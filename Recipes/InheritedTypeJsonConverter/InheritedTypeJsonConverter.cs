﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InheritedTypeJsonConverter.cs">
//     Copyright (c) 2016. All rights reserved. Licensed under the MIT license. See LICENSE file in
//     the project root for full license information.
// </copyright>
// <auto-generated>
// Sourced from NuGet package. Will be overwritten with package update except in Spritely.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Spritely.Recipes
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Significantly rewritten from original source at: http://StackOverflow.com/a/17247339/1442829
    /// --- This requires the base type it's used on to declare all of the types it might use... ---
    /// Use Bindable Attribute to match a derived class based on the class given to the serializer
    /// Selected class will be the first class to match all properties in the json object.
    /// </summary>
#if !RecipesProject
    [System.Diagnostics.DebuggerStepThrough]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.CodeDom.Compiler.GeneratedCode("Spritely.Recipes", "See package version number")]
#endif

    internal partial class InheritedTypeJsonConverter : JsonConverter
    {
        private readonly ConcurrentDictionary<Type, IReadOnlyCollection<Type>> allChildTypes =
            new ConcurrentDictionary<Type, IReadOnlyCollection<Type>>();

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            var attributes = Attribute.GetCustomAttributes(objectType, typeof(BindableAttribute));
            if (!attributes.Any())
            {
                return false;
            }

            var childTypes = GetChildTypes(objectType);

            return childTypes.Any();
        }

        /// <inheritdoc />
        /// <remarks>
        /// - Methodology
        ///   - Get all child types of the specified type.
        ///   - Filter to child types where every 1st level JSON property is either a public (accessor is public)
        ///     property or a public field of the child type, using case-insensitive matching.  Child types passing
        ///     this filter are called 'candidates'.
        ///   - If there are no candidates, then throw.
        ///   - For all candidates, ask the serializer to deserialize the JSON as the candidate type.  Catch and 
        ///     ignore exceptions when attempting to deserialize.
        ///   - If more than one candidate successfully deserializes, then throw.
        /// - Using the serializer to deserialize enables the method to support types with constructors,
        ///   which JSON.net does well out-of-the-box and which would be consumbersome to emulate.
        /// - This method does not consider > 1st level JSON properties to determine candidates.  In other words,
        ///   it is not matching on the fields/properties of the child's fields/properties (e.g. the match is done 
        ///   on Dog.Owner, not Dog.Owner.OwnersAddress).  The issue is that that kind of matching would require
        ///   complex logic.  For example, Strings have properties such as Length which would need to be ignored 
        ///   when reflecting.  Similarly, all fields/properites of value-types would need to be ignored.  There 
        ///   are likely other corner-cases.  To keep things simple, if the 1st level properties match the type's
        ///   properties and fields, by name, we hand-off the problem to the serializer and let it throw if
        ///   there is some incompatability deep in the field/property hierarchy.
        /// - This method does not consider the type of objects containted within JSON arrays to determine
        ///   candidates.  This is difficult because JSON arrays can contain a mix of types (just likes .net 
        ///   objects) and every element would have to be deserialized and matched against the child's IEnumerable
        ///   type and undoubtedly complexity would arrise from dealing with generics and the vast implementations
        ///   of IEnumerable.  Like the bullet above, we simply hand-off the problem to the serializer.
        /// - If properties or fields are removed from a child type after it has been serialized, then the JSON
        ///   will not deserialize properly because that child type will no longer be a candidate.  If, however,
        ///   properties or fields are added to the child type, then the child type will continue to be a
        ///   candidate for the serialized JSON.
        /// - If the user serializes private or internal fields/properties, then this method will not work because
        ///   it only looks for public fields/properties.  We cannot bank on the JSON having been serialized by
        ///   the same serialized passed to this method.  Even if we could, the serializer is so highly 
        ///   configurable that it would be difficult to determine whether or which internal or private fields
        ///   or properites are serialized.
        /// - It's OK if the JSON is serialized with NullValueHandling.Ignore because the candidate filter tries
        ///   to find all JSON properties in child type's properties/fields, and not vice-versa.  However, depending
        ///   on how permissive the serializer's Contract Resolver is, those candidates may or may not be able to
        ///   be deserialized.  For example, if constructor parameters are required and a particular parameter is
        ///   excluded from the JSON, then that type cannot be deserialized.
        /// </remarks>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var jsonObject = JObject.Load(reader);
            var childTypes = GetChildTypes(objectType).ToList();

            var jsonProperties = GetProperties(jsonObject);
            var candidateChildTypes = new List<Type>();
            foreach (var childType in childTypes)
            {
                var childTypeProperties = childType.GetProperties().Select(t => t.Name).ToList();
                var childTypeFields = childType.GetFields().Select(t => t.Name).ToList();
                var childTypePropertiesAndFields = new HashSet<string>(
                    childTypeProperties.Concat(childTypeFields),
                    StringComparer.OrdinalIgnoreCase);
                if (jsonProperties.All(p => childTypePropertiesAndFields.Contains(p)))
                {
                    candidateChildTypes.Add(childType);
                }
            }

            var deserizliedObjects = new List<object>();
            foreach (var candidateChildType in candidateChildTypes)
            {
                try
                {
                    var deserializedObject = serializer.Deserialize(jsonObject.CreateReader(), candidateChildType);
                    if (deserializedObject != null)
                    {
                        deserizliedObjects.Add(deserializedObject);
                    }
                }
                catch (JsonException)
                {
                }
            }

            if (deserizliedObjects.Count == 0)
            {
                throw new JsonSerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Unable to deserialize to type {0}, value: {1}", objectType, jsonObject));
            }

            if (deserizliedObjects.Count > 1)
            {
                var matchingTypes =
                    deserizliedObjects.Select(_ => _.GetType().Name)
                        .Aggregate((running, current) => running + " | " + current);
                throw new JsonSerializationException(
                    string.Format(CultureInfo.InvariantCulture, "The json string can be deserialized into multiple types: {0}, value: {1}", matchingTypes, jsonObject));
            }

            return deserizliedObjects.Single();
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var jsonObject = JObject.FromObject(value, serializer);
            jsonObject.WriteTo(writer);
        }

        private static List<string> GetProperties(JToken node)
        {
            var result = new List<string>();

            if (node.Type == JTokenType.Object)
            {
                result.AddRange(node.Children<JProperty>().Select(child => child.Name));
            }

            return result;
        }

        private IEnumerable<Type> GetChildTypes(Type type)
        {
            if (!allChildTypes.ContainsKey(type))
            {
                var childTypes = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => !a.FullName.Contains("Microsoft.GeneratedCode"))
                    .SelectMany(
                        a =>
                        {
                            try
                            {
                                return a.GetTypes();
                            }
                            catch (ReflectionTypeLoadException)
                            {
                                return new Type[] { };
                            }
                        })
                    .Where(
                        t =>
                            t != null && t.IsClass && !t.IsAbstract && !t.IsGenericTypeDefinition && t != type && type.IsAssignableFrom(t))
                    .ToList();

                allChildTypes.AddOrUpdate(type, t => childTypes, (t, cts) => childTypes);
            }

            return allChildTypes[type];
        }
    }
}

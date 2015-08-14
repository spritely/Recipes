﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InheritedTypeJsonConverter.cs">
//   Copyright (c) 2015. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// <auto-generated>
//   Sourced from NuGet package. Will be overwritten with package update except in Spritely.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Spritely.Recipes
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    ///     Significantly rewritten from original source at: http://StackOverflow.com/a/17247339/1442829
    ///     ---
    ///     This requires the base type it's used on to declare all of the types it might use...
    ///     ---
    ///     Use KnownType Attribute to match a derived class based on the class given to the serializer
    ///     Selected class will be the first class to match all properties in the json object.
    /// </summary>
#if !RecipesProject
    [DebuggerStepThrough]
    [ExcludeFromCodeCoverage]
    [GeneratedCode("Spritely.Recipes", "See package version number")]
#endif
    internal partial class InheritedTypeJsonConverter : JsonConverter
    {
        private readonly ConcurrentDictionary<Type, IReadOnlyCollection<Type>> allChildTypes =
            new ConcurrentDictionary<Type, IReadOnlyCollection<Type>>();

        private IEnumerable<Type> GetChildTypes(Type type)
        {
            if (!this.allChildTypes.ContainsKey(type))
            {
                var childTypes = AppDomain.CurrentDomain.GetAssemblies()
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
                            t != null && t.IsClass && !t.IsAbstract && t != type && type.IsAssignableFrom(t) &&
                            t.GetConstructor(Type.EmptyTypes) != null)
                    .ToList();

                this.allChildTypes.AddOrUpdate(type, t => childTypes, (t, cts) => childTypes);
            }

            return this.allChildTypes[type];
        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            var childTypes = this.GetChildTypes(objectType);

            return childTypes.Any();
        }

        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var sourceKeys = GetKeys(jsonObject).Select(k => k.Key).ToList();

            var childTypes = this.GetChildTypes(objectType);

            var testObjects = childTypes.Select(Activator.CreateInstance)
                .Select(instance => new { Instance = instance, SerializedInstance = Serialize(serializer, instance) })
                .ToList();

            var testKeys = testObjects.ToDictionary(
                to => to,
                to => GetKeys(to.SerializedInstance).Select(kvp => kvp.Key).ToList());

            var target = testObjects.Select(to => new { TestObject = to, Keys = testKeys[to] })
                .OrderBy(t => t.Keys.Count)
                .FirstOrDefault(t => !sourceKeys.Except(t.Keys).Any()); // Any keys in source that are not in the target object?

            if (target == null)
            {
                throw new JsonSerializationException(string.Format("Unable to deserialize to type {0}, value: {1}", objectType, jsonObject));
            }

            serializer.Populate(jsonObject.CreateReader(), target.TestObject.Instance);

            return target.TestObject.Instance;
        }

        private static JObject Serialize(JsonSerializer serializer, object instance)
        {
            using (var writer = new StringWriter())
            {
                var jsonWriter = new JsonTextWriter(writer);

                serializer.Serialize(jsonWriter, instance);
                var json = writer.ToString();
                var parsed = JObject.Parse(json);
                return parsed;
            }
        }

        private static IEnumerable<KeyValuePair<string, JToken>> GetKeys(JObject jObject)
        {
            var list = new List<KeyValuePair<string, JToken>>();

            foreach (var token in jObject)
            {
                list.Add(token);
            }

            return list;
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var jsonObject = JObject.FromObject(value, serializer);
            jsonObject.WriteTo(writer);
        }
    }
}

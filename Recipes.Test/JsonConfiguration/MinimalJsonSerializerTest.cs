﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinimalJsonSerializerTest.cs">
//     Copyright (c) 2016. All rights reserved. Licensed under the MIT license. See LICENSE file in
//     the project root for full license information.
// </copyright>
// <auto-generated>
// Sourced from NuGet package. Will be overwritten with package update except in Spritely.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Spritely.Recipes.Test
{
    using System.Linq;
    using Newtonsoft.Json.Linq;

    using NUnit.Framework;

    [TestFixture]
    public class MinimalJsonSerializerTest
    {
        [Test]
        public void SerializeObject_without_type_serializes_to_json_using_MinimalSerializerSettings()
        {
            // If Minimal is being used then the null Nickname property won't be serialized
            var dog = new Dog(5, "spud", FurColor.Brindle);

            var json = MinimalJsonSerializer.SerializeObject(dog);

            Assert.That(json, Is.EqualTo("{\"name\":\"spud\",\"furColor\":\"brindle\",\"dogTag\":\"my name is spud\",\"age\":5}"));
        }

        [Test]
        public void DeserializeObjectOfT_deserializes_json_using_MinimalSerializerSettings()
        {
            // If Minimal is being used then empty JSON string will deserialize into NoLighting
            // otherwise, out-of-the-box json.net will create an anonymous object
            var lightingJson = "{}";

            var lighting = MinimalJsonSerializer.DeserializeObject<Lighting>(lightingJson) as NoLighting;

            Assert.That(lighting, Is.Not.Null);
        }

        [Test]
        public void DeserializeObject_with_type_deserializes_json_using_MinimalSerializerSettings()
        {
            // If Minimal is being used then empty JSON string will deserialize into NoLighting
            // otherwise, out-of-the-box json.net will create an anonymous object
            var lightingJson = "{}";

            var lighting = MinimalJsonSerializer.DeserializeObject(lightingJson, typeof(Lighting)) as NoLighting;

            Assert.That(lighting, Is.Not.Null);
        }

        [Test]
        public void DeserializeObject_without_type_deserializes_json_into_JObject_using_MinimalSerializerSettings()
        {
            var dogJson = "{\"name\":\"Barney\",\"furColor\":\"brindle\",\"age\":10}";

            var dog = MinimalJsonSerializer.DeserializeObject(dogJson) as JObject;

            Assert.That(dog.Properties().Count(), Is.EqualTo(3));
            Assert.That(dog["name"].ToString(), Is.EqualTo("Barney"));
            Assert.That(dog["age"].ToString(), Is.EqualTo("10"));
            Assert.That(dog["furColor"].ToString(), Is.EqualTo("brindle"));
        }
    }
}

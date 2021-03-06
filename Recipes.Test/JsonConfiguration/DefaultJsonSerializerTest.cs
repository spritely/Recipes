﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultJsonSerializerTest.cs">
//     Copyright (c) 2017. All rights reserved. Licensed under the MIT license. See LICENSE file in
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
    public class DefaultJsonSerializerTest
    {
        [Test]
        public void SerializeObject_without_type_serializes_to_json_using_DefaultSerializerSettings()
        {
            // If Default is being used then there should be new lines
            var dog = new Dog(5, "spud", FurColor.Brindle);

            var json = DefaultJsonSerializer.SerializeObject(dog);

            Assert.That(json, Is.EqualTo("{\r\n  \"name\": \"spud\",\r\n  \"furColor\": \"brindle\",\r\n  \"dogTag\": \"my name is spud\",\r\n  \"nickname\": null,\r\n  \"age\": 5\r\n}"));
        }

        [Test]
        public void DeserializeObjectOfT_deserializes_json_using_DefaultSerializerSettings()
        {
            // If Default is being used then strict constructor matching will result in a Dog and not a Mouse
            var dogJson = "{\"name\":\"Barney\",\"furColor\":\"brindle\",\"age\":10}";

            var dog = DefaultJsonSerializer.DeserializeObject<Animal>(dogJson) as Dog;

            Assert.That(dog, Is.Not.Null);
            Assert.That(dog.Name, Is.EqualTo("Barney"));
            Assert.That(dog.Age, Is.EqualTo(10));
            Assert.That(dog.FurColor, Is.EqualTo(FurColor.Brindle));
            Assert.That(dog.DogTag, Is.EqualTo("my name is Barney"));
        }

        [Test]
        public void DeserializeObject_with_type_deserializes_json_using_DefaultSerializerSettings()
        {
            // If Default is being used then strict constructor matching will result in a Dog and not a Mouse
            var dogJson = "{\"name\":\"Barney\",\"furColor\":\"brindle\",\"age\":10}";

            var dog = DefaultJsonSerializer.DeserializeObject(dogJson, typeof(Animal)) as Dog;

            Assert.That(dog, Is.Not.Null);
            Assert.That(dog.Name, Is.EqualTo("Barney"));
            Assert.That(dog.Age, Is.EqualTo(10));
            Assert.That(dog.FurColor, Is.EqualTo(FurColor.Brindle));
            Assert.That(dog.DogTag, Is.EqualTo("my name is Barney"));
        }

        [Test]
        public void DeserializeObject_without_type_deserializes_json_into_JObject_using_DefaultSerializerSettings()
        {
            var dogJson = "{\"name\":\"Barney\",\"furColor\":\"brindle\",\"age\":10}";

            var dog = DefaultJsonSerializer.DeserializeObject(dogJson) as JObject;

            Assert.That(dog.Properties().Count(), Is.EqualTo(3));
            Assert.That(dog["name"].ToString(), Is.EqualTo("Barney"));
            Assert.That(dog["age"].ToString(), Is.EqualTo("10"));
            Assert.That(dog["furColor"].ToString(), Is.EqualTo("brindle"));
        }        
    }
}

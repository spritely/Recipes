﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonConfigurationTest.cs">
//     Copyright (c) 2016. All rights reserved. Licensed under the MIT license. See LICENSE file in
//     the project root for full license information.
// </copyright>
// <auto-generated>
// Sourced from NuGet package. Will be overwritten with package update except in Spritely.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Spritely.Recipes.Test
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Security;
    using Newtonsoft.Json;
    using NUnit.Framework;

    [TestFixture]
    public class JsonConfigurationTest
    {
        [Test]
        public void Serializer_serializes_camel_cased_properties()
        {
            var value = new CamelCasedPropertyTest()
            {
                TestName = "Hello"
            };

            var result = JsonConvert.SerializeObject(value, JsonConfiguration.DefaultSerializerSettings);

            var serializedValue = "{" + Environment.NewLine +
                                  "  \"testName\": \"Hello\"" + Environment.NewLine +
                                  "}";

            Assert.That(result, Is.EqualTo(serializedValue));
        }

        [Test]
        public void Serializer_deserializes_camel_cased_properties()
        {
            var serializedValue = "{" + Environment.NewLine +
                                  "  \"testName\": \"there\"" + Environment.NewLine +
                                  "}";

            var result = JsonConvert.DeserializeObject<CamelCasedPropertyTest>(serializedValue, JsonConfiguration.DefaultSerializerSettings);

            Assert.That(result.TestName, Is.EqualTo("there"));
        }

        [Test]
        public void Serializer_serializes_camel_cased_enumerations()
        {
            var value = new CamelCasedEnumTest()
            {
                Value = TestEnum.FirstOption
            };

            var result = JsonConvert.SerializeObject(value, JsonConfiguration.DefaultSerializerSettings);

            var serializedValue = "{" + Environment.NewLine +
                                  "  \"value\": \"firstOption\"" + Environment.NewLine +
                                  "}";

            Assert.That(result, Is.EqualTo(serializedValue));
        }

        [Test]
        public void Serializer_deserializes_camel_cased_enumerations()
        {
            var serializedValue = "{" + Environment.NewLine +
                                  "  \"value\": \"secondOption\"" + Environment.NewLine +
                                  "}";

            var result = JsonConvert.DeserializeObject<CamelCasedEnumTest>(serializedValue, JsonConfiguration.DefaultSerializerSettings);

            Assert.That(result.Value, Is.EqualTo(TestEnum.SecondOption));
        }

        [Test]
        public void Serializer_serializes_and_deserializes_SecureString_types()
        {
            var serializedValue = "{" + Environment.NewLine +
                                  "  \"secure\": \"Password\"" + Environment.NewLine +
                                  "}";

            var deserialized = JsonConvert.DeserializeObject<SecureStringTest>(serializedValue, JsonConfiguration.DefaultSerializerSettings);

            var result = JsonConvert.SerializeObject(deserialized, JsonConfiguration.DefaultSerializerSettings);

            Assert.That(result, Is.EqualTo(serializedValue));
        }

        [Test]
        public void Serializer_serializes_InheritedTypes()
        {
            var value = new InheritedTypeBase[]
            {
                new InheritedType1
                {
                    Base = "Base",
                    Child1 = "Child1"
                },
                new InheritedType2
                {
                    Base = "my base",
                    Child2 = "my child 2"
                }
            };

            var result = JsonConvert.SerializeObject(value, JsonConfiguration.DefaultSerializerSettings);

            var serializedValue = "[" + Environment.NewLine +
                                  "  {" + Environment.NewLine +
                                  "    \"child1\": \"Child1\"," + Environment.NewLine +
                                  "    \"base\": \"Base\"" + Environment.NewLine +
                                  "  }," + Environment.NewLine +
                                  "  {" + Environment.NewLine +
                                  "    \"child2\": \"my child 2\"," + Environment.NewLine +
                                  "    \"base\": \"my base\"" + Environment.NewLine +
                                  "  }" + Environment.NewLine +
                                  "]";

            Assert.That(result, Is.EqualTo(serializedValue));
        }

        [Test]
        public void Serializer_deserializes_InheritedTypes()
        {
            var serializedValue = "[" + Environment.NewLine +
                                  "  {" + Environment.NewLine +
                                  "    \"child1\": \"My child 1\"," + Environment.NewLine +
                                  "    \"base\": \"My base\"" + Environment.NewLine +
                                  "  }," + Environment.NewLine +
                                  "  {" + Environment.NewLine +
                                  "    \"child2\": \"child 2\"," + Environment.NewLine +
                                  "    \"base\": \"base\"" + Environment.NewLine +
                                  "  }" + Environment.NewLine +
                                  "]";

            var result = JsonConvert.DeserializeObject<InheritedTypeBase[]>(serializedValue, JsonConfiguration.DefaultSerializerSettings);

            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0].Base, Is.EqualTo("My base"));
            Assert.That((result[0] as InheritedType1), Is.Not.Null);
            Assert.That((result[0] as InheritedType1).Child1, Is.EqualTo("My child 1"));
            Assert.That(result[1].Base, Is.EqualTo("base"));
            Assert.That((result[1] as InheritedType2), Is.Not.Null);
            Assert.That((result[1] as InheritedType2).Child2, Is.EqualTo("child 2"));
        }

        [Test]
        public void Serializer_deserializes_partial_InheritedTypes()
        {
            var serializedValue = "[" + Environment.NewLine +
                                  "  {" + Environment.NewLine +
                                  "    \"string\": \"My string\"," + Environment.NewLine +
                                  "    \"int32\": 5" + Environment.NewLine +
                                  "  }," + Environment.NewLine +
                                  "  {" + Environment.NewLine +
                                  "    \"int32\": 55," + Environment.NewLine +
                                  "    \"float\": 3.56" + Environment.NewLine +
                                  "  }" + Environment.NewLine +
                                  "]";

            var result = JsonConvert.DeserializeObject<IBaseInterface[]>(serializedValue, JsonConfiguration.DefaultSerializerSettings);

            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0].String, Is.EqualTo("My string"));
            Assert.That((result[0] as InheritedType3), Is.Not.Null);
            Assert.That((result[0] as InheritedType3).Int32, Is.EqualTo(5));
            Assert.That((result[0] as InheritedType3).Float, Is.EqualTo(default(float)));
            Assert.That(result[1].String, Is.Null);
            Assert.That((result[1] as InheritedType3), Is.Not.Null);
            Assert.That((result[1] as InheritedType3).Int32, Is.EqualTo(55));
            Assert.That(Math.Round((result[1] as InheritedType3).Float, 2), Is.EqualTo(Math.Round(3.56, 2)));
        }

        [Test]
        public void Serializer_deserializes_inherited_types_with_constructors()
        {
            var dogJson = "{\"name\":\"Barney\",\"furColor\":\"brindle\",\"age\":10,\"dogTag\":\"my name is Barney\"}";
            var catJson = "{\"numberOfLives\":9,\"name\":\"Cleo\",\"age\":3}";
            var tigerJson = "{\"tailLength\":2,\"name\":\"Ronny\",\"numberOfTeeth\":50,\"age\":5}";
            var mouseJson = "{\"tailLength\":8,\"name\":\"Missy\",\"furColor\":\"black\",\"age\":7}";

            var dog = JsonConvert.DeserializeObject<Animal>(dogJson, JsonConfiguration.DefaultSerializerSettings) as Dog;
            var cat = JsonConvert.DeserializeObject<Animal>(catJson, JsonConfiguration.DefaultSerializerSettings) as Cat;
            var tiger = JsonConvert.DeserializeObject<Animal>(tigerJson, JsonConfiguration.DefaultSerializerSettings) as Tiger;
            var mouse = JsonConvert.DeserializeObject<Animal>(mouseJson, JsonConfiguration.DefaultSerializerSettings) as Mouse;

            Assert.That(dog, Is.Not.Null);
            Assert.That(dog.Name, Is.EqualTo("Barney"));
            Assert.That(dog.Age, Is.EqualTo(10));
            Assert.That(dog.FurColor, Is.EqualTo(FurColor.Brindle));
            Assert.That(dog.DogTag, Is.EqualTo("my name is Barney"));

            Assert.That(cat, Is.Not.Null);
            Assert.That(cat.Name, Is.EqualTo("Cleo"));
            Assert.That(cat.Age, Is.EqualTo(3));
            Assert.That(cat.NumberOfLives, Is.EqualTo(9));

            Assert.That(tiger, Is.Not.Null);
            Assert.That(tiger.Name, Is.EqualTo("Ronny"));
            Assert.That(tiger.Age, Is.EqualTo(5));
            Assert.That(tiger.TailLength, Is.EqualTo(2));
            Assert.That(tiger.NumberOfTeeth, Is.EqualTo(50));

            Assert.That(mouse, Is.Not.Null);
            Assert.That(mouse.Name, Is.EqualTo("Missy"));
            Assert.That(mouse.Age, Is.EqualTo(7));
            Assert.That(mouse.TailLength, Is.EqualTo(8));
            Assert.That(mouse.FurColor, Is.EqualTo(FurColor.Black));
        }

        [Test]
        public void Serializer_deserializes_to_type_having_all_constructor_parameters_in_json_when_another_types_constructor_has_all_the_same_parameters_but_one_additional_one_which_is_not_in_the_json()
        {
            var dogJson = "{\"name\":\"Barney\",\"furColor\":\"brindle\",\"age\":10}";

            var dog = JsonConvert.DeserializeObject<Animal>(dogJson, JsonConfiguration.DefaultSerializerSettings) as Dog;

            Assert.That(dog, Is.Not.Null);
            Assert.That(dog.Name, Is.EqualTo("Barney"));
            Assert.That(dog.Age, Is.EqualTo(10));
            Assert.That(dog.FurColor, Is.EqualTo(FurColor.Brindle));
            Assert.That(dog.DogTag, Is.EqualTo("my name is Barney"));
        }

        [Test]
        public void Serializer_throws_JsonSerializationException_when_json_deserializes_to_multiple_child_types_and_lists_all_possible_child_types_when_none_strictly_match()
        {
            var inheritedTypeJson = "{\"base\":\"my base string\"}";

            var ex = Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<InheritedTypeBase>(inheritedTypeJson, JsonConfiguration.DefaultSerializerSettings));

            Assert.That(ex.Message, Does.Contain("InheritedType1"));
            Assert.That(ex.Message, Does.Contain("InheritedType2"));
        }

        [Test]
        public void Serializer_throws_JsonSerializationException_when_json_deserializes_to_multiple_child_types_and_lists_only_strictly_matching_child_types_when_there_are_some_that_strictly_match()
        {
            var lightingJson = "{\"watts\":10, \"wattageEquivalent\":60}";

            var ex = Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<Lighting>(lightingJson, JsonConfiguration.DefaultSerializerSettings));

            Assert.That(ex.Message, Does.Contain("CompactFluorescent"));
            Assert.That(ex.Message, Does.Contain("Led"));
            Assert.That(ex.Message, Does.Not.Contain("SmartLed"));
        }

        [Test]
        public void Serializer_deserializes_to_only_child_type_that_strictly_matches_json_when_json_can_deserialize_into_multiple_child_types()
        {
            var noLightingJson = "{}";
            var incandescentJson = "{\"watts\":60}";

            var noLighting = JsonConvert.DeserializeObject<Lighting>(noLightingJson, JsonConfiguration.DefaultSerializerSettings) as NoLighting;
            var incandescent = JsonConvert.DeserializeObject<Lighting>(incandescentJson, JsonConfiguration.DefaultSerializerSettings) as Incandescent;

            Assert.That(noLighting, Is.Not.Null);

            Assert.That(incandescent, Is.Not.Null);
            Assert.That(incandescent.Watts, Is.EqualTo(60));
        }

        [Test]
        public void Serializer_throws_JsonSerializationException_when_json_cannot_be_deserialized_into_any_child_types()
        {
            var json = "{\"none\":\"none\"}";

            var ex = Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<Animal>(json, JsonConfiguration.DefaultSerializerSettings));

            Assert.That(ex.Message, Does.Contain("Unable to deserialize"));
        }

        [Test]
        public void Serializer_deserializes_inherited_types_when_null_property_is_not_included_in_json()
        {
            var json = "{\"float\":.2,\"int32\":50}";

            var inheritedType3 = JsonConvert.DeserializeObject<IBaseInterface>(json, JsonConfiguration.DefaultSerializerSettings) as InheritedType3;

            Assert.That(inheritedType3, Is.Not.Null);
            Assert.That(inheritedType3.Int32, Is.EqualTo(50));
            Assert.That(inheritedType3.Float, Is.EqualTo(.2f));
            Assert.That(inheritedType3.String, Is.Null);
        }

        [Test]
        public void Serializer_throws_JsonSerializationException_when_json_has_extra_properties_not_available_on_any_child_type()
        {
            var tigerJson = "{\"tailLength\":2,\"name\":\"Ronny\",\"numberOfTeeth\":50,\"age\":5, \"newProperty\":66}";

            var ex = Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<Animal>(tigerJson, JsonConfiguration.DefaultSerializerSettings));

            Assert.That(ex.Message, Does.Contain("Unable to deserialize"));
        }

        [Test]
        public void Serializer_throws_JsonSerializationException_when_candidate_child_type_cannot_be_deserialized_because_property_type_in_json_does_not_match_childs_property_type()
        {
            // name was changed from string to object
            var tigerJson = "{\"tailLength\":2,\"name\":{ \"first\":\"Ronny\",\"last\":\"Ronnerson\" },\"numberOfTeeth\":50,\"age\":5}";

            var ex = Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<Animal>(tigerJson, JsonConfiguration.DefaultSerializerSettings));

            Assert.That(ex.Message, Does.Contain("Unable to deserialize"));
        }

        [Test]
        public void Serializer_deserializes_empty_json_into_the_only_child_type_that_has_a_default_constructor()
        {
            var atkinsJson = "{}";

            var atkins = JsonConvert.DeserializeObject<Diet>(atkinsJson, JsonConfiguration.DefaultSerializerSettings) as Atkins;

            Assert.That(atkins, Is.Not.Null);
        }

        [Test]
        public void Serializer_throws_JsonSerializationException_when_a_constructor_parameter_is_missing_in_json_and_that_parameter_is_a_property_on_the_child_type()
        {
            var catJson1 = "{\"numberOfLives\":9,\"name\":\"Cleo\"}";
            var catJson2 = "{\"numberOfLives\":9,\"age\":3}";

            var ex1 = Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<Animal>(catJson1, JsonConfiguration.DefaultSerializerSettings));
            var ex2 = Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<Animal>(catJson2, JsonConfiguration.DefaultSerializerSettings));

            Assert.That(ex1.Message, Does.Contain("Unable to deserialize"));
            Assert.That(ex2.Message, Does.Contain("Unable to deserialize"));
        }

        [Test]
        public void Serializer_throws_JsonSerializationException_when_a_constructor_parameter_is_missing_in_json_and_that_parameter_is_not_a_property_on_the_child_type()
        {
            var fructoseJson = "{\"minOuncesOfFructose\":5}";

            var ex = Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<Diet>(fructoseJson, JsonConfiguration.DefaultSerializerSettings));

            Assert.That(ex.Message, Does.Contain("Unable to deserialize"));
        }

        [Test]
        public void Serializer_throws_JsonSerializationException_when_constructor_parameter_is_in_json_but_type_has_no_corresponding_property()
        {
            var fructoseJson = "{\"minGramsOfFructose\":5}";

            var ex = Assert.Throws<JsonSerializationException>(() => JsonConvert.DeserializeObject<Diet>(fructoseJson, JsonConfiguration.DefaultSerializerSettings));

            Assert.That(ex.Message, Does.Contain("Unable to deserialize"));
        }

        [Test]
        public void Serializer_deserializes_type_with_no_constructor_that_has_a_property_that_is_an_inherited_type()
        {
            var dogDietJson = "{\"dog\":{\"name\":\"Barney\",\"furColor\":\"brindle\",\"age\":10}, \"diet\":{}}";

            var dogDiet = JsonConvert.DeserializeObject<DogDiet>(dogDietJson, JsonConfiguration.DefaultSerializerSettings);

            Assert.That(dogDiet, Is.Not.Null);

            Assert.That(dogDiet.Dog, Is.Not.Null);
            Assert.That(dogDiet.Dog.Name, Is.EqualTo("Barney"));
            Assert.That(dogDiet.Dog.Age, Is.EqualTo(10));
            Assert.That(dogDiet.Dog.FurColor, Is.EqualTo(FurColor.Brindle));
            Assert.That(dogDiet.Dog.DogTag, Is.EqualTo("my name is Barney"));

            Assert.That(dogDiet.Diet, Is.TypeOf<Atkins>());
        }

        [Test]
        public void Serializer_deserializes_type_with_no_constructor_that_has_a_property_that_is_an_inherited_type_and_is_null_in_json()
        {
            var dogDietJson = "{\"dog\":{\"name\":\"Barney\",\"furColor\":\"brindle\",\"age\":10}, \"diet\":null}";

            var dogDiet = JsonConvert.DeserializeObject<DogDiet>(dogDietJson, JsonConfiguration.DefaultSerializerSettings);

            Assert.That(dogDiet, Is.Not.Null);

            Assert.That(dogDiet.Dog, Is.Not.Null);
            Assert.That(dogDiet.Dog.Name, Is.EqualTo("Barney"));
            Assert.That(dogDiet.Dog.Age, Is.EqualTo(10));
            Assert.That(dogDiet.Dog.FurColor, Is.EqualTo(FurColor.Brindle));
            Assert.That(dogDiet.Dog.DogTag, Is.EqualTo("my name is Barney"));

            Assert.That(dogDiet.Diet, Is.Null);
        }

        [Test]
        public void Serializer_deserializes_type_with_constructor_that_has_a_property_that_is_an_inherited_type()
        {
            var catDietJson = "{\"cat\":{\"numberOfLives\":9,\"name\":\"Cleo\",\"age\":3}, \"diet\":{}}";
            
            var catDiet = JsonConvert.DeserializeObject<CatDiet>(catDietJson, JsonConfiguration.DefaultSerializerSettings);

            Assert.That(catDiet, Is.Not.Null);
            Assert.That(catDiet.Cat, Is.Not.Null);
            Assert.That(catDiet.Cat.Name, Is.EqualTo("Cleo"));
            Assert.That(catDiet.Cat.Age, Is.EqualTo(3));
            Assert.That(catDiet.Cat.NumberOfLives, Is.EqualTo(9));

            Assert.That(catDiet.Diet, Is.TypeOf<Atkins>());
        }

        [Test]
        public void Serializer_deserializes_type_with_constructor_that_has_a_property_that_is_an_inherited_type_and_is_null_in_json()
        {
            var catDietJson = "{\"cat\":{\"numberOfLives\":9,\"name\":\"Cleo\",\"age\":3}, \"diet\":null}";

            var catDiet = JsonConvert.DeserializeObject<CatDiet>(catDietJson, JsonConfiguration.DefaultSerializerSettings);

            Assert.That(catDiet, Is.Not.Null);
            Assert.That(catDiet.Cat, Is.Not.Null);
            Assert.That(catDiet.Cat.Name, Is.EqualTo("Cleo"));
            Assert.That(catDiet.Cat.Age, Is.EqualTo(3));
            Assert.That(catDiet.Cat.NumberOfLives, Is.EqualTo(9));

            Assert.That(catDiet.Diet, Is.Null);
        }

        private class CamelCasedPropertyTest
        {
            public string TestName;
        }

        private class CamelCasedEnumTest
        {
            public TestEnum Value;
        }

        [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses",
            Justification = "Class is used by code external to test")]
        private class SecureStringTest
        {
#pragma warning disable 649

            [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields",
                Justification = "Field is used by code external to test")]
            public SecureString Secure;

#pragma warning restore
        }

        private enum TestEnum
        {
            FirstOption,
            SecondOption
        }

        [Bindable(false)]
        private class InheritedTypeBase
        {
            public string Base;
        }

        private class InheritedType1 : InheritedTypeBase
        {
            public string Child1;
        }

        private class InheritedType2 : InheritedTypeBase
        {
            public string Child2;
        }

        [Bindable(true)]
        private interface IBaseInterface
        {
            string String { get; set; }
        }

        [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses",
            Justification = "Class is used via reflection and code analysis cannot detect that.")]
        private class InheritedType3 : IBaseInterface
        {
            public float Float { get; set; }

            public int Int32 { get; set; }

            public string String { get; set; }
        }

        [Bindable(true)]
        private class Diet
        {
        }

        [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Class is used but is constructed via reflection and code analysis cannot detect that.")]
        private class Atkins : Diet
        {
        }

        [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Class is used but is constructed via reflection and code analysis cannot detect that.")]
        private class LowCalorie : Diet
        {
            public LowCalorie(int maxCalories)
            {
                MaxCalories = maxCalories;
            }

            public int MaxCalories { get; }
        }

        [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Class is used but is constructed via reflection and code analysis cannot detect that.")]
        private class Vegan : Diet
        {
            public Vegan(bool isHoneyAllowed)
            {
                IsHoneyAllowed = isHoneyAllowed;
            }

            public bool IsHoneyAllowed { get; }
        }

        [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Class is used but is constructed via reflection and code analysis cannot detect that.")]
        private class HighFructose : Diet
        {
            public HighFructose(int minGramsOfFructose)
            {
                MinOuncesOfFructose = minGramsOfFructose * .035;
            }

            public double MinOuncesOfFructose { get; }
        }

        [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Class is used but is constructed via reflection and code analysis cannot detect that.")]
        private class DogDiet
        {
            public Dog Dog { get; set; }

            public Diet Diet { get; set; }
        }

        [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Class is used but is constructed via reflection and code analysis cannot detect that.")]
        private class CatDiet
        {
            public CatDiet(Cat cat, Diet diet)
            {
                Cat = cat;
                Diet = diet;
            }

            public Cat Cat { get; }

            public Diet Diet { get; }
        }
    }
}

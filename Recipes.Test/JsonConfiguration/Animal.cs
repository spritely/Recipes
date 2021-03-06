﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Animal.cs">
//     Copyright (c) 2017. All rights reserved. Licensed under the MIT license. See LICENSE file in
//     the project root for full license information.
// </copyright>
// <auto-generated>
// Sourced from NuGet package. Will be overwritten with package update except in Spritely.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Spritely.Recipes.Test
{
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;

    [Bindable(true)]
    internal class Animal
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called during JSON deserialization but code analysis cannot detect that.")]
        protected Animal(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public string Name;

        public int Age { get; }
    }

    internal enum FurColor
    {
        Black,

        Brindle,

        Golden
    }

    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Class is used but is constructed via reflection and code analysis cannot detect that.")]
    internal class Dog : Animal
    {
        public Dog(int age, string name, FurColor furColor)
            : base(age, name)
        {
            FurColor = furColor;
            DogTag = "my name is " + name;
        }

        public FurColor FurColor { get; }

        public string DogTag { get; }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Property is used via reflection and code analysis cannot detect that.")]
        public string Nickname { get; set; }
    }

    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Class is used but is constructed via reflection and code analysis cannot detect that.")]
    internal class Cat : Animal
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Constructor is used via reflection and code analysis cannot detect that.")]
        public Cat(int age, string name, int numberOfLives)
            : base(age, name)
        {
            NumberOfLives = numberOfLives;
        }

        public int NumberOfLives;
    }

    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Class is used but is constructed via reflection and code analysis cannot detect that.")]
    internal class Mouse : Animal
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Constructor is used via reflection and code analysis cannot detect that.")]
        public Mouse(int age, string name, FurColor furColor, int tailLength)
            : base(age, name)
        {
            FurColor = furColor;
            TailLength = tailLength;
        }

        public FurColor FurColor { get; }

        public int TailLength;
    }

    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Class is used but is constructed via reflection and code analysis cannot detect that.")]
    internal class Tiger : Animal
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Constructor is used via reflection and code analysis cannot detect that.")]
        public Tiger(int age, string name, int numberOfTeeth, int tailLength)
            : base(age, name)
        {
            NumberOfTeeth = numberOfTeeth;
            TailLength = tailLength;
        }

        public int NumberOfTeeth { get; }

        public int TailLength;
    }
}

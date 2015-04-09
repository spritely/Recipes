﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecureStringTest.cs">
//   Copyright (c) 2015. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// <auto-generated>
//   Sourced from NuGet package. Will be overwritten with package update except in Spritely.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Spritely.Recipes.Test
{
    using System;
    using System.Security;
    using NUnit.Framework;

    [TestFixture]
    public class SecureStringTest
    {
        [Test]
        public void ToInsecureString_throws_on_null_arguments()
        {
            Assert.Throws<ArgumentNullException>(() => (null as SecureString).ToInsecureString());
        }

        [Test]
        public void ToInsecureString_produces_expected_value()
        {
            var expected = "My secure string";

            var secure = new SecureString();
            expected.ToCharArray().ForEach(c => secure.AppendChar(c));
            secure.MakeReadOnly();

            var actual = secure.ToInsecureString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ToSecureString_throws_on_null_arguments()
        {
            Assert.Throws<ArgumentNullException>(() => (null as string).ToSecureString());
        }

        [Test]
        public void ToSecureString_creates_secure_version_of_source_string()
        {
            var expected = "Hello world";

            var secure = expected.ToSecureString();

            // Comparing SecureString types is difficult so taking advantage of separate ToInsecureString() method to verify outcome
            // Note that there is a separate test that verifies its operation independently so this test really is just testing ToSecureString()
            var actual = secure.ToInsecureString();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderedNumbersCompressionTest.cs">
//   Copyright (c) 2016. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// <auto-generated>
//   Sourced from NuGet package. Will be overwritten with package update except in Spritely.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Spritely.Recipes.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class OrderedNumbersCompressionTest
    {
        [Test]
        public void Deflate_throws_on_null_arguments()
        {
            Assert.Throws<ArgumentNullException>(() => (null as string).Deflate());
        }

        [Test]
        public void Inflate_throws_on_null_arguments()
        {
            Assert.Throws<ArgumentNullException>(() => (null as string).Inflate());
        }

        [Test]
        public void Compress_throws_on_null_arguments()
        {
            Assert.Throws<ArgumentNullException>(() => (null as IEnumerable<int>).Compress());
        }

        [Test]
        public void Decompress_throws_on_null_arguments()
        {
            Assert.Throws<ArgumentNullException>(() => (null as string).Decompress());
        }

        [Test]
        public void Inflate_on_Deflated_result_produces_original_value()
        {
            // Short strings can produce longer output than input
            var expected = @"This is a random string. Can it be inflated and deflated?
Let's go on and on with this for a while longer until it is a sufficiently long string.
Not long enough yet. Nope. How about a litte more? And some more? Yep, I think that is enough.";

            var deflated = expected.Deflate();
            var result = deflated.Inflate();

            deflated.Length.Should().BeLessThan(expected.Length);
            result.Should().Be(expected);
        }

        [Test]
        public void Decompress_on_Compressed_result_produces_original_value()
        {
            var expected = Enumerable.Range(5, 10).Concat(Enumerable.Range(100, 20)).ToList();

            var compressed = expected.Compress();
            var result = compressed.Decompress();

            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Decompress_and_Inflate_on_Deflated_and_Compressed_result_produces_original_value()
        {
            var expected = Enumerable.Range(5, 10).Concat(Enumerable.Range(100, 20)).ToList();

            var deflatedAndCompressed = expected.Compress().Deflate();
            var result = deflatedAndCompressed.Inflate().Decompress();

            result.Should().BeEquivalentTo(expected);
        }
    }
}

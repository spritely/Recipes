﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderedNumbersCompression.cs">
//     Copyright (c) 2017. All rights reserved. Licensed under the MIT license. See LICENSE file in
//     the project root for full license information.
// </copyright>
// <auto-generated>
// Sourced from NuGet package. Will be overwritten with package update except in Spritely.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Spritely.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Responsible for compressing an ordered set of numbers (unordered does not produce good results).
    /// Core algorithm sourced from: http://stackoverflow.com/a/1081776
    /// </summary>
#if !SpritelyRecipesProject
    [System.Diagnostics.DebuggerStepThrough]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.CodeDom.Compiler.GeneratedCode("Spritely.Recipes", "See package version number")]
#pragma warning disable 0436
#endif
    internal static partial class OrderedNumbersCompression
    {
        /// <summary>
        /// Deflates the specified source using .NET deflate algorithm. To reverse use <see cref="Inflate"/>.
        /// </summary>
        /// <param name="source">The source to deflate.</param>
        /// <returns>The deflated source.</returns>
        /// <exception cref="System.ArgumentNullException">If source is null.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "The fix for code analysis breaks the algorithm.")]
        public static string Deflate(this string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var data = Encoding.UTF8.GetBytes(source);

            byte[] compressed;
            using (var outputStream = new MemoryStream())
            {
                using (var deflatedStream = new DeflateStream(outputStream, CompressionMode.Compress))
                using (var sourceStream = new MemoryStream(data))
                {
                    sourceStream.CopyTo(deflatedStream);
                }

                compressed = outputStream.ToArray();
            }

            var output = Convert.ToBase64String(compressed);
            return output;
        }

        /// <summary>
        /// Inflates the specified source using .NET deflate algorithm. Inverse of <see cref="Deflate"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The inflated source.</returns>
        /// <exception cref="System.ArgumentNullException">If source is null.</exception>
        public static string Inflate(this string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var data = Convert.FromBase64String(source);
            string output;

            using (var inputStream = new MemoryStream(data))
            {
                var deflateStream = new DeflateStream(inputStream, CompressionMode.Decompress);
                using (var outputStream = new MemoryStream())
                {
                    deflateStream.CopyTo(outputStream);
                    output = Encoding.UTF8.GetString(outputStream.ToArray());
                }
            }

            return output;
        }

        /// <summary>
        /// Compresses the specified source. To reverse use <see cref="Decompress"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The compressed source.</returns>
        /// <exception cref="System.ArgumentNullException">If source is null.</exception>
        public static string Compress(this IEnumerable<int> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            string result;
            using (var ms = new MemoryStream())
            {
                Encode(ms, source.ToList());
                ms.Seek(0, SeekOrigin.Begin);
                result = Convert.ToBase64String(ms.ToArray());
            }

            return result;
        }

        /// <summary>
        /// Decompresses the specified source. Inverse of <see cref="Compress"/>.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>The decompressed source.</returns>
        /// <exception cref="System.ArgumentNullException">If source is null.</exception>
        public static IList<int> Decompress(this string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var data = Convert.FromBase64String(source);
            IList<int> result;
            using (var ms = new MemoryStream(data))
            {
                ms.Seek(0, SeekOrigin.Begin);
                result = Decode(ms);
            }

            return result;
        }

        private static IList<int> Decode(Stream stream)
        {
            var list = new List<int>();
            uint skip, take;
            int last = 0;
            while (TryDecodeUInt32(stream, out skip) && TryDecodeUInt32(stream, out take))
            {
                last += (int)skip + 1;
                for (uint i = 0; i <= take; i++)
                {
                    list.Add(last++);
                }
            }

            return list;
        }

        private static void Encode(Stream stream, IList<int> data)
        {
            if (data.Count == 0)
            {
                return;
            }

            byte[] buffer = new byte[10];
            int last = -1, len = 0;
            for (int i = 0; i < data.Count;)
            {
                int gap = data[i] - 2 - last, size = 0;
                while (++i < data.Count && data[i] == data[i - 1] + 1)
                {
                    size++;
                }

                last = data[i - 1];
                len += EncodeUInt32((uint)gap, buffer, stream) + EncodeUInt32((uint)size, buffer, stream);
            }
        }

        private static int EncodeUInt32(uint value, byte[] buffer, Stream stream)
        {
            int count = 0, index = 0;
            do
            {
                buffer[index++] = (byte)((value & 0x7F) | 0x80);
                value >>= 7;
                count++;
            }
            while (value != 0);

            buffer[index - 1] &= 0x7F;
            stream.Write(buffer, 0, count);
            return count;
        }

        private static bool TryDecodeUInt32(Stream source, out uint value)
        {
            int b = source.ReadByte();
            if (b < 0)
            {
                value = 0;
                return false;
            }

            if ((b & 0x80) == 0)
            {
                // single-byte
                value = (uint)b;
                return true;
            }

            int shift = 7;

            value = (uint)(b & 0x7F);
            bool keepGoing;
            int i = 0;
            do
            {
                b = source.ReadByte();
                if (b < 0)
                {
                    throw new EndOfStreamException();
                }

                i++;
                keepGoing = (b & 0x80) != 0;
                value |= ((uint)(b & 0x7F)) << shift;
                shift += 7;
            }
            while (keepGoing && i < 4);

            if (keepGoing && i == 4)
            {
                throw new OverflowException();
            }

            return true;
        }
    }
#if !SpritelyRecipesProject
#pragma warning restore 0436
#endif
}

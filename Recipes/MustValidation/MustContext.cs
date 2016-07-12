﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MustContext.cs">
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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     Main interface for validating arguments.
    /// </summary>
#if !RecipesProject
    [System.Diagnostics.DebuggerStepThrough]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.CodeDom.Compiler.GeneratedCode("Spritely.Recipes", "See package version number")]
#pragma warning disable 0436
#endif
    internal partial class MustContext<T> where T : class
    {
        private readonly T objects;

        /// <summary>
        /// Initializes a new instance of the <see cref="MustContext{T}"/> class.
        /// </summary>
        /// <param name="objects">The objects to validate.</param>
        /// <exception cref="System.ArgumentNullException">If the objects class is null.</exception>
        public MustContext(T objects)
        {
            if (objects == null)
            {
                throw new ArgumentNullException(nameof(objects));
            }

            this.objects = objects;
        }

        /// <summary>
        /// Generic validation method capable of running the set of validation rules passed against the context object.
        /// </summary>
        /// <param name="validations">The validations to run.</param>
        public void Be(params Func<string, object, Exception>[] validations)
        {
            var validators = validations.Select(CreateValidator);

            var exceptions = validators.SelectMany(r => r.Invoke(objects)).ToList();

            if (exceptions.Count == 1)
            {
                throw exceptions.First();
            }

            if (exceptions.Any())
            {
                throw new ArgumentException(
                    "There were multiple argument exceptions. Please see innerException for details.",
                    innerException: new AggregateException(exceptions));
            }
        }

        /// <summary>
        /// Validates arguments are within the specified range.
        /// </summary>
        /// <param name="minimum">The minimum.</param>
        /// <param name="maximum">The maximum.</param>
        public void BeInRange(int minimum, int maximum)
        {
            Be(Require.InRange(minimum, maximum));
        }

        /// <summary>
        /// Validates agruments are not null.
        /// </summary>
        public void NotBeNull()
        {
            Be(Require.NotNull);
        }

        /// <summary>
        /// Extracts the property names/values from the context object and prepares a function to validate any passed arguments.
        /// </summary>
        /// <param name="validate">The validate.</param>
        /// <returns>A function capable of validating a given context object.</returns>
        private static Func<object, IEnumerable<Exception>> CreateValidator(Func<string, object, Exception> validate)
        {
            var properties = typeof(T).GetProperties();
            return objects =>
            {
                var pairs = properties.Select(p => new KeyValuePair<string, object>(p.Name, p.GetValue(objects)));
                var exceptions = pairs.Select(p => validate(p.Key, p.Value)).Where(ex => ex != null).ToList();

                return exceptions;
            };
        }
    }
#if !RecipesProject
#pragma warning restore 0436
#endif
}

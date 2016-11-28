﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Rules.cs">
//     Copyright (c) 2016. All rights reserved. Licensed under the MIT license. See LICENSE file in
//     the project root for full license information.
// </copyright>
// <auto-generated>
// Sourced from NuGet package. Will be overwritten with package update except in Spritely.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Spritely.Recipes
{
    // See MustExtensions.cs for comments on type definitions
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using GetArguments = System.Func<System.Collections.Generic.IEnumerable<System.Tuple<System.Type, string, object>>>;
    using Rule = System.Tuple<System.Func<System.Type, object, bool>, System.Collections.Generic.IEnumerable<string>, System.Func<System.Type, System.Collections.Generic.IEnumerable<string>, object, string, System.Exception>>;

    /// <summary>
    ///     Contains built-in Must Rules.
    /// </summary>
#if !RecipesProject
    [System.Diagnostics.DebuggerStepThrough]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.CodeDom.Compiler.GeneratedCode("Spritely.Recipes", "See package version number")]
#pragma warning disable 0436
#endif
    internal static partial class Rules
    {
        /// <summary>
        /// Instance cannot be null rule.
        /// </summary>
        public static Rule NotNull = MakeRule.That<object>(o => o != null).OrCreateArgumentNullException();

        /// <summary>
        /// Rule that value must be false.
        /// </summary>
        public static Rule False =
            MakeRule.That<bool>(b => b == false).OrCreateArgumentException().Because("Value must be false.");

        /// <summary>
        /// Rule that value must be true.
        /// </summary>
        public static Rule True =
            MakeRule.That<bool>(b => b == true).OrCreateArgumentException().Because("Value must be true.");

        /// <summary>
        /// String cannot be empty rule.
        /// </summary>
        public static Rule NotEmptyString =
            MakeRule.That<string>(s => s != string.Empty)
                .OrCreateArgumentException()
                .Because("Argument cannot be empty.");

        /// <summary>
        /// String cannot be not null or empty rule.
        /// </summary>
        public static Rule NotNullOrEmptyString =
            MakeRule.That<string>(s => !string.IsNullOrEmpty(s))
                .OrCreateArgumentException()
                .Because("Argument cannot be null or empty.");

        /// <summary>
        /// String cannot be white space rule.
        /// </summary>
        public static Rule NotWhiteSpace =
            MakeRule.That<string>(s => s == null || !string.IsNullOrWhiteSpace(s))
                .OrCreateArgumentException()
                .Because("Argument cannot be white space.");

        /// <summary>
        /// String cannot be not null or white space rule.
        /// </summary>
        public static Rule NotNullOrWhiteSpace =
            MakeRule.That<string>(s => !string.IsNullOrWhiteSpace(s))
                .OrCreateArgumentException()
                .Because("Argument cannot be null or white space.");

        /// <summary>
        /// The unique identifer cannot be not empty rule.
        /// </summary>
        public static Rule NotEmptyGuid =
            MakeRule.That<Guid>(id => id != Guid.Empty)
                .OrCreateArgumentException()
                .Because("Identifier cannot be null or empty.");

        /// <summary>
        /// Makes a value cannot be default rule.
        /// </summary>
        /// <typeparam name="T">The equatable type being checked.</typeparam>
        /// <returns>The rule.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Spritely.Recipes.MakeRule.Because(System.Tuple<System.Func<System.Type,System.Object,System.Boolean>,System.Collections.Generic.IEnumerable<System.String>,System.Func<System.Type,System.Collections.Generic.IEnumerable<System.String>,System.Object,System.String,System.Exception>>,System.String)", Justification = "These messages should only ever be displayed to developers and do not want to complicate recipes with resources.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "These messages should only ever be displayed to developers and do not want to complicate recipes with resources.")]
        public static Rule NotDefault<T>() where T : struct, IEquatable<T>
        {
            return MakeRule.That<T>(v => !v.Equals(default(T)))
                .OrCreateArgumentException()
                .Because($"Value must be set and not be {default(T)}");
        }

        /// <summary>
        /// Makes a value cannot be null or default rule.
        /// </summary>
        /// <typeparam name="T">The equatable type being checked.</typeparam>
        /// <returns>The rule.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Spritely.Recipes.MakeRule.Because(System.Tuple<System.Func<System.Type,System.Object,System.Boolean>,System.Collections.Generic.IEnumerable<System.String>,System.Func<System.Type,System.Collections.Generic.IEnumerable<System.String>,System.Object,System.String,System.Exception>>,System.String)", Justification = "These messages should only ever be displayed to developers and do not want to complicate recipes with resources.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "These messages should only ever be displayed to developers and do not want to complicate recipes with resources.")]
        public static Rule NotNullOrDefault<T>() where T : IEquatable<T>
        {
            return MakeRule.That<T>(v => v != null && !v.Equals(default(T)))
                .OrCreateArgumentException()
                .Because($"Value must be set and not be {default(T)}");
        }

        /// <summary>
        /// Makes an enumerable cannot be null or empty rule.
        /// </summary>
        /// <typeparam name="T">The type contained in the enumerable.</typeparam>
        /// <returns>The rule.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Spritely.Recipes.MakeRule.Because(System.Tuple<System.Func<System.Type,System.Object,System.Boolean>,System.Collections.Generic.IEnumerable<System.String>,System.Func<System.Type,System.Collections.Generic.IEnumerable<System.String>,System.Object,System.String,System.Exception>>,System.String)", Justification = "These messages should only ever be displayed to developers and do not want to complicate recipes with resources.")]
        public static Rule NotNullOrEmptyEnumerable<T>()
        {
            return MakeRule.That<IEnumerable<T>>(e => e != null && e.Any())
                .OrCreateArgumentException()
                .Because("Enumeration cannot be null or empty.");
        }

        /// <summary>
        /// Makes an enumerable cannot be null or contain any nulls rule.
        /// </summary>
        /// <typeparam name="T">The type contained in the enumerable.</typeparam>
        /// <returns>The rule.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Spritely.Recipes.MakeRule.Because(System.Tuple<System.Func<System.Type,System.Object,System.Boolean>,System.Collections.Generic.IEnumerable<System.String>,System.Func<System.Type,System.Collections.Generic.IEnumerable<System.String>,System.Object,System.String,System.Exception>>,System.String)", Justification = "These messages should only ever be displayed to developers and do not want to complicate recipes with resources.")]
        public static Rule NotNullOrContainAnyNulls<T>()
        {
            return MakeRule.That<IEnumerable<T>>(e => e != null && e.All(i => i != null))
                .OrCreateArgumentException()
                .Because("Enumeration cannot be null or contain any nulls.");
        }

        /// <summary>
        /// Makes a compariable value must be in range rule.
        /// </summary>
        /// <typeparam name="T">The type being compared.</typeparam>
        /// <param name="minimum">The minimum value.</param>
        /// <param name="maximum">The maximum value.</param>
        /// <returns>The rule.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Spritely.Recipes.MakeRule.Because(System.Tuple<System.Func<System.Type,System.Object,System.Boolean>,System.Collections.Generic.IEnumerable<System.String>,System.Func<System.Type,System.Collections.Generic.IEnumerable<System.String>,System.Object,System.String,System.Exception>>,System.String)", Justification = "These messages should only ever be displayed to developers and do not want to complicate recipes with resources.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object,System.Object)", Justification = "These messages should only ever be displayed to developers and do not want to complicate recipes with resources.")]
        public static Rule InRange<T>(T minimum, T maximum) where T : IComparable
        {
            return MakeRule.That<T>(v => v.CompareTo(minimum) >= 0 && v.CompareTo(maximum) <= 0)
                .OrCreateArgumentOutOfRangeException()
                .Because($"Value must range from {minimum} to {maximum}.");
        }

        /// <summary>
        /// Makes a value must be less than rule.
        /// </summary>
        /// <typeparam name="T">The type being compared.</typeparam>
        /// <param name="requirement">The requirement value must meet.</param>
        /// <returns>The rule.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Spritely.Recipes.MakeRule.Because(System.Tuple<System.Func<System.Type,System.Object,System.Boolean>,System.Collections.Generic.IEnumerable<System.String>,System.Func<System.Type,System.Collections.Generic.IEnumerable<System.String>,System.Object,System.String,System.Exception>>,System.String)", Justification = "These messages should only ever be displayed to developers and do not want to complicate recipes with resources.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "These messages should only ever be displayed to developers and do not want to complicate recipes with resources.")]
        public static Rule LessThan<T>(T requirement) where T : IComparable
        {
            return MakeRule.That<T>(v => v.CompareTo(requirement) < 0)
                .OrCreateArgumentOutOfRangeException()
                .Because($"Value must be less than {requirement}.");
        }

        /// <summary>
        /// Makes a value must be less than or equal to rule.
        /// </summary>
        /// <typeparam name="T">The type being compared.</typeparam>
        /// <param name="requirement">The requirement value must meet.</param>
        /// <returns>The rule.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Spritely.Recipes.MakeRule.Because(System.Tuple<System.Func<System.Type,System.Object,System.Boolean>,System.Collections.Generic.IEnumerable<System.String>,System.Func<System.Type,System.Collections.Generic.IEnumerable<System.String>,System.Object,System.String,System.Exception>>,System.String)", Justification = "These messages should only ever be displayed to developers and do not want to complicate recipes with resources.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "These messages should only ever be displayed to developers and do not want to complicate recipes with resources.")]
        public static Rule LessThanOrEqualTo<T>(T requirement) where T : IComparable
        {
            return MakeRule.That<T>(v => v.CompareTo(requirement) <= 0)
                .OrCreateArgumentOutOfRangeException()
                .Because($"Value must be less than or equal to {requirement}.");
        }

        /// <summary>
        /// Makes a value must be greater than rule.
        /// </summary>
        /// <typeparam name="T">The type being compared.</typeparam>
        /// <param name="requirement">The requirement value must meet.</param>
        /// <returns>The rule.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Spritely.Recipes.MakeRule.Because(System.Tuple<System.Func<System.Type,System.Object,System.Boolean>,System.Collections.Generic.IEnumerable<System.String>,System.Func<System.Type,System.Collections.Generic.IEnumerable<System.String>,System.Object,System.String,System.Exception>>,System.String)", Justification = "These messages should only ever be displayed to developers and do not want to complicate recipes with resources.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "These messages should only ever be displayed to developers and do not want to complicate recipes with resources.")]
        public static Rule GreaterThan<T>(T requirement) where T : IComparable
        {
            return MakeRule.That<T>(v => v.CompareTo(requirement) > 0)
                .OrCreateArgumentOutOfRangeException()
                .Because($"Value must be greater than {requirement}.");
        }

        /// <summary>
        /// Makes a value must be greater than or equal to rule.
        /// </summary>
        /// <typeparam name="T">The type being compared.</typeparam>
        /// <param name="requirement">The requirement value must meet.</param>
        /// <returns>The rule.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Spritely.Recipes.MakeRule.Because(System.Tuple<System.Func<System.Type,System.Object,System.Boolean>,System.Collections.Generic.IEnumerable<System.String>,System.Func<System.Type,System.Collections.Generic.IEnumerable<System.String>,System.Object,System.String,System.Exception>>,System.String)", Justification = "These messages should only ever be displayed to developers and do not want to complicate recipes with resources.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "These messages should only ever be displayed to developers and do not want to complicate recipes with resources.")]
        public static Rule GreaterThanOrEqualTo<T>(T requirement) where T : IComparable
        {
            return MakeRule.That<T>(v => v.CompareTo(requirement) >= 0)
                .OrCreateArgumentOutOfRangeException()
                .Because($"Value must be greater than or equal to {requirement}.");
        }
    }
#if !RecipesProject
#pragma warning restore 0436
#endif
}

﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MustExtensions.cs">
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

    // Starts the monad with the function to return the list of arguments to validate
    // Call: new { arg1, arg2 }.Must()
    // Or: arg1.Named(nameof(arg1))
    // Which returns:
    // Func<IEnumerable<Tuple<Type, string, object>>>
    // () => IEnumerable<Tuple<Type, string, object>>
    // Returned tuple encapsulates the argument: type, name, value
    using GetArguments = System.Func<System.Collections.Generic.IEnumerable<System.Tuple<System.Type, string, object>>>;

    // An exception throwing monad termination calls this method for each argument which failed validation
    // GetException data is included as part of the Rule (see below)
    // (argumentType, reasons (aka messages), argumentValue, argumentName) => return new ArgumentException()
    // (Type, IEnumerable<string>, object, string) => Exception
    // Func<Type, IEnumerable<string>, object, string, Exception>
    using GetException = System.Func<System.Type, System.Collections.Generic.IEnumerable<string>, object, string, System.Exception>;

    // The validation predicate function as encapsulated inside a Rule (see below)
    using RulePredicate = System.Func<System.Type, object, bool>;

    // A Rule is the encapsulation of the validation predicate to run, any messages to report on failure, and
    // a function to call to create (not throw) an exception for a given failure.
    // { RulePredicate, Messages, GetException }
    // Tuple<RulePredicate, IEnumerable<string>, GetException>
    // Tuple<Func<Type, object, bool>, IEnumerable<string>, Func<Type, IEnumerable<string>, object, string, Exception>>
    using Rule = System.Tuple<System.Func<System.Type, object, bool>, System.Collections.Generic.IEnumerable<string>, System.Func<System.Type, System.Collections.Generic.IEnumerable<string>, object, string, System.Exception>>;

    // Would like to define this to make code simpler to read, but compiler generates:
    // error CS0811: The fully qualified name for '...' is too long for debug information. Compile without '/debug' option.
    // Do not want to impose this restriction on downstream assemblies (since this is a Recipe)
    // So have to remove this from the compilation and inline the types and instead use the next
    // shortest equivalent: Tuple<GetArguments, IEnumerable<Rule>>
    // A ValidationReportDefinition is the combination of Arguments to validate and Rules to run.
    // Tuple<GetArguments, IEnumerable<Rule>>;
    // Tuple<Func<IEnumerable<Tuple<Type, string, object>>>, IEnumerable<Tuple<Func<Type, object, bool>, IEnumerable<string>, Func<Type, IEnumerable<string>, object, string, Exception>>>>;
    //using ValidationReportDefinition = System.Tuple<System.Func<System.Collections.Generic.IEnumerable<System.Tuple<System.Type, string, object>>>, System.Collections.Generic.IEnumerable<System.Tuple<System.Func<System.Type, object, bool>, System.Collections.Generic.IEnumerable<string>, System.Func<System.Type, System.Collections.Generic.IEnumerable<string>, object, string, System.Exception>>>>;

    // A ValidationReport is the result of running all the validations against all the arguments.
    // It is a list of results for each argument along with the function to call to convert failures into exceptions.
    // IEnumerable<{ argumentType, argumentName, argumentValue, validationResult, messages, getException() }>
    // IEnumerable<Tuple<Type, string, object, bool, IEnumerable<string>, GetException>>
    // IEnumerable<Tuple<Type, string, object, bool, IEnumerable<string>, Func<Type, IEnumerable<string>, object, string, Exception>>>
    using ValidationReport = System.Collections.Generic.IEnumerable<System.Tuple<System.Type, string, object, bool, System.Collections.Generic.IEnumerable<string>, System.Func<System.Type, System.Collections.Generic.IEnumerable<string>, object, string, System.Exception>>>;

    /// <summary>
    ///     Contains Must extension methods.
    /// </summary>
#if !RecipesProject
    [System.Diagnostics.DebuggerStepThrough]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.CodeDom.Compiler.GeneratedCode("Spritely.Recipes", "See package version number")]
#pragma warning disable 0436
#endif
    internal static partial class MustExtensions
    {
        /// <summary>
        /// Starts a requirement that certain objects Must meet to pass validation.
        /// </summary>
        /// <example>
        /// arg1.Named(nameof(arg1)).Must().NotBeNull().OrThrow();
        /// </example>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="value">The value to be validated - typically a method's argument.</param>
        /// <param name="name">The name of the argument being validated.</param>
        /// <returns>
        /// A function capable of obtaining a list of arguments to be validated or acting
        /// as a context to build other validations with.
        /// </returns>
        /// <exception cref="ArgumentNullException">If name is null.</exception>
        /// <exception cref="ArgumentException">If name is whitespace.</exception>
        public static GetArguments Named<T>([ValidatedNotNull] this T value, string name)
        {
            const string invalidNameArgumentMessage =
                "A valid argument name be supplied when initializing a validation.";

            if (name == null)
            {
                throw new ArgumentNullException("name", invalidNameArgumentMessage);
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(invalidNameArgumentMessage, "name");
            }

            var result = new List<Tuple<Type, string, object>>
            {
                Tuple.Create(typeof(T), name, value as object)
            };

            return () => result;
        }

        /// <summary>
        /// Adds additional objects to an existing set that should be validated using Must().
        /// </summary>
        /// <example>
        /// new { arg1, arg2 }.And(new { arg3, arg4 }).Must().NotBeNull().OrThrow();
        /// </example>
        /// <typeparam name="TThis">The type containing objects to be validated.</typeparam>
        /// <typeparam name="TOther">The type containing objects to be validated.</typeparam>
        /// <param name="objects">Arguments already constructed for validation by Must().</param>
        /// <param name="otherObjects">Another objects instance containing members to be validated.</param>
        /// <returns>
        /// A function capable of obtaining a list of arguments to be validated or acting
        /// as a context to build other validations with.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">If objects is null.</exception>
        public static GetArguments And<TThis, TOther>([ValidatedNotNull] this TThis objects, [ValidatedNotNull] TOther otherObjects)
            where TThis : class
            where TOther : class
        {
            if (objects == null)
            {
                throw new ArgumentNullException("objects");
            }

            if (otherObjects == null)
            {
                throw new ArgumentNullException("otherObjects");
            }

            return () =>
            {
                var allArguments = objects.ToArguments().Concat(otherObjects.ToArguments());
                return allArguments;
            };
        }

        /// <summary>
        /// Adds additional objects to an existing set that should be validated using Must().
        /// </summary>
        /// <example>
        /// new { arg1, arg2 }.And(value.Named("Arg3")).Must().NotBeNull().OrThrow();
        /// </example>
        /// <typeparam name="T">The type containing objects to be validated.</typeparam>
        /// <param name="objects">The objects instance containing members to be validated.</param>
        /// <param name="getArguments">Other arguments already constructed for validation by Must().</param>
        /// <returns>
        /// A function capable of obtaining a list of arguments to be validated or acting
        /// as a context to build other validations with.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">If objects is null.</exception>
        public static GetArguments And<T>([ValidatedNotNull] this T objects, GetArguments getArguments) where T : class
        {
            if (objects == null)
            {
                throw new ArgumentNullException("objects");
            }

            if (getArguments == null)
            {
                throw new ArgumentNullException("getArguments");
            }

            return () =>
            {
                var allArguments = objects.ToArguments().Concat(getArguments());
                return allArguments;
            };
        }

        /// <summary>
        /// Adds additional objects to an existing set that should be validated using Must().
        /// </summary>
        /// <example>
        /// value.Named("Arg1").And(new { arg1, arg2 }).Must().NotBeNull().OrThrow();
        /// </example>
        /// <typeparam name="T">The type containing objects to be validated.</typeparam>
        /// <param name="getArguments">Other arguments already constructed for validation by Must().</param>
        /// <param name="objects">The objects instance containing members to be validated.</param>
        /// <returns>
        /// A function capable of obtaining a list of arguments to be validated or acting
        /// as a context to build other validations with.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">If objects is null.</exception>
        public static GetArguments And<T>(this GetArguments getArguments, [ValidatedNotNull] T objects) where T : class
        {
            if (getArguments == null)
            {
                throw new ArgumentNullException("getArguments");
            }

            if (objects == null)
            {
                throw new ArgumentNullException("objects");
            }

            return () =>
            {
                var allArguments = getArguments().Concat(objects.ToArguments());
                return allArguments;
            };
        }

        /// <summary>
        /// Adds additional objects to an existing set that should be validated using Must().
        /// </summary>
        /// <example>
        /// value1.Named("Arg1").And(value2.Named(nameof(value2))).Must().NotBeNull().OrThrow();
        /// </example>
        /// <param name="getArguments">Arguments already constructed for validation by Must().</param>
        /// <param name="otherGetArguments">Another arguments object for validation.</param>
        /// <returns>
        /// A function capable of obtaining a list of arguments to be validated or acting
        /// as a context to build other validations with.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">If objects is null.</exception>
        public static GetArguments And(this GetArguments getArguments, GetArguments otherGetArguments)
        {
            if (getArguments == null)
            {
                throw new ArgumentNullException("getArguments");
            }

            if (otherGetArguments == null)
            {
                throw new ArgumentNullException("otherGetArguments");
            }

            return () =>
            {
                var allArguments = getArguments().Concat(otherGetArguments());
                return allArguments;
            };
        }

        /// <summary>
        /// Combines a set of arguments with a set of validation rules and sets up instance
        /// ready to be validated by various rules such as NotBeNull. It can also be called
        /// without directly specifying any rules if desired for an alternative syntax.
        /// </summary>
        /// <example>
        /// new { arg1, arg2 }.Must(Rules.NotBeNull).OrThrow();
        /// // or
        /// new { arg1, arg2 }.Must().NotBeNull().OrThrow();
        /// </example>
        /// <param name="objects">The objects instance containing members to be validated.</param>
        /// <param name="rules">The rules to add to the validation rule set.</param>
        /// <returns>A suite of validation rules and encapsulated argument retrieval function
        /// (aka a validation report definition).</returns>
        /// <exception cref="System.ArgumentNullException">If objects is null.</exception>
        public static Tuple<GetArguments, IEnumerable<Rule>> Must<T>([ValidatedNotNull] this T objects, params Rule[] rules)
        {
            if (objects == null)
            {
                throw new ArgumentNullException("objects");
            }

            GetArguments getArguments = () => objects.ToArguments();

            return Tuple.Create(getArguments, rules.SelectValid());
        }

        /// <summary>
        /// Combines a set of arguments with a set of validation rules and sets up instance
        /// ready to be validated by various rules such as NotBeNull. It can also be called
        /// without directly specifying any rules if desired for an alternative syntax.
        /// </summary>
        /// <example>
        /// new { arg1, arg2 }.Must(Rules.NotBeNull).OrThrow();
        /// // or
        /// arg1.Named(nameof(arg1)).Must().NotBeNull().OrThrow();
        /// </example>
        /// <param name="getArguments">Arguments already constructed for validation by Must().</param>
        /// <param name="rules">The rules to add to the validation rule set.</param>
        /// <returns>A suite of validation rules and encapsulated argument retrieval function
        /// (aka a validation report definition).</returns>
        /// <exception cref="System.ArgumentNullException">If getArguments is null.</exception>
        public static Tuple<GetArguments, IEnumerable<Rule>> Must(this GetArguments getArguments, params Rule[] rules)
        {
            if (getArguments == null)
            {
                throw new ArgumentNullException("getArguments");
            }

            return Tuple.Create(getArguments, rules.SelectValid());
        }

        /// <summary>
        /// Adds the specified rule or rules to the validation rule set. It can also be called without
        /// specifying a rule if desired for syntax.
        /// 
        /// Similar to Must(), but works with the output of Must() instead of the output of Must().
        /// </summary>
        /// <example>
        /// new { arg1 }.Must().NotBeNull().And().BeInRange(0, 100).OrThrow();
        /// // or
        /// arg1.Named(nameof(arg1)).Must(Rules.NotBeNull).And(Rules.NotBeEmptyString).OrThrow();
        /// </example>
        /// <param name="validationPlan">The validation plan.</param>
        /// <param name="rules">The rules to add to the validation rule set.</param>
        /// <returns>A revised validation plan.</returns>
        /// <exception cref="System.ArgumentNullException">If validationPlan is null.</exception>
        public static Tuple<GetArguments, IEnumerable<Rule>> And(this Tuple<GetArguments, IEnumerable<Rule>> validationPlan, params Rule[] rules)
        {
            if (validationPlan == null)
            {
                throw new ArgumentNullException("validationPlan");
            }

            var validationRules = (rules == null)
                ? validationPlan.Item2
                : validationPlan.Item2.Concat(rules.Where(r => r != null));

            return Tuple.Create(validationPlan.Item1, validationRules);
        }

        /// <summary>
        /// Adds a reason (or reasons) to all failing rules on any argument being validated.
        /// </summary>
        /// <example>
        /// new { arg1 }.Must().NotBeNull().And().BeInRange(0, 100).Because("arg1 is a percentage").OrThrow();
        /// // or
        /// arg1.Named(nameof(arg1)).Must(Rules.NotBeNull).And(Rules.NotBeEmptyString).Because("arg1 is required").OrThrow();
        /// </example>
        /// <param name="validationPlan">The validation plan.</param>
        /// <param name="reasons">The reason or reasons to add.</param>
        /// <returns>A revised validation plan.</returns>
        /// <exception cref="System.ArgumentNullException">If validationPlan is null.</exception>
        public static Tuple<GetArguments, IEnumerable<Rule>> Because(this Tuple<GetArguments, IEnumerable<Rule>> validationPlan, params string[] reasons)
        {
            if (validationPlan == null)
            {
                throw new ArgumentNullException("validationPlan");
            }

            var newRules = validationPlan.Item2;
            if (reasons != null)
            {
                var validReasons = reasons.Where(r => !string.IsNullOrWhiteSpace(r)).ToList();

                if (validReasons.Any())
                {
                    newRules = validationPlan.Item2.Select(
                        r => Tuple.Create(r.Item1, r.Item2.Concat(validReasons), r.Item3));
                }
            }

            return Tuple.Create(validationPlan.Item1, newRules);
        }

        /// <summary>
        /// Generates a report from the provided validation plan by running all the rules against all
        /// arguments. All combinations are reported so rules where types do not match are included but
        /// all evaluate to true (valid).
        /// </summary>
        /// <param name="validationPlan">The validation plan to report on.</param>
        /// <returns>A validation report.</returns>
        /// <exception cref="System.ArgumentNullException">If validationPlan is null.</exception>
        public static ValidationReport Report(this Tuple<GetArguments, IEnumerable<Rule>> validationPlan)
        {
            if (validationPlan == null)
            {
                throw new ArgumentNullException("validationPlan");
            }
            
            var arguments = validationPlan.Item1();
            var rules = validationPlan.Item2.ToList();

            var report = arguments.SelectMany(
                _ => rules,
                (argument, rule) =>
                {
                    var argumentType = argument.Item1;
                    var argumentName = argument.Item2;
                    var argumentValue = argument.Item3;
                    var validate = rule.Item1;
                    var result = validate(argumentType, argumentValue);

                    return Tuple.Create(argumentType, argumentName, argumentValue, result, rule.Item2, rule.Item3);
                });

            return report;
        }

        /// <summary>
        /// Runs all the validation rules and generates an exception for any failures. Multiple exceptions are
        /// wrapped into a single ArgumentException whose InnerException is an AggregateException whose
        /// InnerExceptions is a list of all the validation exceptions.
        /// </summary>
        /// <param name="validationPlan">The validation plan.</param>
        public static void OrThrow(this Tuple<GetArguments, IEnumerable<Rule>> validationPlan)
        {
            var report = validationPlan.Report();

            var exceptions = report.Where(r => !r.Item4 /* validation result */)
                .Select(
                    r =>
                    {
                        var argumentType = r.Item1;
                        var argumentName = r.Item2;
                        var argumentValue = r.Item3;
                        var reasons = r.Item5;
                        var getException = r.Item6;

                        var exception = getException(argumentType, reasons, argumentValue, argumentName);

                        return exception;
                    }).Where(ex => ex != null).ToList();

            if (exceptions.Count == 1)
            {
                throw exceptions.First();
            }

            if (exceptions.Any())
            {
                throw new ArgumentException(
                    "There were multiple argument exceptions. Please see InnerException for details.",
                    innerException: new AggregateException(exceptions));
            }
        }

        private static IEnumerable<Tuple<Type, string, object>> ToArguments<T>(this T objects)
        {
            var properties = typeof(T).GetProperties();
            return properties.Select(p => Tuple.Create(p.PropertyType, p.Name, p.GetValue(objects)));
        }

        private static IEnumerable<Rule> SelectValid(this IEnumerable<Rule> rules)
        {
            return rules == null ? new List<Rule>() : rules.Where(r => r != null);
        }
    }
#if !RecipesProject
#pragma warning restore 0436
#endif
}

﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MustExtensionsTest.cs">
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

    // See MustExtensions.cs for comments on type definitions
    using GetArguments = System.Func<System.Collections.Generic.IEnumerable<System.Tuple<System.Type, string, object>>>;
    using Rule = System.Tuple<System.Func<System.Type, object, bool>, System.Collections.Generic.IEnumerable<string>, System.Func<System.Type, System.Collections.Generic.IEnumerable<string>, object, string, System.Exception>>;

    [TestFixture]
    public class MustExtensionsTest
    {
        [Test]
        public void Named_throws_on_null_name_arguments()
        {
            Assert.Throws<ArgumentNullException>(() => 5.Named(null));
            Assert.Throws<ArgumentException>(() => (0.5).Named("  "));
        }

        [Test]
        public void Named_creates_expected_set_of_arguments()
        {
            var myArg = "the string value";

            var arguments = myArg.Named(nameof(myArg))();
            arguments.Should().HaveCount(1);
            arguments.First().Item1.Should().Be(typeof(string));
            arguments.First().Item2.Should().Be("myArg");
            arguments.First().Item3.Should().Be("the string value");
        }

        [Test]
        public void And_throws_on_null_this_arguments()
        {
            var arg1 = "test";
            Assert.Throws<ArgumentNullException>(() => (null as object).And(arg1.Named(nameof(arg1))));
            Assert.Throws<ArgumentNullException>(() => (null as object).And(new { arg1 }));
            Assert.Throws<ArgumentNullException>(() => (null as GetArguments).And(new { arg1 }));
            Assert.Throws<ArgumentNullException>(() => (null as GetArguments).And(arg1.Named(nameof(arg1))));
        }

        [Test]
        public void And_throws_on_null_other_arguments()
        {
            var arg1 = "test";
            Assert.Throws<ArgumentNullException>(() => new { arg1 }.And(null as object));
            Assert.Throws<ArgumentNullException>(() => new { arg1 }.And(null as GetArguments));
            Assert.Throws<ArgumentNullException>(() => arg1.Named(nameof(arg1)).And(null as object));
            Assert.Throws<ArgumentNullException>(() => arg1.Named(nameof(arg1)).And(null as GetArguments));
        }

        [Test]
        public void And1_creates_expected_set_of_arguments()
        {
            var arg1 = "Hello world!";
            var arg2 = DateTime.UtcNow;
            var arg3 = 15.2;

            var arguments = new { arg1, arg2 }.And(arg3.Named("third argument"))();
            arguments.Should().HaveCount(3);
            arguments.First().Item1.Should().Be(typeof(string));
            arguments.First().Item2.Should().Be("arg1");
            arguments.First().Item3.Should().Be("Hello world!");
            arguments.Skip(1).First().Item1.Should().Be(typeof(DateTime));
            arguments.Skip(1).First().Item2.Should().Be("arg2");
            arguments.Skip(1).First().Item3.Should().Be(arg2);
            arguments.Skip(2).First().Item1.Should().Be(typeof(double));
            arguments.Skip(2).First().Item2.Should().Be("third argument");
            arguments.Skip(2).First().Item3.Should().Be(15.2);
        }

        [Test]
        public void And2_creates_expected_set_of_arguments()
        {
            var arg1 = new object();
            var arg2 = "this is a test";
            var arg3 = 5;
            var arg4 = 98.45;

            var arguments = new { arg1, arg2 }.And(new { arg3, arg4 })();
            arguments.Should().HaveCount(4);
            arguments.First().Item1.Should().Be(typeof(object));
            arguments.First().Item2.Should().Be("arg1");
            arguments.First().Item3.Should().BeSameAs(arg1);
            arguments.Skip(1).First().Item1.Should().Be(typeof(string));
            arguments.Skip(1).First().Item2.Should().Be("arg2");
            arguments.Skip(1).First().Item3.Should().Be(arg2);
            arguments.Skip(2).First().Item1.Should().Be(typeof(int));
            arguments.Skip(2).First().Item2.Should().Be("arg3");
            arguments.Skip(2).First().Item3.Should().Be(5);
            arguments.Skip(3).First().Item1.Should().Be(typeof(double));
            arguments.Skip(3).First().Item2.Should().Be("arg4");
            arguments.Skip(3).First().Item3.Should().Be(98.45);
        }

        [Test]
        public void And3_creates_expected_set_of_arguments()
        {
            var arg1 = new object();
            var arg2 = 1234;
            var arg3 = 15.2;

            var arguments =  arg1.Named(nameof(arg1)).And(new { arg2, arg3 })();
            arguments.Should().HaveCount(3);
            arguments.First().Item1.Should().Be(typeof(object));
            arguments.First().Item2.Should().Be("arg1");
            arguments.First().Item3.Should().BeSameAs(arg1);
            arguments.Skip(1).First().Item1.Should().Be(typeof(int));
            arguments.Skip(1).First().Item2.Should().Be("arg2");
            arguments.Skip(1).First().Item3.Should().Be(1234);
            arguments.Skip(2).First().Item1.Should().Be(typeof(double));
            arguments.Skip(2).First().Item2.Should().Be("arg3");
            arguments.Skip(2).First().Item3.Should().Be(15.2);
        }

        [Test]
        public void And4_creates_expected_set_of_arguments()
        {
            var arg1 = DateTime.UtcNow;
            var arg2 = Guid.NewGuid();

            var arguments = arg1.Named("the date").And(arg2.Named("the guid"))();
            arguments.Should().HaveCount(2);
            arguments.First().Item1.Should().Be(typeof(DateTime));
            arguments.First().Item2.Should().Be("the date");
            arguments.First().Item3.Should().Be(arg1);
            arguments.Skip(1).First().Item1.Should().Be(typeof(Guid));
            arguments.Skip(1).First().Item2.Should().Be("the guid");
            arguments.Skip(1).First().Item3.Should().Be(arg2);
        }

        [Test]
        public void MustBe_throws_on_null_arguments()
        {
            Assert.Throws<ArgumentNullException>(() => (null as object).MustBe());
            Assert.Throws<ArgumentNullException>(() => (null as GetArguments).MustBe());
        }

        [Test]
        public void MustBe1_creates_expected_set_of_arguments()
        {
            var arg1 = "some string";
            var arg2 = new object();
            var arg3 = 133;

            var arguments = new { arg1, arg2, arg3 }.MustBe().Item1();
            arguments.Should().HaveCount(3);
            arguments.First().Item1.Should().Be(typeof(string));
            arguments.First().Item2.Should().Be("arg1");
            arguments.First().Item3.Should().Be("some string");
            arguments.Skip(1).First().Item1.Should().Be(typeof(object));
            arguments.Skip(1).First().Item2.Should().Be("arg2");
            arguments.Skip(1).First().Item3.Should().BeSameAs(arg2);
            arguments.Skip(2).First().Item1.Should().Be(typeof(int));
            arguments.Skip(2).First().Item2.Should().Be("arg3");
            arguments.Skip(2).First().Item3.Should().Be(133);
        }

        [Test]
        public void MustBe2_creates_expected_set_of_arguments()
        {
            var arg1 = Guid.NewGuid();
            var arg2 = TimeSpan.FromDays(1);

            var arguments = arg1.Named("one").And(arg2.Named("two")).MustBe().Item1();
            arguments.Should().HaveCount(2);
            arguments.First().Item1.Should().Be(typeof(Guid));
            arguments.First().Item2.Should().Be("one");
            arguments.First().Item3.Should().Be(arg1);
            arguments.Skip(1).First().Item1.Should().Be(typeof(TimeSpan));
            arguments.Skip(1).First().Item2.Should().Be("two");
            arguments.Skip(1).First().Item3.Should().Be(arg2);
        }

        [Test]
        public void MustBe1_adds_supplied_rule_to_rule_set()
        {
            var arg1 = null as object;
            var arg2 = null as object;
            var arg3 = null as object;

            var intialRuleSet = new { arg1, arg2, arg3 }.MustBe();
            var alwaysTrue = MakeRule.That(() => true).OrCreateArgumentException();
            var newRuleSet = new { arg1, arg2, arg3 }.MustBe(alwaysTrue);

            intialRuleSet.Item2.Should().BeEmpty();
            newRuleSet.Item2.Should().HaveCount(1);
            newRuleSet.Item2.Should().Contain(alwaysTrue);
        }

        [Test]
        public void MustBe2_adds_supplied_rule_to_rule_set()
        {
            var arg1 = null as object;
            var arg2 = null as object;

            var intialRuleSet = arg1.Named(nameof(arg1)).And(arg2.Named(nameof(arg2))).MustBe();
            var alwaysTrue = MakeRule.That(() => true).OrCreateArgumentException();
            var newRuleSet = arg1.Named(nameof(arg1)).And(arg2.Named(nameof(arg2))).MustBe(alwaysTrue);

            intialRuleSet.Item2.Should().BeEmpty();
            newRuleSet.Item2.Should().HaveCount(1);
            newRuleSet.Item2.Should().Contain(alwaysTrue);
        }

        [Test]
        public void MustBe1_adds_supplied_rules_to_rule_set()
        {
            var arg1 = null as object;
            var arg2 = null as object;
            var arg3 = null as object;

            var intialRuleSet = new { arg1, arg2, arg3 }.MustBe();
            var alwaysFalse = MakeRule.That(() => false).OrCreateArgumentException();
            var alwaysTrue = MakeRule.That(() => true).OrCreateArgumentException();
            var newRuleSet = new { arg1, arg2, arg3 }.MustBe(alwaysFalse, alwaysTrue);

            intialRuleSet.Item2.Should().BeEmpty();
            newRuleSet.Item2.Should().HaveCount(2);
            newRuleSet.Item2.Should().Contain(alwaysFalse);
            newRuleSet.Item2.Should().Contain(alwaysTrue);
        }

        [Test]
        public void MustBe2_adds_supplied_rules_to_rule_set()
        {
            var arg1 = null as object;
            var arg2 = null as object;

            var intialRuleSet = arg1.Named(nameof(arg1)).And(arg2.Named(nameof(arg2))).MustBe();
            var alwaysFalse = MakeRule.That(() => false).OrCreateArgumentException();
            var alwaysTrue = MakeRule.That(() => true).OrCreateArgumentException();
            var newRuleSet = arg1.Named(nameof(arg1)).And(arg2.Named(nameof(arg2))).MustBe(alwaysFalse, alwaysTrue);

            intialRuleSet.Item2.Should().BeEmpty();
            newRuleSet.Item2.Should().HaveCount(2);
            newRuleSet.Item2.Should().Contain(alwaysFalse);
            newRuleSet.Item2.Should().Contain(alwaysTrue);
        }

        [Test]
        public void And_throws_on_null_this_argument()
        {
            Assert.Throws<ArgumentNullException>(() => (null as Tuple<GetArguments, IEnumerable<Rule>>).And());
        }

        [Test]
        public void And_does_not_throw_on_empty_rule_argument()
        {
            var arg1 = "test";
            arg1.Named(nameof(arg1)).MustBe().And();
        }

        [Test]
        public void And_adds_supplied_rule_to_rule_set()
        {
            var arg1 = null as object;
            var arg2 = null as object;
            var arg3 = null as object;

            var intialRuleSet = new { arg1, arg2, arg3 }.MustBe();
            var alwaysTrue = MakeRule.That(() => true).OrCreateArgumentException();
            var newRuleSet = intialRuleSet.And(alwaysTrue);

            intialRuleSet.Item2.Should().BeEmpty();
            newRuleSet.Item2.Should().HaveCount(1);
            newRuleSet.Item2.Should().Contain(alwaysTrue);
        }

        [Test]
        public void And_adds_supplied_rules_to_rule_set()
        {
            var arg1 = null as object;
            var arg2 = null as object;
            var arg3 = null as object;

            var intialRuleSet = new { arg1, arg2, arg3 }.MustBe();
            var alwaysFalse = MakeRule.That(() => false).OrCreateArgumentException();
            var alwaysTrue = MakeRule.That(() => true).OrCreateArgumentException();
            var newRuleSet = intialRuleSet.And(alwaysFalse, alwaysTrue);

            intialRuleSet.Item2.Should().BeEmpty();
            newRuleSet.Item2.Should().HaveCount(2);
            newRuleSet.Item2.Should().Contain(alwaysFalse);
            newRuleSet.Item2.Should().Contain(alwaysTrue);
        }
    
        [Test]
        public void And_can_be_chained()
        {
            var arg1 = null as object;
            var arg2 = null as object;
            var arg3 = null as object;

            var intialRuleSet = new { arg1, arg2, arg3 }.MustBe();
            var alwaysFalse = MakeRule.That(() => false).OrCreateArgumentException();
            var alwaysTrue = MakeRule.That(() => true).OrCreateArgumentException();
            var newRuleSet = intialRuleSet.And(alwaysFalse).And(alwaysTrue);

            intialRuleSet.Item2.Should().BeEmpty();
            newRuleSet.Item2.Should().HaveCount(2);
            newRuleSet.Item2.Should().Contain(alwaysFalse);
            newRuleSet.Item2.Should().Contain(alwaysTrue);
        }

        [Test]
        public void Report_calls_correct_validation_functions()
        {
            var arg1 = null as object;
            var arg2 = null as string;
            var arg3 = null as int?;
            var times1 = 0;
            var times2 = 0;
            var times3 = 0;

            var testRule1 = MakeRule.That<object>(
                v =>
                {
                    times1++;
                    return true;
                }).OrCreateArgumentException();

            var testRule2 = MakeRule.That<string>(
                v =>
                {
                    times2++;
                    return true;
                }).OrCreateArgumentException();

            var testRule3 = MakeRule.That<int?>(
                v =>
                {
                    times3++;
                    return true;
                }).OrCreateArgumentException();

            new { arg1, arg2, arg3 }.MustBe(testRule1, testRule2, testRule3).Report().ToList();

            times1.Should().Be(3);
            times2.Should().Be(1);
            times3.Should().Be(1);
        }

        [Test]
        public void OrThrow_calls_correct_validation_functions()
        {
            var arg1 = null as object;
            var arg2 = null as string;
            var arg3 = null as int?;
            var times1 = 0;
            var times2 = 0;
            var times3 = 0;

            var testRule1 = MakeRule.That<object>(
                v =>
                {
                    times1++;
                    return true;
                }).OrCreateArgumentException();

            var testRule2 = MakeRule.That<int>(
                v =>
                {
                    times2++;
                    return true;
                }).OrCreateArgumentException();

            var testRule3 = MakeRule.That<decimal>(
                v =>
                {
                    times3++;
                    return true;
                }).OrCreateArgumentException();

            new { arg1, arg2, arg3 }.MustBe(testRule1, testRule2, testRule3).OrThrow();

            times1.Should().Be(3);
            times2.Should().Be(0);
            times3.Should().Be(0);
        }

        [Test]
        public void Report_calls_validation_functions_with_expected_arguments()
        {
            var arg1 = "test";
            var arg2 = 1.5;
            var arg3 = null as int?;
            var actualStringValue = string.Empty;
            var actualDoubleValue = 0.0;
            int? actualIntValue = -1;

            var testRule1 = MakeRule.That<string>(
                v =>
                {
                    actualStringValue = v;
                    return true;
                }).OrCreateArgumentException();

            var testRule2 = MakeRule.That<double>(
                v =>
                {
                    actualDoubleValue = v;
                    return true;
                }).OrCreateArgumentException();

            var testRule3 = MakeRule.That<int?>(
                v =>
                {
                    actualIntValue = v;
                    return true;
                }).OrCreateArgumentException();

            new { arg1, arg2, arg3 }.MustBe(testRule1, testRule2, testRule3).Report().ToList();

            actualStringValue.Should().Be("test");
            actualDoubleValue.Should().Be(1.5);
            actualIntValue.Should().Be(null);
        }

        [Test]
        public void OrThrow_calls_validation_functions_with_expected_arguments()
        {
            var arg1 = 5;
            var arg2 = "test";
            var arg3 = DateTime.UtcNow;
            var actualIntValue = 0;
            var actualStringValue = string.Empty;
            var actualDateTimeValue = DateTime.MinValue;

            var testRule1 = MakeRule.That<int>(
                v =>
                {
                    actualIntValue = v;
                    return true;
                }).OrCreateArgumentException();

            var testRule2 = MakeRule.That<string>(
                v =>
                {
                    actualStringValue = v;
                    return true;
                }).OrCreateArgumentException();

            var testRule3 = MakeRule.That<DateTime>(
                v =>
                {
                    actualDateTimeValue = v;
                    return true;
                }).OrCreateArgumentException();

            new { arg1, arg2, arg3 }.MustBe(testRule1, testRule2, testRule3).Report().ToList();

            actualIntValue.Should().Be(5);
            actualStringValue.Should().Be("test");
            actualDateTimeValue.Should().Be(arg3);
        }

        [Test]
        public void Report_returns_expected_results()
        {
            var arg1 = new object();
            var arg2 = 1.5;
            var arg3 = "test";

            var alwaysTrue = MakeRule.That<object>(o => true).OrCreateArgumentException();
            var alwaysFalse = MakeRule.That<string>(s => false).OrCreateArgumentException().Because("Test");

            var report = new { arg1, arg2, arg3 }.MustBe(alwaysTrue, alwaysFalse).Report().ToList();

            report.Should().HaveCount(6); // all combinations
            report.First().Item1.Should().Be(typeof(object));
            report.First().Item2.Should().Be("arg1");
            report.First().Item3.Should().Be(arg1);
            report.First().Item4.Should().BeTrue();
            report.First().Item5.Should().BeEmpty();
            report.First().Item6.Should().BeSameAs(alwaysTrue.Item3);
            report.Skip(1).First().Item1.Should().Be(typeof(object));
            report.Skip(1).First().Item2.Should().Be("arg1");
            report.Skip(1).First().Item3.Should().Be(arg1);
            report.Skip(1).First().Item4.Should().BeTrue(); // because type is not string
            report.Skip(1).First().Item5.Should().HaveCount(1);
            report.Skip(1).First().Item5.Should().Contain("Test");
            report.Skip(1).First().Item6.Should().BeSameAs(alwaysFalse.Item3);
            report.Skip(2).First().Item1.Should().Be(typeof(double));
            report.Skip(2).First().Item2.Should().Be("arg2");
            report.Skip(2).First().Item3.Should().Be(arg2);
            report.Skip(2).First().Item4.Should().BeTrue();
            report.Skip(2).First().Item5.Should().BeEmpty();
            report.Skip(2).First().Item6.Should().BeSameAs(alwaysTrue.Item3);
            report.Skip(3).First().Item1.Should().Be(typeof(double));
            report.Skip(3).First().Item2.Should().Be("arg2");
            report.Skip(3).First().Item3.Should().Be(arg2);
            report.Skip(3).First().Item4.Should().BeTrue(); // because type is not string
            report.Skip(3).First().Item5.Should().HaveCount(1);
            report.Skip(3).First().Item5.Should().Contain("Test");
            report.Skip(3).First().Item6.Should().BeSameAs(alwaysFalse.Item3);
            report.Skip(4).First().Item1.Should().Be(typeof(string));
            report.Skip(4).First().Item2.Should().Be("arg3");
            report.Skip(4).First().Item3.Should().Be(arg3);
            report.Skip(4).First().Item4.Should().BeTrue();
            report.Skip(4).First().Item5.Should().BeEmpty();
            report.Skip(4).First().Item6.Should().BeSameAs(alwaysTrue.Item3);
            report.Skip(5).First().Item1.Should().Be(typeof(string));
            report.Skip(5).First().Item2.Should().Be("arg3");
            report.Skip(5).First().Item3.Should().Be(arg3);
            report.Skip(5).First().Item4.Should().BeFalse();
            report.Skip(5).First().Item5.Should().HaveCount(1);
            report.Skip(5).First().Item5.Should().Contain("Test");
            report.Skip(5).First().Item6.Should().BeSameAs(alwaysFalse.Item3);
        }

        [Test]
        public void OrThrow_does_not_call_GetException_when_validation_succeeds()
        {
            var arg1 = Guid.NewGuid();
            int? arg2 = null;

            var called = false;
            var alwaysTrue = MakeRule.That<object>(o => true);
            
            var true1 = alwaysTrue.OrCreate(
                () =>
                {
                    called = true;
                    return new Exception();
                });

            var true2 = alwaysTrue.OrCreate(
                argumentName =>
                {
                    called = true;
                    return new Exception();
                });

            var true3 = alwaysTrue.OrCreate(
                (argumentValue, argumentName) =>
                {
                    called = true;
                    return new Exception();
                });

            var true4 = alwaysTrue.OrCreate(
                (messages, argumentValue, argumentName) =>
                {
                    called = true;
                    return new Exception();
                });

            var true5 = alwaysTrue.OrCreate(
                (type, messages, argumentValue, argumentName) =>
                {
                    called = true;
                    return new Exception();
                });

            new { arg1, arg2 }.MustBe(true1).OrThrow();
            new { arg1, arg2 }.MustBe(true2).OrThrow();
            new { arg1, arg2 }.MustBe(true3).OrThrow();
            new { arg1, arg2 }.MustBe(true4).OrThrow();
            new { arg1, arg2 }.MustBe(true5).OrThrow();

            called.Should().BeFalse();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "Test is about the type and parameter name is irrelevant here.")]
        [Test]
        public void OrThrow_calls_getException_with_expected_arguments_when_validation_fails()
        {
            var arg1 = "Value";

            string argumentName1 = null;
            string argumentName2 = null;
            string argumentName3 = null;
            string argumentName4 = null;
            object argumentValue2 = null;
            object argumentValue3 = null;
            object argumentValue4 = null;
            IEnumerable<string> messages3 = null;
            IEnumerable<string> messages4 = null;
            Type type4 = null;

            var alwaysFalse = MakeRule.That<object>(o => false);

            var false1 = alwaysFalse.OrCreate(
                argumentName =>
                {
                    argumentName1 = argumentName;
                    return new ArgumentException();
                });

            var false2 = alwaysFalse.OrCreate(
                (argumentValue, argumentName) =>
                {
                    argumentName2 = argumentName;
                    argumentValue2 = argumentValue;
                    return new ArgumentException();
                });

            var false3 = alwaysFalse.OrCreate(
                (messages, argumentValue, argumentName) =>
                {
                    argumentName3 = argumentName;
                    argumentValue3 = argumentValue;
                    messages3 = messages;
                    return new ArgumentException();
                }).Because("Test1");

            var false4 = alwaysFalse.OrCreate(
                (type, messages, argumentValue, argumentName) =>
                {
                    argumentName4 = argumentName;
                    argumentValue4 = argumentValue;
                    messages4 = messages;
                    type4 = type;
                    return new ArgumentException();
                }).Because("Test1").Because("Test2");

            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe(false1).OrThrow());
            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe(false2).OrThrow());
            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe(false3).OrThrow());
            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe(false4).OrThrow());

            argumentName1.Should().Be("arg1");
            argumentName2.Should().Be("arg1");
            argumentName3.Should().Be("arg1");
            argumentName4.Should().Be("arg1");
            argumentValue2.Should().Be("Value");
            argumentValue3.Should().Be("Value");
            argumentValue4.Should().Be("Value");
            messages3.Should().HaveCount(1).And.Contain("Test1");
            messages4.Should().HaveCount(2).And.ContainInOrder("Test1", "Test2");
            type4.Should().Be<string>();
        }

        [Test]
        public void OrThrow_does_not_throw_when_getException_returns_null()
        {
            var arg1 = "Value";

            var alwaysFalse = MakeRule.That<object>(o => false);

            var false1 = alwaysFalse.OrCreate<object, ArgumentException>(() => null);
            var false2 = alwaysFalse.OrCreate<object, ArgumentException>(_ => null);
            var false3 = alwaysFalse.OrCreate<object, ArgumentException>((_, __) => null);
            var false4 = alwaysFalse.OrCreate<object, ArgumentException>((_, __, ___) => null);
            var false5 = alwaysFalse.OrCreate<object, ArgumentException>((_, __, ___, ____) => null);

            Assert.DoesNotThrow(() => new { arg1 }.MustBe(false1).OrThrow());
            Assert.DoesNotThrow(() => new { arg1 }.MustBe(false2).OrThrow());
            Assert.DoesNotThrow(() => new { arg1 }.MustBe(false3).OrThrow());
            Assert.DoesNotThrow(() => new { arg1 }.MustBe(false4).OrThrow());
            Assert.DoesNotThrow(() => new { arg1 }.MustBe(false5).OrThrow());
        }

        [Test]
        public void OrThrow_throws_exception_returned_from_getException_if_only_validation_exception()
        {
            var arg1 = "Value";

            var alwaysFalse = MakeRule.That<object>(o => false);

            var false1 = alwaysFalse.OrCreate(() => new TestException());
            var false2 = alwaysFalse.OrCreate(_ => new TestException());
            var false3 = alwaysFalse.OrCreate((_, __) => new TestException());
            var false4 = alwaysFalse.OrCreate((_, __, ___) => new TestException());
            var false5 = alwaysFalse.OrCreate((_, __, ___, ____) => new TestException());

            Assert.Throws<TestException>(() => new { arg1 }.MustBe(false1).OrThrow());
            Assert.Throws<TestException>(() => new { arg1 }.MustBe(false2).OrThrow());
            Assert.Throws<TestException>(() => new { arg1 }.MustBe(false3).OrThrow());
            Assert.Throws<TestException>(() => new { arg1 }.MustBe(false4).OrThrow());
            Assert.Throws<TestException>(() => new { arg1 }.MustBe(false5).OrThrow());
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "OrThrow", Justification = "This text refers to a valid method name.")]
        [Test]
        public void OrThrow_throws_ArgumentException_containing_all_failed_exceptions_when_multiple_validations_fail()
        {
            var arg1 = "Value";
            int? arg2 = null;

            var notNull = MakeRule.That<object>(o => o != null).OrCreateArgumentNullException();
            var notEqualValue = MakeRule.That<string>(s => s != "Value").OrCreateArgumentException();

            try
            {
                new { arg1, arg2 }.MustBe(notNull, notEqualValue).OrThrow();
            }
            catch (ArgumentException ex)
            {
                ex.InnerException.Should().NotBeNull();
                ex.InnerException.Should().BeOfType<AggregateException>();
                (ex.InnerException as AggregateException).InnerExceptions.Should().HaveCount(2);
                (ex.InnerException as AggregateException).InnerExceptions.First()
                    .Should().BeOfType<ArgumentException>();
                (ex.InnerException as AggregateException).InnerExceptions.First()
                    .GetType()
                    .Should()
                    .NotBe<ArgumentNullException>();
                (ex.InnerException as AggregateException).InnerExceptions.Skip(1).First()
                    .Should().BeOfType<ArgumentNullException>();

                return;
            }

            Assert.Fail("Expected OrThrow() to throw but it didn't.");
        }

        [Serializable]
        private class TestException : Exception
        {
        }
    }
}

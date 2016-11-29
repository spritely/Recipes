﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RuleExtensionsTest.cs">
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
    using FluentAssertions;
    using NUnit.Framework;

    // See MustExtensions.cs for comments on type definitions
    using GetArguments = System.Func<System.Collections.Generic.IEnumerable<System.Tuple<System.Type, string, object>>>;
    using Rule = System.Tuple<System.Func<System.Type, object, bool>, System.Collections.Generic.IEnumerable<string>, System.Func<System.Type, System.Collections.Generic.IEnumerable<string>, object, string, System.Exception>>;

    [TestFixture]
    public class RuleExtensionsTest
    {
        [Test]
        public void NotNull_throws_when_an_argument_is_null()
        {
            var arg1 = "throw test";
            var arg2 = new object();
            var arg3 = 5;
            int? arg4 = null;
            
            Assert.Throws<ArgumentNullException>(() => new { arg1, arg2, arg3, arg4 }.MustBe().NotNull().OrThrow());
            Assert.Throws<ArgumentNullException>(() => arg4.Named("Test").MustBe().NotNull().OrThrow());
        }

        [Test]
        public void NotNull_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = "another test";
            var arg2 = 23;
            var arg3 = null as object;

            Action action1 = () => new { arg1, arg2, arg3 }.MustBe().NotNull().OrThrow();
            Action action2 = () => arg3.Named("The argument").MustBe().NotNull().OrThrow();

            action1.ShouldThrow<ArgumentException>()
                .And.Message.Should()
                .Contain("arg3")
                .And.NotContain("arg1")
                .And.NotContain("arg2");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("The argument").And.NotContain("arg3");
        }

        [Test]
        public void NotNull_does_not_throw_when_no_arguments_are_null()
        {
            var arg1 = "no throw test";
            var arg2 = new object();
            var arg3 = 34.4;

            new { arg1, arg2, arg3 }.MustBe().NotNull().OrThrow();
            arg1.Named("test").MustBe().NotNull().OrThrow();
        }

        [Test]
        public void True_throws_when_an_argument_is_false()
        {
            var arg1 = false;

            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe().True().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).MustBe().True().OrThrow());
        }

        [Test]
        public void True_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = "another test";
            var arg2 = 0;
            var arg3 = false;

            Action action1 = () => new { arg1, arg2, arg3 }.MustBe().True().OrThrow();
            Action action2 = () => arg3.Named("false argument").MustBe().True().OrThrow();

            action1.ShouldThrow<ArgumentException>()
                .And.Message.Should()
                .Contain("arg3")
                .And.NotContain("arg1")
                .And.NotContain("arg2");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("false argument").And.NotContain("arg3");
        }

        [Test]
        public void True_does_not_throw_when_no_arguments_are_false()
        {
            var arg1 = "no throw test";
            var arg2 = true;
            var arg3 = 34.4;

            new { arg1, arg2, arg3 }.MustBe().True().OrThrow();
            arg2.Named(nameof(arg2)).MustBe().True().OrThrow();
        }

        [Test]
        public void False_throws_when_an_argument_is_true()
        {
            var arg1 = true;

            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe().False().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).MustBe().False().OrThrow());
        }

        [Test]
        public void False_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = true;
            var arg2 = false;
            var arg3 = false;

            Action action1 = () => new { arg1, arg2, arg3 }.MustBe().False().OrThrow();
            Action action2 = () => arg1.Named(nameof(arg1)).MustBe().False().OrThrow();

            action1.ShouldThrow<ArgumentException>()
                .And.Message.Should()
                .Contain("arg1")
                .And.NotContain("arg2")
                .And.NotContain("arg3");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
        }

        [Test]
        public void False_does_not_throw_when_no_arguments_are_true()
        {
            var arg1 = false;
            var arg2 = Guid.NewGuid();
            var arg3 = DateTime.UtcNow;

            new { arg1, arg2, arg3 }.MustBe().False().OrThrow();
            arg1.Named(nameof(arg1)).MustBe().False().OrThrow();
        }

        [Test]
        public void NotEmptyString_does_not_throw_when_an_argument_is_null()
        {
            var arg1 = null as string;

            new { arg1 }.MustBe().NotEmptyString().OrThrow();
            arg1.Named(nameof(arg1)).MustBe().NotEmptyString().OrThrow();
        }

        [Test]
        public void NotEmptyString_throws_when_an_argument_is_empty()
        {
            var arg1 = string.Empty;

            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe().NotEmptyString().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).MustBe().NotEmptyString().OrThrow());
        }

        [Test]
        public void NotEmptyString_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = string.Empty;

            Action action1 = () => new { arg1 }.MustBe().NotEmptyString().OrThrow();
            Action action2 = () => arg1.Named("empty argument").MustBe().NotEmptyString().OrThrow();

            action1.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("empty argument");
        }

        [Test]
        public void NotEmptyString_does_not_throw_when_arguments_are_not_empty()
        {
            var arg1 = "should not throw";

            new { arg1 }.MustBe().NotEmptyString().OrThrow();
            arg1.Named(nameof(arg1)).MustBe().NotEmptyString().OrThrow();
        }

        [Test]
        public void NotNullOrEmptyString_throws_when_an_argument_is_null()
        {
            var arg1 = null as string;

            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe().NotNullOrEmptyString().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named("Test").MustBe().NotNullOrEmptyString().OrThrow());
        }

        [Test]
        public void NotNullOrEmptyString_throws_when_an_argument_is_empty()
        {
            var arg1 = string.Empty;

            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe().NotNullOrEmptyString().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).MustBe().NotNullOrEmptyString().OrThrow());
        }

        [Test]
        public void NotNullOrEmptyString_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = string.Empty;

            Action action1 = () => new { arg1 }.MustBe().NotNullOrEmptyString().OrThrow();
            Action action2 = () => arg1.Named("Test argument").MustBe().NotNullOrEmptyString().OrThrow();

            action1.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("Test argument");
        }

        [Test]
        public void NotNullOrEmptyString_does_not_throw_when_arguments_are_not_null_or_empty()
        {
            var arg1 = "should not throw";

            new { arg1 }.MustBe().NotNullOrEmptyString().OrThrow();
            arg1.Named(nameof(arg1)).MustBe().NotNullOrEmptyString().OrThrow();
        }

        [Test]
        public void NotWhiteSpace_does_not_throw_when_an_argument_is_null()
        {
            var arg1 = null as string;

            new { arg1 }.MustBe().NotWhiteSpace().OrThrow();
            arg1.Named(nameof(arg1)).MustBe().NotWhiteSpace().OrThrow();
        }

        [Test]
        public void NotWhiteSpace_throws_when_an_argument_is_empty()
        {
            var arg1 = string.Empty;

            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe().NotWhiteSpace().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).MustBe().NotWhiteSpace().OrThrow());
        }

        [Test]
        public void NotWhiteSpace_throws_when_an_argument_is_white_space()
        {
            var arg1 = "\t\t\r\n  ";

            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe().NotWhiteSpace().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).MustBe().NotWhiteSpace().OrThrow());
        }

        [Test]
        public void NotWhiteSpace_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = "   ";

            Action action1 = () => new { arg1 }.MustBe().NotWhiteSpace().OrThrow();
            Action action2 = () => arg1.Named("First arg").MustBe().NotWhiteSpace().OrThrow();

            action1.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("First arg");
        }

        [Test]
        public void NotWhiteSpace_does_not_throw_when_arguments_are_not_null_or_white_space()
        {
            var arg1 = "should not throw";

            new { arg1 }.MustBe().NotWhiteSpace().OrThrow();
            arg1.Named(nameof(arg1)).MustBe().NotWhiteSpace().OrThrow();
        }

        [Test]
        public void NotNullOrWhiteSpace_throws_when_an_argument_is_null()
        {
            var arg1 = null as string;

            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe().NotNullOrWhiteSpace().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).MustBe().NotNullOrWhiteSpace().OrThrow());
        }

        [Test]
        public void NotNullOrWhiteSpace_throws_when_an_argument_is_empty()
        {
            var arg1 = string.Empty;

            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe().NotNullOrWhiteSpace().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).MustBe().NotNullOrWhiteSpace().OrThrow());
        }

        [Test]
        public void NotNullOrWhiteSpace_throws_when_an_argument_is_white_space()
        {
            var arg1 = "  \t ";

            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe().NotNullOrWhiteSpace().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).MustBe().NotNullOrWhiteSpace().OrThrow());
        }

        [Test]
        public void NotNullOrWhiteSpace_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = "   ";

            Action action1 = () => new { arg1 }.MustBe().NotNullOrWhiteSpace().OrThrow();
            Action action2 = () => arg1.Named("First arg").MustBe().NotNullOrWhiteSpace().OrThrow();

            action1.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("First arg");
        }

        [Test]
        public void NotNullOrWhiteSpace_does_not_throw_when_arguments_are_not_null_or_white_space()
        {
            var arg1 = "should not throw";

            new { arg1 }.MustBe().NotNullOrWhiteSpace().OrThrow();
            arg1.Named(nameof(arg1)).MustBe().NotNullOrWhiteSpace().OrThrow();
        }

        [Test]
        public void NotEmptyGuid_throws_when_an_argument_is_empty()
        {
            var arg1 = Guid.Empty;

            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe().NotEmptyGuid().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).MustBe().NotEmptyGuid().OrThrow());
        }

        [Test]
        public void NotEmptyGuid_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = Guid.Empty;

            Action action1 = () => new { arg1 }.MustBe().NotEmptyGuid().OrThrow();
            Action action2 = () => arg1.Named(nameof(arg1)).MustBe().NotEmptyGuid().OrThrow();

            action1.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
        }

        [Test]
        public void NotEmptyGuid_does_not_throw_when_arguments_are_not_null_or_empty()
        {
            var arg1 = Guid.NewGuid();

            new { arg1 }.MustBe().NotEmptyGuid().OrThrow();
            arg1.Named(nameof(arg1)).MustBe().NotEmptyGuid().OrThrow();
        }

        [Test]
        public void NotDefault_throws_when_an_argument_is_default()
        {
            var arg1 = default(DateTime);

            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe().NotDefault<DateTime>().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).MustBe().NotDefault<DateTime>().OrThrow());
        }

        [Test]
        public void NotDefault_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = default(Guid);

            Action action1 = () => new { arg1 }.MustBe().NotDefault<Guid>().OrThrow();
            Action action2 = () => arg1.Named("First arg").MustBe().NotDefault<Guid>().OrThrow();

            action1.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("First arg");
        }

        [Test]
        public void NotDefault_does_not_throw_when_arguments_are_not_default_values()
        {
            var arg1 = Guid.NewGuid();

            new { arg1 }.MustBe().NotDefault<Guid>().OrThrow();
            arg1.Named(nameof(arg1)).MustBe().NotDefault<Guid>().OrThrow();
        }

        [Test]
        public void NotNullOrDefault_throws_when_an_argument_is_null()
        {
            var arg1 = null as string;

            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe().NotNullOrDefault<string>().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).MustBe().NotNullOrDefault<string>().OrThrow());
        }

        [Test]
        public void NotNullOrDefault_throws_when_an_argument_is_default()
        {
            var arg1 = default(string);

            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe().NotNullOrDefault<string>().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).MustBe().NotNullOrDefault<string>().OrThrow());
        }

        [Test]
        public void NotNullOrDefault_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = default(string);

            Action action1 = () => new { arg1 }.MustBe().NotNullOrDefault<string>().OrThrow();
            Action action2 = () => arg1.Named("First arg").MustBe().NotNullOrDefault<string>().OrThrow();

            action1.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("First arg");
        }

        [Test]
        public void NotNullOrDefault_does_not_throw_when_arguments_are_not_null_or_default()
        {
            var arg1 = Guid.NewGuid();

            new { arg1 }.MustBe().NotNullOrDefault<Guid>().OrThrow();
            arg1.Named(nameof(arg1)).MustBe().NotNullOrDefault<Guid>().OrThrow();
        }

        [Test]
        public void NotNullOrEmptyEnumerable_throws_when_an_argument_is_null()
        {
            var arg1 = null as IEnumerable<int>;
            
            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe().NotNullOrEmptyEnumerable<int>().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).MustBe().NotNullOrEmptyEnumerable<int>().OrThrow());
        }

        [Test]
        public void NotNullOrEmptyEnumerable_throws_when_an_argument_is_empty()
        {
            var arg1 = new List<string>();

            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe().NotNullOrEmptyEnumerable<string>().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).MustBe().NotNullOrEmptyEnumerable<string>().OrThrow());
        }

        [Test]
        public void NotNullOrEmptyEnumerable_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = null as IEnumerable<object>;
            var arg2 = new double[0];

            Action action1 = () => new { arg1 }.MustBe().NotNullOrEmptyEnumerable<object>().OrThrow();
            Action action2 = () => arg2.Named(nameof(arg2)).MustBe().NotNullOrEmptyEnumerable<double>().OrThrow();

            action1.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg2");
        }

        [Test]
        public void NotNullOrEmptyEnumerable_does_not_throw_when_arguments_are_not_null_or_empty()
        {
            var arg1 = new [] { "test 1", "test 2" };
            var arg2 = new[] { 500123, -1243 };

            new { arg1 }.MustBe().NotNullOrEmptyEnumerable<string>().OrThrow();
            arg2.Named(nameof(arg2)).MustBe().NotNullOrEmptyEnumerable<int>().OrThrow();
        }

        [Test]
        public void NotNullOrContainAnyNulls_throws_when_an_argument_is_null()
        {
            var arg1 = null as IEnumerable<int?>;

            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe().NotNullOrContainAnyNulls<int?>().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).MustBe().NotNullOrContainAnyNulls<int?>().OrThrow());
        }

        [Test]
        public void NotNullOrContainAnyNulls_throws_when_an_argument_contains_null()
        {
            var arg1 = new List<string> { "Test1", "Test2", null, "Test3" };

            Assert.Throws<ArgumentException>(() => new { arg1 }.MustBe().NotNullOrContainAnyNulls<string>().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).MustBe().NotNullOrContainAnyNulls<string>().OrThrow());
        }

        [Test]
        public void NotNullOrContainAnyNulls_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = new List<string> { "Test1", "Test2", null, "Test3" };

            Action action1 = () => new { arg1 }.MustBe().NotNullOrContainAnyNulls<string>().OrThrow();
            Action action2 = () => arg1.Named(nameof(arg1)).MustBe().NotNullOrContainAnyNulls<string>().OrThrow();

            action1.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
        }

        [Test]
        public void NotNullOrContainAnyNulls_does_not_throw_when_arguments_are_not_null_or_contain_null_items()
        {
            var arg1 = new[] { "test 1", "test 2" };
            var arg2 = new[] { 500123, -1243 };

            new { arg1 }.MustBe().NotNullOrContainAnyNulls<string>().OrThrow();
            arg2.Named(nameof(arg2)).MustBe().NotNullOrContainAnyNulls<int>().OrThrow();
        }

        [Test]
        public void InRange_throws_if_minimum_or_maximum_are_null()
        {
            Action action1 = () => new { validArg = "Test" }.MustBe().InRange(null, "Z").OrThrow();
            Action action2 = () => new { validArg = "Test" }.MustBe().InRange("A", null).OrThrow();

            action1.ShouldThrow<ArgumentNullException>().And.Message.Should().Contain("minimum");
            action2.ShouldThrow<ArgumentNullException>().And.Message.Should().Contain("maximum");
        }

        [Test]
        public void InRange_throws_if_value_is_less_than_minimum()
        {
            var tooLowArg = 19;
            Action action1 = () => new { tooLowArg }.MustBe().InRange(20, int.MaxValue).OrThrow();
            Action action2 = () => tooLowArg.Named(nameof(tooLowArg)).MustBe().InRange(50, 100).OrThrow();

            action1.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooLowArg")
                .And.Contain("20");
            
            action2.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooLowArg")
                .And.Contain("50");
        }

        [Test]
        public void InRange_throws_if_value_is_greater_than_maximum()
        {
            var tooHighArg = -4;
            Action action1 = () => new { tooHighArg }.MustBe().InRange(int.MinValue, -5).OrThrow();
            Action action2 = () => tooHighArg.Named(nameof(tooHighArg)).MustBe().InRange(int.MinValue, -50).OrThrow();

            action1.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooHighArg")
                .And.Contain("-5");

            action2.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooHighArg")
                .And.Contain("-50");
        }

        [Test]
        public void InRange_does_not_throw_when_value_is_in_range()
        {
            var arg1 = 0;

            new { arg1 }.MustBe().InRange(0, 20).OrThrow();
            arg1.Named(nameof(arg1)).MustBe().InRange(-100, 0).OrThrow();
        }

        [Test]
        public void LessThan_throws_if_requirement_is_null()
        {
            Action act = () => new { validArg = "Test" }.MustBe().LessThan(null as string).OrThrow();
            
            act.ShouldThrow<ArgumentNullException>().And.Message.Should().Contain("requirement");
        }

        [Test]
        public void LessThan_throws_if_value_is_not_less_than_requirement()
        {
            var tooHighArg = 19;
            Action action1 = () => new { tooHighArg }.MustBe().LessThan(19).OrThrow();
            Action action2 = () => tooHighArg.Named(nameof(tooHighArg)).MustBe().LessThan(18).OrThrow();

            action1.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooHighArg")
                .And.Contain("19");

            action2.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooHighArg")
                .And.Contain("18");
        }

        [Test]
        public void LessThan_does_not_throw_when_value_is_less_than_requirement()
        {
            var arg1 = 0;

            new { arg1 }.MustBe().LessThan(20).OrThrow();
            arg1.Named(nameof(arg1)).MustBe().LessThan(1).OrThrow();
        }

        [Test]
        public void LessThanOrEqualTo_throws_if_requirement_is_null()
        {
            Action act = () => new { validArg = "Test" }.MustBe().LessThanOrEqualTo(null as string).OrThrow();

            act.ShouldThrow<ArgumentNullException>().And.Message.Should().Contain("requirement");
        }

        [Test]
        public void LessThanOrEqualTo_throws_if_value_is_not_less_than_or_equal_to_requirement()
        {
            var tooHighArg = 19;
            Action action1 = () => new { tooHighArg }.MustBe().LessThanOrEqualTo(18).OrThrow();
            Action action2 = () => tooHighArg.Named(nameof(tooHighArg)).MustBe().LessThanOrEqualTo(0).OrThrow();

            action1.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooHighArg")
                .And.Contain("18");

            action2.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooHighArg")
                .And.Contain("0");
        }

        [Test]
        public void LessThanOrEqualTo_does_not_throw_when_value_is_less_than_or_equal_to_requirement()
        {
            var arg1 = 0;

            new { arg1 }.MustBe().LessThanOrEqualTo(1).OrThrow();
            arg1.Named(nameof(arg1)).MustBe().LessThanOrEqualTo(0).OrThrow();
        }

        [Test]
        public void EqualTo_throws_if_requirement_is_null()
        {
            Action act = () => new { validArg = "Test" }.MustBe().EqualTo(null as string).OrThrow();

            act.ShouldThrow<ArgumentNullException>().And.Message.Should().Contain("requirement");
        }

        [Test]
        public void EqualTo_throws_if_value_is_not_equal_to_requirement()
        {
            Action action1 = () => new { tooLowArg = 6.0 }.MustBe().EqualTo(6.1).OrThrow();
            Action action2 = () => 6.2.Named("tooHighArg").MustBe().EqualTo(6.1).OrThrow();

            action1.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooLowArg")
                .And.Contain("6.1");

            action2.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooHighArg")
                .And.Contain("6.1");
        }

        [Test]
        public void OrEqualTo_does_not_throw_when_value_is_equal_to_requirement()
        {
            var arg1 = "Test";

            new { arg1 }.MustBe().EqualTo("Test").OrThrow();
            arg1.Named(nameof(arg1)).MustBe().EqualTo("Test").OrThrow();
        }

        [Test]
        public void GreaterThan_throws_if_requirement_is_null()
        {
            Action act = () => new { validArg = "Test" }.MustBe().GreaterThan(null as string).OrThrow();

            act.ShouldThrow<ArgumentNullException>().And.Message.Should().Contain("requirement");
        }

        [Test]
        public void GreaterThan_throws_if_value_is_not_greater_than_requirement()
        {
            var tooLowArg = 19.5;
            Action action1 = () => new { tooLowArg }.MustBe().GreaterThan(19.5).OrThrow();
            Action action2 = () => tooLowArg.Named(nameof(tooLowArg)).MustBe().GreaterThan(20.1).OrThrow();

            action1.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooLowArg")
                .And.Contain("19.5");

            action2.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooLowArg")
                .And.Contain("20.1");
        }

        [Test]
        public void GreaterThan_does_not_throw_when_value_is_greater_than_requirement()
        {
            var arg1 = 0.2;

            new { arg1 }.MustBe().GreaterThan(0.0).OrThrow();
            arg1.Named(nameof(arg1)).MustBe().GreaterThan(0.19).OrThrow();
        }

        [Test]
        public void GreaterThanOrEqualTo_throws_if_requirement_is_null()
        {
            Action act = () => new { validArg = "Test" }.MustBe().GreaterThanOrEqualTo(null as string).OrThrow();

            act.ShouldThrow<ArgumentNullException>().And.Message.Should().Contain("requirement");
        }

        [Test]
        public void GreaterThanOrEqualTo_throws_if_value_is_not_greater_than_or_equal_to_requirement()
        {
            var tooLowArg = 5.6;
            Action action1 = () => new { tooLowArg }.MustBe().GreaterThanOrEqualTo(5.9).OrThrow();
            Action action2 = () => tooLowArg.Named(nameof(tooLowArg)).MustBe().GreaterThanOrEqualTo(5.61).OrThrow();

            action1.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooLowArg")
                .And.Contain("5.9");

            action2.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooLowArg")
                .And.Contain("5.61");
        }

        [Test]
        public void GreaterThanOrEqualTo_does_not_throw_when_value_is_greater_than_or_equal_to_requirement()
        {
            var arg1 = 0.5;

            new { arg1 }.MustBe().GreaterThanOrEqualTo(-1.0).OrThrow();
            arg1.Named(nameof(arg1)).MustBe().GreaterThanOrEqualTo(0.5).OrThrow();
        }
    }
}

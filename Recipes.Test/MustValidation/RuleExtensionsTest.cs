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
        public void NotBeNull_throws_when_an_argument_is_null()
        {
            var arg1 = "throw test";
            var arg2 = new object();
            var arg3 = 5;
            int? arg4 = null;
            
            Assert.Throws<ArgumentNullException>(() => new { arg1, arg2, arg3, arg4 }.Must().NotBeNull().OrThrow());
            Assert.Throws<ArgumentNullException>(() => arg4.Named("Test").Must().NotBeNull().OrThrow());
        }

        [Test]
        public void NotBeNull_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = "another test";
            var arg2 = 23;
            var arg3 = null as object;

            Action action1 = () => new { arg1, arg2, arg3 }.Must().NotBeNull().OrThrow();
            Action action2 = () => arg3.Named("The argument").Must().NotBeNull().OrThrow();

            action1.ShouldThrow<ArgumentException>()
                .And.Message.Should()
                .Contain("arg3")
                .And.NotContain("arg1")
                .And.NotContain("arg2");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("The argument").And.NotContain("arg3");
        }

        [Test]
        public void NotBeNull_does_not_throw_when_no_arguments_are_null()
        {
            var arg1 = "no throw test";
            var arg2 = new object();
            var arg3 = 34.4;

            new { arg1, arg2, arg3 }.Must().NotBeNull().OrThrow();
            arg1.Named("test").Must().NotBeNull().OrThrow();
        }

        [Test]
        public void BeTrue_throws_when_an_argument_is_false()
        {
            var arg1 = false;

            Assert.Throws<ArgumentException>(() => new { arg1 }.Must().BeTrue().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).Must().BeTrue().OrThrow());
        }

        [Test]
        public void BeTrue_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = "another test";
            var arg2 = 0;
            var arg3 = false;

            Action action1 = () => new { arg1, arg2, arg3 }.Must().BeTrue().OrThrow();
            Action action2 = () => arg3.Named("false argument").Must().BeTrue().OrThrow();

            action1.ShouldThrow<ArgumentException>()
                .And.Message.Should()
                .Contain("arg3")
                .And.NotContain("arg1")
                .And.NotContain("arg2");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("false argument").And.NotContain("arg3");
        }

        [Test]
        public void BeTrue_does_not_throw_when_no_arguments_are_false()
        {
            var arg1 = "no throw test";
            var arg2 = true;
            var arg3 = 34.4;

            new { arg1, arg2, arg3 }.Must().BeTrue().OrThrow();
            arg2.Named(nameof(arg2)).Must().BeTrue().OrThrow();
        }

        [Test]
        public void BeFalse_throws_when_an_argument_is_true()
        {
            var arg1 = true;

            Assert.Throws<ArgumentException>(() => new { arg1 }.Must().BeFalse().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).Must().BeFalse().OrThrow());
        }

        [Test]
        public void BeFalse_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = true;
            var arg2 = false;
            var arg3 = false;

            Action action1 = () => new { arg1, arg2, arg3 }.Must().BeFalse().OrThrow();
            Action action2 = () => arg1.Named(nameof(arg1)).Must().BeFalse().OrThrow();

            action1.ShouldThrow<ArgumentException>()
                .And.Message.Should()
                .Contain("arg1")
                .And.NotContain("arg2")
                .And.NotContain("arg3");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
        }

        [Test]
        public void BeFalse_does_not_throw_when_no_arguments_are_true()
        {
            var arg1 = false;
            var arg2 = Guid.NewGuid();
            var arg3 = DateTime.UtcNow;

            new { arg1, arg2, arg3 }.Must().BeFalse().OrThrow();
            arg1.Named(nameof(arg1)).Must().BeFalse().OrThrow();
        }

        [Test]
        public void NotBeEmptyString_throws_when_an_argument_is_null()
        {
            var arg1 = null as string;

            Assert.Throws<ArgumentException>(() => new { arg1 }.Must().NotBeEmptyString().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named("Test").Must().NotBeEmptyString().OrThrow());
        }

        [Test]
        public void NotBeEmptyString_throws_when_an_argument_is_empty()
        {
            var arg1 = string.Empty;

            Assert.Throws<ArgumentException>(() => new { arg1 }.Must().NotBeEmptyString().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).Must().NotBeEmptyString().OrThrow());
        }

        [Test]
        public void NotBeEmptyString_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = string.Empty;

            Action action1 = () => new { arg1 }.Must().NotBeEmptyString().OrThrow();
            Action action2 = () => arg1.Named("Test argument").Must().NotBeEmptyString().OrThrow();

            action1.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("Test argument");
        }

        [Test]
        public void NotBeEmptyString_does_not_throw_when_arguments_are_not_null_or_empty()
        {
            var arg1 = "should not throw";

            new { arg1 }.Must().NotBeEmptyString().OrThrow();
            arg1.Named(nameof(arg1)).Must().NotBeEmptyString().OrThrow();
        }

        [Test]
        public void NotBeWhiteSpace_throws_when_an_argument_is_null()
        {
            var arg1 = null as string;

            Assert.Throws<ArgumentException>(() => new { arg1 }.Must().NotBeWhiteSpace().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).Must().NotBeWhiteSpace().OrThrow());
        }

        [Test]
        public void NotBeWhiteSpace_throws_when_an_argument_is_empty()
        {
            var arg1 = string.Empty;

            Assert.Throws<ArgumentException>(() => new { arg1 }.Must().NotBeWhiteSpace().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).Must().NotBeWhiteSpace().OrThrow());
        }

        [Test]
        public void NotBeWhiteSpace_throws_when_an_argument_is_white_space()
        {
            var arg1 = "  \t ";

            Assert.Throws<ArgumentException>(() => new { arg1 }.Must().NotBeWhiteSpace().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).Must().NotBeWhiteSpace().OrThrow());
        }

        [Test]
        public void NotBeWhiteSpace_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = "   ";

            Action action1 = () => new { arg1 }.Must().NotBeWhiteSpace().OrThrow();
            Action action2 = () => arg1.Named("First arg").Must().NotBeWhiteSpace().OrThrow();

            action1.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("First arg");
        }

        [Test]
        public void NotBeWhiteSpace_does_not_throw_when_arguments_are_not_null_or_white_space()
        {
            var arg1 = "should not throw";

            new { arg1 }.Must().NotBeWhiteSpace().OrThrow();
            arg1.Named(nameof(arg1)).Must().NotBeWhiteSpace().OrThrow();
        }

        [Test]
        public void NotBeEmptyGuid_throws_when_an_argument_is_empty()
        {
            var arg1 = Guid.Empty;

            Assert.Throws<ArgumentException>(() => new { arg1 }.Must().NotBeEmptyGuid().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).Must().NotBeEmptyGuid().OrThrow());
        }

        [Test]
        public void NotBeEmptyGuid_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = Guid.Empty;

            Action action1 = () => new { arg1 }.Must().NotBeEmptyGuid().OrThrow();
            Action action2 = () => arg1.Named(nameof(arg1)).Must().NotBeEmptyGuid().OrThrow();

            action1.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
        }

        [Test]
        public void NotBeEmptyGuid_does_not_throw_when_arguments_are_not_null_or_empty()
        {
            var arg1 = Guid.NewGuid();

            new { arg1 }.Must().NotBeEmptyGuid().OrThrow();
            arg1.Named(nameof(arg1)).Must().NotBeEmptyGuid().OrThrow();
        }

        [Test]
        public void NotBeDefault_throws_when_an_argument_is_null()
        {
            var arg1 = null as string;

            Assert.Throws<ArgumentException>(() => new { arg1 }.Must().NotBeDefault<string>().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).Must().NotBeDefault<string>().OrThrow());
        }

        [Test]
        public void NotBeDefault_throws_when_an_argument_is_default()
        {
            var arg1 = default(string);

            Assert.Throws<ArgumentException>(() => new { arg1 }.Must().NotBeDefault<string>().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).Must().NotBeDefault<string>().OrThrow());
        }

        [Test]
        public void NotBeDefault_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = default(string);

            Action action1 = () => new { arg1 }.Must().NotBeDefault<string>().OrThrow();
            Action action2 = () => arg1.Named("First arg").Must().NotBeDefault<string>().OrThrow();

            action1.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("First arg");
        }

        [Test]
        public void NotBeDefault_does_not_throw_when_arguments_are_not_null_or_default()
        {
            var arg1 = Guid.NewGuid();

            new { arg1 }.Must().NotBeDefault<Guid>().OrThrow();
            arg1.Named(nameof(arg1)).Must().NotBeDefault<Guid>().OrThrow();
        }

        [Test]
        public void NotBeEmptyEnumerable_throws_when_an_argument_is_null()
        {
            var arg1 = null as IEnumerable<int>;
            
            Assert.Throws<ArgumentException>(() => new { arg1 }.Must().NotBeEmptyEnumerable<int>().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).Must().NotBeEmptyEnumerable<int>().OrThrow());
        }

        [Test]
        public void NotBeEmptyEnumerable_throws_when_an_argument_is_empty()
        {
            var arg1 = new List<string>();

            Assert.Throws<ArgumentException>(() => new { arg1 }.Must().NotBeEmptyEnumerable<string>().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).Must().NotBeEmptyEnumerable<string>().OrThrow());
        }

        [Test]
        public void NotBeEmptyEnumerable_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = null as IEnumerable<object>;
            var arg2 = new double[0];

            Action action1 = () => new { arg1 }.Must().NotBeEmptyEnumerable<object>().OrThrow();
            Action action2 = () => arg2.Named(nameof(arg2)).Must().NotBeEmptyEnumerable<double>().OrThrow();

            action1.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg2");
        }

        [Test]
        public void NotBeEmptyEnumerable_does_not_throw_when_arguments_are_not_null_or_empty()
        {
            var arg1 = new [] { "test 1", "test 2" };
            var arg2 = new[] { 500123, -1243 };

            new { arg1 }.Must().NotBeEmptyEnumerable<string>().OrThrow();
            arg2.Named(nameof(arg2)).Must().NotBeEmptyEnumerable<int>().OrThrow();
        }

        [Test]
        public void NotContainAnyNulls_throws_when_an_argument_is_null()
        {
            var arg1 = null as IEnumerable<int?>;

            Assert.Throws<ArgumentException>(() => new { arg1 }.Must().NotContainAnyNulls<int?>().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).Must().NotContainAnyNulls<int?>().OrThrow());
        }

        [Test]
        public void NotContainAnyNulls_throws_when_an_argument_contains_null()
        {
            var arg1 = new List<string> { "Test1", "Test2", null, "Test3" };

            Assert.Throws<ArgumentException>(() => new { arg1 }.Must().NotContainAnyNulls<string>().OrThrow());
            Assert.Throws<ArgumentException>(() => arg1.Named(nameof(arg1)).Must().NotContainAnyNulls<string>().OrThrow());
        }

        [Test]
        public void NotContainAnyNulls_thrown_message_contains_name_of_problem_argument()
        {
            var arg1 = new List<string> { "Test1", "Test2", null, "Test3" };

            Action action1 = () => new { arg1 }.Must().NotContainAnyNulls<string>().OrThrow();
            Action action2 = () => arg1.Named(nameof(arg1)).Must().NotContainAnyNulls<string>().OrThrow();

            action1.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
            action2.ShouldThrow<ArgumentException>().And.Message.Should().Contain("arg1");
        }

        [Test]
        public void NotContainAnyNulls_does_not_throw_when_arguments_are_not_null_or_contain_any_null_items()
        {
            var arg1 = new[] { "test 1", "test 2" };
            var arg2 = new[] { 500123, -1243 };
            
            new { arg1 }.Must().NotContainAnyNulls<string>().OrThrow();
            arg2.Named(nameof(arg2)).Must().NotContainAnyNulls<int>().OrThrow();
        }

        [Test]
        public void BeInRange_throws_if_minimum_or_maximum_are_null()
        {
            Action action1 = () => new { validArg = "Test" }.Must().BeInRange(null, "Z").OrThrow();
            Action action2 = () => new { validArg = "Test" }.Must().BeInRange("A", null).OrThrow();
            
            action1.ShouldThrow<ArgumentNullException>().And.Message.Should().Contain("minimum");
            action2.ShouldThrow<ArgumentNullException>().And.Message.Should().Contain("maximum");
        }

        [Test]
        public void BeInRange_throws_if_value_is_less_than_minimum()
        {
            var tooLowArg = 19;
            Action action1 = () => new { tooLowArg }.Must().BeInRange(20, int.MaxValue).OrThrow();
            Action action2 = () => tooLowArg.Named(nameof(tooLowArg)).Must().BeInRange(50, 100).OrThrow();

            action1.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooLowArg")
                .And.Contain("20");
            
            action2.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooLowArg")
                .And.Contain("50");
        }

        [Test]
        public void BeInRange_throws_if_value_is_greater_than_maximum()
        {
            var tooHighArg = -4;
            Action action1 = () => new { tooHighArg }.Must().BeInRange(int.MinValue, -5).OrThrow();
            Action action2 = () => tooHighArg.Named(nameof(tooHighArg)).Must().BeInRange(int.MinValue, -50).OrThrow();

            action1.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooHighArg")
                .And.Contain("-5");

            action2.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooHighArg")
                .And.Contain("-50");
        }

        [Test]
        public void BeInRange_does_not_throw_when_value_is_in_range()
        {
            var arg1 = 0;

            new { arg1 }.Must().BeInRange(0, 20).OrThrow();
            arg1.Named(nameof(arg1)).Must().BeInRange(-100, 0).OrThrow();
        }

        [Test]
        public void BeLessThan_throws_if_requirement_is_null()
        {
            Action act = () => new { validArg = "Test" }.Must().BeLessThan(null as string).OrThrow();
            
            act.ShouldThrow<ArgumentNullException>().And.Message.Should().Contain("requirement");
        }

        [Test]
        public void BeLessThan_throws_if_value_is_not_less_than_requirement()
        {
            var tooHighArg = 19;
            Action action1 = () => new { tooHighArg }.Must().BeLessThan(19).OrThrow();
            Action action2 = () => tooHighArg.Named(nameof(tooHighArg)).Must().BeLessThan(18).OrThrow();

            action1.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooHighArg")
                .And.Contain("19");

            action2.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooHighArg")
                .And.Contain("18");
        }

        [Test]
        public void BeLessThan_does_not_throw_when_value_is_less_than_requirement()
        {
            var arg1 = 0;

            new { arg1 }.Must().BeLessThan(20).OrThrow();
            arg1.Named(nameof(arg1)).Must().BeLessThan(1).OrThrow();
        }

        [Test]
        public void BeLessThanOrEqualTo_throws_if_requirement_is_null()
        {
            Action act = () => new { validArg = "Test" }.Must().BeLessThanOrEqualTo(null as string).OrThrow();

            act.ShouldThrow<ArgumentNullException>().And.Message.Should().Contain("requirement");
        }

        [Test]
        public void BeLessThanOrEqualTo_throws_if_value_is_not_less_than_or_equal_to_requirement()
        {
            var tooHighArg = 19;
            Action action1 = () => new { tooHighArg }.Must().BeLessThanOrEqualTo(18).OrThrow();
            Action action2 = () => tooHighArg.Named(nameof(tooHighArg)).Must().BeLessThanOrEqualTo(0).OrThrow();

            action1.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooHighArg")
                .And.Contain("18");

            action2.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooHighArg")
                .And.Contain("0");
        }

        [Test]
        public void BeLessThanOrEqualTo_does_not_throw_when_value_is_less_than_or_equal_to_requirement()
        {
            var arg1 = 0;

            new { arg1 }.Must().BeLessThanOrEqualTo(1).OrThrow();
            arg1.Named(nameof(arg1)).Must().BeLessThanOrEqualTo(0).OrThrow();
        }

        [Test]
        public void NotBeEqualTo_throws_if_requirement_is_null()
        {
            Action act = () => new { validArg = "Test" }.Must().NotBeEqualTo(null as string).OrThrow();

            act.ShouldThrow<ArgumentNullException>().And.Message.Should().Contain("requirement");
        }

        [Test]
        public void NotBeEqualTo_throws_if_value_is_equal_to_requirement()
        {
            Action action1 = () => new { arg = "hello" }.Must().NotBeEqualTo("hello").OrThrow();
            Action action2 = () => "world".Named("arg").Must().NotBeEqualTo("world").OrThrow();

            action1.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("arg")
                .And.Contain("hello");

            action2.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("arg")
                .And.Contain("world");
        }

        [Test]
        public void NotBeEqualTo_does_not_throw_when_value_is_not_equal_to_requirement()
        {
            var arg1 = 10;

            new { arg1 }.Must().NotBeEqualTo(12).OrThrow();
            arg1.Named(nameof(arg1)).Must().NotBeEqualTo(-1).OrThrow();
        }

        [Test]
        public void BeEqualTo_throws_if_requirement_is_null()
        {
            Action act = () => new { validArg = "Test" }.Must().BeEqualTo(null as string).OrThrow();

            act.ShouldThrow<ArgumentNullException>().And.Message.Should().Contain("requirement");
        }

        [Test]
        public void BeEqualTo_throws_if_value_is_not_equal_to_requirement()
        {
            Action action1 = () => new { tooLowArg = 6.0 }.Must().BeEqualTo(6.1).OrThrow();
            Action action2 = () => 6.2.Named("tooHighArg").Must().BeEqualTo(6.1).OrThrow();

            action1.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooLowArg")
                .And.Contain("6.1");

            action2.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooHighArg")
                .And.Contain("6.1");
        }

        [Test]
        public void BeEqualTo_does_not_throw_when_value_is_equal_to_requirement()
        {
            var arg1 = "Test";

            new { arg1 }.Must().BeEqualTo("Test").OrThrow();
            arg1.Named(nameof(arg1)).Must().BeEqualTo("Test").OrThrow();
        }

        [Test]
        public void BeGreaterThan_throws_if_requirement_is_null()
        {
            Action act = () => new { validArg = "Test" }.Must().BeGreaterThan(null as string).OrThrow();

            act.ShouldThrow<ArgumentNullException>().And.Message.Should().Contain("requirement");
        }

        [Test]
        public void BeGreaterThan_throws_if_value_is_not_greater_than_requirement()
        {
            var tooLowArg = 19.5;
            Action action1 = () => new { tooLowArg }.Must().BeGreaterThan(19.5).OrThrow();
            Action action2 = () => tooLowArg.Named(nameof(tooLowArg)).Must().BeGreaterThan(20.1).OrThrow();

            action1.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooLowArg")
                .And.Contain("19.5");

            action2.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooLowArg")
                .And.Contain("20.1");
        }

        [Test]
        public void BeGreaterThan_does_not_throw_when_value_is_greater_than_requirement()
        {
            var arg1 = 0.2;

            new { arg1 }.Must().BeGreaterThan(0.0).OrThrow();
            arg1.Named(nameof(arg1)).Must().BeGreaterThan(0.19).OrThrow();
        }

        [Test]
        public void BeGreaterThanOrEqualTo_throws_if_requirement_is_null()
        {
            Action act = () => new { validArg = "Test" }.Must().BeGreaterThanOrEqualTo(null as string).OrThrow();

            act.ShouldThrow<ArgumentNullException>().And.Message.Should().Contain("requirement");
        }

        [Test]
        public void BeGreaterThanOrEqualTo_throws_if_value_is_not_greater_than_or_equal_to_requirement()
        {
            var tooLowArg = 5.6;
            Action action1 = () => new { tooLowArg }.Must().BeGreaterThanOrEqualTo(5.9).OrThrow();
            Action action2 = () => tooLowArg.Named(nameof(tooLowArg)).Must().BeGreaterThanOrEqualTo(5.61).OrThrow();

            action1.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooLowArg")
                .And.Contain("5.9");

            action2.ShouldThrow<ArgumentOutOfRangeException>()
                .And.Message.Should().Contain("tooLowArg")
                .And.Contain("5.61");
        }

        [Test]
        public void BeGreaterThanOrEqualTo_does_not_throw_when_value_is_greater_than_or_equal_to_requirement()
        {
            var arg1 = 0.5;

            new { arg1 }.Must().BeGreaterThanOrEqualTo(-1.0).OrThrow();
            arg1.Named(nameof(arg1)).Must().BeGreaterThanOrEqualTo(0.5).OrThrow();
        }

        private enum TestEnum
        {
            First = 1,
            Second = 2
        }
    }
}

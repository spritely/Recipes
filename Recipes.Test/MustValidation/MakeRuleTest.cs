﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MakeRuleTest.cs">
//   Copyright (c) 2017. All rights reserved.
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
    public class MakeRuleTest
    {
        [Test]
        public void That_throws_on_null_arguments()
        {
            Assert.Throws<ArgumentNullException>(() => MakeRule.That(null as Func<object, bool>));
            Assert.Throws<ArgumentNullException>(() => MakeRule.That(null as Func<bool>));
        }

        [Test]
        public void That_produces_function_which_calls_original_predicate_argument()
        {
            var overload1Times = 0;
            var overload2Times = 0;
            var expectedOverload1Argument = new object();
            object actualOverload1Argument = null;

            var overload1Rule = MakeRule.That<object>(
                v =>
                {
                    actualOverload1Argument = v;
                    overload1Times++;
                    return false;
                });

            var overload2Rule = MakeRule.That(
                () =>
                {
                    overload2Times++;
                    return true;
                });

            var overload1Result = overload1Rule(expectedOverload1Argument);
            overload2Rule(null);
            overload2Rule(null);
            var overload2Result = overload2Rule(null);

            overload1Times.Should().Be(1);
            overload2Times.Should().Be(3);
            actualOverload1Argument.Should().BeSameAs(expectedOverload1Argument);
            overload1Result.Should().BeFalse();
            overload2Result.Should().BeTrue();
        }

        [Test]
        public void OrCreate_throws_on_null_this_argument()
        {
            Assert.Throws<ArgumentNullException>(() =>
                (null as Func<object, bool>).OrCreate((argumentType, messages, argumentValue, argumentName) => new Exception()));
            Assert.Throws<ArgumentNullException>(() =>
                (null as Func<object, bool>).OrCreate((messages, argumentValue, argumentName) => new Exception()));
            Assert.Throws<ArgumentNullException>(() =>
                (null as Func<object, bool>).OrCreate((argumentValue, argumentName) => new Exception()));
            Assert.Throws<ArgumentNullException>(() =>
                (null as Func<object, bool>).OrCreate(argumentName => new Exception()));
            Assert.Throws<ArgumentNullException>(() =>
                (null as Func<object, bool>).OrCreate(() => new Exception()));
            Assert.Throws<ArgumentNullException>(() =>
                (null as Func<object, bool>).OrCreate(new Exception()));
        }

        [Test]
        public void OrCreate_throws_on_null_exception_argument()
        {
            var alwaysPass = MakeRule.That(() => true);

            Assert.Throws<ArgumentNullException>(() =>
                alwaysPass.OrCreate(null as Func<Type, IEnumerable<string>, object, string, Exception>));
            Assert.Throws<ArgumentNullException>(() =>
                alwaysPass.OrCreate(null as Func<IEnumerable<string>, object, string, Exception>));
            Assert.Throws<ArgumentNullException>(() =>
                alwaysPass.OrCreate(null as Func<object, string, Exception>));
            Assert.Throws<ArgumentNullException>(() =>
                alwaysPass.OrCreate(null as Func<string, Exception>));
            Assert.Throws<ArgumentNullException>(() =>
                alwaysPass.OrCreate(null as Func<Exception>));
            Assert.Throws<ArgumentNullException>(() =>
                alwaysPass.OrCreate(null as Exception));
        }

        [Test]
        public void OrCreateArgumentNullException_throws_on_null_arguments()
        {
            Assert.Throws<ArgumentNullException>(
                () => (null as Func<object, bool>).OrCreateArgumentNullException());
        }

        [Test]
        public void OrCreateArgumentException_throws_on_null_arguments()
        {
            Assert.Throws<ArgumentNullException>(
                () => (null as Func<object, bool>).OrCreateArgumentException());
        }

        [Test]
        public void OrCreateArgumentOutOfRangeException_throws_on_null_arguments()
        {
            Assert.Throws<ArgumentNullException>(
                () => (null as Func<object, bool>).OrCreateArgumentOutOfRangeException());
        }

        [Test]
        public void OrCreate_makes_rule_that_calls_original_rule_when_type_matches()
        {
            int? actualArgument = null;
            int? expectedArgument = 5;
            var times = 0;
            var rule = MakeRule.That<int?>(
                v =>
                {
                    actualArgument = v;
                    times++;
                    return true;
                }).OrCreate(new Exception("Test should not create this exception."));

            rule.Item1(typeof(int?), expectedArgument);
            times.Should().Be(1);
            actualArgument.Should().Be(expectedArgument);
        }

        [Test]
        public void OrCreate_makes_rule_that_does_not_call_original_rule_when_type_does_not_match()
        {
            var actualArgument = 0.0;
            var expectedArgument = 5;
            var times = 0;
            var rule = MakeRule.That<double>(
                v =>
                {
                    actualArgument = v;
                    times++;
                    return true;
                }).OrCreate(new Exception("Test should not create this exception."));

            rule.Item1(typeof(int), expectedArgument);
            times.Should().Be(0);
            actualArgument.Should().Be(0.0);
        }

        [Test]
        public void OrCreate1_makes_rule_that_calls_original_exception()
        {
            var alwaysTrue = MakeRule.That(() => true);
            Type actualType = null;
            IEnumerable<string> actualMessages = null;
            object actualValue = null;
            string actualName = null;
            var expectedException = new Exception();
            var expectedMessages = new List<string> { "Test 1", "Test 2" };

            var rule = alwaysTrue.OrCreate(
                (argumentType, messages, argumentValue, argumentName) =>
                {
                    actualType = argumentType;
                    actualMessages = messages;
                    actualValue = argumentValue;
                    actualName = argumentName;

                    return expectedException;
                });

            var actualException = rule.Item3(typeof(int), expectedMessages, 5, "arg");

            actualType.Should().Be(typeof(int));
            actualMessages.Should().ContainInOrder(expectedMessages);
            actualValue.Should().Be(5);
            actualName.Should().Be("arg");
            actualException.Should().Be(expectedException);
            actualException.InnerException.Should().BeNull();
        }

        [Test]
        public void OrCreate2_makes_rule_that_calls_original_exception()
        {
            var alwaysTrue = MakeRule.That(() => true);
            IEnumerable<string> actualMessages = null;
            object actualValue = null;
            string actualName = null;
            var expectedException = new Exception();
            var expectedMessages = new List<string> { "Test 1", "Test 2", "Test 3" };

            var rule = alwaysTrue.OrCreate(
                (messages, argumentValue, argumentName) =>
                {
                    actualMessages = messages;
                    actualValue = argumentValue;
                    actualName = argumentName;

                    return expectedException;
                });

            var actualException = rule.Item3(typeof(double), expectedMessages, 15.0, "argument");

            actualMessages.Should().ContainInOrder(expectedMessages);
            actualValue.Should().Be(15.0);
            actualName.Should().Be("argument");
            actualException.Should().Be(expectedException);
            actualException.InnerException.Should().BeNull();
        }

        [Test]
        public void OrCreate3_makes_rule_that_calls_original_exception()
        {
            var alwaysTrue = MakeRule.That(() => true);
            object actualValue = null;
            string actualName = null;
            var expectedException = new Exception();
            var expectedMessages = new List<string> { "Test 1" };

            var rule = alwaysTrue.OrCreate(
                (argumentValue, argumentName) =>
                {
                    actualValue = argumentValue;
                    actualName = argumentName;

                    return expectedException;
                });

            var actualException = rule.Item3(typeof(string), expectedMessages, "test", "testArgument");

            actualValue.Should().Be("test");
            actualName.Should().Be("testArgument");
            actualException.Should().Be(expectedException);
            actualException.InnerException.Should().NotBeNull();
            actualException.InnerException.Should().BeOfType<ArgumentException>();
            actualException.InnerException.Message.Should().Contain(expectedMessages.First());
            (actualException.InnerException as ArgumentException).ParamName.Should().Be("testArgument");
        }

        [Test]
        public void OrCreate4_makes_rule_that_calls_original_exception()
        {
            var alwaysTrue = MakeRule.That(() => true);
            string actualName = null;
            var expectedException = new Exception();
            var expectedMessages = new List<string> { "First Test", "Second Test" };

            var rule = alwaysTrue.OrCreate(
                argumentName =>
                {
                    actualName = argumentName;

                    return expectedException;
                });

            var actualException = rule.Item3(typeof(long), expectedMessages, -15, "arg");

            actualName.Should().Be("arg");
            actualException.Should().Be(expectedException);
            actualException.InnerException.Should().NotBeNull();
            actualException.InnerException.Should().BeOfType<ArgumentException>();
            actualException.InnerException.Message.Should().Contain(expectedMessages.First());
            actualException.InnerException.Message.Should().Contain(expectedMessages.Skip(1).First());
            (actualException.InnerException as ArgumentException).ParamName.Should().Be("arg");
        }

        [Test]
        public void OrCreate5_makes_rule_that_calls_original_exception()
        {
            var alwaysTrue = MakeRule.That(() => true);
            var expectedException = new Exception();
            var expectedMessages = new List<string> { "First Test", "Second Test", "Third Test" };

            var rule = alwaysTrue.OrCreate(() => expectedException);

            var actualException = rule.Item3(typeof(int), expectedMessages, 0, "arg");

            actualException.Should().Be(expectedException);
            actualException.InnerException.Should().NotBeNull();
            actualException.InnerException.Should().BeOfType<ArgumentException>();
            actualException.InnerException.Message.Should().Contain(expectedMessages.First());
            actualException.InnerException.Message.Should().Contain(expectedMessages.Skip(1).First());
            actualException.InnerException.Message.Should().Contain(expectedMessages.Skip(2).First());
            (actualException.InnerException as ArgumentException).ParamName.Should().Be("arg");
        }

        [Test]
        public void OrCreate6_makes_rule_that_calls_original_exception()
        {
            var alwaysTrue = MakeRule.That(() => true);
            var expectedException = new Exception();
            var expectedMessages = new List<string>();

            var rule = alwaysTrue.OrCreate(expectedException);

            var actualException = rule.Item3(typeof(object), expectedMessages, null, "value");

            actualException.Should().Be(expectedException);
            actualException.InnerException.Should().BeNull();
        }

        [Test]
        public void OrCreateArgumentException_creates_expected_exception()
        {
            var alwaysTrue = MakeRule.That(() => true).OrCreateArgumentException();

            var actualException = alwaysTrue.Item3(typeof(object), new List<string> { "Test 1", "Test 2"}, null, "value");

            actualException.Should().BeOfType<ArgumentException>();
            (actualException as ArgumentException).ParamName.Should().Be("value");
            actualException.InnerException.Should().BeNull();
            actualException.Message.Should().Contain("Test 1");
            actualException.Message.Should().Contain("Test 2");
        }

        [Test]
        public void OrCreateArgumentNullException_creates_expected_exception()
        {
            var alwaysTrue = MakeRule.That(() => true).OrCreateArgumentNullException();

            var actualException = alwaysTrue.Item3(typeof(object), new List<string> { "First Test", "Second Test", "Third Test" }, new object(), "argument");

            actualException.Should().BeOfType<ArgumentNullException>();
            (actualException as ArgumentNullException).ParamName.Should().Be("argument");
            actualException.InnerException.Should().BeNull();
            actualException.Message.Should().Contain("First Test");
            actualException.Message.Should().Contain("Second Test");
            actualException.Message.Should().Contain("Third Test");
        }

        [Test]
        public void OrCreateArgumentOutOfRangeException_creates_expected_exception()
        {
            var alwaysTrue = MakeRule.That(() => true).OrCreateArgumentOutOfRangeException();

            var actualException = alwaysTrue.Item3(typeof(int), new List<string> { "The reason" }, 50, "test");

            actualException.Should().BeOfType<ArgumentOutOfRangeException>();
            var argumentOutOfRangeException = actualException as ArgumentOutOfRangeException;
            argumentOutOfRangeException.ActualValue.Should().Be(50);
            argumentOutOfRangeException.ParamName.Should().Be("test");
            actualException.InnerException.Should().BeNull();
            actualException.Message.Should().Contain("The reason");
        }

        [Test]
        public void Because_with_null_or_empty_message_throws()
        {
            var alwaysTrue = MakeRule.That(() => true).OrCreateArgumentException();

            Assert.Throws<ArgumentNullException>(() => alwaysTrue.Because(null));
            Assert.Throws<ArgumentException>(() => alwaysTrue.Because(" \t  "));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "This test is testing the argument exception explicitly.")]
        [Test]
        public void Because_uncalled_does_not_create_any_rule_messages()
        {
            var alwaysTrue = MakeRule.That(() => true).OrCreateArgumentException();

            var actualException = alwaysTrue.Item3(typeof(string), new List<string>(), "", "value");

            var builtInException = new ArgumentException(message: "", paramName: "value");
            alwaysTrue.Item2.Should().BeEmpty();
            actualException.Message.Should().Be(builtInException.Message);
        }

        [Test]
        public void Because_adds_message_to_rule_and_exception()
        {
            var alwaysTrue = MakeRule.That(() => true).OrCreateArgumentException()
                .Because("Because_adds_message_to_rule_and_exception-1")
                .Because("Because_adds_message_to_rule_and_exception-2");

            var actualException = alwaysTrue.Item3(typeof(string), alwaysTrue.Item2, "", "value");

            alwaysTrue.Item2.Should()
                .ContainInOrder(
                    "Because_adds_message_to_rule_and_exception-1",
                    "Because_adds_message_to_rule_and_exception-2");

            actualException.Message.Should().Contain("Because_adds_message_to_rule_and_exception-1");
            actualException.Message.Should().Contain("Because_adds_message_to_rule_and_exception-2");
        }
    }
}

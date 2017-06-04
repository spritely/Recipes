﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParsingExtensionsTest.cs">
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
    using System.Globalization;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class ParsingExtensionsTest
    {
        [Test]
        public void ToBoolean_produces_expected_result()
        {
            "true".ToBoolean().Should().BeTrue();
            "false".ToBoolean(defaultValue: _ => true).Should().BeFalse();
        }

        [Test]
        public void ToBoolean_uses_default_value_for_non_parsable_values()
        {
            "not parsable".ToBoolean(defaultValue: true).Should().BeTrue();
            "different overload".ToBoolean(defaultValue: _ => true).Should().BeTrue();
        }

        [Test]
        public void ToBoolean_uses_default_defaults_for_non_parsable_values()
        {
            "yet another".ToBoolean().Should().BeFalse();
        }

        [Test]
        public void ToBoolean_with_null_functional_defaultValue_throws()
        {
            Action act = () => "true".ToBoolean(null);
            act.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToBoolean_passes_non_parsable_value_to_continuation()
        {
            var actual = string.Empty;
            "test this".ToBoolean(defaultValue: s =>
            {
                actual = s;
                return true;
            });

            actual.Should().Be("test this");
        }

        [Test]
        public void ToByte_produces_expected_result()
        {
            "24".ToByte().Should().Be(24);
            "255".ToByte(defaultValue: _ => 5).Should().Be(255);
            " 0 ".ToByte(
                NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
                CultureInfo.InvariantCulture,
                defaultValue: 5)
                .Should().Be(0);
            "100.0".ToByte(
                NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                defaultValue: _ => 1)
                .Should().Be(100);
        }

        [Test]
        public void ToByte_uses_default_value_for_non_parsable_values()
        {
            "not parsable".ToByte(defaultValue: 18).Should().Be(18);
            "different overload".ToByte(defaultValue: _ => 55).Should().Be(55);
            "another invalid".ToByte(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: 255).Should().Be(255);
            "and another".ToByte(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: _ => 1).Should().Be(1);
        }

        [Test]
        public void ToByte_uses_default_defaults_for_non_parsable_values()
        {
            "yet another".ToByte().Should().Be(default(byte));
            "non_parsable".ToByte(NumberStyles.Any, CultureInfo.InvariantCulture).Should().Be(0);
        }

        [Test]
        public void ToByte_with_null_functional_defaultValue_throws()
        {
            Action act1 = () => "12".ToByte(null);
            Action act2 = () => "13".ToByte(NumberStyles.Any, CultureInfo.InvariantCulture, null);

            act1.ShouldThrow<ArgumentNullException>();
            act2.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToByte_passes_non_parsable_value_to_continuation()
        {
            var actual1 = string.Empty;
            var actual2 = string.Empty;
            "test this".ToByte(s =>
            {
                actual1 = s;
                return 0;
            });
            "and this".ToByte(s =>
            {
                actual2 = s;
                return 0;
            });

            actual1.Should().Be("test this");
            actual2.Should().Be("and this");
        }

        [Test]
        public void ToChar_produces_expected_result()
        {
            "f".ToChar().Should().Be('f');
            "g".ToChar(defaultValue: _ => '0').Should().Be('g');
        }

        [Test]
        public void ToChar_uses_default_value_for_non_parsable_values()
        {
            "too long".ToChar(defaultValue: 'a').Should().Be('a');
            "".ToChar(defaultValue: _ => 'b').Should().Be('b');
        }

        [Test]
        public void ToChar_uses_default_defaults_for_non_parsable_values()
        {
            "non_parsable".ToChar().Should().Be(default(char));
        }

        [Test]
        public void ToChar_with_null_functional_defaultValue_throws()
        {
            Action act = () => "1".ToChar(null);

            act.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToChar_passes_non_parsable_value_to_continuation()
        {
            var actual = string.Empty;
            "wee".ToChar(s =>
            {
                actual = s;
                return '0';
            });

            actual.Should().Be("wee");
        }

        [Test]
        public void ToDateTime_produces_expected_result()
        {
            var expected = DateTime.UtcNow;
            var source = expected.ToString(CultureInfo.InvariantCulture);
            source.ToDateTime().Should().BeCloseTo(expected, precision: 1000);
            source.ToDateTime(defaultValue: _ => DateTime.Now.AddDays(2)).Should().BeCloseTo(expected, precision: 1000);
            (" " + source + "  ").ToDateTime(
                DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite,
                CultureInfo.InvariantCulture,
                defaultValue: DateTime.Now.AddDays(3))
                .Should().BeCloseTo(expected, precision: 1000);
            (" " + source + "  ").ToDateTime(
                DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite,
                CultureInfo.InvariantCulture,
                defaultValue: _ => DateTime.Now.AddDays(4))
                .Should().BeCloseTo(expected, precision: 1000);
        }

        [Test]
        public void ToDateTime_uses_default_value_for_non_parsable_values()
        {
            var expected = DateTime.UtcNow;
            "not parsable".ToDateTime(defaultValue: expected).Should().Be(expected);
            "different overload".ToDateTime(defaultValue: _ => expected).Should().Be(expected);
            "another invalid".ToDateTime(DateTimeStyles.None, CultureInfo.InvariantCulture, defaultValue: expected).Should().Be(expected);
            "and another".ToDateTime(DateTimeStyles.None, CultureInfo.InvariantCulture, defaultValue: _ => expected).Should().Be(expected);
        }

        [Test]
        public void ToDateTime_uses_default_defaults_for_non_parsable_values()
        {
            "yet another".ToDateTime().Should().Be(default(DateTime));
            "non_parsable".ToDateTime(DateTimeStyles.None, CultureInfo.InvariantCulture).Should().Be(default(DateTime));
        }

        [Test]
        public void ToDateTime_with_null_functional_defaultValue_throws()
        {
            var valid = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
            Action act1 = () => valid.ToDateTime(null);
            Action act2 = () => valid.ToDateTime(DateTimeStyles.None, CultureInfo.InvariantCulture, null);

            act1.ShouldThrow<ArgumentNullException>();
            act2.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDateTime_passes_non_parsable_value_to_continuation()
        {
            var actual1 = string.Empty;
            var actual2 = string.Empty;
            "test this".ToDateTime(s =>
            {
                actual1 = s;
                return DateTime.Now;
            });
            "and this".ToDateTime(s =>
            {
                actual2 = s;
                return DateTime.Now;
            });

            actual1.Should().Be("test this");
            actual2.Should().Be("and this");
        }

        [Test]
        public void ToDecimal_produces_expected_result()
        {
            "24.1".ToDecimal().Should().Be(24.1m);
            "-15.7".ToDecimal(defaultValue: _ => 5.0m).Should().Be(-15.7m);
            " 0 ".ToDecimal(
                NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
                CultureInfo.InvariantCulture,
                defaultValue: 5.0m)
                .Should().Be(0m);
            "(100.0)".ToDecimal(
                NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                defaultValue: _ => 1.0m)
                .Should().Be(-100.0m);
        }

        [Test]
        public void ToDecimal_uses_default_value_for_non_parsable_values()
        {
            "not parsable".ToDecimal(defaultValue: 18.5m).Should().Be(18.5m);
            "different overload".ToDecimal(defaultValue: _ => -500m).Should().Be(-500m);
            "another invalid".ToDecimal(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: 458.400m).Should().Be(458.400m);
            "and another".ToDecimal(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: _ => 1.00000m).Should().Be(1.00000m);
        }

        [Test]
        public void ToDecimal_uses_default_defaults_for_non_parsable_values()
        {
            "yet another".ToDecimal().Should().Be(default(decimal));
            "non_parsable".ToDecimal(NumberStyles.Any, CultureInfo.InvariantCulture).Should().Be(0m);
        }

        [Test]
        public void ToDecimal_with_null_functional_defaultValue_throws()
        {
            Action act1 = () => "1.2".ToDecimal(null);
            Action act2 = () => "1.3".ToDecimal(NumberStyles.Any, CultureInfo.InvariantCulture, null);

            act1.ShouldThrow<ArgumentNullException>();
            act2.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDecimal_passes_non_parsable_value_to_continuation()
        {
            var actual1 = string.Empty;
            var actual2 = string.Empty;
            "can't parse me".ToDecimal(s =>
            {
                actual1 = s;
                return 0;
            });
            "or me".ToDecimal(s =>
            {
                actual2 = s;
                return 0;
            });

            actual1.Should().Be("can't parse me");
            actual2.Should().Be("or me");
        }

        [Test]
        public void ToDouble_produces_expected_result()
        {
            "24.1".ToDouble().Should().Be(24.1);
            "-15.7".ToDouble(defaultValue: _ => 5.0).Should().Be(-15.7);
            " 0 ".ToDouble(
                NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
                CultureInfo.InvariantCulture,
                defaultValue: 5.0)
                .Should().Be(0);
            "(100.0)".ToDouble(
                NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                defaultValue: _ => 1.0)
                .Should().Be(-100.0);
        }

        [Test]
        public void ToDouble_uses_default_value_for_non_parsable_values()
        {
            "not parsable".ToDouble(defaultValue: 18.5).Should().Be(18.5);
            "different overload".ToDouble(defaultValue: _ => -500).Should().Be(-500);
            "another invalid".ToDouble(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: 458.4).Should().Be(458.4);
            "and another".ToDouble(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: _ => 1.0).Should().Be(1.0);
        }

        [Test]
        public void ToDouble_uses_default_defaults_for_non_parsable_values()
        {
            "yet another".ToDouble().Should().Be(default(double));
            "non_parsable".ToDouble(NumberStyles.Any, CultureInfo.InvariantCulture).Should().Be(0.0);
        }

        [Test]
        public void ToDouble_with_null_functional_defaultValue_throws()
        {
            Action act1 = () => "1.2".ToDouble(null);
            Action act2 = () => "1.3".ToDouble(NumberStyles.Any, CultureInfo.InvariantCulture, null);

            act1.ShouldThrow<ArgumentNullException>();
            act2.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToDouble_passes_non_parsable_value_to_continuation()
        {
            var actual1 = string.Empty;
            var actual2 = string.Empty;
            "can't parse me".ToDouble(s =>
            {
                actual1 = s;
                return 0;
            });
            "or me".ToDouble(s =>
            {
                actual2 = s;
                return 0;
            });

            actual1.Should().Be("can't parse me");
            actual2.Should().Be("or me");
        }

        [Test]
        public void ToInt16_produces_expected_result()
        {
            "24".ToInt16().Should().Be(24);
            "-255".ToInt16(defaultValue: _ => 5).Should().Be(-255);
            " 0 ".ToInt16(
                NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
                CultureInfo.InvariantCulture,
                defaultValue: 5)
                .Should().Be(0);
            "-100.0".ToInt16(
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture,
                defaultValue: _ => -1)
                .Should().Be(-100);
        }

        [Test]
        public void ToInt16_uses_default_value_for_non_parsable_values()
        {
            "not parsable".ToInt16(defaultValue: 18).Should().Be(18);
            "different overload".ToInt16(defaultValue: _ => -55).Should().Be(-55);
            "another invalid".ToInt16(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: 255).Should().Be(255);
            "and another".ToInt16(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: _ => -1).Should().Be(-1);
        }

        [Test]
        public void ToInt16_uses_default_defaults_for_non_parsable_values()
        {
            "yet another".ToInt16().Should().Be(default(short));
            "non_parsable".ToInt16(NumberStyles.Any, CultureInfo.InvariantCulture).Should().Be(0);
        }

        [Test]
        public void ToInt16_with_null_functional_defaultValue_throws()
        {
            Action act1 = () => "12".ToInt16(null);
            Action act2 = () => "13".ToInt16(NumberStyles.Any, CultureInfo.InvariantCulture, null);

            act1.ShouldThrow<ArgumentNullException>();
            act2.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToInt16_passes_non_parsable_value_to_continuation()
        {
            var actual1 = string.Empty;
            var actual2 = string.Empty;
            "test this".ToInt16(s =>
            {
                actual1 = s;
                return 0;
            });
            "and this".ToInt16(s =>
            {
                actual2 = s;
                return 0;
            });

            actual1.Should().Be("test this");
            actual2.Should().Be("and this");
        }

        [Test]
        public void ToInt32_produces_expected_result()
        {
            "24".ToInt32().Should().Be(24);
            "-255".ToInt32(defaultValue: _ => 5).Should().Be(-255);
            " 0 ".ToInt32(
                NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
                CultureInfo.InvariantCulture,
                defaultValue: 5)
                .Should().Be(0);
            "-100.0".ToInt32(
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture,
                defaultValue: _ => -1)
                .Should().Be(-100);
        }

        [Test]
        public void ToInt32_uses_default_value_for_non_parsable_values()
        {
            "not parsable".ToInt32(defaultValue: 18).Should().Be(18);
            "different overload".ToInt32(defaultValue: _ => -55).Should().Be(-55);
            "another invalid".ToInt32(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: 255).Should().Be(255);
            "and another".ToInt32(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: _ => -1).Should().Be(-1);
        }

        [Test]
        public void ToInt32_uses_default_defaults_for_non_parsable_values()
        {
            "yet another".ToInt32().Should().Be(default(int));
            "non_parsable".ToInt32(NumberStyles.Any, CultureInfo.InvariantCulture).Should().Be(0);
        }

        [Test]
        public void ToInt32_with_null_functional_defaultValue_throws()
        {
            Action act1 = () => "12".ToInt32(null);
            Action act2 = () => "13".ToInt32(NumberStyles.Any, CultureInfo.InvariantCulture, null);

            act1.ShouldThrow<ArgumentNullException>();
            act2.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToInt32_passes_non_parsable_value_to_continuation()
        {
            var actual1 = string.Empty;
            var actual2 = string.Empty;
            "test this".ToInt32(s =>
            {
                actual1 = s;
                return 0;
            });
            "and this".ToInt32(s =>
            {
                actual2 = s;
                return 0;
            });

            actual1.Should().Be("test this");
            actual2.Should().Be("and this");
        }

        [Test]
        public void ToInt64_produces_expected_result()
        {
            "24".ToInt64().Should().Be(24);
            "-255".ToInt64(defaultValue: _ => 5).Should().Be(-255);
            " 0 ".ToInt64(
                NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
                CultureInfo.InvariantCulture,
                defaultValue: 5)
                .Should().Be(0);
            "-100.0".ToInt64(
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture,
                defaultValue: _ => -1)
                .Should().Be(-100);
        }

        [Test]
        public void ToInt64_uses_default_value_for_non_parsable_values()
        {
            "not parsable".ToInt64(defaultValue: 18).Should().Be(18);
            "different overload".ToInt64(defaultValue: _ => -55).Should().Be(-55);
            "another invalid".ToInt64(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: 255).Should().Be(255);
            "and another".ToInt64(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: _ => -1).Should().Be(-1);
        }

        [Test]
        public void ToInt64_uses_default_defaults_for_non_parsable_values()
        {
            "yet another".ToInt64().Should().Be(default(long));
            "non_parsable".ToInt64(NumberStyles.Any, CultureInfo.InvariantCulture).Should().Be(0);
        }

        [Test]
        public void ToInt64_with_null_functional_defaultValue_throws()
        {
            Action act1 = () => "12".ToInt64(null);
            Action act2 = () => "13".ToInt64(NumberStyles.Any, CultureInfo.InvariantCulture, null);

            act1.ShouldThrow<ArgumentNullException>();
            act2.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToInt64_passes_non_parsable_value_to_continuation()
        {
            var actual1 = string.Empty;
            var actual2 = string.Empty;
            "test this".ToInt64(s =>
            {
                actual1 = s;
                return 0;
            });
            "and this".ToInt64(s =>
            {
                actual2 = s;
                return 0;
            });

            actual1.Should().Be("test this");
            actual2.Should().Be("and this");
        }

        [Test]
        public void ToSByte_produces_expected_result()
        {
            "127".ToSByte().Should().Be(127);
            "-127".ToSByte(defaultValue: _ => 5).Should().Be(-127);
            " 0 ".ToSByte(
                NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
                CultureInfo.InvariantCulture,
                defaultValue: 5)
                .Should().Be(0);
            "-100.0".ToSByte(
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture,
                defaultValue: _ => -1)
                .Should().Be(-100);
        }

        [Test]
        public void ToSByte_uses_default_value_for_non_parsable_values()
        {
            "not parsable".ToSByte(defaultValue: 127).Should().Be(127);
            "255".ToSByte(defaultValue: _ => -55).Should().Be(-55);
            "-5000".ToSByte(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: -127).Should().Be(-127);
            "and another".ToSByte(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: _ => -1).Should().Be(-1);
        }

        [Test]
        public void ToSByte_uses_default_defaults_for_non_parsable_values()
        {
            "yet another".ToSByte().Should().Be(default(sbyte));
            "non_parsable".ToSByte(NumberStyles.Any, CultureInfo.InvariantCulture).Should().Be(0);
        }

        [Test]
        public void ToSByte_with_null_functional_defaultValue_throws()
        {
            Action act1 = () => "12".ToSByte(null);
            Action act2 = () => "13".ToSByte(NumberStyles.Any, CultureInfo.InvariantCulture, null);

            act1.ShouldThrow<ArgumentNullException>();
            act2.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToSByte_passes_non_parsable_value_to_continuation()
        {
            var actual1 = string.Empty;
            var actual2 = string.Empty;
            "test this".ToSByte(s =>
            {
                actual1 = s;
                return 0;
            });
            "and this".ToSByte(s =>
            {
                actual2 = s;
                return 0;
            });

            actual1.Should().Be("test this");
            actual2.Should().Be("and this");
        }

        [Test]
        public void ToSingle_produces_expected_result()
        {
            "24.1".ToSingle().Should().Be(24.1f);
            "-15.7".ToSingle(defaultValue: _ => 5.0f).Should().Be(-15.7f);
            " 0 ".ToSingle(
                NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
                CultureInfo.InvariantCulture,
                defaultValue: 5.0f)
                .Should().Be(0f);
            "(100.0)".ToSingle(
                NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint,
                CultureInfo.InvariantCulture,
                defaultValue: _ => 1.0f)
                .Should().Be(-100.0f);
        }

        [Test]
        public void ToSingle_uses_default_value_for_non_parsable_values()
        {
            "not parsable".ToSingle(defaultValue: 18.5f).Should().Be(18.5f);
            "different overload".ToSingle(defaultValue: _ => -500f).Should().Be(-500f);
            "another invalid".ToSingle(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: 458.4f).Should().Be(458.4f);
            "and another".ToSingle(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: _ => 1.0f).Should().Be(1.0f);
        }

        [Test]
        public void ToSingle_uses_default_defaults_for_non_parsable_values()
        {
            "yet another".ToSingle().Should().Be(default(float));
            "non_parsable".ToSingle(NumberStyles.Any, CultureInfo.InvariantCulture).Should().Be(0.0f);
        }

        [Test]
        public void ToSingle_with_null_functional_defaultValue_throws()
        {
            Action act1 = () => "1.2".ToSingle(null);
            Action act2 = () => "1.3".ToSingle(NumberStyles.Any, CultureInfo.InvariantCulture, null);

            act1.ShouldThrow<ArgumentNullException>();
            act2.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToSingle_passes_non_parsable_value_to_continuation()
        {
            var actual1 = string.Empty;
            var actual2 = string.Empty;
            "can't parse me".ToSingle(s =>
            {
                actual1 = s;
                return 0;
            });
            "or me".ToSingle(s =>
            {
                actual2 = s;
                return 0;
            });

            actual1.Should().Be("can't parse me");
            actual2.Should().Be("or me");
        }

        [Test]
        public void ToUInt16_produces_expected_result()
        {
            "24".ToUInt16().Should().Be(24);
            "9".ToUInt16(defaultValue: _ => 5).Should().Be(9);
            " 0 ".ToUInt16(
                NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
                CultureInfo.InvariantCulture,
                defaultValue: 5)
                .Should().Be(0);
            "30.0".ToUInt16(
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture,
                defaultValue: _ => 1)
                .Should().Be(30);
        }

        [Test]
        public void ToUInt16_uses_default_value_for_non_parsable_values()
        {
            "not parsable".ToUInt16(defaultValue: 158).Should().Be(158);
            "-743".ToUInt16(defaultValue: _ => 554).Should().Be(554);
            "another invalid".ToUInt16(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: 255).Should().Be(255);
            "23498795".ToUInt16(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: _ => 11).Should().Be(11);
        }

        [Test]
        public void ToUInt16_uses_default_defaults_for_non_parsable_values()
        {
            "-173".ToUInt16().Should().Be(default(ushort));
            "3498705".ToUInt16(NumberStyles.Any, CultureInfo.InvariantCulture).Should().Be(0);
        }

        [Test]
        public void ToUInt16_with_null_functional_defaultValue_throws()
        {
            Action act1 = () => "12".ToUInt16(null);
            Action act2 = () => "13".ToUInt16(NumberStyles.Any, CultureInfo.InvariantCulture, null);

            act1.ShouldThrow<ArgumentNullException>();
            act2.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToUInt16_passes_non_parsable_value_to_continuation()
        {
            var actual1 = string.Empty;
            var actual2 = string.Empty;
            "test this".ToUInt16(s =>
            {
                actual1 = s;
                return 0;
            });
            "and this".ToUInt16(s =>
            {
                actual2 = s;
                return 0;
            });

            actual1.Should().Be("test this");
            actual2.Should().Be("and this");
        }

        [Test]
        public void ToUInt32_produces_expected_result()
        {
            "2554".ToUInt32().Should().Be(2554);
            "255".ToUInt32(defaultValue: _ => 5).Should().Be(255);
            " 0 ".ToUInt32(
                NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
                CultureInfo.InvariantCulture,
                defaultValue: 5)
                .Should().Be(0);
            "1000.0".ToUInt32(
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture,
                defaultValue: _ => 1)
                .Should().Be(1000);
        }

        [Test]
        public void ToUInt32_uses_default_value_for_non_parsable_values()
        {
            "not parsable".ToUInt32(defaultValue: 18).Should().Be(18);
            "different overload".ToUInt32(defaultValue: _ => 55).Should().Be(55);
            "-34987".ToUInt32(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: 255).Should().Be(255);
            "54633452346525635".ToUInt32(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: _ => 1).Should().Be(1);
        }

        [Test]
        public void ToUInt32_uses_default_defaults_for_non_parsable_values()
        {
            "-456".ToUInt32().Should().Be(default(uint));
            "23452364568541234".ToUInt32(NumberStyles.Any, CultureInfo.InvariantCulture).Should().Be(0);
        }

        [Test]
        public void ToUInt32_with_null_functional_defaultValue_throws()
        {
            Action act1 = () => "12".ToUInt32(null);
            Action act2 = () => "13".ToUInt32(NumberStyles.Any, CultureInfo.InvariantCulture, null);

            act1.ShouldThrow<ArgumentNullException>();
            act2.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToUInt32_passes_non_parsable_value_to_continuation()
        {
            var actual1 = string.Empty;
            var actual2 = string.Empty;
            "test this".ToUInt32(s =>
            {
                actual1 = s;
                return 0;
            });
            "and this".ToUInt32(s =>
            {
                actual2 = s;
                return 0;
            });

            actual1.Should().Be("test this");
            actual2.Should().Be("and this");
        }

        [Test]
        public void ToUInt64_produces_expected_result()
        {
            "24".ToUInt64().Should().Be(24);
            "255".ToUInt64(defaultValue: _ => 5).Should().Be(255);
            " 0 ".ToUInt64(
                NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
                CultureInfo.InvariantCulture,
                defaultValue: 5)
                .Should().Be(0);
            "100.0".ToUInt64(
                NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
                CultureInfo.InvariantCulture,
                defaultValue: _ => 1)
                .Should().Be(100);
        }

        [Test]
        public void ToUInt64_uses_default_value_for_non_parsable_values()
        {
            "-50".ToUInt64(defaultValue: 18).Should().Be(18);
            "-100".ToUInt64(defaultValue: _ => 55).Should().Be(55);
            "768768967970970979078432567831423453512323".ToUInt64(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: 255).Should().Be(255);
            "and another".ToUInt64(NumberStyles.Any, CultureInfo.InvariantCulture, defaultValue: _ => 1).Should().Be(1);
        }

        [Test]
        public void ToUInt64_uses_default_defaults_for_non_parsable_values()
        {
            "-234598744".ToUInt64().Should().Be(default(ulong));
            "2345234634746867843562342124234242323".ToUInt64(NumberStyles.Any, CultureInfo.InvariantCulture).Should().Be(0);
        }

        [Test]
        public void ToUInt64_with_null_functional_defaultValue_throws()
        {
            Action act1 = () => "12".ToUInt64(null);
            Action act2 = () => "13".ToUInt64(NumberStyles.Any, CultureInfo.InvariantCulture, null);

            act1.ShouldThrow<ArgumentNullException>();
            act2.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void ToUInt64_passes_non_parsable_value_to_continuation()
        {
            var actual1 = string.Empty;
            var actual2 = string.Empty;
            "test this".ToUInt64(s =>
            {
                actual1 = s;
                return 0;
            });
            "and this".ToUInt64(s =>
            {
                actual2 = s;
                return 0;
            });

            actual1.Should().Be("test this");
            actual2.Should().Be("and this");
        }
    }
}

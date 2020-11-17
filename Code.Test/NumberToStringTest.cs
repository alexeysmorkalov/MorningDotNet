using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Code.Test
{
    /// <summary>
    /// Convert a number to a string
    /// </summary>
    [TestFixture]
    public class NumberToStringTest
    {
        [TestCase(0, "0")]
        [TestCase(1, "1")]
        [TestCase(139420, "139420")]
        [TestCase(9420, "9420")]
        [TestCase(4565494, "4565494")]
        public void NumberToString(int input, string expected)
        {
            // Act
            var res = input.NumberToString();
            // Assert
            Assert.AreEqual(expected, res);
        }

    }

    public static class SNConvert
    {
        public static string  NumberToString(this int input)
        {
            List<char> result = new List<char>();

            do
            {
                char digit = (char)((int)'0' + (input % 10));
                input = input / 10;
                result.Insert(0, digit);
            } while (input != 0);

            return string.Join(null, result);
        }
    }
}

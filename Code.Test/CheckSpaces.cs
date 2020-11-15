using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using NUnit.Framework;

namespace Code.Test
{
    /* 
     * Check is spaces correctly placed in a string.
     * Rules:
     * 1. There should not be trailing spaces
     * 2. There should not be more than one space between words
     */
    [TestFixture]
    public class CheckSpacesTest
    {
        [TestCase("", true)]
        [TestCase(" ", false)]
        [TestCase(" Hello", false)]
        [TestCase("Hello", true)]
        [TestCase("Hello world!", true)]
        [TestCase("Hello  world!", false)]
        [TestCase("Hello world! ", false)]
        public void CheckSpaces(string value, bool expected)
        {
            // Act
            //var res = value.CheckSpaces();
            var res = value.CheckSpaces2();
            // Assert
            Assert.AreEqual(expected, res);
        }
    }

    public static class Checker 
    {
        public static bool CheckSpaces(this string value)
        {
            var prevChar = ' ';
            var lastChar = '\0';
            foreach(var c in value.ToCharArray())
            {
                lastChar = c;
                if (prevChar == ' ' && lastChar == ' ')
                    break;
                prevChar = lastChar;
            }
            return lastChar != ' ';
        }

        public static bool CheckSpaces2(this string value)
        {
            var prevChar = ' ';
            bool res = true;
            value.ToCharArray().ForEach(c => {
                if (c == ' ' && prevChar == ' ')
                    res = false;
                prevChar = c;
            });
            return res && (value == "" || prevChar != ' ');
        }

        public static void ForEach<T>(this IEnumerable<T> array, Action<T> action)
        {
            foreach (var value in array)
            {
                action(value);
            }
        }

    }

}

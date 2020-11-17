using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Code.Test
{
    // Convert a string to integer
    [TestFixture]
    public class StringToIntTest
    {

        [TestCase("0", 0)]
        [TestCase("1", 1)]
        [TestCase("345345", 345345)]
        [TestCase("923598375", 923598375)]
        public void StringToNumber(string input, int result)
        {
            // Act
            var res = input.ToNumber();
            // Assert
            Assert.AreEqual(result, res);
        }
    }

    public static class SConvert
    {
        public static int ToNumber(this string input)
        {
            var multiplier = 1;
            return input.ToCharArray().Reverse().Aggregate(0, (res, c) => 
            {
                var m = multiplier;
                multiplier *= 10;
                return res + ((int)c - (int)'0') * m;
            });
        }
    }
}

using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}

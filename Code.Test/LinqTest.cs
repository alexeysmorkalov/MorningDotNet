using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Code.Test
{
    [TestFixture]
    public class LinqTest
    {
        [Test]
        [TestCase("*123", "1*2*3")]
        [TestCase("", "")]
        [TestCase("*", "")]
        [TestCase("*1", "1")]
        [TestCase("**", "*")]
        public void Linq_Aggregate_Test(string input, string expected) {
            // Arrange
            string result = "";
            char[] data = input.ToCharArray();
            // Act
            result = data.Skip(1).Aggregate("", (list, next) => string.IsNullOrEmpty(list) ? Convert.ToString(next) : list + data[0] + Convert.ToString(next));
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}

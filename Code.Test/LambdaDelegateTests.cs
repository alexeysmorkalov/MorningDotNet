using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Code.Test
{
    public class LambdaDelegateTests
    {

        [Test]
        public void Sum()
        {
            // Act
            var res = new LambdaDelegates().Sum(1, 2);
            // Assert
            Assert.AreEqual(3, res);
        }
        [Test]
        public void Func()
        {
            // Arrange
            Func<int, int, int> d = (height, width) => height * width;
            // Act 
            var res = d(1, 2);
            // Assert
            Assert.AreEqual(2, res);
        }
    }
}

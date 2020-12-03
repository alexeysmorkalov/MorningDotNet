using System;
using System.Linq;
using NUnit.Framework;

namespace Code.Test
{
    public record Person {
        public string FirstName {get;}

        public Person(string firstName) => (FirstName) = firstName;
    }

    [TestFixture]
    public class RecordsTest
    {
        [Test]
        public void Records_Equality()
        {
            var person1 = new Person("1");
            var person2 = new Person("1");
            Assert.IsTrue(person1 == person2);
        }
        [Test] 
        public void Records_ToString() {
            var person = new Person("1");
            var res = person.ToString();
            // Assert
            Assert.AreEqual("Person { FirstName = 1 }", res);
        }
    }
}

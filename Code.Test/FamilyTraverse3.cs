﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Test3
{
    /// <summary>
    /// There is a tree of "John" (class Human) and his children.
    /// Task: write a method GetFamily which returns John, his children, his grand children, etc.
    /// </summary>
    public class Human
    {
        public string Name { get; set; }
        public List<Human> Children = new List<Human>();
    }

    public static class HumanExtension
    {
        public static IEnumerable<Human> GetFamily(this Human parent)
        {
            List<Human> generation = new List<Human>();
            generation.Add(parent);
            var prevGen = generation.AsQueryable<Human>().ToList();
            do
            {
                generation.Clear();
                foreach(var h in prevGen)
                {
                    generation.AddRange(h.Children);
                    yield return h;
                }
                prevGen = generation.AsQueryable<Human>().ToList();
            }
            while (generation.Count > 0);
            yield break;
        }

    }

    [TestFixture]
    public class FamilyTraverse
    {

        [Test]
        public void TestFullFamily()
        {
            // Arrange
            var john = new Human() { Name = "John" };
            // John's children
            var sally = new Human() { Name = "Sally" };
            var peter = new Human() { Name = "Peter" };
            var jub = new Human() { Name = "Jub" };
            john.Children.AddRange(new[] { sally, peter, jub });
            // Sally's children
            var alexandra = new Human() { Name = "Alexandra" };
            sally.Children.AddRange(new[] { alexandra });
            // Peter's children
            var denny = new Human() { Name = "Denny" };
            peter.Children.AddRange(new[] { denny });
            // Jub's children
            var kenny = new Human() { Name = "Kenny" };
            jub.Children.AddRange(new[] { kenny });
            // Kenny's children
            var bob = new Human() { Name = "Bob" };
            var jack = new Human() { Name = "Jack" };
            kenny.Children.AddRange(new[] { bob, jack });
            var expected = "John,Sally,Peter,Jub,Alexandra,Denny,Kenny,Bob,Jack";

            // Act
            //var family = john.GetFamily().Aggregate("", (f, next) => string.IsNullOrWhiteSpace(f) ? next.Name : string.Join(',', new string[] { f, next.Name }));
            var family = string.Join(',', john.GetFamily().Select(x => x.Name).ToArray()); // more conscise
            // Assert
            Assert.AreEqual(expected, family);
        }

        [Test]
        public void TestEmptyFamily()
        {
            //Arrange 
            var john = new Human() { Name = "John" };
            // Act
            var res = john.GetFamily();
            // Assert
            Assert.AreEqual(1, res.Count());
            Assert.AreEqual(john, res.First());
        }
    }
}

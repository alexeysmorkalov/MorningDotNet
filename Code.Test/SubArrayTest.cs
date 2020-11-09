using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Code.Test
{
    /*
     * Given array of elements.
     * Each element of the array is unique, except one.
     * Return sub-array of elements within these two non-unique elements.
     */
    [TestFixture]
    public class SubArrayTest
    {

        public T[] SubArray<T>(T[] input)
        {
            Dictionary<T, int> table = new Dictionary<T, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (table.ContainsKey(input[i]))
                    return input.Skip(table[input[i]] + 1).Take(i - table[input[i]] - 1).ToArray();
                else
                    table.Add(input[i], i);
            }
            throw new ArgumentException();
        }

        [TestCase(new string[] {"bird","bear","cat","rabbit","owl","cat"}, new string[] { "rabbit", "owl" })]
        public void SubArray_Test_String(string[] input, string[] expected)
        {
            // Arrange
            // Act
            var result = SubArray(input);
            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 2, 9 }, new int[] { 3, 4, 5 })]
        [TestCase(new int[] { 1, 1, 3, 4, 5, 0 }, new int[0])]
        public void SubArray_Test_Int(int[] input, int[] expected)
        {
            // Arrange
            // Act
            var result = SubArray(input);
            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
        
        [TestCase(new int[0] )]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        public void SubArray_WrongInput(int[] input)
        {
            Assert.That(() => SubArray(input), Throws.ArgumentException);
        }
    }
}

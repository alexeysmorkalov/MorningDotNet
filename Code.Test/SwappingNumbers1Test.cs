using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using NUnit.Framework;

namespace Code.Test
{
    /* PROBLEM STATEMENT
    Given is a String num. This String contains the digits of a (possibly large) positive integer. For example, num="1147" represents the integer 1147. The String num will not have any leading zeros.

    You are allowed to swap one pair of digits in the given number. In other words, you may choose a pair of distinct indices i and j, and swap the characters num[i] and num[j]. Note that you may also leave the original number unchanged. The new String must again describe a valid positive integer, i.e., it must not have any leading zeros.

    Find and return the String that represents the smallest possible integer that can be obtained.

    DEFINITION
      	
        Class:	SwappingDigits
        Method:	MinNumber
        Parameters:	String
        Returns:	String
        Method signature:	String minNumber(String num)
        (be sure your method is public)

    CONSTRAINTS
        -	The length of num will be between 2 and 50, inclusive.
        -	Each character of num will be between '0' and '9', inclusive.
        -	The first character of num will not be '0'.
    */
    [TestFixture]
    public class SwappingNumbers1Test
    {
        [TestCase("596", "569")]
        [TestCase("93561", "13569")]
        [TestCase("5491727514", "1491727554")]
        [TestCase("10234", "10234")]
        [TestCase("93218910471211292416", "13218910471211292496")]
        [TestCase("2000", "2000")]
        [TestCase("2100", "1200")]
        [TestCase("390", "309")]
        [TestCase("3900", "3009")]
        [TestCase("3944", "3449")]
        [TestCase("11111", "11111")]
        [TestCase("11211", "11112")]
        public void TestSwappingNumbers(string input, string expected)
        {
            // Act
            var result = new SwappingNumbers().MinNumber(input);
            // Assert
            Assert.AreEqual(expected, result);
        }
    }

    // Solution
    public class SwappingNumbers
    {
        public string MinNumber(string value)
        {
            var chars = value.ToCharArray();

            // because keys of input array is vary limited in comparison to the imput array
            // length, only 10 characters, we will use a SortedDictionary which we'll fill with
            // the best swap option (starting from the end of input array).
            
            var endArray = new SortedDictionary<char, int>();
            for(int i = chars.Length-1; i >= 0; i--)
            {
                if (!endArray.ContainsKey(chars[i]))
                {
                    endArray[chars[i]] = i;
                }
                if (endArray.Count == '9' - '0' + 1)
                    break;
            }

            // starting from the beginning, we test if a swap option for this position exists
            for(int i = 0; i < chars.Length - 1; i++)
            {
                var q = endArray.Where(x => x.Key < chars[i] && x.Value > i);
                // the zero-leading restriction
                if (i == 0)
                    q = q.Where(x => x.Key != '0');
                if (q.Any())
                {
                    var swappee = q.First();
                    chars[swappee.Value] = chars[i];
                    chars[i] = swappee.Key;
                    break;
                }
            }
            return new string(chars);
        }
    }
}

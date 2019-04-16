using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TDD_Course
{
    /*
     * I = 1
     * V = 5
     * X = 10
     * L = 50
     * C = 100
     * D = 500
     * M = 1000
     * 
     * IV = 4
     * IX = 9
     */
     
    [TestFixture]
    public class RomanNumeralTestClass
    {
        [TestCase(1, "I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(2, "II")]
        [TestCase(4, "IV")]
        [TestCase(9, "IX")]
        [TestCase(11, "XI")]
        [TestCase(1011, "MXI")]
        [TestCase(999, "IM")]
        [TestCase(432, "CCCCXXXII")]
        [TestCase(111, "CXI")]
        public void TestMethod1(int expected, string numeral)
        {
            Assert.AreEqual(expected, RomanNumeral(numeral));
        }

        private Dictionary<char, int> map = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000},
        };

        private int RomanNumeral(string numeral)
        {
            int result = 0;
            for(int i = 0; i < numeral.Length; i++)
            {
                //if it's subtractive notation(IV or IX) then subtract instead of add
                if(i + 1 < numeral.Length && map[numeral[i]] < map[numeral[i + 1]])
                {
                    result -= map[numeral[i]];
                }
                else
                {
                    result += map[numeral[i]];
                }
            }

            return result;
        }
    }
}

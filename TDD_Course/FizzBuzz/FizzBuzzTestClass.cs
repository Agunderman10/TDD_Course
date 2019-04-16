using System;
using NUnit.Framework;

namespace TDD_Course
{
    [TestFixture]
    public class FizzBuzzTestClass
    {
        /* FizzBuzz
         * If divisible by 3 -> return "Fizz"
         * If divisible by 5 -> return "Buzz"
         * If divisible by 3 and 5 -> return "FizzBuzz"
         * Else -> return ""
         */
        [TestCase("Fizz", 3)]
        [TestCase("Buzz", 5)]
        [TestCase("Fizz", 6)]
        [TestCase("Buzz", 10)]
        [TestCase("FizzBuzz", 15)]
        [TestCase("FizzBuzz", 30)]
        [TestCase("", 7)]
        [TestCase("", 31)]
        public void TestFizzBuzz(string expected, int number)
        {
            Assert.AreEqual(expected, FizzBuzz(number));
        }

        private string FizzBuzz(int number)
        {
            if((number % 3 == 0) && (number % 5 == 0))
            {
                return "FizzBuzz"; 
            }

            if(number % 3 == 0)
            {
                return "Fizz";
            }

            if(number % 5 == 0)
            {
                return "Buzz";
            }

            return string.Empty;
        }
    }
}

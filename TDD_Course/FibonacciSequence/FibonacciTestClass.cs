//fast
//independent
//repeatable
//self-validatable
//in-time

//tdd is the approach of writing tests ahead of the production code

//Red, Green, Refactor
//Red: Create a test and make it fail
//Green: Make the test pass by any means necessary
//Refactor: Change the code to remove duplication in your project and improve design while ensuring
//tests still pass

//3 laws of TDD (Test Driven Development)
//never write a line of production code until you have written at least one test/failed test
//don't write excessive code
//don't write production code more than to simply pass the failing test

//3 main types of tests, unit tests(most), integration test(second most), and acceptance tests(least)

/* Regular Agile Process
 * 
 * Customer and Developers talk about the product and the expectations, goals, and elements that need to be
 * included. Acceptance tests are written first, either by the means of software developers or the customer's
 * employees. Next, we think of the big picture of the project and draw several diagrams to help us design
 * the biggest parts of the system. We break down the most complex parts and draw several smaller diagrams to
 * help us understand how to design these more complicated parts. All of the diagrams are able to be changed
 * as we create the program. 
 * 
 * Now, the team can implement TDD by writing unit tests before writing any production code. 
 * 
 * 
 * 3 Main TDD Techniques (Faking and Triangulation strongly advised)
 *     Faking- faking is returning a fake value just to make a test pass without actually writing the 
 *     correct method to be tested yet
 *     Triangulation- the process of adding test cases until the right way of implementation starts to 
 *     emerge. Usually, 2 or 3 test cases are enough to stop triangulation. Faking and triangulation lead
 *     to the implementation when the way of generalization becomes obvious. 
 *     Obvious Implementation- in many cases we can avoid Faking and Triangulation. Be careful implementing
 *     an entire algorithm out of your mind, very often you think implementation is obvious but obvious 
 *     implementation often fails at the edge cases. 
 */

using System;
using NUnit.Framework;
//to use NUnit make sure you install NUnit NuGet packages including the NUnit Test Adapter to run the tests

namespace TDD_Course
{
    [TestFixture]
    public class FibonacciTests
    {
        
        [TestCase(0,0)]
        [TestCase(1,1)]
        [TestCase(1,2)]
        [TestCase(2,3)]
        public void TestFibonacci(int expected, int index)
        {
            Assert.AreEqual(expected, GetFibonacci(index));
        }

        private int GetFibonacci(int index)
        {
            if(index == 0)
            {
                return 0;
            }

            if(index == 1)
            {
                return 1;
            }

            return GetFibonacci(index - 1) + GetFibonacci(index - 2);
        }
    }
}

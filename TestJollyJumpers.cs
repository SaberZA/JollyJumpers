using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ChallengeJollyJumpers.Test
{
    [TestFixture]
    public class TestJollyJumpers
    {
        private const string Delimiter = " ";

        [Test]
        public void IsJolly_GivenEmptyString_ShouldReturnFalse()
        {
            //---------------Set up test pack-------------------
            var inputLine = "";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var isJolly = IsJolly(inputLine);
            //---------------Test Result -----------------------
            Assert.IsFalse(isJolly);
        }

        [Test]
        public void IsJolly_GivenSingleInteger_ShouldReturnFalse()
        {
            //---------------Set up test pack-------------------
            var inputLine = "1";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var isJolly = IsJolly(inputLine);
            //---------------Test Result -----------------------
            Assert.IsFalse(isJolly);
        }

        [Test]
        public void IsJolly_GivenTwoIntegers_ShouldReturnTrue()
        {
            //---------------Set up test pack-------------------
            var inputLine = "1 2";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var isJolly = IsJolly(inputLine);
            //---------------Test Result -----------------------
            Assert.IsTrue(isJolly);
        }

        [Test]
        public void IsJolly_GivenThreeIntegers_ShouldReturnFalse()
        {
            //---------------Set up test pack-------------------
            var inputLine = "2 1 3";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var isJolly = IsJolly(inputLine);
            //---------------Test Result -----------------------
            Assert.IsFalse(isJolly);
        }

        [Test]
        public void IsJolly_Given5Integers_ShouldReturnTrue()
        {
            //---------------Set up test pack-------------------
            var inputLine = "4 1 4 2 3";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var isJolly = IsJolly(inputLine);
            //---------------Test Result -----------------------
            Assert.IsTrue(isJolly);
        }

        [Test]
        public void IsJolly_Given6Integers_ShouldReturnFalse()
        {
            //---------------Set up test pack-------------------
            var inputLine = "5 1 4 2 -1 6";
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var isJolly = IsJolly(inputLine);
            //---------------Test Result -----------------------
            Assert.IsFalse(isJolly);
        }

        private bool IsJolly(string inputLine)
        {
            if (string.IsNullOrEmpty(inputLine))
            {
                return false;
            }

            var items = SplitInput(inputLine);

            if (items.Count < 2)
            {
                return false;
            }

            var numberCount = GetNumberCount(items);
            var sequence = GetNumberSequence(items);
            if (sequence.Count() != numberCount)
            {
                return false;
            }

            var sequenceWithoutDuplicates = sequence.Distinct().ToList();

            var sumOfSequence = GetSumOfDistinctSequence(numberCount - 1);
            var sumOfAbsoluteValues = GetSumOfAbsoluteValues(sequenceWithoutDuplicates);

            return sumOfSequence == sumOfAbsoluteValues;
        }

        private static int GetSumOfDistinctSequence(int numberCount)
        {
            return (numberCount*(numberCount + 1))/2;
        }

        private static int GetSumOfAbsoluteValues(List<string> sequenceWithoutDuplicates)
        {
            var sumOfAbsoluteValues = 0;

            for (int i = 0; i < sequenceWithoutDuplicates.Count() - 1; i++)
            {
                var numberString1 = sequenceWithoutDuplicates[i];
                var numberString2 = sequenceWithoutDuplicates[i + 1];
                var number1 = Int32.Parse(numberString1);
                var number2 = Int32.Parse(numberString2);

                sumOfAbsoluteValues += Math.Abs(number1 - number2);
            }
            return sumOfAbsoluteValues;
        }

        private static List<string> GetNumberSequence(List<string> items)
        {
            return items.Skip(1).ToList();
        }

        private static int GetNumberCount(List<string> items)
        {
            return Int32.Parse(items[0]);
        }

        private static List<string> SplitInput(string inputLine)
        {
            return inputLine.Split(new[] {Delimiter}, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }

}

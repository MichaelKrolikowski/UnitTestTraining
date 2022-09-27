using NUnit.Framework;
using System;

namespace UnitTestTraining.Test
{
    [Parallelizable(ParallelScope.Children)]
    public class Tests
    {
        [TestCase("")]
        public void TestStringCalculatedEmptyString(string numbers)
        {
            var result = StringCalculator.Add(numbers);
            Assert.That(() => result, Is.EqualTo(0));
        }

        [TestCase("1")]
        public void TestStringCalculatedTest1(string numbers)
        {
            var result = StringCalculator.Add(numbers);
            Assert.That(() => result, Is.EqualTo(1));
        }

        [TestCase("1,2")]
        public void TestStringCalculatedTest2(string numbers)
        {
            var result = StringCalculator.Add(numbers);
            Assert.That(() => result, Is.EqualTo(3));
        }

        [TestCase("1\n2,3")]
        public void TestStringCalculatedTest3(string numbers)
        {
            var result = StringCalculator.Add(numbers);
            Assert.That(() => result, Is.EqualTo(6));
        }

        [TestCase("-1,2,3")]
        public void TestStringCalculatedTest4(string numbers)
        {
            Assert.That(() => StringCalculator.Add(numbers), Throws.TypeOf<ArgumentException>());
        }

        [TestCase("2,1001")]
        public void TestStringCalculatedTest5(string numbers)
        {
            var result = StringCalculator.Add(numbers);
            Assert.That(() => result, Is.EqualTo(2));
        }

        [TestCase("//[***]\n1***2***3")]
        public void TestStringCalculatedTest6(string numbers)
        {
            var result = StringCalculator.Add(numbers);
            Assert.That(() => result, Is.EqualTo(6));
        }

        [TestCase("//[*][%]\n1*2%3")]
        public void TestStringCalculatedTest7(string numbers)
        {
            var result = StringCalculator.Add(numbers);
            Assert.That(() => result, Is.EqualTo(6));
        }

    }
}
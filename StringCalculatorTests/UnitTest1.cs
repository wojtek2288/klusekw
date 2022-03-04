using NUnit.Framework;
using StringCalculator;
using System;

namespace StringCalculatorTests
{
    public class Tests
    {
        private Calculator calculator;
        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void EmptyStringTest()
        {
            int res = calculator.Calculate("");
            Assert.AreEqual(res, 0);
        }

        [Test]
        public void SingleNumberTest()
        {
            int res = calculator.Calculate("1");
            Assert.AreEqual(res, 1);
        }

        [Test]
        public void TwoNumbersSum()
        {
            int res = calculator.Calculate("2, 3");
            Assert.AreEqual(res, 5);
        }

        [Test]
        public void TwoNumbersEndlSplitter()
        {
            int res = calculator.Calculate("2\n3");
            Assert.AreEqual(res, 5);
        }

        [Test]
        public void TripleSplitters()
        {
            int res = calculator.Calculate("2,4\n5");
            Assert.AreEqual(res, 11);
        }

        [Test]
        public void NegativeTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.Calculate("2,-4\n5"));
        }

        [Test]
        public void GreaterThan1000()
        {
            int res = calculator.Calculate("1001, 10");
            Assert.AreEqual(res, 10);
        }

        [Test]
        public void DefineSplitter()
        {
            int res = calculator.Calculate("//#2#2");
            Assert.AreEqual(res, 4);
        }

        [Test]
        public void MultiCharSpllitter()
        {
            int res = calculator.Calculate("//[##]2##2");
            Assert.AreEqual(res, 4);
        }
    }
}
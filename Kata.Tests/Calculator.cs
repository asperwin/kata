using System;
using NUnit.Framework;

namespace Kata.Tests
{
    [TestFixture]
    public class CalculatorTest
    {
        [Test]
        public void Add_EmptyStringPassed_ZeroReturned()
        {
            var calc = new Calculator();

            var result = calc.Add("");

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Add_NumberStringPassed_NumberReturned()
        {
            var calc = new Calculator();

            var result = calc.Add("1");

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Add_NumbersStringPassed_NumbersSumReturned()
        {
            var calc = new Calculator();

            var result = calc.Add("1,2");

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Add_NumbersSplitByNewLineStringPassed_NumbersSumReturned()
        {
            var calc = new Calculator();

            var result = calc.Add("1\n2,3");

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Add_NumbersSplitByCustomSeparatorStringPassed_NumbersSumReturned()
        {
            var calc = new Calculator();

            var result = calc.Add("//;\n1;2");

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Add_NumbersWithNegativesPassed_ExceptionReturned()
        {
            var calc = new Calculator();

            Assert.Throws(Is.TypeOf<ArgumentException>().And.Message.EqualTo("negatives not allowed\r\nParameter name: -2,-4"),
                ()=> calc.Add("1,-2,3,-4"));
        }

        [Test]
        public void Add_NumbersBiggerThen1000StringPassed_SumReturnedBigNumbersIgnored()
        {
            var calc = new Calculator();

            var result = calc.Add("1,2,1001,3,1000");

            Assert.That(result, Is.EqualTo(1006));
        }

        [Test]
        public void Add_NumbersSplitByMultyCharacterDelimeterPassed_SumReturned()
        {
            var calc = new Calculator();

            var result = calc.Add("//[***]\n1***2***3");

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Add_NumbersSplitByMultipleDelimetersPassed_SumReturned()
        {
            var calc = new Calculator();

            var result = calc.Add("//[*][%]\n1*2%3");

            Assert.That(result, Is.EqualTo(6));
        }

    }
}
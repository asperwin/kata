using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Kata.Tests
{
     [TestFixture]
    public class CalculatorTest
    {
         [Test]
         public void Add_EmptyStringPassed_ZeroReturned()
         {
             //Arrange
             Calculator calc = new Calculator();

             //Act
             int val = calc.Add("");

             //Assert
             Assert.AreEqual(val, 0);
         }

         [Test]
         public void Add_OneElementStringPassed_ElementReturned()
         {
             //Arrange
             Calculator calc = new Calculator();

             //Act
             int val = calc.Add("5");

             //Assert
             Assert.AreEqual(val, 5);
         }

         [Test]
         public void Add_TwoElementsStringPassed_SumReturned()
         {
             //Arrange
             Calculator calc = new Calculator();

             //Act
             int val = calc.Add("1,2");

             //Assert
             Assert.AreEqual(val, 3);
         }

         [Test]
         public void Add_ElementsSpliByNewLineStringPassed_SumReturned()
         {
             //Arrange
             Calculator calc = new Calculator();

             //Act
             int val = calc.Add("1\n2");

             //Assert
             Assert.AreEqual(val, 3);
         }

         [Test]
         public void Add_ThreeElementsSpliByNewLineOrComaPassed_SumReturned()
         {
             //Arrange
             Calculator calc = new Calculator();

             //Act
             int val = calc.Add("1\n2,3");

             //Assert
             Assert.AreEqual(val, 6);
         }

         [Test]
         public void Add_ElementsSpliByNewDelimeterPassed_SumReturned()
         {
             //Arrange
             Calculator calc = new Calculator();

             //Act
             int val = calc.Add("//;\n1;2");

             //Assert
             Assert.That(val, Is.EqualTo(3));
             Assert.AreEqual(val, 3);
         }

         [Test]
         public void Add_NegativeElementIsPassed_ExceptionThrown()
         {
             //Arrange
             Calculator calc = new Calculator();
             
             Assert.Throws(Is.TypeOf<ArgumentException>().And.Message.EqualTo("negatives not allowed"),
                 delegate
                     {
                         calc.Add("1, -2");
                     });
         }
       
    }
}

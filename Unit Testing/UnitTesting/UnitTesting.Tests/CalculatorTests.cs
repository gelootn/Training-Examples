using NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.Code;

namespace UnitTesting.Tests
{
    [TestFixture]
    internal class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void TestSum()
        {
            // Arrange
            var a = 10;
            var b = 20;

            // Act
            var result = _calculator.Sum(a, b);
            // Assert

            Assert.That(result, Is.EqualTo(30));
        }


        [TestCase(10, 20, 30)]
        [TestCase(15, 20, 35)]
        [TestCase(0, 20, 20)]
        public void TestSumExtended(decimal a, decimal b, decimal expected)
        {
            // Act
            var result = _calculator.Sum(a, b);
            // Assert

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(SumSources))]
        public void TestSumWithSource(SumSource source)
        {
            // Act
            var result = _calculator.Sum(source.A, source.B);
            // Assert

            Assert.That(result, Is.EqualTo(source.expected), $"A {source.A} + B {source.B} does not equal {source.expected}, result was {result}");
        }


        [Test]
        public void DividerTest()
        {
            Assert.Throws<DivideByZeroException>( () => _calculator.Divide(10 , 0));

        }


        public static IEnumerable<SumSource> SumSources()
        {
            yield return new SumSource { A = 10, B = 20, expected = 30};
            yield return new SumSource { A = 15, B = 20, expected = 35 };
            yield return new SumSource { A = 0, B = 20, expected = 20};
        }

         

        public class SumSource{
           public decimal A { get; set; }
           public decimal B { get; set; }
           public decimal expected { get; set; }
        }

   

    }
}

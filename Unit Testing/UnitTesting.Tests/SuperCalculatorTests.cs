using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.Code;
using Moq;

namespace UnitTesting.Tests
{
    [TestFixture]
    internal class SuperCalculatorTests
    {
        private SuperCalculator _calc;
        private Mock<ICalculator> _baseCalc;


        [SetUp]
        public void SetUp()
        {
            _baseCalc = new Mock<ICalculator>();
            _baseCalc.Setup(x => x.Sum(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(30);

            _calc = new SuperCalculator(_baseCalc.Object);
        }

        [Test]
        public void FancyCalculationTest()
        {
            var a = 100;
            var b = 200; 
            var c = 30;
            var result = _calc.DoFancyCalculation(a, b, c);

            Assert.That(result, Is.EqualTo(60));
        }


        [Test]
        public void FancyCalculationMethodCallTest()
        {
            var a = 100;
            var b = 200;
            var c = 30;

            var result = _calc.DoFancyCalculation(a, b, c);

            _baseCalc.Verify(x => x.Sum(a, b), Times.Once);
        }
    }
}

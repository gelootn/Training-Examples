using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Code
{
    public class SuperCalculator
    {
        private readonly ICalculator _basicCalculator;

        public SuperCalculator(ICalculator basicCalculator)
        {
            _basicCalculator = basicCalculator;
        }

        public decimal DoFancyCalculation(int a, int b, int c)
        {
            return _basicCalculator.Sum(a, b) + c;
        }
    }
}

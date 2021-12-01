using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class Calculator
    {
        public double Sum(double left, double right)
        {
            return left + right;
        }
        public double Min(double left, double right) 
        {
            return left - right;
        }
        public double Multiply (double left, double right)
        {
            return left * right;
        }
        public decimal Divide(decimal left, decimal right)
        {
            try
            {   
                return left / right;

            }
            catch (Exception ex)
            {
                throw new Exception("Divider error", ex);
            }
           
        }
        public double Power(double @base, double power)
        {
            return Math.Pow(@base, power);
        }
        public double Root(double @base, double root)
        {
            return Math.Pow(@base, 1.0 / root);
        }
    }
}

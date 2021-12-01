using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling.Console
{
    public class MyFirstException : Exception
    {
        public string MyProp { get; set; }
        public MyFirstException(string myProp)
        {
            MyProp = myProp;
        }
    }
}

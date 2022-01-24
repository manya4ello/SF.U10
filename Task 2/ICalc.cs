using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    internal interface ICalc
    {
        decimal Add(decimal a, decimal b);
        decimal Multiply(decimal a, decimal b);
        decimal Subtract(decimal a, decimal b);
        decimal Divide(decimal a, decimal b);
    }
}

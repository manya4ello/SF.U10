using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Calc : ICalc
    {
        public decimal Add(decimal a, decimal b) { return a + b; }
        public decimal Multiply(decimal a, decimal b) { return a * b; }
        public decimal Subtract(decimal a, decimal b) { return a - b; }
        public decimal Divide(decimal a, decimal b) { return a / b; }
        public decimal Nothing(decimal a, decimal b) { return 0; } //можно было бы и не делать его, но тогда надо вместо switch на if-else-if длинный переходить

    }
}

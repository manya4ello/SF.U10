using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{

    public class Logger : ILogger
    {
        public void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{

    /// <summary>
    /// Метод расширения для различных типов данных
    /// </summary>
    public static class Extansions
    {
        /// <summary>
        /// Возвращает символ из массива
        /// </summary>
        /// <param name="sign"></param>
        /// <param name="signs"></param>
        /// <returns></returns>
        public static char GetC(this char sign, char[] signs)
        {
            char[] input;
            string? inputstr = string.Empty;
            bool check = false;
            int i = 0;
            (int x, int y) = Console.GetCursorPosition();
            do
            {
                Console.SetCursorPosition(x, y);

                inputstr = Console.ReadLine();
                if (inputstr.Length > 0)
                {
                    input = inputstr.ToCharArray();
                    sign = input[0];
                    foreach (char c in signs)
                        if (c == sign)
                            check = true;
                    if (i > 4)
                    {
                        Console.Write("Видимо вы ошиблись, попробуйте еще раз ввести один из следующих символов: \t");
                        foreach (char c in signs)
                            Console.Write("{0} \t", c);
                        Console.WriteLine();
                        (x, y) = Console.GetCursorPosition();
                        i -= 4;
                    }
                }
                i++;
            }
            while (!check);

            return sign;
        }
        /// <summary>
        /// Возвращает число decimal в диапазоне
        /// </summary>
        /// <param name="number"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static decimal GetN(this decimal number, decimal a, decimal b)
        {
            string? inputstr = String.Empty;
            bool check;
            (int x, int y) = Console.GetCursorPosition();
            do
            {
                Console.SetCursorPosition(x, y);
                inputstr = Console.ReadLine();
                check = !decimal.TryParse(inputstr, out number) | (inputstr == "");
                if (!check && ((number < a) | (number > b)))
                {
                    Console.Write("Видимо вы ошиблись, попробуйте еще раз ввести целое число от {0} до {1}: ", a, b);
                    (x, y) = Console.GetCursorPosition();
                }

            }
            while (check | ((number < a) | (number > b)));

            return number;
        }
        public static int GetN(this int number, int a, int b)
        {
            string? inputstr = String.Empty;
            bool check;
            (int x, int y) = Console.GetCursorPosition();
            do
            {
                Console.SetCursorPosition(x, y);
                inputstr = Console.ReadLine();
                check = !int.TryParse(inputstr, out number) | (inputstr == "");
                if (!check && ((number < a) | (number > b)))
                {
                    Console.Write("Видимо вы ошиблись, попробуйте еще раз ввести целое число от {0} до {1}: ", a, b);
                    (x, y) = Console.GetCursorPosition();
                }

            }
            while (check | ((number < a) | (number > b)));

            return number;
        }
    }

}

//Реализуйте механизм внедрения зависимостей: добавьте в мини-калькулятор логгер, используя материал из скринкаста юнита 10.1.

//Дополнительно: текст ошибки, выводимый в логгере, окрасьте в красный цвет, а текст события — в синий цвет.


using System;

namespace Task_2;

class Program
{
    static ILogger Logger { get; set; }
    static void Main()
    {
        Logger = new Logger();
        Calc Calc = new Calc();
        Operate operation = Calc.Nothing;
        char c = default;
        char[] signs = new char[] { '+', '-', '/', '*', 'в' };


        Console.WriteLine("Добро пожаловать в программу калькулятор!");
        Logger.Info("Введите число: ");
        decimal a = 0;
        decimal b = 0;
        a = a.GetN(decimal.MinValue, decimal.MaxValue);

        bool check = true;
        decimal? result;
        do
        {
            Logger.Info("Введите число: ");
            b = b.GetN(decimal.MinValue, decimal.MaxValue);

            Logger.Info ("Введите операцию (для выхода из программы - 'в'): ");
            c = c.GetC(signs);
            switch (c)
            {
                case '+': { operation = Calc.Add; break; }
                case '-': { operation = Calc.Subtract; break; }
                case '/': { operation = Calc.Divide; break; }
                case '*': { operation = Calc.Multiply; break; }
                case 'в': { check = false; continue; }
            }

            try
            {
                operation -= Calc.Nothing;
                result = operation?.Invoke(a, b);
                
                Logger.Event($"{a} {c} {b} = {result}");
                a = result ?? a;
            }
            catch (DivideByZeroException)
            {
                Logger.Error("Что-ж вы, батенька, на ноль то делите?!");
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }

        }
        while (check);


        Console.ReadKey();
    }

}

public delegate decimal Operate(decimal a, decimal b);

class Calc : ICalc
{
    public decimal Add(decimal a, decimal b) { return a + b; }
    public decimal Multiply(decimal a, decimal b) { return a * b; }
    public decimal Subtract(decimal a, decimal b) { return a - b; }
    public decimal Divide(decimal a, decimal b) { return a / b; }
    public decimal Nothing(decimal a, decimal b) { return 0; } //можно было бы и не делать его, но тогда надо вместо switch на if-else-if длинный переходить

}



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

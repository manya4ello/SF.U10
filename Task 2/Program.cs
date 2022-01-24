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






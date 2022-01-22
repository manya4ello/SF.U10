using System;

class Program
{
    static void Main()
    {
        Calc Calc = new Calc();
        Operate operation = Calc.Nothing;
        char c = default;
        char[] signs = new char[] { '+', '-', '/', '*','в' };
        
        
        Console.WriteLine("Добро пожаловать в программу калькулятор!");
        Console.Write("Введите число: ");
        decimal a = 0;
        decimal b = 0;
        a =a.GetN(decimal.MinValue, decimal.MaxValue);

        bool check = true;
        decimal? result;
        do
        {
            Console.Write("Введите число: ");
            b = b.GetN(decimal.MinValue, decimal.MaxValue);

            Console.Write("Введите операцию (для выхода из программы - 'в'): ");
            c = c.GetC(signs);
            switch (c)
            {
                case '+': {operation = Calc.Add; break; }
                    case '-': { operation = Calc.Subtract; break; }
                case '/': { operation = Calc.Divide; break; }
                case '*': { operation = Calc.Multiply; break; }
                case 'в':        { check = false; continue; }
            }
            
            try
            {
               operation -= Calc.Nothing;
                result = operation?.Invoke(a, b);
                Console.WriteLine("{0} {1} {2} = {3}", a,c,b,result );
                a = result??a; 
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Что-ж вы, батенька, на ноль то делите?!");
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
           
        }
        while (check);

       

        //S<int> XS = new S<int>();
        //Console.WriteLine(XS.Add(4, 9));


        Console.ReadKey();
    }

}

public delegate decimal Operate (decimal a, decimal b); 
public interface ICalc
{
    decimal Add(decimal a, decimal b);
	decimal Multiply(decimal a, decimal b);
	decimal Subtract(decimal a, decimal b);
	decimal Divide(decimal a, decimal b);
}
class Calc: ICalc
{
    public decimal Add(decimal a, decimal b) { return a + b; }
    public decimal Multiply(decimal a, decimal b) { return a * b; }
    public decimal Subtract(decimal a, decimal b) { return a - b; }
    public decimal Divide(decimal a, decimal b) { return a / b; }
    public decimal Nothing(decimal a, decimal b) { return 0; }

}

/// <summary>
/// Метод расширения для различных типов данных
/// </summary>
public static class Extansions
{
    ///Проверка ввода числа. Проверяет, что число и оно в диапазоне от a до b
    public static char GetC(this char sign, char [] signs)
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
            if (inputstr.Length>0)
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

/// <summary>
/// Пытался написать метод для ввода любого типа числа - не получилось
/// </summary>
/// <typeparam name="T"></typeparam>
public static class Numbers<T>
{
    //public static T GetNumber(T a, T b)
    //{
    //    string? inputstr = String.Empty;
    //    bool check = false;
    //    T result = default;
    //    (int x, int y) = Console.GetCursorPosition();
    //    do
    //    {

    //        Console.SetCursorPosition(x, y);
    //        inputstr = Console.ReadLine();

    //        decimal number = 0;
    //        decimal min = default;
    //        decimal max = default;
    //        try
    //        {
    //            number = Convert.ToDecimal(inputstr);
    //            min = Convert.ToDecimal(a);
    //            max = Convert.ToDecimal(b);
    //            check = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            check = false;
    //        }

    //        if (check && ((number < min) | (number > max)))
    //        {
    //            Console.Write("Видимо вы ошиблись, попробуйте еще раз ввести число типа {0} от {1} до {2}: ", number.GetType(), a, b);
    //            (x, y) = Console.GetCursorPosition();
    //            check = false;
    //        }


    //        result = (T)inputstr;
    //    }
    //    while (!check);

    //    return result;
    //}
}

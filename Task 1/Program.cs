using System;

class Program
{
    static void Main()
    {

        // decimal

        S<int> XS = new S<int>();
        Console.WriteLine(XS.Add(4, 9));
        Console.ReadKey();
    }

}

public interface IArithmetic<T>
{
    T Add(T a, T b);
    T Multiply(T a, T b);
    T Subtract(T a, T b);
    T Divide(T a, T b);
}
class S<T> where T : IArithmetic<T>
{
    public T Add(T a, T b) { return a + b; }
    public T Multiply(T a, T b) { return a * b; }
    public T Subtract(T a, T b) { return a - b; }
    public T Divide(T a, T b) { return a / b; }
}

/// <summary>
/// Метод расширения для различных типов данных
/// </summary>
public static class Extansions
{
	///Проверка ввода числа. Проверяет, что число и оно в диапазоне от a до b
	public static int GetInt(this int number, int a, int b)
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
	public static <T> GetNumber(T number, T a, T b)
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
				Console.Write("Видимо вы ошиблись, попробуйте еще раз ввести число от {0} до {1}: ", a, b);
				(x, y) = Console.GetCursorPosition();
			}

		}
		while (check | ((number < a) | (number > b)));

		return number;
	}
}

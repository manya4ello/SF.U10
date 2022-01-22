using System;
interface Itry
{
    void Writes (string mes)
    { 
        Console.WriteLine("Пишу {0}",mes);
        }
}

class Test: Itry
{
   
}

class Program
{
    static void Main()
    {
        Itry itry = new Test();

        Test test = new Test();

        itry.Writes("Хрень");

        void Doaction(Itry obj) => obj.Writes("ок");
        
        Doaction(test);

        Console.ReadKey();
    }
}
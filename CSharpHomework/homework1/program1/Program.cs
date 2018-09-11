using System;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = " ";
            s = Console.ReadLine();
            double a = Double.Parse(s);
            s = Console.ReadLine();
            double b = Double.Parse(s);
            Console.WriteLine(a*b);
        }
    }
}

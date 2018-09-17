using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//输出用户指定数据的所有素数因子
namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input an int number: ");
            string s = Console.ReadLine();
            int num;
            bool vaild = Int32.TryParse(s, out num);
            if (vaild)
            {
                Console.WriteLine("Its prime factors are: ");
                for (int i = 2; i <= num; i++)
                {
                    if (IsPrimeOrNot(i) && num % i == 0)
                        Console.Write(i + " ");
                }
            }
            else
            {
                Console.WriteLine("Input error!");
            }
        }
        private static bool IsPrimeOrNot(int a)
        {
            for (int i = 2; i < a; i++)
            {
                if (a % i == 0) return false;
            }
            return true;
        }
    }
}

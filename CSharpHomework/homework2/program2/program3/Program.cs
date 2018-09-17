using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[99];
            for (int i = 0; i < arr.Length; i++) arr[i] = i + 2;
            for(int i=2;i<=100;i++)
            {
                for(int j=0;j<arr.Length;j++)
                {
                    if (arr[j]!=0 && arr[j]/i>1 && arr[j] % i == 0) arr[j] = 0;
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                    Console.Write(arr[i] + " ");
            }
        }
    }
}

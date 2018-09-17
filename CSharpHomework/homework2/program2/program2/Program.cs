using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//求一个整数数组的最大值，最小值，平均值，和
namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 54, 4, 7, 34, 23, 87, 3 };
            int max=arr[0], min=arr[0];
            double avr=0, he = 0;
            for(int i=0;i<arr.Length;i++)
            {
                if (arr[i] > max) max = arr[i];
                if (arr[i] < min) min = arr[i];
                he += arr[i];
            }
            avr = he / arr.Length;
            Console.WriteLine("数组最大值是：" + max);
            Console.WriteLine("数组最小值是：" + min);
            Console.WriteLine("数组元素的和是：" + he);
            Console.WriteLine("数组元素的平均值是：" + avr);
        }
        
    }
}

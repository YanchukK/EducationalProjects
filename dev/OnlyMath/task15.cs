using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[5] { 5, 4, 8, 3, 4};

            int sum = 0;

            for (int i = 0; i < mas.Length; i++)
            {
                sum += mas[i];
            }

            Console.WriteLine(sum/mas.Length);
        }
    }
}

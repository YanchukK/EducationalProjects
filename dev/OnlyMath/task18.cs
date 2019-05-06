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
            Console.Write("Input size of arrays: ");
            int[] mas = new int[int.Parse(Console.ReadLine())];

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = i;
                Console.Write(mas[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] *= 2;
                Console.Write(mas[i] + " ");
            }
        }
    }
}

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

            int max = 0;

            for (int i = 0; i < mas.Length-1; i++)
            {
                if(mas[i] > mas[i + 1])
                {
                    max = mas[i];
                }
            }

            Console.WriteLine(max);
        }
    }
}

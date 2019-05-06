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

            for (int i = 0; i < mas.Length; i++)
            {
                if(mas[i] > max)
                {
                    max = mas[i];
                }
            }

            Console.WriteLine(max);
        }
    }
}

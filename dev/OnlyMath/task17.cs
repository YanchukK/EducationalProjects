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
            int n = int.Parse(Console.ReadLine());
            int[] mas1 = new int[n];
            int[] mas2 = new int[n];

            for (int i = 0; i < n; i++)
            {
                mas1[i] = i;
                mas2[i] = i * 2;
            }

            int number = 0;

            for (int i = 0; i < n; i++)
            {
                if(mas1[i] > mas2[i])
                {
                    number++;
                }
            }

            Console.WriteLine("In first array " + number + " elements bigger than in decond");
        }
    }
}

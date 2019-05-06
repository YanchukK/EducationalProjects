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
            int[] mas = new int[9] { 5, 9, 4, 8, 3, 1, 10, 13, -5 };

            int indexofmax = 0;
            int max = 0;

            for (int i = 0; i < mas.Length; i++)
            { 
                if (mas[i] > max)
                {
                    max = mas[i];
                    indexofmax = i;
                }
            }

            int indexofmin = 0;

            for (int i = 0; i < mas.Length - 1; i++)
            {
                if (mas[i] > mas[i + 1])
                {
                    indexofmin = i + 1;
                }
            }

            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(mas[i] + " ");
            }
            
            int temp = mas[indexofmax];
            mas[indexofmax] = mas[indexofmin];
            mas[indexofmin] = temp;

            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write(mas[i] + " ");
            }
        }
    }
}

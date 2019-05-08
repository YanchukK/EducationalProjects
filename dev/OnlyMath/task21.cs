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
            // 21. Считать с клавиатуры строку, разбить по
            // точке с запятой. Элементы сложить в массив

            Console.Write("Enter the string: ");
            string str = Console.ReadLine();

            int number = 1;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ';')
                {
                    number++;
                }
            }

            string[] array = new string[number];

            int j = 0;

            for (int k = 0; k < str.Length; k++)
            {
                if (str[k] == ';')
                {
                    k++;
                    j++;
                    array[j] += str[k];
                }
                else
                {
                    array[j] += str[k];
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}

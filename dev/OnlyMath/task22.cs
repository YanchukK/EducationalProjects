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
            // 22. Считать с клавиатуры строку в которой через
            // запятую введены числа и разложить их в числовой массив

            Console.Write("Enter the string: ");
            string str = Console.ReadLine();

            int number = 1;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ',')
                {
                    number++;
                }
            }

            string[] array = new string[number];

            int j = 0;

            for (int k = 0; k < str.Length; k++)
            {
                if (str[k] == ',')
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

            int[] arrayint = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                arrayint[i] = int.Parse(array[i]);
                Console.WriteLine(arrayint[i]);
            }
        }
    }
}

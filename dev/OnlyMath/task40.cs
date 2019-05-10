using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire
{
    class Program
    {
        static void Main(string[] args)
        {
            // 40. Отсортировать массив из 39. Пузырьком.

            Console.Write("Enter the length: ");
            int length = int.Parse(Console.ReadLine());

            Console.Write("Enter the value of the maximum element: ");
            int max = int.Parse(Console.ReadLine());

            Random random = new Random();

            int[] array = new int[length]; // результирующий массив, где сразу проверяется,
                                           // существует ли уже такое сгенерированное число
            int v = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (!IsContains(array, v = random.Next(max - length, max), i))
                {
                    array[i] = v;
                }
                else
                {
                    i--;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();

            v = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < length - 1 - i; j++) 
                {
                    if (array[j] > array[j + 1])
                    {
                        v = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = v;
                    }
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            bool IsContains(int[] array1, int value, int index)
            {
                for (int i = 0; i < index; i++)
                {
                    if (array1[i] == value)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}

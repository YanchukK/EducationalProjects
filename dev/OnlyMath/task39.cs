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
            // 39.Считать с клавиатуры 2 числа, 1е(length) - длина массива,
            // 2е(max) значение максимального элемента массива. 
            // Сгенерировать такой массив чтобы в нем были все элементы
            // от max - length до max, но в произвольном порядке   

            Console.Write("Enter the length: ");
            int length = int.Parse(Console.ReadLine());

            Console.Write("Enter the value of the maximum element: ");
            int max = int.Parse(Console.ReadLine());

            Random random = new Random();

            int[] array = new int[length]; // результирующий массив, где проверяется, существует
                                           // ли уже такое сгенерированное число
            int v = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (IsEquals(v = random.Next(max - length, max), 0))
                {
                    //mixedcards[i] = cards[v];
                    array[i] = v;
                }
                else if (!IsContains(array, v = random.Next(max - length, max), (i + 1)))
                {
                    //mixedcards[i] = cards[v];
                    array[i] = v;
                }
                else
                {
                    i--;
                }
            }

            bool IsEquals(int v1, int v2)
            {
                if (v1 == v2)
                {
                    return true;
                }
                return false;
            }

            bool IsContains(int[] array1, int value, int index)
            {
                for (int i = 0; i < array1.Length; i++)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire
{
    struct MyStruct
    {
        public string FirstString;
        public string SecondString;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 23. Считать с клавиатуры массив строк заданной 
            // пользователем длины. Каждая из строк содержит
            // точки с запятой. Разбить по ним и сложить в массив структур.

            Console.Write("Input size of array: ");
            string[] array = new string[int.Parse(Console.ReadLine())];

            Console.WriteLine("Fill the array:");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Console.ReadLine();
            }

            int j = 0; // счетчик для подсчета элемента результирующего массива
            int s = 0; // счетчик для подсчета элемента структуры
            MyStruct[] myStructs = new MyStruct[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                string[] result = new string[2];
                for (int k = 0; k < array[i].Length; k++)
                {
                    if (array[i][k] == ';')
                    {
                        k++;
                        j++;
                        //i++;
                        result[j] += array[i][k];
                    }
                    else
                    {
                        result[j] += array[i][k];
                    }
                }
                j = 0;
                myStructs[s] = new MyStruct { FirstString = result[0], SecondString = result[1] };
                s++;
            }
        }
    }
}

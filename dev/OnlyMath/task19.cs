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
            Console.Write("Input size of array: ");
            string[] array = new string[int.Parse(Console.ReadLine())];

            Console.WriteLine("Fill the array");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Console.ReadLine();
            }

            Console.Write("Input the word: ");
            string word = Console.ReadLine();

            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] == word[counter])
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }

                    if (counter == word.Length)
                    {
                        Console.WriteLine(j - (word.Length - 1));
                        Console.WriteLine(array[i]);
                    }
                }
                counter = 0;
            }
        }
    }
}

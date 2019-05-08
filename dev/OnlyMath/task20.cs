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
            // 20. Считать с клавиатуры массив строк заданного пользователем размера.
            // Считать еще одну строку, удалить из всех строк вхождение данной строки

            Console.Write("Input size of array: ");
            string[] array = new string[int.Parse(Console.ReadLine())];

            Console.WriteLine("Fill the array:");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Console.ReadLine();
            }

            Console.Write("Input the word: ");
            string word = Console.ReadLine();

            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                index = IndexOfSubstring(array[i], word);
                if (index != 0)
                {
                    index -= (word.Length + 1);
                    Console.WriteLine(Delete(array[i], index, word.Length));
                }
            }

            string Delete(string str, int ind, int number) // возвращает строку без подтроки
            {
                string result = "";

                for (int i = 0; i < str.Length; i++)
                {
                    if (i == ind)
                    {
                        i += number - 1;
                    }
                    else
                    {
                        result += str[i];
                    }
                }

                return result;
            }

            int IndexOfSubstring(string main, string substring) // возвращает индекс последнего вхождения подстроки
            {
                int counter = 0;

                int cj = 0;

                for (int i = 0; i < main.Length; i++)
                {
                    if (main[i] == substring[counter])
                    {
                        cj = i;
                        counter++;
                    }
                    else
                    {
                        counter = 0;
                    }

                    if (counter == substring.Length)
                    {
                        counter = cj;
                        return counter;
                    }
                }
                return counter;
            }
        }
    }
}

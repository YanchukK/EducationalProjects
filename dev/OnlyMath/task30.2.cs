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
            // 30. Вывести название библиотеки содержащую книги большего числа авторов.
            // название библиотеки где большее число авторов.
            // Предполагается, что авторы разделены запятой

            string[] array = File.ReadAllLines("text1.txt");

            int numberOfLibraries = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i][0] == 'N')
                {
                    numberOfLibraries++;
                }
            }

            string[] libraries = new string[numberOfLibraries];
            int[] authors = new int[numberOfLibraries]; // количество авторов в каждой библиотеке

            int l = 0; // счетчик библиотек

            for (int i = 0; i < array.Length; i++)
            {
                int b = 0; // счетчик книг в библиотеке

                if (array[i][0] == 'N')
                {
                    libraries[l] = TextAfterEquals(array[i]);
                }
                else
                {
                    while (i < array.Length && array[i][0] == 'B')
                    {
                        b += CountOfAuthor(array[i]);                        
                        i++;
                    }
                    authors[l] = b;
                    i--;
                    l++;
                }
            }

            int resultindex = 0;
            int d = 0;

            for (int i = 0; i < authors.Length; i++)
            {
                if (authors[i] > d)
                {
                    d = authors[i];
                    resultindex = i;
                }
            }

            // Вывод для проверки
            Console.WriteLine(libraries[resultindex]);

            string TextAfterEquals(string str)
            {
                int j = 0; // счетчик для подсчета элемента результирующего массива

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] != '=')
                    {
                        j++;
                    }
                    else
                    {
                        i = str.Length;
                    }
                }

                j++;
                string result = "";

                for (int i = j; i < str.Length - 1; i++)
                {
                    result += str[i];
                }
                return result;
            }

            int CountOfAuthor(string main) // возвращает индекс последнего вхождения подстроки
            {
                int counter = 1;

                for (int i = 0; i < main.Length; i++)
                {
                    if (main[i] == ',')
                    {
                        counter++;
                    }
                    else if (main[i] == ';')
                    {
                        i = main.Length;
                    }
                }

                return counter;
            }
        }
    }
}

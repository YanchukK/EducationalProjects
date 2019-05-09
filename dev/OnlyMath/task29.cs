using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire
{
    enum Janre
    {
        Professional = 1,
        Imaginative
    }

    struct Book
    {
        public string Author;
        public int PageCount;
        public Janre Janre;
    }

    struct Library
    {
        public string Name;
        public Book[] Book;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 29. Вывести название библиотеки с наибольшим числом книг

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
            int[] index = new int[numberOfLibraries];

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
                        b++;
                        i++;
                    }
                    index[l] = b;
                    i--;
                    l++;
                }
            }
            
            int resultindex = 0;
            int d = 0;

            for (int i = 0; i < index.Length; i++)
            {
                if (index[i] > d)
                {
                    d = index[i];
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
                    if (str[i] != '=' )
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
        }
    }
}

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
        public int numberOfReadingRooms;
        public Book[] Book;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 28. Создать файл описывающий несколько библиотек
            // и считать данные из него в массив структур.

            string[] array = File.ReadAllLines("text.txt");

            int numberOfLibraries = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i][0] == 'R')
                {
                    numberOfLibraries++;
                }
            }
            
            Library[] libraries = new Library[numberOfLibraries];

            int l = 0; // счетчик библиотек

            for (int i = 0; i < array.Length; i++)
            {
                int b = 0; // счетчик книг в библиотеке

                if (array[i][0] == 'R')
                {
                    libraries[l].numberOfReadingRooms = int.Parse(TextAfterEquals(array[i]));
                }
                else
                {
                    while (i < array.Length && array[i][0] == 'B')
                    {
                        b++;
                        i++;
                    }

                    i -= b;

                    libraries[l].Book = new Book[b];

                    for (int j = 0; j < b; j++)
                    {
                        libraries[l].Book[j] = TextForBook(array[i]);
                        i++;
                    }
                    i--;
                    l++;
                }
            }

            Book TextForBook(string str1)
            {
                Book book = new Book();
                str1 = TextAfterEquals(str1);

                string[] result = new string[3];

                int j = 0;

                for (int k = 0; k < str1.Length; k++)
                {
                    if (str1[k] == ';')
                    {
                        k++;
                        j++;
                        result[j] += str1[k];
                    }
                    else
                    {
                        result[j] += str1[k];
                    }
                }

                book.Author = result[0];
                book.PageCount = int.Parse(result[1]);
                book.Janre = (Janre)int.Parse(result[2]);

                return book;
            }

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



            // Вывод на экран для проверки
            for (int i = 0; i < libraries.Length; i++)
            {
                Console.WriteLine("Reading Rooms\t" + libraries[i].numberOfReadingRooms);
                for (int j = 0; j < libraries[i].Book.Length; j++)
                {
                    Console.WriteLine("Author\t\t" + libraries[i].Book[j].Author);
                    Console.WriteLine("Page Count\t" + libraries[i].Book[j].PageCount);
                    Console.WriteLine("Janre\t\t" + libraries[i].Book[j].Janre);
                }
                Console.WriteLine();
            }
        }
    }
}

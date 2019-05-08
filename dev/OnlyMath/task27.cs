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
            // 27. Описать библиотеку структурой.
            // Придумать способ хранения данных библиотеке в файле.

            Library library;

            Console.Write("Number of reading rooms: ");
            library.numberOfReadingRooms = int.Parse(Console.ReadLine());

            Console.Write("Number of books: ");
            int numberOfBooks = int.Parse(Console.ReadLine());

            library.Book = new Book[numberOfBooks];
            string libraryStr = $"ReadingRooms={library.numberOfReadingRooms};\n";

            for (int i = 0; i < numberOfBooks; i++)
            {
                library.Book[i] = new Book
                {
                    Author = Console.ReadLine(),
                    PageCount = int.Parse(Console.ReadLine()),
                    Janre = (Janre)int.Parse(Console.ReadLine())
                };

                libraryStr += $"Book{i+1}={library.Book[i].Author};{library.Book[i].PageCount};{(int)library.Book[i].Janre};\n";
            }
            
            File.WriteAllText("text.txt", libraryStr);
        }
    }
}

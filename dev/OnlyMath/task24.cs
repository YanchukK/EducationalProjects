using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire
{
    enum Janre
    {
        Professional
    }

    struct Book
    {
        public string Author;
        public int PageCount;
        public Janre Janre;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 24. Описать структурой книгу. Вывести данные книги на экран

            Book book = new Book()
            {
                Author = "Jeffrey Richter",
                PageCount = 6874684,
                Janre = Janre.Professional
            };

            string bookStr = $"Author={book.Author};Pages={book.PageCount};Janre={book.Janre}";

            Console.WriteLine(bookStr);
        }
    }
}

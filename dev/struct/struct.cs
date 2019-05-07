using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painting
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
            Book book = new Book
            {
                Author = "J.Richter",
                PageCount = 456,
                Janre = Janre.Professional
            };

            string bookStr = $"Author={book.Author};Pages={book.PageCount}"


        }
    }
}

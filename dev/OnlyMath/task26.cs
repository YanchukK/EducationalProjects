using System;
using System.Collections.Generic;
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

    class Program
    {
        static void Main(string[] args)
        {
            // 26. Придумать способ сохранения массива книг в строке.
            // Считать информацию о книгах с клавиатуры и заполнить
            // в массив структур

            Console.Write("How many books? ");
            int numberOfBooks = int.Parse(Console.ReadLine());

            Book[] books = new Book[numberOfBooks];

            for (int i = 0; i < numberOfBooks; i++)
            {
                Console.Write("Enter the author{i}: ");
                string author = Console.ReadLine();

                Console.Write("Enter the number of pages: ");
                int pageCount = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the janre\n1 if it is Professional literature\n2 if it is imaginative literature");
                int janre = int.Parse(Console.ReadLine());

                books[i] = new Book { Author = author, PageCount = pageCount, Janre = (Janre)janre };
                string bookStr = $"Author={books[i].Author};Pages={books[i].PageCount};Janre={(int)books[i].Janre}";
            }
        }
    }
}

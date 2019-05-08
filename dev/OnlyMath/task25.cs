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
            // 25. Придумать способ сохранить данные о книги в одной строке. 
            // Считать информацию о книге с клавиатуры и заполнить в структуру

            Console.Write("Enter the author: ");
            string author = Console.ReadLine();

            Console.Write("Enter the number of pages: ");
            int pageCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the janre\n1 if it is Professional literature\n2 if it is imaginative literature");
            int janre = int.Parse(Console.ReadLine());

            Book book = new Book { Author = author, PageCount = pageCount, Janre = (Janre)janre };
        }
    }
}

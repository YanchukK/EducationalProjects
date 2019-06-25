using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedControl
{
    class Program
    {
        class Book
        {
            public string Name;
            public int Year;
        }

        class BookWithAuthor
        {
            public string Author { get; set; }
            public string Name { get; set; }
        }

        static bool IsLeapYear(int year)
        {
            bool div1 = year % 4 == 0;
            bool div2 = year % 100 != 0;
            bool div3 = year % 400 == 0;
            return ((div1 && div2) || div3);
        }

        static void Main(string[] args)
        {
            var books = new List<Book>() {
                        new Book() { Name = "Guards! Guards!", Year = 1810 },
                        new Book() { Name="Finders Keepers", Year = 2002 },
                        new Book() { Name="Finders LINQ Keepers", Year = 2016 }
                    };

            // Выберите все книги, в названии которых есть слово LINQ, а год издания высокосный
            var resultBooks = books.Where(f => f.Name.Contains("LINQ") && IsLeapYear(f.Year));

            // Дана последовательность русских слов.
            // Сколько букв алфавита понадобилось для написания этих слов
            Console.OutputEncoding = Encoding.UTF8; // Поддержка кириллицы
            string[] words = { "Ниссан", "Альфа Ромео", "БМВ"};
            var countOfLetters = words.SelectMany(f => f.Trim().ToArray()).ToArray().Distinct().Count();


            // Дан массив целых двузначных чисел. Упорядочить их по возрастанию
            // старшего разряда, а затем по убыванию младшего, например { 14, 12, 23, 20, 33, 32 }

            int[] array = { 32, 12, 14, 33, 23, 20 };

            var newarray = array.OrderBy(f => f).GroupBy(f => f%10);


            // Дан массив книг books. Сколько книг написал каждый автор (два столбца: Автор, Количество)
            var newBooks = new List<BookWithAuthor>() {
                        new BookWithAuthor() { Author = "Terry Pratchett", Name = "Guards! Guards!" },
                        new BookWithAuthor() { Author = "Stephen King", Name="Finders Keepers" },
                        new BookWithAuthor() { Author = "Stephen King", Name="Finders Keepers" }
                    };

            var authorAndNumberOfBooks = newBooks.GroupBy(f => f.Author).Select(f => f.Key + ", " + f.Count());
        }
    }
}

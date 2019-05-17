using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutClass
{ 
    class Program
    {
        class Book
        {
            // Класс Книга - аффтор, текст, год издания, название, кол-во страниц.

            private string author;
            private string name;
            private string text;
            private int yearOfPublishing;
            private int numberOfPages;

            public Book(string author, string name, string text, int yearOfPublishing, int numberOfPages)
            {
                SetAuthor(author);
                SetName(name);
                SetText(text);
                SetYear(yearOfPublishing);
                SetPages(numberOfPages);
            }

            private void SetPages(int value)
            {
                if (value > 0)
                {
                    this.numberOfPages = value;
                }
                else
                {
                    Console.WriteLine("Nice try");
                }
            }

            private void SetYear(int value)
            {
                if (value >= 1800)
                {
                    this.yearOfPublishing = value;
                }
                else
                {
                    Console.WriteLine("Nice try");
                }
            }

            private void SetText(string value)
            {
                if (value != "")
                {
                    this.text = value;
                }
                else
                {
                    Console.WriteLine("Nice try");
                }
            }

            private void SetAuthor(string value)
            {
                if (value != "")
                {
                    this.author = value;
                }
                else
                {
                    Console.WriteLine("Nice try");
                }
            }

            private void SetName(string value)
            {
                if(value != "")
                {
                    this.name = value;
                }
                else
                {
                    Console.WriteLine("Nice try");
                }
            }

            public string GetName()
            {
                return name;
            }
        }

       
        class Bookcase
        {
            class Shelf
            {
                // Класс Полка -содержит Книги, можно положить книгу
                // и взять ее по названию. У нее есть фиксированный размер.

                private int number = 0; // количество книг на полке

                Book[] books;

                public Shelf(int numberOfBooks)
                {
                    SetBooks(numberOfBooks);
                }

                public void SetBooks(int value)
                {
                    if (value > 0)
                    {
                        books = new Book[value];
                    }
                    else
                    {
                        Console.WriteLine("Nice try");
                    }
                }

                public void AddBook(Book book)
                {
                    books[number] = book;
                    number++;
                }

                public Book GetBook(string Name)
                {
                    Book book = null;

                    for (int i = 0; i < number; i++)
                    {
                        if (books[i].GetName() == Name)
                        {
                            book = books[i];
                        }
                    }
                    return book;
                }
            }

            // Класс шкаф - содержит полки, содержит фиксированное
            // количество полок. Позволяет брать и класть книгу.

            Shelf[] shelves /*= new Shelf[0]*/;

            public Bookcase(int numberOfShelves, int numberOfBooks)
            {
                SetShelves(numberOfShelves, numberOfBooks);
            }

            private void SetShelves(int numberOfShelves, int numberOfBooks)
            {
                if (numberOfShelves > 0 && numberOfBooks > 0)
                {
                    shelves = new Shelf[numberOfShelves];

                    for (int i = 0; i < numberOfShelves; i++)
                    {
                        shelves[i] = new Shelf(numberOfBooks);
                    } 
                }
                else
                {
                    Console.WriteLine("Nice try");
                }
            }

            public void AddBook(Book book, int shelfId)
            {
                if (shelfId > shelves.Length)
                {
                    Console.WriteLine("Nice try");
                }
                else
                {
                    shelves[shelfId - 1].AddBook(book);
                }
            }

            public Book GetBook(string name)
            {
                Book book = null;

                for (int i = 0; i < shelves.Length; i++)
                {
                    book = shelves[i].GetBook(name);
                }

                return book;
            }
        }

        static void Main(string[] args)
        {
            // Класс шкаф - содержит полки, содержит фиксированное
            // количество полок. Позволяет брать и класть книгу.

            Bookcase bookcase = new Bookcase(2, 5);

            Book book1 = new Book("author1", "name1", "text1", 1900, 100);
            Book book2 = new Book("author2", "name2", "text2", 2000, 200);

            bookcase.AddBook(book1, 2);
            bookcase.AddBook(book2, 1);

            Book book3 = bookcase.GetBook("name1");       
        }
    }
}

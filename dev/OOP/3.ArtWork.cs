using System;

namespace Millionaire
{
    // 3. Book, Author, Newspaper, Song, ArtWork, J. R. R. Tolkien, Lord of the rings
    // Newspaper - произведение искусства?

    // ArtWork - произведение искусства. Нужно ли поле автор?
    class ArtWork
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public Author Author { get; set; }

        public ArtWork(string name, int year, Author author)
        {
            Name = name;
            Year = year;
            Author = author;
        }

        public virtual void Display()
        {
            Console.WriteLine($"{Name} was created in {Year} year by {Author.Name}");
        }
    }

    class Book : ArtWork
    {
        public string Genre { get; set; }

        public Book(string name, int year, string genre, Author author) : base(name, year, author)
        {
            this.Genre = genre;
        }

        public override void Display()
        {
            Console.WriteLine($"Book \"{Name}\" is a {Genre}. This book was created in {Year} year by {Author.Name}");
        }
    }

    class Song : ArtWork
    {
        public Song(string name, int year, Author author) : base(name, year, author)
        { }

        public override void Display()
        {
            Console.WriteLine($"Song {Name} was created in {Year} year by {Author.Name}");
        }
    }


    class Author
    {
        public string Name { get; set; }

        private ArtWork[] artWorks;

        public Author(string name)
        {
            Name = name;
        }

        public void AddArtWork(ArtWork artWork)
        {
            if (artWorks == null)
            {
                artWorks = new ArtWork[] { artWork };
            }
            else
            {
                ArtWork[] newArtWorks = new ArtWork[artWorks.Length + 1];

                int i = 0;
                while (i != (newArtWorks.Length - 1))
                {
                    newArtWorks[i] = artWorks[i];
                    i++;
                }

                newArtWorks[newArtWorks.Length - 1] = artWork;

                artWorks = newArtWorks;
            }
        }

        public void DisplayAllArtWorks()
        {
            for (int i = 0; i < artWorks.Length; i++)
            {
                artWorks[i].Display();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Author Tolkien = new Author("J. R. R. Tolkien");

            Book book = new Book("Lord of the rings", 1954, "Fantasy", Tolkien);

            Tolkien.AddArtWork(book);

            Tolkien.DisplayAllArtWorks();
        }
    }
}
}

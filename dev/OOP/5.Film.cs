using System;

namespace Millionaire
{

    // Artwork - произведение искусства
    public class ArtWork
    {
        public string Name { get; set; }
        public int Year { get; set; }

        public ArtWork(string name, int year)
        {
            Name = name;
            Year = year;
        }

        public virtual void Display()
        {
            Console.WriteLine($"\"{Name}\" was created in {Year} year");
        }
    }

    public class Book : ArtWork
    {
        public string Genre { get; set; }

        public Book(string name, int year, string genre) : base(name, year)
        {
            this.Genre = genre;
        }

        public override void Display()
        {
            Console.WriteLine($"Book \"{Name}\" is a {Genre}. This book was created in {Year} year");
        }
    }

    // Director - режиссер
    public class Director
    {
        public string Name { get; set; }

        public Film[] films;

        public Director(string name)
        {
            Name = name;
        }

        public void AddFilms(Film film)
        {
            if (films == null)
            {
                films = new Film[] { film };
            }
            else
            {
                Film[] newFilms = new Film[films.Length + 1];

                int i = 0;
                while (i != (newFilms.Length - 1))
                {
                    newFilms[i] = films[i];
                    i++;
                }

                newFilms[newFilms.Length - 1] = film;

                films = newFilms;
            }
        }

        public void DisplayAllArtWorks()
        {
            for (int i = 0; i < films.Length; i++)
            {
                films[i].Display();
            }
        }
    }


    public struct Work
    {
        public Film film;
        public string role;
    }

    public class Actor
    {
        public string Name { get; set; }
        public Work[] works;

        public Actor(string name)
        {
            this.Name = name;
        }

        public void Display(Film film)
        {
            foreach (var item in works)
            {
                if (item.film == film)
                {
                    Console.WriteLine($"{Name} play {item.role} in {item.film.Name}");
                }
            }
        }

        public void AddWork(Film film, string role)
        {
            Work work = new Work();
            work.film = film;
            work.role = role;

            if (works == null)
            {
                works = new Work[] { work };
            }
            else
            {
                Work[] newWorks = new Work[works.Length + 1];

                int i = 0;
                while (i != (newWorks.Length - 1))
                {
                    newWorks[i] = works[i];
                    i++;
                }

                newWorks[newWorks.Length - 1] = work;

                works = newWorks;
            }
        }
    }

    public struct Worker
    {
        public Actor actor;
        public string role;
    }

    public class Film : ArtWork
    {
        public Worker[] workers;
        public Director Director { get; set; }
        public Book Book { get; set; } // необязательный параметр

        public Film(string name, int year, Director director) : base(name, year)
        {
            this.Director = director;
        }

        public Film(string name, int year, Book book, Director director) : base(name, year) // если фильм создан на основе книги
        {
            this.Book = book;
            this.Director = director;
        }

        public void AddActor(string role, Actor actor)
        {
            Worker worker = new Worker();
            worker.actor = actor;
            worker.role = role;

            if (workers == null)
            {
                workers = new Worker[] { worker };
            }
            else
            {
                Worker[] newWorkers = new Worker[workers.Length + 1];

                int i = 0;
                while (i != (newWorkers.Length - 1))
                {
                    newWorkers[i] = workers[i];
                    i++;
                }

                newWorkers[newWorkers.Length - 1] = worker;

                workers = newWorkers;
            }
        }

        public override void Display()
        {
            Console.WriteLine($"Film \"{Name}\" was created in {Year} year by {Director.Name}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // 5. Pulp fiction, H8tfull eight, Director, Film, Book, Artwork, Actor, Role

            Director QuentinTarantino = new Director("Quentin Tarantino");

            Film PulpFiction = new Film("Pulp Fiction", 1994, QuentinTarantino);
            Film H8tfullEight = new Film("H8tfull eight", 2015, QuentinTarantino);

            QuentinTarantino.AddFilms(PulpFiction);
            QuentinTarantino.AddFilms(H8tfullEight);

            QuentinTarantino.DisplayAllArtWorks();
        }
    }
}

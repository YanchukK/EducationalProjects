using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Painting
{
    class Actor
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }

    abstract class ArtObject
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }

    class Film : ArtObject
    {
        public int Length { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }

    class Book : ArtObject
    {
        public int Pages { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<object>() {
                        "Hello",
                        new Book() { Author = "Terry Pratchett", Name = "Guards! Guards!", Pages = 810 },
                        new List<int>() {4, 6, 8, 2},
                        new string[] {"Hello inside array"},
                        new Film() { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
                            new Actor() { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                            new Actor() { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                            new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
                        }},
                        new Film() { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
                            new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                            new Actor() { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
                        }},
                        new Book() { Author = "Stephen King", Name="Finders Keepers", Pages = 200},
                        new Book() { Author = "Stephen King", Name="Finders Keepers", Pages = 200},
                        "Leonardo DiCaprio"
                    };


            // 1. Output all elements excepting ArtObjects
            //foreach (var item in data.Except(data.OfType<ArtObject>()))
            //{
            //    Console.WriteLine(item);
            //}


            // 2. Output all actors names
            //Console.WriteLine(string.Join(Environment.NewLine, data.OfType<Film>().SelectMany(f => f.Actors).Select(k => k.Name)));

            // 3. Output number of actors born in august
            //Console.WriteLine(data.OfType<Film>().SelectMany(f => f.Actors).
            //    Where(f => f.Birthdate.Month == 8).Count());

            // 4. Output two oldest actors names
            //Console.WriteLine(string.Join(Environment.NewLine, data.OfType<Film>()
            //    .SelectMany(f => f.Actors).OrderBy(f => f.Birthdate).Select(f => f.Name).Take(2)));

            // 5. Output number of books per authors
            //Console.WriteLine(string.Join(Environment.NewLine,
            //    data.OfType<Book>().GroupBy(f => f.Author).Select(f => f.Key + ": " + f.Count())));
            
            // 6. Output number of books per authors and films per director
            //Console.WriteLine(string.Join(Environment.NewLine,
            //    data.OfType<ArtObject>().GroupBy(f => f.Author).Select(f => f.Key + ": " + f.Count())));

            
        }
    }
}

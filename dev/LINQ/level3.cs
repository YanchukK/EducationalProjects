    class Film
    {
        public string Name { get; set; }
        public string Director { get; set; }
    }

    class Director
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    
    //List<Film> films = new List<Film>()
    //{
    //    new Film { Name = "The Silence of the Lambs", Director ="Jonathan Demme" },
    //    new Film { Name = "The World's Fastest Indian", Director ="Roger Donaldson" },
    //    new Film { Name = "The Recruit", Director ="Roger Donaldson" }
    //};
    //List<Director> directors = new List<Director>()
    //{
    //    new Director { Name="Jonathan Demme", Country="USA"},
    //    new Director { Name="Roger Donaldson", Country="New Zealand" },
    //};
    // 4. Output all films in such format: FilmName DirectorName(DirectorCountry)
    //Console.WriteLine(string.Join(Environment.NewLine,
    //    films.Join(directors,
    //    f => f.Director,
    //    d => d.Name,
    //    (f, d) => new { filmName = f.Name, directorName = d.Name, directorCountry = d.Country }).
    //    Select(x => x.filmName + " - " + x.directorName + " (" + x.directorCountry + ")")));

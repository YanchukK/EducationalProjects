using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW_Lesson
{

    public class Player
    {
        [Key]
        public virtual int PlayerId { get; set; }

        [Required]
        public string PlayerName { get; set; }

        [Required]
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }

    public class Team
    {
        [Key]
        public virtual int TeamId { get; set; }

        [Required]
        public string TeamName { get; set; }
        [Required]
        public string City { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }

    public class Match
    {
        [Key]
        public int MatchId { get; set; }
        [Required]
        public string Stadium { get; set; }
        [Required]
        public int TeamAId { get; set; }
        public Team TeamA { get; set; }
        [Required]
        public int TeamBId { get; set; }
        public Team TeamB { get; set; }
        [Required]
        public int TeamAScore { get; set; }
        [Required]
        public int TeamBScore { get; set; }
    }


    public class DatabaseControlContext : DbContext
    {
        public DatabaseControlContext()
          : base("test")
        {
            Database.Log += (str) => Console.WriteLine(str);
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Person>().HasKey(p => p.Id);

        //    modelBuilder.Entity<Team>()
        //      .HasMany(p => p.Players) //    *
        //      .WithRequired(p => p.Team); // 1
        //}

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
    }

    class Program
    {

        static void Main(string[] args)
        {

            using (var context = new DatabaseControlContext())
            {
                var teamA = new Team { TeamId = 1, TeamName = "Newcastle", City = "Sutton Coldfield" };
                var teamB = new Team { TeamId = 2, TeamName = "Mount Eliza", City = "Milton Keynes" };

                context.Teams.Add(teamA);
                context.Teams.Add(teamB);
                context.SaveChanges();
                
                // создаем два объекта User
                //User user1 = new User { Name = "Tom", Age = 33 };
                //User user2 = new User { Name = "Sam", Age = 26 };

                //// добавляем их в бд
                //db.Users.Add(user1);
                //db.Users.Add(user2);
                //db.SaveChanges();
                //Console.WriteLine("Объекты успешно сохранены");

                //// получаем объекты из бд и выводим на консоль
                //var users = db.Users;
                //Console.WriteLine("Список объектов:");
                //foreach (User u in users)
                //{
                //    Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Age);
                //}
            }

            //using (var context = new DatabaseControlContext())
            //{

            //var john = context.Persons.Add(new Person() { Name = "John", Age = 22, Gender = GenderType.Some, Orders = new List<Order>() });
            //john.Orders.Add(new Order() { Cost = 100, CreatingDate = DateTime.Now });
            //john.Orders.Add(new Order() { Cost = 200, CreatingDate = DateTime.Now });
            //context.SaveChanges();

            //var orders = new List<Order>() {
            //  new Order() { Cost = 100, CreatingDate = DateTime.Now, PersonId = 1 },
            //  new Order() { Cost = 200, CreatingDate = DateTime.Now, PersonId = 1 }
            //};
            //var all = context.Persons
            //  .Join(context.Orders, o => o.Id, i => i.PersonId, (p, i) => new { p, i })
            //  .ToList();

            //var john = context.Persons
            //  .Include(p => p.Orders).AsNoTracking()
            //  .FirstOrDefault(x => x.Name == "John");

            //context.Entry(john)
            //  .Collection(p => p.Orders)
            //  .Load();

            //var orders = john.Orders;
            //var all = context.Persons.ToList();
            //}
        }
    }
}

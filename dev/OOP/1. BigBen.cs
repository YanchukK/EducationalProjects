using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Wall
    {
        public int Hight { get; set; }
        public int Width { get; set; }

        public Wall(int h, int w)
        {
            Hight = h;
            Width = w;
        }

        public virtual void Stand()
        {
            Console.WriteLine($"{this.ToString().Substring(4)} stands");
        }
    }

    class Roof
    {
        public int Hight { get; set; }
        public int Width { get; set; }

        public Roof(int h, int w)
        {
            Hight = h;
            Width = w;
        }

        public virtual void Stand()
        {
            Console.WriteLine($"{this.ToString().Substring(4)} stands");
        }
    }

    class House
    {
        public Roof roof;
        public Wall[] walls;

        public House(int h, int w)
        {
            roof = new Roof(h, w);
            InitialiseWalls(h, w);
        }
        
        public Roof GetRoof()
        {
            return roof;
        }

        private void InitialiseWalls(int h, int w)
        {
            walls = new Wall[4]
            {
                new Wall(h, w),
                new Wall(h, w),
                new Wall(h, w),
                new Wall(h, w)
            };
        }

        public virtual void Stand()
        {
            Console.WriteLine($"{this.ToString().Substring(4)} stands");
        }
    }

    class BigBen : House
    {
        public BigBen(int h, int w) : base(h, w)
        {

        }

        public override void Stand()
        {
            base.Stand();
        }
    }

    class EiffelTower : House
    {
        public EiffelTower(int hight, int w) : base(hight, w)
        {

        }

        public override void Stand()
        {
            base.Stand();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BigBen bigBen = new BigBen(10, 20);
            bigBen.Stand();
            Console.WriteLine(bigBen.roof.Hight);
        }
    }
}

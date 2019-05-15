using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutClass
{
    class Number
    {
        private int x; // числитель
        private int y; // знаменатель

        public Number(int x, int y)
        {
            SetAll(x, y);
        }

        public void SetAll(int x, int y)
        {
            SetX(x);
            SetY(y);
        }

        public void SetX(int value)
        {
            x = value;
        }

        public void SetY(int value)
        {
            if (value != 0)
            {
                y = value;
            }
            else
            {
                Console.WriteLine("no");
            }
        }

        public double ReturnDouble()
        {
            return (double)x / y;
        }

        public string Print()
        {
            string minus = "";
            if (x < 0 || y < 0)
            {
                minus = "-";
                x = Math.Abs(x);
                y = Math.Abs(y);
            }

            if (x > y)
            {
                minus += x / y;
            }

            x = x - (x / y) * y;

            int nod = Nod(x, y);

            if (nod != 0)
            {
                x /= nod;
                y /= nod;
            }

            minus += $" {x}/{y}";

            return minus;
        }

        private int Nod(int n, int d)
        {
            while (d != 0 && n != 0)
            {
                if (n % d > 0)
                {
                    var temp = n;
                    n = d;
                    d = temp % d;
                }
                else break;
            }
            if (d != 0 && n != 0)
                return d;
            return 0;
        }

        public void Sum(int value)
        {
            x += y * value;
        }

        public void Sum(Number value)
        {
            if (y == value.y)
            {
                x += value.x;
            }
            else
            {
                x = value.x * y + value.y * x;
                y = value.y * y;
            }
        }

        public void Dif(int value)
        {
            x -= value * y;
        }

        public void Dif(Number value)
        {
            x = value.y * x - value.x * y;
            y = value.y * y;
        }

        public void Product(int value)
        {
            x *= value;
        }

        public void Product(Number value)
        {
            x *= value.x;
            y *= value.y;
        }

        public void Div(int value)
        {
            y *= value;
        }

        public void Div(Number value)
        {
            x *= value.y;
            y *= value.x;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Number number = new Number(46, 25);

            Number number1 = new Number(2, 50);

            number.Sum(number1);

            Console.WriteLine(number.Print());
        }
    }
}

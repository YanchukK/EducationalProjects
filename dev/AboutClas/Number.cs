using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire
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
            if(x < 0 || y < 0)
            {
                minus = "-";
                if(x < 0)
                {
                    x *= -1;
                }
                if (y < 0)
                {
                    y *= -1;
                }
            }

            if(x > y)
            {
                minus += x/y;
            }

            // сократить
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
            Number number = new Number(1, 2);

            Number number1 = new Number(2, 2);

            number.Sum(-11);

            Console.WriteLine(number.Print());

        }
    }
}

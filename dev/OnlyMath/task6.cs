using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire
{
    class Program
    {
        // Считать с клавиатуры число и вывести все его цифры отдельно

        static void Main(string[] args)
        {
            string ns = Console.ReadLine();

            int n = int.Parse(ns);

            while (n > 0)
            {
                Console.WriteLine(n%10);
                n /= 10;
            }
        }
        
        
        
        
        // правильный вариант
        static void Main(string[] args)
        {
            string ns = Console.ReadLine();

            int x = int.Parse(ns);
            int y = x;
            int d = 10;

            while (y > 0)
            {
                y = y / 10;
                if(y > 0)
                {
                    d = d * 10;
                }
            }

            d = d / 10;

            while (d > 0)
            {
                Console.WriteLine(x / d % 10);
                d /= 10;
            }
        }        
    }
}

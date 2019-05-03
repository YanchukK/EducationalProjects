using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire
{
    class Program
    {
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
    }
}

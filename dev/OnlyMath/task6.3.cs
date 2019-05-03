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

            int result = n%10;

            while (n!=0)
            {
                if (n%10 < result)
                {
                    result = n % 10;
                }
                n /= 10;
            }

            Console.WriteLine(result);
        }
    }
}

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

            float n = float.Parse(ns);

            int ni = (int)n;
            Console.WriteLine(ni);

            float nii = n - ni;
            Console.WriteLine(nii);

        }
    }
}

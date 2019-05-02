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
            // онли математика

            string number = Console.ReadLine();

            int i = 0;
            while (i < number.Length)
            {
                Console.WriteLine(number[i]);
                i++;
            }

            number = Console.ReadLine();
            i = 0;

            int index = number.IndexOf('.'); // равно 4
            while (i < index)
            {
                Console.Write(number[i]);
                i++;
            }
            Console.WriteLine();
            i++;
            while (i < number.Length)
            {
                Console.Write(number[i]);
                i++;
            }

            Console.WriteLine();

            number = Console.ReadLine(); // длина 3
            int intnumber = int.Parse(number); //456

            int[] a = new int[number.Length];

            switch (number.Length)
            {
                case 2:
                    a[0] = intnumber / 10;
                    a[1] = intnumber - (a[0] * 10);
                    break;
                case 3:
                    a[0] = intnumber / 100;
                    a[1] = (intnumber / 10) - (a[0] * 10);
                    a[2] = intnumber - ((intnumber / 10) * 10);
                    break;
                case 4:
                    a[0] = intnumber / 1000;
                    a[1] = (intnumber / 100) - (a[0] * 10);
                    a[2] = (intnumber / 10) - ((intnumber / 100) * 10);
                    a[3] = intnumber - ((intnumber / 10) * 10);
                    break;
            }

            Console.WriteLine(a.Max());
        }
    }
}

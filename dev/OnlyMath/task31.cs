using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire
{
    class Program
    {
        static void Main(string[] args)
        {
            // 31. Сгенерировать такой массив на 11 элементов в
            // котором бы присутствовали все цифры от 0 до 10,
            // но в произвольном порядке. 

            Random random = new Random();

            int[] mas = new int[11];

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = random.Next(10);
            }
        }
    }
}

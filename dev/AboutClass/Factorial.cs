using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutClass
{
    class Factorial
    {
        // 2. Факториал
        //класс принимает число в конструктор
        //число целое, положительное.
        //класс содержит метод который рассчитывает факториал от этого числа.
        //метод должен работать рекурсивно.

        private int number;

        public Factorial(int Number)
        {
            SetNumber(Number);
        }

        public void SetNumber(int value)
        {
            if(value > 0)
            {
                number = value;
            }
            else
            {
                Console.WriteLine("Nice try");
            }
        }

        private int NumberFactorial()
        {
            number--;
            return (number == 0) ? 1 : number * NumberFactorial();
        }

        public int Fact()
        {
            return number * NumberFactorial();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Factorial factorial = new Factorial(5);

            Console.WriteLine(factorial.Fact());
        }
    }
}

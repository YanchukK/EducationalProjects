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
            string q1 = "Who ?\na me\nb\nc\nd";
            string q2 = "When ?\na\nb now\nc\nd";
            string q3 = "Why ?\na\nb\nc because\nd";
            string win = "You win";
            string fail = "You faild on question № ";
            string[] variants = new string[4] { "a", "b", "c", "d" };

            string q1_rus = "Кто ?\nа я\nб\nв\nг";
            string q2_rus = "Когда ?\nа\nб сейчас\nв\nг";
            string q3_rus = "Почему ?\nа\nб\nв потому что\nг";
            string win_rus = "Вы победили";
            string fail_rus = "Вы проиграли на вопросе № ";
            string[] variants_rus = new string[4] { "а", "б", "в", "г" };


            Console.WriteLine("На каком языке Вы хотите играть?\n1. рус\n2. eng");
            string answer = Console.ReadLine();

            if (answer == "рус" || answer == "1")
            {
                Console.WriteLine(q1_rus);
                answer = Console.ReadLine();

                if (answer == variants_rus[0])
                {
                    Console.WriteLine(win_rus);
                    Console.WriteLine(q2_rus);
                    answer = Console.ReadLine();
                    if (answer == variants_rus[1])
                    {
                        Console.WriteLine(win_rus);
                        Console.WriteLine(q3_rus);
                        answer = Console.ReadLine();
                        if (answer == variants_rus[2])
                        {
                            Console.WriteLine(win_rus);
                        }
                        else
                        {

                            Console.WriteLine(fail_rus + 3);
                        }
                    }
                    else
                    {

                        Console.WriteLine(fail_rus + 2);
                    }
                }
                else
                {
                    Console.WriteLine(fail_rus + 1);
                }
            }
            else if (answer == "eng" || answer == "2")
            {
                Console.WriteLine(q1);
                answer = Console.ReadLine();

                if (answer == variants[0])
                {
                    Console.WriteLine(win);
                    Console.WriteLine(q2);
                    answer = Console.ReadLine();
                    if (answer == variants[1])
                    {
                        Console.WriteLine(win);
                        Console.WriteLine(q3);
                        answer = Console.ReadLine();
                        if (answer == variants[2])
                        {
                            Console.WriteLine(win);
                        }
                        else
                        {

                            Console.WriteLine(fail + 3);
                        }
                    }
                    else
                    {

                        Console.WriteLine(fail + 2);
                    }
                }
                else
                {
                    Console.WriteLine(fail + 1);
                }
            }
            else
            {
                Console.WriteLine("Вариант введен некорректно");
            }
        }
    }
}

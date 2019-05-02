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
            string fail = "You faild on question ";
            string playagain = "Do you want play again?";
            string[] variants = new string[4] { "a", "b", "c", "d" };

            Console.WriteLine("На каком языке Вы хотите играть?\n1. рус\n2. eng");
            string answer = Console.ReadLine();

            if (answer == "рус" || answer == "1")
            {
                q1 = "Кто ?\nа я\nб\nв\nг";
                q2 = "Когда ?\nа\nб сейчас\nв\nг";
                q3 = "Почему ?\nа\nб\nв потому что\nг";
                win = "Вы победили";
                fail = "Вы проиграли на вопросе ";
                playagain = "Вы бы хотели сыграть еще раз?";
                variants = new string[4] { "а", "б", "в", "г" };
            }

            do
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
                            Console.WriteLine(playagain);
                        }
                        else
                        {
                            Console.WriteLine(fail + 3);
                            Console.WriteLine(playagain);
                        }
                    }
                    else
                    {
                        Console.WriteLine(fail + 2);
                        Console.WriteLine(playagain);
                    }
                }
                else
                {
                    Console.WriteLine(fail + 1);
                    Console.WriteLine(playagain);
                }
            } while (Console.ReadLine() == "Yes");
        }
    }
}

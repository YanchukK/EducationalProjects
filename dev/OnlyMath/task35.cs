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
        enum Suit
        {
            Diamonds, // Бубны
            Hearts, //  Червы/черви
            Spades, //  Пики
            Clubs //  Трефы
        }

        enum Value
        {
            Six = 6,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack = 2,
            Lady,
            King,
            Ace = 11 
        }

        struct Card
        {
            public Suit Suit;
            public Value Value; // ценность карты
            //public string Name; // имя 6, 7, 8, 9, 10, валет - 2, дама - 3, король - 4, туз - 11
        }

        static void Main(string[] args)
        {
            // 35. Найти позиции всех тузов в колоде

            Card[] cards = new Card[36];

            int s = 0;

            for (int i = 0; i < 36;)
            {
                for (int j = 11; j < (2 + 10); j++) // j = 11, потому что первый в колоде тух
                {
                    cards[i] = new Card { Suit = (Suit)s, Value = (Value)j };
                    if (j == 11) // потом идут 6, 7, 8, 9, 10
                    {
                        j = 5;
                    }
                    if (j == 10) // потом валет, дама, король
                    {
                        j = 1;
                    }
                    if (j == 4)
                    {
                        j = 2 + 10;
                    }
                    i++;
                }
                s++;
            }

            Console.WriteLine();

            Card[] mixedcards = new Card[36];
            Random random = new Random(); 
            int[] randmas = new int[36]; // массив для проверки, существует
                                         // ли уже такое сгенерированное число
            int v = 0;

            do
            {
                for (int i = 0; i < randmas.Length; i++)
                {
                    if (IsEquals(v = random.Next(0, 36), 0))
                    {
                        mixedcards[i] = cards[v];
                        randmas[i] = v;
                    }
                    else if (!IsContains(randmas, v = random.Next(0, 36), (i + 1)))
                    {
                        mixedcards[i] = cards[v];
                        randmas[i] = v;
                    }
                    else
                    {
                        i--;
                    }
                }
            } while (!IsFourAces());

            bool IsEquals(int v1, int v2)
            {
                if(v1 == v2)
                {
                    return true;
                }
                return false;
            }

            bool IsContains(int[] array, int value, int length)
            {
                for (int i = 0; i < length;  i++)
                {
                    if (array[i] == value)
                    {
                        return true;
                    }
                }

                return false;
            }

            bool IsFourAces()
            {
                v = 0;

                for (int i = 0; i < mixedcards.Length; i++)
                {
                    if (mixedcards[i].Value == (Value)11) // 11 - "цена" тузов
                    {
                        v++;
                    }
                }
                if(v == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            int[] aces = new int[4]; // массив для хранения позиций тузов в колоде

            v = 0;

            for (int i = 0; i < mixedcards.Length; i++)
            {
                if (mixedcards[i].Value == (Value)11) // 11 - "цена" тузов
                {
                    aces[v] = i;
                    v++;
                }
            }
        }
    }
}

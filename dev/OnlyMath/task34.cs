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
            public Value Value; // ценность карты // имя 6, 7, 8, 9, 10, валет - 2, дама - 3, король - 4, туз - 11
        }

        static void Main(string[] args)
        {
            // 34. Перемешать колоду карт

            Card[] cards = new Card[36];

            int suit = 0; // идентификатор карты

            for (int i = 0; i < 36;)
            {
                for (int j = 11; j < (2 + 10); j++) // j = 11, потому что первый в колоде туз
                {
                    cards[i] = new Card { Suit = (Suit)suit, Value = (Value)j };
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
                suit++;
            }

            Card[] mixedcards = new Card[36]; // массив перемешанных карт
            Random random = new Random();
            int[] randmas = new int[36]; // массив для проверки, существует
                                         // ли уже такое сгенерированное число
            int v = 0;

            for (int i = 0; i < randmas.Length; i++)
            {
                if (!IsContains(randmas, v = random.Next(0, 36), i))
                {
                    mixedcards[i] = cards[v];
                    randmas[i] = v;
                }
                else
                {
                    i--;
                }
            }

            for (int i = 0; i < mixedcards.Length; i++)
            {
                Console.WriteLine(mixedcards[i].Suit + " " + mixedcards[i].Value);
            }
        }

        public static bool IsContains(int[] array, int value, int index)
        {
            for (int i = 0; i < index; i++)
            {
                if (array[i] == value)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

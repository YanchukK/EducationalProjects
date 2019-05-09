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
            // 32. Структурой описать игральную карту
            // 33. Сгенерировать упорядоченную колоду карт
            // упорядоченная: туз, 6, 7, 8, 9, 10, валет, дама, король

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
                    if(j == 10) // потом валет, дама, король
                    {
                        j = 1;
                    }
                    if(j == 4)
                    {
                        j = 2 + 10;
                    }
                    i++;
                }
                s++;
            }
              
            for (int i = 0; i < cards.Length; i++)
            {
                Console.WriteLine((i + 1) + " " + cards[i].Suit + " " + cards[i].Value);
            }
        }
    }
}

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

            int suit = 0; // идентификатор масти карты

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

            // перетасовать колоду
            Random random = new Random();

            // перемешать колоду т.е. написать алгоритм перемешивания например,
            // каждый раз ложить а середину. Каждый раз середина будет разная 
          
            for (int i = 0; i < cards.Length; i++)
            {
                int r = random.Next(0, 36);

                Card card = cards[r];
                cards[r] = cards[cards.Length / 2];
                cards[cards.Length / 2] = card;
            }
        }
    }
}

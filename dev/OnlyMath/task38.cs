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
            // 6, 7, 8, 9, 10, валет - 2, дама - 3, король - 4, туз - 11
        }

        static void Main(string[] args)
        {
            // 38. Считать колоду карт из файла

            string[] array = File.ReadAllLines("Cards.txt");

            Card[] cards = new Card[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                cards[i] = ReturnCard(array[i]);
            }

            Card ReturnCard(string str)
            {
                Card card = new Card();

                int k = 0;
                int j = 0;

                while (k < str.Length)
                {
                    if (str[k] == '=')
                    {
                        j++;
                    }
                    k++;
                }

                int[] result = new int[j];

                j = 0;

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '=')
                    {
                        i++;
                        result[j] = ReturnInt(str, i);
                        j++;
                    }
                }              
                
                card.Suit = (Suit)result[0];
                card.Value = (Value)result[1];

                return card;
            }

            int ReturnInt(string str1, int index)
            {
                string res = "";
                for (int i = index; i < str1.Length; i++)
                {
                    if(str1[i] == ';')
                    {
                        i = str1.Length;
                    }
                    else
                    {
                        res += str1[i];
                    }
                }

                return int.Parse(res);
            }
        }
    }
}

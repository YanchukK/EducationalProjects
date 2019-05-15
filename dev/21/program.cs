using System;

namespace Millionaire
{
    class Program
    {
        // Зачем нужны масти если, они не используются
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
        
        // зачем?
        struct Card
        {
            public Suit Suit;
            public Value Value; // ценность карты // имя 6, 7, 8, 9, 10, валет - 2, дама - 3, король - 4, туз - 11
        }

        static void Main(string[] args)
        {
            // Игра 21

            Card[] cards = new Card[36];

            int suit = 0; // идентификатор масти карты

            // генерация упорядоченной колоды карт
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

            // перемешивание колоды. Каждый раз в середину кладется
            // рандомный элемент. Каждый раз середина будет разная 

            Random random = new Random();

            for (int i = 0; i < cards.Length; i++)
            {
                int r = random.Next(0, 36);

                Card card = cards[r];
                cards[r] = cards[cards.Length / 2];
                cards[cards.Length / 2] = card;
            }


            int yourTotalCards = 0;
            int compTotalCards = 0;

            yourTotalCards += (int)cards[0].Value;
            yourTotalCards += (int)cards[1].Value;
            compTotalCards += (int)cards[2].Value;
            compTotalCards += (int)cards[3].Value;
            int c = 4;
            
            // at first you should enter who receives first cards
            string answer = "";

            do
            {
                Console.WriteLine("Enter who receives first cards?\nif comp enter \"C\", if you enter \"Y\"");
                answer = Console.ReadLine();
            } while (answer != "C" && answer != "Y");

            string firstPlayer = "You";

            // если компьютер первый, меняются значения суммы выданных карт 
            if (answer == "C")
            {
                int temp = yourTotalCards;
                yourTotalCards = compTotalCards;
                compTotalCards = temp;

                firstPlayer = "Computer";
            }

            bool continueGame = true;

            while (true)
            {
                if (yourTotalCards == 21 || compTotalCards == 21)
                {
                    if(yourTotalCards == compTotalCards)
                    {
                        Console.WriteLine("Computer and you have tied");
                    }
                    else
                    {
                        Console.WriteLine(yourTotalCards == 21 ? "You have 21 point. Congratulations!"
                            : "Computer have 21 point. Computer is winner!");
                        break;
                    }
                }
                else if (yourTotalCards == 22 || compTotalCards == 22)
                {
                    if (yourTotalCards == compTotalCards)
                    {
                        Console.WriteLine("Computer and you have tied");
                    }
                    else
                    {
                        Console.WriteLine(yourTotalCards == 22 ? "You have 2 aces. Congratulations!"
                            : "Computer have 2 aces. Computer is winner!");
                        break;
                    }
                }

                string cont = ""; // continue?

                do
                {
                    Console.WriteLine($"Sum of your cards is {yourTotalCards}.\nDo you want to continue?\nEnter \"Y\" if yes" +
                        $" or \"N\" if no");

                    cont = Console.ReadLine();
                } while (cont != "Y" && cont != "N");

                if (cont == "N")
                {
                    continueGame = false;
                }
                else
                { 
                    if (firstPlayer == "You")
                    {
                        yourTotalCards += (int)cards[c].Value;
                        c++;

                        while (compTotalCards < 17)
                        {
                            compTotalCards += (int)cards[c].Value;
                            c++;
                        }
                    }
                    else
                    {
                        while (compTotalCards < 17)
                        {
                            compTotalCards += (int)cards[c].Value;
                            c++;
                        }

                        yourTotalCards += (int)cards[c].Value;
                        c++;
                    }
                }
                
                // конец игры
                if (!continueGame || compTotalCards > 21 || yourTotalCards > 21)
                {
                    Console.WriteLine($"Sum of your cards is {yourTotalCards}.\n"
                        + $"Sum of computer cards is {compTotalCards}.\n");

                    if (yourTotalCards == compTotalCards)
                    {
                        Console.WriteLine("Computer and you have tied");
                    }
                    else if (compTotalCards > 21 && yourTotalCards > 21)
                    {
                        Console.WriteLine(yourTotalCards > compTotalCards ? "Computer is winner" : "You are winner");
                    }
                    else if (compTotalCards > 21)
                    {
                        Console.WriteLine("You are winner");
                    }
                    else if (yourTotalCards > 21)
                    {
                        Console.WriteLine("Computer is winner");
                    }
                    else if (compTotalCards < yourTotalCards)
                    {
                        Console.WriteLine("You are winner");
                    }
                    else
                    {
                        Console.WriteLine("Computer is winner");
                    }

                    break;
                }
            }               
        }
    }
}

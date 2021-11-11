using System;
using System.Linq;

namespace Poker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Player1 = new Player()
            {
                Name = "Player1"
            };

            var Player2 = new Player()
            {
                Name = "Player2"
            };
            


            Console.WriteLine("Hello. Welcome in Poker.");
            Console.WriteLine("You have 4 available commends Draw Cards/Show Cards/Check The Winner/Exit");
            var action = (string)default;

            while (action != "exit")
            {
                Console.WriteLine("\nwhat action do you want now?");
                action = Console.ReadLine().ToLower().Replace(" ","");
                switch (action)
                { 
                    case "drawcards":
                        {
                            CardDrawer.AllDrewCards.Clear();

                            Player2.WithTableCards.Clear();

                            Player1.WithTableCards.Clear();

                            CardDrawer.DrawTableCards(PokerTable.CardsOnTable, 5);

                            CardDrawer.DrawTableCards(Player1.Cards, 2);

                            CardDrawer.DrawTableCards(Player2.Cards, 2);

                            Player1.WithTableCards.AddRange(Player1.Cards);

                            Player1.WithTableCards.AddRange(PokerTable.CardsOnTable);

                            Player2.WithTableCards.AddRange(Player2.Cards);

                            Player2.WithTableCards.AddRange(PokerTable.CardsOnTable);

                            Console.WriteLine("\nCards drawn");

                            break;
                        }
                    case "showcards":
                        {
                            if (Player1.Cards.Count > 0)
                            {

                                Console.WriteLine("\nPlayer1 Cards:\n");

                                foreach (var card in Player1.Cards)
                                {
                                    Console.WriteLine(card.TypeOfCard + " " + card.ColorOfCard);
                                }

                                Console.WriteLine("\nPlayer2 Cards:\n");

                                foreach (var card in Player2.Cards)
                                {
                                    Console.WriteLine(card.TypeOfCard + " " + card.ColorOfCard);
                                }
                                Console.WriteLine("\nCards on the table:\n");

                                foreach (var card in PokerTable.CardsOnTable)
                                {
                                    Console.WriteLine(card.TypeOfCard + " " + card.ColorOfCard);

                                }
                            }
                            else
                            {
                                Console.WriteLine("\nFirst you have to DrawCards");
                            }
                      
                            break;

                        }
                    case "checkthewinner":
                        {
                            if (Player1.Cards.Count > 0)
                            {

                                PokerTable.CardsOnTable = PokerTable.CardsOnTable.OrderByDescending(s => (int)s.TypeOfCard).ToList();

                                Player2.Cards = Player2.Cards.OrderByDescending(s => (int)s.TypeOfCard).ToList();

                                Player1.Cards = Player1.Cards.OrderByDescending(s => (int)s.TypeOfCard).ToList();


                                Console.WriteLine("\n\n");

                                CheckSetsOfCards.CheckSetOfCards(Player1, Player2);
                            }
                            else
                            {
                                Console.WriteLine("\nFirst you have to DrawCards");
                            }

                            break;
                        }
                    case "exit":
                        {
                            Console.WriteLine("\nBye Bye");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nAction like this doesn't exist, please choose DrawCards/CheckTheWinner/ShowCards/Exit");
                            break;
                        }
                }




    

            }



        }
    }
}

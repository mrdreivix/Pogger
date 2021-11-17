using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var player1 = new Player()
            {
                Name = "Player1"
            };

            var player2 = new Player()
            {
                Name = "Player2"
            };

            var table = new PokerTable();
            Console.WriteLine("Hello. Welcome in Poker.");
            Console.WriteLine("You have 4 available commends Draw Cards/Show Cards/Check The Winner/Exit");
            var action = (string)default;

            while (action != "exit")
            {
                Console.WriteLine("\nwhat action do you want now?");
                action = Console.ReadLine().ToLower().Replace(" ","");
                switch (action)
                { 
                    case "drawcards"://wrzucic wszystko w switchach do funkcji zeby switchbyl mniejszy
                        {
                            table.Cards = CardDrawer.DrawTableCards(5);
                            player1.Cards = CardDrawer.DrawTableCards(2);
                            player2.Cards = CardDrawer.DrawTableCards(2);
                            Console.WriteLine("\nCards drawn");
                            break;
                        }
                    case "showcards":
                        {
                            if (player1.Cards.Count > 0)
                            {
                                Console.WriteLine("\nPlayer1 Cards:\n");
                                foreach (var card in player1.Cards)
                                Console.WriteLine(card.TypeOfCard + " " + card.ColorOfCard);

                                Console.WriteLine("\nPlayer2 Cards:\n");
                                foreach (var card in player2.Cards)
                                Console.WriteLine(card.TypeOfCard + " " + card.ColorOfCard);

                                Console.WriteLine("\nCards on the table:\n");
                                foreach (var card in table.Cards)
                                Console.WriteLine(card.TypeOfCard + " " + card.ColorOfCard);
                            }
                            else
                            {
                                Console.WriteLine("\nFirst you have to DrawCards");
                            }
                            break;
                        }
                    case "checkthewinner":
                        {
                            Console.WriteLine();
                            if (player1.Cards.Count > 0)
                            {
                                var Player1Set = PlayerAndTableCardsConnector.ConnectCards(player1.Cards, table.Cards).CheckSetOfCards();
                                Console.WriteLine("player 1 have: "+ Player1Set.set);
                                var Player2Set = PlayerAndTableCardsConnector.ConnectCards(player2.Cards, table.Cards).CheckSetOfCards();
                                Console.WriteLine("player 2 have: " + Player2Set.set);
                                WinnerChecker.CheckTheWinner(Player1Set, Player2Set);
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

using System;

namespace Poker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var player1 = new Player("Player1");
            var player2 = new Player("Player2");
            var table = new PokerTable();

            Console.WriteLine("Hello. Welcome in Poker.");
            Console.WriteLine("You have 4 available commends Draw Cards/Show Cards/Check The Winner/Exit");
            var action = (string)default;

            while (action != "exit")
            {
                Console.WriteLine("\nwhat action do you want now?");
                action = Console.ReadLine().ToLower().Replace(" ", "");
                switch (action)
                {
                    case "drawcards":
                        {
                            CardDrawer.DrawAllCards(table, player1, player2);
                            break;
                        }
                    case "showcards":
                        {
                            DisplayOfCards.DisplayCards(table, player1, player2);
                            break;
                        }
                    case "checkthewinner":
                        {
                            WinnerChecker.CheckTheWinner
                               (player1, SetAndBestHandChecker.CheckSetOfCards(PlayerAndTableCardsConnector.ConnectCards(player1.Cards, table.Cards)),
                                player2, SetAndBestHandChecker.CheckSetOfCards(PlayerAndTableCardsConnector.ConnectCards(player2.Cards, table.Cards)));
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

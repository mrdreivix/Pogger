using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Poker
{
    class Program
    {


        public static void Main(string[] args)
        {




            var Player1 = new PokerPlayer()
            {
                NameOfPlayer = "Player1"
            };

            var Player2 = new PokerPlayer()
            {
                NameOfPlayer = "Player2"
            };

            DrawCards.DrawTableCards();

            DrawCards.DrawPlayersCards(Player1);

            DrawCards.DrawPlayersCards(Player2);


            Console.WriteLine("\nKarty Gracza1:\n");

            foreach (var cardsss in Player1.PlayersCards)
            {
                Console.WriteLine(cardsss.TypeOfCard + " " + cardsss.ColorOfCard);
            }

            Console.WriteLine("\nKarty Gracza2:\n");

            foreach (var cardss in Player2.PlayersCards)
            {
                Console.WriteLine(cardss.TypeOfCard + " " + cardss.ColorOfCard);
            }
            Console.WriteLine("\nKarty na stole:\n");

            foreach (var lane in DrawCards.ListOfCards)
            {
                Console.WriteLine(lane.TypeOfCard + " " + lane.ColorOfCard);
                Player1.PlayersCards.Add(lane);
                Player2.PlayersCards.Add(lane);
            }

            DrawCards.ListOfCards = DrawCards.ListOfCards.OrderByDescending(s => (int)s.TypeOfCard).ToList();
            Player2.PlayersCards = Player2.PlayersCards.OrderByDescending(s => (int)s.TypeOfCard).ToList();
            Player1.PlayersCards = Player1.PlayersCards.OrderByDescending(s => (int)s.TypeOfCard).ToList();


            Console.WriteLine("\n\n");

            CheckSetsOfCards.CheckSetOfCards(Player1, Player2);




        }
    }
}

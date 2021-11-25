using System;

namespace Poker
{
    public class DisplayOfCards
    {
        public static void DisplayCards(PokerTable table, Player player1, Player player2)
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
        }
    }
}

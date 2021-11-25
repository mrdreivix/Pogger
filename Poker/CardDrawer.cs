
using System;
using System.Collections.Generic;


namespace Poker
{
    public static class CardDrawer
    {
        public static void DrawAllCards(PokerTable table, Player player1, Player player2)
        {
            table.Cards = DrawCards(5);
            player1.Cards = DrawCards(2);
            player2.Cards = DrawCards(2);
            Console.WriteLine("\nCards drawn");
        }
        private static List<Card> DrawCards(int numberOfCards)
        {
            List<Card> allDrewCards = new List<Card>();
            Random randomNumber = new Random();
            var listOfCards = new List<Card>();

            while (listOfCards.Count != numberOfCards)
            {
                var card = new Card()
                {
                    TypeOfCard = (DeckOfCards)(randomNumber.Next(Enum.GetNames(typeof(DeckOfCards)).Length)),
                    ColorOfCard = (ColorOfCard)(randomNumber.Next(Enum.GetNames(typeof(ColorOfCard)).Length))
                };

                if (!(allDrewCards.Exists(s => s.TypeOfCard == card.TypeOfCard && s.ColorOfCard == card.ColorOfCard)))
                {
                    listOfCards.Add(card);
                    allDrewCards.Add(card);
                }
            }
            return listOfCards;
        }
    }
}

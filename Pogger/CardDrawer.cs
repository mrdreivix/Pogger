
using System;
using System.Collections.Generic;


namespace Poker
{
    public static class CardDrawer
    {
        public static List<Card> AllDrewCards;
        public static List<Card> DrawTableCards(int numberOfCards)
        {
            AllDrewCards = new List<Card>();
            Random randomNumber = new Random();
            var listOfCards = new List<Card>();

            while(listOfCards.Count != numberOfCards)
            {
                var card = new Card() 
                {
                    TypeOfCard = (DeckOfCards)(randomNumber.Next(Enum.GetNames(typeof(DeckOfCards)).Length)),
                    ColorOfCard = (ColorOfCard)(randomNumber.Next(Enum.GetNames(typeof(ColorOfCard)).Length))
                };

                if (!(AllDrewCards.Exists(s => s.TypeOfCard == card.TypeOfCard && s.ColorOfCard == card.ColorOfCard)))
                {
                    listOfCards.Add(card);
                    AllDrewCards.Add(card);
                }
            }
            return listOfCards;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public static class CardDrawer
    {

      

        public static List<Card> AllDrewCards = new List<Card>() { };
        public static void DrawTableCards(List<Card> listOfCards,int numberOfCards)
        {
            listOfCards.Clear();

            Random randomNumber = new Random();
            
            while(listOfCards.Count != numberOfCards)
            {
                Card Card = new Card();
                CardRandomization.RandomizeCard(Card, randomNumber);
                if (!(AllDrewCards.Exists(s => s.TypeOfCard == Card.TypeOfCard && s.ColorOfCard == Card.ColorOfCard)))
                {
                    listOfCards.Add(Card);
                    AllDrewCards.Add(Card);
                }
            }
            

        }

       

    }
}

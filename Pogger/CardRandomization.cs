using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class CardRandomization
    {
        public static void RandomizeCard(Card Card, Random randomNumber)
        {
         
            Card.TypeOfCard = (DeckOfCards)(randomNumber.Next(Enum.GetNames(typeof(DeckOfCards)).Length));

            Card.ColorOfCard = (ColorOfCard)(randomNumber.Next(Enum.GetNames(typeof(ColorOfCard)).Length));

           
        }
    }
}

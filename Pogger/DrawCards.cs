using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public static class DrawCards
    {
        public static List<Card> ListOfCards = new List<Card>();

        public static Card Card = new Card();

        public static List<Card> AllDrewCards = new List<Card>();
        public static void DrawTableCards()
        {
            Random randomNumbers = new Random();

            Card.TypeOfCard = (DeckOfCards)(randomNumbers.Next(1, 14));
            Card.ColorOfCard = (ColorOfCards)randomNumbers.Next(1, 5);


            ListOfCards.Add(Card);
            AllDrewCards.Add(Card);

            for (int i = 0; i <= 3; i++)
            {
                Card = new Card();
                Card.TypeOfCard = (DeckOfCards)randomNumbers.Next(1, 14);
                Card.ColorOfCard = (ColorOfCards)randomNumbers.Next(1, 5);
                int CounterOfLastElement = 1;

                foreach (var card in ListOfCards)
                {

                    if (card.ColorOfCard == Card.ColorOfCard && card.TypeOfCard == Card.TypeOfCard)
                    {
                        i--;
                        break;
                    }
                    else if (ListOfCards.Count <= CounterOfLastElement)
                    {
                        ListOfCards.Add(Card);
                        AllDrewCards.Add(Card);
                        break;
                    }
                    CounterOfLastElement++;


                }



            }



        }

        public static void DrawPlayersCards(PokerPlayer pokerPlayer)
        {
            Random randomNumbers = new Random();

            for (int i = 0; i <= 5; i++)
            {
                Card = new Card();
                Card.TypeOfCard = (DeckOfCards)randomNumbers.Next(1, 14);
                Card.ColorOfCard = (ColorOfCards)randomNumbers.Next(1, 5);
                int CounterOfLastElementInAllDrewCardsList = 1;

                foreach (var card in AllDrewCards)
                {

                    if (card.ColorOfCard == Card.ColorOfCard && card.TypeOfCard == Card.TypeOfCard)
                    {
                        i--;
                        break;
                    }
                    else if (AllDrewCards.Count <= CounterOfLastElementInAllDrewCardsList)
                    {
                        AllDrewCards.Add(Card);
                        pokerPlayer.PlayersCards.Add(Card);
                        break;
                    }
                    CounterOfLastElementInAllDrewCardsList++;
                }
            }

        }

    }
}

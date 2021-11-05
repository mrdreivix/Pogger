using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker
{
    public class CheckSetsOfCards
    {
        public delegate void cos(PokerPlayer player);

        public static List<cos> ListOfFunctions = new List<cos>() { StraightFlushSet, FourOfAKindSet, FullHouseSet, FlushSet, StraightSet, ThreeOfAKindSet, TwoPairsSet, OnePairSet, HighCardSet };
        public static void CheckSetOfCards(PokerPlayer player1, PokerPlayer player2)
        {

            foreach (var i in ListOfFunctions)
            {
                i(player1);
                i(player2);
                if (player1.StrongestSet > 0 || player2.StrongestSet > 0)
                {
                    CheckWhoIsTheWinner.CheckTheWinner(player1, player2);
                }
            }

        }
        public static void HighCardSet(PokerPlayer player)
        {


            player.StrongestSet = SetsOfCards.HighCard;

            player.StrongestCardsInSet.AddRange(player.PlayersCards.Take(5));

        }

        public static void FourOfAKindSet(PokerPlayer player)
        {


            if (player.PlayersCards.FindAll(s => player.PlayersCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count == 4).Count > 0)
            {
                player.StrongestSet = SetsOfCards.FourOfAKind;
                player.StrongestCardsInSet.Add(player.PlayersCards.FindAll(s => player.PlayersCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count() == 4).OrderByDescending(l => l.TypeOfCard).First());
                player.StrongestCardsInSet.Add(player.PlayersCards.Where(s => s.TypeOfCard != player.StrongestCardsInSet[0].TypeOfCard).OrderByDescending(c => c.TypeOfCard).First());
                Console.WriteLine(player.NameOfPlayer + ": ma Four Of Kind");
            }


        }
        public static void ThreeOfAKindSet(PokerPlayer player)
        {


            if (player.PlayersCards.FindAll(s => player.PlayersCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count == 3).Count > 0)
            {
                player.StrongestSet = SetsOfCards.ThreeOfAKind;
                player.StrongestCardsInSet.Add(player.PlayersCards.FindAll(s => player.PlayersCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count() == 3).OrderByDescending(l => l.TypeOfCard).First());
                player.StrongestCardsInSet.AddRange(player.PlayersCards.Where(s => s.TypeOfCard != player.StrongestCardsInSet[0].TypeOfCard).OrderByDescending(c => c.TypeOfCard).Take(2));
                Console.WriteLine(player.NameOfPlayer + ": ma three of kind");
            }

        }
        public static void OnePairSet(PokerPlayer player)
        {


            if (player.PlayersCards.FindAll(s => player.PlayersCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count == 2).Count > 0)
            {
                player.StrongestSet = SetsOfCards.OnePair;
                player.StrongestCardsInSet.Add(player.PlayersCards.FindAll(s => player.PlayersCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count() == 2).OrderByDescending(l => l.TypeOfCard).First());
                player.StrongestCardsInSet.AddRange(player.PlayersCards.Where(s => s.TypeOfCard != player.StrongestCardsInSet[0].TypeOfCard).OrderByDescending(c => c.TypeOfCard).Take(3));
                Console.WriteLine(player.NameOfPlayer + ": ma One Pair");
            }

        }

        public static void TwoPairsSet(PokerPlayer player)
        {

            if (player.PlayersCards.FindAll(s => player.PlayersCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count == 2).Count > 2)
            {
                player.StrongestSet = SetsOfCards.TwoPair;
                player.StrongestCardsInSet.AddRange(player.PlayersCards.FindAll(s => player.PlayersCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count() == 2).OrderByDescending(l => l.TypeOfCard).Take(4));
                player.StrongestCardsInSet.Add(player.PlayersCards.Where(s => s.TypeOfCard != player.StrongestCardsInSet[0].TypeOfCard && s.TypeOfCard != player.StrongestCardsInSet[2].TypeOfCard).OrderByDescending(c => c.TypeOfCard).First());

                Console.WriteLine(player.NameOfPlayer + ": ma Two Pair");
            }
        }
        public static void StraightSet(PokerPlayer player)
        {



            foreach (var lanes in player.PlayersCards)
            {
                for (int i = 1; i < 5; i++)
                {

                    if (player.PlayersCards.Exists(s => (int)s.TypeOfCard + i == (int)lanes.TypeOfCard))
                    {


                        if (i == 4)
                        {

                            for (int u = 0; u < 5; u++)
                            {
                                player.StrongestCardsInSet.Add(player.PlayersCards.Find(r => (int)r.TypeOfCard + u == (int)lanes.TypeOfCard));
                            }

                            player.StrongestSet = SetsOfCards.Straight;

                            Console.WriteLine(player.NameOfPlayer + ": ma straight");
                            return;
                        }

                    }
                    else
                    {

                        break;
                    }


                }

            }


        }


        public static void FlushSet(PokerPlayer player)
        {

            foreach (var i in player.PlayersCards)
            {

                if (player.PlayersCards.FindAll(s => s.ColorOfCard == i.ColorOfCard).Count >= 5)
                {
                    player.StrongestSet = SetsOfCards.Flush;
                    Console.WriteLine(player.NameOfPlayer + ": ma Flush");

                    foreach (var s in player.PlayersCards.FindAll(s => s.ColorOfCard == i.ColorOfCard))
                    {
                        player.StrongestCardsInSet.Add(s);
                        if (player.StrongestCardsInSet.Count == 5)
                        {
                            return;
                        }
                    }

                }
            }

        }
        public static void FullHouseSet(PokerPlayer player)
        {


            if (player.PlayersCards.FindAll(s => player.PlayersCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count == 3).Count > 0 && player.PlayersCards.FindAll(s => player.PlayersCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count == 2).Count > 0)
            {
                player.StrongestCardsInSet.Add(player.PlayersCards.FindAll(s => player.PlayersCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count() == 3).OrderByDescending(l => l.TypeOfCard).First());
                player.StrongestCardsInSet.Add(player.PlayersCards.FindAll(s => player.PlayersCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count() == 2).OrderByDescending(l => l.TypeOfCard).First());
                player.StrongestSet = SetsOfCards.FullHouse;
                Console.WriteLine(player.NameOfPlayer + ": ma FullHouse");
            }


        }

        public static void StraightFlushSet(PokerPlayer player)
        {



            foreach (var lanes in player.PlayersCards)
            {
                player.StrongestCardsInSet.Add(lanes);
                for (int i = 1; i < 5; i++)
                {

                    if (player.PlayersCards.Exists(s => (int)s.TypeOfCard + i == (int)lanes.TypeOfCard && s.ColorOfCard == lanes.ColorOfCard))
                    {

                        if (i == 4)
                        {
                            player.StrongestSet = SetsOfCards.StraightFlush;
                            Console.WriteLine(player.NameOfPlayer + ": ma StraightFlush");
                            return;
                        }

                    }
                    else
                    {
                        player.StrongestCardsInSet.Clear();
                        break;
                    }


                }

            }


        }



    }
}

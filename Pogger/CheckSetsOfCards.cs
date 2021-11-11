using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class CheckSetsOfCards
    {
        public delegate void Function(Player player);

        public static List<Function> ListOfFunctions = new List<Function>() { StraightFlushSet, FourOfAKindSet, FullHouseSet, FlushSet, StraightSet, ThreeOfAKindSet, TwoPairsSet, OnePairSet, HighCardSet };
        public static void CheckSetOfCards(Player player1, Player player2)
        {
            player1.StrongestSet = 0;
            player2.StrongestSet = 0;
            player1.StrongestCardsInSet.Clear();
            player2.StrongestCardsInSet.Clear();
            foreach (var i in ListOfFunctions)
            {
                i(player1);
                i(player2);
                if (player1.StrongestSet > 0 || player2.StrongestSet > 0)
                {
                    CheckWhoIsTheWinner.CheckTheWinner(player1, player2);
                    return;
                }
                
            }

        }
        public static void HighCardSet(Player player)
        {


            player.StrongestSet = SetOfCard.HighCard;

            player.StrongestCardsInSet.AddRange(player.WithTableCards.Take(5));

        }

        public static void FourOfAKindSet(Player player)
        {


            if (player.WithTableCards.FindAll(s => player.WithTableCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count == 4).Count > 0)
            {
                player.StrongestSet = SetOfCard.FourOfAKind;
                player.StrongestCardsInSet.Add(player.WithTableCards.FindAll(s => player.WithTableCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count() == 4).OrderByDescending(l => l.TypeOfCard).First());
                player.StrongestCardsInSet.Add(player.WithTableCards.Where(s => s.TypeOfCard != player.StrongestCardsInSet[0].TypeOfCard).OrderByDescending(c => c.TypeOfCard).First());
                Console.WriteLine(player.Name + ": ma Four Of Kind");
            }


        }
        public static void ThreeOfAKindSet(Player player)
        {


            if (player.WithTableCards.FindAll(s => player.WithTableCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count == 3).Count > 0)
            {
                player.StrongestSet = SetOfCard.ThreeOfAKind;
                player.StrongestCardsInSet.Add(player.WithTableCards.FindAll(s => player.WithTableCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count() == 3).OrderByDescending(l => l.TypeOfCard).First());
                player.StrongestCardsInSet.AddRange(player.WithTableCards.Where(s => s.TypeOfCard != player.StrongestCardsInSet[0].TypeOfCard).OrderByDescending(c => c.TypeOfCard).Take(2));
                Console.WriteLine(player.Name + ": ma three of kind");
            }

        }
        public static void OnePairSet(Player player)
        {


            if (player.WithTableCards.FindAll(s => player.WithTableCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count == 2).Count > 0)
            {
                player.StrongestSet = SetOfCard.OnePair;
                player.StrongestCardsInSet.Add(player.WithTableCards.FindAll(s => player.WithTableCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count() == 2).OrderByDescending(l => l.TypeOfCard).First());
                player.StrongestCardsInSet.AddRange(player.WithTableCards.Where(s => s.TypeOfCard != player.StrongestCardsInSet[0].TypeOfCard).OrderByDescending(c => c.TypeOfCard).Take(3));
                Console.WriteLine(player.Name + ": ma One Pair");
            }

        }

        public static void TwoPairsSet(Player player)
        {

            if (player.WithTableCards.FindAll(s => player.WithTableCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count == 2).Count > 2)
            {
                player.StrongestSet = SetOfCard.TwoPair;
                player.StrongestCardsInSet.AddRange(player.WithTableCards.FindAll(s => player.WithTableCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count() == 2).OrderByDescending(l => l.TypeOfCard).Take(4));
                player.StrongestCardsInSet.Add(player.WithTableCards.Where(s => s.TypeOfCard != player.StrongestCardsInSet[0].TypeOfCard && s.TypeOfCard != player.StrongestCardsInSet[2].TypeOfCard).OrderByDescending(c => c.TypeOfCard).First());

                Console.WriteLine(player.Name + ": ma Two Pair");
            }
        }
        public static void StraightSet(Player player)
        {



            foreach (var lanes in player.WithTableCards)
            {
                for (int i = 1; i < 5; i++)
                {

                    if (player.WithTableCards.Exists(s => (int)s.TypeOfCard + i == (int)lanes.TypeOfCard))
                    {


                        if (i == 4)
                        {

                            for (int u = 0; u < 5; u++)
                            {
                                player.StrongestCardsInSet.Add(player.WithTableCards.Find(r => (int)r.TypeOfCard + u == (int)lanes.TypeOfCard));
                            }

                            player.StrongestSet = SetOfCard.Straight;

                            Console.WriteLine(player.Name + ": ma straight");
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


        public static void FlushSet(Player player)
        {

            foreach (var i in player.WithTableCards)
            {

                if (player.WithTableCards.FindAll(s => s.ColorOfCard == i.ColorOfCard).Count >= 5)
                {
                    player.StrongestSet = SetOfCard.Flush;
                    Console.WriteLine(player.Name + ": ma Flush");

                    foreach (var s in player.WithTableCards.FindAll(s => s.ColorOfCard == i.ColorOfCard))
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
        public static void FullHouseSet(Player player)
        {


            if (player.WithTableCards.FindAll(s => player.WithTableCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count == 3).Count > 0 && player.WithTableCards.FindAll(s => player.WithTableCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count == 2).Count > 0)
            {
                player.StrongestCardsInSet.Add(player.WithTableCards.FindAll(s => player.WithTableCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count() == 3).OrderByDescending(l => l.TypeOfCard).First());
                player.StrongestCardsInSet.Add(player.WithTableCards.FindAll(s => player.WithTableCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count() == 2).OrderByDescending(l => l.TypeOfCard).First());
                player.StrongestSet = SetOfCard.FullHouse;
                Console.WriteLine(player.Name + ": ma FullHouse");
            }


        }

        public static void StraightFlushSet(Player player)
        {



            foreach (var lanes in player.WithTableCards)
            {
                player.StrongestCardsInSet.Add(lanes);
                for (int i = 1; i < 5; i++)
                {

                    if (player.WithTableCards.Exists(s => (int)s.TypeOfCard + i == (int)lanes.TypeOfCard && s.ColorOfCard == lanes.ColorOfCard))
                    {

                        if (i == 4)
                        {
                            player.StrongestSet = SetOfCard.StraightFlush;
                            Console.WriteLine(player.Name + ": ma StraightFlush");
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

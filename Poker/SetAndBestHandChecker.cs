using System.Collections.Generic;
using System.Linq;
namespace Poker
{
    public static class SetAndBestHandChecker
    {
        private const int MAX_NUMBER_OF_CARDS = 5;
        private delegate (SetOfCard set, List<Card>) Function(List<Card> playerCards);
        private static List<Card> BestHand;
        private static List<Function> ListOfFunctions = new List<Function>()
        { CheckStraightFlushSet, CheckFourOfAKindSet,
          CheckFullHouseSet, CheckFlushSet, CheckStraightSet, CheckThreeOfAKindSet, CheckTwoPairsSet, CheckOnePairSet,};
        public static (SetOfCard set, List<Card>) CheckSetOfCards(List<Card> playerCards)
        {
            foreach (var function in ListOfFunctions)
            {
                var setOrBestHand = function(playerCards);
                if (setOrBestHand.set > SetOfCard.HighCard)
                {
                    return function(playerCards);
                }
            }
            return CheckHighCardSet(playerCards);
        }
        private static (SetOfCard, List<Card>) CheckHighCardSet(List<Card> playerCards)
        {
            BestHand = new List<Card>();
            BestHand.AddRange(playerCards.Take(5));
            return (SetOfCard.HighCard, BestHand);
        }
        private static (SetOfCard, List<Card>) CheckFourOfAKindSet(List<Card> playerCards)
        {
            BestHand = new List<Card>();
            if (playerCards.FindAll(s => playerCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count == 4).Count > 0)
            {
                BestHand.Add(playerCards.FindAll(s => playerCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count() == 4).OrderByDescending(l => l.TypeOfCard).First());
                BestHand.Add(playerCards.Where(s => s.TypeOfCard != BestHand[0].TypeOfCard).OrderByDescending(c => c.TypeOfCard).First());
                return (SetOfCard.FourOfAKind, BestHand);
            }
            else
            {
                return (SetOfCard.Unknown, BestHand);
            }
        }
        private static (SetOfCard, List<Card>) CheckThreeOfAKindSet(List<Card> playerCards)
        {
            BestHand = new List<Card>();
            if (playerCards.FindAll(s => playerCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count == 3).Count > 0)
            {
                BestHand.Add(playerCards.FindAll(s => playerCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count() == 3).OrderByDescending(l => l.TypeOfCard).First());
                BestHand.AddRange(playerCards.Where(s => s.TypeOfCard != BestHand[0].TypeOfCard).OrderByDescending(c => c.TypeOfCard).Take(2));
                return (SetOfCard.ThreeOfAKind, BestHand);
            }
            else
            {
                return (SetOfCard.Unknown, BestHand);
            }
        }
        private static (SetOfCard, List<Card>) CheckOnePairSet(List<Card> playerCards)
        {
            BestHand = new List<Card>();
            if (playerCards.FindAll(s => playerCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).Count == 2).Count > 0)
            {
                BestHand.Add(playerCards.FindAll(s => playerCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count() == 2).OrderByDescending(l => l.TypeOfCard).First());
                BestHand.AddRange(playerCards.Where(s => s.TypeOfCard != BestHand[0].TypeOfCard).OrderByDescending(c => c.TypeOfCard).Take(3));
                return (SetOfCard.OnePair, BestHand);
            }
            return (SetOfCard.Unknown, BestHand);
        }
        private static (SetOfCard, List<Card>) CheckTwoPairsSet(List<Card> playerCards)
        {
            BestHand = new List<Card>();
            if (playerCards.FindAll(s => playerCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count == 2).Count > 2)
            {
                BestHand.AddRange(playerCards.FindAll(s => playerCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count() == 2).OrderByDescending(l => l.TypeOfCard).Take(4));
                BestHand.Add(playerCards.Where(s => s.TypeOfCard != BestHand[0].TypeOfCard && s.TypeOfCard != BestHand[2].
                TypeOfCard).OrderByDescending(c => c.TypeOfCard).First());
                return (SetOfCard.TwoPair, BestHand);
            }
            else
            {
                return (SetOfCard.Unknown, BestHand);
            }
        }
        private static (SetOfCard, List<Card>) CheckStraightSet(List<Card> playerCards)
        {
            BestHand = new List<Card>();
            foreach (var card in playerCards)
            {
                for (int i = 1; i < MAX_NUMBER_OF_CARDS; i++)
                {
                    if (playerCards.Exists(s => (int)s.TypeOfCard + i == (int)card.TypeOfCard))
                    {
                        if (i == 4)
                        {
                            for (int j = 0; j < MAX_NUMBER_OF_CARDS; j++)
                            {
                                BestHand.Add(playerCards.Find(r => (int)r.TypeOfCard + j == (int)card.TypeOfCard));
                            }
                            return (SetOfCard.Straight, BestHand);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return (SetOfCard.Unknown, BestHand);
        }
        private static (SetOfCard, List<Card>) CheckFlushSet(List<Card> playerCards)
        {
            BestHand = new List<Card>();
            foreach (var card in playerCards)
            {
                if (playerCards.FindAll(s => s.ColorOfCard == card.ColorOfCard).Count >= MAX_NUMBER_OF_CARDS)
                {
                    foreach (var s in playerCards.FindAll(s => s.ColorOfCard == card.ColorOfCard))
                    {
                        BestHand.Add(s);
                        if (BestHand.Count == MAX_NUMBER_OF_CARDS)
                        {
                            return (SetOfCard.Flush, BestHand);
                        }
                    }
                }
            }
            return (SetOfCard.Unknown, BestHand);
        }
        private static (SetOfCard, List<Card>) CheckFullHouseSet(List<Card> playerCards)
        {
            BestHand = new List<Card>();
            if (playerCards.FindAll(s => playerCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count == 3).Count > 0 &&
             playerCards.FindAll(s => playerCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count == 2).Count > 0)
            {
                BestHand.Add(playerCards.FindAll(s => playerCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count() == 3).OrderByDescending(l => l.TypeOfCard).First());
                BestHand.Add(playerCards.FindAll(s => playerCards.FindAll(p => p.TypeOfCard == s.TypeOfCard).ToList().Count() == 2).OrderByDescending(l => l.TypeOfCard).First());
                return (SetOfCard.FullHouse, BestHand);
            }
            else
            {
                return (SetOfCard.Unknown, BestHand);
            }
        }
        private static (SetOfCard, List<Card>) CheckStraightFlushSet(List<Card> playerCards)
        {
            BestHand = new List<Card>();
            foreach (var card in playerCards)
            {
                BestHand.Add(card);
                for (int i = 1; i < MAX_NUMBER_OF_CARDS; i++)
                {
                    if (playerCards.Exists(s => (int)s.TypeOfCard + i == (int)card.TypeOfCard && s.ColorOfCard == card.ColorOfCard))
                    {
                        BestHand.Add(playerCards.Find(s => (int)s.TypeOfCard + i == (int)card.TypeOfCard && s.ColorOfCard == card.ColorOfCard));
                        if (i == 4)
                        {
                            return (SetOfCard.StraightFlush, BestHand);
                        }
                    }
                    else
                    {
                        BestHand.Clear();
                        break;
                    }
                }
            }
            return (SetOfCard.Unknown, BestHand);
        }
    }
}

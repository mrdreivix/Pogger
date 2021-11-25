using System;
using System.Collections.Generic;

namespace Poker
{
    public class WinnerChecker
    {
        public static void CheckTheWinner
            (Player player1, (SetOfCard set, List<Card>) player1BestHandOrSet,
             Player player2, (SetOfCard set, List<Card>) player2BestHandOrSet)
        {
            Console.WriteLine();
            if (player1.Cards.Count > 0)
            {
                Console.WriteLine(player1.Name + " have: " + player1BestHandOrSet.set);
                Console.WriteLine(player2.Name + " have: " + player2BestHandOrSet.set);
                DefineTheWinner(player1, player1BestHandOrSet, player2, player2BestHandOrSet);
            }
            else
            {
                Console.WriteLine("\nFirst you have to DrawCards");
            }
        }
        private static void DefineTheWinner
            (Player player1, (SetOfCard set, List<Card> bestHand) player1BestHandOrSet,
            Player player2, (SetOfCard set, List<Card> bestHand) player2BestHandOrSet)
        {
            if (player1BestHandOrSet.set == player2BestHandOrSet.set)
            {
                for (int i = 0; i < player1BestHandOrSet.bestHand.Count; i++)
                {
                    if (player1BestHandOrSet.bestHand[i].TypeOfCard > player2BestHandOrSet.bestHand[i].TypeOfCard)
                    {
                        Console.WriteLine(player1.Name + " won");
                        return;
                    }
                    else if (player1BestHandOrSet.bestHand[i].TypeOfCard < player2BestHandOrSet.bestHand[i].TypeOfCard)
                    {
                        Console.WriteLine(player2.Name + " won");
                        return;
                    }
                }
                Console.WriteLine("Draw");
            }
            else if (player1BestHandOrSet.set > player2BestHandOrSet.set)
                Console.WriteLine(player1.Name + " won");
            else if (player1BestHandOrSet.set < player2BestHandOrSet.set)
                Console.WriteLine(player2.Name + " won");
        }
    }
}

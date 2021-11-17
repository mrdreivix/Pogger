using System;
using System.Collections.Generic;

namespace Poker
{
    public class WinnerChecker 
    {
        public static void CheckTheWinner((SetOfCard set, List<Card> bestHand) player1, (SetOfCard set, List<Card> bestHand) player2)
        {
            if (player1.set == player2.set)
            {
                for (int i = 0; i < player1.bestHand.Count; i++)
                {
                    if (player1.bestHand[i].TypeOfCard > player2.bestHand[i].TypeOfCard)
                    {
                        Console.WriteLine("player1 won");
                        return;
                    }
                    else if (player1.bestHand[i].TypeOfCard < player2.bestHand[i].TypeOfCard)
                    {
                        Console.WriteLine("player2 won");
                        return;
                    }
                }
                Console.WriteLine("draw");
            }
            else if (player1.set > player2.set)
            Console.WriteLine("player1 won");
            else if (player1.set < player2.set)
            Console.WriteLine("player2 won");
        }
    }
}

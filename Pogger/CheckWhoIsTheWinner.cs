using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class CheckWhoIsTheWinner
    {
        public static void CheckTheWinner(PokerPlayer player1, PokerPlayer player2)
        {
            if (player1.StrongestSet != (SetsOfCards)0 || player2.StrongestSet != (SetsOfCards)0)
            {


                if (player1.StrongestSet == player2.StrongestSet)
                {
                    for (int i = 0; i < player1.StrongestCardsInSet.Count; i++)
                    {
                        if (player1.StrongestCardsInSet[i].TypeOfCard > player2.StrongestCardsInSet[i].TypeOfCard)
                        {
                            Console.WriteLine("wygrał player1");
                            Environment.Exit(1);

                        }
                        else if (player1.StrongestCardsInSet[i].TypeOfCard < player2.StrongestCardsInSet[i].TypeOfCard)
                        {
                            Console.WriteLine("wygrał player2");
                            Environment.Exit(1);

                        }
                    }
                    Console.WriteLine("remis");
                    Environment.Exit(1);



                }

                else if (player1.StrongestSet > player2.StrongestSet)
                {
                    Console.WriteLine("wygrał player1");
                    Environment.Exit(1);

                }
                else if (player1.StrongestSet < player2.StrongestSet)
                {
                    Console.WriteLine("wygrał player2");
                    Environment.Exit(1);

                }
            }


        }
    }
}

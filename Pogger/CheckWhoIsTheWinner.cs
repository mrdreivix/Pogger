using System;

namespace Poker
{
    public class CheckWhoIsTheWinner
    {
        public static void CheckTheWinner(Player player1, Player player2)
        {
           


                if (player1.StrongestSet == player2.StrongestSet)
                {
                    for (int i = 0; i < player1.StrongestCardsInSet.Count; i++)
                    {
                        if (player1.StrongestCardsInSet[i].TypeOfCard > player2.StrongestCardsInSet[i].TypeOfCard)
                        {
                            Console.WriteLine("player1 won");
                        return;

                        }
                        else if (player1.StrongestCardsInSet[i].TypeOfCard < player2.StrongestCardsInSet[i].TypeOfCard)
                        {
                            Console.WriteLine("player2 won");
                        return;

                        }
                        
                    }
                    Console.WriteLine("draw");
                    



                }

                else if (player1.StrongestSet > player2.StrongestSet)
                {
                    Console.WriteLine("player1 won");
                    

                }
                else if (player1.StrongestSet < player2.StrongestSet)
                {
                    Console.WriteLine("player2 won");
                    

                }
            


        }
    }
}

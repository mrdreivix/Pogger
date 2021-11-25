using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public static class PlayerAndTableCardsConnector
    {
        public static List<Card> ConnectCards(List<Card> playerCards, List<Card> tableCards)
        {
            var allPlayerCards = new List<Card>();
            allPlayerCards.AddRange(tableCards);
            allPlayerCards.AddRange(playerCards);
            return allPlayerCards.OrderByDescending(s => s.TypeOfCard).ToList();
        }
    }
}

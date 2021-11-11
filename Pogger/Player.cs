using System.Collections.Generic;

namespace Poker
{
    public class Player
    {
        public string Name { get; set; }

        public List<Card> Cards = new List<Card>();

        public SetOfCard StrongestSet { get; set; }

        public List<Card> StrongestCardsInSet = new List<Card>();

        public List<Card> WithTableCards = new List<Card>();

    }
}

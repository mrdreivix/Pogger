using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class PokerPlayer
    {
        public string NameOfPlayer { get; set; }

        public List<Card> PlayersCards = new List<Card>();

        public SetsOfCards StrongestSet { get; set; }

        public List<Card> StrongestCardsInSet = new List<Card>();

    }
}

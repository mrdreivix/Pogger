using System.Collections.Generic;

namespace Poker
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();
    }
}

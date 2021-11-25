using System.Collections.Generic;

namespace Poker
{
    public class Player
    {
        public string Name { get; private set; }
        public List<Card> Cards { get; set; } = new List<Card>();

        public Player(string name)
        {
            Name = name;
        }
    }
}

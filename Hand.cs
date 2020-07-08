using System.Collections.Generic;

namespace PokerhandRanker
{
    public class Hand
    {
        public List<Card> Cards { get; }

        public Hand() => Cards = new List<Card>();

        public void Draw(Card card) => Cards.Add(card);
    }
}

using System.Linq;
using System.Collections.Generic;

namespace PokerhandRanker
{
    public class Hand
    {
        public List<Card> Cards { get; }

        public Hand() => Cards = new List<Card>();

        public void Draw(Card card) => Cards.Add(card);

        public CardValue HighCard() => Cards.Max(x => x.Value);

        public HandRank GetHandRank() => 
            HasRoyalFlush() ? HandRank.RoyalFlush : 
            HasFlush() ? HandRank.Flush : HandRank.HighCard;

        private bool HasFlush() => Cards.All(x => Cards.First().Suit == x.Suit);

        private bool HasRoyalFlush() => HasFlush() && Cards.All(x => x.Value > CardValue.Nine);
    }
}

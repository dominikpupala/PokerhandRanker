using System.Linq;
using System.Collections.Generic;

namespace PokerhandRanker
{
    public class Hand
    {
        public List<Card> Cards { get; } = new List<Card>();

        public void Draw(Card card) => Cards.Add(card);

        public Card HighCard() => Cards.Aggregate((x, y) => y.Value > x.Value ? y : x);

        public HandRank GetHandRank() =>
            HasRoyalFlush() ? HandRank.RoyalFlush :
            HasFlush() ? HandRank.Flush :
            HasNumberOfKind(4) ? HandRank.FourOfAKind :
            HasNumberOfKind(3) && HasNumberOfKind(2) ? HandRank.FullHouse :
            HasNumberOfKind(3) ? HandRank.ThreeOfAKind :
            HasNumberOfKind(2) ? HandRank.Pair : HandRank.HighCard;

        private bool HasFlush() => Cards.All(x => Cards.First().Suit == x.Suit);

        private bool HasRoyalFlush() => HasFlush() && Cards.All(x => x.Value > CardValue.Nine);

        private bool HasNumberOfKind(int n) => Cards.GroupBy(x => x.Value).Any(g => g.Count() == n);
    }
}

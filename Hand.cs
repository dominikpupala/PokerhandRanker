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
            HasFourOfKind() ? HandRank.FourOfAKind :
            HasFullHouse() ? HandRank.FullHouse :
            HasFlush() ? HandRank.Flush :
            HasThreeOfKind() ? HandRank.ThreeOfAKind :
            HasPair() ? HandRank.Pair : HandRank.HighCard;

        private bool HasRoyalFlush() => HasFlush() && Cards.All(x => x.Value > CardValue.Nine);

        private bool HasFlush() => Cards.All(x => Cards.First().Suit == x.Suit);

        private bool HasFullHouse() => HasThreeOfKind() && HasPair();

        private bool HasFourOfKind() => HasNumberOfKind(4);

        private bool HasThreeOfKind() => HasNumberOfKind(3);

        private bool HasPair() => HasNumberOfKind(2);

        private bool HasNumberOfKind(int n) => Cards.QuantitiesOfKind().Any(i => i.Value == n);
    }
}

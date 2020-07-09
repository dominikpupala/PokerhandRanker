using System.Linq;
using System.Collections.Generic;

namespace PokerhandRanker
{
    public static class FiveCardPokerScorer
    {
        public static Card HighCard(IEnumerable<Card> cards) => cards.Aggregate((x, y) => y.Value > x.Value ? y : x);

        public static HandRank GetHandRank(IEnumerable<Card> cards) =>
            HasRoyalFlush(cards) ? HandRank.RoyalFlush :
            HasFourOfKind(cards) ? HandRank.FourOfAKind :
            HasFullHouse(cards) ? HandRank.FullHouse :
            HasFlush(cards) ? HandRank.Flush :
            HasStraight(cards) ? HandRank.Straight :
            HasThreeOfKind(cards) ? HandRank.ThreeOfAKind :
            HasPair(cards) ? HandRank.Pair : HandRank.HighCard;

        private static bool HasRoyalFlush(IEnumerable<Card> cards) => HasFlush(cards) && cards.All(x => x.Value > CardValue.Nine);

        private static bool HasFlush(IEnumerable<Card> cards) => cards.All(x => cards.First().Suit == x.Suit);

        private static bool HasStraight(IEnumerable<Card> cards) => cards.OrderByDescending(x => x.Value).SelectConsecutive((x, y) => x.Value == y.Value + 1).All(v => v);

        private static bool HasFullHouse(IEnumerable<Card> cards) => HasThreeOfKind(cards) && HasPair(cards);

        private static bool HasFourOfKind(IEnumerable<Card> cards) => HasNumberOfKind(cards, 4);

        private static bool HasThreeOfKind(IEnumerable<Card> cards) => HasNumberOfKind(cards, 3);

        private static bool HasPair(IEnumerable<Card> cards) => HasNumberOfKind(cards, 2);

        private static bool HasNumberOfKind(IEnumerable<Card> cards, int n) => cards.QuantitiesOfKind().Any(i => i.Value == n);
    }
}

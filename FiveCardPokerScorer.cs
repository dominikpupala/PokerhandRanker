using System.Linq;
using System.Collections.Generic;
using System;

namespace PokerhandRanker
{
    public static class FiveCardPokerScorer
    {
        public static Card HighCard(IEnumerable<Card> cards) => cards.Aggregate((x, y) => y.Value > x.Value ? y : x);

        public static HandRank GetHandRank(IEnumerable<Card> cards) => Rankings().OrderByDescending(t => t.rank).First(t => t.eval(cards)).rank;

        private static bool HasRoyalFlush(IEnumerable<Card> cards) => HasFlush(cards) && cards.All(x => x.Value > CardValue.Nine);

        private static bool HasStraightFlush(IEnumerable<Card> cards) => HasStraight(cards) && HasFlush(cards);

        private static bool HasFlush(IEnumerable<Card> cards) => cards.All(x => cards.First().Suit == x.Suit);

        private static bool HasStraight(IEnumerable<Card> cards) => cards.OrderByDescending(x => x.Value).SelectConsecutive((x, y) => x.Value == y.Value + 1).All(v => v);

        private static bool HasFullHouse(IEnumerable<Card> cards) => HasThreeOfAKind(cards) && HasPair(cards);

        private static bool HasFourOfAKind(IEnumerable<Card> cards) => HasNumberOfKind(cards, 4);

        private static bool HasThreeOfAKind(IEnumerable<Card> cards) => HasNumberOfKind(cards, 3);

        private static bool HasTwoPair(IEnumerable<Card> cards) => cards.QuantitiesOfKind().Count(x => x.Value == 2) == 2;

        private static bool HasPair(IEnumerable<Card> cards) => HasNumberOfKind(cards, 2);

        private static bool HasNumberOfKind(IEnumerable<Card> cards, int n) => cards.QuantitiesOfKind().Any(i => i.Value == n);

        private static List<(Func<IEnumerable<Card>, bool> eval, HandRank rank)> Rankings() =>
            new List<(Func<IEnumerable<Card>, bool> eval, HandRank rank)>
            {
                (cards => HasRoyalFlush(cards), HandRank.RoyalFlush),
                (cards => HasStraightFlush(cards), HandRank.StraightFlush),
                (cards => HasFourOfAKind(cards), HandRank.FourOfAKind),
                (cards => HasFullHouse(cards), HandRank.FullHouse),
                (cards => HasFlush(cards), HandRank.Flush),
                (cards => HasStraight(cards), HandRank.Straight),
                (cards => HasThreeOfAKind(cards), HandRank.ThreeOfAKind),
                (cards => HasTwoPair(cards), HandRank.TwoPair),
                (cards => HasPair(cards), HandRank.Pair),
                (cards => true, HandRank.HighCard)
            };
    }
}

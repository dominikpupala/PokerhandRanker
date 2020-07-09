using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace PokerhandRanker
{
    public static class HandExtensions
    {
        public static IEnumerable<KeyValuePair<CardValue, int>> QuantitiesOfKind(this IEnumerable<Card> cards)
        {
            ConcurrentDictionary<CardValue, int> dictionary = new ConcurrentDictionary<CardValue, int>();
            foreach (Card card in cards) dictionary.AddOrUpdate(card.Value, 1, (x, c) => ++c);

            return dictionary;
        }

        public static IEnumerable<TResult> SelectConsecutive<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TSource, TResult> selector)
        {
            for (int i = 1; i < source.Count(); ++i) yield return selector(source.ElementAt(i - 1), source.ElementAt(i));
        }
    }
}

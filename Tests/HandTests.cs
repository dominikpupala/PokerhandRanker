using System.Linq;

using Xunit;

namespace PokerhandRanker.Tests
{
    public class HandTests
    {
        [Fact]
        public void CanCreateHand()
        {
            Hand hand = new Hand();

            Assert.False(hand.Cards.Any());
        }

        [Fact]
        public void CanHandDrawCard()
        {
            Card card = new Card(CardValue.Queen, CardSuit.Hearts);
            Hand hand = new Hand();

            hand.Draw(card);

            Assert.Equal(hand.Cards.First(), card);
        }

        [Fact]
        public void CanGetHighCard()
        {
            Hand hand = new Hand();

            hand.Draw(new Card(CardValue.Seven, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
            hand.Draw(new Card(CardValue.Five, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.Two, CardSuit.Hearts));

            Assert.Equal(CardValue.King, hand.HighCard());
        }

        [Fact]
        public void CanScoreHighCard()
        {
            Hand hand = new Hand();

            hand.Draw(new Card(CardValue.Seven, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
            hand.Draw(new Card(CardValue.Five, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.Two, CardSuit.Hearts));

            Assert.Equal(HandRank.HighCard, hand.GetHandRank());
        }

        [Fact]
        public void CanScoreFlush()
        {
            Hand hand = new Hand();

            hand.Draw(new Card(CardValue.Two, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Three, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Five, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Six, CardSuit.Spades));

            Assert.Equal(HandRank.Flush, hand.GetHandRank());
        }
        [Fact]
        public void CanScoreRoyalFlush()
        {
            Hand hand = new Hand();

            hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Queen, CardSuit.Spades));
            hand.Draw(new Card(CardValue.King, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));

            Assert.Equal(HandRank.RoyalFlush, hand.GetHandRank());
        }
    }
}

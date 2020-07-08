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
    }
}

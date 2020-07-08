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
    }
}

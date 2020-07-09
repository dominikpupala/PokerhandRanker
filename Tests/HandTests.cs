using System.Linq;

using Xunit;
using FluentAssertions;

namespace PokerhandRanker.Tests
{
    public class HandTests
    {
        [Fact]
        public void CanCreateHand()
        {
            Hand hand = new Hand();

            hand.Cards.Any().Should().BeFalse();
        }

        [Fact]
        public void CanHandDrawCard()
        {
            Card card = new Card(CardValue.Queen, CardSuit.Hearts);
            Hand hand = new Hand();

            hand.Draw(card);

            hand.Cards.First().Should().Be(card);
        }
    }
}

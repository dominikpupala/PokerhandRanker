using Xunit;
using FluentAssertions;

namespace PokerhandRanker.Tests
{
    public class CardTests
    {
        [Fact]
        public void CanCreateCardWithValue()
        {
            Card card = new Card(CardValue.Queen, CardSuit.Hearts);

            card.Suit.Should().Be(CardSuit.Hearts);
            card.Value.Should().Be(CardValue.Queen);
        }

        [Fact]
        public void CanDescribeCard()
        {
            Card card = new Card(CardValue.Queen, CardSuit.Hearts);

            card.ToString().Should().Be("Queen of Hearts");
        }
    }
}

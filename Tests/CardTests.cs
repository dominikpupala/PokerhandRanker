using Xunit;

namespace PokerhandRanker.Tests
{
    public class CardTests
    {
        [Fact]
        public void CanCreateCardWithValue()
        {
            Card card = new Card(CardValue.Queen, CardSuit.Hearts);

            Assert.Equal(CardSuit.Hearts, card.Suit);
            Assert.Equal(CardValue.Queen, card.Value);
        }
    }
}

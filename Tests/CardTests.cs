using Xunit;

namespace PokerhandRanker.Tests
{
    public class CardTests
    {
        [Fact]
        public void CanCreateCard()
        {
            object card = new Card();
            Assert.NotNull(card);
        }
    }
}

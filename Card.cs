namespace PokerhandRanker
{
    public class Card
    {
        public Card(CardValue value, CardSuit suit)
        {
            Suit = suit; 
            Value = value;
        }

        public CardSuit Suit { get; set; }
        public CardValue Value { get; set; }
    }
}

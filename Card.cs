namespace PokerhandRanker
{
    public class Card
    {
        public CardSuit Suit { get; }

        public CardValue Value { get; }

        public Card(CardValue value, CardSuit suit)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString() =>  $"{Value} of {Suit}";
    }
}

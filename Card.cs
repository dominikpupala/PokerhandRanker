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

        public override string ToString()
        {
            // string interpolation syntax
            // enum is custom made object
            // no override for ToString()
            return $"{Value} of {Suit}";
        }
    }
}

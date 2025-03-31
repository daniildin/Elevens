namespace ElevensGameModels
{
    public enum Suit { Hearts, Diamonds, Clubs, Spades }
    public enum Rank { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

    public class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }
        public int Value => (int)Rank;
        public bool IsFaceUp { get; set; } = true;

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            string suitSymbol;
            switch (Suit)
            {
                case Suit.Hearts:
                    suitSymbol = "♥";
                    break;
                case Suit.Diamonds:
                    suitSymbol = "♦";
                    break;
                case Suit.Clubs:
                    suitSymbol = "♣";
                    break;
                case Suit.Spades:
                    suitSymbol = "♠";
                    break;
                default:
                    suitSymbol = "?";
                    break;
            }
            return $"[{Rank} {suitSymbol}]";
        }
    }
}

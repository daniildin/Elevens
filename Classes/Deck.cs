namespace ElevensGameModels
{
    using System;
    using System.Collections.Generic;

    public class Deck
    {
        public List<Card> Cards { get; private set; } = new List<Card>();

        public void CreateDeck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    Cards.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            for (int i = Cards.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (Cards[i], Cards[j]) = (Cards[j], Cards[i]);
            }
        }

        public Card DrawCard()
        {
            if (Cards.Count == 0) return null;
            Card drawnCard = Cards[0];
            Cards.RemoveAt(0);
            return drawnCard;
        }
    }
}

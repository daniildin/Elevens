namespace ElevensGameModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Board
    {
        public Deck Deck { get; private set; } = new Deck();
        public List<Card> TableCards { get; private set; } = new List<Card>();

        public Board()
        {
            Deck.CreateDeck();
            Deck.Shuffle();
            SetUpBoard();
        }

        public void SetUpBoard()
        {
            TableCards.Clear();
            for (int i = 0; i < 9; i++)
            {
                Card card = Deck.DrawCard();
                if (card != null)
                {
                    TableCards.Add(card);
                }
                else
                {
                    Console.WriteLine("Deck doesn't have enough cards to set up the board.");
                    break;
                }
            }
        }

        public void ReplaceCards(int index1, int index2, int index3 = -1)
        {
            Console.WriteLine($"Replacing indices: {index1}, {index2}, {index3}");
            if (AreValidIndices(index1, index2, index3))
            {
                ReplaceCardAt(index1);
                ReplaceCardAt(index2);
                if (index3 != -1) ReplaceCardAt(index3);
            }
            else
            {
                Console.WriteLine("Invalid indices for card replacement.");
            }
        }

        private bool AreValidIndices(params int[] indices)
        {
            return indices.All(index => index == -1 || (index >= 0 && index < TableCards.Count));
        }

        private void ReplaceCardAt(int index)
        {
            Card newCard = Deck.DrawCard();
            if (newCard != null)
            {
                TableCards[index] = newCard;
            }
            else
            {
                Console.WriteLine("Deck is empty, cannot draw a new card.");
            }
        }

        public bool HasValidMove()
        {
            // Check for pairs summing to 11
            for (int i = 0; i < TableCards.Count; i++)
            {
                for (int j = i + 1; j < TableCards.Count; j++)
                {
                    if (TableCards[i].Value + TableCards[j].Value == 11)
                        return true;
                }
            }

            // Check for J, Q, K set
            return TableCards.Any(c => c.Rank == Rank.Jack) &&
                   TableCards.Any(c => c.Rank == Rank.Queen) &&
                   TableCards.Any(c => c.Rank == Rank.King);
        }
    }
}

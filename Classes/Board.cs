namespace ElevensGameModels
{
    using System;
    using System.Collections.Generic;

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
                TableCards.Add(Deck.DrawCard());
            }
        }

        public void ReplaceCards(int index1, int index2, int index3 = -1)
        {
            if (index3 == -1)
            {
                TableCards[index1] = Deck.DrawCard();
                TableCards[index2] = Deck.DrawCard();
            }
            else
            {
                TableCards[index1] = Deck.DrawCard();
                TableCards[index2] = Deck.DrawCard();
                TableCards[index3] = Deck.DrawCard();
            }
        }

        public bool ContainsRank(Card card, Rank rank)
        {
            return TableCards.Exists(c => c.Rank == rank && c != card);
        }
    }
}

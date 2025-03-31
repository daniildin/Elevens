namespace ElevensGameModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Elevens
    {
        public Board Board { get; private set; }
        public List<Card> SelectedCards { get; private set; } = new List<Card>();
        public int GamesPlayed { get; private set; } = 0;
        public int GamesWon { get; private set; } = 0;

        public Elevens()
        {
            Board = new Board();
        }

        public void SetUp()
        {
            Board.SetUpBoard();
            SelectedCards.Clear();
        }

        public void SelectCard(Card card)
        {
            if (SelectedCards.Count < 3 && !SelectedCards.Contains(card))
                SelectedCards.Add(card);
        }

        public void DeselectCard(Card card)
        {
            SelectedCards.Remove(card);
        }

        public bool ValidateReplace()
        {
            if (SelectedCards.Count == 2)
            {
                return SelectedCards[0].Value + SelectedCards[1].Value == 11;
            }
            else if (SelectedCards.Count == 3)
            {
                return SelectedCards.Any(c => c.Rank == Rank.Jack) &&
                       SelectedCards.Any(c => c.Rank == Rank.Queen) &&
                       SelectedCards.Any(c => c.Rank == Rank.King);
            }
            return false;
        }

        public bool ValidMoveRemaining()
        {
            return Board.HasValidMove();
        }

        public void OnReplace()
        {
            if (ValidateReplace())
            {
                var indices = SelectedCards.Select(card => Board.TableCards.IndexOf(card)).ToList();
                foreach (var card in SelectedCards)
                {
                    Board.TableCards.Remove(card);
                }
                Board.ReplaceCards(indices[0], indices[1], indices.Count > 2 ? indices[2] : -1);
                SelectedCards.Clear();
            }
        }

        public void OnRestart()
        {
            SetUp();
            GamesPlayed++;
        }

        public void OnWin()
        {
            GamesWon++;
            Console.WriteLine("You win!");
        }

        public void OnLose()
        {
            Console.WriteLine("You lose.");
        }
    }
}

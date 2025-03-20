namespace ElevensGameModels
{
    using System;
    using System.Collections.Generic;

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
        }

        public void SelectCard(Card card)
        {
            if (SelectedCards.Count < 3)
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
                var sum = SelectedCards[0].Value + SelectedCards[1].Value;
                return sum == 11;
            }
            else if (SelectedCards.Count == 3)
            {
                return SelectedCards.Exists(c => c.Rank == Rank.Jack) &&
                       SelectedCards.Exists(c => c.Rank == Rank.Queen) &&
                       SelectedCards.Exists(c => c.Rank == Rank.King);
            }
            return false;
        }

        public bool ValidMoveRemaining()
        {
            return SelectedCards.Count > 0;
        }

        public void OnReplace()
        {
            if (ValidateReplace())
            {
                foreach (var card in SelectedCards)
                {
                    Board.TableCards.Remove(card);
                    Board.ReplaceCards(Board.TableCards.IndexOf(card), Board.TableCards.IndexOf(card));
                }
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

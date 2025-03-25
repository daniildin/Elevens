namespace ElevensGame
{
    using System;
    using System.Linq;
    using ElevensGameModels;

    class Program
    {
        static void Main()
        {
            Elevens elevens = new Elevens();
            bool playing = true;

            while (playing)
            {
                elevens.SetUp();
                Console.Clear();
                Console.WriteLine("Welcome to Elevens Solitaire!");
                PlayGame(elevens);

                Console.WriteLine("Do you want to play again? (Y/N)");
                playing = Console.ReadLine().Trim().ToUpper() == "Y";
            }
        }

        static void DisplayBoard(Elevens elevens)
        {
            Console.WriteLine("\nCurrent Board:");
            for (int i = 0; i < elevens.Board.TableCards.Count; i++)
            {
                var card = elevens.Board.TableCards[i];
                Console.WriteLine($"{i + 1}: {card.Rank} of {card.Suit}");
            }
        }

        static bool IsValidSelection(int[] indexes, Elevens elevens)
        {
            // Check that the selection has two or three valid indexes.
            if (indexes.Length != 2 && indexes.Length != 3)
            {
                Console.WriteLine("You must select exactly two or three cards.");
                return false;
            }

            // Validate that all indexes are within the correct range.
            foreach (int index in indexes)
            {
                if (index < 0 || index >= elevens.Board.TableCards.Count)
                {
                    Console.WriteLine("Invalid card number. Please select a valid card.");
                    return false;
                }
            }

         
            return true;
        }

        static void PlayGame(Elevens elevens)
        {
            while (true)
            {
                DisplayBoard(elevens);
                Console.WriteLine("Select two or three cards (e.g., 1 2 3) or type 'Q' to quit:");
                string input = Console.ReadLine().Trim();

                if (input.ToUpper() == "Q") break;

                // Parse the input into indexes
                int[] selectedIndexes = input.Split(' ')
                                              .Select(s => int.TryParse(s, out int index) ? index - 1 : -1)
                                              .ToArray();

                // Validate the selection before proceeding.
                if (!IsValidSelection(selectedIndexes, elevens)) continue;

                // Clear previous selections
                elevens.SelectedCards.Clear();

                // Add the selected cards
                foreach (int index in selectedIndexes)
                {
                    elevens.SelectCard(elevens.Board.TableCards[index]);
                }

                // Perform the replacement if valid
                if (elevens.ValidateReplace())
                {
                    elevens.OnReplace();
                    Console.WriteLine("Cards replaced successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid move. The selected cards don't meet the criteria for a valid move.");
                }

                // Check for win condition
                if (!elevens.ValidMoveRemaining())
                {
                    Console.WriteLine("No more valid moves.");
                    elevens.OnWin();
                    break;
                }
            }
        }
    }
}


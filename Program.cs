namespace ElevensGame
{
    using System;
    using System.Collections.Generic;
    using ElevensGameModels;

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                var card = new ElevensGameModels.Card(ElevensGameModels.Suit.Hearts, ElevensGameModels.Rank.Ace);
                Console.WriteLine(card.ToString());
                Elevens game = new Elevens();
                game.SetUp();

                while (true)
                {
                    DisplayBoard(game);

                    if (!game.ValidMoveRemaining())
                    {
                        Console.WriteLine("No valid moves left! You lose.");
                        game.OnLose();
                        break;
                    }

                    Console.Write("Select card indices (comma-separated) or 'q' to quit: ");
                    string input = Console.ReadLine();

                    if (input.Trim().ToLower() == "q")
                    {
                        Console.Write("Do you want to restart the game? (y/n): ");
                        string restartInput = Console.ReadLine();
                        if (restartInput.Trim().ToLower() == "y")
                        {
                            break; // Break the inner loop to restart the game
                        }
                        else
                        {
                            Console.WriteLine("Quitting the game. Goodbye!");
                            return; // Exit the application
                        }
                    }

                    var indices = ParseIndices(input, game.Board.TableCards.Count);

                    if (indices.Count == 2 || indices.Count == 3)
                    {
                        game.SelectedCards.Clear();
                        foreach (var index in indices)
                        {
                            game.SelectCard(game.Board.TableCards[index]);
                        }

                        if (game.ValidateReplace())
                        {
                            game.OnReplace();
                            Console.WriteLine("Cards replaced successfully! Board updated.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection. The selected cards do not meet the game's rules. Try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please select exactly 2 or 3 valid card indices.");
                    }
                }
            }
        }

        static void DisplayBoard(Elevens game)
        {
            Console.WriteLine("\nCurrent Board:");
            for (int i = 0; i < game.Board.TableCards.Count; i++)
            {
                var card = game.Board.TableCards[i];
                Console.WriteLine($"[{i + 1}] {card}");
            }
            Console.WriteLine($"Cards left in deck: {game.Board.Deck.CardsRemaining()}");
        }

        static List<int> ParseIndices(string input, int maxIndex)
        {
            var indices = new List<int>();
            var parts = input.Split(',');
            foreach (var part in parts)
            {
                if (int.TryParse(part.Trim(), out int index) && index > 0 && index <= maxIndex)
                {
                    indices.Add(index - 1);
                }
                else
                {
                    Console.WriteLine("Invalid index detected. Please enter valid card numbers.");
                    return new List<int>();
                }
            }
            return indices;
        }
    }
}

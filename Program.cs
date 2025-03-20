namespace ElevensGame
{
    using System;
    using ElevensGameModels;

    class Program
    {
        static void Main()
        {
            Elevens elevens = new Elevens();
            elevens.SetUp();

            Console.WriteLine("Welcome to Elevens Solitaire!");
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();

            // Example logic (you may expand the game logic here)
            elevens.SelectCard(elevens.Board.TableCards[0]);
            elevens.SelectCard(elevens.Board.TableCards[1]);

            if (elevens.ValidateReplace())
            {
                elevens.OnReplace();
                elevens.OnWin();
            }
            else
            {
                elevens.OnLose();
            }

            Console.WriteLine("Game Over.");
        }
    }
}


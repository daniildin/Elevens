# Elevens Solitaire Game

Elevens Solitaire is a console-based solitaire game where the goal is to select and replace cards that add up to 11 or form a Jack, Queen, and King combination. This game is played with a deck of 52 cards.

## Features

- **Card Selection**: Players can select two or three cards to form a valid set.
- **Valid Moves**: A valid move is either:
  - Two cards whose values add up to 11.
  - A combination of a Jack, Queen, and King.
- **Game Replay**: After the game ends, players can choose to play again.
- **Deck Shuffling**: The deck is shuffled before each game, providing a new setup each time.
- **Card Replacement**: Valid selections replace the selected cards with new cards drawn from the deck.
- **Win Condition**: The player wins if there are no more valid moves remaining.

## Setup

1. Clone this repository to your local machine.
2. Open the solution in Visual Studio or another C# IDE.
3. Build and run the project.
4. The game will display the board and prompt you for input.

## Gameplay

- **Selecting Cards**: Players select two or three cards by their number. The game will prompt you to enter a selection, for example, "1 2 3" (to select the first, second, and third cards).
- **Validating Selection**: After each selection, the game checks if the cards selected form a valid set (either adding up to 11 or forming a Jack, Queen, and King combination).
- **Replacing Cards**: If the selection is valid, the selected cards are replaced with new cards drawn from the deck.
- **Win Condition**: The game checks for any remaining valid moves. If no valid moves are left, you win.

## Code Structure

### `Program.cs`
Contains the main game logic. This file is responsible for:
- Starting the game.
- Displaying the board.
- Handling user input for card selection.
- Managing the game loop and replay options.

### `Board.cs`
Represents the game board. This file handles:
- Managing the deck of cards.
- Setting up the table with cards.
- Replacing cards when valid moves are made.

### `Deck.cs`
Manages the deck of 52 cards. This file is responsible for:
- Creating and shuffling the deck.
- Drawing cards from the deck when needed.

### `Card.cs`
Represents a single card in the deck. This file handles:
- Storing the suit and rank of each card.
- Calculating the value of a card based on its rank.

### `Elevens.cs`
Manages the game's state. This file is responsible for:
- Handling card selection and validation.
- Managing the player's progress and wins.

## Requirements

- .NET Core 3.1 or later.
- C# IDE (e.g., Visual Studio, VS Code) to compile and run the program.

## License

This project is open-source and available under the MIT License. See the [LICENSE](LICENSE) file for more details.

## How to Play

1. Start the game.
2. The current table will be displayed, and you'll be asked to select two or three cards.
3. After entering your selection, the game will validate your move and replace cards if the selection is valid.
4. If there are no more valid moves, the game ends, and you win.
5. You will be prompted if you want to play again.

### First Update

## Game Loop
I’ve added a loop to allow the user to play the game repeatedly without needing to restart the application. This makes the game more user-friendly since players can choose whether they want to play again after finishing a round. The game automatically resets for a new session when the player chooses to play again.

## Game Display
The `DisplayBoard` function prints the current state of the board, showing the cards that are currently on the table. This is a key feature for providing feedback to the player, allowing them to clearly see the current game setup and make informed choices.

## Input Validation
To ensure the game runs smoothly, I’ve implemented the `IsValidSelection` function. This checks the user’s input for selecting cards, ensuring that the cards they choose form a valid set. By validating the input before proceeding, this reduces the chances of errors or invalid moves, which keeps the game flowing without interruption.

## Card Replacement
In the `ReplaceCards` method, I’ve added a check to make sure the indices provided for replacing cards are valid. This prevents any errors related to incorrect card positions and ensures that only valid moves are made. The game will prompt the player to make a valid move if the indices are incorrect.

## Endgame Conditions
Finally, I’ve implemented an endgame check that determines when the game should end. If no valid moves are remaining, the game will end automatically, giving the player a satisfying conclusion. This ensures that the game doesn’t drag on indefinitely and wraps up in a meaningful way.

### Final Update

- **Board.cs:**I improved `ValidMoveRemaining()` to check if valid moves exist.
- **Card.cs:** I improved formatting for better readability.
- **Deck.cs:**I added deck count display.
- **Elevens.cs:**I improved validation with clearer error messages.
- **Program.cs:** I enhanced user input handling and board display.

## How to Compile and Run
### Prerequisites
- .NET SDK installed ([Download Here](https://dotnet.microsoft.com/en-us/download))

### Steps
1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/ElevensGame.git
   cd ElevensGame
   ```
2. Build the project:
   ```sh
   dotnet build
   ```
3. Run the game:
   ```sh
   dotnet run
   ```

## Challenges and Solutions 
### Challenge 1: Invalid Move Handling
**Problem:** The game was incorrectly replacing invalid card selections.  
**Solution:** Improved `ValidateReplace()` to give clearer error messages and reject bad input.

### Challenge 2: Board Display Readability
**Problem:** Players found it hard to read the board layout.  
**Solution:** Reformatted board output and added deck count information.

### Challenge 3: Input Handling
**Problem:** Users could enter invalid indices, causing crashes.  
**Solution:** Enhanced input validation to reject invalid selections and provide user feedback.

## Future Enhancementsthat I might work on individually
- Implementing a GUI version using WPF.
- Adding a scoring system.
- Enhancing AI for hint suggestions.


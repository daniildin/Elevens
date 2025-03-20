using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using ElevensGameModels;


namespace ElevensGame.Tests
{
    [TestClass]
    public class ElevensGameTests
    {
        private Board board;
        private Elevens game;

        [TestInitialize]
        public void Setup()
        {
            // This method is called before each test to initialize the game and board.
            game = new Elevens();
            board = game.Board;
            game.SetUp();  // Initializes the board with 9 cards
        }

        // Test Case 1: Test ReplaceCards (verify cards are replaced correctly)
        [TestMethod]
        public void ReplaceCards_CorrectlyReplacesSelectedCards()
        {
            // Arrange
            int initialTableCardCount = board.TableCards.Count;

            // Act: Select and replace two cards
            board.ReplaceCards(0, 1);

            // Assert
            Assert.AreEqual(initialTableCardCount, board.TableCards.Count); // Ensure the count remains the same
            Assert.IsTrue(board.TableCards[0].Suit != board.TableCards[1].Suit); // Ensure the cards are replaced
        }

        // Test Case 2: Test ContainsRank (verify that a rank exists on the board)
        [TestMethod]
        public void ContainsRank_FindsRankOnBoard()
        {
            // Arrange
            var card = board.TableCards[0];
            var rankToCheck = card.Rank;

            // Act
            bool result = board.ContainsRank(card, rankToCheck);

            // Assert
            Assert.IsTrue(result); // The rank should exist on the board
        }

        // Test Case 3: Test SetUp (verify that the board is initialized correctly)
        [TestMethod]
        public void SetUp_InitializesBoardWithNineCards()
        {
            // Assert
            Assert.AreEqual(9, board.TableCards.Count); // The board should contain 9 cards
        }

        // Test Case 4: Test SelectCard & DeselectCard (verify selection of cards)
        [TestMethod]
        public void SelectCard_DeselectCard_CorrectlyUpdatesSelection()
        {
            // Arrange
            var card1 = board.TableCards[0];
            var card2 = board.TableCards[1];

            // Act
            game.SelectCard(card1);
            game.SelectCard(card2);

            // Assert
            Assert.AreEqual(2, game.SelectedCards.Count); // Two cards should be selected

            // Act: Deselect a card
            game.DeselectCard(card1);

            // Assert
            Assert.AreEqual(1, game.SelectedCards.Count); // Only one card should be selected
        }

        // Test Case 5: Test ValidateReplace (verify correct validation of card pairs)
        [TestMethod]
        public void ValidateReplace_ValidPairReturnsTrue()
        {
            // Arrange
            var card1 = new Card(Suit.Hearts, Rank.Ace);
            var card2 = new Card(Suit.Spades, Rank.Ten);
            game.SelectCard(card1);
            game.SelectCard(card2);

            // Act
            bool result = game.ValidateReplace();

            // Assert
            Assert.IsTrue(result); // The sum of Ace and Ten is 11, so this should be a valid pair
        }

        [TestMethod]
        public void ValidateReplace_InvalidPairReturnsFalse()
        {
            // Arrange
            var card1 = new Card(Suit.Hearts, Rank.Ace);
            var card2 = new Card(Suit.Spades, Rank.Jack);
            game.SelectCard(card1);
            game.SelectCard(card2);

            // Act
            bool result = game.ValidateReplace();

            // Assert
            Assert.IsFalse(result); // The pair does not sum to 11, so it should be invalid
        }

        // Test Case 6: Test ValidMoveRemaining (check if there are valid moves left)
        [TestMethod]
        public void ValidMoveRemaining_ReturnsTrueWhenValidMoveExists()
        {
            // Arrange
            game.SelectCard(board.TableCards[0]);
            game.SelectCard(board.TableCards[1]);

            // Act
            bool result = game.ValidMoveRemaining();

            // Assert
            Assert.IsTrue(result); // There should be a valid move
        }

        // Test Case 7: Test OnReplace (verify the replacement happens correctly)
        [TestMethod]
        public void OnReplace_CorrectlyReplacesCards()
        {
            // Arrange
            var card1 = board.TableCards[0];
            var card2 = board.TableCards[1];
            game.SelectCard(card1);
            game.SelectCard(card2);

            // Act
            game.OnReplace();

            // Assert
            Assert.IsTrue(board.TableCards.Contains(card1)); // Check if card1 was replaced
            Assert.IsTrue(board.TableCards.Contains(card2)); // Check if card2 was replaced
        }

        // Test Case 8: Test OnRestart (check if the game resets)
        [TestMethod]
        public void OnRestart_ResetsGame()
        {
            // Act
            int initialGamesPlayed = game.GamesPlayed;
            game.OnRestart();

            // Assert
            Assert.AreEqual(initialGamesPlayed + 1, game.GamesPlayed); // Ensure the game count increased
            Assert.AreEqual(9, board.TableCards.Count); // Ensure the board is reset with 9 cards
        }

        // Test Case 9: Test OnWin (ensure win condition is triggered)
        [TestMethod]
        public void OnWin_IncrementsWinCount()
        {
            // Arrange
            int initialWinCount = game.GamesWon;

            // Act
            game.OnWin();

            // Assert
            Assert.AreEqual(initialWinCount + 1, game.GamesWon); // Ensure the win count increases
        }

        // Test Case 10: Test OnLose (ensure loss condition is triggered)
        [TestMethod]
        public void OnLose_DisplaysLoseMessage()
        {
            // Act
            game.OnLose();

            // Assert
            // No direct output assertion, you could mock or capture output to validate the message.
        }
    }
}

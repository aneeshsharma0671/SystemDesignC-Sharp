
using System.Collections;

namespace Game {
	public class TicTacToe {
		public enum PlayerToken {
			None = 0,
			X = 1,
			O = 2,
		}
		private List<List<PlayerToken>> board;
		private int currentPlayer = 0;
		private bool gameOver = false;
		public bool GameOver { get { return gameOver; } }
		public event EventHandler OnMoveMade = delegate { };
		public event EventHandler OnGameOver = delegate { };
		public class MoveEventArgs : EventArgs {
			public PlayerToken player;
			public int row;
			public int col;
		}

		public class GameOverEventArgs : EventArgs {
			public PlayerToken winner;
		}

		public TicTacToe() {
			int gridSize = 3;
			// Constructor
			board = new List<List<PlayerToken>>();
			for (int i = 0; i < gridSize; i++) {
				board.Add(new List<PlayerToken>());
				for (int j = 0; j < gridSize; j++) {
					board[i].Add(PlayerToken.None);
				}
			}

			currentPlayer = (int)PlayerToken.X;
		}

		private bool moveMade = false;
		public IEnumerator GameLoop() {
			gameOver = false;
			while (!IsBoardFull() && !CheckWin()) {
				moveMade = false;

				while (!moveMade) {
					// Wait for player input
					yield return null;
				}
			}

			// Game over
			gameOver = true;
			PlayerToken winner = GetWinner();
			OnGameOver(this, new GameOverEventArgs { winner = winner });
		}

		public void Update() {
			if (!gameOver) {
				GameLoop().MoveNext();
			}
		}

		public List<List<PlayerToken>> GetBoard() {
			return board;
		}

		private bool IsBoardFull() {
			foreach (List<PlayerToken> row in board) {
				foreach (PlayerToken cell in row) {
					if (cell == PlayerToken.None) {
						return false;
					}
				}
			}
			return true;
		}

		public bool MakeMove(int row, int col) {
			if (row < 0 || row >= board.Count || col < 0 || col >= board[0].Count || board[row][col] != PlayerToken.None || IsBoardFull()) {
				return false; // Invalid move
			}

			board[row][col] = (PlayerToken)currentPlayer;
			OnMoveMade(this, new MoveEventArgs { player = GetCurrPlayer(), row = row, col = col });
			moveMade = true;
			Update();

			currentPlayer = currentPlayer == (int)PlayerToken.X ? (int)PlayerToken.O : (int)PlayerToken.X; // Switch player
			return true;
		}

		private bool CheckWin() {
			// Check rows
			for (int i = 0; i < board.Count; i++) {
				if (board[i][0] != PlayerToken.None && board[i][0] == board[i][1] && board[i][1] == board[i][2]) {
					return true;
				}
			}

			// Check columns
			for (int i = 0; i < board[0].Count; i++) {
				if (board[0][i] != PlayerToken.None && board[0][i] == board[1][i] && board[1][i] == board[2][i]) {
					return true;
				}
			}

			// Check diagonals
			if (board[0][0] != PlayerToken.None && board[0][0] == board[1][1] && board[1][1] == board[2][2]) {
				return true;
			}
			if (board[0][2] != PlayerToken.None && board[0][2] == board[1][1] && board[1][1] == board[2][0]) {
				return true;
			}

			return false;
		}

		public PlayerToken GetCurrPlayer() {
			return (PlayerToken)currentPlayer;
		}

		public PlayerToken GetWinner() {
			if (CheckWin()) {
				return (PlayerToken)currentPlayer;
			}
			return PlayerToken.None;
		}

	}

}
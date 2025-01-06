using Game;

namespace ConsoleApp {
	class Program {
		static void Main(string[] args) {
			TicTacToe game = new TicTacToe();

			game.OnMoveMade += (sender, e) => {
				// Print board
				List<List<TicTacToe.PlayerToken>> board = game.GetBoard();
				for (int i = 0; i < board.Count; i++) {
					for (int j = 0; j < board[i].Count; j++) {
						Console.Write(board[i][j] + " ");
					}
					Console.WriteLine();
				}
			};

			game.OnGameOver += (sender, e) => {
				if (e is TicTacToe.GameOverEventArgs) {
					TicTacToe.GameOverEventArgs args = e as TicTacToe.GameOverEventArgs;
					TicTacToe.PlayerToken winner = args.winner;
					Console.WriteLine("Game over! Winner: " + winner);
				}
			};

			while (!game.GameOver) {
				// Get player input
				Console.WriteLine($"Enter row and column (0-2) for player: {game.GetCurrPlayer()}");
				string[] input = Console.ReadLine().Split();
				int row = Convert.ToInt32(input[0]);
				int col = Convert.ToInt32(input[1]);
				game.MakeMove(row, col);
			}
		}
	}
}

class InOut {
	// public static int ReadInt() {
	// 	return Convert.ToInt32(Console.ReadLine());
	// }

	// public static int[] ReadIntArray(int n) {
	// 	int[] arr = new int[n];
	// 	string elements = Console.ReadLine();
	// 	//elements = elements;
	// 	arr = Array.ConvertAll(elements.Split(), int.Parse);
	// 	return arr;
	// }

	// public static void PrintArr(int[] arr) {
	// 	string ret = "";
	// 	foreach (int a in arr) {
	// 		ret += a;
	// 	}
	// 	Console.WriteLine(ret);
	// }

}
using Game;

namespace ConsoleApp {
	class Program {
		static void Main(string[] args) {
			TicTacToe game = new TicTacToe();
			game.Initialize();
		}
	}
}

// class InOut {
// 	// public static int ReadInt() {
// 	// 	return Convert.ToInt32(Console.ReadLine());
// 	// }

// 	// public static int[] ReadIntArray(int n) {
// 	// 	int[] arr = new int[n];
// 	// 	string elements = Console.ReadLine();
// 	// 	//elements = elements;
// 	// 	arr = Array.ConvertAll(elements.Split(), int.Parse);
// 	// 	return arr;
// 	// }

// 	// public static void PrintArr(int[] arr) {
// 	// 	string ret = "";
// 	// 	foreach (int a in arr) {
// 	// 		ret += a;
// 	// 	}
// 	// 	Console.WriteLine(ret);
// 	// }

// }
using System;

namespace csharpProjectLearning {
    class Program {
        private const string V1 = "Player 1";
        private const string V = "Player 2";
        private static string[,] board = new string[3, 3];
        private static string winner = "";
        private static int playerTurn = 1;
        private const string player1Move = "X";
        private const string player2Move = "O";
        private static bool invalidMove = false;

        static void Main(string[] args) {
            int counter = 1;
            for (int i = 0; i < board.GetLength(0); i++) {
                for (int j = 0; j < board.GetLength(1); j++) {
                    board[i, j] = counter.ToString();
                    counter++;
                }

            }
            PrintBoard();

            int player1Choice = 0;
            int player2Choice = 0;
            string choice;

            while (IsGameEnded()) {
                switch (playerTurn) {
                    case 1:
                        try {
                            Console.WriteLine("Player X: Choose your field");
                            choice = Console.ReadLine();
                            Int32.TryParse(choice, out player1Choice);
                            MakeMove(player1Choice);
                            playerTurn = (invalidMove? 1: 2);
                        } catch (Exception) {
                            Console.WriteLine("Invalid input, please enter a number 1-9");
                            playerTurn = 1;
                            continue;
                        }
                        break;
                    case 2:
                        try {
                            Console.WriteLine("Player O: Choose your field");
                            choice = Console.ReadLine();
                            Int32.TryParse(choice, out player2Choice);
                            MakeMove(player2Choice);
                            playerTurn = (invalidMove? 2: 1);
                        } catch (Exception) {
                            Console.WriteLine("Invalid input, please enter a number 1-9");
                            playerTurn = 2;
                            continue;
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Winner: " + winner);
        }

        static void MakeMove(int playerChoice) {
            if (playerChoice < 4 && playerChoice > 0) {
                int col = playerChoice - 1;
                if (board[0, col] == "O" || board[0, col] == "X") {
                    Console.WriteLine("This field is already played. Please another field.");
                    invalidMove = true;
                    return;
                }
                board[0, col] = (playerTurn == 1 ? player1Move: player2Move);
            } else if (playerChoice < 7 && playerChoice > 3) {
                int col = playerChoice - 4;
                if (board[1, col] == "O" || board[1, col] == "X") {
                    Console.WriteLine("This field is already played. Please another field.");
                    invalidMove = true;
                    return;
                }
                board[1, col] = (playerTurn == 1 ? player1Move : player2Move);
            } else {
                int col = playerChoice - 7;
                if (board[2, col] == "O" || board[2, col] == "X") {
                    Console.WriteLine("This field is already played. Please another field.");
                    invalidMove = true;
                    return;
                }
                board[2, col] = (playerTurn == 1 ? player1Move : player2Move);
            }

            invalidMove = false;
            Console.Clear();
            PrintBoard();

        }

        static void PrintBoard() {
            for (int i = 0; i < board.GetLength(0); i++) {
                Console.WriteLine("");
                for (int k = 0; k < board.GetLength(1); k++) {
                    Console.Write("     |");
                }
                Console.WriteLine("");
                for (int j = 0; j < board.GetLength(1); j++) {
                    //Console.Write(" " + board[i, j] + " |");
                    Console.Write(String.Format("  {0}  |", board[i, j]));
                }
                Console.WriteLine("");
                if (i == board.GetLength(0) - 1) {
                    for (int k = 0; k < board.GetLength(1); k++) {
                        Console.Write("     |");
                    }
                } else {
                    for (int k = 0; k < board.GetLength(1); k++) {
                        Console.Write("_____|");
                    }
                }
            }
            Console.WriteLine("");
        }

        static bool IsGameEnded() {
            //Check row
            CheckRow();
            //Check column
            CheckCol();
            //Check diagonal left
            CheckDiagLeft();
            //Check diagonal right
            CheckDiagRight();

            return winner.Equals("");
        }

        static void CheckRow() {
            for (int i = 0; i < board.GetLength(0); i++) {
                int player1Counter = 0;
                int player2Counter = 0;
                for (int j = 0; j < board.GetLength(1); j++) {
                    if (board[i, j].Equals("O")) player1Counter++;
                    else if (board[i, j].Equals("X")) player2Counter++;
                }

                if (player1Counter == 3) {
                    winner = V;
                    break;
                }

                if (player2Counter == 3) {
                    winner = V1;
                    break;
                }
            }
        }

        static void CheckCol() {
            for (int j = 0; j < board.GetLength(1); j++) {
                int player1Counter = 0;
                int player2Counter = 0;
                for (int i = 0; i < board.GetLength(0); i++) {
                    if (board[i, j].Equals("O")) player1Counter++;
                    else if (board[i, j].Equals("X")) player2Counter++;
                }
                if (player1Counter == 3) {
                    winner = V;
                    break;
                }

                if (player2Counter == 3) {
                    winner = V1;
                    break;
                }
            }
        }

        static void CheckDiagLeft() {
            int player1Counter = 0;
            int player2Counter = 0;
            for (int i = 0; i < board.GetLength(0); i++) {
                if (board[i, i].Equals("O")) player1Counter++;
                else if (board[i, i].Equals("X")) player2Counter++;
            }
            if (player1Counter == 3) {
                winner = V;
            }

            if (player2Counter == 3) {
                winner = V1;
            }
        }

        static void CheckDiagRight() {
            int player1Counter = 0;
            int player2Counter = 0;
            int row = 0;
            for (int i = board.GetLength(0) - 1; i >= 0; i--) {
                if (board[row, i].Equals("O")) player1Counter++;
                else if (board[row, i].Equals("X")) player2Counter++;
                row++;
            }
            if (player1Counter == 3) {
                winner = V;
            }

            if (player2Counter == 3) {
                winner = V1;
            }
        }
    }
}

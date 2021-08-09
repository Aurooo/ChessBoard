using System;
using System.Collections.Generic;

namespace ChessBoard
{
    class Program
    {
        static Board myBoard = new Board(8);
        static void Main(string[] args)
        {
            
            Cell currentCell = SetCurrentCell();
            string piece = SetPiece();
            

            myBoard.MarkNextLegalMove(currentCell, piece);
            printBoard(myBoard);
        }

        private static void printBoard(Board myBoard)
        {
            Console.WriteLine("(r)+---+---+---+---+---+---+---+---+");
            for (int i = 0; i < myBoard.Size; i++)
            {
                Console.Write($"({i})");
                for (int j = 0; j < myBoard.Size; j++)
                {
                    Cell c = myBoard.Grid[i, j];
                    
                    if (c.CurrentlyOccupied == true)
                    {
                        Console.Write("| X ");
                    }
                    else if (c.LegalNextMove == true)
                    {
                        Console.Write("| + ");
                    }
                    else
                    {
                        Console.Write("|   ");
                    }
                }
                Console.Write("|\n");
                Console.WriteLine("   +---+---+---+---+---+---+---+---+");
            }
            Console.WriteLine("(c)+(0)+(1)+(2)+(3)+(4)+(5)+(6)+(7)");
            Console.WriteLine("==================");
        }
        private static Cell SetCurrentCell()
        {
            int row;
            int column;
            do
            {
                Console.WriteLine("Enter row number (0-7)");
            } while (!(int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < 7));

            do
            {
                Console.WriteLine("Enter column number (0-7)");
            } while (!(int.TryParse(Console.ReadLine(), out column) && column >= 0 && column < 7));

            myBoard.Grid[row, column].CurrentlyOccupied = true;

            return myBoard.Grid[row, column];
        }
        private static string SetPiece()
        {
            string piece;
            List<string> pieces = new List<string>() { "rook", "king", "queen", "bishop", "knight" };
            do
            {
                Console.WriteLine("Enter piece");
                piece = Console.ReadLine();
            } while (!pieces.Contains(piece));
            return piece;
        }
    }
}

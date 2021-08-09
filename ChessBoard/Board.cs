using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] Grid { get; set; }

        public Board (int s)
        {
            Size = s;

            Grid = new Cell[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Grid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMove(Cell current, string chessPiece)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Grid[i, j].LegalNextMove = false;
                    Grid[i, j].CurrentlyOccupied = false;
                }
            }

            switch (chessPiece.ToLower())
            {
                case "knight":
                    if (current.RowNumber + 2 < Size && current.ColumnNumber + 1 < Size)
                        Grid[current.RowNumber + 2, current.ColumnNumber + 1].LegalNextMove = true;
                    if (current.RowNumber + 2 < Size && current.ColumnNumber - 1 >= 0)
                        Grid[current.RowNumber + 2, current.ColumnNumber - 1].LegalNextMove = true;
                    if (current.RowNumber - 2 >= 0 && current.ColumnNumber + 1 < Size)
                        Grid[current.RowNumber - 2, current.ColumnNumber + 1].LegalNextMove = true;
                    if (current.RowNumber - 2 >= 0 && current.ColumnNumber - 1 >= 0)
                        Grid[current.RowNumber - 2, current.ColumnNumber - 1].LegalNextMove = true;
                    if (current.RowNumber + 1 < Size && current.ColumnNumber + 2 < Size)
                        Grid[current.RowNumber + 1, current.ColumnNumber + 2].LegalNextMove = true;
                    if (current.RowNumber + 1 < Size && current.ColumnNumber - 2 >= 0)
                        Grid[current.RowNumber + 1, current.ColumnNumber - 2].LegalNextMove = true;
                    if (current.RowNumber - 1 >= 0 && current.ColumnNumber + 2 < Size)
                        Grid[current.RowNumber - 1, current.ColumnNumber + 2].LegalNextMove = true;
                    if (current.RowNumber - 1 >= 0 && current.ColumnNumber - 2 >= 0)
                        Grid[current.RowNumber - 1, current.ColumnNumber - 2].LegalNextMove = true;
                    break;

                case "king":
                    if (current.ColumnNumber + 1 < Size)
                        Grid[current.RowNumber, current.ColumnNumber + 1].LegalNextMove = true;
                    if (current.ColumnNumber - 1 >= 0)
                        Grid[current.RowNumber, current.ColumnNumber - 1].LegalNextMove = true;
                    if (current.RowNumber + 1 < Size)
                        Grid[current.RowNumber + 1, current.ColumnNumber].LegalNextMove = true;
                    if (current.RowNumber + 1 < Size && current.ColumnNumber + 1 < Size)
                        Grid[current.RowNumber + 1, current.ColumnNumber + 1].LegalNextMove = true;
                    if (current.RowNumber + 1 < Size && current.ColumnNumber - 1 >= 0)
                        Grid[current.RowNumber + 1, current.ColumnNumber - 1].LegalNextMove = true;
                    if (current.RowNumber - 1 >= 0)
                        Grid[current.RowNumber - 1, current.ColumnNumber].LegalNextMove = true;
                    if (current.RowNumber - 1 >= 0 && current.ColumnNumber + 1 < Size)
                        Grid[current.RowNumber - 1, current.ColumnNumber + 1].LegalNextMove = true;
                    if (current.RowNumber - 1 >= 0 && current.ColumnNumber - 1 >= 0)
                    Grid[current.RowNumber - 1, current.ColumnNumber - 1].LegalNextMove = true;
                    break;

                case "rook":
                    for (int i = 0; i < Size; i++)
                        Grid[i, current.ColumnNumber].LegalNextMove = true;
                    for (int i = 0; i < Size; i++)
                        Grid[current.RowNumber, i].LegalNextMove = true;
                    break;

                case "bishop":
                    for (int i = current.RowNumber, j = current.ColumnNumber; i >= 0 && j >= 0; i--, j--)
                        Grid[i, j].LegalNextMove = true;
                    for (int i = current.RowNumber, j = current.ColumnNumber; i < Size && j < Size; i++, j++)
                        Grid[i, j].LegalNextMove = true;
                    for (int i = current.RowNumber, j = current.ColumnNumber; i >= 0 && j < Size; i--, j++)
                        Grid[i, j].LegalNextMove = true;
                    for (int i = current.RowNumber, j = current.ColumnNumber; i < Size && j >= 0; i++, j--)
                        Grid[i, j].LegalNextMove = true;
                    break;

                case "queen":
                    for (int i = 0; i < Size; i++)
                        Grid[i, current.ColumnNumber].LegalNextMove = true;
                    for (int i = 0; i < Size; i++)
                        Grid[current.RowNumber, i].LegalNextMove = true;
                    for (int i = current.RowNumber, j = current.ColumnNumber; i >= 0 && j >= 0; i--, j--)
                        Grid[i, j].LegalNextMove = true;
                    for (int i = current.RowNumber, j = current.ColumnNumber; i < Size && j < Size; i++, j++)
                        Grid[i, j].LegalNextMove = true;
                    for (int i = current.RowNumber, j = current.ColumnNumber; i >= 0 && j < Size; i--, j++)
                        Grid[i, j].LegalNextMove = true;
                    for (int i = current.RowNumber, j = current.ColumnNumber; i < Size && j >= 0; i++, j--)
                        Grid[i, j].LegalNextMove = true;
                    break;
                default:
                    break;
            }

            Grid[current.RowNumber, current.ColumnNumber].CurrentlyOccupied = true;
        }
    }
}

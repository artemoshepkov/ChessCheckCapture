using ChessPetroGM.Model.ChessPieces;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessPetroGM.Model
{
    public class Game
    {
        public ChessBoard Board { get; set; }

        public Game(ChessBoard board) 
        {
            Board = board;
        }

        public IEnumerable<string> GetPossibleCapturePieces()
        {
            foreach (var pieceMoving in Board.Piece)
            {
                foreach (var move in pieceMoving.GetPossibleMoves(Board.Size))
                {
                    foreach (var pieceCapturing in Board.Piece)
                    {
                        if (pieceMoving == pieceCapturing)
                            continue;

                        if (move.X == pieceCapturing.Position.X && move.Y == pieceCapturing.Position.Y)
                            yield return $"{pieceMoving.GetPeaceSymbol()} ({pieceMoving.Position.X}, {pieceMoving.Position.Y}) " +
                                $"capture " +
                                $"{pieceCapturing.GetPeaceSymbol()} ({pieceCapturing.Position.X}, {pieceCapturing.Position.Y})";
                    }
                }
            }
        }
    }
}

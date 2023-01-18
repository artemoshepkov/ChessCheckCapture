using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ChessPetroGM.Model.ChessPieces
{
    public class Bishop : Piece
    {
        public Bishop(Point position) : base(position) { }

        public override char GetPeaceSymbol() => 'B';

        public override IEnumerable<Point> GetPossibleMoves(int boardSize)
            => GetterPeacesMoves.GetPossibleBishopMoves(Position, boardSize);
    }
}

namespace ChessPetroGM.Model.ChessPieces
{
    public class Knight : Piece
    {
        public Knight(Point position) : base(position) { }

        public override char GetPeaceSymbol() => 'H';

        public override IEnumerable<Point> GetPossibleMoves(int boardSize)
            => GetterPeacesMoves.GetPossibleKnightMoves(Position, boardSize);
    }
}

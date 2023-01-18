namespace ChessPetroGM.Model.ChessPieces
{
    public class King : Piece
    {
        public King(Point position) : base(position) { }

        public override char GetPeaceSymbol() => 'K';

        public override IEnumerable<Point> GetPossibleMoves(int boardSize)
            => GetterPeacesMoves.GetPossibleKingMoves(Position, boardSize);
    }
}

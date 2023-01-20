namespace ChessPetroGM.Model.ChessPieces
{
    public class Rook : Piece
    {
        public Rook(Point position) : base(position) { }

        public override char GetPeaceSymbol() => 'R';

        public override IEnumerable<Point> GetPossibleMoves(int boardSize)
            => GetterPeacesMoves.GetPossibleRookMoves(Position, boardSize);
    }
}

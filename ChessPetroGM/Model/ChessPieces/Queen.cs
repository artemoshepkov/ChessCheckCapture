namespace ChessPetroGM.Model.ChessPieces
{
    public class Queen : Piece
    {
        public Queen(Point position) : base(position) { }

        public override char GetPeaceSymbol() => 'Q';

        public override IEnumerable<Point> GetPossibleMoves(int boardSize)
            => GetterPeacesMoves.GetPossibleQueenMoves(Position, boardSize);
    }
}

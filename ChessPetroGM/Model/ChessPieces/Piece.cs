using System.Linq;

namespace ChessPetroGM.Model.ChessPieces
{
    public abstract class Piece
    {
        public Point Position { get; protected set; }

        abstract public IEnumerable<Point> GetPossibleMoves(int boardSize);

        abstract public char GetPeaceSymbol();

        public Piece(Point position)
        {
            Position = position;
        }   
    }
}

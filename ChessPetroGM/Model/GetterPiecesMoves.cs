namespace ChessPetroGM.Model
{
    internal class GetterPeacesMoves
    {
        public static IEnumerable<Point> GetPossibleKingMoves(Point piecePosition, int boardSize)
            => CutOffWrongPoints(GetKingMoves(piecePosition), piecePosition, boardSize);

        public static IEnumerable<Point> GetKingMoves(Point piecePosition)
        {
            for (int y = -1; y <= 1; y++)
            {
                var tempY = piecePosition.Y + y;
                for (int x = -1; x <= 1; x++)
                {
                    var tempX = piecePosition.X + x;
                    yield return new Point(tempX, tempY);
                }
            }
        }

        public static IEnumerable<Point> GetPossibleBishopMoves(Point piecePosition, int boardSize)
            => CutOffWrongPoints(GetBishopMoves(piecePosition, boardSize), piecePosition, boardSize);

        public static IEnumerable<Point> GetBishopMoves(Point piecePosition, int boardSize)
        {
            for (int i = -boardSize + 1; i < boardSize; i++)
            {
                yield return new Point(piecePosition.X + i, piecePosition.Y + i);
            }

            for (int i = -boardSize + 1; i < boardSize; i++)
            {
                yield return new Point(piecePosition.X - i, piecePosition.Y + i);
            }
        }

        public static IEnumerable<Point> GetPossibleKnightMoves(Point piecePosition, int boardSize)
            => CutOffWrongPoints(GetKnightMoves(piecePosition), piecePosition, boardSize);

        public static IEnumerable<Point> GetKnightMoves(Point piecePosition)
        {
            var possibleMoves = new Point[]
                {
                    new Point(piecePosition.X - 2, piecePosition.Y - 1),
                    new Point(piecePosition.X - 1, piecePosition.Y - 2),
                    new Point(piecePosition.X + 1, piecePosition.Y - 2),
                    new Point(piecePosition.X + 2, piecePosition.Y - 1),
                    new Point(piecePosition.X - 2, piecePosition.Y + 1),
                    new Point(piecePosition.X - 1, piecePosition.Y + 2),
                    new Point(piecePosition.X + 1, piecePosition.Y + 2),
                    new Point(piecePosition.X + 2, piecePosition.Y + 1),
                };

            return possibleMoves;
        }

        public static IEnumerable<Point> GetPossibleRookMoves(Point piecePosition, int boardSize)
            => CutOffWrongPoints(GetRookMoves(piecePosition, boardSize), piecePosition, boardSize);

        public static IEnumerable<Point> GetRookMoves(Point piecePosition, int boardSize)
        {
            for (int y = -boardSize + 1; y < boardSize; y++)
            {
                yield return new Point(piecePosition.X, piecePosition.Y + y);
            }

            for (int x = -boardSize + 1; x < boardSize; x++)
            {
                yield return new Point(piecePosition.X + x, piecePosition.Y);
            }
        }

        public static IEnumerable<Point> GetPossibleQueenMoves(Point piecePosition, int boardSize)
            => CutOffWrongPoints(GetQueenMoves(piecePosition, boardSize), piecePosition, boardSize);

        public static IEnumerable<Point> GetQueenMoves(Point piecePosition, int boardSize)
        {
            var possibleQueenMoves = GetPossibleKingMoves(piecePosition, boardSize)
                .Concat(GetPossibleRookMoves(piecePosition, boardSize))
                .Concat(GetPossibleBishopMoves(piecePosition, boardSize));

            return possibleQueenMoves.Distinct();
        }

        private static IEnumerable<Point> CutOffWrongPoints(IEnumerable<Point> points, Point piecePosition, int boardSize)
        {
            return points.Where(p => p.X >= 0 && p.Y >= 0 && p.X < boardSize && p.Y < boardSize)
                .Where(p => p.X != piecePosition.X || p.Y != piecePosition.Y);
        }
    }
}

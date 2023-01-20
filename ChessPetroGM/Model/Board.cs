using ChessPetroGM.Model.ChessPieces;

namespace ChessPetroGM.Model
{
    public class ChessBoard
    {
        public readonly int Size;

        public char[,] Field { get; private set; }

        public Piece[] Piece { get; private set; }

        public ChessBoard(Piece[] piece, int size = 8)
        {
            if (size < 1)
                throw new ArgumentException("Board size must be greater than 0");

            if (piece.Length < 2 || piece.Length > 10) 
                throw new ArgumentException("Wrong amount of pieces. Must be > 1 and < 11.");

            Size = size;

            Piece = piece;

            InitializeBoard();

            SetPeacesToBoard();
        }

        private void InitializeBoard()
        {
            Field = new char[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i % 2 == j % 2)
                        Field[i, j] = '#';
                    else
                        Field[i, j] = 'O';
                }
            }
        }

        private void SetPeacesToBoard()
        {
            foreach (var piece in Piece)
            {
                if (piece.Position.Y >= Size || piece.Position.Y < 0 || piece.Position.X >= Size || piece.Position.X < 0)
                    throw new ArgumentException("Wrong coordinate for pieces.");

                if (Field[piece.Position.Y, piece.Position.X] != '#' && Field[piece.Position.Y, piece.Position.X] != 'O')
                    throw new ArgumentException("Wrong coordinate for pieces. Repeating positions for pieces.");

                Field[piece.Position.Y, piece.Position.X] = piece.GetPeaceSymbol();
            }
        }
    }
}

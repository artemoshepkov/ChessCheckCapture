using ChessPetroGM.Model;
using ChessPetroGM.Model.ChessPieces;

namespace ChessPetroGM.View
{
    public class GameView
    {
        private Game _game;

        public GameView(Game game)
        {
            _game = game;
        }

        public void ShowPiecesCapturing()
        {
            foreach (var move in _game.GetPossibleCapturePieces())
            {
                Console.WriteLine(move);
            }
        }

        public void ShowBoard()
        {
            Action printHorizontalEdgeBoard = () =>
            {
                for (int j = 0; j < _game.Board.Size * 2 + 2; j++)
                {
                    Console.Write('-');
                }
                Console.WriteLine();
            };

            printHorizontalEdgeBoard();

            for (int i = 0; i < _game.Board.Size; i++)
            {
                Console.Write('|');
                for (int j = 0; j < _game.Board.Size; j++)
                {
                    Console.Write(_game.Board.Field[i, j] + " ");
                }
                Console.WriteLine("|" + i);
            }

            printHorizontalEdgeBoard();

            for (int j = 0; j < _game.Board.Size; j++)
            {
                Console.Write(" " + j);
            }
            Console.WriteLine();
        }
    }
}

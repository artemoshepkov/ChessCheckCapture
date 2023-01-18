using ChessPetroGM.Model;
using ChessPetroGM.Model.ChessPieces;
using ChessPetroGM.View;

namespace TestChess
{
    public class Program
    {
        private static void Main()
        {
            try
            {
                var pieces = GameFileReader.GetPeacesFromFile(@"..\..\..\ChessPieces.txt").ToArray();

                ChessBoard board = new ChessBoard(pieces);
                Game game = new Game(board);
                GameView gameView = new GameView(game);

                gameView.ShowBoard();
                Console.WriteLine();
                gameView.ShowPiecesCapturing();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
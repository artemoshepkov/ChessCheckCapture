using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ChessPetroGM.Model.ChessPieces;

namespace ChessPetroGM.Model
{
    public static class GameFileReader
    {
        public static IEnumerable<Piece> GetPeacesFromFile(string pathToFile) // 
        {
            if (!File.Exists(pathToFile))
                throw new ArgumentException("File doesn`t exist");

            using (StreamReader file = new StreamReader(pathToFile))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    yield return StringArrayToPiece(Regex.Replace(line, @"\s+", " ").Split(' '));
                }

                file.Close();
            }
        }

        public static Piece StringArrayToPiece(string[] piece)
        {
            if (piece.Length != 3)
                throw new ArgumentException("Wrong file input. Must be 3 parameters.");

            if (int.TryParse(piece[1], out int X) && int.TryParse(piece[2], out int Y))
            {
                switch (piece[0])
                {
                    case "king":
                        return new King(new Point(X, Y));
                    case "queen":
                        return new Queen(new Point(X, Y));
                    case "rook":
                        return new Rook(new Point(X, Y));
                    case "bishop":
                        return new Bishop(new Point(X, Y));
                    case "knight":
                        return new Knight(new Point(X, Y));
                    default:
                        throw new ArgumentException($"Wrong file input. {piece[0]} is wrong name of piece.");
                    }
            }
            throw new ArgumentException("Wrong file input. Coordinate must be numbers.");
        }
    }
}

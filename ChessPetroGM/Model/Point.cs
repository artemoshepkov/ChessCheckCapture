using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ChessPetroGM.Model
{
    public class Point : IEquatable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x; 
            Y = y;
        }

        public bool Equals(Point? other)
        {
            if (Object.ReferenceEquals(other, null)) 
                return false;

            if (Object.ReferenceEquals(other, this))
                return true;

            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            return (X.GetHashCode() ^ Y.GetHashCode()) * 997;
        }
    }
}

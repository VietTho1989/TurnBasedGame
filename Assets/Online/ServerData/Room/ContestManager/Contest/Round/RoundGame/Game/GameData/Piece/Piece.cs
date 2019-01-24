using UnityEngine;
using System.Collections;

public class Piece : Data
{
	[System.Serializable]
	public struct Position
	{
		public int X;
		public int Y;

		public Position(Position otherPos){
			this.X = otherPos.X;
			this.Y = otherPos.Y;
		}

		public Position(int X, int Y){
			this.X = X;
			this.Y = Y;
		}

		public override string ToString ()
		{
			return "(" + X + ", " + Y + ")";
		}

		public static Position operator +(Position lhs, Position rhs)
		{
			/*Position position = new Position ();
			{
				position.X = lhs.X + rhs.X;
				position.Y = lhs.Y + rhs.Y;
			}
			return lhs;*/
			lhs.X += rhs.X;
			lhs.Y += rhs.Y;
			return lhs;
		}

		public static bool operator == (Piece.Position lhs, Piece.Position rhs)
		{
			return lhs.X == rhs.X && lhs.Y == rhs.Y;
		}

		public static bool operator !=(Piece.Position lhs, Piece.Position rhs)
		{
			return lhs.X != rhs.X || lhs.Y != rhs.Y;
		}

		public override bool Equals(object other)
		{
			if(!(other is Piece.Position))
			{
				return false;
			}
			Piece.Position point = (Piece.Position)other;
			return X == point.X && Y == point.Y;
		}

		public override int GetHashCode()
		{
			unchecked // Overflow is fine, just wrap
			{
				int hash = (int) 2166136261;
				hash = (hash * 16777619) ^ X;
				hash = (hash * 16777619) ^ Y;
				return hash;
			}
		}
	}

	public static Position UnknownPosition = new Position (int.MinValue, int.MinValue);
	public static Position EatenPosition = new Position (1506392418, 1506392418);

	#region Constructor

	public Piece () : base()
	{

	}

	#endregion

}


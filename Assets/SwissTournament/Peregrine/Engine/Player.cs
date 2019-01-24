using System;

namespace Peregrine.Engine
{
	public class Player
	{
		public readonly string Identifier;
		public readonly int? RoundDropped;

		public Player(string identifier, int? roundDropped)
		{
			if(String.IsNullOrEmpty(identifier))
				throw new ArgumentException("Player identifier must not be null or empty", "identifier");

			Identifier = identifier;
			RoundDropped = roundDropped;
		}

		public override bool Equals(object other)
		{
			if(Object.ReferenceEquals(other, null))
				return false;

			if(other is Player)
				return Equals((Player)other);

			return false;
		}

		public bool Equals(Player other)
		{
			if(Object.ReferenceEquals(other, null))
				return false;
			
			if(Object.ReferenceEquals(this, other))
				return true;

			return Identifier == other.Identifier;
		}

		public override int GetHashCode()
		{
			return Identifier.GetHashCode();
		}

		public static bool operator==(Player x, Player y)
		{
			if(Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
				return Object.ReferenceEquals(x, null) && Object.ReferenceEquals(y, null);

			return x.Equals(y);
		}

		public static bool operator !=(Player x, Player y)
		{
			return !(x == y);
		}

		public override string ToString()
		{
			return Identifier;
		}
	}
}
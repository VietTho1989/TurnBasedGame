using System;

namespace Janggi
{
	public class Global
	{
		
		public static Random Rand = new Random();

		public static int Next(int max)
		{
			lock (Rand) {
				return Rand.Next (max);
			}
		}

		public static double NextDouble()
		{
			lock (Rand) {
				return Rand.NextDouble ();
			}
		}

		public static float NextFloat(int max)
		{
			lock (Rand) {
				return (float)Rand.NextDouble () * max;
			}
		}

	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peregrine
{
	public static class Extensions
	{
		public static IEnumerable<T> Concat<T>(this IEnumerable<T> collection, params T[] values)
		{
			if(collection == null)
				return null;

			if(values == null)
				return collection;

			return collection.Concat(values.AsEnumerable());
		}

		public static IEnumerable<T> Except<T>(this IEnumerable<T> collection, params T[] values)
		{
			if(collection == null)
				return null;

			if(values == null)
				return collection;

			return collection.Except(values.AsEnumerable());
		}

		public static IEnumerable<T> Replace<T>(this IEnumerable<T> collection, Func<T, bool> predicate, Func<T, T> replacement)
		{
			if(predicate == null)
				throw new ArgumentNullException("predicate");

			if(replacement == null)
				throw new ArgumentNullException("replacement");

			if(collection == null)
				return null;

			return collection
				.Select(t => predicate(t) ? replacement(t) : t);
		}

		public static IEnumerable<T> Replace<T>(this IEnumerable<T> collection, T old, T @new, IEqualityComparer<T> equalityComparer = null)
		{
			return collection
				.Replace(
						t => (equalityComparer ?? EqualityComparer<T>.Default).Equals(t, old),
						t => @new
					);
		}
	}
}
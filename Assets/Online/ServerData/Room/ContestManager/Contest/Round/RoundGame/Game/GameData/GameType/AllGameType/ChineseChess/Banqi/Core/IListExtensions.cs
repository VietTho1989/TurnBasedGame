using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class IListExtensions {

	public static System.Random random = new System.Random ();

	public static int Next(int i, int count)
	{
		lock (random) {
			return random.Next (i, count);
		}
	}

	/// <summary>
	/// Shuffles the element order of the specified list.
	/// </summary>
	public static void Shuffle<T>(this IList<T> ts) {
		int count = ts.Count;
		int last = count - 1;
		for (var i = 0; i < last; ++i) {
			int r = Next (i, count);
			T tmp = ts [i];
			ts [i] = ts [r];
			ts [r] = tmp;
		}
	}

}
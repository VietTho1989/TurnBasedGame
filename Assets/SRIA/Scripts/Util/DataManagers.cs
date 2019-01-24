using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
using frame8.ScrollRectItemsAdapter.Util;

namespace frame8.ScrollRectItemsAdapter.Util
{
	/// <summary>
	/// <para>Utility interface to implement in order to access some default functionality for data manipulation, which is created in</para>
	/// <para><see cref="ISimpleDataManagerExtensions"/>. It calls <see cref="Refresh"/> each time something's modified.</para>
	/// </summary>
	/// <typeparam name="TItem"></typeparam>
	public interface ILazyListSimpleDataManager<TItem>
	{
		void Refresh();
		LazyList<TItem> Data { get; }
	}


	public static class ISimpleDataManagerExtensions
	{
		public static void LazyAddItems<TItem>(this ILazyListSimpleDataManager<TItem> manager, int count)
		{
			manager.Data.Add(count);
			manager.Refresh();
		}
		public static void LazyInsertItems<TItem>(this ILazyListSimpleDataManager<TItem> manager, int index, int count)
		{
			manager.Data.Insert(index, count);
			manager.Refresh();
		}
		public static void LazyRemoveItems<TItem>(this ILazyListSimpleDataManager<TItem> manager, params TItem[] toBeRemoved)
		{
			for (int i = 0; i < toBeRemoved.Length; ++i)
				manager.Data.Remove(toBeRemoved[i]);
			manager.Refresh();
		}
		public static void LazyRemoveItemAt<TItem>(this ILazyListSimpleDataManager<TItem> manager, int index)
		{
			manager.Data.RemoveAt(index);
			manager.Refresh();
		}
		public static void LazySetNewItems<TItem>(this ILazyListSimpleDataManager<TItem> manager, int count)
		{
			manager.Data.Clear();
			manager.LazyAddItems(count);
		}
		public static void LazyClearItems<TItem>(this ILazyListSimpleDataManager<TItem> manager)
		{
			manager.Data.Clear();
			manager.Refresh();
		}
		public static TItem LazyGetItem<TItem>(this ILazyListSimpleDataManager<TItem> manager, int index) { return manager.Data[index]; }
	}
}

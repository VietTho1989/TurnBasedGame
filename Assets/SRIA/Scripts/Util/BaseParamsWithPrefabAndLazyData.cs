using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace frame8.ScrollRectItemsAdapter.Util
{
	/// <summary><see cref="LazyList{T}"/></summary>
	/// <typeparam name="TData">The model type to be used</typeparam>
	public abstract class BaseParamsWithPrefabAndLazyData<TData> : BaseParamsWithPrefab
	{
		public LazyList<TData> Data { get; set; }
		public Func<int, TData> NewModelCreator { get; set; }


		/// <inheritdoc/>
		internal override void InitIfNeeded(ISRIA sria)
		{
			base.InitIfNeeded(sria);

			if (Data == null) // this will only be null at init. When scrollview's size changes, the data should remain the same
				Data = new LazyList<TData>(NewModelCreator, 0);
		}
	}
}

using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace frame8.ScrollRectItemsAdapter.Util
{
	/// <typeparam name="TData">The model type to be used</typeparam>
	public class BaseParamsWithPrefabAndData<TData> : BaseParamsWithPrefab
	{
		[NonSerialized]
		public List<TData> Data = new List<TData>();
	}
}

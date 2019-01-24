using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

using frame8.Logic.Misc.Other.Extensions;
using frame8.Logic.Misc.Visual.UI.MonoBehaviours;

namespace frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter
{
	public enum ItemCountChangeMode
	{
		/// <summary>
		/// The items count will be set to the specified count.
		/// The cached list of sizes will be cleared and all items will initially have the default size <see cref="BaseParams.DefaultItemSize"/>
		/// </summary>
		RESET,

		///// <summary>
		///// The count param will be ignored. This just recalculates positions and 
		///// </summary>
		//REFRESH,

		/// <summary>The items count will be increased by the specified count</summary>
		INSERT,

		/// <summary>The items count will be decreased by the specified count</summary>
		REMOVE,
	}
}

using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace frame8.ScrollRectItemsAdapter.Util
{
	/// <summary>
	/// Custom params containing a single prefab. <see cref="ItemPrefabSize"/> is calculated on first accessing and invalidated each time <see cref="InitIfNeeded(ISRIA)"/> is called.
	/// </summary>
	public class BaseParamsWithPrefab : BaseParams
	{
		public RectTransform itemPrefab;

		public float ItemPrefabSize
		{
			get
			{
				if (_PrefabSize == -1f)
					_PrefabSize = scrollRect.horizontal ? itemPrefab.rect.width : itemPrefab.rect.height;

				return _PrefabSize;
			}
		}

		float _PrefabSize = -1f;

		/// <inheritdoc/>
		internal override void InitIfNeeded(ISRIA sria)
		{
			base.InitIfNeeded(sria);

			_PrefabSize = -1f; // so the prefab's size will be recalculated

			_DefaultItemSize = ItemPrefabSize;
		}
	}
}

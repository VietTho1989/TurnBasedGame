using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
	public class BoardBackgroundUI : UIBehavior<BoardBackgroundUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{
			
			public VP<int> size;

			public VP<float> deltaX;

			public VP<float> deltaY;

			#region Constructor

			public enum Property
			{
				size,
				deltaX,
				deltaY
			}

			public UIData() : base()
			{
				this.size = new VP<int>(this, (byte)Property.size, 0);
				this.deltaX = new VP<float>(this, (byte)Property.deltaX, 0f);
				this.deltaY = new VP<float>(this, (byte)Property.deltaY, 0f);
			}

			#endregion
		}

		#endregion

		#region Refresh

		public RectTransform image;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// image
					{
						if (image != null) {
							if (this.data.size.v >= 1) {
								image.sizeDelta = new Vector2 (this.data.size.v - 1, this.data.size.v - 1);
							} else {
								Debug.LogError ("size < 0: " + this.data.size.v);
							}
						} else {
							Debug.LogError ("image null");
						}
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				// UIData uiData = data as UIData;
				// Child
				{

				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{

				}
				this.setDataNull (uiData);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.size:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
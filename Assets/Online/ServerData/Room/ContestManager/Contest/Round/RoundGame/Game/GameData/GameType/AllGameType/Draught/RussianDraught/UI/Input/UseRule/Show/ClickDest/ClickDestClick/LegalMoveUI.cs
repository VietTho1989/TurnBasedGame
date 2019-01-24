using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace RussianDraught.UseRule
{
	public class LegalMoveUI : UIBehavior<LegalMoveUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<int> square;

			#region Constructor

			public enum Property
			{
				square
			}

			public UIData() : base()
			{
				this.square = new VP<int>(this, (byte)Property.square, 0);
			}

			#endregion

		}

		#endregion

		#region Refresh

		public GameObject contentContainer;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Debug.LogError ("legalSquare: " + this.data.square.v);
					// contentContainer
					if (contentContainer != null) {
						if (this.data.square.v > 0) {
							contentContainer.SetActive (true);
						} else {
							contentContainer.SetActive (false);
						}
					} else {
						Debug.LogError ("contentContainer null: " + this);
					}
					// Update
					{
						// position
						this.transform.localPosition = Common.convertSquareToLocalPosition (this.data.square.v);
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
				case UIData.Property.square:
					{
						dirty = true;
					}
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
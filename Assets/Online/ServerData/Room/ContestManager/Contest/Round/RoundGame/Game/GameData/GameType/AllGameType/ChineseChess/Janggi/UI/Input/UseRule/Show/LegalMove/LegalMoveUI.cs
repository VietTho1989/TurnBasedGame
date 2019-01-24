using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Janggi.UseRule
{
	public class LegalMoveUI : UIBehavior<LegalMoveUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<JanggiMove>> janggiMove;

			#region Constructor

			public enum Property
			{
				janggiMove
			}

			public UIData() : base()
			{
				this.janggiMove = new VP<ReferenceData<JanggiMove>>(this, (byte)Property.janggiMove, new ReferenceData<JanggiMove>(null));
			}

			#endregion

		}

		#endregion

		#region Refresh

		public Image imgLegal;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					JanggiMove janggiMove = this.data.janggiMove.v.data;
					if (janggiMove != null) {
						// enable
						if (imgLegal != null) {
							imgLegal.gameObject.SetActive (true);
						} else {
							Debug.LogError ("imgLegal null");
						}
						// position
						this.transform.localPosition = Common.convertXYToLocalPosition (janggiMove.toX.v, janggiMove.toY.v);
					} else {
						// Debug.LogError ("janggiMove null");
						// enable
						if (imgLegal != null) {
							imgLegal.gameObject.SetActive (false);
						} else {
							Debug.LogError ("imgLegal null");
						}
					}
				} else {
					Debug.LogError ("data null");
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
				UIData uiData = data as UIData;
				// Child
				{
					uiData.janggiMove.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is JanggiMove) {
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
					uiData.janggiMove.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is JanggiMove) {
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
				case UIData.Property.janggiMove:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is JanggiMove) {
				switch ((JanggiMove.Property)wrapProperty.n) {
				case JanggiMove.Property.fromX:
					dirty = true;
					break;
				case JanggiMove.Property.fromY:
					dirty = true;
					break;
				case JanggiMove.Property.toX:
					dirty = true;
					break;
				case JanggiMove.Property.toY:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
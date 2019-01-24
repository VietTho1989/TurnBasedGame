using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class SolitaireMoveUI : UIBehavior<SolitaireMoveUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{

			public VP<ReferenceData<SolitaireMove>> solitaireMove;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				solitaireMove,
				isHint
			}

			public UIData() : base()
			{
				this.solitaireMove = new VP<ReferenceData<SolitaireMove>>(this, (byte)Property.solitaireMove, new ReferenceData<SolitaireMove>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.SolitaireMove;
			}

		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					SolitaireMove solitaireMove = this.data.solitaireMove.v.data;
					if (solitaireMove != null) {

					} else {
						Debug.LogError ("solitaireMove null: " + this);
					}
				} else {
					Debug.LogError ("data null: " + this);
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
					uiData.solitaireMove.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is SolitaireMove) {
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
					uiData.solitaireMove.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is SolitaireMove) {
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
				case UIData.Property.solitaireMove:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.isHint:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is SolitaireMove) {
				switch ((SolitaireMove.Property)wrapProperty.n) {
				case SolitaireMove.Property.From:
					dirty = true;
					break;
				case SolitaireMove.Property.To:
					dirty = true;
					break;
				case SolitaireMove.Property.Count:
					dirty = true;
					break;
				case SolitaireMove.Property.Extra:
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
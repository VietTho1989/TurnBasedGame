using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Shogi
{
	public class BtnChangeStyle : UIBehavior<BtnChangeStyle.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			#region Constructor

			public enum Property
			{

			}

			public UIData() : base()
			{

			}

			#endregion

		}

		#endregion

		#region Refresh

		public Text txtStyle;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// text
					{
						if (txtStyle != null) {
							ShogiGameDataUI.UIData shogiGameDataUIData = this.data.findDataInParent<ShogiGameDataUI.UIData> ();
							if (shogiGameDataUIData != null) {
								switch (shogiGameDataUIData.style.v) {
								case ShogiGameDataUI.UIData.Style.Normal:
									txtStyle.text = "Style Normal";
									break;
								case ShogiGameDataUI.UIData.Style.Western:
									txtStyle.text = "Style Western";
									break;
								default:
									Debug.LogError ("unknown style: " + shogiGameDataUIData.style.v + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("shogiGameDataUIData null: " + this);
							}
						} else {
							Debug.LogError ("txtStyle null: " + this);
						}
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

		private ShogiGameDataUI.UIData shogiGameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.shogiGameDataUIData);
				}
				dirty = true;
				return;
			}
			if (data is ShogiGameDataUI.UIData) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.shogiGameDataUIData);
				}
				this.setDataNull (uiData);
				return;
			}
			if (data is ShogiGameDataUI.UIData) {
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
				return;
			}
			if (wrapProperty.p is ShogiGameDataUI.UIData) {
				switch ((ShogiGameDataUI.UIData.Property)wrapProperty.n) {
				case ShogiGameDataUI.UIData.Property.gameData:
					break;
				case ShogiGameDataUI.UIData.Property.style:
					dirty = true;
					break;
				case ShogiGameDataUI.UIData.Property.btnChangeStyle:
					break;
				case ShogiGameDataUI.UIData.Property.isOnAnimation:
					break;
				case ShogiGameDataUI.UIData.Property.board:
					break;
				case ShogiGameDataUI.UIData.Property.lastMove:
					break;
				case ShogiGameDataUI.UIData.Property.showHint:
					break;
				case ShogiGameDataUI.UIData.Property.inputUI:
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

		public void onClickBtnChangeStyle()
		{
			if (this.data != null) {
				ShogiGameDataUI.UIData shogiGameDataUIData = this.data.findDataInParent<ShogiGameDataUI.UIData> ();
				if (shogiGameDataUIData != null) {
					switch (shogiGameDataUIData.style.v) {
					case ShogiGameDataUI.UIData.Style.Normal:
						shogiGameDataUIData.style.v = ShogiGameDataUI.UIData.Style.Western;
						break;
					case ShogiGameDataUI.UIData.Style.Western:
						shogiGameDataUIData.style.v = ShogiGameDataUI.UIData.Style.Normal;
						break;
					default:
						Debug.LogError ("unknown style: " + shogiGameDataUIData.style.v + "; " + this);
						break;
					}
				} else {
					Debug.LogError ("shogiGameDataUIData null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}
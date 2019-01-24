using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess.UseRule
{
	public class ClickDestClickMoveOrChooseUI : UIBehavior<ClickDestClickMoveOrChooseUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{
			
			public VP<int> destX;

			public VP<int> destY;

			#region Constructor

			public enum Property
			{
				destX,
				destY
			}

			public UIData() : base()
			{
				this.destX = new VP<int>(this, (byte)Property.destX, 0);
				this.destY = new VP<int>(this, (byte)Property.destY, 0);
			}

			#endregion

			public bool processEvent(Event e)
			{
				bool isProcess = false;
				{
					// back
					if (!isProcess) {
						if (InputEvent.isBackEvent (e)) {
							ClickDestClickMoveOrChooseUI moveOrChooseUI = this.findCallBack<ClickDestClickMoveOrChooseUI> ();
							if (moveOrChooseUI != null) {
								moveOrChooseUI.onClickBtnCancel ();
							} else {
								Debug.LogError ("moveOrChooseUI null: " + this);
							}
							isProcess = true;
						}
					}
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// TODO co le ko can
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
				case UIData.Property.destX:
					dirty = true;
					break;
				case UIData.Property.destY:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		#endregion

		private void resetMoveOrChoose()
		{
			if (this.data != null) {
				ClickDestClickUI.UIData clickDestClickUIData = this.data.findDataInParent<ClickDestClickUI.UIData> ();
				if (clickDestClickUIData != null) {
					if (clickDestClickUIData.moveOrChoose.v != null) {
						clickDestClickUIData.moveOrChoose.v = null;
					} else {
						Debug.LogError ("why already null: " + this);
					}
				} else {
					Debug.LogError ("clickDestClickUIData null: " + this);
				}
			} else {
				Debug.LogError ("data null");
			}
		}

		public void onClickBtnMove()
		{
			Debug.LogError ("onClickBtnMove: " + this);
			if (this.data != null) {
				ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData> ();
				if (clickDestUIData != null) {
					ClickDestChooseUI.UIData clickDestChooseUIData = new ClickDestChooseUI.UIData ();
					{
						clickDestChooseUIData.x.v = this.data.destX.v;
						clickDestChooseUIData.y.v = this.data.destY.v;
					}
					clickDestUIData.sub.v = clickDestChooseUIData;
				} else {
					Debug.LogError ("clickDestUIData null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
			resetMoveOrChoose ();
		}

		public void onClickBtnChoose()
		{
			Debug.LogError ("onClickBtnChoose: " + this);
			if (this.data != null) {
				// Check select same position
				bool isSelectSamePosition = false;
				{
					ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData> ();
					if (clickDestUIData != null) {
						if (clickDestUIData.x.v == this.data.destX.v && clickDestUIData.y.v == this.data.destY.v) {
							isSelectSamePosition = true;
						}
					} else {
						Debug.LogError ("clickDestUIData null: " + this);
					}
				}
				// process
				if (isSelectSamePosition) {
					// Chuyen ve ClickPieceUI
					ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData>();
					if (show != null) {
						ClickPieceUI.UIData clickPieceUIData = new ClickPieceUI.UIData ();
						{
							clickPieceUIData.uid = show.sub.makeId ();
						}
						show.sub.v = clickPieceUIData;
					} else {
						Debug.LogError ("show null: " + this);
					}
				} else {
					ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData> ();
					if (clickDestUIData != null) {
						clickDestUIData.x.v = this.data.destX.v;
						clickDestUIData.y.v = this.data.destY.v;
					} else {
						Debug.LogError ("clickDestUIData null: " + this);
					}
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
			resetMoveOrChoose ();
		}

		public void onClickBtnCancel()
		{
			Debug.LogError ("onClickBtnCancel: " + this);
			resetMoveOrChoose ();
		}
	}
}
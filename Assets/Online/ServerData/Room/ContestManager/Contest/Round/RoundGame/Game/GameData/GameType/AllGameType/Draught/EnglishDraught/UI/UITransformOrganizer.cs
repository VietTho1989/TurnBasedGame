using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace EnglishDraught
{
	public class UITransformOrganizer : UpdateBehavior<UITransformOrganizer.UpdateData>
	{

		#region UpdateData

		public class UpdateData : Data
		{

			#region Constructor

			public enum Property
			{

			}

			public UpdateData() : base()
			{

			}

			#endregion

		}

		#endregion

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EnglishDraughtGameDataUI.UIData englishDraughtGameDataUIData = this.data.findDataInParent<EnglishDraughtGameDataUI.UIData> ();
					GameDataBoardUI.UIData gameDataBoardUIData = this.data.findDataInParent<GameDataBoardUI.UIData> ();
					if (englishDraughtGameDataUIData != null && gameDataBoardUIData != null) {
						UpdateTransform.UpdateData englishDraughtTransform = englishDraughtGameDataUIData.updateTransform.v;
						UpdateTransform.UpdateData boardTransform = gameDataBoardUIData.updateTransform.v;
						if (englishDraughtTransform.size.v != Vector2.zero && boardTransform.size.v != Vector2.zero) {
							float boardSizeX = 8f;
							float boardSizeY = 8f;
							float scale = Mathf.Min (Mathf.Abs (boardTransform.size.v.x / boardSizeX), Mathf.Abs (boardTransform.size.v.y / boardSizeY));
							// new scale
							Vector3 newLocalScale = new Vector3 ();
							{
								Vector3 currentLocalScale = this.transform.localScale;
								// x
								newLocalScale.x = scale;
								// y
								newLocalScale.y = (gameDataBoardUIData.perspective.v.playerView.v == 0 ? 1 : -1) * scale;
								// z
								newLocalScale.z = 1;
							}
							this.transform.localScale = newLocalScale;
						} else {
							Debug.LogError ("why transform zero");
						}
					} else {
						Debug.LogError ("englishDraughtGameDataUIData or gameDataBoardUIData null: " + this);
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

		private EnglishDraughtGameDataUI.UIData englishDraughtGameDataUIData = null;
		private GameDataBoardCheckTransformChange<UpdateData> gameDataBoardCheckTransformChange = new GameDataBoardCheckTransformChange<UpdateData>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UpdateData) {
				UpdateData updateData = data as UpdateData;
				// CheckChange
				{
					gameDataBoardCheckTransformChange.addCallBack (this);
					gameDataBoardCheckTransformChange.setData (updateData);
				}
				// Parent
				{
					DataUtils.addParentCallBack (updateData, this, ref this.englishDraughtGameDataUIData);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckTransformChange<UpdateData>) {
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is EnglishDraughtGameDataUI.UIData) {
					EnglishDraughtGameDataUI.UIData englishDraughtGameDataUIData = data as EnglishDraughtGameDataUI.UIData;
					{
						englishDraughtGameDataUIData.updateTransform.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				if (data is UpdateTransform.UpdateData) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UpdateData) {
				UpdateData updateData = data as UpdateData;
				// CheckChange
				{
					gameDataBoardCheckTransformChange.removeCallBack (this);
					gameDataBoardCheckTransformChange.setData (null);
				}
				// Parent
				{
					DataUtils.removeParentCallBack (updateData, this, ref this.englishDraughtGameDataUIData);
				}
				this.setDataNull (updateData);
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckTransformChange<UpdateData>) {
				return;
			}
			// Parent
			{
				if (data is EnglishDraughtGameDataUI.UIData) {
					EnglishDraughtGameDataUI.UIData englishDraughtGameDataUIData = data as EnglishDraughtGameDataUI.UIData;
					{
						englishDraughtGameDataUIData.updateTransform.allRemoveCallBack (this);
					}
					return;
				}
				if (data is UpdateTransform.UpdateData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is UpdateData) {
				switch ((UpdateData.Property)wrapProperty.n) {
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if (wrapProperty.p is GameDataBoardCheckTransformChange<UpdateData>) {
                dirty = true;
                return;
			}
			// Parent
			{
				if (wrapProperty.p is EnglishDraughtGameDataUI.UIData) {
					switch ((EnglishDraughtGameDataUI.UIData.Property)wrapProperty.n) {
					case EnglishDraughtGameDataUI.UIData.Property.gameData:
						break;
					case EnglishDraughtGameDataUI.UIData.Property.updateTransform:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
							dirty = true;
						}
						break;
					case EnglishDraughtGameDataUI.UIData.Property.transformOrganizer:
						break;
					case EnglishDraughtGameDataUI.UIData.Property.isOnAnimation:
						break;
					case EnglishDraughtGameDataUI.UIData.Property.board:
						break;
					case EnglishDraughtGameDataUI.UIData.Property.lastMove:
						break;
					case EnglishDraughtGameDataUI.UIData.Property.showHint:
						break;
					case EnglishDraughtGameDataUI.UIData.Property.inputUI:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is UpdateTransform.UpdateData) {
					switch ((UpdateTransform.UpdateData.Property)wrapProperty.n) {
					case UpdateTransform.UpdateData.Property.position:
						dirty = true;
						break;
					case UpdateTransform.UpdateData.Property.rotation:
						dirty = true;
						break;
					case UpdateTransform.UpdateData.Property.scale:
						dirty = true;
						break;
					case UpdateTransform.UpdateData.Property.size:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this + "; " + syncs);
						break;
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
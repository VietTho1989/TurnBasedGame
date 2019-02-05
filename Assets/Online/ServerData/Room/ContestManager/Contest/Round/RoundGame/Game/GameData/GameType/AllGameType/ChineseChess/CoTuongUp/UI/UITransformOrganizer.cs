using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace CoTuongUp
{
	/**
	 * TODO Sau nay can phai xu ly miniGameDataUIData
	 * */
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
                    CoTuongUpGameDataUI coTuongUpGameDataUI = null;
                    {
                        CoTuongUpGameDataUI.UIData coTuongUpGameDataUIData = this.data.findDataInParent<CoTuongUpGameDataUI.UIData>();
                        if (coTuongUpGameDataUIData != null)
                        {
                            coTuongUpGameDataUI = coTuongUpGameDataUIData.findCallBack<CoTuongUpGameDataUI>();
                        }
                        else
                        {
                            Debug.LogError("coTuongUpGameDataUIData null");
                        }
                    }
                    GameDataBoardUI gameDataBoardUI = null;
					GameDataBoardUI.UIData gameDataBoardUIData = this.data.findDataInParent<GameDataBoardUI.UIData> ();
                    {
                        if (gameDataBoardUIData != null)
                        {
                            gameDataBoardUI = gameDataBoardUIData.findCallBack<GameDataBoardUI>();
                        }
                        else
                        {
                            Debug.LogError("gameDataBoardUIData null");
                        }
                    }
                    if (coTuongUpGameDataUI != null && gameDataBoardUI != null) {
						TransformData chessTransform = coTuongUpGameDataUI.transformData;
						TransformData boardTransform = gameDataBoardUI.transformData;
						if (chessTransform.size.v != Vector2.zero && boardTransform.size.v != Vector2.zero) {
							float scale = Mathf.Min (Mathf.Abs (boardTransform.size.v.x / 9f), Mathf.Abs (boardTransform.size.v.y / 10f));
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
						Debug.LogError ("coTuongUpGameDataUI or gameDataBoardUI null: " + this);
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

		private CoTuongUpGameDataUI.UIData coTuongUpGameDataUIData = null;
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
					DataUtils.addParentCallBack (updateData, this, ref this.coTuongUpGameDataUIData);
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
				if (data is CoTuongUpGameDataUI.UIData) {
					CoTuongUpGameDataUI.UIData coTuongUpGameDataUIData = data as CoTuongUpGameDataUI.UIData;
					// Child
                    {
                        CoTuongUpGameDataUI coTuongUpGameDataUI = coTuongUpGameDataUIData.findCallBack<CoTuongUpGameDataUI>();
                        if (coTuongUpGameDataUI != null)
                        {
                            coTuongUpGameDataUI.transformData.addCallBack(this);
                        }
                        else
                        {
                            Debug.LogError("coTuongUpGameDataUI null");
                        }
					}
					dirty = true;
					return;
				}
                // Child
				if (data is TransformData) {
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
					DataUtils.removeParentCallBack (updateData, this, ref this.coTuongUpGameDataUIData);
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
				if (data is CoTuongUpGameDataUI.UIData) {
					CoTuongUpGameDataUI.UIData coTuongUpGameDataUIData = data as CoTuongUpGameDataUI.UIData;
					// Child
                    {
                        CoTuongUpGameDataUI coTuongUpGameDataUI = coTuongUpGameDataUIData.findCallBack<CoTuongUpGameDataUI>();
                        if (coTuongUpGameDataUI != null)
                        {
                            coTuongUpGameDataUI.transformData.removeCallBack(this);
                        }
                        else
                        {
                            Debug.LogError("coTuongUpGameDataUI null");
                        }
                    }
					return;
				}
                // Child
				if (data is TransformData) {
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
				if (wrapProperty.p is CoTuongUpGameDataUI.UIData) {
					return;
				}
				if (wrapProperty.p is TransformData) {
					switch ((TransformData.Property)wrapProperty.n) {
					case TransformData.Property.position:
						dirty = true;
						break;
					case TransformData.Property.rotation:
						dirty = true;
						break;
					case TransformData.Property.scale:
						dirty = true;
						break;
					case TransformData.Property.size:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
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
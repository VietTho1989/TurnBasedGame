using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Xiangqi
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
                    XiangqiGameDataUI xiangqiGameDataUI = null;
                    {
                        XiangqiGameDataUI.UIData xiangqiGameDataUIData = this.data.findDataInParent<XiangqiGameDataUI.UIData>();
                        if (xiangqiGameDataUIData != null)
                        {
                            xiangqiGameDataUI = xiangqiGameDataUIData.findCallBack<XiangqiGameDataUI>();
                        }
                        else
                        {
                            Debug.LogError("xiangqiGameDataUIData null");
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
                    if (xiangqiGameDataUI != null && gameDataBoardUI != null) {
						TransformData reversiTransform = xiangqiGameDataUI.transformData;
						TransformData boardTransform = gameDataBoardUI.transformData;
						if (reversiTransform.size.v != Vector2.zero && boardTransform.size.v != Vector2.zero) {
							float boardSizeX = 9f;
							float boardSizeY = 10f;
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
						Debug.LogError ("xiangqiGameDataUI or gameDataBoardUI null: " + this);
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

		private XiangqiGameDataUI.UIData xiangqiGameDataUIData = null;
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
					DataUtils.addParentCallBack (updateData, this, ref this.xiangqiGameDataUIData);
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
				if (data is XiangqiGameDataUI.UIData) {
					XiangqiGameDataUI.UIData xiangqiGameDataUIData = data as XiangqiGameDataUI.UIData;
					// Child
					{
                        XiangqiGameDataUI xiangqiGameDataUI = xiangqiGameDataUIData.findCallBack<XiangqiGameDataUI>();
                        if (xiangqiGameDataUI != null)
                        {
                            xiangqiGameDataUI.transformData.addCallBack(this);
                        }
                        else
                        {
                            Debug.LogError("xiangqiGameDataUI null");
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
					DataUtils.removeParentCallBack (updateData, this, ref this.xiangqiGameDataUIData);
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
				if (data is XiangqiGameDataUI.UIData) {
					XiangqiGameDataUI.UIData xiangqiGameDataUIData = data as XiangqiGameDataUI.UIData;
					// Child
					{
                        XiangqiGameDataUI xiangqiGameDataUI = xiangqiGameDataUIData.findCallBack<XiangqiGameDataUI>();
                        if (xiangqiGameDataUI != null)
                        {
                            xiangqiGameDataUI.transformData.removeCallBack(this);
                        }
                        else
                        {
                            Debug.LogError("xiangqiGameDataUI null");
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
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
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
				if (wrapProperty.p is XiangqiGameDataUI.UIData) {
					return;
				}
                // Child
				if (wrapProperty.p is TransformData) {
                    dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
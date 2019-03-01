using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace NineMenMorris
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
                    NineMenMorrisGameDataUI nineMenMorrisGameDataUI = null;
                    {
                        NineMenMorrisGameDataUI.UIData nineMenMorrisGameDataUIData = this.data.findDataInParent<NineMenMorrisGameDataUI.UIData>();
                        if (nineMenMorrisGameDataUIData != null)
                        {
                            nineMenMorrisGameDataUI = nineMenMorrisGameDataUIData.findCallBack<NineMenMorrisGameDataUI>();
                        }
                        else
                        {
                            Debug.LogError("nineMenMorrisGameDataUIData null");
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
                    if (nineMenMorrisGameDataUI != null && gameDataBoardUI != null) {
						TransformData nineMenMorrisTransform = nineMenMorrisGameDataUI.transformData;
						TransformData boardTransform = gameDataBoardUI.transformData;
						if (nineMenMorrisTransform.size.v != Vector2.zero && boardTransform.size.v != Vector2.zero) {
							float scale = Mathf.Min (Mathf.Abs (boardTransform.size.v.x / 7f), Mathf.Abs (boardTransform.size.v.y / 7f));
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
						Debug.LogError ("nineMenMorrisGameDataUI or gameDataBoardUI null: " + this);
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

		private NineMenMorrisGameDataUI.UIData nineMenMorrisGameDataUIData = null;
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
					DataUtils.addParentCallBack (updateData, this, ref this.nineMenMorrisGameDataUIData);
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
				if (data is NineMenMorrisGameDataUI.UIData) {
					NineMenMorrisGameDataUI.UIData nineMenMorrisGameDataUIData = data as NineMenMorrisGameDataUI.UIData;
					// Child
					{
                        NineMenMorrisGameDataUI nineMenMorrisGameDataUI = nineMenMorrisGameDataUIData.findCallBack<NineMenMorrisGameDataUI>();
                        if (nineMenMorrisGameDataUI != null)
                        {
                            nineMenMorrisGameDataUI.transformData.addCallBack(this);
                        }
                        else
                        {
                            Debug.LogError("nineMenMorrisGameDataUI null");
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
					DataUtils.removeParentCallBack (updateData, this, ref this.nineMenMorrisGameDataUIData);
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
				if (data is NineMenMorrisGameDataUI.UIData) {
					NineMenMorrisGameDataUI.UIData nineMenMorrisGameDataUIData = data as NineMenMorrisGameDataUI.UIData;
					// Child
					{
                        NineMenMorrisGameDataUI nineMenMorrisGameDataUI = nineMenMorrisGameDataUIData.findCallBack<NineMenMorrisGameDataUI>();
                        if (nineMenMorrisGameDataUI != null)
                        {
                            nineMenMorrisGameDataUI.transformData.removeCallBack(this);
                        }
                        else
                        {
                            Debug.LogError("nineMenMorrisGameDataUI null");
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
				if (wrapProperty.p is NineMenMorrisGameDataUI.UIData) {
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
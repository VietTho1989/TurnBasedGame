using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Shatranj
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
                    ShatranjGameDataUI shatranjGameDataUI = null;
                    {
                        ShatranjGameDataUI.UIData shatranjGameDataUIData = this.data.findDataInParent<ShatranjGameDataUI.UIData>();
                        if (shatranjGameDataUIData != null)
                        {
                            shatranjGameDataUI = shatranjGameDataUIData.findCallBack<ShatranjGameDataUI>();
                        }
                        else
                        {
                            Debug.LogError("shatranjGameDataUIData null");
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
                    if (shatranjGameDataUI != null && gameDataBoardUI != null) {
						TransformData shatranjTransform = shatranjGameDataUI.transformData;
						TransformData boardTransform = gameDataBoardUI.transformData;
						if (shatranjTransform.size.v != Vector2.zero && boardTransform.size.v != Vector2.zero) {
							float scale = Mathf.Min (Mathf.Abs (boardTransform.size.v.x / 8f), Mathf.Abs (boardTransform.size.v.y / 8f));
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
						Debug.LogError ("shatranjGameDataUI or gameDataBoardUI null: " + this);
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

		private ShatranjGameDataUI.UIData shatranjGameDataUIData = null;
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
					DataUtils.addParentCallBack (updateData, this, ref this.shatranjGameDataUIData);
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
				if (data is ShatranjGameDataUI.UIData) {
					ShatranjGameDataUI.UIData shatranjGameDataUIData = data as ShatranjGameDataUI.UIData;
                    // Child
                    {
                        ShatranjGameDataUI shatranjGameDataUI = shatranjGameDataUIData.findCallBack<ShatranjGameDataUI>();
                        if (shatranjGameDataUI != null)
                        {
                            shatranjGameDataUI.transformData.addCallBack(this);
                        }
                        else
                        {
                            Debug.LogError("shatranjGameDataUI null");
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
					DataUtils.removeParentCallBack (updateData, this, ref this.shatranjGameDataUIData);
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
				if (data is ShatranjGameDataUI.UIData) {
					ShatranjGameDataUI.UIData shatranjGameDataUIData = data as ShatranjGameDataUI.UIData;
					// Child
                    {
                        ShatranjGameDataUI shatranjGameDataUI = shatranjGameDataUIData.findCallBack<ShatranjGameDataUI>();
                        if (shatranjGameDataUI != null)
                        {
                            shatranjGameDataUI.transformData.removeCallBack(this);
                        }
                        else
                        {
                            Debug.LogError("shatranjGameDataUI null");
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
				if (wrapProperty.p is ShatranjGameDataUI.UIData) {
					return;
				}
                // Child
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
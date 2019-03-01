using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace HEX
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
                    HexGameDataUI hexGameDataUI = null;
                    {
                        HexGameDataUI.UIData hexGameDataUIData = this.data.findDataInParent<HexGameDataUI.UIData>();
                        if (hexGameDataUIData != null)
                        {
                            hexGameDataUI = hexGameDataUIData.findCallBack<HexGameDataUI>();
                        }
                        else
                        {
                            Debug.LogError("hexGameDataUIData null");
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
                    if (hexGameDataUI != null && gameDataBoardUI != null) {
						TransformData hexTransform = hexGameDataUI.transformData;
						TransformData boardTransform = gameDataBoardUI.transformData;
						if (hexTransform.size.v != Vector2.zero && boardTransform.size.v != Vector2.zero) {
							float boardSizeX = 11f;
							float boardSizeY = 11f;
							{
								BoardUI.UIData boardUIData = hexGameDataUIData.board.v;
								if (boardUIData != null) {
									System.UInt16 boardSize = (System.UInt16)Mathf.Clamp ((int)boardUIData.boardSize.v, (int)Hex.MIN_BOARD_SIZE, (int)Hex.MAX_BOARD_SIZE);
									boardSizeX = boardSize;
									boardSizeY = boardSize;
								} else {
									Debug.LogError ("boardUIData null");
								}
							}
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
						Debug.LogError ("hexGameDataUI or gameDataBoardUI null: " + this);
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

		private HexGameDataUI.UIData hexGameDataUIData = null;
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
					DataUtils.addParentCallBack (updateData, this, ref this.hexGameDataUIData);
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
				if (data is HexGameDataUI.UIData) {
					HexGameDataUI.UIData hexGameDataUIData = data as HexGameDataUI.UIData;
					// Child
					{
                        // transformData
                        {
                            HexGameDataUI hexGameDataUI = hexGameDataUIData.findCallBack<HexGameDataUI>();
                            if (hexGameDataUI != null)
                            {
                                hexGameDataUI.transformData.addCallBack(this);
                            }
                            else
                            {
                                Debug.LogError("hexGameDataUI null");
                            }
                        }
						hexGameDataUIData.board.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is TransformData) {
						dirty = true;
						return;
					}
					if (data is BoardUI.UIData) {
						dirty = true;
						return;
					}
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
					DataUtils.removeParentCallBack (updateData, this, ref this.hexGameDataUIData);
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
				if (data is HexGameDataUI.UIData) {
					HexGameDataUI.UIData hexGameDataUIData = data as HexGameDataUI.UIData;
					// Child
					{
                        // transformData
                        {
                            HexGameDataUI hexGameDataUI = hexGameDataUIData.findCallBack<HexGameDataUI>();
                            if (hexGameDataUI != null)
                            {
                                hexGameDataUI.transformData.removeCallBack(this);
                            }
                            else
                            {
                                Debug.LogError("hexGameDataUI null");
                            }
                        }
                        hexGameDataUIData.board.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is TransformData) {
						return;
					}
					if (data is BoardUI.UIData) {
						return;
					}
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
				if (wrapProperty.p is HexGameDataUI.UIData) {
					switch ((HexGameDataUI.UIData.Property)wrapProperty.n) {
					case HexGameDataUI.UIData.Property.gameData:
						break;
					case HexGameDataUI.UIData.Property.transformOrganizer:
						break;
					case HexGameDataUI.UIData.Property.isOnAnimation:
						break;
					case HexGameDataUI.UIData.Property.board:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case HexGameDataUI.UIData.Property.lastMove:
						break;
					case HexGameDataUI.UIData.Property.showHint:
						break;
					case HexGameDataUI.UIData.Property.inputUI:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				{
					if (wrapProperty.p is TransformData) {
                        dirty = true;
						return;
					}
					if (wrapProperty.p is BoardUI.UIData) {
						switch ((BoardUI.UIData.Property)wrapProperty.n) {
						case BoardUI.UIData.Property.hex:
							break;
						case BoardUI.UIData.Property.boardSize:
							dirty = true;
							break;
						case BoardUI.UIData.Property.pieces:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Gomoku
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
					GomokuGameDataUI.UIData gomokuGameDataUIData = this.data.findDataInParent<GomokuGameDataUI.UIData> ();
					GameDataBoardUI.UIData gameDataBoardUIData = this.data.findDataInParent<GameDataBoardUI.UIData> ();
					if (gomokuGameDataUIData != null && gameDataBoardUIData != null) {
						UpdateTransform.UpdateData gomokuTransform = gomokuGameDataUIData.updateTransform.v;
						UpdateTransform.UpdateData boardTransform = gameDataBoardUIData.updateTransform.v;
						if (gomokuTransform.size.v != Vector2.zero && boardTransform.size.v != Vector2.zero) {
							float boardSizeX = 19f;
							float boardSizeY = 19f;
							{
								// Find gomoku
								/*Gomoku gomoku = null;
								{
									GameData gameData = gomokuGameDataUIData.gameData.v.data;
									if (gameData != null) {
										if (gameData.gameType.v != null && gameData.gameType.v is Gomoku) {
											gomoku = gameData.gameType.v as Gomoku;
										}
									} else {
										Debug.LogError ("gameData null: " + this);
									}
								}
								// Process
								if (gomoku != null) {
									boardSizeX = Mathf.Clamp (gomoku.boardSize.v, Gomoku.MinBoardSize, Gomoku.MaxBoardSize);
									boardSizeY = gomoku.boardSize.v;
								} else {
									Debug.LogError ("gomoku null: " + this);
								}*/
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
						Debug.LogError ("gomokuGameDataUIData or gameDataBoardUIData null: " + this);
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

		private GomokuGameDataUI.UIData gomokuGameDataUIData = null;
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
					DataUtils.addParentCallBack (updateData, this, ref this.gomokuGameDataUIData);
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
				if (data is GomokuGameDataUI.UIData) {
					GomokuGameDataUI.UIData gomokuGameDataUIData = data as GomokuGameDataUI.UIData;
					// Child
					{
						gomokuGameDataUIData.updateTransform.allAddCallBack (this);
						gomokuGameDataUIData.gameData.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				if (data is UpdateTransform.UpdateData) {
					dirty = true;
					return;
				}
				// GameData
				{
					if (data is GameData) {
						GameData gameData = data as GameData;
						{
							gameData.gameType.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					if (data is GameType) {
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
					DataUtils.removeParentCallBack (updateData, this, ref this.gomokuGameDataUIData);
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
				if (data is GomokuGameDataUI.UIData) {
					GomokuGameDataUI.UIData gomokuGameDataUIData = data as GomokuGameDataUI.UIData;
					// Child
					{
						gomokuGameDataUIData.updateTransform.allRemoveCallBack (this);
						gomokuGameDataUIData.gameData.allRemoveCallBack (this);
					}
					return;
				}
				if (data is UpdateTransform.UpdateData) {
					return;
				}
				// GameData
				{
					if (data is GameData) {
						GameData gameData = data as GameData;
						{
							gameData.gameType.allRemoveCallBack (this);
						}
						return;
					}
					if (data is GameType) {
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
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if (wrapProperty.p is GameDataBoardCheckTransformChange<UpdateData>) {
				switch ((GameDataBoardCheckTransformChange<UpdateData>.Property)wrapProperty.n) {
				case GameDataBoardCheckTransformChange<UpdateData>.Property.change:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			{
				if (wrapProperty.p is GomokuGameDataUI.UIData) {
					switch ((GomokuGameDataUI.UIData.Property)wrapProperty.n) {
					case GomokuGameDataUI.UIData.Property.gameData:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case GomokuGameDataUI.UIData.Property.updateTransform:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
							dirty = true;
						}
						break;
					case GomokuGameDataUI.UIData.Property.transformOrganizer:
						break;
					case GomokuGameDataUI.UIData.Property.isOnAnimation:
						break;
					case GomokuGameDataUI.UIData.Property.board:
						break;
					case GomokuGameDataUI.UIData.Property.lastMove:
						break;
					case GomokuGameDataUI.UIData.Property.showHint:
						break;
					case GomokuGameDataUI.UIData.Property.inputUI:
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
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
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// GameData
				{
					if (wrapProperty.p is GameData) {
						switch ((GameData.Property)wrapProperty.n) {
						case GameData.Property.gameType:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case GameData.Property.useRule:
							break;
						case GameData.Property.turn:
							break;
						case GameData.Property.timeControl:
							break;
						case GameData.Property.lastMove:
							break;
						case GameData.Property.state:
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					if (wrapProperty.p is GameType) {
						if (wrapProperty.p is Gomoku) {
							switch ((Gomoku.Property)wrapProperty.n) {
							case Gomoku.Property.boardSize:
								dirty = true;
								break;
							case Gomoku.Property.gs:
								break;
							case Gomoku.Property.player:
								break;
							case Gomoku.Property.winningPlayer:
								break;
							case Gomoku.Property.lastMove:
								break;
							case Gomoku.Property.winSize:
								break;
							case Gomoku.Property.winCoord:
								break;
							default:
								Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
								break;
							}
							return;
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
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hint;
using MineSweeper.NoneRule;

namespace MineSweeper
{
	public class ShowHintUI : UIBehavior<ShowHintUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{
			public VP<LastMoveSub> sub;

			#region Constructor

			public enum Property
			{
				sub
			}

			public UIData() : base()
			{
				this.sub = new VP<LastMoveSub>(this, (byte)Property.sub, null);
			}

			#endregion
		}

		#endregion

		#region Refresh

		private int lastMove = -1;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					bool canShowHint = false;
					{
						MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = this.data.findDataInParent<MineSweeperGameDataUI.UIData> ();
						if (mineSweeperGameDataUIData != null) {
							if (!mineSweeperGameDataUIData.isOnAnimation.v) {
								canShowHint = true;
							}
						} else {
							Debug.LogError ("mineSweeperGameDataUIData null: " + this);
						}
					}
					if (canShowHint) {
						// Find HintMove
						GameMove hintMove = null;
						{
							GameDataUI.UIData gameDataUIData = this.data.findDataInParent<GameDataUI.UIData> ();
							if (gameDataUIData != null) {
								HintUI.UIData hintUIData = gameDataUIData.hintUI.v;
								if (hintUIData != null) {
									if (hintUIData.state.v != null && hintUIData.state.v is ShowUI.UIData) {
										ShowUI.UIData showUIData = hintUIData.state.v as ShowUI.UIData;
										hintMove = showUIData.hintMove.v;
									}
								} else {
									Debug.LogError ("hintUIData null: " + this);
								}
							} else {
								Debug.LogError ("gameDataUIData null: " + this);
							}
						}
						if (hintMove != null) {
							switch (hintMove.getType ()) {
							case GameMove.Type.MineSweeperMove:
								{
									MineSweeperMove mineSweeperMove = hintMove as MineSweeperMove;
									// change view
									{
										if (mineSweeperMove.move.v >= 0) {
											if (lastMove != mineSweeperMove.move.v) {
												lastMove = mineSweeperMove.move.v;
												// Find boardUIData
												BoardUI.UIData boardUIData = null;
												{
													MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = this.data.findDataInParent<MineSweeperGameDataUI.UIData> ();
													if (mineSweeperGameDataUIData != null) {
														boardUIData = mineSweeperGameDataUIData.board.v;
													}
												}
												// Process
												if (boardUIData != null) {
													MineSweeper mineSweeper = boardUIData.mineSweeper.v.data;
													if (mineSweeper != null) {
														// change view position due to animation
														if (mineSweeperMove.move.v >= 0) {
															if (mineSweeper.Y.v > 0) {
																int moveX = mineSweeperMove.move.v / mineSweeper.Y.v;
																int moveY = mineSweeperMove.move.v % mineSweeper.Y.v;
																if (moveX >= boardUIData.x.v && moveX < boardUIData.x.v + boardUIData.width.v
																	&& moveY >= boardUIData.y.v && moveY < boardUIData.y.v + boardUIData.height.v) {
																	// Da o trong tam nhin
																} else {
																	// Chua o trong tam nhin, phai chuyen
																	float newX = moveX - boardUIData.width.v / 2;
																	float newY = moveY - boardUIData.height.v / 2;
																	// Set
																	{
																		// x
																		boardUIData.x.v = Mathf.Clamp (newX, 0, mineSweeper.X.v - boardUIData.width.v);
																		// y
																		boardUIData.y.v = Mathf.Clamp (newY, 0, mineSweeper.Y.v - boardUIData.height.v);
																	}
																	Debug.LogError ("not in the view, so change: " + newX + "; " + newY + "; " + moveX + "; " + moveY);
																}
															} else {
																Debug.LogError ("why Y < 0: " + mineSweeper.Y.v + "; " + this);
															}
														}
													} else {
														Debug.LogError ("mineSweeper null: " + this);
													}
												} else {
													Debug.LogError ("boardUIData null: " + this);
												}
											}
										}
									}
									// Find
									MineSweeperMoveUI.UIData mineSweeperMoveUIData = this.data.sub.newOrOld<MineSweeperMoveUI.UIData>();
									{
										// move
										mineSweeperMoveUIData.mineSweeperMove.v = new ReferenceData<MineSweeperMove> (mineSweeperMove);
										// isHint
										mineSweeperMoveUIData.isHint.v = true;
									}
									this.data.sub.v = mineSweeperMoveUIData;
								}
								break;
							default:
								{
									Debug.LogError ("unknown hintMove: " + hintMove + ";" + this);
									this.data.sub.v = null;
								}
								break;
							}
						} else {
							// Debug.LogError ("hintMove null: " + this);
							this.data.sub.v = null;
						}
					} else {
						// Debug.LogError ("cannot show hint: " + this);
						this.data.sub.v = null;
					}
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

		public MineSweeperMoveUI mineSweeperMovePrefab;

		private MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = null;
		private GameDataUI.UIData gameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.mineSweeperGameDataUIData);
					DataUtils.addParentCallBack (uiData, this, ref this.gameDataUIData);
				}
				// Child
				{
					uiData.sub.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				// mineSweeperGameDataUIData
				if(data is MineSweeperGameDataUI.UIData){
					// MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = data as MineSweeperGameDataUI.UIData;
					dirty = true;
					return;
				}
				// gameDataUIData
				{
					if (data is GameDataUI.UIData) {
						GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
						// Child
						{
							gameDataUIData.hintUI.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// HintUI
					{
						if (data is HintUI.UIData) {
							HintUI.UIData hintUIData = data as HintUI.UIData;
							// Child
							{
								hintUIData.state.allAddCallBack (this);
							}
							dirty = true;
							return;
						}
						// Child
						if (data is HintUI.UIData.State) {
							dirty = true;
							return;
						}
					}
				}

			}
			// Child
			{
				if (data is LastMoveSub) {
					LastMoveSub sub = data as LastMoveSub;
					{
						switch (sub.getType ()) {
						case GameMove.Type.MineSweeperMove:
							{
								MineSweeperMoveUI.UIData mineSweeperMoveUIData = sub as MineSweeperMoveUI.UIData;
								UIUtils.Instantiate (mineSweeperMoveUIData, mineSweeperMovePrefab, this.transform);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
							break;
						}
					}
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.mineSweeperGameDataUIData);
					DataUtils.removeParentCallBack (uiData, this, ref this.gameDataUIData);
				}
				// Child
				{
					uiData.sub.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			{
				// mineSweeperGameDataUIData
				if(data is MineSweeperGameDataUI.UIData){
					// MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = data as MineSweeperGameDataUI.UIData;
					return;
				}
				// gameDataUIData
				{
					if (data is GameDataUI.UIData) {
						GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
						// Child
						{
							gameDataUIData.hintUI.allRemoveCallBack (this);
						}
						return;
					}
					// HintUI
					{
						if (data is HintUI.UIData) {
							HintUI.UIData hintUIData = data as HintUI.UIData;
							// Child
							{
								hintUIData.state.allRemoveCallBack (this);
							}
							return;
						}
						// Child
						if (data is HintUI.UIData.State) {
							return;
						}
					}
				}

			}
			// Child
			{
				if (data is LastMoveSub) {
					LastMoveSub sub = data as LastMoveSub;
					{
						switch (sub.getType ()) {
						case GameMove.Type.MineSweeperMove:
							{
								MineSweeperMoveUI.UIData mineSweeperMoveUIData = sub as MineSweeperMoveUI.UIData;
								mineSweeperMoveUIData.removeCallBackAndDestroy(typeof(MineSweeperMoveUI));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
							break;
						}
					}
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
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.sub:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			{
				// mineSweeperGameDataUIData
				if (wrapProperty.p is MineSweeperGameDataUI.UIData) {
					switch ((MineSweeperGameDataUI.UIData.Property)wrapProperty.n) {
					case MineSweeperGameDataUI.UIData.Property.gameData:
						break;
					case MineSweeperGameDataUI.UIData.Property.board:
						break;
					case MineSweeperGameDataUI.UIData.Property.isOnAnimation:
						dirty = true;
						break;
					case MineSweeperGameDataUI.UIData.Property.lastMove:
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// gameDataUIData
				{
					if (wrapProperty.p is GameDataUI.UIData) {
						switch ((GameDataUI.UIData.Property)wrapProperty.n) {
						case GameDataUI.UIData.Property.gameData:
							break;
						case GameDataUI.UIData.Property.board:
							break;
						case GameDataUI.UIData.Property.allowLastMove:
							break;
						case GameDataUI.UIData.Property.hintUI:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case GameDataUI.UIData.Property.allowInput:
							break;
						case GameDataUI.UIData.Property.turn:
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// HintUI
					{
						if (wrapProperty.p is HintUI.UIData) {
							switch ((HintUI.UIData.Property)wrapProperty.n) {
							case HintUI.UIData.Property.gameData:
								break;
							case HintUI.UIData.Property.autoHint:
								break;
							case HintUI.UIData.Property.state:
								{
									ValueChangeUtils.replaceCallBack (this, syncs);
									dirty = true;
								}
								break;
							case HintUI.UIData.Property.ai:
								break;
							default:
								Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						// State
						if (wrapProperty.p is HintUI.UIData.State) {
							HintUI.UIData.State state = wrapProperty.p as HintUI.UIData.State;
							{
								switch (state.getType ()) {
								case HintUI.UIData.State.Type.Not:
									break;
								case HintUI.UIData.State.Type.Normal:
									break;
								case HintUI.UIData.State.Type.Get:
									break;
								case HintUI.UIData.State.Type.Getting:
									break;
								case HintUI.UIData.State.Type.Show:
									{
										switch ((ShowUI.UIData.Property)wrapProperty.n) {
										case ShowUI.UIData.Property.hintMove:
											dirty = true;
											break;
										default:
											Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
											break;
										}
									}
									break;
								default:
									Debug.LogError ("unknown type: " + state.getType () + "; " + this);
									break;
								}
							}
							return;
						}
					}
				}

			}
			// Child
			{
				if (wrapProperty.p is LastMoveSub) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion
	}
}
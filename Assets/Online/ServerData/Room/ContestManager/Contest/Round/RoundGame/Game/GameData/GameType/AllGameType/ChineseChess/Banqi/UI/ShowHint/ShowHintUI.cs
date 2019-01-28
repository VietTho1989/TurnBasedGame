﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Banqi.NoneRule;
using Hint;

namespace Banqi
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

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					bool canShowHint = false;
					{
						BanqiGameDataUI.UIData banqiGameDataUIData = this.data.findDataInParent<BanqiGameDataUI.UIData> ();
						if (banqiGameDataUIData != null) {
							if (!banqiGameDataUIData.isOnAnimation.v) {
								canShowHint = true;
							}
						} else {
							Debug.LogError ("banqiGameDataUIData null: " + this);
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
								// Debug.LogError ("gameDataUIData not null: " + this);
							} else {
								Debug.LogError ("gameDataUIData null: " + this);
							}
						}
						if (hintMove != null) {
							switch (hintMove.getType ()) {
							case GameMove.Type.BanqiMove:
								{
									BanqiMove banqiMove = hintMove as BanqiMove;
									// Find
									BanqiMoveUI.UIData banqiMoveUIData = this.data.sub.newOrOld<BanqiMoveUI.UIData>();
									{
										// move
										banqiMoveUIData.banqiMove.v = new ReferenceData<BanqiMove> (banqiMove);
										// isHint
										banqiMoveUIData.isHint.v = true;
									}
									this.data.sub.v = banqiMoveUIData;
								}
								break;
							case GameMove.Type.BanqiCustomMove:
								{
									BanqiCustomMove banqiCustomMove = hintMove as BanqiCustomMove;
									// Find
									BanqiCustomMoveUI.UIData banqiCustomMoveUIData = this.data.sub.newOrOld<BanqiCustomMoveUI.UIData>();
									{
										// move
										banqiCustomMoveUIData.banqiCustomMove.v = new ReferenceData<BanqiCustomMove> (banqiCustomMove);
										// isHint
										banqiCustomMoveUIData.isHint.v = true;
									}
									this.data.sub.v = banqiCustomMoveUIData;
								}
								break;
							case GameMove.Type.BanqiCustomSet:
								{
									BanqiCustomSet banqiCustomSet = hintMove as BanqiCustomSet;
									// Find
									BanqiCustomSetUI.UIData banqiCustomSetUIData = this.data.sub.newOrOld<BanqiCustomSetUI.UIData>();
									{
										// move
										banqiCustomSetUIData.banqiCustomSet.v = new ReferenceData<BanqiCustomSet> (banqiCustomSet);
										// isHint
										banqiCustomSetUIData.isHint.v = true;
									}
									this.data.sub.v = banqiCustomSetUIData;
								}
								break;
							case GameMove.Type.BanqiCustomFlip:
								{
									BanqiCustomFlip banqiCustomFlip = hintMove as BanqiCustomFlip;
									// Find
									BanqiCustomFlipUI.UIData banqiCustomFlipUIData = this.data.sub.newOrOld<BanqiCustomFlipUI.UIData>();
									{
										// move
										banqiCustomFlipUIData.banqiCustomFlip.v = new ReferenceData<BanqiCustomFlip> (banqiCustomFlip);
										// isHint
										banqiCustomFlipUIData.isHint.v = true;
									}
									this.data.sub.v = banqiCustomFlipUIData;
								}
								break;
							case GameMove.Type.None:
								this.data.sub.v = null;
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

		public BanqiMoveUI banqiMovePrefab;
		public BanqiCustomMoveUI banqiCustomMovePrefab;
		public BanqiCustomSetUI banqiCustomSetPrefab;
		public BanqiCustomFlipUI banqiCustomFlipPrefab;

		private BanqiGameDataUI.UIData banqiGameDataUIData = null;
		private GameDataUI.UIData gameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.banqiGameDataUIData);
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
				// banqiGameDataUIData
				if(data is BanqiGameDataUI.UIData){
					// BanqiGameDataUI.UIData banqiGameDataUIData = data as BanqiGameDataUI.UIData;
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
							{
								hintUIData.state.allAddCallBack (this);
							}
							dirty = true;
							return;
						}
						// State
						{
							if (data is HintUI.UIData.State) {
								HintUI.UIData.State state = data as HintUI.UIData.State;
								// Child
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
											ShowUI.UIData showUIData = state as ShowUI.UIData;
											showUIData.hintMove.allAddCallBack (this);
										}
										break;
									default:
										Debug.LogError ("unknown type: " + state.getType () + "; " + this);
										break;
									}
								}
								dirty = true;
								return;
							}
							// Child
							if (data is GameMove) {
								dirty = true;
								return;
							}
						}
					}
				}

			}
			// Child
			if (data is LastMoveSub) {
				LastMoveSub sub = data as LastMoveSub;
				// UI
				{
					switch (sub.getType ()) {
					case GameMove.Type.BanqiMove:
						{
							BanqiMoveUI.UIData banqiMoveUIData = sub as BanqiMoveUI.UIData;
							UIUtils.Instantiate (banqiMoveUIData, banqiMovePrefab, this.transform);
						}
						break;
					case GameMove.Type.BanqiCustomMove:
						{
							BanqiCustomMoveUI.UIData banqiCustomMoveUIData = sub as BanqiCustomMoveUI.UIData;
							UIUtils.Instantiate (banqiCustomMoveUIData, banqiCustomMovePrefab, this.transform);
						}
						break;
					case GameMove.Type.BanqiCustomSet:
						{
							BanqiCustomSetUI.UIData banqiCustomSetUIData = sub as BanqiCustomSetUI.UIData;
							UIUtils.Instantiate (banqiCustomSetUIData, banqiCustomSetPrefab, this.transform);
						}
						break;
					case GameMove.Type.BanqiCustomFlip:
						{
							BanqiCustomFlipUI.UIData banqiCustomFlipUIData = sub as BanqiCustomFlipUI.UIData;
							UIUtils.Instantiate (banqiCustomFlipUIData, banqiCustomFlipPrefab, this.transform);
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
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.banqiGameDataUIData);
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
				// banqiGameDataUIData
				if(data is BanqiGameDataUI.UIData){
					// BanqiGameDataUI.UIData banqiGameDataUIData = data as BanqiGameDataUI.UIData;
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
							{
								hintUIData.state.allRemoveCallBack (this);
							}
							return;
						}
						// State
						{
							if (data is HintUI.UIData.State) {
								HintUI.UIData.State state = data as HintUI.UIData.State;
								// Child
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
											ShowUI.UIData showUIData = state as ShowUI.UIData;
											showUIData.hintMove.allRemoveCallBack (this);
										}
										break;
									default:
										Debug.LogError ("unknown type: " + state.getType () + "; " + this);
										break;
									}
								}
								return;
							}
							// Child
							if (data is GameMove) {
								return;
							}
						}
					}
				}
			}
			// Child
			if (data is LastMoveSub) {
				LastMoveSub sub = data as LastMoveSub;
				// UI
				{
					switch (sub.getType ()) {
					case GameMove.Type.BanqiMove:
						{
							BanqiMoveUI.UIData banqiMoveUIData = sub as BanqiMoveUI.UIData;
							banqiMoveUIData.removeCallBackAndDestroy(typeof(BanqiMoveUI));
						}
						break;
					case GameMove.Type.BanqiCustomMove:
						{
							BanqiCustomMoveUI.UIData banqiCustomMoveUIData = sub as BanqiCustomMoveUI.UIData;
							banqiCustomMoveUIData.removeCallBackAndDestroy(typeof(BanqiCustomMoveUI));
						}
						break;
					case GameMove.Type.BanqiCustomSet:
						{
							BanqiCustomSetUI.UIData banqiCustomSetUIData = sub as BanqiCustomSetUI.UIData;
							banqiCustomSetUIData.removeCallBackAndDestroy(typeof(BanqiCustomSetUI));
						}
						break;
					case GameMove.Type.BanqiCustomFlip:
						{
							BanqiCustomFlipUI.UIData banqiCustomFlipUIData = sub as BanqiCustomFlipUI.UIData;
							banqiCustomFlipUIData.removeCallBackAndDestroy(typeof(BanqiCustomFlipUI));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
						break;
					}
				}
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
				// banqiGameDataUIData
				if (wrapProperty.p is BanqiGameDataUI.UIData) {
					switch ((BanqiGameDataUI.UIData.Property)wrapProperty.n) {
					case BanqiGameDataUI.UIData.Property.gameData:
						break;
					case BanqiGameDataUI.UIData.Property.isOnAnimation:
						dirty = true;
						break;
					case BanqiGameDataUI.UIData.Property.board:
						break;
					case BanqiGameDataUI.UIData.Property.lastMove:
						break;
					case BanqiGameDataUI.UIData.Property.inputUI:
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
							case HintUI.UIData.Property.editHintAIUIData:
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
											{
												ValueChangeUtils.replaceCallBack (this, syncs);
												dirty = true;
											}
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
						// Child
						if (wrapProperty.p is GameMove) {
							return;
						}
					}
				}

			}
			// Child
			if (wrapProperty.p is LastMoveSub) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion
	}
}
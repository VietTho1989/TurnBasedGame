using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hint;
using Weiqi.NoneRule;

namespace Weiqi
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
						WeiqiGameDataUI.UIData weiqiGameDataUIData = this.data.findDataInParent<WeiqiGameDataUI.UIData> ();
						if (weiqiGameDataUIData != null) {
							if (!weiqiGameDataUIData.isOnAnimation.v) {
								canShowHint = true;
							}
						} else {
							Debug.LogError ("weiqiGameDataUIData null: " + this);
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
							case GameMove.Type.WeiqiMove:
								{
									WeiqiMove move = hintMove as WeiqiMove;
									// Find
									WeiqiMoveUI.UIData weiqiMoveUIData = this.data.sub.newOrOld<WeiqiMoveUI.UIData>();
									{
										// move
										weiqiMoveUIData.weiqiMove.v = new ReferenceData<WeiqiMove> (move);
										// isHint
										weiqiMoveUIData.isHint.v = true;
									}
									this.data.sub.v = weiqiMoveUIData;
								}
								break;
							case GameMove.Type.WeiqiCustomSet:
								{
									WeiqiCustomSet weiqiCustomSet = hintMove as WeiqiCustomSet;
									// Find
									WeiqiCustomSetUI.UIData weiqiCustomSetUIData = this.data.sub.newOrOld<WeiqiCustomSetUI.UIData>();
									{
										// move
										weiqiCustomSetUIData.weiqiCustomSet.v = new ReferenceData<WeiqiCustomSet> (weiqiCustomSet);
										// isHint
										weiqiCustomSetUIData.isHint.v = true;
									}
									this.data.sub.v = weiqiCustomSetUIData;
								}
								break;
							case GameMove.Type.WeiqiCustomMove:
								{
									WeiqiCustomMove weiqiCustomMove = hintMove as WeiqiCustomMove;
									// Find
									WeiqiCustomMoveUI.UIData weiqiCustomMoveUIData = this.data.sub.newOrOld<WeiqiCustomMoveUI.UIData>();
									{
										// move
										weiqiCustomMoveUIData.weiqiCustomMove.v = new ReferenceData<WeiqiCustomMove> (weiqiCustomMove);
										// isHint
										weiqiCustomMoveUIData.isHint.v = true;
									}
									this.data.sub.v = weiqiCustomMoveUIData;
								}
								break;
							default:
								Debug.LogError ("unknown hintMove: " + hintMove + ";" + this);
								this.data.sub.v = null;
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

		public WeiqiMoveUI movePrefab;
		public WeiqiCustomSetUI weiqiCustomSetPrefab;
		public WeiqiCustomMoveUI weiqiCustomMovePrefab;

		private WeiqiGameDataUI.UIData weiqiGameDataUIData = null;
		private GameDataUI.UIData gameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.weiqiGameDataUIData);
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
				// weiqiGameDataUIData
				if(data is WeiqiGameDataUI.UIData){
					// WeiqiGameDataUI.UIData weiqiGameDataUIData = data as WeiqiGameDataUI.UIData;
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
						// State
						if (data is HintUI.UIData.State) {
							HintUI.UIData.State state = data as HintUI.UIData.State;
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
						if (data is GameMove) {
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
						case GameMove.Type.WeiqiMove:
							{
								WeiqiMoveUI.UIData moveUIData = sub as WeiqiMoveUI.UIData;
								UIUtils.Instantiate (moveUIData, movePrefab, this.transform);
							}
							break;
						case GameMove.Type.WeiqiCustomSet:
							{
								WeiqiCustomSetUI.UIData weiqiCustomSetUIData = sub as WeiqiCustomSetUI.UIData;
								UIUtils.Instantiate (weiqiCustomSetUIData, weiqiCustomSetPrefab, this.transform);
							}
							break;
						case GameMove.Type.WeiqiCustomMove:
							{
								WeiqiCustomMoveUI.UIData weiqiCustomMoveUIData = sub as WeiqiCustomMoveUI.UIData;
								UIUtils.Instantiate (weiqiCustomMoveUIData, weiqiCustomMovePrefab, this.transform);
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
					DataUtils.removeParentCallBack (uiData, this, ref this.weiqiGameDataUIData);
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
				// weiqiGameDataUIData
				if(data is WeiqiGameDataUI.UIData){
					// WeiqiGameDataUI.UIData weiqiGameDataUIData = data as WeiqiGameDataUI.UIData;
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
						// State
						if (data is HintUI.UIData.State) {
							HintUI.UIData.State state = data as HintUI.UIData.State;
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
						if (data is GameMove) {
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
						case GameMove.Type.WeiqiMove:
							{
								WeiqiMoveUI.UIData moveUIData = sub as WeiqiMoveUI.UIData;
								moveUIData.removeCallBackAndDestroy(typeof(WeiqiMoveUI));
							}
							break;
						case GameMove.Type.WeiqiCustomSet:
							{
								WeiqiCustomSetUI.UIData weiqiCustomSetUIData = sub as WeiqiCustomSetUI.UIData;
								weiqiCustomSetUIData.removeCallBackAndDestroy (typeof(WeiqiCustomSetUI));
							}
							break;
						case GameMove.Type.WeiqiCustomMove:
							{
								WeiqiCustomMoveUI.UIData weiqiCustomMoveUIData = sub as WeiqiCustomMoveUI.UIData;
								weiqiCustomMoveUIData.removeCallBackAndDestroy (typeof(WeiqiCustomMoveUI));
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
				// weiqiGameDataUIData
				if (wrapProperty.p is WeiqiGameDataUI.UIData) {
					switch ((WeiqiGameDataUI.UIData.Property)wrapProperty.n) {
					case WeiqiGameDataUI.UIData.Property.gameData:
						break;
					case WeiqiGameDataUI.UIData.Property.board:
						break;
					case WeiqiGameDataUI.UIData.Property.isOnAnimation:
						dirty = true;
						break;
					case WeiqiGameDataUI.UIData.Property.lastMove:
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
						if (wrapProperty.p is GameMove) {
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
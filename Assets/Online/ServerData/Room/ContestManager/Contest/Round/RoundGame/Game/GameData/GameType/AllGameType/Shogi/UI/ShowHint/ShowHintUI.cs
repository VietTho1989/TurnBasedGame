using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hint;
using Shogi.NoneRule;

namespace Shogi
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
						ShogiGameDataUI.UIData shogiGameDataUIData = this.data.findDataInParent<ShogiGameDataUI.UIData> ();
						if (shogiGameDataUIData != null) {
							if (!shogiGameDataUIData.isOnAnimation.v) {
								canShowHint = true;
							}
						} else {
							Debug.LogError ("shogiGameDataUIData null: " + this);
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
							case GameMove.Type.ShogiMove:
								{
									ShogiMove shogiMove = hintMove as ShogiMove;
									// Find
									ShogiMoveUI.UIData shogiMoveUIData = this.data.sub.newOrOld<ShogiMoveUI.UIData>();
									{
										// move
										shogiMoveUIData.shogiMove.v = new ReferenceData<ShogiMove> (shogiMove);
										// isHint
										shogiMoveUIData.isHint.v = true;
									}
									this.data.sub.v = shogiMoveUIData;
								}
								break;
							case GameMove.Type.ShogiCustomSet:
								{
									ShogiCustomSet shogiCustomSet = hintMove as ShogiCustomSet;
									// Find
									ShogiCustomSetUI.UIData shogiCustomSetUIData = this.data.sub.newOrOld<ShogiCustomSetUI.UIData>();
									{
										// move
										shogiCustomSetUIData.shogiCustomSet.v = new ReferenceData<ShogiCustomSet> (shogiCustomSet);
										// isHint
										shogiCustomSetUIData.isHint.v = true;
									}
									this.data.sub.v = shogiCustomSetUIData;
								}
								break;
							case GameMove.Type.ShogiCustomMove:
								{
									ShogiCustomMove shogiCustomMove = hintMove as ShogiCustomMove;
									// Find
									ShogiCustomMoveUI.UIData shogiCustomMoveUIData = this.data.sub.newOrOld<ShogiCustomMoveUI.UIData>();
									{
										// move
										shogiCustomMoveUIData.shogiCustomMove.v = new ReferenceData<ShogiCustomMove> (shogiCustomMove);
										// isHint
										shogiCustomMoveUIData.isHint.v = true;
									}
									this.data.sub.v = shogiCustomMoveUIData;
								}
								break;
							case GameMove.Type.ShogiCustomHand:
								{
									ShogiCustomHand shogiCustomHand = hintMove as ShogiCustomHand;
									// Find
									ShogiCustomHandUI.UIData shogiCustomHandUIData = this.data.sub.newOrOld<ShogiCustomHandUI.UIData>();
									{
										// move
										shogiCustomHandUIData.shogiCustomHand.v = new ReferenceData<ShogiCustomHand> (shogiCustomHand);
										// isHint
										shogiCustomHandUIData.isHint.v = true;
									}
									this.data.sub.v = shogiCustomHandUIData;
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

		public ShogiMoveUI shogiMovePrefab;
		public ShogiCustomSetUI shogiCustomSetPrefab;
		public ShogiCustomMoveUI shogiCustomMovePrefab;
		public ShogiCustomHandUI shogiCustomHandPrefab;

		private ShogiGameDataUI.UIData shogiGameDataUIData = null;
		private GameDataUI.UIData gameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.shogiGameDataUIData);
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
				// shogiGameDataUIData
				if(data is ShogiGameDataUI.UIData){
					// ShogiGameDataUI.UIData shogiGameDataUIData = data as ShogiGameDataUI.UIData;
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
						case GameMove.Type.ShogiMove:
							{
								ShogiMoveUI.UIData shogiMoveUIData = sub as ShogiMoveUI.UIData;
								UIUtils.Instantiate (shogiMoveUIData, shogiMovePrefab, this.transform);
							}
							break;
						case GameMove.Type.ShogiCustomSet:
							{
								ShogiCustomSetUI.UIData shogiCustomSetUIData = sub as ShogiCustomSetUI.UIData;
								UIUtils.Instantiate (shogiCustomSetUIData, shogiCustomSetPrefab, this.transform);
							}
							break;
						case GameMove.Type.ShogiCustomMove:
							{
								ShogiCustomMoveUI.UIData shogiCustomMoveUIData = sub as ShogiCustomMoveUI.UIData;
								UIUtils.Instantiate (shogiCustomMoveUIData, shogiCustomMovePrefab, this.transform);
							}
							break;
						case GameMove.Type.ShogiCustomHand:
							{
								ShogiCustomHandUI.UIData shogiCustomHandUIData = sub as ShogiCustomHandUI.UIData;
								UIUtils.Instantiate (shogiCustomHandUIData, shogiCustomHandPrefab, this.transform);
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
					DataUtils.removeParentCallBack (uiData, this, ref this.shogiGameDataUIData);
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
				// shogiGameDataUIData
				if(data is ShogiGameDataUI.UIData){
					// ShogiGameDataUI.UIData shogiGameDataUIData = data as ShogiGameDataUI.UIData;
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
						case GameMove.Type.ShogiMove:
							{
								ShogiMoveUI.UIData shogiMoveUIData = sub as ShogiMoveUI.UIData;
								shogiMoveUIData.removeCallBackAndDestroy(typeof(ShogiMoveUI));
							}
							break;
						case GameMove.Type.ShogiCustomSet:
							{
								ShogiCustomSetUI.UIData shogiCustomSetUIData = sub as ShogiCustomSetUI.UIData;
								shogiCustomSetUIData.removeCallBackAndDestroy (typeof(ShogiCustomSetUI));
							}
							break;
						case GameMove.Type.ShogiCustomMove:
							{
								ShogiCustomMoveUI.UIData shogiCustomMoveUIData = sub as ShogiCustomMoveUI.UIData;
								shogiCustomMoveUIData.removeCallBackAndDestroy (typeof(ShogiCustomMoveUI));
							}
							break;
						case GameMove.Type.ShogiCustomHand:
							{
								ShogiCustomHandUI.UIData shogiCustomHandUIData = sub as ShogiCustomHandUI.UIData;
								shogiCustomHandUIData.removeCallBackAndDestroy (typeof(ShogiCustomHandUI));
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
				// shogiGameDataUIData
				if (wrapProperty.p is ShogiGameDataUI.UIData) {
					switch ((ShogiGameDataUI.UIData.Property)wrapProperty.n) {
					case ShogiGameDataUI.UIData.Property.gameData:
						break;
					case ShogiGameDataUI.UIData.Property.board:
						break;
					case ShogiGameDataUI.UIData.Property.isOnAnimation:
						dirty = true;
						break;
					case ShogiGameDataUI.UIData.Property.lastMove:
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
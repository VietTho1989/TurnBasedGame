using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hint;
using CoTuongUp.NoneRule;

namespace CoTuongUp
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
						CoTuongUpGameDataUI.UIData coTuongUpGameDataUIData = this.data.findDataInParent<CoTuongUpGameDataUI.UIData> ();
						if (coTuongUpGameDataUIData != null) {
							if (!coTuongUpGameDataUIData.isOnAnimation.v) {
								canShowHint = true;
							}
						} else {
							Debug.LogError ("coTuongUpGameDataUIData null: " + this);
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
							case GameMove.Type.CoTuongUpMove:
								{
									CoTuongUpMove coTuongUpMove = hintMove as CoTuongUpMove;
									// Find
									CoTuongUpMoveUI.UIData coTuongUpMoveUIData = this.data.sub.newOrOld<CoTuongUpMoveUI.UIData>();
									{
										// move
										coTuongUpMoveUIData.coTuongUpMove.v = new ReferenceData<CoTuongUpMove> (coTuongUpMove);
										// isHint
										coTuongUpMoveUIData.isHint.v = true;
									}
									this.data.sub.v = coTuongUpMoveUIData;
								}
								break;
							case GameMove.Type.CoTuongUpCustomSet:
								{
									CoTuongUpCustomSet coTuongUpCustomSet = hintMove as CoTuongUpCustomSet;
									// Find
									CoTuongUpCustomSetUI.UIData coTuongUpCustomSetUIData = this.data.sub.newOrOld<CoTuongUpCustomSetUI.UIData>();
									{
										// move
										coTuongUpCustomSetUIData.coTuongUpCustomSet.v = new ReferenceData<CoTuongUpCustomSet> (coTuongUpCustomSet);
										// isHint
										coTuongUpCustomSetUIData.isHint.v = true;
									}
									this.data.sub.v = coTuongUpCustomSetUIData;
								}
								break;
							case GameMove.Type.CoTuongUpCustomMove:
								{
									CoTuongUpCustomMove coTuongUpCustomMove = hintMove as CoTuongUpCustomMove;
									// Find
									CoTuongUpCustomMoveUI.UIData coTuongUpCustomMoveUIData = this.data.sub.newOrOld<CoTuongUpCustomMoveUI.UIData>();
									{
										// move
										coTuongUpCustomMoveUIData.coTuongUpCustomMove.v = new ReferenceData<CoTuongUpCustomMove> (coTuongUpCustomMove);
										// isHint
										coTuongUpCustomMoveUIData.isHint.v = true;
									}
									this.data.sub.v = coTuongUpCustomMoveUIData;
								}
								break;
							case GameMove.Type.CoTuongUpCustomFlip:
								{
									CoTuongUpCustomFlip coTuongUpCustomFlip = hintMove as CoTuongUpCustomFlip;
									// Find
									CoTuongUpCustomFlipUI.UIData coTuongUpCustomFlipUIData = this.data.sub.newOrOld<CoTuongUpCustomFlipUI.UIData>();
									{
										// move
										coTuongUpCustomFlipUIData.coTuongUpCustomFlip.v = new ReferenceData<CoTuongUpCustomFlip> (coTuongUpCustomFlip);
										// isHint
										coTuongUpCustomFlipUIData.isHint.v = true;
									}
									this.data.sub.v = coTuongUpCustomFlipUIData;
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

		public CoTuongUpMoveUI coTuongUpMovePrefab;
		public CoTuongUpCustomSetUI coTuongUpCustomSetPrefab;
		public CoTuongUpCustomMoveUI coTuongUpCustomMovePrefab;
		public CoTuongUpCustomFlipUI coTuongUpCustomFlipPrefab;

		private CoTuongUpGameDataUI.UIData coTuongUpGameDataUIData = null;
		private GameDataUI.UIData gameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.coTuongUpGameDataUIData);
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
				// coTuongUpGameDataUIData
				if(data is CoTuongUpGameDataUI.UIData){
					// CoTuongUpGameDataUI.UIData coTuongUpGameDataUIData = data as CoTuongUpGameDataUI.UIData;
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
						case GameMove.Type.CoTuongUpMove:
							{
								CoTuongUpMoveUI.UIData coTuongUpMoveUIData = sub as CoTuongUpMoveUI.UIData;
								UIUtils.Instantiate (coTuongUpMoveUIData, coTuongUpMovePrefab, this.transform);
							}
							break;
						case GameMove.Type.CoTuongUpCustomSet:
							{
								CoTuongUpCustomSetUI.UIData coTuongUpCustomSetUIData = sub as CoTuongUpCustomSetUI.UIData;
								UIUtils.Instantiate (coTuongUpCustomSetUIData, coTuongUpCustomSetPrefab, this.transform);
							}
							break;
						case GameMove.Type.CoTuongUpCustomMove:
							{
								CoTuongUpCustomMoveUI.UIData coTuongUpCustomMoveUIData = sub as CoTuongUpCustomMoveUI.UIData;
								UIUtils.Instantiate (coTuongUpCustomMoveUIData, coTuongUpCustomMovePrefab, this.transform);
							}
							break;
						case GameMove.Type.CoTuongUpCustomFlip:
							{
								CoTuongUpCustomFlipUI.UIData coTuongUpCustomFlipUIData = sub as CoTuongUpCustomFlipUI.UIData;
								UIUtils.Instantiate (coTuongUpCustomFlipUIData, coTuongUpCustomFlipPrefab, this.transform);
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
					DataUtils.removeParentCallBack (uiData, this, ref this.coTuongUpGameDataUIData);
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
				// coTuongUpGameDataUIData
				if(data is CoTuongUpGameDataUI.UIData){
					// CoTuongUpGameDataUI.UIData coTuongUpGameDataUIData = data as CoTuongUpGameDataUI.UIData;
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
							GameMove gameMove = data as GameMove;
							switch (gameMove.getType ()) {
							case GameMove.Type.CoTuongUpMove:
								{
									CoTuongUpMove coTuongUpMove = gameMove as CoTuongUpMove;
									if (this.data != null) {
										if (this.data.sub.v != null) {
											if (this.data.sub.v is CoTuongUpMoveUI.UIData) {
												CoTuongUpMoveUI.UIData coTuongUpMoveUIData = this.data.sub.v as CoTuongUpMoveUI.UIData;
												if (coTuongUpMoveUIData.coTuongUpMove.v.data == coTuongUpMove) {
													coTuongUpMoveUIData.coTuongUpMove.v = new ReferenceData<CoTuongUpMove> (null);
												} else {
													Debug.LogError ("why different: " + this);
												}
											} else {
												Debug.LogError ("why different: " + this);
											}
										} else {
											Debug.LogError ("sub null: " + this);
										}
									} else {
										Debug.LogError ("data null: " + this);
									}
								}
								break;
							default:
								Debug.LogError ("unknown gameMove: " + gameMove + "; " + this);
								break;
							}
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
						case GameMove.Type.CoTuongUpMove:
							{
								CoTuongUpMoveUI.UIData coTuongUpMoveUIData = sub as CoTuongUpMoveUI.UIData;
								coTuongUpMoveUIData.removeCallBackAndDestroy(typeof(CoTuongUpMoveUI));
							}
							break;
						case GameMove.Type.CoTuongUpCustomSet:
							{
								CoTuongUpCustomSetUI.UIData coTuongUpCustomSetUIData = sub as CoTuongUpCustomSetUI.UIData;
								coTuongUpCustomSetUIData.removeCallBackAndDestroy (typeof(CoTuongUpCustomSetUI));
							}
							break;
						case GameMove.Type.CoTuongUpCustomMove:
							{
								CoTuongUpCustomMoveUI.UIData coTuongUpCustomMoveUIData = sub as CoTuongUpCustomMoveUI.UIData;
								coTuongUpCustomMoveUIData.removeCallBackAndDestroy (typeof(CoTuongUpCustomMoveUI));
							}
							break;
						case GameMove.Type.CoTuongUpCustomFlip:
							{
								CoTuongUpCustomFlipUI.UIData coTuongUpCustomFlipUIData = sub as CoTuongUpCustomFlipUI.UIData;
								coTuongUpCustomFlipUIData.removeCallBackAndDestroy (typeof(CoTuongUpCustomFlipUI));
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
				// coTuongUpGameDataUIData
				if (wrapProperty.p is CoTuongUpGameDataUI.UIData) {
					switch ((CoTuongUpGameDataUI.UIData.Property)wrapProperty.n) {
					case CoTuongUpGameDataUI.UIData.Property.gameData:
						break;
					case CoTuongUpGameDataUI.UIData.Property.isOnAnimation:
						dirty = true;
						break;
					case CoTuongUpGameDataUI.UIData.Property.board:
						break;
					case CoTuongUpGameDataUI.UIData.Property.lastMove:
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
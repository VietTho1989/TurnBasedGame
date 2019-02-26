using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hint;
using Makruk.NoneRule;

namespace Makruk
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
						MakrukGameDataUI.UIData makrukGameDataUIData = this.data.findDataInParent<MakrukGameDataUI.UIData> ();
						if (makrukGameDataUIData != null) {
							if (!makrukGameDataUIData.isOnAnimation.v) {
								canShowHint = true;
							}
						} else {
							Debug.LogError ("makrukGameDataUIData null: " + this);
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
							case GameMove.Type.MakrukMove:
								{
									MakrukMove makrukMove = hintMove as MakrukMove;
									// Find
									MakrukMoveUI.UIData makrukMoveUIData = this.data.sub.newOrOld<MakrukMoveUI.UIData>();
									{
										// move
										makrukMoveUIData.makrukMove.v = new ReferenceData<MakrukMove> (makrukMove);
										// isHint
										makrukMoveUIData.isHint.v = true;
									}
									this.data.sub.v = makrukMoveUIData;
								}
								break;
							case GameMove.Type.MakrukCustomSet:
								{
									MakrukCustomSet makrukCustomSet = hintMove as MakrukCustomSet;
									// Find
									MakrukCustomSetUI.UIData makrukCustomSetUIData = this.data.sub.newOrOld<MakrukCustomSetUI.UIData>();
									{
										// move
										makrukCustomSetUIData.makrukCustomSet.v = new ReferenceData<MakrukCustomSet> (makrukCustomSet);
										// isHint
										makrukCustomSetUIData.isHint.v = true;
									}
									this.data.sub.v = makrukCustomSetUIData;
								}
								break;
							case GameMove.Type.MakrukCustomMove:
								{
									MakrukCustomMove makrukCustomMove = hintMove as MakrukCustomMove;
									// Find
									MakrukCustomMoveUI.UIData makrukCustomMoveUIData = this.data.sub.newOrOld<MakrukCustomMoveUI.UIData>();
									{
										// move
										makrukCustomMoveUIData.makrukCustomMove.v = new ReferenceData<MakrukCustomMove> (makrukCustomMove);
										// isHint
										makrukCustomMoveUIData.isHint.v = true;
									}
									this.data.sub.v = makrukCustomMoveUIData;
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

		public MakrukMoveUI makrukMovePrefab;
		public MakrukCustomSetUI makrukCustomSetPrefab;
		public MakrukCustomMoveUI makrukCustomMovePrefab;

		private MakrukGameDataUI.UIData makrukGameDataUIData = null;
		private GameDataUI.UIData gameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.makrukGameDataUIData);
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
				// makrukGameDataUIData
				if(data is MakrukGameDataUI.UIData){
					// MakrukGameDataUI.UIData makrukGameDataUIData = data as MakrukGameDataUI.UIData;
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
						case GameMove.Type.MakrukMove:
							{
								MakrukMoveUI.UIData makrukMoveUIData = sub as MakrukMoveUI.UIData;
								UIUtils.Instantiate (makrukMoveUIData, makrukMovePrefab, this.transform);
							}
							break;
						case GameMove.Type.MakrukCustomSet:
							{
								MakrukCustomSetUI.UIData makrukCustomSetUIData = sub as MakrukCustomSetUI.UIData;
								UIUtils.Instantiate (makrukCustomSetUIData, makrukCustomSetPrefab, this.transform);
							}
							break;
						case GameMove.Type.MakrukCustomMove:
							{
								MakrukCustomMoveUI.UIData makrukCustomMoveUIData = sub as MakrukCustomMoveUI.UIData;
								UIUtils.Instantiate (makrukCustomMoveUIData, makrukCustomMovePrefab, this.transform);
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
					DataUtils.removeParentCallBack (uiData, this, ref this.makrukGameDataUIData);
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
				// makrukGameDataUIData
				if(data is MakrukGameDataUI.UIData){
					// MakrukGameDataUI.UIData makrukGameDataUIData = data as MakrukGameDataUI.UIData;
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
							// GameMove gameMove = data as GameMove;
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
						case GameMove.Type.MakrukMove:
							{
								MakrukMoveUI.UIData makrukMoveUIData = sub as MakrukMoveUI.UIData;
								makrukMoveUIData.removeCallBackAndDestroy(typeof(MakrukMoveUI));
							}
							break;
						case GameMove.Type.MakrukCustomSet:
							{
								MakrukCustomSetUI.UIData makrukCustomSetUIData = sub as MakrukCustomSetUI.UIData;
								makrukCustomSetUIData.removeCallBackAndDestroy (typeof(MakrukCustomSetUI));
							}
							break;
						case GameMove.Type.MakrukCustomMove:
							{
								MakrukCustomMoveUI.UIData makrukCustomMoveUIData = sub as MakrukCustomMoveUI.UIData;
								makrukCustomMoveUIData.removeCallBackAndDestroy (typeof(MakrukCustomMoveUI));
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
				// makrukGameDataUIData
				if (wrapProperty.p is MakrukGameDataUI.UIData) {
					switch ((MakrukGameDataUI.UIData.Property)wrapProperty.n) {
					case MakrukGameDataUI.UIData.Property.gameData:
						break;
					case MakrukGameDataUI.UIData.Property.isOnAnimation:
						dirty = true;
						break;
					case MakrukGameDataUI.UIData.Property.board:
						break;
					case MakrukGameDataUI.UIData.Property.lastMove:
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
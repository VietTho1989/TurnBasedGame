using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hint;
using HEX.NoneRule;

namespace HEX
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
						HexGameDataUI.UIData hexGameDataUIData = this.data.findDataInParent<HexGameDataUI.UIData> ();
						if (hexGameDataUIData != null) {
							if (!hexGameDataUIData.isOnAnimation.v) {
								canShowHint = true;
							}
						} else {
							Debug.LogError ("hexGameDataUIData null: " + this);
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
							case GameMove.Type.HexMove:
								{
									HexMove hexMove = hintMove as HexMove;
									// Find
									HexMoveUI.UIData hexMoveUIData = this.data.sub.newOrOld<HexMoveUI.UIData>();
									{
										// move
										hexMoveUIData.hexMove.v = new ReferenceData<HexMove> (hexMove);
										// isHint
										hexMoveUIData.isHint.v = true;
									}
									this.data.sub.v = hexMoveUIData;
								}
								break;
							case GameMove.Type.HexSwitch:
								{
									HexSwitch hexSwitch = hintMove as HexSwitch;
									// Find
									HexSwitchUI.UIData hexSwitchUIData = this.data.sub.newOrOld<HexSwitchUI.UIData>();
									{
										// move
										hexSwitchUIData.hexSwitch.v = new ReferenceData<HexSwitch> (hexSwitch);
										// isHint
										hexSwitchUIData.isHint.v = true;
									}
									this.data.sub.v = hexSwitchUIData;
								}
								break;
							case GameMove.Type.HexCustomSet:
								{
									HexCustomSet hexCustomSet = hintMove as HexCustomSet;
									// Find
									HexCustomSetUI.UIData hexCustomSetUIData = this.data.sub.newOrOld<HexCustomSetUI.UIData>();
									{
										// move
										hexCustomSetUIData.hexCustomSet.v = new ReferenceData<HexCustomSet> (hexCustomSet);
										// isHint
										hexCustomSetUIData.isHint.v = true;
									}
									this.data.sub.v = hexCustomSetUIData;
								}
								break;
							case GameMove.Type.HexCustomMove:
								{
									HexCustomMove hexCustomMove = hintMove as HexCustomMove;
									// Find
									HexCustomMoveUI.UIData hexCustomMoveUIData = this.data.sub.newOrOld<HexCustomMoveUI.UIData>();
									{
										// move
										hexCustomMoveUIData.hexCustomMove.v = new ReferenceData<HexCustomMove> (hexCustomMove);
										// isHint
										hexCustomMoveUIData.isHint.v = true;
									}
									this.data.sub.v = hexCustomMoveUIData;
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

		public HexMoveUI hexMovePrefab;
		public HexSwitchUI hexSwitchPrefab;
		public HexCustomSetUI hexCustomSetPrefab;
		public HexCustomMoveUI hexCustomMovePrefab;

		private HexGameDataUI.UIData hexGameDataUIData = null;
		private GameDataUI.UIData gameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack(uiData, this, ref this.hexGameDataUIData);
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
				// hexGameDataUIData
				if(data is HexGameDataUI.UIData){
					// HexGameDataUI.UIData hexGameDataUIData = data as HexGameDataUI.UIData;
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
						case GameMove.Type.HexMove:
							{
								HexMoveUI.UIData hexMoveUIData = sub as HexMoveUI.UIData;
								UIUtils.Instantiate (hexMoveUIData, hexMovePrefab, this.transform);
							}
							break;
						case GameMove.Type.HexSwitch:
							{
								HexSwitchUI.UIData hexSwitchUIData = sub as HexSwitchUI.UIData;
								UIUtils.Instantiate (hexSwitchUIData, hexSwitchPrefab, this.transform);
							}
							break;
						case GameMove.Type.HexCustomSet:
							{
								HexCustomSetUI.UIData hexCustomSetUIData = sub as HexCustomSetUI.UIData;
								UIUtils.Instantiate (hexCustomSetUIData, hexCustomSetPrefab, this.transform);
							}
							break;
						case GameMove.Type.HexCustomMove:
							{
								HexCustomMoveUI.UIData hexCustomMoveUIData = sub as HexCustomMoveUI.UIData;
								UIUtils.Instantiate (hexCustomMoveUIData, hexCustomMovePrefab, this.transform);
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
					DataUtils.removeParentCallBack (uiData, this, ref this.hexGameDataUIData);
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
				// hexGameDataUIData
				if(data is HexGameDataUI.UIData){
					// HexGameDataUI.UIData hexGameDataUIData = data as HexGameDataUI.UIData;
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
						case GameMove.Type.HexMove:
							{
								HexMoveUI.UIData hexMoveUIData = sub as HexMoveUI.UIData;
								hexMoveUIData.removeCallBackAndDestroy (typeof(HexMoveUI));
							}
							break;
						case GameMove.Type.HexSwitch:
							{
								HexSwitchUI.UIData hexSwitchUIData = sub as HexSwitchUI.UIData;
								hexSwitchUIData.removeCallBackAndDestroy (typeof(HexSwitchUI));
							}
							break;
						case GameMove.Type.HexCustomSet:
							{
								HexCustomSetUI.UIData hexCustomSetUIData = sub as HexCustomSetUI.UIData;
								hexCustomSetUIData.removeCallBackAndDestroy (typeof(HexCustomSetUI));
							}
							break;
						case GameMove.Type.HexCustomMove:
							{
								HexCustomMoveUI.UIData hexCustomMoveUIData = sub as HexCustomMoveUI.UIData;
								hexCustomMoveUIData.removeCallBackAndDestroy (typeof(HexCustomMoveUI));
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
				// hexGameDataUIData
				if (wrapProperty.p is HexGameDataUI.UIData) {
					switch ((HexGameDataUI.UIData.Property)wrapProperty.n) {
					case HexGameDataUI.UIData.Property.gameData:
						break;
					case HexGameDataUI.UIData.Property.isOnAnimation:
						dirty = true;
						break;
					case HexGameDataUI.UIData.Property.board:
						break;
					case HexGameDataUI.UIData.Property.lastMove:
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
						// Child
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
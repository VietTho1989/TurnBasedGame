using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Xiangqi.NoneRule;
using Hint;

namespace Xiangqi
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
						XiangqiGameDataUI.UIData xiangqiGameDataUIData = this.data.findDataInParent<XiangqiGameDataUI.UIData> ();
						if (xiangqiGameDataUIData != null) {
							if (!xiangqiGameDataUIData.isOnAnimation.v) {
								canShowHint = true;
							}
						} else {
							Debug.LogError ("xiangqiGameDataUIData null: " + this);
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
							case GameMove.Type.XiangqiMove:
								{
									XiangqiMove xiangqiMove = hintMove as XiangqiMove;
									// Find
									XiangqiMoveUI.UIData xiangqiMoveUIData = this.data.sub.newOrOld<XiangqiMoveUI.UIData>();
									{
										// move
										xiangqiMoveUIData.xiangqiMove.v = new ReferenceData<XiangqiMove> (xiangqiMove);
										// isHint
										xiangqiMoveUIData.isHint.v = true;
									}
									this.data.sub.v = xiangqiMoveUIData;
								}
								break;
							case GameMove.Type.XiangqiCustomSet:
								{
									XiangqiCustomSet xiangqiCustomSet = hintMove as XiangqiCustomSet;
									// Find
									XiangqiCustomSetUI.UIData xiangqiCustomSetUIData = this.data.sub.newOrOld<XiangqiCustomSetUI.UIData>();
									{
										// move
										xiangqiCustomSetUIData.xiangqiCustomSet.v = new ReferenceData<XiangqiCustomSet> (xiangqiCustomSet);
										// isHint
										xiangqiCustomSetUIData.isHint.v = true;
									}
									this.data.sub.v = xiangqiCustomSetUIData;
								}
								break;
							case GameMove.Type.XiangqiCustomMove:
								{
									XiangqiCustomMove xiangqiCustomMove = hintMove as XiangqiCustomMove;
									// Find
									XiangqiCustomMoveUI.UIData xiangqiCustomMoveUIData = this.data.sub.newOrOld<XiangqiCustomMoveUI.UIData>();
									{
										// move
										xiangqiCustomMoveUIData.xiangqiCustomMove.v = new ReferenceData<XiangqiCustomMove> (xiangqiCustomMove);
										// isHint
										xiangqiCustomMoveUIData.isHint.v = true;
									}
									this.data.sub.v = xiangqiCustomMoveUIData;
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

		public XiangqiMoveUI xiangqiMovePrefab;
		public XiangqiCustomSetUI xiangqiCustomSetPrefab;
		public XiangqiCustomMoveUI xiangqiCustomMovePrefab;

		private XiangqiGameDataUI.UIData xiangqiGameDataUIData = null;
		private GameDataUI.UIData gameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.xiangqiGameDataUIData);
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
				// xiangqiGameDataUIData
				if(data is XiangqiGameDataUI.UIData){
					// XiangqiGameDataUI.UIData xiangqiGameDataUIData = data as XiangqiGameDataUI.UIData;
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

			}
			// Child
			{
				if (data is LastMoveSub) {
					LastMoveSub sub = data as LastMoveSub;
					// UI
					{
						switch (sub.getType ()) {
						case GameMove.Type.XiangqiMove:
							{
								XiangqiMoveUI.UIData xiangqiMoveUIData = sub as XiangqiMoveUI.UIData;
								UIUtils.Instantiate (xiangqiMoveUIData, xiangqiMovePrefab, this.transform);
							}
							break;
						case GameMove.Type.XiangqiCustomSet:
							{
								XiangqiCustomSetUI.UIData xiangqiCustomSetUIData = sub as XiangqiCustomSetUI.UIData;
								UIUtils.Instantiate (xiangqiCustomSetUIData, xiangqiCustomSetPrefab, this.transform);
							}
							break;
						case GameMove.Type.XiangqiCustomMove:
							{
								XiangqiCustomMoveUI.UIData xiangqiCustomMoveUIData = sub as XiangqiCustomMoveUI.UIData;
								UIUtils.Instantiate (xiangqiCustomMoveUIData, xiangqiCustomMovePrefab, this.transform);
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
					DataUtils.removeParentCallBack (uiData, this, ref this.xiangqiGameDataUIData);
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
				// xiangqiGameDataUIData
				if(data is XiangqiGameDataUI.UIData){
					// XiangqiGameDataUI.UIData xiangqiGameDataUIData = data as XiangqiGameDataUI.UIData;
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

			}
			// Child
			{
				if (data is LastMoveSub) {
					LastMoveSub sub = data as LastMoveSub;
					{
						switch (sub.getType ()) {
						case GameMove.Type.XiangqiMove:
							{
								XiangqiMoveUI.UIData xiangqiMoveUIData = sub as XiangqiMoveUI.UIData;
								xiangqiMoveUIData.removeCallBackAndDestroy(typeof(XiangqiMoveUI));
							}
							break;
						case GameMove.Type.XiangqiCustomSet:
							{
								XiangqiCustomSetUI.UIData xiangqiCustomSetUIData = sub as XiangqiCustomSetUI.UIData;
								xiangqiCustomSetUIData.removeCallBackAndDestroy(typeof(XiangqiCustomSetUI));
							}
							break;
						case GameMove.Type.XiangqiCustomMove:
							{
								XiangqiCustomMoveUI.UIData xiangqiCustomMoveUIData = sub as XiangqiCustomMoveUI.UIData;
								xiangqiCustomMoveUIData.removeCallBackAndDestroy(typeof(XiangqiCustomMoveUI));
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
				// xiangqiGameDataUIData
				if (wrapProperty.p is XiangqiGameDataUI.UIData) {
					switch ((XiangqiGameDataUI.UIData.Property)wrapProperty.n) {
					case XiangqiGameDataUI.UIData.Property.gameData:
						break;
					case XiangqiGameDataUI.UIData.Property.isOnAnimation:
						dirty = true;
						break;
					case XiangqiGameDataUI.UIData.Property.board:
						break;
					case XiangqiGameDataUI.UIData.Property.lastMove:
						break;
					case XiangqiGameDataUI.UIData.Property.inputUI:
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
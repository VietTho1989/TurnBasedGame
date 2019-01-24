using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hint;
using Khet.NoneRule;

namespace Khet
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
						KhetGameDataUI.UIData khetGameDataUIData = this.data.findDataInParent<KhetGameDataUI.UIData> ();
						if (khetGameDataUIData != null) {
							if (!khetGameDataUIData.isOnAnimation.v) {
								canShowHint = true;
							}
						} else {
							Debug.LogError ("khetGameDataUIData null: " + this);
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
							case GameMove.Type.KhetMove:
								{
									KhetMove khetMove = hintMove as KhetMove;
									// Find
									KhetMoveUI.UIData khetMoveUIData = this.data.sub.newOrOld<KhetMoveUI.UIData>();
									{
										// move
										khetMoveUIData.khetMove.v = new ReferenceData<KhetMove> (khetMove);
										// isHint
										khetMoveUIData.isHint.v = true;
									}
									this.data.sub.v = khetMoveUIData;
								}
								break;
							case GameMove.Type.KhetCusomMove:
								{
									KhetCustomMove khetCustomMove = hintMove as KhetCustomMove;
									// Find
									KhetCustomMoveUI.UIData khetCustomMoveUIData = this.data.sub.newOrOld<KhetCustomMoveUI.UIData>();
									{
										// move
										khetCustomMoveUIData.khetCustomMove.v = new ReferenceData<KhetCustomMove> (khetCustomMove);
										// isHint
										khetCustomMoveUIData.isHint.v = true;
									}
									this.data.sub.v = khetCustomMoveUIData;
								}
								break;
							case GameMove.Type.KhetCusomSet:
								{
									KhetCustomSet khetCustomSet = hintMove as KhetCustomSet;
									// Find
									KhetCustomSetUI.UIData khetCustomSetUIData = this.data.sub.newOrOld<KhetCustomSetUI.UIData>();
									{
										// move
										khetCustomSetUIData.khetCustomSet.v = new ReferenceData<KhetCustomSet> (khetCustomSet);
										// isHint
										khetCustomSetUIData.isHint.v = true;
									}
									this.data.sub.v = khetCustomSetUIData;
								}
								break;
							case GameMove.Type.KhetCustomRotate:
								{
									KhetCustomRotate khetCustomRotate = hintMove as KhetCustomRotate;
									// Find
									KhetCustomRotateUI.UIData khetCustomRotateUIData = this.data.sub.newOrOld<KhetCustomRotateUI.UIData>();
									{
										// move
										khetCustomRotateUIData.khetCustomRotate.v = new ReferenceData<KhetCustomRotate> (khetCustomRotate);
										// isHint
										khetCustomRotateUIData.isHint.v = true;
									}
									this.data.sub.v = khetCustomRotateUIData;
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

		public KhetMoveUI khetMovePrefab;
		public KhetCustomMoveUI khetCustomMovePrefab;
		public KhetCustomSetUI khetCustomSetPrefab;
		public KhetCustomRotateUI khetCustomRotatePrefab;

		private KhetGameDataUI.UIData khetGameDataUIData = null;
		private GameDataUI.UIData gameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.khetGameDataUIData);
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
				// khetGameDataUIData
				if(data is KhetGameDataUI.UIData){
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
					// Child
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
			if (data is LastMoveSub) {
				LastMoveSub sub = data as LastMoveSub;
				// UI
				{
					switch (sub.getType ()) {
					case GameMove.Type.KhetMove:
						{
							KhetMoveUI.UIData khetMoveUIData = sub as KhetMoveUI.UIData;
							UIUtils.Instantiate (khetMoveUIData, khetMovePrefab, this.transform);
						}
						break;
					case GameMove.Type.KhetCusomMove:
						{
							KhetCustomMoveUI.UIData khetCustomMoveUIData = sub as KhetCustomMoveUI.UIData;
							UIUtils.Instantiate (khetCustomMoveUIData, khetCustomMovePrefab, this.transform);
						}
						break;
					case GameMove.Type.KhetCusomSet:
						{
							KhetCustomSetUI.UIData khetCustomSetUIData = sub as KhetCustomSetUI.UIData;
							UIUtils.Instantiate (khetCustomSetUIData, khetCustomSetPrefab, this.transform);
						}
						break;
					case GameMove.Type.KhetCustomRotate:
						{
							KhetCustomRotateUI.UIData khetCustomRotateUIData = sub as KhetCustomRotateUI.UIData;
							UIUtils.Instantiate (khetCustomRotateUIData, khetCustomRotatePrefab, this.transform);
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
					DataUtils.removeParentCallBack (uiData, this, ref this.khetGameDataUIData);
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
				// khetGameDataUIData
				if(data is KhetGameDataUI.UIData){
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
					// Child
					{
						if (data is HintUI.UIData) {
							HintUI.UIData hintUIData = data as HintUI.UIData;
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
			if (data is LastMoveSub) {
				LastMoveSub sub = data as LastMoveSub;
				{
					switch (sub.getType ()) {
					case GameMove.Type.KhetMove:
						{
							KhetMoveUI.UIData khetMoveUIData = sub as KhetMoveUI.UIData;
							khetMoveUIData.removeCallBackAndDestroy(typeof(KhetMoveUI));
						}
						break;
					case GameMove.Type.KhetCusomMove:
						{
							KhetCustomMoveUI.UIData khetCustomMoveUIData = sub as KhetCustomMoveUI.UIData;
							khetCustomMoveUIData.removeCallBackAndDestroy(typeof(KhetCustomMoveUI));
						}
						break;
					case GameMove.Type.KhetCusomSet:
						{
							KhetCustomSetUI.UIData khetCustomSetUIData = sub as KhetCustomSetUI.UIData;
							khetCustomSetUIData.removeCallBackAndDestroy (typeof(KhetCustomSetUI));
						}
						break;
					case GameMove.Type.KhetCustomRotate:
						{
							KhetCustomRotateUI.UIData khetCustomRotateUIData = sub as KhetCustomRotateUI.UIData;
							khetCustomRotateUIData.removeCallBackAndDestroy (typeof(KhetCustomRotateUI));
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
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			{
				// khetGameDataUIData
				if (wrapProperty.p is KhetGameDataUI.UIData) {
					switch ((KhetGameDataUI.UIData.Property)wrapProperty.n) {
					case KhetGameDataUI.UIData.Property.gameData:
						break;
					case KhetGameDataUI.UIData.Property.isOnAnimation:
						dirty = true;
						break;
					case KhetGameDataUI.UIData.Property.board:
						break;
					case KhetGameDataUI.UIData.Property.lastMove:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
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
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
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
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						// Child
						{
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
												Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
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
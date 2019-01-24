using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Weiqi.NoneRule;

namespace Weiqi
{
	public class LastMoveUI : UIBehavior<LastMoveUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{
			
			public VP<ReferenceData<GameData>> gameData;

			public VP<LastMoveSub> sub;

			#region Constructor

			public enum Property
			{
				gameData,
				sub
			}

			public UIData() : base()
			{
				this.gameData = new VP<ReferenceData<GameData>>(this, (byte)Property.gameData, new ReferenceData<GameData>(null));
				this.sub = new VP<LastMoveSub>(this, (byte)Property.sub, null);
			}

			#endregion

		}

		#endregion

		#region Refresh

		public Transform contentContainer;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// Find last move
					GameMove lastMove = LastMoveCheckChange<UIData>.getLastMove(this.data);
					// contentContainer
					{
						if (contentContainer != null) {
							contentContainer.gameObject.SetActive (lastMove != null);
						} else {
							Debug.LogError ("contentContainer null: " + this);
						}
					}
					// Process
					if (lastMove != null) {
						switch (lastMove.getType ()) {
						case GameMove.Type.WeiqiMove:
							{
								WeiqiMove weiqiMove = lastMove as WeiqiMove;
								// Find
								WeiqiMoveUI.UIData weiqiMoveUIData = this.data.sub.newOrOld<WeiqiMoveUI.UIData>();
								{
									// move
									weiqiMoveUIData.weiqiMove.v = new ReferenceData<WeiqiMove> (weiqiMove);
									// isHint
									weiqiMoveUIData.isHint.v = false;
								}
								this.data.sub.v = weiqiMoveUIData;
							}
							break;
						case GameMove.Type.WeiqiCustomSet:
							{
								WeiqiCustomSet weiqiCustomSet = lastMove as WeiqiCustomSet;
								// Find
								WeiqiCustomSetUI.UIData weiqiCustomSetUIData = this.data.sub.newOrOld<WeiqiCustomSetUI.UIData>();
								{
									// move
									weiqiCustomSetUIData.weiqiCustomSet.v = new ReferenceData<WeiqiCustomSet> (weiqiCustomSet);
									// isHint
									weiqiCustomSetUIData.isHint.v = false;
								}
								this.data.sub.v = weiqiCustomSetUIData;
							}
							break;
						case GameMove.Type.WeiqiCustomMove:
							{
								WeiqiCustomMove weiqiCustomMove = lastMove as WeiqiCustomMove;
								// Find
								WeiqiCustomMoveUI.UIData weiqiCustomMoveUIData = this.data.sub.newOrOld<WeiqiCustomMoveUI.UIData>();
								{
									// move
									weiqiCustomMoveUIData.weiqiCustomMove.v = new ReferenceData<WeiqiCustomMove> (weiqiCustomMove);
									// isHint
									weiqiCustomMoveUIData.isHint.v = false;
								}
								this.data.sub.v = weiqiCustomMoveUIData;
							}
							break;
						case GameMove.Type.None:
							this.data.sub.v = null;
							break;
						default:
							Debug.LogError ("unknown lastMove: " + lastMove + ";" + this);
							this.data.sub.v = null;
							break;
						}
					} else {
						// Debug.LogError ("lastMove null: " + this);
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

		public WeiqiMoveUI weiqiMovePrefab;
		public WeiqiCustomSetUI weiqiCustomSetPrefab;
		public WeiqiCustomMoveUI weiqiCustomMovePrefab;

		private LastMoveCheckChange<UIData> lastMoveCheckChange = new LastMoveCheckChange<UIData> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					lastMoveCheckChange.addCallBack (this);
					lastMoveCheckChange.setData (uiData);
				}
				// Child
				{
					uiData.sub.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is LastMoveCheckChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			if (data is LastMoveSub) {
				LastMoveSub lastMoveSub = data as LastMoveSub;
				// UI
				{
					switch (lastMoveSub.getType ()) {
					case GameMove.Type.WeiqiMove:
						{
							WeiqiMoveUI.UIData weiqiMoveUIData = lastMoveSub as WeiqiMoveUI.UIData;
							UIUtils.Instantiate (weiqiMoveUIData, weiqiMovePrefab, this.transform);
						}
						break;
					case GameMove.Type.WeiqiCustomSet:
						{
							WeiqiCustomSetUI.UIData weiqiCustomSetUIData = lastMoveSub as WeiqiCustomSetUI.UIData;
							UIUtils.Instantiate (weiqiCustomSetUIData, weiqiCustomSetPrefab, this.transform);
						}
						break;
					case GameMove.Type.WeiqiCustomMove:
						{
							WeiqiCustomMoveUI.UIData weiqiCustomMoveUIData = lastMoveSub as WeiqiCustomMoveUI.UIData;
							UIUtils.Instantiate (weiqiCustomMoveUIData, weiqiCustomMovePrefab, this.transform);
						}
						break;
					default:
						Debug.LogError ("unknown type: " + lastMoveSub.getType () + "; " + this);
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
				// CheckChange
				{
					lastMoveCheckChange.removeCallBack (this);
					lastMoveCheckChange.setData (null);
				}
				// Child
				{
					uiData.sub.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// CheckChange
			if (data is LastMoveCheckChange<UIData>) {
				return;
			}
			// Child
			if (data is LastMoveSub) {
				LastMoveSub lastMoveSub = data as LastMoveSub;
				// UI
				{
					switch (lastMoveSub.getType ()) {
					case GameMove.Type.WeiqiMove:
						{
							WeiqiMoveUI.UIData weiqiMoveUIData = lastMoveSub as WeiqiMoveUI.UIData;
							weiqiMoveUIData.removeCallBackAndDestroy (typeof(WeiqiMoveUI));
						}
						break;
					case GameMove.Type.WeiqiCustomSet:
						{
							WeiqiCustomSetUI.UIData weiqiCustomSetUIData = lastMoveSub as WeiqiCustomSetUI.UIData;
							weiqiCustomSetUIData.removeCallBackAndDestroy (typeof(WeiqiCustomSetUI));
						}
						break;
					case GameMove.Type.WeiqiCustomMove:
						{
							WeiqiCustomMoveUI.UIData weiqiCustomMoveUIData = lastMoveSub as WeiqiCustomMoveUI.UIData;
							weiqiCustomMoveUIData.removeCallBackAndDestroy (typeof(WeiqiCustomMoveUI));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + lastMoveSub.getType () + "; " + this);
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
				case UIData.Property.gameData:
					dirty = true;
					break;
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
			// CheckChange
			if (wrapProperty.p is LastMoveCheckChange<UIData>) {
				dirty = true;
				return;
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
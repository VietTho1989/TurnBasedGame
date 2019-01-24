using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RussianDraught.NoneRule;

namespace RussianDraught
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
						case GameMove.Type.RussianDraughtMove:
							{
								RussianDraughtMove russianDraughtMove = lastMove as RussianDraughtMove;
								// Find
								RussianDraughtMoveUI.UIData russianDraughtMoveUIData = this.data.sub.newOrOld<RussianDraughtMoveUI.UIData>();
								{
									// move
									russianDraughtMoveUIData.russianDraughtMove.v = new ReferenceData<RussianDraughtMove> (russianDraughtMove);
									// isHint
									russianDraughtMoveUIData.isHint.v = false;
								}
								this.data.sub.v = russianDraughtMoveUIData;
							}
							break;
						case GameMove.Type.RussianDraughtCustomSet:
							{
								RussianDraughtCustomSet russianDraughtCustomSet = lastMove as RussianDraughtCustomSet;
								// Find
								RussianDraughtCustomSetUI.UIData russianDraughtCustomSetUIData = this.data.sub.newOrOld<RussianDraughtCustomSetUI.UIData>();
								{
									// move
									russianDraughtCustomSetUIData.russianDraughtCustomSet.v = new ReferenceData<RussianDraughtCustomSet> (russianDraughtCustomSet);
									// isHint
									russianDraughtCustomSetUIData.isHint.v = false;
								}
								this.data.sub.v = russianDraughtCustomSetUIData;
							}
							break;
						case GameMove.Type.RussianDraughtCustomMove:
							{
								RussianDraughtCustomMove russianDraughtCustomMove = lastMove as RussianDraughtCustomMove;
								// Find
								RussianDraughtCustomMoveUI.UIData russianDraughtCustomMoveUIData = this.data.sub.newOrOld<RussianDraughtCustomMoveUI.UIData>();
								{
									// move
									russianDraughtCustomMoveUIData.russianDraughtCustomMove.v = new ReferenceData<RussianDraughtCustomMove> (russianDraughtCustomMove);
									// isHint
									russianDraughtCustomMoveUIData.isHint.v = false;
								}
								this.data.sub.v = russianDraughtCustomMoveUIData;
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

		public RussianDraughtMoveUI russianDraughtMovePrefab;
		public RussianDraughtCustomSetUI russianDraughtCustomSetPrefab;
		public RussianDraughtCustomMoveUI russianDraughtCustomMovePrefab;

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
					case GameMove.Type.RussianDraughtMove:
						{
							RussianDraughtMoveUI.UIData russianDraughtMoveUIData = lastMoveSub as RussianDraughtMoveUI.UIData;
							UIUtils.Instantiate (russianDraughtMoveUIData, russianDraughtMovePrefab, this.transform);
						}
						break;
					case GameMove.Type.RussianDraughtCustomSet:
						{
							RussianDraughtCustomSetUI.UIData russianDraughtCustomSetUIData = lastMoveSub as RussianDraughtCustomSetUI.UIData;
							UIUtils.Instantiate (russianDraughtCustomSetUIData, russianDraughtCustomSetPrefab, this.transform);
						}
						break;
					case GameMove.Type.RussianDraughtCustomMove:
						{
							RussianDraughtCustomMoveUI.UIData russianDraughtCustomMoveUIData = lastMoveSub as RussianDraughtCustomMoveUI.UIData;
							UIUtils.Instantiate (russianDraughtCustomMoveUIData, russianDraughtCustomMovePrefab, this.transform);
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
					case GameMove.Type.RussianDraughtMove:
						{
							RussianDraughtMoveUI.UIData russianDraughtMoveUIData = lastMoveSub as RussianDraughtMoveUI.UIData;
							russianDraughtMoveUIData.removeCallBackAndDestroy (typeof(RussianDraughtMoveUI));
						}
						break;
					case GameMove.Type.RussianDraughtCustomSet:
						{
							RussianDraughtCustomSetUI.UIData russianDraughtCustomSetUIData = lastMoveSub as RussianDraughtCustomSetUI.UIData;
							russianDraughtCustomSetUIData.removeCallBackAndDestroy (typeof(RussianDraughtCustomSetUI));
						}
						break;
					case GameMove.Type.RussianDraughtCustomMove:
						{
							RussianDraughtCustomMoveUI.UIData russianDraughtCustomMoveUIData = lastMoveSub as RussianDraughtCustomMoveUI.UIData;
							russianDraughtCustomMoveUIData.removeCallBackAndDestroy (typeof(RussianDraughtCustomMoveUI));
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
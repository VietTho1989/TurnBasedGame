using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FairyChess.NoneRule;

namespace FairyChess
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
						case GameMove.Type.FairyChessMove:
							{
								FairyChessMove fairyChessMove = lastMove as FairyChessMove;
								// Find
								FairyChessMoveUI.UIData fairyChessMoveUIData = this.data.sub.newOrOld<FairyChessMoveUI.UIData>();
								{
									// move
									fairyChessMoveUIData.fairyChessMove.v = new ReferenceData<FairyChessMove> (fairyChessMove);
									// isHint
									fairyChessMoveUIData.isHint.v = false;
								}
								this.data.sub.v = fairyChessMoveUIData;
							}
							break;
						case GameMove.Type.FairyChessCustomSet:
							{
								FairyChessCustomSet fairyChessCustomSet = lastMove as FairyChessCustomSet;
								// Find
								FairyChessCustomSetUI.UIData fairyChessCustomSetUIData = this.data.sub.newOrOld<FairyChessCustomSetUI.UIData>();
								{
									// move
									fairyChessCustomSetUIData.fairyChessCustomSet.v = new ReferenceData<FairyChessCustomSet> (fairyChessCustomSet);
									// isHint
									fairyChessCustomSetUIData.isHint.v = false;
								}
								this.data.sub.v = fairyChessCustomSetUIData;
							}
							break;
						case GameMove.Type.FairyChessCustomMove:
							{
								FairyChessCustomMove fairyChessCustomMove = lastMove as FairyChessCustomMove;
								// Find
								FairyChessCustomMoveUI.UIData fairyChessCustomMoveUIData = this.data.sub.newOrOld<FairyChessCustomMoveUI.UIData>();
								{
									// move
									fairyChessCustomMoveUIData.fairyChessCustomMove.v = new ReferenceData<FairyChessCustomMove> (fairyChessCustomMove);
									// isHint
									fairyChessCustomMoveUIData.isHint.v = false;
								}
								this.data.sub.v = fairyChessCustomMoveUIData;
							}
							break;
						case GameMove.Type.FairyChessCustomHand:
							{
								FairyChessCustomHand fairyChessCustomHand = lastMove as FairyChessCustomHand;
								// Find
								FairyChessCustomHandUI.UIData fairyChessCustomHandUIData = this.data.sub.newOrOld<FairyChessCustomHandUI.UIData>();
								{
									// move
									fairyChessCustomHandUIData.fairyChessCustomHand.v = new ReferenceData<FairyChessCustomHand> (fairyChessCustomHand);
									// isHint
									fairyChessCustomHandUIData.isHint.v = false;
								}
								this.data.sub.v = fairyChessCustomHandUIData;
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

		public FairyChessMoveUI fairyChessMovePrefab;
		public FairyChessCustomSetUI fairyChessCustomSetPrefab;
		public FairyChessCustomMoveUI fairyChessCustomMovePrefab;
		public FairyChessCustomHandUI fairyChessCustomHandPrefab;

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
					case GameMove.Type.FairyChessMove:
						{
							FairyChessMoveUI.UIData fairyChessMoveUIData = lastMoveSub as FairyChessMoveUI.UIData;
							UIUtils.Instantiate (fairyChessMoveUIData, fairyChessMovePrefab, this.transform);
						}
						break;
					case GameMove.Type.FairyChessCustomSet:
						{
							FairyChessCustomSetUI.UIData fairyChessCustomSetUIData = lastMoveSub as FairyChessCustomSetUI.UIData;
							UIUtils.Instantiate (fairyChessCustomSetUIData, fairyChessCustomSetPrefab, this.transform);
						}
						break;
					case GameMove.Type.FairyChessCustomMove:
						{
							FairyChessCustomMoveUI.UIData fairyChessCustomMoveUIData = lastMoveSub as FairyChessCustomMoveUI.UIData;
							UIUtils.Instantiate (fairyChessCustomMoveUIData, fairyChessCustomMovePrefab, this.transform);
						}
						break;
					case GameMove.Type.FairyChessCustomHand:
						{
							FairyChessCustomHandUI.UIData fairyChessCustomHandUIData = lastMoveSub as FairyChessCustomHandUI.UIData;
							UIUtils.Instantiate (fairyChessCustomHandUIData, fairyChessCustomHandPrefab, this.transform);
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
					case GameMove.Type.FairyChessMove:
						{
							FairyChessMoveUI.UIData fairyChessMoveUIData = lastMoveSub as FairyChessMoveUI.UIData;
							fairyChessMoveUIData.removeCallBackAndDestroy (typeof(FairyChessMoveUI));
						}
						break;
					case GameMove.Type.FairyChessCustomSet:
						{
							FairyChessCustomSetUI.UIData fairyChessCustomSetUIData = lastMoveSub as FairyChessCustomSetUI.UIData;
							fairyChessCustomSetUIData.removeCallBackAndDestroy (typeof(FairyChessCustomSetUI));
						}
						break;
					case GameMove.Type.FairyChessCustomMove:
						{
							FairyChessCustomMoveUI.UIData fairyChessCustomMoveUIData = lastMoveSub as FairyChessCustomMoveUI.UIData;
							fairyChessCustomMoveUIData.removeCallBackAndDestroy (typeof(FairyChessCustomMoveUI));
						}
						break;
					case GameMove.Type.FairyChessCustomHand:
						{
							FairyChessCustomHandUI.UIData fairyChessCustomHandUIData = lastMoveSub as FairyChessCustomHandUI.UIData;
							fairyChessCustomHandUIData.removeCallBackAndDestroy (typeof(FairyChessCustomHandUI));
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
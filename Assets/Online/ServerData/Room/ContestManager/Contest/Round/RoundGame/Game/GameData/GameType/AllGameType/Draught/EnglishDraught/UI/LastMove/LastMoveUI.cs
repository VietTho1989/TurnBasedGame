using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using EnglishDraught.NoneRule;

namespace EnglishDraught
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
						case GameMove.Type.EnglishDraughtMove:
							{
								EnglishDraughtMove englishDraughtMove = lastMove as EnglishDraughtMove;
								// Find
								EnglishDraughtMoveUI.UIData englishDraughtMoveUIData = this.data.sub.newOrOld<EnglishDraughtMoveUI.UIData>();
								{
									// move
									englishDraughtMoveUIData.englishDraughtMove.v = new ReferenceData<EnglishDraughtMove> (englishDraughtMove);
									// isHint
									englishDraughtMoveUIData.isHint.v = false;
								}
								this.data.sub.v = englishDraughtMoveUIData;
							}
							break;
						case GameMove.Type.EnglishDraughtCustomSet:
							{
								EnglishDraughtCustomSet englishDraughtCustomSet = lastMove as EnglishDraughtCustomSet;
								// Find
								EnglishDraughtCustomSetUI.UIData englishDraughtCustomSetUIData = this.data.sub.newOrOld<EnglishDraughtCustomSetUI.UIData>();
								{
									// move
									englishDraughtCustomSetUIData.englishDraughtCustomSet.v = new ReferenceData<EnglishDraughtCustomSet> (englishDraughtCustomSet);
									// isHint
									englishDraughtCustomSetUIData.isHint.v = false;
								}
								this.data.sub.v = englishDraughtCustomSetUIData;
							}
							break;
						case GameMove.Type.EnglishDraughtCustomMove:
							{
								EnglishDraughtCustomMove englishDraughtCustomMove = lastMove as EnglishDraughtCustomMove;
								// Find
								EnglishDraughtCustomMoveUI.UIData englishDraughtCustomMoveUIData = this.data.sub.newOrOld<EnglishDraughtCustomMoveUI.UIData>();
								{
									// move
									englishDraughtCustomMoveUIData.englishDraughtCustomMove.v = new ReferenceData<EnglishDraughtCustomMove> (englishDraughtCustomMove);
									// isHint
									englishDraughtCustomMoveUIData.isHint.v = false;
								}
								this.data.sub.v = englishDraughtCustomMoveUIData;
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

		public EnglishDraughtMoveUI englishDraughtMovePrefab;
		public EnglishDraughtCustomSetUI englishDraughtCustomSetPrefab;
		public EnglishDraughtCustomMoveUI englishDraughtCustomMovePrefab;

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
					case GameMove.Type.EnglishDraughtMove:
						{
							EnglishDraughtMoveUI.UIData englishDraughtMoveUIData = lastMoveSub as EnglishDraughtMoveUI.UIData;
							UIUtils.Instantiate (englishDraughtMoveUIData, englishDraughtMovePrefab, this.transform);
						}
						break;
					case GameMove.Type.EnglishDraughtCustomSet:
						{
							EnglishDraughtCustomSetUI.UIData englishDraughtCustomSetUIData = lastMoveSub as EnglishDraughtCustomSetUI.UIData;
							UIUtils.Instantiate (englishDraughtCustomSetUIData, englishDraughtCustomSetPrefab, this.transform);
						}
						break;
					case GameMove.Type.EnglishDraughtCustomMove:
						{
							EnglishDraughtCustomMoveUI.UIData englishDraughtCustomMoveUIData = lastMoveSub as EnglishDraughtCustomMoveUI.UIData;
							UIUtils.Instantiate (englishDraughtCustomMoveUIData, englishDraughtCustomMovePrefab, this.transform);
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
					case GameMove.Type.EnglishDraughtMove:
						{
							EnglishDraughtMoveUI.UIData englishDraughtMoveUIData = lastMoveSub as EnglishDraughtMoveUI.UIData;
							englishDraughtMoveUIData.removeCallBackAndDestroy (typeof(EnglishDraughtMoveUI));
						}
						break;
					case GameMove.Type.EnglishDraughtCustomSet:
						{
							EnglishDraughtCustomSetUI.UIData englishDraughtCustomSetUIData = lastMoveSub as EnglishDraughtCustomSetUI.UIData;
							englishDraughtCustomSetUIData.removeCallBackAndDestroy (typeof(EnglishDraughtCustomSetUI));
						}
						break;
					case GameMove.Type.EnglishDraughtCustomMove:
						{
							EnglishDraughtCustomMoveUI.UIData englishDraughtCustomMoveUIData = lastMoveSub as EnglishDraughtCustomMoveUI.UIData;
							englishDraughtCustomMoveUIData.removeCallBackAndDestroy (typeof(EnglishDraughtCustomMoveUI));
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
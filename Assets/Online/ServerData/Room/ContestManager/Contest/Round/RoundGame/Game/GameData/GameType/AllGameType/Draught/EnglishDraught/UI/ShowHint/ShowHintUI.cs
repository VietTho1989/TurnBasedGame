using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hint;
using EnglishDraught.NoneRule;

namespace EnglishDraught
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
						EnglishDraughtGameDataUI.UIData englishDraughtGameDataUIData = this.data.findDataInParent<EnglishDraughtGameDataUI.UIData> ();
						if (englishDraughtGameDataUIData != null) {
							if (!englishDraughtGameDataUIData.isOnAnimation.v) {
								canShowHint = true;
							}
						} else {
							Debug.LogError ("englishDraughtGameDataUIData null: " + this);
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
							case GameMove.Type.EnglishDraughtMove:
								{
									EnglishDraughtMove englishDraughtMove = hintMove as EnglishDraughtMove;
									// Find
									EnglishDraughtMoveUI.UIData englishDraughtMoveUIData = this.data.sub.newOrOld<EnglishDraughtMoveUI.UIData>();
									{
										// move
										englishDraughtMoveUIData.englishDraughtMove.v = new ReferenceData<EnglishDraughtMove> (englishDraughtMove);
										// isHint
										englishDraughtMoveUIData.isHint.v = true;
									}
									this.data.sub.v = englishDraughtMoveUIData;
								}
								break;
							case GameMove.Type.EnglishDraughtCustomSet:
								{
									EnglishDraughtCustomSet englishDraughtCustomSet = hintMove as EnglishDraughtCustomSet;
									// Find
									EnglishDraughtCustomSetUI.UIData englishDraughtCustomSetUIData = this.data.sub.newOrOld<EnglishDraughtCustomSetUI.UIData>();
									{
										// move
										englishDraughtCustomSetUIData.englishDraughtCustomSet.v = new ReferenceData<EnglishDraughtCustomSet> (englishDraughtCustomSet);
										// isHint
										englishDraughtCustomSetUIData.isHint.v = true;
									}
									this.data.sub.v = englishDraughtCustomSetUIData;
								}
								break;
							case GameMove.Type.EnglishDraughtCustomMove:
								{
									EnglishDraughtCustomMove englishDraughtCustomMove = hintMove as EnglishDraughtCustomMove;
									// Find
									EnglishDraughtCustomMoveUI.UIData englishDraughtCustomMoveUIData = this.data.sub.newOrOld<EnglishDraughtCustomMoveUI.UIData>();
									{
										// move
										englishDraughtCustomMoveUIData.englishDraughtCustomMove.v = new ReferenceData<EnglishDraughtCustomMove> (englishDraughtCustomMove);
										// isHint
										englishDraughtCustomMoveUIData.isHint.v = true;
									}
									this.data.sub.v = englishDraughtCustomMoveUIData;
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

		public EnglishDraughtMoveUI englishDraughtMovePrefab;
		public EnglishDraughtCustomSetUI englishDraughtCustomSetPrefab;
		public EnglishDraughtCustomMoveUI englishDraughtCustomMovePrefab;

		private EnglishDraughtGameDataUI.UIData englishDraughtGameDataUIData = null;
		private GameDataUI.UIData gameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.englishDraughtGameDataUIData);
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
				// englishDraughtGameDataUIData
				if(data is EnglishDraughtGameDataUI.UIData){
					// EnglishDraughtGameDataUI.UIData englishDraughtGameDataUIData = data as EnglishDraughtGameDataUI.UIData;
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
						case GameMove.Type.EnglishDraughtMove:
							{
								EnglishDraughtMoveUI.UIData englishDraughtMoveUIData = sub as EnglishDraughtMoveUI.UIData;
								UIUtils.Instantiate (englishDraughtMoveUIData, englishDraughtMovePrefab, this.transform);
							}
							break;
						case GameMove.Type.EnglishDraughtCustomSet:
							{
								EnglishDraughtCustomSetUI.UIData englishDraughtCustomSetUIData = sub as EnglishDraughtCustomSetUI.UIData;
								UIUtils.Instantiate (englishDraughtCustomSetUIData, englishDraughtCustomSetPrefab, this.transform);
							}
							break;
						case GameMove.Type.EnglishDraughtCustomMove:
							{
								EnglishDraughtCustomMoveUI.UIData englishDraughtCustomMoveUIData = sub as EnglishDraughtCustomMoveUI.UIData;
								UIUtils.Instantiate (englishDraughtCustomMoveUIData, englishDraughtCustomMovePrefab, this.transform);
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
					DataUtils.removeParentCallBack (uiData, this, ref this.englishDraughtGameDataUIData);
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
				// englishDraughtGameDataUIData
				if(data is EnglishDraughtGameDataUI.UIData){
					// EnglishDraughtGameDataUI.UIData englishDraughtGameDataUIData = data as EnglishDraughtGameDataUI.UIData;
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
						case GameMove.Type.EnglishDraughtMove:
							{
								EnglishDraughtMoveUI.UIData englishDraughtMoveUIData = sub as EnglishDraughtMoveUI.UIData;
								englishDraughtMoveUIData.removeCallBackAndDestroy(typeof(EnglishDraughtMoveUI));
							}
							break;
						case GameMove.Type.EnglishDraughtCustomSet:
							{
								EnglishDraughtCustomSetUI.UIData englishDraughtCustomSetUIData = sub as EnglishDraughtCustomSetUI.UIData;
								englishDraughtCustomSetUIData.removeCallBackAndDestroy (typeof(EnglishDraughtCustomSetUI));
							}
							break;
						case GameMove.Type.EnglishDraughtCustomMove:
							{
								EnglishDraughtCustomMoveUI.UIData englishDraughtCustomMoveUIData = sub as EnglishDraughtCustomMoveUI.UIData;
								englishDraughtCustomMoveUIData.removeCallBackAndDestroy (typeof(EnglishDraughtCustomMoveUI));
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
				// englishDraughtGameDataUIData
				if (wrapProperty.p is EnglishDraughtGameDataUI.UIData) {
					switch ((EnglishDraughtGameDataUI.UIData.Property)wrapProperty.n) {
					case EnglishDraughtGameDataUI.UIData.Property.gameData:
						break;
					case EnglishDraughtGameDataUI.UIData.Property.board:
						break;
					case EnglishDraughtGameDataUI.UIData.Property.isOnAnimation:
						dirty = true;
						break;
					case EnglishDraughtGameDataUI.UIData.Property.lastMove:
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
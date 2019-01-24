using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hint;
// using NineMenMorris.NoneRule;

namespace NineMenMorris
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
						NineMenMorrisGameDataUI.UIData nineMenMorrisGameDataUIData = this.data.findDataInParent<NineMenMorrisGameDataUI.UIData> ();
						if (nineMenMorrisGameDataUIData != null) {
							if (!nineMenMorrisGameDataUIData.isOnAnimation.v) {
								canShowHint = true;
							}
						} else {
							Debug.LogError ("nineMenMorrisGameDataUIData null: " + this);
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
							case GameMove.Type.NineMenMorrisMove:
								{
									NineMenMorrisMove nineMenMorrisMove = hintMove as NineMenMorrisMove;
									// Find
									NineMenMorrisMoveUI.UIData nineMenMorrisMoveUIData = this.data.sub.newOrOld<NineMenMorrisMoveUI.UIData>();
									{
										// move
										nineMenMorrisMoveUIData.nineMenMorrisMove.v = new ReferenceData<NineMenMorrisMove> (nineMenMorrisMove);
										// isHint
										nineMenMorrisMoveUIData.isHint.v = true;
									}
									this.data.sub.v = nineMenMorrisMoveUIData;
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

		public NineMenMorrisMoveUI nineMenMorrisMovePrefab;

		private NineMenMorrisGameDataUI.UIData nineMenMorrisGameDataUIData = null;
		private GameDataUI.UIData gameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.nineMenMorrisGameDataUIData);
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
				// nineMenMorrisGameDataUIData
				if(data is NineMenMorrisGameDataUI.UIData){
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
			{
				if (data is LastMoveSub) {
					LastMoveSub sub = data as LastMoveSub;
					// UI
					{
						switch (sub.getType ()) {
						case GameMove.Type.NineMenMorrisMove:
							{
								NineMenMorrisMoveUI.UIData nineMenMorrisMoveUIData = sub as NineMenMorrisMoveUI.UIData;
								UIUtils.Instantiate (nineMenMorrisMoveUIData, nineMenMorrisMovePrefab, this.transform);
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
					DataUtils.removeParentCallBack (uiData, this, ref this.nineMenMorrisGameDataUIData);
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
				// nineMenMorrisGameDataUIData
				if(data is NineMenMorrisGameDataUI.UIData){
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
			{
				if (data is LastMoveSub) {
					LastMoveSub sub = data as LastMoveSub;
					// UI
					{
						switch (sub.getType ()) {
						case GameMove.Type.NineMenMorrisMove:
							{
								NineMenMorrisMoveUI.UIData nineMenMorrisMoveUIData = sub as NineMenMorrisMoveUI.UIData;
								nineMenMorrisMoveUIData.removeCallBackAndDestroy(typeof(NineMenMorrisMoveUI));
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
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			{
				// nineMenMorrisGameDataUIData
				if (wrapProperty.p is NineMenMorrisGameDataUI.UIData) {
					switch ((NineMenMorrisGameDataUI.UIData.Property)wrapProperty.n) {
					case NineMenMorrisGameDataUI.UIData.Property.gameData:
						break;
					case NineMenMorrisGameDataUI.UIData.Property.isOnAnimation:
						dirty = true;
						break;
					case NineMenMorrisGameDataUI.UIData.Property.board:
						break;
					case NineMenMorrisGameDataUI.UIData.Property.lastMove:
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
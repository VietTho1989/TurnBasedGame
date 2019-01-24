using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Hint
{
	public class HintUI : UIBehavior<HintUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{
			
			public VP<ReferenceData<GameData>> gameData;

			public VP<bool> autoHint;

			#region State

			public abstract class State : Data
			{
				public enum Type
				{
					Not,
					Normal,
					Get,
					Getting,
					Show
				}

				public abstract Type getType();
			}

			public VP<State> state;

			#endregion

			public VP<Computer.AI> ai;

			public VP<EditHintAIUI.UIData> editHintAIUIData;

			#region Constructor

			public enum Property
			{
				gameData,
				autoHint,
				state,
				ai,
				editHintAIUIData
			}

			public UIData() : base()
			{
				this.gameData = new VP<ReferenceData<GameData>>(this, (byte)Property.gameData, new ReferenceData<GameData>(null));
				this.autoHint = new VP<bool>(this, (byte)Property.autoHint, false);
				this.state = new VP<State>(this, (byte)Property.state, new NotUI.UIData());
				this.ai = new VP<Computer.AI>(this, (byte)Property.ai, null);
				this.editHintAIUIData = new VP<EditHintAIUI.UIData>(this, (byte)Property.editHintAIUIData, null);
			}

			#endregion

			public bool processEvent(Event e)
			{
				bool isProcess = false;
				{
					// editHintAIUIData
					if (!isProcess) {
						EditHintAIUI.UIData editHintAIUIData = this.editHintAIUIData.v;
						if (editHintAIUIData != null) {
							isProcess = editHintAIUIData.processEvent (e);
						} else {
							Debug.LogError ("editHintAIUIData null: " + this);
						}
					}
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text tvAuto;
		public static readonly TxtLanguage txtAuto = new TxtLanguage();

		static HintUI()
		{
			txtAuto.add (Language.Type.vi, "Tự Động");
		}

		#endregion

		public Toggle tgAutoHint;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// tgAutoHint
					if (tgAutoHint != null) {
						tgAutoHint.isOn = this.data.autoHint.v;
					} else {
						Debug.LogError ("tgAutoHint null: " + this);
					}
					// editHintUIData
					{
						EditHintAIUI.UIData editHintAIUIData = this.data.editHintAIUIData.v;
						if (editHintAIUIData != null) {
							AIUI.UIData aiUIData = editHintAIUIData.aiUIData.v;
							if (aiUIData != null) {
								EditData<Computer.AI> editAI = aiUIData.editAI.v;
								if (editAI != null) {
									// origin
									editAI.origin.v = new ReferenceData<Computer.AI> (this.data.ai.v);
									// show
									// canEdit
									editAI.canEdit.v = true;
									// editType
								} else {
									Debug.LogError ("editAI null: " + this);
								}
							} else {
								Debug.LogError ("aiUIData null: " + this);
							}
						} else {
							// Debug.LogError ("editHintAIUIData null: " + this);
						}
					}
					// txt
					{
						if (tvAuto != null) {
							tvAuto.text = txtAuto.get ("Auto");
						} else {
							Debug.LogError ("tvAuto null: " + this);
						}
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

		public Transform stateContainer;
		public NotUI notPrefab;
		public NormalUI normalPrefab;
		public GetUI getPrefab;
		public GettingUI gettingPrefab;
		public ShowUI showPrefab;

		public EditHintAIUI editHintAIPrefab;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Update
				{
					UpdateUtils.makeUpdate<PreventAINullUpdate, HintUI.UIData> (uiData, this.transform);
					UpdateUtils.makeUpdate<HintUpdate, HintUI.UIData> (uiData, this.transform);
				}
				// Child
				{
					uiData.gameData.allAddCallBack (this);
					uiData.state.allAddCallBack (this);
					uiData.editHintAIUIData.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Setting
			if (data is Setting) {
				dirty = true;
				return;
			}
			// Child
			{
				if (data is GameData) {
					// GameData gameData = data as GameData;
					// reset state
					{
						if (this.data != null) {
							NotUI.UIData notUIData = this.data.state.newOrOld<NotUI.UIData> ();
							{

							}
							this.data.state.v = notUIData;
						} else {
							Debug.LogError ("data null: " + this);
						}
					}
					dirty = true;
					return;
				}
				if (data is UIData.State) {
					UIData.State state = data as UIData.State;
					{
						switch (state.getType ()) {
						case UIData.State.Type.Not:
							{
								NotUI.UIData notUIData = state as NotUI.UIData;
								UIUtils.Instantiate (notUIData, notPrefab, stateContainer);
							}
							break;
						case UIData.State.Type.Normal:
							{
								NormalUI.UIData normalUIData = state as NormalUI.UIData;
								UIUtils.Instantiate (normalUIData, normalPrefab, stateContainer);
							}
							break;
						case UIData.State.Type.Get:
							{
								GetUI.UIData getUIData = state as GetUI.UIData;
								UIUtils.Instantiate (getUIData, getPrefab, stateContainer);
							}
							break;
						case UIData.State.Type.Getting:
							{
								GettingUI.UIData gettingUIData = state as GettingUI.UIData;
								UIUtils.Instantiate (gettingUIData, gettingPrefab, stateContainer);
							}
							break;
						case UIData.State.Type.Show:
							{
								ShowUI.UIData showUIData = state as ShowUI.UIData;
								UIUtils.Instantiate (showUIData, showPrefab, stateContainer);
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
				if (data is EditHintAIUI.UIData) {
					EditHintAIUI.UIData editHintAIUIData = data as EditHintAIUI.UIData;
					// UI
					{
						Transform transform = this.transform;
						// Find transform
						{
							GameDataUI.UIData gameDataUIData = editHintAIUIData.findDataInParent<GameDataUI.UIData> ();
							if (gameDataUIData != null) {
								GameDataUI gameDataUI = gameDataUIData.findCallBack<GameDataUI> ();
								if (gameDataUI != null) {
									transform = gameDataUI.transform;
								} else {
									Debug.LogError ("gameDataUI null: " + this);
								}
							} else {
								Debug.LogError ("gameDataUIData null: " + this);
							}
						}
						UIUtils.Instantiate (editHintAIUIData, editHintAIPrefab, transform);
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
				// Setting
				Setting.get().removeCallBack(this);
				// Update
				{
					uiData.removeCallBackAndDestroy (typeof(PreventAINullUpdate));
					uiData.removeCallBackAndDestroy (typeof(HintUpdate));
				}
				// Child
				{
					uiData.gameData.allRemoveCallBack (this);
					uiData.state.allRemoveCallBack (this);
					uiData.editHintAIUIData.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Setting
			if (data is Setting) {
				return;
			}
			// Child
			{
				if (data is GameData) {
					// GameData gameData = data as GameData;
					return;
				}
				if (data is UIData.State) {
					UIData.State state = data as UIData.State;
					{
						switch (state.getType ()) {
						case UIData.State.Type.Not:
							{
								NotUI.UIData notUIData = state as NotUI.UIData;
								notUIData.removeCallBackAndDestroy (typeof(NotUI));
							}
							break;
						case UIData.State.Type.Normal:
							{
								NormalUI.UIData normalUIData = state as NormalUI.UIData;
								normalUIData.removeCallBackAndDestroy (typeof(NormalUI));
							}
							break;
						case UIData.State.Type.Get:
							{
								GetUI.UIData getUIData = state as GetUI.UIData;
								getUIData.removeCallBackAndDestroy (typeof(GetUI));
							}
							break;
						case UIData.State.Type.Getting:
							{
								GettingUI.UIData gettingUIData = state as GettingUI.UIData;
								gettingUIData.removeCallBackAndDestroy (typeof(GettingUI));
							}
							break;
						case UIData.State.Type.Show:
							{
								ShowUI.UIData showUIData = state as ShowUI.UIData;
								showUIData.removeCallBackAndDestroy (typeof(ShowUI));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + state.getType () + "; " + this);
							break;
						}
					}
					return;
				}
				if (data is EditHintAIUI.UIData) {
					EditHintAIUI.UIData editHintAIUIData = data as EditHintAIUI.UIData;
					// UI
					{
						editHintAIUIData.removeCallBackAndDestroy (typeof(EditHintAIUI));
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
				case UIData.Property.gameData:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.autoHint:
					{
						dirty = true;
					}
					break;
				case UIData.Property.state:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.ai:
					dirty = true;
					break;
				case  UIData.Property.editHintAIUIData:
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
			// Setting
			if (wrapProperty.p is Setting) {
				switch ((Setting.Property)wrapProperty.n) {
				case Setting.Property.language:
					dirty = true;
					break;
				case Setting.Property.showLastMove:
					break;
				case Setting.Property.viewUrlImage:
					break;
				case Setting.Property.animationSetting:
					break;
				case Setting.Property.maxThinkCount:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				if (wrapProperty.p is GameData) {
					return;
				}
				if (wrapProperty.p is UIData.State) {
					return;
				}
				if (wrapProperty.p is EditHintAIUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs);
		}

		#endregion

		public void onClickBtnHint()
		{
			if (this.data != null) {
				if (this.data.state.v != null) {
					if (this.data.state.v is NormalUI.UIData) {
						GetUI.UIData getUIData = this.data.state.newOrOld<GetUI.UIData> ();
						{

						}
						this.data.state.v = getUIData;
					} else if (this.data.state.v is ShowUI.UIData) {
						NormalUI.UIData normalUIData = this.data.state.newOrOld<NormalUI.UIData> ();
						{

						}
						this.data.state.v = normalUIData;
					} else {
						NormalUI.UIData normalUIData = this.data.state.newOrOld<NormalUI.UIData> ();
						{

						}
						this.data.state.v = normalUIData;
					}
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void onClickBtnAI()
		{
			// Debug.LogError ("onClickBtnAI: " + this);
			if (this.data != null) {
				EditHintAIUI.UIData editHintAIUIData = this.data.editHintAIUIData.newOrOld<EditHintAIUI.UIData> ();
				{
					AIUI.UIData aiUIData = editHintAIUIData.aiUIData.v;
					if (aiUIData != null) {
						EditData<Computer.AI> editAI = aiUIData.editAI.v;
						if (editAI != null) {
							editAI.origin.v = new ReferenceData<Computer.AI> (this.data.ai.v);
							editAI.canEdit.v = true;
							editAI.editType.v = Data.EditType.Immediate;
						} else {
							Debug.LogError ("editAI null: " + this);
						}
					} else {
						Debug.LogError ("aiUIData null: " + this);
					}
				}
				this.data.editHintAIUIData.v = editHintAIUIData;
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void onToggleAutoChange(bool newAuto)
		{
			Debug.LogError ("onToggleAutoChange: " + newAuto + "; " + this);
			if (this.data != null) {
				if (tgAutoHint != null) {
					this.data.autoHint.v = tgAutoHint.isOn;
				} else {
					Debug.LogError ("tgAutoHint null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}
	}
}
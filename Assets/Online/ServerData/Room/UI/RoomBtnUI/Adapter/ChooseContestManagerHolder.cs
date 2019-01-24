using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ChooseContestManagerHolder : SriaHolderBehavior<ChooseContestManagerHolder.UIData>
	{

		#region UIData

		public class UIData : BaseItemViewsHolder
		{

			public VP<ReferenceData<ContestManager>> contestManager;

			#region state

			public abstract class StateUI : Data
			{

				public abstract ContestManager.State.Type getType ();

			}

			public VP<StateUI> stateUI;

			#endregion

			#region Constructor

			public enum Property
			{
				contestManager,
				stateUI
			}

			public UIData() : base()
			{
				this.contestManager = new VP<ReferenceData<ContestManager>>(this, (byte)Property.contestManager, new ReferenceData<ContestManager>(null));
				this.stateUI = new VP<StateUI>(this, (byte)Property.stateUI, null);
			}

			#endregion

			public void updateView(ChooseContestManagerAdapter.UIData myParams)
			{
				// Find
				ContestManager contestManager = null;
				{
					if (ItemIndex >= 0 && ItemIndex < myParams.contestManagers.Count) {
						contestManager = myParams.contestManagers [ItemIndex];
					} else {
						Debug.LogError ("ItemIdex error: " + this);
					}
				}
				// Update
				this.contestManager.v = new ReferenceData<ContestManager> (contestManager);
			}

		}

		#endregion

		#region Refresh

		#region txt

		public static readonly TxtLanguage txtIndex = new TxtLanguage ();

		public Text tvShow;
		public static readonly TxtLanguage txtShow = new TxtLanguage();

		static ChooseContestManagerHolder()
		{
			txtIndex.add (Language.Type.vi, "Chỉ số");
			txtShow.add (Language.Type.vi, "Hiện");
		}

		#endregion

		public Text tvIndex;

		public override void refresh ()
		{
			base.refresh ();
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					ContestManager contestManager = this.data.contestManager.v.data;
					if (contestManager != null) {
						// tvIndex
						{
							if (tvIndex != null) {
								tvIndex.text = txtIndex.get ("Index") + ": " + contestManager.index.v;
							} else {
								Debug.LogError ("tvIndex null: " + this);
							}
						}
						// stateUI
						{
							ContestManager.State state = contestManager.state.v;
							if (state != null) {
								switch (state.getType ()) {
								case ContestManager.State.Type.Lobby:
									{
										ContestManagerStateLobby contestManagerStateLobby = state as ContestManagerStateLobby;
										// UIData
										ChooseContestManagerStateLobbyUI.UIData chooseContestManagerStateLobbyUIData = this.data.stateUI.newOrOld<ChooseContestManagerStateLobbyUI.UIData>();
										{
											chooseContestManagerStateLobbyUIData.contestManagerStateLobby.v = new ReferenceData<ContestManagerStateLobby> (contestManagerStateLobby);
										}
										this.data.stateUI.v = chooseContestManagerStateLobbyUIData;
									}
									break;
								case ContestManager.State.Type.Play:
									{
										ContestManagerStatePlay contestManagerStatePlay = state as ContestManagerStatePlay;
										// UIData
										ChooseContestManagerStatePlayUI.UIData chooseContestManagerStatePlayUIData = this.data.stateUI.newOrOld<ChooseContestManagerStatePlayUI.UIData>();
										{
											chooseContestManagerStatePlayUIData.contestManagerStatePlay.v = new ReferenceData<ContestManagerStatePlay> (contestManagerStatePlay);
										}
										this.data.stateUI.v = chooseContestManagerStatePlayUIData;
									}
									break;
								default:
									Debug.LogError ("unknown type: " + state.getType () + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("state null: " + this);
							}
						}
						// txt
						{
							if (tvShow != null) {
								tvShow.text = txtShow.get ("Show");
							} else {
								Debug.LogError ("tvShow null: " + this);
							}
						}
					} else {
						Debug.LogError ("contestManager null: " + this);
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		#endregion

		#region implement callBacks

		public ChooseContestManagerStateLobbyUI lobbyPrefab;
		public ChooseContestManagerStatePlayUI playPrefab;
		public Transform stateUIContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.contestManager.allAddCallBack (this);
					uiData.stateUI.allAddCallBack (this);
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
				if (data is ContestManager) {
					dirty = true;
					return;
				}
				if (data is UIData.StateUI) {
					UIData.StateUI stateUI = data as UIData.StateUI;
					// UI
					{
						switch (stateUI.getType ()) {
						case ContestManager.State.Type.Lobby:
							{
								ChooseContestManagerStateLobbyUI.UIData chooseContestManagerStateLobbyUIData = stateUI as ChooseContestManagerStateLobbyUI.UIData;
								UIUtils.Instantiate (chooseContestManagerStateLobbyUIData, lobbyPrefab, stateUIContainer);
							}
							break;
						case ContestManager.State.Type.Play:
							{
								ChooseContestManagerStatePlayUI.UIData chooseContestManagerStatePlayUIData = stateUI as ChooseContestManagerStatePlayUI.UIData;
								UIUtils.Instantiate (chooseContestManagerStatePlayUIData, playPrefab, stateUIContainer);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + stateUI.getType () + "; " + this);
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
				// Setting
				Setting.get().removeCallBack(this);
				// Child
				{
					uiData.contestManager.allRemoveCallBack (this);
					uiData.stateUI.allRemoveCallBack (this);
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
				if (data is ContestManager) {
					return;
				}
				if (data is UIData.StateUI) {
					UIData.StateUI stateUI = data as UIData.StateUI;
					// UI
					{
						switch (stateUI.getType ()) {
						case ContestManager.State.Type.Lobby:
							{
								ChooseContestManagerStateLobbyUI.UIData chooseContestManagerStateLobbyUIData = stateUI as ChooseContestManagerStateLobbyUI.UIData;
								chooseContestManagerStateLobbyUIData.removeCallBackAndDestroy (typeof(ChooseContestManagerStateLobbyUI));
							}
							break;
						case ContestManager.State.Type.Play:
							{
								ChooseContestManagerStatePlayUI.UIData chooseContestManagerStatePlayUIData = stateUI as ChooseContestManagerStatePlayUI.UIData;
								chooseContestManagerStatePlayUIData.removeCallBackAndDestroy (typeof(ChooseContestManagerStatePlayUI));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + stateUI.getType () + "; " + this);
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
				case UIData.Property.contestManager:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.stateUI:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("Don't process: " + data + "; " + this);
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
				if (wrapProperty.p is ContestManager) {
					switch ((ContestManager.Property)wrapProperty.n) {
					case ContestManager.Property.index:
						dirty = true;
						break;
					case ContestManager.Property.state:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is UIData.StateUI) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnShow()
		{
			if (this.data != null) {
				ContestManager contestManager = this.data.contestManager.v.data;
				if (contestManager != null) {
					RoomUI.UIData roomUIData = this.data.findDataInParent<RoomUI.UIData> ();
					if (roomUIData != null) {
						ContestManagerUI.UIData contestManagerUIData = roomUIData.contestManagerUIData.v;
						if (contestManagerUIData != null) {
							contestManagerUIData.contestManager.v = new ReferenceData<ContestManager>(contestManager);
						} else {
							Debug.LogError ("contestManagerUIData null: " + this);
						}
					} else {
						Debug.LogError ("roomUIData null: " + this);
					}
				} else {
					Debug.LogError ("contestManager null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}
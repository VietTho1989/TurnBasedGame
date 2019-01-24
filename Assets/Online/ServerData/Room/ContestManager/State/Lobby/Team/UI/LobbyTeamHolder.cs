using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using Foundation.Tasks;
using AdvancedCoroutines;

namespace GameManager.Match
{
	public class LobbyTeamHolder : SriaHolderBehavior<LobbyTeamHolder.UIData>
	{

		#region UIData

		public class UIData : BaseItemViewsHolder
		{

			public VP<ReferenceData<LobbyTeam>> lobbyTeam;

			public VP<LobbyPlayerAdapter.UIData> playerAdapter;

			#region Constructor

			public enum Property
			{
				lobbyTeam,
				playerAdapter
			}

			public UIData() : base()
			{
				this.lobbyTeam = new VP<ReferenceData<LobbyTeam>>(this, (byte)Property.lobbyTeam, new ReferenceData<LobbyTeam>(null));
				this.playerAdapter = new VP<LobbyPlayerAdapter.UIData>(this, (byte)Property.playerAdapter, new LobbyPlayerAdapter.UIData());
			}

			#endregion

			public void updateView(LobbyTeamAdapter.UIData myParams)
			{
				// Find LobbyTeam
				LobbyTeam lobbyTeam = null;
				{
					if (ItemIndex >= 0 && ItemIndex < myParams.lobbyTeams.Count) {
						lobbyTeam = myParams.lobbyTeams [ItemIndex];
					} else {
						Debug.LogError ("ItemIndex error: " + this);
					}
				}
				// Update
				this.lobbyTeam.v = new ReferenceData<LobbyTeam> (lobbyTeam);
			}

		}

		#endregion

		#region Refresh

		public Text tvTeamIndex;

		public override void refresh ()
		{
			base.refresh ();
			if (this.data != null) {
				LobbyTeam lobbyTeam = this.data.lobbyTeam.v.data;
				if (lobbyTeam != null) {
					// tvTeamIndex
					{
						if (tvTeamIndex != null) {
							tvTeamIndex.text = "TeamIndex: " + lobbyTeam.teamIndex.v;
						} else {
							Debug.LogError ("tvTeamIndex null: " + this);
						}
					}
					// playerAdapter
					{
						LobbyPlayerAdapter.UIData playerAdapter = this.data.playerAdapter.v;
						if (playerAdapter != null) {
							playerAdapter.lobbyTeam.v = new ReferenceData<LobbyTeam> (lobbyTeam);
						} else {
							Debug.LogError ("playerAdapter null: " + this);
						}
					}
				} else {
					Debug.LogError ("lobbyTeam null: " + this);
				}
			} else {
				// Debug.LogError ("data null: " + this);
			}
		}

		#endregion

		#region implement callBacks

		public LobbyPlayerAdapter playerAdapterPrefab;
		public Transform playerAdapterContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.lobbyTeam.allAddCallBack (this);
					uiData.playerAdapter.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is LobbyTeam) {
					dirty = true;
					return;
				}
				if (data is LobbyPlayerAdapter.UIData) {
					LobbyPlayerAdapter.UIData playerAdapter = data as LobbyPlayerAdapter.UIData;
					// UI
					{
						UIUtils.Instantiate (playerAdapter, playerAdapterPrefab, playerAdapterContainer);
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
				// Child
				{
					uiData.lobbyTeam.allRemoveCallBack (this);
					uiData.playerAdapter.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				if (data is LobbyTeam) {
					return;
				}
				if (data is LobbyPlayerAdapter.UIData) {
					LobbyPlayerAdapter.UIData playerAdapter = data as LobbyPlayerAdapter.UIData;
					// UI
					{
						playerAdapter.removeCallBackAndDestroy (typeof(LobbyPlayerAdapter));
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
				case UIData.Property.lobbyTeam:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.playerAdapter:
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
			// Child
			{
				if (wrapProperty.p is LobbyTeam) {
					switch ((LobbyTeam.Property)wrapProperty.n) {
					case LobbyTeam.Property.teamIndex:
						dirty = true;
						break;
					case LobbyTeam.Property.players:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is LobbyPlayerAdapter.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
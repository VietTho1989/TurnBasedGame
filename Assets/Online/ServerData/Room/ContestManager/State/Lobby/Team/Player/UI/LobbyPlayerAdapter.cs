using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class LobbyPlayerAdapter : UIBehavior<LobbyPlayerAdapter.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<LobbyTeam>> lobbyTeam;

			public LP<LobbyPlayerHolder.UIData> holders;

			#region Constructor

			public enum Property
			{
				lobbyTeam,
				holders
			}

			public UIData() : base()
			{
				this.lobbyTeam = new VP<ReferenceData<LobbyTeam>>(this, (byte)Property.lobbyTeam, new ReferenceData<LobbyTeam>(null));
				this.holders = new LP<LobbyPlayerHolder.UIData>(this, (byte)Property.holders);
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
					LobbyTeam lobbyTeam = this.data.lobbyTeam.v.data;
					if (lobbyTeam != null) {
						// get old
						List<LobbyPlayerHolder.UIData> oldPlayers = new List<LobbyPlayerHolder.UIData>();
						{
							oldPlayers.AddRange (this.data.holders.vs);
						}
						// Update
						{
							foreach (LobbyPlayer lobbyPlayer in lobbyTeam.players.vs) {
								// Find UI
								LobbyPlayerHolder.UIData lobbyPlayerUIData = null;
								{
									// Find old
									if (oldPlayers.Count > 0) {
										lobbyPlayerUIData = oldPlayers [0];
									}
									// Make new
									if (lobbyPlayerUIData == null) {
										lobbyPlayerUIData = new LobbyPlayerHolder.UIData ();
										{
											lobbyPlayerUIData.uid = this.data.holders.makeId ();
										}
										this.data.holders.add (lobbyPlayerUIData);
									} else {
										oldPlayers.Remove (lobbyPlayerUIData);
									}
								}
								// Update Property
								{
									lobbyPlayerUIData.lobbyPlayer.v = new ReferenceData<LobbyPlayer> (lobbyPlayer);
								}
							}
						}
						// Remove old
						foreach (LobbyPlayerHolder.UIData oldPlayer in oldPlayers) {
							this.data.holders.remove (oldPlayer);
						}
					} else {
						Debug.LogError ("lobbyTeam null: " + this);
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public LobbyPlayerHolder holderPrefab;
		public Transform holderContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.lobbyTeam.allAddCallBack (this);
					uiData.holders.allAddCallBack (this);
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
				if (data is LobbyPlayerHolder.UIData) {
					LobbyPlayerHolder.UIData lobbyPlayerHolderUIData = data as LobbyPlayerHolder.UIData;
					// UI
					{
						UIUtils.Instantiate (lobbyPlayerHolderUIData, holderPrefab, holderContainer);
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
					uiData.holders.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				if (data is LobbyTeam) {
					return;
				}
				if (data is LobbyPlayerHolder.UIData) {
					LobbyPlayerHolder.UIData lobbyPlayerHolderUIData = data as LobbyPlayerHolder.UIData;
					// UI
					{
						lobbyPlayerHolderUIData.removeCallBackAndDestroy (typeof(LobbyPlayerHolder));
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
				case UIData.Property.holders:
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
						break;
					case LobbyTeam.Property.players:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is LobbyPlayerHolder.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
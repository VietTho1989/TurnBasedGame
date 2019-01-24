using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace GameManager.Match
{
	public class AdminEditLobbyPlayerChooseHumanAdapter : SRIA<AdminEditLobbyPlayerChooseHumanAdapter.UIData, AdminEditLobbyPlayerChooseHumanHolder.UIData>
	{

		#region UIData

		[Serializable]
		public class UIData : BaseParams
		{
			public VP<ReferenceData<LobbyPlayer>> lobbyPlayer;

			public LP<AdminEditLobbyPlayerChooseHumanHolder.UIData> holders;

			#region Constructor

			public enum Property
			{
				lobbyPlayer,
				holders
			}

			public UIData() : base()
			{
				this.lobbyPlayer = new VP<ReferenceData<LobbyPlayer>>(this, (byte)Property.lobbyPlayer, new ReferenceData<LobbyPlayer>(null));
				this.holders = new LP<AdminEditLobbyPlayerChooseHumanHolder.UIData>(this, (byte)Property.holders);
			}

			#endregion

			[NonSerialized]
			public List<Human> humans = new List<Human> ();

			public void reset()
			{
				this.humans.Clear ();
			}

		}

		#endregion

		#region Adapter

		public AdminEditLobbyPlayerChooseHumanHolder holderPrefab;

		protected override AdminEditLobbyPlayerChooseHumanHolder.UIData CreateViewsHolder (int itemIndex)
		{
			AdminEditLobbyPlayerChooseHumanHolder.UIData uiData = new AdminEditLobbyPlayerChooseHumanHolder.UIData();
			{
				// add
				{
					uiData.uid = this.data.holders.makeId ();
					this.data.holders.add (uiData);
				}
				if (holderPrefab != null) {
					uiData.Init (holderPrefab.gameObject, itemIndex);
				} else {
					Debug.LogError ("holderPrefab null: " + this);
				}
			}
			return uiData;
		}

		protected override void UpdateViewsHolder (AdminEditLobbyPlayerChooseHumanHolder.UIData newOrRecycled)
		{
			newOrRecycled.updateView (_Params);
		}

		#endregion

		#region Refresh

		#region txt

		public Text tvNoHumans;
		public static readonly TxtLanguage txtNoHumans = new TxtLanguage();

		static AdminEditLobbyPlayerChooseHumanAdapter()
		{
			txtNoHumans.add (Language.Type.vi, "Không có người nào cả");
		}

		#endregion

		public GameObject noHumans;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					LobbyPlayer lobbyPlayer = this.data.lobbyPlayer.v.data;
					if (lobbyPlayer != null) {
						// get list of human
						List<Human> humans = new List<Human>();
						{
							Room room = lobbyPlayer.findDataInParent<Room> ();
							if (room != null) {
								// get currentUserId
								uint currentUserId = uint.MaxValue;
								{
									if (lobbyPlayer.inform.v is Human) {
										Human human = lobbyPlayer.inform.v as Human;
										currentUserId = human.playerId.v;
									}
								}
								// get list of human
								foreach (RoomUser roomUser in room.users.vs) {
									if (roomUser.isInsideRoom ()) {
										Human human = roomUser.inform.v;
										if (human != null) {
											if (human.playerId.v != currentUserId) {
												humans.Add (human);
											}
										} else {
											Debug.LogError ("human null: " + this);
										}
									}
								}
							} else {
								Debug.LogError ("room null: " + this);
							}
						}
						// Add to adapter
						{
							int min = Mathf.Min (humans.Count, _Params.humans.Count);
							// Update
							{
								for (int i = 0; i < min; i++) {
									if (humans [i] != _Params.humans [i]) {
										// change param
										_Params.humans [i] = humans [i];
										// Update holder
										foreach (AdminEditLobbyPlayerChooseHumanHolder.UIData holder in this.data.holders.vs) {
											if (holder.ItemIndex == i) {
												holder.human.v = new ReferenceData<Human> (humans [i]);
												break;
											}
										}
									}
								}
							}
							// Add or Remove
							{
								if (humans.Count > min) {
									// Add
									int insertCount = humans.Count - min;
									List<Human> addItems = humans.GetRange (min, insertCount);
									_Params.humans.AddRange (addItems);
									InsertItems (min, insertCount, false, false);
								} else {
									// Remove
									int deleteCount = _Params.humans.Count - min;
									if (deleteCount > 0) {
										RemoveItems (min, deleteCount, false, false);
										_Params.humans.RemoveRange (min, deleteCount);
									}
								}
							}
						}
						// NoHumans
						{
							if (noHumans != null) {
								bool haveAny = false;
								{
									foreach (AdminEditLobbyPlayerChooseHumanHolder.UIData holder in this.data.holders.vs) {
										if (holder.human.v.data != null) {
											AdminEditLobbyPlayerChooseHumanHolder holderUI = holder.findCallBack<AdminEditLobbyPlayerChooseHumanHolder> ();
											if (holderUI != null) {
												if (holderUI.gameObject.activeSelf) {
													haveAny = true;
													break;
												}
											} else {
												Debug.LogError ("holderUI null: " + this);
											}
										}
									}
								}
								noHumans.SetActive (!haveAny);
							} else {
								Debug.LogError ("noHumans null: " + this);
							}
						}
					} else {
						Debug.LogError ("lobbyPlayer null: " + this);
					}
					// txt
					{
						if (tvNoHumans != null) {
							tvNoHumans.text = txtNoHumans.get ("Don't have any humans");
						} else {
							Debug.LogError ("tvNoHumans null: " + this);
						}
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		#endregion

		#region implement callBacks

		private RoomCheckChangeAdminChange<LobbyPlayer> roomCheckAdminChange = new RoomCheckChangeAdminChange<LobbyPlayer>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.lobbyPlayer.allAddCallBack (this);
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
				if (data is LobbyPlayer) {
					LobbyPlayer lobbyPlayer = data as LobbyPlayer;
					// reset
					{
						if (this.data != null) {
							this.data.reset ();
						} else {
							Debug.LogError ("data null: " + this);
						}
					}
					// CheckChange
					{
						roomCheckAdminChange.addCallBack (this);
						roomCheckAdminChange.setData (lobbyPlayer);
					}
					// Child
					{
						lobbyPlayer.inform.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// CheckChange
				if (data is RoomCheckChangeAdminChange<LobbyPlayer>) {
					dirty = true;
					return;
				}
				// Child
				if (data is GamePlayer.Inform) {
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
					uiData.lobbyPlayer.allRemoveCallBack (this);
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
				if (data is LobbyPlayer) {
					LobbyPlayer lobbyPlayer = data as LobbyPlayer;
					// CheckChange
					{
						roomCheckAdminChange.removeCallBack (this);
						roomCheckAdminChange.setData (null);
					}
					// Child
					{
						lobbyPlayer.inform.allRemoveCallBack (this);
					}
					return;
				}
				// CheckChange
				if (data is RoomCheckChangeAdminChange<LobbyPlayer>) {
					return;
				}
				// Child
				if (data is GamePlayer.Inform) {
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
				case UIData.Property.lobbyPlayer:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.holders:
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
				if (wrapProperty.p is LobbyPlayer) {
					switch ((LobbyPlayer.Property)wrapProperty.n) {
					case LobbyPlayer.Property.playerIndex:
						break;
					case LobbyPlayer.Property.inform:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case LobbyPlayer.Property.isReady:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// CheckChange
				if (wrapProperty.p is RoomCheckChangeAdminChange<LobbyPlayer>) {
					dirty = true;
					return;
				}
				// Child
				if (wrapProperty.p is GamePlayer.Inform) {
					if (wrapProperty.p is Human) {
						Human.onUpdateSyncPlayerIdChange (wrapProperty, this);
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using Foundation.Tasks;
using AdvancedCoroutines;

namespace GameManager.Match
{
	public class LobbyPlayerHolder : UIBehavior<LobbyPlayerHolder.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<LobbyPlayer>> lobbyPlayer;

			public VP<InformAvatarUI.UIData> avatar;

			public VP<LobbyPlayerBtnSetReady.UIData> btnReady;

			#region Constructor

			public enum Property
			{
				lobbyPlayer,
				avatar,
				btnReady
			}

			public UIData() : base()
			{
				this.lobbyPlayer = new VP<ReferenceData<LobbyPlayer>>(this, (byte)Property.lobbyPlayer, new ReferenceData<LobbyPlayer>(null));
				this.avatar = new VP<InformAvatarUI.UIData>(this, (byte)Property.avatar, new InformAvatarUI.UIData());
				this.btnReady = new VP<LobbyPlayerBtnSetReady.UIData>(this, (byte)Property.btnReady, new LobbyPlayerBtnSetReady.UIData());
			}

			#endregion

		}

		#endregion

		#region Refresh

		#region txt

		public Text tvEdit;
		public static readonly TxtLanguage txtEdit = new TxtLanguage();

		public static readonly TxtLanguage txtPlayerIndex = new TxtLanguage();
		public static readonly TxtLanguage txtName = new TxtLanguage();

		static LobbyPlayerHolder()
		{
			txtEdit.add (Language.Type.vi, "Chỉnh sửa");
			txtPlayerIndex.add (Language.Type.vi, "Chỉ số người chơi");
			txtName.add (Language.Type.vi, "Tên");
		}

		#endregion

		public Text tvName;
		public Text tvPlayerIndex;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					LobbyPlayer lobbyPlayer = this.data.lobbyPlayer.v.data;
					if (lobbyPlayer != null) {
						// tvPlayerIndex
						{
							if (tvPlayerIndex != null) {
								tvPlayerIndex.text = txtPlayerIndex.get ("PlayerIndex") + ": " + lobbyPlayer.playerIndex.v;
							} else {
								Debug.LogError ("tvPlayerIndex null: " + this);
							}
						}
						// avatar
						{
							InformAvatarUI.UIData avatar = this.data.avatar.v;
							if (avatar != null) {
								avatar.inform.v = new ReferenceData<GamePlayer.Inform> (lobbyPlayer.inform.v);
							} else {
								Debug.LogError ("avatar null: " + this);
							}
						}
						// tvName
						{
							if (tvName != null) {
								string strName = "";
								{
									GamePlayer.Inform inform = lobbyPlayer.inform.v;
									if (inform != null) {
										strName = inform.getPlayerName ();
									} else {
										Debug.LogError ("inform null: " + this);
									}
								}
								tvName.text = txtName.get ("Name") + ": " + strName;
							} else {
								Debug.LogError ("tvName null: " + this);
							}
						}
						// btnReady
						{
							LobbyPlayerBtnSetReady.UIData btnReady = this.data.btnReady.v;
							if (btnReady != null) {
								btnReady.lobbyPlayer.v = new ReferenceData<LobbyPlayer> (lobbyPlayer);
							} else {
								Debug.LogError ("btnReady null: " + this);
							}
						}
					} else {
						Debug.LogError ("lobbyPlayer null: " + this);
					}
					// txt
					{
						if (tvEdit != null) {
							tvEdit.text = txtEdit.get ("Edit");
						} else {
							Debug.LogError ("tvEdit null: " + this);
						}
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

		public InformAvatarUI avatarPrefab;
		public Transform avatarContainer;

		public LobbyPlayerBtnSetReady btnReadyPrefab;
		public Transform btnReadyContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.lobbyPlayer.allAddCallBack (this);
					uiData.avatar.allAddCallBack (this);
					uiData.btnReady.allAddCallBack (this);
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
				// LobbyPlayer
				{
					if (data is LobbyPlayer) {
						LobbyPlayer lobbyPlayer = data as LobbyPlayer;
						// Child
						{
							lobbyPlayer.inform.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is GamePlayer.Inform) {
							GamePlayer.Inform inform = data as GamePlayer.Inform;
							switch (inform.getType ()) {
							case GamePlayer.Inform.Type.None:
								break;
							case GamePlayer.Inform.Type.Human:
								{
									Human human = inform as Human;
									human.account.allAddCallBack (this);
								}
								break;
							case GamePlayer.Inform.Type.Computer:
								break;
							default:
								Debug.LogError ("unknown type: " + inform.getType () + "; " + this);
								break;
							}
							dirty = true;
							return;
						}
						// Child
						if (data is Account) {
							dirty = true;
							return;
						}
					}
				}
				if (data is InformAvatarUI.UIData) {
					InformAvatarUI.UIData avatar = data as InformAvatarUI.UIData;
					// UI
					{
						UIUtils.Instantiate (avatar, avatarPrefab, avatarContainer);
					}
					dirty = true;
					return;
				}
				if (data is LobbyPlayerBtnSetReady.UIData) {
					LobbyPlayerBtnSetReady.UIData btnReady = data as LobbyPlayerBtnSetReady.UIData;
					// UI
					{
						UIUtils.Instantiate (btnReady, btnReadyPrefab, btnReadyContainer);
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
					uiData.lobbyPlayer.allRemoveCallBack (this);
					uiData.avatar.allRemoveCallBack (this);
					uiData.btnReady.allRemoveCallBack (this);
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
				// LobbyPlayer
				{
					if (data is LobbyPlayer) {
						LobbyPlayer lobbyPlayer = data as LobbyPlayer;
						// Child
						{
							lobbyPlayer.inform.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is GamePlayer.Inform) {
							GamePlayer.Inform inform = data as GamePlayer.Inform;
							switch (inform.getType ()) {
							case GamePlayer.Inform.Type.None:
								break;
							case GamePlayer.Inform.Type.Human:
								{
									Human human = inform as Human;
									human.account.allRemoveCallBack (this);
								}
								break;
							case GamePlayer.Inform.Type.Computer:
								break;
							default:
								Debug.LogError ("unknown type: " + inform.getType () + "; " + this);
								break;
							}
							return;
						}
						// Child
						if (data is Account) {
							return;
						}
					}
				}
				if (data is InformAvatarUI.UIData) {
					InformAvatarUI.UIData avatar = data as InformAvatarUI.UIData;
					// UI
					{
						avatar.removeCallBackAndDestroy (typeof(InformAvatarUI));
					}
					return;
				}
				if (data is LobbyPlayerBtnSetReady.UIData) {
					LobbyPlayerBtnSetReady.UIData btnReady = data as LobbyPlayerBtnSetReady.UIData;
					// UI
					{
						btnReady.removeCallBackAndDestroy (typeof(LobbyPlayerBtnSetReady));
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
				case UIData.Property.lobbyPlayer:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.avatar:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.btnReady:
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
				// LobbyPlayer
				{
					if (wrapProperty.p is LobbyPlayer) {
						switch ((LobbyPlayer.Property)wrapProperty.n) {
						case LobbyPlayer.Property.playerIndex:
							dirty = true;
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
					// Child
					{
						if (wrapProperty.p is GamePlayer.Inform) {
							GamePlayer.Inform inform = wrapProperty.p as GamePlayer.Inform;
							switch (inform.getType ()) {
							case GamePlayer.Inform.Type.None:
								break;
							case GamePlayer.Inform.Type.Human:
								{
									switch ((Human.Property)wrapProperty.n) {
									case Human.Property.playerId:
										break;
									case Human.Property.account:
										{
											ValueChangeUtils.replaceCallBack(this, syncs);
											dirty =true;
										}
										break;
									case Human.Property.state:
										break;
									case Human.Property.email:
										break;
									case Human.Property.phoneNumber:
										break;
									case Human.Property.status:
										break;
									case Human.Property.birthday:
										break;
									case Human.Property.sex:
										break;
									case Human.Property.connection:
										break;
									case Human.Property.ban:
										break;
									default:
										Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
										break;
									}
								}
								break;
							case GamePlayer.Inform.Type.Computer:
								{
									switch ((Computer.Property)wrapProperty.n) {
									case Computer.Property.computerName:
										dirty = true;
										break;
									case Computer.Property.avatarUrl:
										break;
									case Computer.Property.ai:
										break;
									default:
										Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
										break;
									}
								}
								break;
							default:
								Debug.LogError ("unknown type: " + inform.getType () + "; " + this);
								break;
							}
							return;
						}
						// Child
						if (wrapProperty.p is Account) {
							Account.OnUpdateSyncAccount (wrapProperty, this);
							return;
						}
					}
				}
				if (wrapProperty.p is InformAvatarUI.UIData) {
					return;
				}
				if (wrapProperty.p is LobbyPlayerBtnSetReady.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnEdit()
		{
			if (this.data != null) {
				LobbyPlayer lobbyPlayer = this.data.lobbyPlayer.v.data;
				if (lobbyPlayer != null) {
					ContestManagerStateLobbyUI.UIData contestManagerStateLobbyUIData = this.data.findDataInParent<ContestManagerStateLobbyUI.UIData> ();
					if (contestManagerStateLobbyUIData != null) {
						// UIData
						EditLobbyPlayerUI.UIData editLobbyPlayerUIData = contestManagerStateLobbyUIData.editLobbyPlayer.newOrOld<EditLobbyPlayerUI.UIData> ();
						{
							editLobbyPlayerUIData.lobbyPlayer.v = new ReferenceData<LobbyPlayer> (lobbyPlayer);
						}
						contestManagerStateLobbyUIData.editLobbyPlayer.v = editLobbyPlayerUIData;
					} else {
						Debug.LogError ("contestManagerStateLobbyUIData null: " + this);
					}
				} else {
					Debug.LogError ("lobbyPlayer null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}
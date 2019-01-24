using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class EditLobbyPlayerUI : UIBehavior<EditLobbyPlayerUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<LobbyPlayer>> lobbyPlayer;

			public VP<InformUI> informUI;

			public VP<LobbyPlayerBtnSetReady.UIData> btnReady;

			#region Sub

			public abstract class Sub : Data
			{

				public abstract RoomUser.Role getType ();

				public abstract bool processEvent(Event e);

			}

			public VP<Sub> sub;

			#endregion

			#region Constructor

			public enum Property
			{
				lobbyPlayer,
				informUI,
				btnReady,
				sub
			}

			public UIData() : base()
			{
				this.lobbyPlayer = new VP<ReferenceData<LobbyPlayer>>(this, (byte)Property.lobbyPlayer, new ReferenceData<LobbyPlayer>(null));
				this.informUI = new VP<InformUI>(this, (byte)Property.informUI, null);
				this.btnReady = new VP<LobbyPlayerBtnSetReady.UIData>(this, (byte)Property.btnReady, new LobbyPlayerBtnSetReady.UIData());
				this.sub = new VP<Sub>(this, (byte)Property.sub, null);
			}

			#endregion

			public bool processEvent(Event e)
			{
				bool isProcess = false;
				{
					// sub
					if (!isProcess) {
						Sub sub = this.sub.v;
						if (sub != null) {
							isProcess = sub.processEvent (e);
						} else {
							Debug.LogError ("sub null: " + this);
						}
					}
					// back
					if (!isProcess) {
						if (InputEvent.isBackEvent (e)) {
							EditLobbyPlayerUI editLobbyPlayerUI = this.findCallBack<EditLobbyPlayerUI> ();
							if (editLobbyPlayerUI != null) {
								editLobbyPlayerUI.onClickBtnBack ();
							} else {
								Debug.LogError ("editLobbyPlayerUI null: " + this);
							}
							isProcess = true;
						}
					}
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		public Text tvBack;
		public static readonly TxtLanguage txtBack = new TxtLanguage();

		public static readonly TxtLanguage txtTeamIndex = new TxtLanguage ();
		public static readonly TxtLanguage txtPlayerIndex = new TxtLanguage ();

		static EditLobbyPlayerUI()
		{
			txtTitle.add (Language.Type.vi, "Chỉnh Sửa Người chơi");
			txtBack.add (Language.Type.vi, "Quay Lại");
			txtTeamIndex.add (Language.Type.vi, "Chỉ số đội");
			txtPlayerIndex.add (Language.Type.vi, "Chỉ số người chơi");
		}

		#endregion

		public Text tvTeamIndex;
		public Text tvPlayerIndex;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					LobbyPlayer lobbyPlayer = this.data.lobbyPlayer.v.data;
					if (lobbyPlayer != null) {
						if (lobbyPlayer.getDataParent () != null) {
							// tvTeamIndex
							{
								if (tvTeamIndex != null) {
									int teamIndex = 0;
									{
										LobbyTeam lobbyTeam = lobbyPlayer.findDataInParent<LobbyTeam> ();
										if (lobbyTeam != null) {
											teamIndex = lobbyTeam.teamIndex.v;
										} else {
											Debug.LogError ("lobbyTeam null: " + this);
										}
									}
									tvTeamIndex.text = txtTeamIndex.get("Team Index")+ ": " + teamIndex;
								} else {
									Debug.LogError ("tvTeamIndex null: " + this);
								}
							}
							// tvPlayerIndex
							{
								if (tvPlayerIndex != null) {
									tvPlayerIndex.text = txtPlayerIndex.get ("Player Index") + ": " + lobbyPlayer.playerIndex.v;
								} else {
									Debug.LogError ("tvPlayerIndex null: " + this);
								}
							}
							// informUI
							{
								GamePlayer.Inform inform = lobbyPlayer.inform.v;
								if (inform != null) {
									switch (inform.getType ()) {
									case GamePlayer.Inform.Type.None:
										{
											EmptyInform emptyInform = inform as EmptyInform;
											// UIData
											EmptyInformUI.UIData emptyInformUIData = this.data.informUI.newOrOld<EmptyInformUI.UIData> ();
											{
												emptyInformUIData.editEmptyInform.v.origin.v = new ReferenceData<EmptyInform> (emptyInform);
												emptyInformUIData.editEmptyInform.v.canEdit.v = false;
											}
											this.data.informUI.v = emptyInformUIData;
										}
										break;
									case GamePlayer.Inform.Type.Human:
										{
											Human human = inform as Human;
											// UIData
											HumanUI.UIData humanUIData = this.data.informUI.newOrOld<HumanUI.UIData>();
											{
												humanUIData.editHuman.v.origin.v = new ReferenceData<Human> (human);
												humanUIData.editHuman.v.canEdit.v = false;
											}
											this.data.informUI.v = humanUIData;
										}
										break;
									case GamePlayer.Inform.Type.Computer:
										{
											Computer computer = inform as Computer;
											// UIData
											ComputerUI.UIData computerUIData = this.data.informUI.newOrOld<ComputerUI.UIData>();
											{
												computerUIData.editComputer.v.origin.v = new ReferenceData<Computer> (computer);
												computerUIData.editComputer.v.canEdit.v = false;
											}
											this.data.informUI.v = computerUIData;
										}
										break;
									default:
										Debug.LogError ("unknown type: " + inform.getType () + "; " + this);
										break;
									}
								} else {
									Debug.LogError ("inform null: " + this);
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
							// sub
							{
								bool canEdit = true;
								{
									ContestManagerStateLobby contestManagerStateLobby = lobbyPlayer.findDataInParent<ContestManagerStateLobby> ();
									if (contestManagerStateLobby != null) {
										if (!(contestManagerStateLobby.state.v is Lobby.StateNormal)) {
											canEdit = false;
										}
									} else {
										Debug.LogError ("contestManagerStateLobby null: " + this);
									}
								}
								// Process
								if (canEdit) {
									if (Room.isYouAdmin (lobbyPlayer)) {
										// editContainer
										{
											if (editContainer != null) {
												editContainer.gameObject.SetActive (true);
											} else {
												Debug.LogError ("editContainer null: " + this);
											}
										}
										// UIData
										AdminEditLobbyPlayerUI.UIData adminEditLobbyPlayerUIData = this.data.sub.newOrOld<AdminEditLobbyPlayerUI.UIData> ();
										{
											adminEditLobbyPlayerUIData.lobbyPlayer.v = new ReferenceData<LobbyPlayer> (lobbyPlayer);
										}
										this.data.sub.v = adminEditLobbyPlayerUIData;
									} else {
										// editContainer
										{
											if (editContainer != null) {
												editContainer.gameObject.SetActive (true);
											} else {
												Debug.LogError ("editContainer null: " + this);
											}
										}
										// UIData
										NormalEditLobbyPlayerUI.UIData normalEditLobbyPlayerUIData = this.data.sub.newOrOld<NormalEditLobbyPlayerUI.UIData> ();
										{
											normalEditLobbyPlayerUIData.lobbyPlayer.v = new ReferenceData<LobbyPlayer> (lobbyPlayer);
										}
										this.data.sub.v = normalEditLobbyPlayerUIData;
									}
								} else {
									// editContainer
									{
										if (editContainer != null) {
											editContainer.gameObject.SetActive (false);
										} else {
											Debug.LogError ("editContainer null: " + this);
										}
									}
								}
							}
						} else {
							Debug.LogError ("data parent null: " + this);
						}
					} else {
						Debug.LogError ("lobbyPlayer null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Edit Lobby Player");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (tvBack != null) {
							tvBack.text = txtBack.get ("Back");
						} else {
							Debug.LogError ("tvBack null: " + this);
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

		public EmptyInformUI emptyPrefab;
		public HumanUI humanPrefab;
		public ComputerUI computerPrefab;
		public Transform informContainer;

		public LobbyPlayerBtnSetReady btnReadyPrefab;
		public Transform btnReadyContainer;

		public AdminEditLobbyPlayerUI adminEditPrefab;
		public NormalEditLobbyPlayerUI normalEditPrefab;
		public Transform editContainer;

		private RoomCheckChangeAdminChange<LobbyPlayer> roomCheckAdminChange = new RoomCheckChangeAdminChange<LobbyPlayer>();

		private LobbyTeam lobbyTeam = null;
		private ContestManagerStateLobby contestManagerStateLobby = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.lobbyPlayer.allAddCallBack (this);
					uiData.informUI.allAddCallBack (this);
					uiData.btnReady.allAddCallBack (this);
					uiData.sub.allAddCallBack (this);
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
						// CheckChange
						{
							roomCheckAdminChange.addCallBack (this);
							roomCheckAdminChange.setData (lobbyPlayer);
						}
						// Parent
						{
							DataUtils.addParentCallBack (lobbyPlayer, this, ref this.lobbyTeam);
							DataUtils.addParentCallBack (lobbyPlayer, this, ref this.contestManagerStateLobby);
						}
						dirty = true;
						return;
					}
					// CheckChange
					if (data is RoomCheckChangeAdminChange<LobbyPlayer>) {
						dirty = true;
						return;
					}
					// Parent
					{
						if (data is LobbyTeam) {
							dirty = true;
							return;
						}
						if (data is ContestManagerStateLobby) {
							dirty = true;
							return;
						}
					}
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
				if (data is InformUI) {
					InformUI editInformUI = data as InformUI;
					// UI
					{
						switch (editInformUI.getType ()) {
						case GamePlayer.Inform.Type.None:
							{
								EmptyInformUI.UIData emptyInformUIData = editInformUI as EmptyInformUI.UIData;
								UIUtils.Instantiate (emptyInformUIData, emptyPrefab, informContainer);
							}
							break;
						case GamePlayer.Inform.Type.Human:
							{
								HumanUI.UIData humanUIData = editInformUI as HumanUI.UIData;
								UIUtils.Instantiate (humanUIData, humanPrefab, informContainer);
							}
							break;
						case GamePlayer.Inform.Type.Computer:
							{
								ComputerUI.UIData editComputerUIData = editInformUI as ComputerUI.UIData;
								UIUtils.Instantiate (editComputerUIData, computerPrefab, informContainer);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + editInformUI.getType () + "; " + this);
							break;
						}
					}
					dirty = true;
					return;
				}
				if (data is UIData.Sub) {
					UIData.Sub sub = data as UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case RoomUser.Role.ADMIN:
							{
								AdminEditLobbyPlayerUI.UIData adminEdit = sub as AdminEditLobbyPlayerUI.UIData;
								UIUtils.Instantiate (adminEdit, adminEditPrefab, editContainer);
							}
							break;
						case RoomUser.Role.NORMAL:
							{
								NormalEditLobbyPlayerUI.UIData normalEdit = sub as NormalEditLobbyPlayerUI.UIData;
								UIUtils.Instantiate (normalEdit, normalEditPrefab, editContainer);
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
				// Setting
				Setting.get().removeCallBack(this);
				// Child
				{
					uiData.lobbyPlayer.allRemoveCallBack (this);
					uiData.informUI.allRemoveCallBack (this);
					uiData.btnReady.allRemoveCallBack (this);
					uiData.sub.allRemoveCallBack (this);
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
						// CheckChange
						{
							roomCheckAdminChange.removeCallBack (this);
							roomCheckAdminChange.setData (null);
						}
						// Parent
						{
							DataUtils.removeParentCallBack (lobbyPlayer, this, ref this.lobbyTeam);
							DataUtils.removeParentCallBack (lobbyPlayer, this, ref this.contestManagerStateLobby);
						}
						return;
					}
					// CheckChange
					if (data is RoomCheckChangeAdminChange<LobbyPlayer>) {
						return;
					}
					// Parent
					{
						if (data is LobbyTeam) {
							return;
						}
						if (data is ContestManagerStateLobby) {
							return;
						}
					}
				}
				if (data is InformUI) {
					InformUI editInformUI = data as InformUI;
					// UI
					{
						switch (editInformUI.getType ()) {
						case GamePlayer.Inform.Type.None:
							{
								EmptyInformUI.UIData emptyInformUIData = editInformUI as EmptyInformUI.UIData;
								emptyInformUIData.removeCallBackAndDestroy (typeof(EmptyInformUI));
							}
							break;
						case GamePlayer.Inform.Type.Human:
							{
								HumanUI.UIData humanUIData = editInformUI as HumanUI.UIData;
								humanUIData.removeCallBackAndDestroy (typeof(HumanUI));
							}
							break;
						case GamePlayer.Inform.Type.Computer:
							{
								ComputerUI.UIData editComputerUIData = editInformUI as ComputerUI.UIData;
								editComputerUIData.removeCallBackAndDestroy (typeof(ComputerUI));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + editInformUI.getType () + "; " + this);
							break;
						}
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
				if (data is UIData.Sub) {
					UIData.Sub sub = data as UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case RoomUser.Role.ADMIN:
							{
								AdminEditLobbyPlayerUI.UIData adminEdit = sub as AdminEditLobbyPlayerUI.UIData;
								adminEdit.removeCallBackAndDestroy (typeof(AdminEditLobbyPlayerUI));
							}
							break;
						case RoomUser.Role.NORMAL:
							{
								NormalEditLobbyPlayerUI.UIData normalEdit = sub as NormalEditLobbyPlayerUI.UIData;
								normalEdit.removeCallBackAndDestroy (typeof(NormalEditLobbyPlayerUI));
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
				case UIData.Property.lobbyPlayer:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.informUI:
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
				case UIData.Property.sub:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("Don't prococess: " + wrapProperty + "; " + this);
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
							dirty = true;
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
					// Parent
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
						if (wrapProperty.p is ContestManagerStateLobby) {
							switch ((ContestManagerStateLobby.Property)wrapProperty.n) {
							case ContestManagerStateLobby.Property.state:
								dirty = true;
								break;
							case ContestManagerStateLobby.Property.teams:
								break;
							case ContestManagerStateLobby.Property.gameType:
								break;
							case ContestManagerStateLobby.Property.randomTeamIndex:
								break;
							case ContestManagerStateLobby.Property.contentFactory:
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
					}
				}
				if (wrapProperty.p is InformUI) {
					return;
				}
				if (wrapProperty.p is LobbyPlayerBtnSetReady.UIData) {
					return;
				}
				if (wrapProperty.p is UIData.Sub) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnBack()
		{
			if (this.data != null) {
				ContestManagerStateLobbyUI.UIData contestManagerStateLobbyUIData = this.data.findDataInParent<ContestManagerStateLobbyUI.UIData> ();
				if (contestManagerStateLobbyUIData != null) {
					contestManagerStateLobbyUIData.editLobbyPlayer.v = null;
				} else {
					Debug.LogError ("contestManagerStateLobbyUIData null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}
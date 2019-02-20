using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

namespace GameManager.Match
{
	public class LobbyPlayerBtnSetReady : UIBehavior<LobbyPlayerBtnSetReady.UIData>
	{

		#region UIData 

		public class UIData : Data
		{

			public VP<ReferenceData<LobbyPlayer>> lobbyPlayer;

			#region State

			public enum State
			{
				None,
				Request,
				Wait
			}

			public VP<State> state;

			#endregion

			#region Constructor

			public enum Property
			{
				lobbyPlayer,
				state
			}

			public UIData() : base()
			{
				this.lobbyPlayer = new VP<ReferenceData<LobbyPlayer>>(this, (byte)Property.lobbyPlayer, new ReferenceData<LobbyPlayer>(null));
				this.state = new VP<State>(this, (byte)Property.state, State.None);
			}

			#endregion

			public void reset()
			{
				this.state.v = State.None;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public static readonly TxtLanguage txtReady = new TxtLanguage ();
		public static readonly TxtLanguage txtCancelNotReady = new TxtLanguage();
		public static readonly TxtLanguage txtNotReadying = new TxtLanguage ();

		public static readonly TxtLanguage txtNoReady = new TxtLanguage();
		public static readonly TxtLanguage txtCancelReady = new TxtLanguage ();
		public static readonly TxtLanguage txtReadying = new TxtLanguage();

		static LobbyPlayerBtnSetReady()
		{
			txtReady.add(Language.Type.vi, "Sẵn sàng");
			txtCancelNotReady.add (Language.Type.vi, "Huỷ không sẵn sàng");
			txtNotReadying.add(Language.Type.vi, "Đang không sẵn sàng");

			txtNoReady.add(Language.Type.vi, "Không sẵn sàng");
			txtCancelReady.add(Language.Type.vi, "Huỷ sẵn sàng");
			txtReadying.add(Language.Type.vi, "Đang sẵn sàng");
		}

		#endregion

		public GameObject contentContainer;
		public GameObject clickDisable;

		public Button btnReady;
		public Text tvReady;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					LobbyPlayer lobbyPlayer = this.data.lobbyPlayer.v.data;
					if (lobbyPlayer != null) {
						if (lobbyPlayer.isNeedSetReady ()) {
							// conentContainer
							{
								if (contentContainer != null) {
									contentContainer.SetActive (true);
								} else {
									Debug.LogError ("contentContainer null: " + this);
								}
							}
							// check is your player
							bool isYourPlayer = false;
							uint profileId = Server.getProfileUserId (lobbyPlayer);
							{
								if (lobbyPlayer.inform.v is Human) {
									Human human = lobbyPlayer.inform.v as Human;
									if (human.playerId.v == profileId) {
										isYourPlayer = true;
									}
								}
							}
							// Task
							{
								if (isYourPlayer) {
									bool isCanStart = false;
									{
										ContestManagerStateLobby contestManagerStateLobby = lobbyPlayer.findDataInParent<ContestManagerStateLobby> ();
										if (contestManagerStateLobby != null) {
											if (contestManagerStateLobby.state.v.getType () == ContestManagerStateLobby.State.Type.Normal) {
												isCanStart = true;
											}
										} else {
											Debug.LogError ("contestManagerStateLobby null: " + this);
										}
									}
									// UI
									{
										if (clickDisable != null) {
											clickDisable.SetActive (!isCanStart);
										} else {
											Debug.LogError ("clickDisable null: " + this);
										}
									}
									if (isCanStart) {
										switch (this.data.state.v) {
										case UIData.State.None:
											{
												destroyRoutine (wait);
											}
											break;
										case UIData.State.Request:
											{
												destroyRoutine (wait);
												if (Server.IsServerOnline (lobbyPlayer)) {
													lobbyPlayer.requestSetReady (profileId, !lobbyPlayer.isReady.v);
												} else {
													Debug.LogError ("server not online: " + this);
												}
											}
											break;
										case UIData.State.Wait:
											{
												if (Server.IsServerOnline (lobbyPlayer)) {
													startRoutine (ref this.wait, TaskWait ());
												} else {
													this.data.state.v = UIData.State.None;
												}
											}
											break;
										default:
											Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
											break;
										}
									} else {
										this.data.state.v = UIData.State.None;
										destroyRoutine (wait);
									}
								} else {
									// Task
									{
										this.data.state.v = UIData.State.None;
										destroyRoutine (wait);
									}
									// UI
									{
										if (clickDisable != null) {
											clickDisable.SetActive (true);
										} else {
											Debug.LogError ("clickDisable null: " + this);
										}
									}
								}
							}
							// UI
							{
								if (btnReady != null && tvReady != null) {
									switch (this.data.state.v) {
									case UIData.State.None:
										{
											btnReady.enabled = true;
											tvReady.text = lobbyPlayer.isReady.v ? txtReady.get("Ready") : txtNoReady.get("Not Ready");
										}
										break;
									case UIData.State.Request:
										{
											btnReady.enabled = true;
											tvReady.text = lobbyPlayer.isReady.v ? txtCancelNotReady.get("Cancel Not Readying?") : txtCancelReady.get("Cancel Readying?");
										}
										break;
									case UIData.State.Wait:
										{
											btnReady.enabled = false;
											tvReady.text = lobbyPlayer.isReady.v ? txtNotReadying.get ("NotReadying") : txtReadying.get ("Readying");
										}
										break;
									default:
										Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
										break;
									}
								} else {
									Debug.LogError ("btnReady, tvReady null: " + this);
								}
							}
						} else {
							// conentContainer
							{
								if (contentContainer != null) {
									contentContainer.SetActive (false);
								} else {
									Debug.LogError ("contentContainer null: " + this);
								}
							}
							// Task
							{
								this.data.state.v = UIData.State.None;
								destroyRoutine (wait);
							}
						}
					} else {
						// Debug.LogError ("lobbyPlayer null: " + this);
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

		#region Task wait

		private Routine wait;

		public IEnumerator TaskWait()
		{
			if (this.data != null) {
				yield return new Wait (Global.WaitSendTime);
				// Chuyen sang state none
				{
					if (this.data != null) {
						this.data.state.v = UIData.State.None;
					} else {
						Debug.LogError ("data null: " + this);
					}
				}
				Toast.showMessage ("request error");
				Debug.LogError ("request error: " + this);
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public override List<Routine> getRoutineList ()
		{
			List<Routine> ret = new List<Routine> ();
			{
				ret.Add (wait);
			}
			return ret;
		}

		#endregion

		#region implement callBacks

		private ContestManagerStateLobby contestManagerStateLobby = null;
		private Server server = null;

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
					// CheckChange
					{
						roomCheckAdminChange.addCallBack (this);
						roomCheckAdminChange.setData (lobbyPlayer);
					}
					// Parent
					{
						DataUtils.addParentCallBack (lobbyPlayer, this, ref this.server);
						DataUtils.addParentCallBack (lobbyPlayer, this, ref this.contestManagerStateLobby);
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
				// Parent
				{
					if (data is Server) {
						dirty = true;
						return;
					}
					if (data is ContestManagerStateLobby) {
						dirty = true;
						return;
					}
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
					// Parent
					{
						DataUtils.removeParentCallBack (lobbyPlayer, this, ref this.server);
						DataUtils.removeParentCallBack (lobbyPlayer, this, ref this.contestManagerStateLobby);
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
				// Parent
				{
					if (data is Server) {
						return;
					}
					if (data is ContestManagerStateLobby) {
						return;
					}
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
				case UIData.Property.state:
					dirty = true;
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
							if (this.data != null) {
								this.data.reset ();
							} else {
								Debug.LogError ("data null: " + this);
							}
						}
						break;
					case LobbyPlayer.Property.isReady:
						{
							dirty = true;
							if (this.data != null) {
								this.data.reset ();
							} else {
								Debug.LogError ("data null: " + this);
							}
						}
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
					if (wrapProperty.p is Server) {
						Server.State.OnUpdateSyncStateChange (wrapProperty, this);
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
				// Child
				if (wrapProperty.p is GamePlayer.Inform) {
					if (wrapProperty.p is Human) {
						switch ((Human.Property)wrapProperty.n) {
						case Human.Property.playerId:
							{
								dirty = true;
								// reset
								{
									if (this.data != null) {
										this.data.reset ();
									} else {
										Debug.LogError ("data null: " + this);
									}
								}
							}
							break;
						case Human.Property.account:
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
						return;
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnReady()
		{
			if (this.data != null) {
				switch (this.data.state.v) {
				case UIData.State.None:
					this.data.state.v = UIData.State.Request;
					break;
				case UIData.State.Request:
					this.data.state.v = UIData.State.None;
					break;
				case UIData.State.Wait:
					Debug.LogError ("you are requesting: " + this);
					break;
				default:
					Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
					break;
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}
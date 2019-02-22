using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

namespace GameState
{
	public class PlayPauseUI : UIBehavior<PlayPauseUI.UIData>
	{

		#region UIData

		public class UIData : PlayUI.UIData.Sub
		{

			public VP<ReferenceData<PlayPause>> playPause;

			public VP<AccountAvatarUI.UIData> accountAvatar;

			#region State

			public enum State
			{
				Normal,
				Request,
				Wait
			}

			public VP<State> state;

			#endregion

			#region Constructor

			public enum Property
			{
				playPause,
				accountAvatar,
				state
			}

			public UIData() : base()
			{
				this.playPause = new VP<ReferenceData<PlayPause>>(this, (byte)Property.playPause, new ReferenceData<PlayPause>(null));
				this.accountAvatar = new VP<AccountAvatarUI.UIData>(this, (byte)Property.accountAvatar, new AccountAvatarUI.UIData());
				this.state = new VP<State>(this, (byte)Property.state, State.Normal);
			}

			#endregion

			public override Play.Sub.Type getType ()
			{
				return Play.Sub.Type.Pause;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public static readonly TxtLanguage txtUnpause = new TxtLanguage();
		public static readonly TxtLanguage txtCancelUnpause = new TxtLanguage ();
		public static readonly TxtLanguage txtUnpausing = new TxtLanguage();
		public static readonly TxtLanguage txtCannotUnpause = new TxtLanguage();

		static PlayPauseUI()
		{
			txtUnpause.add (Language.Type.vi, "Tiếp Tục Lại");
			txtCancelUnpause.add (Language.Type.vi, "Huỷ tiếp tục lại?");
			txtUnpausing.add (Language.Type.vi, "Đang tiếp tục lại...");
			txtCannotUnpause.add (Language.Type.vi, "Không thể tiếp tục lại");
		}

		#endregion

		public Text tvName;

		public Button btnUnPause;
		public Text tvUnPause;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					PlayPause playPause = this.data.playPause.v.data;
					if (playPause != null) {
						// inform
						{
							Human human = playPause.human.v;
							// accountAvatar
							{
								AccountAvatarUI.UIData accountAvatarUIData = this.data.accountAvatar.v;
								if (accountAvatarUIData != null) {
									// Find account
									Account account = null;
									{
										if (human != null) {
											account = human.account.v;
										} else {
											Debug.LogError ("human null: " + this);
										}
									}
									// Process
									accountAvatarUIData.account.v = new ReferenceData<Account> (account);
								} else {
									Debug.LogError ("accountAvatarUIData null: " + this);
								}
							}
							// name
							if (tvName != null) {
								string name = "";
								{
									if (human != null) {
										if (human.account.v != null) {
											name = human.account.v.getName ();
										} else {
											Debug.LogError ("account null: " + this);
										}
									} else {
										Debug.LogError ("human null: " + this);
									}
								}
								tvName.text = name;
							} else {
								Debug.LogError ("tvName null: " + this);
							}
						}
						// UnPause
						{
							if (Play.IsCanChange (playPause, Server.getProfileUserId (playPause))) {
								// Task
								{
									switch (this.data.state.v) {
									case UIData.State.Normal:
										{
											destroyRoutine (wait);
										}
										break;
									case UIData.State.Request:
										{
											destroyRoutine (wait);
											if (Server.IsServerOnline (playPause)) {
												playPause.requestUnPause (Server.getProfileUserId (playPause));
												this.data.state.v = UIData.State.Wait;
											} else {
												Debug.LogError ("server offline: " + this);
											}
										}
										break;
									case UIData.State.Wait:
										{
											if (Server.IsServerOnline (playPause)) {
												if (Routine.IsNull (wait)) {
													wait = CoroutineManager.StartCoroutine (TaskWait (), this.gameObject);
												} else {
													Debug.LogError ("Why routine != null: " + this);
												}
											} else {
												this.data.state.v = UIData.State.Normal;
											}
										}
										break;
									default:
										Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
										break;
									}
								}
								// UI
								{
									if (btnUnPause != null && tvUnPause != null) {
										switch (this.data.state.v) {
										case UIData.State.Normal:
											{
												btnUnPause.interactable = true;
												tvUnPause.text = txtUnpause.get("Unpause");
											}
											break;
										case UIData.State.Request:
											{
												btnUnPause.interactable = true;
												tvUnPause.text = txtCancelUnpause.get ("Cancel unpause?");
											}
											break;
										case UIData.State.Wait:
											{
												btnUnPause.interactable = false;
												tvUnPause.text = txtUnpausing.get ("Unpausing");
											}
											break;
										default:
											Debug.LogError ("Unknown state: " + this.data.state.v + "; " + this);
											break;
										}
									} else {
										Debug.LogError ("btnUnPause, tvUnPause null: " + this);
									}
								}
							} else {
								// Task
								{
									this.data.state.v = UIData.State.Normal;
									destroyRoutine (wait);
								}
								// UI
								{
									if (btnUnPause != null && tvUnPause != null) {
										btnUnPause.interactable = false;
										tvUnPause.text = txtCannotUnpause.get ("Cannot unpause");
									} else {
										Debug.LogError ("btnUnPause, tvUnPause null: " + this);
									}
								}
							}
						}
					} else {
						Debug.LogError ("playPause null: " + this);
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
				if (this.data != null) {
					this.data.state.v = UIData.State.Normal;
				} else {
					Debug.LogError ("data null: " + this);
				}
				Debug.LogError ("error, why cannot request: " + this);
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

		private GameCheckPlayerChange<PlayPause> gamePlayerCheckChange = new GameCheckPlayerChange<PlayPause> ();
		private RoomCheckChangeAdminChange<PlayPause> roomCheckAdminChange = new RoomCheckChangeAdminChange<PlayPause> ();
		private Server server = null;

		public AccountAvatarUI accountAvatarPrefab;
		public Transform accountAvatarContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.playPause.allAddCallBack (this);
					uiData.accountAvatar.allAddCallBack (this);
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
				// PlayPause
				{
					if (data is PlayPause) {
						PlayPause playPause = data as PlayPause;
						// Reset
						{
							if (this.data != null) {
								this.data.state.v = UIData.State.Normal;
							} else {
								Debug.LogError ("data null: " + this);
							}
						}
						// CheckChange
						{
							// gamePlayer
							{
								gamePlayerCheckChange.addCallBack (this);
								gamePlayerCheckChange.setData (playPause);
							}
							// roomAdmin
							{
								roomCheckAdminChange.addCallBack (this);
								roomCheckAdminChange.setData (playPause);
							}
						}
						// Parent
						{
							DataUtils.addParentCallBack (playPause, this, ref this.server);
						}
						// Child
						{
							playPause.human.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// CheckChange
					{
						if (data is GameCheckPlayerChange<PlayPause>) {
							dirty = true;
							return;
						}
						if (data is RoomCheckChangeAdminChange<PlayPause>) {
							dirty = true;
							return;
						}
					}
					// Parent
					if (data is Server) {
						dirty = true;
						return;
					}
					// Child
					{
						if (data is Human) {
							Human human = data as Human;
							// Child
							{
								human.account.allAddCallBack (this);
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
				if (data is AccountAvatarUI.UIData) {
					AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
					// UI
					{
						UIUtils.Instantiate (accountAvatarUIData, accountAvatarPrefab, accountAvatarContainer);
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
					uiData.playPause.allRemoveCallBack (this);
					uiData.accountAvatar.allRemoveCallBack (this);
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
				// PlayPause
				{
					if (data is PlayPause) {
						PlayPause playPause = data as PlayPause;
						// CheckChange
						{
							// gamePlayer
							{
								gamePlayerCheckChange.removeCallBack (this);
								gamePlayerCheckChange.setData (null);
							}
							// roomAdmin
							{
								roomCheckAdminChange.removeCallBack (this);
								roomCheckAdminChange.setData (null);
							}
						}
						// Parent
						{
							DataUtils.removeParentCallBack (playPause, this, ref this.server);
						}
						// Child
						{
							playPause.human.allRemoveCallBack (this);
						}
						return;
					}
					// CheckChange
					{
						if (data is GameCheckPlayerChange<PlayPause>) {
							return;
						}
						if (data is RoomCheckChangeAdminChange<PlayPause>) {
							return;
						}
					}
					// Parent
					if (data is Server) {
						return;
					}
					// Child
					{
						if (data is Human) {
							Human human = data as Human;
							// Child
							{
								human.account.allRemoveCallBack (this);
							}
							return;
						}
						// Child
						if (data is Account) {
							return;
						}
					}
				}
				if (data is AccountAvatarUI.UIData) {
					AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
					// UI
					{
						accountAvatarUIData.removeCallBackAndDestroy (typeof(AccountAvatarUI));
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
				case UIData.Property.playPause:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.accountAvatar:
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
				// PlayPause
				{
					if (wrapProperty.p is PlayPause) {
						switch ((PlayPause.Property)wrapProperty.n) {
						case PlayPause.Property.human:
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
					// CheckChange
					{
						if (wrapProperty.p is GameCheckPlayerChange<PlayPause>) {
							dirty = true;
							return;
						}
						if (wrapProperty.p is RoomCheckChangeAdminChange<PlayPause>) {
							dirty = true;
							return;
						}
					}
					// Parent
					if (wrapProperty.p is Server) {
						Server.State.OnUpdateSyncStateChange (wrapProperty, this);
						return;
					}
					// Child
					{
						if (wrapProperty.p is Human) {
							switch ((Human.Property)wrapProperty.n) {
							case Human.Property.playerId:
								break;
							case Human.Property.account:
								{
									ValueChangeUtils.replaceCallBack (this, syncs);
									dirty = true;
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
							return;
						}
						// Child
						if (wrapProperty.p is Account) {
							Account.OnUpdateSyncAccount (wrapProperty, this);
							return;
						}
					}
				}
				if (wrapProperty.p is AccountAvatarUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnUnPause()
		{
			if (this.data != null) {
				if (this.data.state.v == UIData.State.Normal) {
					this.data.state.v = UIData.State.Request;
				} else if (this.data.state.v == UIData.State.Request) {
					this.data.state.v = UIData.State.Normal;
				} else {
					Debug.LogError ("you are requesting: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}
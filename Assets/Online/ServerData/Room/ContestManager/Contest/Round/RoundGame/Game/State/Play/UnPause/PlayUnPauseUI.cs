using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class PlayUnPauseUI : UIBehavior<PlayUnPauseUI.UIData>
	{

		#region UIData

		public class UIData : PlayUI.UIData.Sub
		{

			public VP<ReferenceData<PlayUnPause>> playUnPause;

			public VP<AccountAvatarUI.UIData> accountAvatar;

			#region Constructor

			public enum Property
			{
				playUnPause,
				accountAvatar
			}

			public UIData() : base()
			{
				this.playUnPause = new VP<ReferenceData<PlayUnPause>>(this, (byte)Property.playUnPause, new ReferenceData<PlayUnPause>(null));
				this.accountAvatar = new VP<AccountAvatarUI.UIData>(this, (byte)Property.accountAvatar, new AccountAvatarUI.UIData());
			}

			#endregion

			public override Play.Sub.Type getType ()
			{
				return Play.Sub.Type.UnPause;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage ();

		public static readonly TxtLanguage txtName = new TxtLanguage();
		public static readonly TxtLanguage txtTime = new TxtLanguage();

		static PlayUnPauseUI()
		{
            // txt
            {
                txtTitle.add(Language.Type.vi, "Tiếp Tục Lại");
                txtName.add(Language.Type.vi, "Tên");
                txtTime.add(Language.Type.vi, "Thời gian");
            }
            // rect
            {
                // accountAvatarRect
                {
                    // anchoredPosition: (0.0, -40.0); anchorMin: (0.5, 1.0); anchorMax: (0.5, 1.0); pivot: (0.5, 1.0);
                    // offsetMin: (-30.0, -100.0); offsetMax: (30.0, -40.0); sizeDelta: (60.0, 60.0);
                    accountAvatarRect.anchoredPosition = new Vector3(0.0f, -40.0f, 0.0f);
                    accountAvatarRect.anchorMin = new Vector2(0.5f, 1.0f);
                    accountAvatarRect.anchorMax = new Vector2(0.5f, 1.0f);
                    accountAvatarRect.pivot = new Vector2(0.5f, 1.0f);
                    accountAvatarRect.offsetMin = new Vector2(-30.0f, -100.0f);
                    accountAvatarRect.offsetMax = new Vector2(30.0f, -40.0f);
                    accountAvatarRect.sizeDelta = new Vector2(60.0f, 60.0f);
                }
            }
        }

		#endregion

		public Text tvName;
		public Text tvTime;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					PlayUnPause playUnPause = this.data.playUnPause.v.data;
					if (playUnPause != null) {
						Human human = playUnPause.human.v;
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
								accountAvatarUIData.account.v = new ReferenceData<Account> (account);
							} else {
								Debug.LogError ("accountAvatarUIData null: " + this);
							}
						}
						// tvName
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
						// tvTime
						if (tvTime != null) {
                            tvTime.text = txtTime.get("Time") + ": " + Mathf.Min(playUnPause.time.v, playUnPause.duration.v) + "/" + playUnPause.duration.v;
						} else {
							Debug.LogError ("tvTime null: " + this);
						}
					} else {
						Debug.LogError ("playUnPause null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Unpause");
						} else {
							Debug.LogError ("lbTitle null: " + this);
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

		public AccountAvatarUI accountAvatarPrefab;
        private static readonly UIRectTransform accountAvatarRect = new UIRectTransform();

        public Transform contentContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.playUnPause.allAddCallBack (this);
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
				// PlayUnPause
				{
					if (data is PlayUnPause) {
						PlayUnPause playUnPause = data as PlayUnPause;
						// Child
						{
							playUnPause.human.allAddCallBack (this);
						}
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
                        UIUtils.Instantiate(accountAvatarUIData, accountAvatarPrefab, contentContainer, accountAvatarRect);
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
					uiData.playUnPause.allRemoveCallBack (this);
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
				// PlayUnPause
				{
					if (data is PlayUnPause) {
						PlayUnPause playUnPause = data as PlayUnPause;
						// Child
						{
							playUnPause.human.allRemoveCallBack (this);
						}
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
				case UIData.Property.playUnPause:
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
				// PlayUnPause
				{
					if (wrapProperty.p is PlayUnPause) {
						switch ((PlayUnPause.Property)wrapProperty.n) {
						case PlayUnPause.Property.human:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case PlayUnPause.Property.time:
							dirty = true;
							break;
						case PlayUnPause.Property.duration:
							dirty = true;
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
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

	}
}
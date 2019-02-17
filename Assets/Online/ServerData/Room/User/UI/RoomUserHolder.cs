using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using UnityEngine.UI;
using Foundation.Tasks;
using AdvancedCoroutines;

public class RoomUserHolder : SriaHolderBehavior<RoomUserHolder.UIData>
{

	#region UIData

	public class UIData : BaseItemViewsHolder
	{

		public VP<ReferenceData<RoomUser>> roomUser;

		public VP<AccountAvatarUI.UIData> avatar;

		#region Constructor

		public enum Property
		{
			roomUser,
			avatar
		}

		public UIData() : base()
		{
			this.roomUser = new VP<ReferenceData<RoomUser>>(this, (byte)Property.roomUser, new ReferenceData<RoomUser>(null));
			this.avatar = new VP<AccountAvatarUI.UIData>(this, (byte)Property.avatar, new AccountAvatarUI.UIData());
		}

		#endregion

		public void updateView(RoomUserAdapter.UIData myParams)
		{
			// Find RoomUser
			RoomUser roomUser = null;
			{
				if (ItemIndex >= 0 && ItemIndex < myParams.roomUsers.Count) {
					roomUser = myParams.roomUsers [ItemIndex];
				} else {
					Debug.LogError ("ItemIndex error: " + this);
				}
			}
			// Update
			this.roomUser.v = new ReferenceData<RoomUser> (roomUser);
		}

	}

    #endregion

    #region txt, rect

    static RoomUserHolder()
    {
        // avatarRect
        {
            // anchoredPosition: (5.0, 0.0); anchorMin: (0.0, 0.5); anchorMax: (0.0, 0.5); pivot: (0.0, 0.5);
            // offsetMin: (5.0, -18.0); offsetMax: (41.0, 18.0); sizeDelta: (36.0, 36.0);
            avatarRect.anchoredPosition = new Vector3(0.5f, 0.0f, 0.0f);
            avatarRect.anchorMin = new Vector2(0.0f, 0.5f);
            avatarRect.anchorMax = new Vector2(0.0f, 0.5f);
            avatarRect.pivot = new Vector2(0.0f, 0.5f);
            avatarRect.offsetMin = new Vector2(5.0f, -18.0f);
            avatarRect.offsetMax = new Vector2(41.0f, 18.0f);
            avatarRect.sizeDelta = new Vector2(36.0f, 36.0f);
        }
    }

    #endregion

    #region Refresh

    private static readonly Color AdminColor = Color.blue;
    private static readonly Color NormalColor = new Color(50 / 255f, 50 / 255f, 50 / 255f);
    private static readonly Color KickColor = Color.red;

    private const float LeftAlpha = 0.6f;

    public Text tvName;
	public override void refresh ()
	{
		base.refresh();
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				RoomUser roomUser = this.data.roomUser.v.data;
				if (roomUser != null) {
					// avatar
					{
						AccountAvatarUI.UIData avatarUIData = this.data.avatar.v;
						if (avatarUIData != null) {
							// Find account
							Account account = null;
							{
								Human human = roomUser.inform.v;
								if (human != null) {
									account = human.account.v;
								} else {
									Debug.LogError ("human null: " + this);
								}
							}
							avatarUIData.account.v = new ReferenceData<Account> (account);
						} else {
							Debug.LogError ("avatarUIData null: " + this);
						}
                        // siblingIndex
                        UIRectTransform.SetSiblingIndex(this.data.avatar.v, 0);
					}
					// name
					if (tvName != null) {
						string strName = "";
						{
							Human human = roomUser.inform.v;
							if (human != null) {
								strName = human.getPlayerName ();
							} else {
								Debug.LogError ("human null: " + this);
							}
						}
						tvName.text = strName;
                        // color
                        {
                            // find color
                            Color color = NormalColor;
                            float alpha = 1.0f;
                            {
                                switch (roomUser.role.v)
                                {
                                    case RoomUser.Role.ADMIN:
                                        {
                                            color = AdminColor;
                                            if(roomUser.state.v== RoomUser.State.LEFT)
                                            {
                                                alpha = LeftAlpha;
                                            }
                                        }
                                        break;
                                    case RoomUser.Role.NORMAL:
                                        {
                                            color = NormalColor;
                                            switch (roomUser.state.v)
                                            {
                                                case RoomUser.State.NORMAL:
                                                    alpha = 1.0f;
                                                    break;
                                                case RoomUser.State.LEFT:
                                                    alpha = LeftAlpha;
                                                    break;
                                                case RoomUser.State.KICK:
                                                    color = KickColor;
                                                    alpha = 1.0f;
                                                    break;
                                                default:
                                                    Debug.LogError("unknown state: " + roomUser.state.v);
                                                    break;
                                            }
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            // alpha
                            color.a = alpha;
                            // set
                            tvName.color = color;
                        }
                    } else {
						Debug.LogError ("tvName null: " + this);
					}
				} else {
					Debug.LogError ("roomUser null: " + this);
				}
			} else {
				// Debug.LogError ("data null: " + this);
			}
		}
	}

	#endregion

	#region implement callBacks

	public AccountAvatarUI avatarPrefab;
    private static readonly UIRectTransform avatarRect = new UIRectTransform();

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.roomUser.allAddCallBack (this);
				uiData.avatar.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			// RoomUser
			{
				if (data is RoomUser) {
					RoomUser roomUser = data as RoomUser;
					// Child
					{
						roomUser.inform.allAddCallBack (this);
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
					UIUtils.Instantiate (accountAvatarUIData, avatarPrefab, this.transform, avatarRect);
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
				uiData.roomUser.allRemoveCallBack (this);
				uiData.avatar.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			// RoomUser
			{
				if (data is RoomUser) {
					RoomUser roomUser = data as RoomUser;
					// Child
					{
						roomUser.inform.allRemoveCallBack (this);
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
			case UIData.Property.roomUser:
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
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			// RoomUser
			{
				if (wrapProperty.p is RoomUser) {
					switch ((RoomUser.Property)wrapProperty.n) {
					case RoomUser.Property.role:
						dirty = true;
						break;
					case RoomUser.Property.inform:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case RoomUser.Property.state:
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
		Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
	}

	#endregion

	public void onClickBtnShow()
	{
		if (this.data != null) {
			RoomUser roomUser = this.data.roomUser.v.data;
			if (roomUser != null) {
				RoomUI.UIData roomUIData = this.data.findDataInParent<RoomUI.UIData> ();
				if (roomUIData != null) {
					// make UI
					RoomUserInformUI.UIData roomUserInformUIData = roomUIData.roomUserInformUI.newOrOld<RoomUserInformUI.UIData> ();
					{
						roomUserInformUIData.roomUser.v = new ReferenceData<RoomUser> (roomUser);
					}
					roomUIData.roomUserInformUI.v = roomUserInformUIData;
				} else {
					Debug.LogError ("roomUIData null: " + this);
				}
			} else {
				Debug.LogError ("roomUser null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}
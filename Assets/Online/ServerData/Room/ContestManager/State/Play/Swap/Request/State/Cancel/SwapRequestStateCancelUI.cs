using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
	public class SwapRequestStateCancelUI : UIBehavior<SwapRequestStateCancelUI.UIData>
	{

		#region UIData

		public class UIData : HaveRequestSwapPlayerUI.UIData.StateUI
		{

			public VP<ReferenceData<SwapRequestStateCancel>> swapRequestStateCancel;

			public VP<AccountAvatarUI.UIData> avatar;

			#region Constructor

			public enum Property
			{
				swapRequestStateCancel,
				avatar
			}

			public UIData() : base()
			{
				this.swapRequestStateCancel = new VP<ReferenceData<SwapRequestStateCancel>>(this, (byte)Property.swapRequestStateCancel, new ReferenceData<SwapRequestStateCancel>(null));
				this.avatar = new VP<AccountAvatarUI.UIData>(this, (byte)Property.avatar, new AccountAvatarUI.UIData());
			}

			#endregion

			public override SwapRequest.State.Type getType ()
			{
				return SwapRequest.State.Type.Cancel;
			}

		}

        #endregion

        #region txt, rect

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Cancel Request Swap");

        static SwapRequestStateCancelUI()
        {
            // txt
            txtTitle.add(Language.Type.vi, "Huỷ Yêu Cầu");
            // rect
            {
                // avatarRect
                {
                    // anchoredPosition: (0.0, 30.0); anchorMin: (0.5, 0.5); anchorMax: (0.5, 0.5); pivot: (0.5, 0.5);
                    // offsetMin: (-25.0, 5.0); offsetMax: (25.0, 55.0); sizeDelta: (50.0, 50.0);
                    avatarRect.anchoredPosition = new Vector3(0.0f, 30.0f);
                    avatarRect.anchorMin = new Vector2(0.5f, 0.5f);
                    avatarRect.anchorMax = new Vector2(0.5f, 0.5f);
                    avatarRect.pivot = new Vector2(0.5f, 0.5f);
                    avatarRect.offsetMin = new Vector2(-25.0f, 5.0f);
                    avatarRect.offsetMax = new Vector2(25.0f, 55.0f);
                    avatarRect.sizeDelta = new Vector2(50.0f, 50.0f);
                }
            }
        }

        #endregion

        #region Refresh

        public Text tvName;
		public Text tvTime;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					SwapRequestStateCancel swapRequestStateCancel = this.data.swapRequestStateCancel.v.data;
					if (swapRequestStateCancel != null) {
						// avatar
						{
							AccountAvatarUI.UIData avatar = this.data.avatar.v;
							if (avatar != null) {
								// find account
								Account account = null;
								{
									Human human = swapRequestStateCancel.whoCancel.v;
									if (human != null) {
										account = human.account.v;
									} else {
										Debug.LogError ("human null: " + this);
									}
								}
								// process
								avatar.account.v = new ReferenceData<Account>(account);
							} else {
								Debug.LogError ("avatar null: " + this);
							}
						}
						// tvName
						{
							if (tvName != null) {
								string name = "";
								{
									Human human = swapRequestStateCancel.whoCancel.v;
									if (human != null) {
										name = human.getPlayerName ();
									} else {
										Debug.LogError ("human null: " + this);
									}
								}
								tvName.text = name + " cancel request";
							} else {
								Debug.LogError ("tvName null: " + this);
							}
						}
						// tvTime
						{
							if (tvTime != null) {
								tvTime.text = swapRequestStateCancel.time.v + "/" + swapRequestStateCancel.duration.v;
							} else {
								Debug.LogError ("tvTime null: " + this);
							}
						}
                        // txt
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.text = txtTitle.get();
                            }
                            else
                            {
                                Debug.LogError("lbTitle null");
                            }
                        }
                    } else {
						Debug.LogError ("swapRequestStateCancel null: " + this);
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

		public AccountAvatarUI avatarPrefab;
        private static readonly UIRectTransform avatarRect = new UIRectTransform();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
				// Child
				{
					uiData.swapRequestStateCancel.allAddCallBack (this);
					uiData.avatar.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
            // Setting
            if(data is Setting)
            {
                dirty = true;
                return;
            }
            // Child
            {
				// swapRequestStateCancel
				{
					if (data is SwapRequestStateCancel) {
						SwapRequestStateCancel swapRequestStateCancel = data as SwapRequestStateCancel;
						// Child
						{
							swapRequestStateCancel.whoCancel.allAddCallBack (this);
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
                // Setting
                Setting.get().removeCallBack(this);
				// Child
				{
					uiData.swapRequestStateCancel.allRemoveCallBack (this);
					uiData.avatar.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
            // Setting
            if(data is Setting)
            {
                return;
            }
            // Child
            {
				// swapRequestStateCancel
				{
					if (data is SwapRequestStateCancel) {
						SwapRequestStateCancel swapRequestStateCancel = data as SwapRequestStateCancel;
						// Child
						{
							swapRequestStateCancel.whoCancel.allRemoveCallBack (this);
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
				case UIData.Property.swapRequestStateCancel:
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
            // Setting
            if(wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
                        dirty = true;
                        break;
                    case Setting.Property.style:
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
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
				// swapRequestStateCancel
				{
					if (wrapProperty.p is SwapRequestStateCancel) {
						switch ((SwapRequestStateCancel.Property)wrapProperty.n) {
						case SwapRequestStateCancel.Property.whoCancel:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case SwapRequestStateCancel.Property.time:
							dirty = true;
							break;
						case SwapRequestStateCancel.Property.duration:
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
									ValueChangeUtils.replaceCallBack(this, syncs);
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
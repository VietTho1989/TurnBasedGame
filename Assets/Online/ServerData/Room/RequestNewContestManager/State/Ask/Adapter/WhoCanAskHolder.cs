using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

namespace GameManager.ContestManager
{
	public class WhoCanAskHolder : SriaHolderBehavior<WhoCanAskHolder.UIData>
	{

		#region UIData

		public class UIData : BaseItemViewsHolder
		{

			public VP<ReferenceData<Human>> human;

			public VP<AccountAvatarUI.UIData> avatar;

			#region Constructor

			public enum Property
			{
				human,
				avatar
			}

			public UIData() : base()
			{
				this.human = new VP<ReferenceData<Human>>(this, (byte)Property.human, new ReferenceData<Human>(null));
				this.avatar = new VP<AccountAvatarUI.UIData>(this, (byte)Property.avatar, new AccountAvatarUI.UIData());
			}

			#endregion

			public void updateView(WhoCanAskAdapter.UIData myParams)
			{
				// Find
				Human human = null;
				{
					if (ItemIndex >= 0 && ItemIndex < myParams.humans.Count) {
						human = myParams.humans [ItemIndex];
					} else {
						Debug.LogError ("ItemIdex error: " + this);
					}
				}
				// Update
				this.human.v = new ReferenceData<Human> (human);
			}

		}

		#endregion

		#region Refresh

		#region txt

		public static readonly TxtLanguage txtName = new TxtLanguage();

		public static readonly TxtLanguage txtAlreadyAccept = new TxtLanguage ();
		public static readonly TxtLanguage txtNotAccept = new TxtLanguage ();

		static WhoCanAskHolder()
		{
			txtName.add (Language.Type.vi, "Tên");
			txtAlreadyAccept.add (Language.Type.vi, "Đã chấp nhận");
			txtNotAccept.add (Language.Type.vi, "Chưa chấp nhận");
		}

		#endregion

		public Text tvName;
		public Text tvAnswer;

		public override void refresh ()
		{
			base.refresh ();
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Human human = this.data.human.v.data;
                    if (human != null)
                    {
                        // tvName
                        {
                            if (tvName != null)
                            {
                                tvName.text = txtName.get("Name") + ": " + human.getPlayerName();
                            }
                            else
                            {
                                Debug.LogError("tvName null: " + this);
                            }
                        }
                        // tvAnswer
                        {
                            if (tvAnswer != null)
                            {
                                bool alreadyAccept = false;
                                {
                                    RequestNewContestManagerStateAsk requestNewContestManagerStateAsk = human.findDataInParent<RequestNewContestManagerStateAsk>();
                                    if (requestNewContestManagerStateAsk != null)
                                    {
                                        alreadyAccept = requestNewContestManagerStateAsk.accepts.vs.Contains(human.playerId.v);
                                    }
                                    else
                                    {
                                        Debug.LogError("requestNewContestManagerStateAsk null: " + this);
                                    }
                                }
                                tvAnswer.text = alreadyAccept ? txtAlreadyAccept.get("Already Accept") : txtNotAccept.get("Not Accept");
                            }
                            else
                            {
                                Debug.LogError("tvAnswer null: " + this);
                            }
                        }
                        // avatar
                        {
                            AccountAvatarUI.UIData avatar = this.data.avatar.v;
                            if (avatar != null)
                            {
                                avatar.account.v = new ReferenceData<Account>(human.account.v);
                            }
                            else
                            {
                                Debug.LogError("avatar null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("human null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
		}

		#endregion

		#region implement callBacks

		public AccountAvatarUI avatarPrefab;
		public Transform avatarContainer;

		private RequestNewContestManagerStateAsk requestNewContestManagerStateAsk = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.human.allAddCallBack (this);
					uiData.avatar.allAddCallBack (this);
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
				// Human
				{
					if (data is Human) {
						Human human = data as Human;
						// Parent
						{
							DataUtils.addParentCallBack (human, this, ref this.requestNewContestManagerStateAsk);
						}
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
				// Parent
				if (data is RequestNewContestManagerStateAsk) {
					dirty = true;
					return;
				}
				// avatar
				if (data is AccountAvatarUI.UIData) {
					AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
					// UI
					{
						UIUtils.Instantiate (accountAvatarUIData, avatarPrefab, avatarContainer);
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
					uiData.human.allRemoveCallBack (this);
					uiData.avatar.allRemoveCallBack (this);
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
				// Human
				{
					if (data is Human) {
						Human human = data as Human;
						// Parent
						{
							DataUtils.removeParentCallBack (human, this, ref this.requestNewContestManagerStateAsk);
						}
						// Child
						{
							human.account.allRemoveCallBack (this);
						}
						return;
					}
					// Parent
					if (data is RequestNewContestManagerStateAsk) {
						return;
					}
					// Child
					if (data is Account) {
						return;
					}
				}
				// avatar
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
				case UIData.Property.human:
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
				// Human
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
					// Parent
					if (wrapProperty.p is RequestNewContestManagerStateAsk) {
						switch ((RequestNewContestManagerStateAsk.Property)wrapProperty.n) {
						case RequestNewContestManagerStateAsk.Property.whoCanAsks:
							break;
						case RequestNewContestManagerStateAsk.Property.accepts:
							dirty = true;
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
				// avatar
				if (wrapProperty.p is AccountAvatarUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
		}

		#endregion

	}
}
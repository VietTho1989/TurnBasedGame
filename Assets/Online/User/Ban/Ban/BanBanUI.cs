using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

public class BanBanUI : UIBehavior<BanBanUI.UIData>
{

	#region UIData

	public class UIData : BanUI.UIData.Sub
	{

		public VP<ReferenceData<BanBan>> banBan;

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
			banBan,
			state
		}

		public UIData() : base()
		{
			this.banBan = new VP<ReferenceData<BanBan>>(this, (byte)Property.banBan, new ReferenceData<BanBan>(null));
			this.state = new VP<State>(this, (byte)Property.state, State.None);
		}

		#endregion

		public override Ban.Type getType ()
		{
			return Ban.Type.Ban;
		}

		public void reset()
		{
			this.state.v = State.None;
		}

	}

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage();

    public Text tvUnban;
    private static readonly TxtLanguage txtUnban = new TxtLanguage();
    private static readonly TxtLanguage txtCancelUnban = new TxtLanguage();
    private static readonly TxtLanguage txtUnbanning = new TxtLanguage();
    private static readonly TxtLanguage txtCannotUnban = new TxtLanguage();

    private static readonly TxtLanguage txtRequestError = new TxtLanguage();

    static BanBanUI()
    {
        txtTitle.add(Language.Type.vi, "Đã Bị Cấm");
        txtRequestError.add(Language.Type.vi, "Gửi yêu cầu bỏ cấm lỗi");
        // unban
        {
            txtUnban.add(Language.Type.vi, "Huỷ Cấm");
            txtCancelUnban.add(Language.Type.vi, "Huỷ");
            txtUnbanning.add(Language.Type.vi, "Đang huỷ cấm");
            txtCannotUnban.add(Language.Type.vi, "Không thể huỷ cấm");
        }
    }

    #endregion

    #region Refresh

    private User profileUser = null;
	private User toBanUser = null;

	public Button btnUnban;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				BanBan banBan = this.data.banBan.v.data;
				if (banBan != null) {
					// Check to add callBack
					{
						// profileUser
						{
							User profileUser = Server.GetProfileUser (banBan);
							if (this.profileUser != profileUser) {
								// remove old
								if (this.profileUser != null) {
									this.profileUser.removeCallBack (this);
								}
								// set new
								this.profileUser = profileUser;
								if (this.profileUser != null) {
									this.profileUser.addCallBack (this);
								}
							} else {
								Debug.LogError ("the same: " + this);
							}
						}
						// toBanUser
						{
							User toBanUser = banBan.findDataInParent<User>();
							if (this.toBanUser != toBanUser) {
								// remove old
								if (this.toBanUser != null) {
									this.toBanUser.removeCallBack (this);
								}
								// set new
								this.toBanUser = toBanUser;
								if (this.toBanUser != null) {
									this.toBanUser.addCallBack (this);
								}
							} else {
								Debug.LogError ("the same: " + this);
							}
						}
					}
					// Check can unban
					bool canUnBan = banBan.isCanBanOrUnBan(Server.getProfileUserId(banBan));
					// Task
					{
						if (canUnBan) {
                            // Task
                            {
                                switch (this.data.state.v)
                                {
                                    case UIData.State.None:
                                        {
                                            destroyRoutine(wait);
                                        }
                                        break;
                                    case UIData.State.Request:
                                        {
                                            destroyRoutine(wait);
                                            // request
                                            if (Server.IsServerOnline(banBan))
                                            {
                                                banBan.requestUnBan(Server.getProfileUserId(banBan));
                                                this.data.state.v = UIData.State.Wait;
                                            }
                                            else
                                            {
                                                Debug.LogError("server not online: " + this);
                                            }
                                        }
                                        break;
                                    case UIData.State.Wait:
                                        {
                                            if (Server.IsServerOnline(banBan))
                                            {
                                                if (Routine.IsNull(wait))
                                                {
                                                    wait = CoroutineManager.StartCoroutine(TaskWait(), this.gameObject);
                                                }
                                                else
                                                {
                                                    Debug.LogError("Why routine != null: " + this);
                                                }
                                            }
                                            else
                                            {
                                                this.data.state.v = UIData.State.None;
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                        break;
                                }
                            }
                            // UI
                            {
                                if(btnUnban!=null && tvUnban != null)
                                {
                                    switch (this.data.state.v)
                                    {
                                        case UIData.State.None:
                                            {
                                                btnUnban.interactable = true;
                                                tvUnban.text = txtUnban.get("Unban");
                                            }
                                            break;
                                        case UIData.State.Request:
                                            {
                                                btnUnban.interactable = true;
                                                tvUnban.text = txtCancelUnban.get("Cancel");
                                            }
                                            break;
                                        case UIData.State.Wait:
                                            {
                                                btnUnban.interactable = false;
                                                tvUnban.text = txtUnbanning.get("Unbanning");
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown state: " + this.data.state.v);
                                            break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("btnUnban, tvUnban null");
                                }
                            }
                        } else {
                            // task
                            {
                                destroyRoutine(wait);
                                this.data.state.v = UIData.State.None;
                            }
                            // UI
                            {
                                if(btnUnban!=null && tvUnban != null)
                                {
                                    btnUnban.interactable = false;
                                    tvUnban.text = txtCannotUnban.get("Cannot Unban");
                                }
                                else
                                {
                                    Debug.LogError("btnUnban, tvUnban null");
                                }
                            }
                        }
					}
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("Already Banned");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                    }
                } else {
					Debug.LogError ("banBan null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return false;
	}

	public override void OnDestroy()
	{
		base.OnDestroy ();
		if (this.profileUser != null) {
			this.profileUser.removeCallBack (this);
			this.profileUser = null;
		} else {
			Debug.LogError ("profileUser null: " + this);
		}
		if (this.toBanUser != null) {
			this.toBanUser.removeCallBack (this);
			this.toBanUser = null;
		} else {
			Debug.LogError ("toBanUser null: " + this);
		}
	}

	#endregion

	#region Task wait

	private Routine wait;

	public IEnumerator TaskWait()
	{
		if (this.data != null) {
			yield return new Wait (Global.WaitSendTime);
			this.data.state.v = UIData.State.None;
			Toast.showMessage (txtRequestError.get("Send request unban error"));
			Debug.LogError ("request unfriend error: " + this);
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

	private Server server = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
			// Child
			{
				uiData.banBan.allAddCallBack (this);
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
			// BanBan
			{
				if (data is BanBan) {
					BanBan banBan = data as BanBan;
					// Reset
					{
						if (this.data != null) {
							this.data.reset ();
						} else {
							Debug.LogError ("data null: " + this);
						}
					}
					// Parent
					{
						DataUtils.addParentCallBack (banBan, this, ref this.server);
					}
					dirty = true;
					return;
				}
				// Parent
				{
					if (data is Server) {
						dirty = true;
						return;
					}
				}
				if (data is User) {
					dirty = true;
					return;
				}
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
				uiData.banBan.allRemoveCallBack (this);
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
			// BanBan
			{
				if (data is BanBan) {
					BanBan banBan = data as BanBan;
					// Parent
					{
						DataUtils.removeParentCallBack (banBan, this, ref this.server);
					}
					return;
				}
				// Parent
				{
					if (data is Server) {
						return;
					}
				}
				if (data is User) {
					return;
				}
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
			case UIData.Property.banBan:
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
			// BanBan
			{
				if (wrapProperty.p is BanBan) {
					switch ((BanBan.Property)wrapProperty.n) {
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Parent
				{
					if (wrapProperty.p is Server) {
						Server.State.OnUpdateSyncStateChange (wrapProperty, this);
						return;
					}
				}
				if (wrapProperty.p is User) {
					switch ((User.Property)wrapProperty.n) {
					case User.Property.human:
						dirty = true;
						break;
					case User.Property.role:
						dirty = true;
						break;
					case User.Property.ipAddress:
						break;
					case User.Property.registerTime:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnUnBan()
	{
		if (this.data != null) {
            switch (this.data.state.v)
            {
                case UIData.State.None:
                    this.data.state.v = UIData.State.Request;
                    break;
                case UIData.State.Request:
                    this.data.state.v = UIData.State.None;
                    break;
                case UIData.State.Wait:
                    Debug.LogError("You are requesting");
                    break;
                default:
                    Debug.LogError("unknown state: " + this.data.state.v);
                    break;
            }
        } else {
			Debug.LogError ("data null: " + this);
		}
	}

}
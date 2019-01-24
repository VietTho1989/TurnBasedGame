using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Foundation.Tasks;
using AdvancedCoroutines;

public class BtnUpdateUser : UIBehavior<BtnUpdateUser.UIData>
{

	#region UIData

	public class UIData : Data
	{

		#region state

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
			state
		}

		public UIData() : base()
		{
			this.state = new VP<State>(this, (byte)Property.state, State.None);
		}

		#endregion

	}

	#endregion

	#region Refresh

	#region txt

	public static readonly TxtLanguage txtApply = new TxtLanguage ();
	public static readonly TxtLanguage txtCannotApply = new TxtLanguage();
	public static readonly TxtLanguage txtCancelApply = new TxtLanguage ();
	public static readonly TxtLanguage txtApplying = new TxtLanguage();

	static BtnUpdateUser()
	{
		txtApply.add (Language.Type.vi, "Cập nhập");
		txtCannotApply.add (Language.Type.vi, "Không có thay đổi");
		txtCancelApply.add (Language.Type.vi, "Huỷ bỏ cập nhập");
		txtApplying.add (Language.Type.vi, "Đang cập nhập...");
	}

	#endregion

	public Button btnApply;
	public Text tvApply;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				UserUI.UIData userUIData = this.data.findDataInParent<UserUI.UIData> ();
				if (userUIData != null) {
					EditData<User> editUser = userUIData.editUser.v;
					if (editUser != null) {
						if (editUser.canEdit.v && editUser.editType.v == Data.EditType.Later) {
							User originUser = editUser.origin.v.data;
							User showUser = editUser.show.v.data;
							if (originUser != null && showUser != null) {
								// set state
								bool isDifferent = DataUtils.IsDifferent (originUser, showUser);
								{
									if (!isDifferent) {
										this.data.state.v = UIData.State.None;
									} 
								}
								// Task
								{
									switch (this.data.state.v) {
									case UIData.State.None:
										{
											destroyRoutine (wait);
										}
										break;
									case UIData.State.Request:
										{
											destroyRoutine (wait);
											if (Server.IsServerOnline (originUser)) {
												originUser.requestUpdate (Server.getProfileUserId (originUser), showUser);
												this.data.state.v = UIData.State.Wait;
											} else {
												Debug.LogError ("server not online");
												// Toast.showMessage ("not correct to server");
												this.data.state.v = UIData.State.None;
											}
										}
										break;
									case UIData.State.Wait:
										{
											if (Server.IsServerOnline (originUser)) {
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
								}
								// btnApply, txtApply
								{
									if (btnApply!=null && tvApply != null) {
										switch (this.data.state.v) {
										case UIData.State.None:
											{
												if (isDifferent) {
													btnApply.enabled = true;
													tvApply.text = txtApply.get ("Apply");
												} else {
													btnApply.enabled = false;
													tvApply.text = txtCannotApply.get ("Not Different, Cannot apply");
												}
											}
											break;
										case UIData.State.Request:
											{
												btnApply.enabled = true;
												tvApply.text = txtCancelApply.get ("Cancel Apply");
											}
											break;
										case UIData.State.Wait:
											tvApply.text = txtApplying.get ("Applying...");
											break;
										default:
											Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
											break;
										}
									} else {
										Debug.LogError ("btnApply, txtApply null: " + this);
									}
								}
							} else {
								Debug.LogError ("originUser, showUser null: " + this);
								this.data.state.v = UIData.State.None;
							}
						} else {
							this.data.state.v = UIData.State.None;
							// btnApply
							if (btnApply != null) {
								btnApply.enabled = false;
							} else {
								Debug.LogError ("btnApply null: " + this);
							}
							// txtApply
							if (tvApply != null) {
								tvApply.text = txtApply.get ("Apply");
							} else {
								Debug.LogError ("txtApply null: " + this);
							}
						}
					} else {
						Debug.LogError ("editUser null: " + this);
					}
				} else {
					Debug.LogError ("userUIData null: " + this);
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

	#endregion

	#region Task wait

	private Routine wait;

	public IEnumerator TaskWait()
	{
		if (this.data != null) {
			yield return new Wait (Global.WaitSendTime);
			if (this.data != null) {
				this.data.state.v = UIData.State.None;
			} else {
				Debug.LogError ("data null: " + this);
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

	private UserUI.UIData userUIData = null;
	private Server server = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Parent
			{
				DataUtils.addParentCallBack (uiData, this, ref this.userUIData);
			}
			dirty = true;
			return;
		}
		// Setting
		if (data is Setting) {
			dirty = true;
			return;
		}
		// Parent
		{
			if (data is UserUI.UIData) {
				UserUI.UIData userUIData = data as UserUI.UIData;
				// Child
				{
					userUIData.editUser.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is EditData<User>) {
					EditData<User> editUser = data as EditData<User>;
					// Child
					{
						editUser.origin.allAddCallBack (this);
						editUser.show.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is User) {
						User user = data as User;
						// Parent
						{
							DataUtils.addParentCallBack (user, this, ref this.server);
						}
						// Child
						{
							user.addCallBackAllChildren (this);
						}
						dirty = true;
						return;
					}
					// Parent
					if (data is Server) {
						dirty = true;
						return;
					}
					// Child
					{
						data.addCallBackAllChildren (this);
						dirty = true;
						return;
					}
				}
			}
		}
		// Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().removeCallBack(this);
			// Parent
			{
				DataUtils.removeParentCallBack (uiData, this, ref this.userUIData);
			}
			this.setDataNull (uiData);
			return;
		}
		// Setting
		if (data is Setting) {
			return;
		}
		// Parent
		{
			if (data is UserUI.UIData) {
				UserUI.UIData userUIData = data as UserUI.UIData;
				// Child
				{
					userUIData.editUser.allRemoveCallBack (this);
				}
				return;
			}
			// Child
			{
				if (data is EditData<User>) {
					EditData<User> editUser = data as EditData<User>;
					// Child
					{
						editUser.origin.allRemoveCallBack (this);
						editUser.show.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is User) {
						User user = data as User;
						// Parent
						{
							DataUtils.removeParentCallBack (user, this, ref this.server);
						}
						// Child
						{
							user.removeCallBackAllChildren (this);
						}
						return;
					}
					// Parent
					if (data is Server) {
						return;
					}
					// Child
					{
						data.removeCallBackAllChildren (this);
						return;
					}
				}
			}
		}
		// Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is UIData) {
			switch ((UIData.Property)wrapProperty.n) {
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
		// Parent
		{
			if (wrapProperty.p is UserUI.UIData) {
				switch ((UserUI.UIData.Property)wrapProperty.n) {
				case UserUI.UIData.Property.editUser:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UserUI.UIData.Property.editType:
					break;
				case UserUI.UIData.Property.requestEditType:
					break;
				case UserUI.UIData.Property.human:
					break;
				case UserUI.UIData.Property.role:
					break;
				case UserUI.UIData.Property.ipAddress:
					break;
				case UserUI.UIData.Property.registerTime:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				if (wrapProperty.p is EditData<User>) {
					switch ((EditData<User>.Property)wrapProperty.n) {
					case EditData<User>.Property.origin:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case EditData<User>.Property.show:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case EditData<User>.Property.compare:
						break;
					case EditData<User>.Property.compareOtherType:
						break;
					case EditData<User>.Property.canEdit:
						dirty = true;
						break;
					case EditData<User>.Property.editType:
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
					if (wrapProperty.p is User) {
						if (Generic.IsAddCallBackInterface<T> ()) {
							ValueChangeUtils.replaceCallBack (this, syncs);
						}
						dirty = true;
						if (this.data != null) {
							this.data.state.v = UIData.State.None;
						}
						return;
					}
					// Parent
					if (wrapProperty.p is Server) {
						Server.State.OnUpdateSyncStateChange (wrapProperty, this);
						return;
					}
					// Child
					{
						if (Generic.IsAddCallBackInterface<T> ()) {
							ValueChangeUtils.replaceCallBack (this, syncs);
						}
						dirty = true;
						if (this.data != null) {
							this.data.state.v = UIData.State.None;
						}
						return;
					}
				}
			}
		}
		// Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnUpdate()
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
				Debug.LogError ("You are requesting: " + this);
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
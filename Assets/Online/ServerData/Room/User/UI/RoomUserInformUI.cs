using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RoomUserInformUI : UIBehavior<RoomUserInformUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<RoomUser>> roomUser;

		public VP<HumanUI.UIData> humanUI;

		public VP<UserMakeFriendUI.UIData> userMakeFriend;

		public VP<RoomUserKickUI.UIData> kickUI;

		#region Constructor

		public enum Property
		{
			roomUser,
			humanUI,
			userMakeFriend,
			kickUI
		}

		public UIData() : base()
		{
			this.roomUser = new VP<ReferenceData<RoomUser>>(this, (byte)Property.roomUser, new ReferenceData<RoomUser>(null));
			// humanUI
			{
				this.humanUI = new VP<HumanUI.UIData>(this, (byte)Property.humanUI, new HumanUI.UIData());
				this.humanUI.v.editHuman.v.canEdit.v = false;
			}
			this.userMakeFriend = new VP<UserMakeFriendUI.UIData>(this, (byte)Property.userMakeFriend, new UserMakeFriendUI.UIData());
			this.kickUI = new VP<RoomUserKickUI.UIData>(this, (byte)Property.kickUI, new RoomUserKickUI.UIData());
		}

		#endregion

		public bool processEvent(Event e)
		{
			bool isProcess = false;
			{
				// back
				if (!isProcess) {
					if (InputEvent.isBackEvent (e)) {
						RoomUserInformUI roomUserInformUI = this.findCallBack<RoomUserInformUI> ();
						if (roomUserInformUI != null) {
							roomUserInformUI.onClickBtnBack ();
						} else {
							Debug.LogError ("roomUserInformUI null: " + this);
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

	public Text tvCannotBeKicked;
	public static readonly TxtLanguage txtCannotBeKicked = new TxtLanguage();

	static RoomUserInformUI()
	{
		txtTitle.add (Language.Type.vi, "Thông tin người trong phòng");
		txtBack.add (Language.Type.vi, "Quay Lại");
		txtCannotBeKicked.add (Language.Type.vi, "Không thể bị kick");
	}

	#endregion

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				RoomUser roomUser = this.data.roomUser.v.data;
				if (roomUser != null) {
					// humanUI
					{
						HumanUI.UIData humanUIData = this.data.humanUI.v;
						if (humanUIData != null) {
							humanUIData.editHuman.v.origin.v = new ReferenceData<Human> (roomUser.inform.v);
						} else {
							Debug.LogError ("humanUIData null: " + this);
						}
					}
					// userMakeFriend
					{
						UserMakeFriendUI.UIData userMakeFriend = this.data.userMakeFriend.v;
						if (userMakeFriend != null) {
							userMakeFriend.human.v = new ReferenceData<Human> (roomUser.inform.v);
						} else {
							Debug.LogError ("userMakeFriend null: " + this);
						}
					}
					// btnKick
					{
						RoomUserKickUI.UIData kickUIData = this.data.kickUI.v;
						if (kickUIData != null) {
							kickUIData.roomUser.v = new ReferenceData<RoomUser> (roomUser);
						} else {
							Debug.LogError ("kickUIData null: " + this);
						}
					}
				} else {
					Debug.LogError ("roomUser null: " + this);
				}
				// txt
				{
					if (lbTitle != null) {
						lbTitle.text = txtTitle.get ("Room User Information");
					} else {
						Debug.LogError ("lbTitle null: " + this);
					}
					if (tvBack != null) {
						tvBack.text = txtBack.get ("Back");
					} else {
						Debug.LogError ("tvBack null: " + this);
					}
					if (tvCannotBeKicked != null) {
						tvCannotBeKicked.text = txtCannotBeKicked.get ("Cannot be kicked");
					} else {
						Debug.LogError ("tvCannotBeKicked null: " + this);
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

	public HumanUI humanPrefab;
	public Transform humanContainer;

	public UserMakeFriendUI userMakeFriendPrefab;
	public Transform userMakeFriendContainer;

	public RoomUserKickUI kickPrefab;
	public Transform kickContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.roomUser.allAddCallBack (this);
				uiData.humanUI.allAddCallBack (this);
				uiData.userMakeFriend.allAddCallBack (this);
				uiData.kickUI.allAddCallBack (this);
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
			if (data is RoomUser) {
				dirty = true;
				return;
			}
			if (data is HumanUI.UIData) {
				HumanUI.UIData humanUIData = data as HumanUI.UIData;
				// UI
				{
					UIUtils.Instantiate (humanUIData, humanPrefab, humanContainer);
				}
				dirty = true;
				return;
			}
			if (data is UserMakeFriendUI.UIData) {
				UserMakeFriendUI.UIData userMakeFriendUIData = data as UserMakeFriendUI.UIData;
				// UI
				{
					UIUtils.Instantiate (userMakeFriendUIData, userMakeFriendPrefab, userMakeFriendContainer);
				}
				dirty = true;
				return;
			}
			if (data is RoomUserKickUI.UIData) {
				RoomUserKickUI.UIData kickUIData = data as RoomUserKickUI.UIData;
				// UI
				{
					UIUtils.Instantiate (kickUIData, kickPrefab, kickContainer);
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
				uiData.roomUser.allRemoveCallBack (this);
				uiData.humanUI.allRemoveCallBack (this);
				uiData.userMakeFriend.allRemoveCallBack (this);
				uiData.kickUI.allRemoveCallBack (this);
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
			if (data is RoomUser) {
				return;
			}
			if (data is HumanUI.UIData) {
				HumanUI.UIData humanUIData = data as HumanUI.UIData;
				// UI
				{
					humanUIData.removeCallBackAndDestroy (typeof(HumanUI));
				}
				return;
			}
			if (data is UserMakeFriendUI.UIData) {
				UserMakeFriendUI.UIData userMakeFriendUIData = data as UserMakeFriendUI.UIData;
				// UI
				{
					userMakeFriendUIData.removeCallBackAndDestroy (typeof(UserMakeFriendUI));
				}
				return;
			}
			if (data is RoomUserKickUI.UIData) {
				RoomUserKickUI.UIData kickUIData = data as RoomUserKickUI.UIData;
				// UI
				{
					kickUIData.removeCallBackAndDestroy (typeof(RoomUserKickUI));
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
			case UIData.Property.humanUI:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.userMakeFriend:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.kickUI:
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
			if (wrapProperty.p is RoomUser) {
				switch ((RoomUser.Property)wrapProperty.n) {
				case RoomUser.Property.role:
					break;
				case RoomUser.Property.inform:
					dirty = true;
					break;
				case RoomUser.Property.state:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is HumanUI.UIData) {
				return;
			}
			if (wrapProperty.p is UserMakeFriendUI.UIData) {
				return;
			}
			if (wrapProperty.p is RoomUserKickUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnBack()
	{
		if (this.data != null) {
			RoomUI.UIData roomUIData = this.data.findDataInParent<RoomUI.UIData> ();
			if (roomUIData != null) {
				roomUIData.roomUserInformUI.v = null;
			} else {
				Debug.LogError ("roomUIData null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}
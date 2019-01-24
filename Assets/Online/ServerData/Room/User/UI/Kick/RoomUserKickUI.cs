using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomUserKickUI : UIBehavior<RoomUserKickUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<RoomUser>> roomUser;

		public VP<RoomUserBtnKickUI.UIData> btnKick;

		public VP<RoomUserBtnUnKickUI.UIData> btnUnKick;

		#region Constructor

		public enum Property
		{
			roomUser,
			btnKick,
			btnUnKick
		}

		public UIData() : base()
		{
			this.roomUser = new VP<ReferenceData<RoomUser>>(this, (byte)Property.roomUser, new ReferenceData<RoomUser>(null));
			this.btnKick = new VP<RoomUserBtnKickUI.UIData>(this, (byte)Property.btnKick, new RoomUserBtnKickUI.UIData());
			this.btnUnKick = new VP<RoomUserBtnUnKickUI.UIData>(this, (byte)Property.btnUnKick, new RoomUserBtnUnKickUI.UIData());
		}

		#endregion

	}

	#endregion

	#region Refresh

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				RoomUser roomUser = this.data.roomUser.v.data;
				if (roomUser != null) {
					uint profileId = Server.getProfileUserId (roomUser);
					// btnKick
					{
						// UI
						{
							if (btnKickContainer != null) {
								btnKickContainer.gameObject.SetActive (roomUser.isCanKick (profileId));
							} else {
								Debug.LogError ("btnKickContainer null: " + this);
							}
						}
						// Data
						{
							RoomUserBtnKickUI.UIData btnKick = this.data.btnKick.v;
							if (btnKick != null) {
								btnKick.roomUser.v = new ReferenceData<RoomUser> (roomUser);
							} else {
								Debug.LogError ("btnKick null: " + this);
							}
						}
					}
					// btnUnKick
					{
						// UI
						{
							if (btnUnKickContainer != null) {
								btnUnKickContainer.gameObject.SetActive (roomUser.isCanUnKick (profileId));
							} else {
								Debug.LogError ("btnUnKickContainer null: " + this);
							}
						}
						// Data
						{
							RoomUserBtnUnKickUI.UIData btnUnKick = this.data.btnUnKick.v;
							if (btnUnKick != null) {
								btnUnKick.roomUser.v = new ReferenceData<RoomUser> (roomUser);
							} else {
								Debug.LogError ("btnUnKick null: " + this);
							}
						}
					}
				} else {
					Debug.LogError ("roomUser null: " + this);
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

	public RoomUserBtnKickUI btnKickPrefab;
	public Transform btnKickContainer;

	public RoomUserBtnUnKickUI btnUnKickPrefab;
	public Transform btnUnKickContainer;

	private RoomCheckChangeAdminChange<RoomUser> roomCheckAdminChange = new RoomCheckChangeAdminChange<RoomUser> ();

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.roomUser.allAddCallBack (this);
				uiData.btnKick.allAddCallBack (this);
				uiData.btnUnKick.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			// roomUser
			{
				if (data is RoomUser) {
					RoomUser roomUser = data as RoomUser;
					// CheckChange
					{
						roomCheckAdminChange.addCallBack (this);
						roomCheckAdminChange.setData (roomUser);
					}
					// Child
					{
						roomUser.inform.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// CheckChange
				if (data is RoomCheckChangeAdminChange<RoomUser>) {
					dirty = true;
					return;
				}
				// Child
				if (data is Human) {
					dirty = true;
					return;
				}
			}
			if (data is RoomUserBtnKickUI.UIData) {
				RoomUserBtnKickUI.UIData btnKickUIData = data as RoomUserBtnKickUI.UIData;
				// UI
				{
					UIUtils.Instantiate (btnKickUIData, btnKickPrefab, btnKickContainer);
				}
				dirty = true;
				return;
			}
			if (data is RoomUserBtnUnKickUI.UIData) {
				RoomUserBtnUnKickUI.UIData btnUnKickUIData = data as RoomUserBtnUnKickUI.UIData;
				// UI
				{
					UIUtils.Instantiate (btnUnKickUIData, btnUnKickPrefab, btnUnKickContainer);
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
				uiData.btnKick.allRemoveCallBack (this);
				uiData.btnUnKick.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			// roomUser
			{
				if (data is RoomUser) {
					RoomUser roomUser = data as RoomUser;
					// CheckChange
					{
						roomCheckAdminChange.removeCallBack (this);
						roomCheckAdminChange.setData (null);
					}
					// Child
					{
						roomUser.inform.allRemoveCallBack (this);
					}
					return;
				}
				// CheckChange
				if (data is RoomCheckChangeAdminChange<RoomUser>) {
					return;
				}
				// Child
				if (data is Human) {
					return;
				}
			}
			if (data is RoomUserBtnKickUI.UIData) {
				RoomUserBtnKickUI.UIData btnKickUIData = data as RoomUserBtnKickUI.UIData;
				// UI
				{
					btnKickUIData.removeCallBackAndDestroy (typeof(RoomUserBtnKickUI));
				}
				return;
			}
			if (data is RoomUserBtnUnKickUI.UIData) {
				RoomUserBtnUnKickUI.UIData btnUnKickUIData = data as RoomUserBtnUnKickUI.UIData;
				// UI
				{
					btnUnKickUIData.removeCallBackAndDestroy (typeof(RoomUserBtnUnKickUI));
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
			case UIData.Property.btnKick:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.btnUnKick:
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
			// roomUser
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
				// CheckChange
				if (wrapProperty.p is RoomCheckChangeAdminChange<RoomUser>) {
					dirty = true;
					return;
				}
				// Child
				if (wrapProperty.p is Human) {
					switch ((Human.Property)wrapProperty.n) {
					case Human.Property.playerId:
						dirty = true;
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
			}
			if (wrapProperty.p is RoomUserBtnKickUI.UIData) {
				return;
			}
			if (wrapProperty.p is RoomUserBtnUnKickUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

}
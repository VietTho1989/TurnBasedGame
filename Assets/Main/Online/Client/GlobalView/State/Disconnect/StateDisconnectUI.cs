using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StateDisconnectUI : UIBehavior<StateDisconnectUI.UIData>
{

	#region UIData

	public class UIData : GlobalStateUI.UIData.Sub
	{

		public VP<ReferenceData<Server.State.Disconnect>> disconnect;

		public VP<LoginStateUI.UIData> loginState;

		#region Constructor

		public enum Property
		{
			disconnect,
			loginState
		}

		public UIData() : base()
		{
			this.disconnect = new VP<ReferenceData<Server.State.Disconnect>>(this, (byte)Property.disconnect, new ReferenceData<Server.State.Disconnect>(null));
			this.loginState = new VP<LoginStateUI.UIData>(this, (byte)Property.loginState, new LoginStateUI.UIData());
		}

		#endregion

		public override Server.State.Type getType ()
		{
			return Server.State.Type.Disconnect;
		}

	}

	#endregion

	#region Refresh

	public Text tvTime;

	#region txt

	public static readonly TxtLanguage txtTime = new TxtLanguage ();

	static StateDisconnectUI()
	{
		txtTime.add (Language.Type.vi, "mất kết nối, thời gian");
	}

	#endregion

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Server.State.Disconnect disconnect = this.data.disconnect.v.data;
				if (disconnect != null) {
					// time
					{
						if (tvTime != null) {
							tvTime.text = txtTime.get ("disconnect: time") + ": " + disconnect.time.v;
						} else {
							Debug.LogError ("tvTime null: " + this);
						}
					}
					// login
					{
						LoginStateUI.UIData loginStateUIData = this.data.loginState.v;
						if (loginStateUIData != null) {
							loginStateUIData.login.v = new ReferenceData<Login> (disconnect.login.v);
						} else {
							Debug.LogError ("loginUIData null: " + this);
						}
					}
				} else {
					Debug.LogError ("disconnect null: " + this);
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

	public LoginStateUI loginStatePrefab;
	public Transform loginStateContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.disconnect.allAddCallBack (this);
				uiData.loginState.allAddCallBack (this);
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
			if (data is Server.State.Disconnect) {
				dirty = true;
				return;
			}
			if (data is LoginStateUI.UIData) {
				LoginStateUI.UIData loginStateUIData = data as LoginStateUI.UIData;
				// UI
				{
					UIUtils.Instantiate (loginStateUIData, loginStatePrefab, loginStateContainer);
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
				uiData.disconnect.allRemoveCallBack (this);
				uiData.loginState.allRemoveCallBack (this);
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
			if (data is Server.State.Disconnect) {
				return;
			}
			if (data is LoginStateUI.UIData) {
				LoginStateUI.UIData loginStateUIData = data as LoginStateUI.UIData;
				// UI
				{
					loginStateUIData.removeCallBackAndDestroy (typeof(LoginStateUI));
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if(WrapProperty.checkError(wrapProperty)){
			return;
		}
		if (wrapProperty.p is UIData) {
			switch ((UIData.Property)wrapProperty.n) {
			case UIData.Property.disconnect:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.loginState:
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
			if (wrapProperty.p is Server.State.Disconnect) {
				switch ((Server.State.Disconnect.Property)wrapProperty.n) {
				case Server.State.Disconnect.Property.time:
					dirty = true;
					break;
				case Server.State.Disconnect.Property.login:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is LoginStateUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
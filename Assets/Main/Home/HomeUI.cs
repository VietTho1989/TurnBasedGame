using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HomeUI : UIBehavior<HomeUI.UIData> 
{
	
	#region UIData

	public class UIData : MainUI.UIData.Sub
	{
		
		#region Constructor

		public enum Property
		{

		}

		public UIData() : base()
		{

		}

		#endregion

		public override MainUI.UIData.Sub.Type getType()
		{
			return MainUI.UIData.Sub.Type.Home;
		}

		public override bool processEvent(Event e)
		{
			Debug.LogError ("processEvent: " + e + "; " + this);
			bool isProcess = false;
			{
				// Child
				{
					// TODO Can hoan thien
				}
				// back
				if (!isProcess) {
					if (InputEvent.isBackEvent (e)) {
						Debug.LogError ("backEvent: " + this);
						Application.Quit ();
						isProcess = true;
					}
				}
				// short key
				if(!isProcess){
					// TODO Can hoan thien
				}
			}
			return isProcess;
		}

	}

	#endregion

	#region refresh

	public Text tvOffline;
	public static readonly TxtLanguage txtOffline = new TxtLanguage ();

	public Text tvLan;
	public static readonly TxtLanguage txtLan = new TxtLanguage ();

	public Text tvOnline;
	public static readonly TxtLanguage txtOnline = new TxtLanguage();

	public Text tvLoad;
	public static readonly TxtLanguage txtLoad = new TxtLanguage ();

	static HomeUI()
	{
		// offline
		txtOffline.add (Language.Type.vi, "Chơi Offline");
		// lan
		txtLan.add (Language.Type.vi, "Chơi mạng Lan");
		// online
		txtOnline.add (Language.Type.vi, "Chơi Online");
		// load
		txtLoad.add (Language.Type.vi, "Tải");
	}

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// tvOffline
				if (tvOffline != null) {
					tvOffline.text = txtOffline.get ("Play Offline");
				} else {
					Debug.LogError ("tvOffline null: " + this);
				}
				// tvLan
				if (tvLan != null) {
					tvLan.text = txtLan.get ("Play LAN");
				} else {
					Debug.LogError ("tvLan null: " + this);
				}
				// tvOnline
				if (tvOnline != null) {
					tvOnline.text = txtOnline.get ("Play Online");
				} else {
					Debug.LogError ("tvOnline null: " + this);
				}
				// tvLoad
				if (tvLoad != null) {
					tvLoad.text = txtLoad.get ("Load");
				} else {
					Debug.LogError ("tvLoad null: " + this);
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

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			// setting
			{
				Setting.get ().addCallBack (this);
			}
			dirty = true;
			return;
		}
		// Setting
		if (data is Setting) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// setting
			{
				Setting.get ().removeCallBack (this);
			}
			// Child
			{

			}
			this.setDataNull (uiData);
			return;
		}
		// Setting
		if (data is Setting) {
			return;
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
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// setting
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
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	#region Click Button

	public void onClickBtnPlayOnline()
	{
		// Debug.LogError ("onClickBtnPlayOnline");
		if (this.data != null) {
			MainUI.UIData mainUIData = this.data.findDataInParent<MainUI.UIData> ();
			if (mainUIData != null) {
				PlayOnlineUI.UIData playOnlineUIData = mainUIData.sub.newOrOld<PlayOnlineUI.UIData> ();
				{

				}
				mainUIData.sub.v = playOnlineUIData;
			} else {
				Debug.LogError ("mainUIData null");
			}
		} else {
			Debug.LogError ("uiData null");
		}
	}

	public void onClickBtnPlayOffline()
	{
		// Debug.LogError ("onClickBtnPlayOffline");
		if (this.data != null) {
			MainUI.UIData mainUIData = this.data.findDataInParent<MainUI.UIData> ();
			if (mainUIData != null) {
				OfflineUI.UIData offlineUIData = mainUIData.sub.newOrOld<OfflineUI.UIData> ();
				{

				}
				mainUIData.sub.v = offlineUIData;
			} else {
				Debug.LogError ("mainUIData null");
			}
		} else {
			Debug.LogError ("uiData null");
		}
	}

	public void onClickBtnPlayLAN()
	{
		// Debug.LogError ("onClickBtnPlayLAN");
		if (this.data != null) {
			MainUI.UIData mainUIData = this.data.findDataInParent<MainUI.UIData> ();
			if (mainUIData != null) {
				LanUI.UIData lanUIData = mainUIData.sub.newOrOld<LanUI.UIData> ();
				{

				}
				mainUIData.sub.v = lanUIData;
			} else {
				Debug.LogError ("mainUIData null");
			}
		} else {
			Debug.LogError ("uiData null");
		}
	}

	public void onClickBtnLoadGame()
	{
		Debug.LogError ("onClickBtnLoadGame");
		if (this.data != null) {
			MainUI.UIData mainUIData = this.data.findDataInParent<MainUI.UIData> ();
			if (mainUIData != null) {
				LoadDataUI.UIData loadDataUIData = mainUIData.sub.newOrOld<LoadDataUI.UIData> ();
				{

				}
				mainUIData.sub.v = loadDataUIData;
			} else {
				Debug.LogError ("mainUIData null");
			}
		} else {
			Debug.LogError ("data null");
		}
	}

	#endregion
}

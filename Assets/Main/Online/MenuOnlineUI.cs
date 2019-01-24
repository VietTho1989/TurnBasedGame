using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuOnlineUI : UIBehavior<MenuOnlineUI.UIData>
{
	
	#region UIData

	public class UIData : PlayOnlineUI.UIData.Sub
	{
		
		#region Constructor

		public enum Property
		{

		}

		public UIData() : base()
		{

		}

		#endregion


		public override PlayOnlineUI.UIData.Sub.Type getType()
		{
			return PlayOnlineUI.UIData.Sub.Type.Menu;
		}

		public override bool processEvent (Event e)
		{
			bool isProcess = false;
			{
				// back
				if (!isProcess) {
					if (InputEvent.isBackEvent (e)) {
						MenuOnlineUI menuOnlineUI = this.findCallBack<MenuOnlineUI> ();
						if (menuOnlineUI != null) {
							menuOnlineUI.onClickBtnBack ();
						} else {
							Debug.LogError ("menuOnlineUI null: " + this);
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

	public Text tvServer;
	public static readonly TxtLanguage txtServer = new TxtLanguage ();

	public Text tvClient;
	public static readonly TxtLanguage txtClient = new TxtLanguage();

	static MenuOnlineUI()
	{
		txtTitle.add (Language.Type.vi, "Chơi Online");
		txtBack.add (Language.Type.vi, "Quay Lại");
		txtServer.add (Language.Type.vi, "Máy Chủ");
		txtClient.add (Language.Type.vi, "Máy Khách");
	}

	#endregion

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// txt
				{
					if (lbTitle != null) {
						lbTitle.text = txtTitle.get ("Play Online");
					} else {
						Debug.LogError ("lbTitle null: " + this);
					}
					if (tvBack != null) {
						tvBack.text = txtBack.get ("Back");
					} else {
						Debug.LogError ("tvBack null: " + this);
					}
					if (tvServer != null) {
						tvServer.text = txtServer.get ("Server");
					} else {
						Debug.LogError ("tvServer null: " + this);
					}
					if (tvClient != null) {
						tvClient.text = txtClient.get ("Client");
					} else {
						Debug.LogError ("tvClient null: " + this);
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

	public override void onAddCallBack<T> (T data)
	{
		if (data is MenuOnlineUI.UIData) {
			// Setting
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
			// Setting
			Setting.get ().removeCallBack (this);
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
		Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
	}

	#endregion

	public void onClickBtnServer()
	{
		if (this.data != null) {
			PlayOnlineUI.UIData playOnlineUIData = this.data.findDataInParent<PlayOnlineUI.UIData> ();
			if (playOnlineUIData != null) {
				ServerOnlineUI.UIData serverOnlineUIData = new ServerOnlineUI.UIData ();
				{
					serverOnlineUIData.uid = playOnlineUIData.sub.makeId ();
				}
				playOnlineUIData.sub.v = serverOnlineUIData;
			} else {
				Debug.LogError ("playOnlineUIData null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	public void onClickBtnClient()
	{
		if (this.data != null) {
			PlayOnlineUI.UIData playOnlineUIData = this.data.findDataInParent<PlayOnlineUI.UIData> ();
			if (playOnlineUIData != null) {
				ClientUI.UIData clientUIData = new ClientUI.UIData ();
				{
					clientUIData.uid = playOnlineUIData.sub.makeId ();
				}
				playOnlineUIData.sub.v = clientUIData;
			} else {
				Debug.LogError ("playOnlineUIData null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	public void onClickBtnBack()
	{
		if (this.data != null) {
			MainUI.UIData mainUIData = this.data.findDataInParent<MainUI.UIData> ();
			if (mainUIData != null) {
				HomeUI.UIData homeUIData = new HomeUI.UIData ();
				{
					homeUIData.uid = mainUIData.sub.makeId ();
				}
				mainUIData.sub.v = homeUIData;
			} else {
				Debug.LogError ("mainUIData null");
			}
		} else {
			Debug.LogError ("uiData null");
		}
	}
}
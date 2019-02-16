using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AfterLoginMainBtnBackServerUI : UIBehavior<AfterLoginMainBtnBackServerUI.UIData>
{

	#region UIData

	public class UIData : AfterLoginMainBtnBackUI.UIData.Sub
	{

		public VP<ReferenceData<Server>> server;

		public VP<bool> needConfirm;

		public VP<ConfirmBackServerUI.UIData> confirmUI;

		#region Constructor

		public enum Property
		{
			server,
			needConfirm,
			confirmUI
		}

		public UIData() : base()
		{
			this.server = new VP<ReferenceData<Server>>(this, (byte)Property.server, new ReferenceData<Server>(null));
			this.needConfirm = new VP<bool>(this, (byte)Property.needConfirm, true);
			this.confirmUI = new VP<ConfirmBackServerUI.UIData>(this, (byte)Property.confirmUI, null);
		}

		#endregion

		public override Server.Type getType ()
		{
			return Server.Type.Server;
		}

		public override bool processEvent (Event e)
		{
			bool isProcess = false;
			{
				// confirmUI
				if (!isProcess) {
					ConfirmBackServerUI.UIData confirmUI = this.confirmUI.v;
					if (confirmUI != null) {
						isProcess = confirmUI.processEvent (e);
					} else {
						Debug.LogError ("confirmUI null: " + this);
					}
				}
				// back
				if (!isProcess) {
					if (InputEvent.isBackEvent (e)) {
						AfterLoginMainBtnBackServerUI backServerUI = this.findCallBack<AfterLoginMainBtnBackServerUI> ();
						if (backServerUI != null) {
							backServerUI.onClickBtnBack ();
						} else {
							Debug.LogError ("backServerUI null: " + this);
						}
						isProcess = true;
					}
				}
			}
			return isProcess;
		}

		public void back()
		{
			PlayOnlineUI.UIData playOnlineUIData = this.findDataInParent<PlayOnlineUI.UIData> ();
			if (playOnlineUIData != null) {
				MenuOnlineUI.UIData menuOnlineUIData = playOnlineUIData.sub.newOrOld<MenuOnlineUI.UIData> ();
				{

				}
				playOnlineUIData.sub.v = menuOnlineUIData;
			} else {
				Debug.LogError ("playOnlineUIData null: " + this);
			}
		}

	}

	#endregion

	#region Refresh

	#region txt

	public Text tvBack;
	public static readonly TxtLanguage txtBack = new TxtLanguage ();

	static AfterLoginMainBtnBackServerUI()
	{
		txtBack.add (Language.Type.vi, "Quay Lại");
	}

	#endregion

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// confirmUI
				{
					if (!this.data.needConfirm.v) {
						this.data.confirmUI.v = null;
					}
				}
				// txt
				{
					if (tvBack != null) {
						tvBack.text = txtBack.get ("Back");
					} else {
						Debug.LogError ("tvBack null: " + this);
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

	public ConfirmBackServerUI confirmUIPrefab;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.server.allAddCallBack (this);
				uiData.confirmUI.allAddCallBack (this);
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
			if (data is Server) {
				dirty = true;
				// reset
				{
					if (this.data != null) {
						this.data.confirmUI.v = null;
					} else {
						Debug.LogError ("data null: " + this);
					}
				}
				return;
			}
			if (data is ConfirmBackServerUI.UIData) {
				ConfirmBackServerUI.UIData confirmUIData = data as ConfirmBackServerUI.UIData;
				// UI
				{
                    Transform confirmBackContainer = null;
                    {
                        GlobalViewUI.UIData globalViewUIData = confirmUIData.findDataInParent<GlobalViewUI.UIData>();
                        if (globalViewUIData != null)
                        {
                            GlobalViewUI globalViewUI = globalViewUIData.findCallBack<GlobalViewUI>();
                            if (globalViewUI != null)
                            {
                                confirmBackContainer = globalViewUI.confirmBackContainer;
                            }
                            else
                            {
                                Debug.LogError("globalViewUI null");
                            }
                        }
                        else
                        {
                            Debug.LogError("globalViewUIData null");
                        }
                    }
                    UIUtils.Instantiate (confirmUIData, confirmUIPrefab, confirmBackContainer);
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
				uiData.server.allRemoveCallBack (this);
				uiData.confirmUI.allRemoveCallBack (this);
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
			if (data is Server) {
				return;
			}
			if (data is ConfirmBackServerUI.UIData) {
				ConfirmBackServerUI.UIData confirmUIData = data as ConfirmBackServerUI.UIData;
				// UI
				{
					confirmUIData.removeCallBackAndDestroy (typeof(ConfirmBackServerUI));
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
			case UIData.Property.server:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.needConfirm:
				dirty = true;
				break;
			case UIData.Property.confirmUI:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
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
			if (wrapProperty.p is Server) {
				return;
			}
			if (wrapProperty.p is ConfirmBackServerUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnBack()
	{
		if (this.data != null) {
			if (!this.data.needConfirm.v) {
				this.data.back ();
			} else {
				ConfirmBackServerUI.UIData confirmUIData = this.data.confirmUI.newOrOld<ConfirmBackServerUI.UIData> ();
				{

				}
				this.data.confirmUI.v = confirmUIData;
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}
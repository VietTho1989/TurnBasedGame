using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StateConnectUI : UIBehavior<StateConnectUI.UIData>
{

	#region UIData

	public class UIData : GlobalStateUI.UIData.Sub
	{

		public VP<ReferenceData<Server.State.Connect>> connect;

        public VP<StateConnectDetailUI.UIData> detail;

		#region Constructor

		public enum Property
		{
			connect,
            detail
        }

		public UIData() : base()
		{
			this.connect = new VP<ReferenceData<Server.State.Connect>>(this, (byte)Property.connect, new ReferenceData<Server.State.Connect>(null));
            this.detail = new VP<StateConnectDetailUI.UIData>(this, (byte)Property.detail, null);
        }

		#endregion

		public override Server.State.Type getType ()
		{
			return Server.State.Type.Connect;
		}

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // detail
                if (!isProcess)
                {
                    StateConnectDetailUI.UIData detail = this.detail.v;
                    if (detail != null)
                    {
                        isProcess = detail.processEvent(e);
                    }
                    else
                    {
                        // Debug.LogError("detail null");
                    }
                }
            }
            return isProcess;
        }

    }

	#endregion

	#region Refresh

	#region txt

	public Text tvOnline;
	public static readonly TxtLanguage txtOnline = new TxtLanguage ();

	static StateConnectUI()
	{
		txtOnline.add (Language.Type.vi, "Có kết nối");
	}

	#endregion

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Server.State.Connect connect = this.data.connect.v.data;
				if (connect != null) {
                    // detail
                    {
                        StateConnectDetailUI.UIData detail = this.data.detail.v;
                        if (detail != null)
                        {
                            detail.connect.v = new ReferenceData<Server.State.Connect>(connect);
                        }
                        else
                        {
                            // Debug.LogError("detail null");
                        }
                    }
                    // txt
                    {
						if (tvOnline != null) {
							tvOnline.text = txtOnline.get ("Online");
						} else {
							Debug.LogError ("tvOnline null: " + this);
						}
					}
				} else {
					Debug.LogError ("connect null: " + this);
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

    public StateConnectDetailUI detailPrefab;

    public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.connect.allAddCallBack (this);
                uiData.detail.allAddCallBack(this);
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
            if (data is Server.State.Connect)
            {
                dirty = true;
                return;
            }
            if (data is StateConnectDetailUI.UIData)
            {
                StateConnectDetailUI.UIData detailUIData = data as StateConnectDetailUI.UIData;
                // UI
                {
                    Transform confirmBackContainer = null;
                    {
                        GlobalViewUI.UIData globalViewUIData = detailUIData.findDataInParent<GlobalViewUI.UIData>();
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
                    UIUtils.Instantiate(detailUIData, detailPrefab, confirmBackContainer);
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
				uiData.connect.allRemoveCallBack (this);
                uiData.detail.allRemoveCallBack(this);
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
            if (data is Server.State.Connect)
            {
                return;
            }
            if (data is StateConnectDetailUI.UIData)
            {
                StateConnectDetailUI.UIData detailUIData = data as StateConnectDetailUI.UIData;
                // UI
                {
                    detailUIData.removeCallBackAndDestroy(typeof(StateConnectDetailUI));
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
        if (wrapProperty.p is UIData)
        {
            switch ((UIData.Property)wrapProperty.n)
            {
                case UIData.Property.connect:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.detail:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
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
            if (wrapProperty.p is Server.State.Connect)
            {
                return;
            }
            if (wrapProperty.p is StateConnectDetailUI.UIData)
            {
                return;
            }
        }
        Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

    #endregion

    public void onClickButtonShowDetail()
    {
        if (this.data != null)
        {
            Server.State.Connect connect = this.data.connect.v.data;
            if (connect != null)
            {
                StateConnectDetailUI.UIData detailUIData = this.data.detail.newOrOld<StateConnectDetailUI.UIData>();
                {
                    detailUIData.connect.v = new ReferenceData<Server.State.Connect>(connect);
                }
                this.data.detail.v = detailUIData;
            }
            else
            {
                Debug.LogError("connect null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}
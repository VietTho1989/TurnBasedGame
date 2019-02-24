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

		public VP<StateDisconnectDetailUI.UIData> detail;

		#region Constructor

		public enum Property
		{
			disconnect,
			detail
		}

		public UIData() : base()
		{
			this.disconnect = new VP<ReferenceData<Server.State.Disconnect>>(this, (byte)Property.disconnect, new ReferenceData<Server.State.Disconnect>(null));
            this.detail = new VP<StateDisconnectDetailUI.UIData>(this, (byte)Property.detail, new StateDisconnectDetailUI.UIData());
		}

		#endregion

		public override Server.State.Type getType ()
		{
			return Server.State.Type.Disconnect;
		}

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // detail
                if (!isProcess)
                {
                    StateDisconnectDetailUI.UIData detail = this.detail.v;
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

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Server.State.Disconnect disconnect = this.data.disconnect.v.data;
				if (disconnect != null) {
                    // detail
                    {
                        StateDisconnectDetailUI.UIData detail = this.data.detail.v;
                        if (detail != null)
                        {
                            detail.disconnect.v = new ReferenceData<Server.State.Disconnect>(disconnect);
                        }
                        else
                        {
                            Debug.LogError("detail null");
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

    public StateDisconnectDetailUI detailPrefab;

	public override void onAddCallBack<T> (T data)
	{
		if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.disconnect.allAddCallBack(this);
                uiData.detail.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is Server.State.Disconnect)
            {
                dirty = true;
                return;
            }
            if(data is StateDisconnectDetailUI.UIData)
            {
                StateDisconnectDetailUI.UIData detailUIData = data as StateDisconnectDetailUI.UIData;
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
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.disconnect.allRemoveCallBack(this);
                uiData.detail.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is Server.State.Disconnect)
            {
                return;
            }
            if (data is StateDisconnectDetailUI.UIData)
            {
                StateDisconnectDetailUI.UIData detailUIData = data as StateDisconnectDetailUI.UIData;
                // UI
                {
                    detailUIData.removeCallBackAndDestroy(typeof(StateDisconnectDetailUI));
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
        if (wrapProperty.p is UIData)
        {
            switch ((UIData.Property)wrapProperty.n)
            {
                case UIData.Property.disconnect:
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
        // Child
        {
            if (wrapProperty.p is Server.State.Disconnect)
            {
                return;
            }
            if (wrapProperty.p is StateDisconnectDetailUI.UIData)
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
            Server.State.Disconnect disconnect = this.data.disconnect.v.data;
            if (disconnect != null)
            {
                StateDisconnectDetailUI.UIData detailUIData = this.data.detail.newOrOld<StateDisconnectDetailUI.UIData>();
                {
                    detailUIData.disconnect.v = new ReferenceData<Server.State.Disconnect>(disconnect);
                }
                this.data.detail.v = detailUIData;
            }
            else
            {
                Debug.LogError("disconnect null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeUseRuleStateAskUI : UIBehavior<RequestChangeUseRuleStateAskUI.UIData>
{

	#region UIData

	public class UIData : RequestChangeUseRuleUI.UIData.Sub
	{

		public VP<ReferenceData<RequestChangeUseRuleStateAsk>> requestChangeUseRuleStateAsk;

		public VP<RequestChangeUseRuleWhoAskAdapter.UIData> whoAskAdapter;

		public VP<RequestChangeUseRuleStateAskBtnAcceptUI.UIData> btnAccept;

		public VP<RequestChangeUseRuleStateAskBtnRefuseUI.UIData> btnRefuse;

		#region Constructor

		public enum Property
		{
			requestChangeUseRuleStateAsk,
			whoAskAdapter,
			btnAccept,
			btnRefuse
		}

		public UIData() : base()
		{
			this.requestChangeUseRuleStateAsk = new VP<ReferenceData<RequestChangeUseRuleStateAsk>>(this, (byte)Property.requestChangeUseRuleStateAsk, new ReferenceData<RequestChangeUseRuleStateAsk>(null));
			this.whoAskAdapter = new VP<RequestChangeUseRuleWhoAskAdapter.UIData>(this, (byte)Property.whoAskAdapter, new RequestChangeUseRuleWhoAskAdapter.UIData());
			this.btnAccept = new VP<RequestChangeUseRuleStateAskBtnAcceptUI.UIData>(this, (byte)Property.btnAccept, new RequestChangeUseRuleStateAskBtnAcceptUI.UIData());
			this.btnRefuse = new VP<RequestChangeUseRuleStateAskBtnRefuseUI.UIData>(this, (byte)Property.btnRefuse, new RequestChangeUseRuleStateAskBtnRefuseUI.UIData());
		}

		#endregion

		public override RequestChangeUseRule.State.Type getType ()
		{
			return RequestChangeUseRule.State.Type.Ask;
		}

	}

	#endregion

	#region Refresh

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				RequestChangeUseRuleStateAsk requestChangeUseRuleStateAsk = this.data.requestChangeUseRuleStateAsk.v.data;
				if (requestChangeUseRuleStateAsk != null) {
					// whoAskAdapter
					{
						RequestChangeUseRuleWhoAskAdapter.UIData whoAskAdapter = this.data.whoAskAdapter.v;
						if (whoAskAdapter != null) {
							whoAskAdapter.requestChangeUseRuleStateAsk.v = new ReferenceData<RequestChangeUseRuleStateAsk> (requestChangeUseRuleStateAsk);
						} else {
							Debug.LogError ("whoAskAdapter null: " + this);
						}
					}
					// btnAccept
					{
						RequestChangeUseRuleStateAskBtnAcceptUI.UIData btnAccept = this.data.btnAccept.v;
						if (btnAccept != null) {
							btnAccept.requestChangeUseRuleStateAsk.v = new ReferenceData<RequestChangeUseRuleStateAsk> (requestChangeUseRuleStateAsk);
						} else {
							Debug.LogError ("btnAccept null: " + this);
						}
					}
					// btnRefuse
					{
						RequestChangeUseRuleStateAskBtnRefuseUI.UIData btnRefuse = this.data.btnRefuse.v;
						if (btnRefuse != null) {
							btnRefuse.requestChangeUseRuleStateAsk.v = new ReferenceData<RequestChangeUseRuleStateAsk> (requestChangeUseRuleStateAsk);
						} else {
							Debug.LogError ("btnAccept null: " + this);
						}
					}
				} else {
					Debug.LogError ("requestChangeUseRuleStateAsk null: " + this);
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

	public RequestChangeUseRuleWhoAskAdapter whoAskAdapterPrefab;
	public Transform whoAskAdapterContainer;

	public RequestChangeUseRuleStateAskBtnAcceptUI btnAcceptPrefab;
	public Transform btnAcceptContainer;

	public RequestChangeUseRuleStateAskBtnRefuseUI btnRefusePrefab;
	public Transform btnRefuseContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.requestChangeUseRuleStateAsk.allAddCallBack (this);
				uiData.whoAskAdapter.allAddCallBack (this);
				uiData.btnAccept.allAddCallBack (this);
				uiData.btnRefuse.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is RequestChangeUseRuleStateAsk) {
				dirty = true;
				return;
			}
			if (data is RequestChangeUseRuleWhoAskAdapter.UIData) {
				RequestChangeUseRuleWhoAskAdapter.UIData whoAskAdapter = data as RequestChangeUseRuleWhoAskAdapter.UIData;
				// UI
				{
					UIUtils.Instantiate (whoAskAdapter, whoAskAdapterPrefab, whoAskAdapterContainer);
				}
				dirty = true;
				return;
			}
			if (data is RequestChangeUseRuleStateAskBtnAcceptUI.UIData) {
				RequestChangeUseRuleStateAskBtnAcceptUI.UIData btnAccept = data as RequestChangeUseRuleStateAskBtnAcceptUI.UIData;
				// UI
				{
					UIUtils.Instantiate (btnAccept, btnAcceptPrefab, btnAcceptContainer);
				}
				dirty = true;
				return;
			}
			if (data is RequestChangeUseRuleStateAskBtnRefuseUI.UIData) {
				RequestChangeUseRuleStateAskBtnRefuseUI.UIData btnRefuse = data as RequestChangeUseRuleStateAskBtnRefuseUI.UIData;
				// UI
				{
					UIUtils.Instantiate (btnRefuse, btnRefusePrefab, btnRefuseContainer);
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
				uiData.requestChangeUseRuleStateAsk.allRemoveCallBack (this);
				uiData.whoAskAdapter.allRemoveCallBack (this);
				uiData.btnAccept.allRemoveCallBack (this);
				uiData.btnRefuse.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is RequestChangeUseRuleStateAsk) {
				return;
			}
			if (data is RequestChangeUseRuleWhoAskAdapter.UIData) {
				RequestChangeUseRuleWhoAskAdapter.UIData whoAskAdapter = data as RequestChangeUseRuleWhoAskAdapter.UIData;
				// UI
				{
					whoAskAdapter.removeCallBackAndDestroy (typeof(RequestChangeUseRuleWhoAskAdapter));
				}
				return;
			}
			if (data is RequestChangeUseRuleStateAskBtnAcceptUI.UIData) {
				RequestChangeUseRuleStateAskBtnAcceptUI.UIData btnAccept = data as RequestChangeUseRuleStateAskBtnAcceptUI.UIData;
				// UI
				{
					btnAccept.removeCallBackAndDestroy (typeof(RequestChangeUseRuleStateAskBtnAcceptUI));
				}
				return;
			}
			if (data is RequestChangeUseRuleStateAskBtnRefuseUI.UIData) {
				RequestChangeUseRuleStateAskBtnRefuseUI.UIData btnRefuse = data as RequestChangeUseRuleStateAskBtnRefuseUI.UIData;
				// UI
				{
					btnRefuse.removeCallBackAndDestroy (typeof(RequestChangeUseRuleStateAskBtnRefuseUI));
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
			case UIData.Property.requestChangeUseRuleStateAsk:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.whoAskAdapter:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.btnAccept:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.btnRefuse:
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
			if (wrapProperty.p is RequestChangeUseRuleStateAsk) {
				switch ((RequestChangeUseRuleStateAsk.Property)wrapProperty.n) {
				case RequestChangeUseRuleStateAsk.Property.accepts:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is RequestChangeUseRuleWhoAskAdapter.UIData) {
				return;
			}
			if (wrapProperty.p is RequestChangeUseRuleStateAskBtnAcceptUI.UIData) {
				return;
			}
			if (wrapProperty.p is RequestChangeUseRuleStateAskBtnRefuseUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RequestDrawUI : UIBehavior<RequestDrawUI.UIData>
{

	#region UIData

	public class UIData : Data
	{
		public VP<ReferenceData<RequestDraw>> requestDraw;

		#region Sub

		public abstract class Sub : Data
		{
			public abstract RequestDraw.State.Type getType();
		}

		public VP<Sub> sub;

		#endregion

		#region Constructor

		public enum Property
		{
			requestDraw,
			sub
		}

		public UIData() : base()
		{
			this.requestDraw = new VP<ReferenceData<RequestDraw>>(this, (byte)Property.requestDraw, new ReferenceData<RequestDraw>(null));
			this.sub = new VP<Sub>(this, (byte)Property.sub, null);
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
				RequestDraw requestDraw = this.data.requestDraw.v.data;
				if (requestDraw != null) {
					// stateUI
					{
						RequestDraw.State state = requestDraw.state.v;
						if (state != null) {
							switch (state.getType ()) {
							case RequestDraw.State.Type.None:
								{
									RequestDrawStateNone stateNone = state as RequestDrawStateNone;
									// UIData
									RequestDrawStateNoneUI.UIData stateNoneUIData = this.data.sub.newOrOld<RequestDrawStateNoneUI.UIData>();
									{
										stateNoneUIData.requestDrawStateNone.v = new ReferenceData<RequestDrawStateNone> (stateNone);
									}
									this.data.sub.v = stateNoneUIData;
								}
								break;
							case RequestDraw.State.Type.Ask:
								{
									RequestDrawStateAsk stateAsk = state as RequestDrawStateAsk;
									// UIData
									RequestDrawStateAskUI.UIData stateAskUIData = this.data.sub.newOrOld<RequestDrawStateAskUI.UIData>();
									{
										stateAskUIData.requestDrawStateAsk.v = new ReferenceData<RequestDrawStateAsk> (stateAsk);
									}
									this.data.sub.v = stateAskUIData;
								}
								break;
							case RequestDraw.State.Type.Accept:
								{
									RequestDrawStateAccept stateAccept = state as RequestDrawStateAccept;
									// UIData
									RequestDrawStateAcceptUI.UIData stateAcceptUIData = this.data.sub.newOrOld<RequestDrawStateAcceptUI.UIData>();
									{
										stateAcceptUIData.requestDrawStateAccept.v = new ReferenceData<RequestDrawStateAccept> (stateAccept);
									}
									this.data.sub.v = stateAcceptUIData;
								}
								break;
							case RequestDraw.State.Type.Cancel:
								{
									RequestDrawStateCancel stateCancel = state as RequestDrawStateCancel;
									// UIData
									RequestDrawStateCancelUI.UIData stateCancelUIData = this.data.sub.newOrOld<RequestDrawStateCancelUI.UIData>();
									{
										stateCancelUIData.requestDrawStateCancel.v = new ReferenceData<RequestDrawStateCancel> (stateCancel);
									}
									this.data.sub.v = stateCancelUIData;
								}
								break;
							default:
								Debug.LogError ("unknown type: " + state.getType ());
								break;
							}
						} else {
							Debug.LogError ("state null: " + this);
						}
					}
				} else {
					// Debug.LogError ("requestDraw null: " + this);
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

	public RequestDrawStateNoneUI nonePrefab;
	public RequestDrawStateAskUI askPrefab;
	public RequestDrawStateAcceptUI acceptPrefab;
	public RequestDrawStateCancelUI cancelPrefab;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.requestDraw.allAddCallBack (this);
				uiData.sub.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				switch (sub.getType ()) {
				case RequestDraw.State.Type.None:
					{
						RequestDrawStateNoneUI.UIData subUIData = sub as RequestDrawStateNoneUI.UIData;
						UIUtils.Instantiate (subUIData, nonePrefab, this.transform);
					}
					break;
				case RequestDraw.State.Type.Ask:
					{
						RequestDrawStateAskUI.UIData subUIData = sub as RequestDrawStateAskUI.UIData;
						UIUtils.Instantiate (subUIData, askPrefab, this.transform);
					}
					break;
				case RequestDraw.State.Type.Accept:
					{
						RequestDrawStateAcceptUI.UIData subUIData = sub as RequestDrawStateAcceptUI.UIData;
						UIUtils.Instantiate (subUIData, acceptPrefab, this.transform);
					}
					break;
				case RequestDraw.State.Type.Cancel:
					{
						RequestDrawStateCancelUI.UIData subUIData = sub as RequestDrawStateCancelUI.UIData;
						UIUtils.Instantiate (subUIData, cancelPrefab, this.transform);
					}
					break;
				default:
					Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
					break;
				}
				return;
			}
			if (data is RequestDraw) {
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
				uiData.requestDraw.allRemoveCallBack (this);
				uiData.sub.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				switch (sub.getType ()) {
				case RequestDraw.State.Type.None:
					{
						RequestDrawStateNoneUI.UIData subUIData = sub as RequestDrawStateNoneUI.UIData;
						subUIData.removeCallBackAndDestroy(typeof(RequestDrawStateNoneUI));
					}
					break;
				case RequestDraw.State.Type.Ask:
					{
						RequestDrawStateAskUI.UIData subUIData = sub as RequestDrawStateAskUI.UIData;
						subUIData.removeCallBackAndDestroy(typeof(RequestDrawStateAskUI));
					}
					break;
				case RequestDraw.State.Type.Accept:
					{
						RequestDrawStateAcceptUI.UIData subUIData = sub as RequestDrawStateAcceptUI.UIData;
						subUIData.removeCallBackAndDestroy(typeof(RequestDrawStateAcceptUI));
					}
					break;
				case RequestDraw.State.Type.Cancel:
					{
						RequestDrawStateCancelUI.UIData subUIData = sub as RequestDrawStateCancelUI.UIData;
						subUIData.removeCallBackAndDestroy(typeof(RequestDrawStateCancelUI));
					}
					break;
				default:
					Debug.LogError ("unknown type: " + sub.getType ());
					break;
				}
				return;
			}
			if (data is RequestDraw) {
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
			case UIData.Property.requestDraw:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.sub:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		if (wrapProperty.p is RequestDraw) {
			switch ((RequestDraw.Property)wrapProperty.n) {
			case RequestDraw.Property.state:
				dirty = true;
				break;
			case RequestDraw.Property.time:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		if (wrapProperty.p is UIData.Sub) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientInputUI : UIBehavior<ClientInputUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<ClientInput>> clientInput;

		#region Sub

		public abstract class Sub : Data
		{
			public abstract ClientInput.Sub.Type getType ();
		}

		public VP<Sub> sub;

		#endregion

		#region Constructor

		public enum Property
		{
			clientInput,
			sub
		}

		public UIData() : base()
		{
			this.clientInput = new VP<ReferenceData<ClientInput>>(this, (byte)Property.clientInput, new ReferenceData<ClientInput>(null));
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
				ClientInput clientInput = this.data.clientInput.v.data;
				if (clientInput != null) {
					if (clientInput.sub.v != null) {
						switch (clientInput.sub.v.getType ()) {
						case ClientInput.Sub.Type.None:
							{
								ClientInputNone none = clientInput.sub.v as ClientInputNone;
								// UIData
								ClientInputNoneUI.UIData noneUIData = this.data.sub.newOrOld<ClientInputNoneUI.UIData>();
								{
									noneUIData.clientInputNone.v = new ReferenceData<ClientInputNone> (none);
								}
								this.data.sub.v = noneUIData;
							}
							break;
						case ClientInput.Sub.Type.Send:
							{
								ClientInputSend send = clientInput.sub.v as ClientInputSend;
								// UIData
								ClientInputSendUI.UIData sendUIData = this.data.sub.newOrOld<ClientInputSendUI.UIData>();
								{
									sendUIData.clientInputSend.v = new ReferenceData<ClientInputSend> (send);
								}
								this.data.sub.v = sendUIData;
							}
							break;
						default:
							Debug.LogError ("unknown sub: " + clientInput.sub.v + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("sub null: " + this);
					}
				} else {
					// Debug.LogError ("clientInput null: " + this);
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

	public Transform subContainer;
	public ClientInputNoneUI nonePrefab;
	public ClientInputSendUI sendPrefab;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.sub.allAddCallBack (this);
				uiData.clientInput.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				{
					switch (sub.getType ()) {
					case ClientInput.Sub.Type.None:
						{
							ClientInputNoneUI.UIData noneUIData = sub as ClientInputNoneUI.UIData;
							UIUtils.Instantiate (noneUIData, nonePrefab, subContainer);
						}
						break;
					case ClientInput.Sub.Type.Send:
						{
							ClientInputSendUI.UIData sendUIData = sub as ClientInputSendUI.UIData;
							UIUtils.Instantiate (sendUIData, sendPrefab, subContainer);
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
						break;
					}
				}
				dirty = true;
				return;
			}
			// ClientInput
			{
				if (data is ClientInput) {
					ClientInput clientInput = data as ClientInput;
					{
						clientInput.sub.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				if (data is ClientInput.Sub) {
					dirty = true;
					return;
				}
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
				uiData.sub.allRemoveCallBack (this);
				uiData.clientInput.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				{
					switch (sub.getType ()) {
					case ClientInput.Sub.Type.None:
						{
							ClientInputNoneUI.UIData noneUIData = sub as ClientInputNoneUI.UIData;
							noneUIData.removeCallBackAndDestroy (typeof(ClientInputNoneUI));
						}
						break;
					case ClientInput.Sub.Type.Send:
						{
							ClientInputSendUI.UIData sendUIData = sub as ClientInputSendUI.UIData;
							sendUIData.removeCallBackAndDestroy (typeof(ClientInputSendUI));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
						break;
					}
				}
				return;
			}
			// ClientInput
			{
				if (data is ClientInput) {
					ClientInput clientInput = data as ClientInput;
					{
						clientInput.sub.allRemoveCallBack (this);
					}
					return;
				}
				if (data is ClientInput.Sub) {
					return;
				}
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
			case UIData.Property.clientInput:
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
		// Child
		{
			if (wrapProperty.p is UIData.Sub) {
				return;
			}
			// ClientInput
			{
				if (wrapProperty.p is ClientInput) {
					switch ((ClientInput.Property)wrapProperty.n) {
					case ClientInput.Property.sub:
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
				if (wrapProperty.p is ClientInput.Sub) {
					return;
				}
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class LoginStateUI : UIBehavior<LoginStateUI.UIData>
{

	#region UIData

	public class UIData : Data
	{
		
		public VP<ReferenceData<Login>> login;

		#region Sub

		public abstract class Sub : Data
		{

			public abstract Login.State.Type getType ();

		}

		public VP<Sub> sub;

		#endregion

		#region Constructor

		public enum Property
		{
			login,
			sub
		}

		public UIData() : base()
		{
			this.login = new VP<ReferenceData<Login>>(this, (byte)Property.login, new ReferenceData<Login>(null));
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
				Login login = this.data.login.v.data;
				if (login != null) {
					Login.State state = login.state.v;
					if (state != null) {
						switch (state.getType ()) {
						case Login.State.Type.None:
							{
								LoginState.None none = state as LoginState.None;
								// UIData
								LoginState.NoneUI.UIData noneUIData = this.data.sub.newOrOld<LoginState.NoneUI.UIData>();
								{
									noneUIData.none.v = new ReferenceData<LoginState.None> (none);
								}
								this.data.sub.v = noneUIData;
							}
							break;
						case Login.State.Type.Log:
							{
								LoginState.Log log = state as LoginState.Log;
								// UIData
								LoginState.LogUI.UIData logUIData = this.data.sub.newOrOld<LoginState.LogUI.UIData>();
								{
									logUIData.log.v = new ReferenceData<LoginState.Log> (log);
								}
								this.data.sub.v = logUIData;
							}
							break;
						default:
							Debug.LogError ("unknown type: " + state.getType () + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("state null: " + this);
					}
				} else {
					Debug.LogError ("login null: " + this);
				}
			} else {
				Debug.LogError ("data null");
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public LoginState.NoneUI nonePrefab;
	public LoginState.LogUI logPrefab;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.login.allAddCallBack (this);
				uiData.sub.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is Login) {
				dirty = true;
				return;
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case Login.State.Type.None:
						{
							LoginState.NoneUI.UIData noneUIData = sub as LoginState.NoneUI.UIData;
							UIUtils.Instantiate (noneUIData, nonePrefab, this.transform);
						}
						break;
					case Login.State.Type.Log:
						{
							LoginState.LogUI.UIData logUIData = sub as LoginState.LogUI.UIData;
							UIUtils.Instantiate (logUIData, logPrefab, this.transform);
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
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.login.allRemoveCallBack (this);
				uiData.sub.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is Login) {
				return;	
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case Login.State.Type.None:
						{
							LoginState.NoneUI.UIData noneUIData = sub as LoginState.NoneUI.UIData;
							noneUIData.removeCallBackAndDestroy (typeof(LoginState.NoneUI));
						}
						break;
					case Login.State.Type.Log:
						{
							LoginState.LogUI.UIData logUIData = sub as LoginState.LogUI.UIData;
							logUIData.removeCallBackAndDestroy (typeof(LoginState.LogUI));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
						break;
					}
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
			case UIData.Property.login:
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
			if (wrapProperty.p is Login) {
				switch ((Login.Property)wrapProperty.n) {
				case Login.Property.state:
					dirty = true;
					break;
				case Login.Property.account:
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
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
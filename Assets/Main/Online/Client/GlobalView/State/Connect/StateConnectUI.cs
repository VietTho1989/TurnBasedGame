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

		#region Constructor

		public enum Property
		{
			connect
		}

		public UIData() : base()
		{
			this.connect = new VP<ReferenceData<Server.State.Connect>>(this, (byte)Property.connect, new ReferenceData<Server.State.Connect>(null));
		}

		#endregion

		public override Server.State.Type getType ()
		{
			return Server.State.Type.Connect;
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

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.connect.allAddCallBack (this);
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
		if (data is Server.State.Connect) {
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
			Setting.get().removeCallBack(this);
			// Child
			{
				uiData.connect.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Setting
		if (data is Setting) {
			return;
		}
		// Child
		if (data is Server.State.Connect) {
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
			case UIData.Property.connect:
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
		if (wrapProperty.p is Server.State.Connect) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
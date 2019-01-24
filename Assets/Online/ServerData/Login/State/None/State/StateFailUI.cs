using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class StateFailUI : UIBehavior<StateFailUI.UIData>
	{

		#region UIData

		public class UIData : NoneUI.UIData.Sub
		{
			public VP<ReferenceData<StateFail>> stateFail;

			#region Constructor

			public enum Property
			{
				stateFail
			}

			public UIData() : base()
			{
				this.stateFail = new VP<ReferenceData<StateFail>>(this, (byte)Property.stateFail, new ReferenceData<StateFail>(null));
			}

			#endregion

			public override None.State.Type getType ()
			{
				return None.State.Type.Fail;
			}

		}

		#endregion

		#region Refresh

		public Text tvReason;
		public static readonly TxtLanguage txtTimeOut = new TxtLanguage ();
		public static readonly TxtLanguage txtConnectFail = new TxtLanguage ();
		public static readonly TxtLanguage txtWrongPassword = new TxtLanguage ();
		public static readonly TxtLanguage txtGetFacebookDataFail = new TxtLanguage ();

		static StateFailUI()
		{
			txtTimeOut.add (Language.Type.vi, "");
			txtConnectFail.add (Language.Type.vi, "");
			txtWrongPassword.add (Language.Type.vi, "");
			txtGetFacebookDataFail.add (Language.Type.vi, "");
		}

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					StateFail stateFail = this.data.stateFail.v.data;
					if (stateFail != null) {
						// reason
						if (tvReason != null) {
							switch (stateFail.reason.v) {
							case StateFail.Reason.TimeOut:
								tvReason.text = txtTimeOut.get ("Login fail, timeout");
								break;
							case StateFail.Reason.ConnectFail:
								tvReason.text = txtConnectFail.get ("Login fail, connect fail");
								break;
							case StateFail.Reason.WrongPassword:
								tvReason.text = txtWrongPassword.get ("Login fail, email or password wrong");
								break;
							case StateFail.Reason.GetFacebookDataFail:
								tvReason.text = txtGetFacebookDataFail.get ("Login fail, get facebook data fail");
								break;
							default:
								Debug.LogError ("unknown reason: " + stateFail.reason.v + "; " + this);
								break;
							}
						} else {
							Debug.LogError ("tvReason null: " + this);
						}
					} else {
						Debug.LogError ("stateFail null: " + this);
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
					uiData.stateFail.allAddCallBack (this);
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
			if (data is StateFail) {
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
					uiData.stateFail.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Setting
			if (data is Setting) {
				return;
			}
			// Child
			if (data is StateFail) {
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
				case UIData.Property.stateFail:
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
			if (wrapProperty.p is StateFail) {
				switch ((StateFail.Property)wrapProperty.n) {
				case StateFail.Property.reason:
					dirty = true;
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

	}
}
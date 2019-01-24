using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class NoneUI : UIBehavior<NoneUI.UIData>
	{

		#region UIData

		public class UIData : LoginStateUI.UIData.Sub
		{

			public VP<ReferenceData<None>> none;

			#region Sub

			public abstract class Sub : Data
			{
				public abstract None.State.Type getType();
			}

			public VP<Sub> sub;

			#endregion

			#region Constructor

			public enum Property
			{
				none,
				sub
			}

			public UIData() : base()
			{
				this.none = new VP<ReferenceData<None>>(this, (byte)Property.none, new ReferenceData<None>(null));
				this.sub = new VP<Sub>(this, (byte)Property.sub, null);
			}

			#endregion

			public override Login.State.Type getType ()
			{
				return Login.State.Type.None;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text tvLogin;
		public static readonly TxtLanguage txtLogin = new TxtLanguage();

		static NoneUI()
		{
			txtLogin.add (Language.Type.vi, "Đăng Nhập");
		}

		#endregion

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					None none = this.data.none.v.data;
					if (none != null) {
						None.State state = none.state.v;
						if (state != null) {
							switch (state.getType ()) {
							case None.State.Type.Normal:
								{
									StateNormal stateNormal = state as StateNormal;
									// UIData
									StateNormalUI.UIData stateNormalUIData = this.data.sub.newOrOld<StateNormalUI.UIData>();
									{
										stateNormalUIData.stateNormal.v = new ReferenceData<StateNormal> (stateNormal);
									}
									this.data.sub.v = stateNormalUIData;
								}
								break;
							case None.State.Type.Fail:
								{
									StateFail stateFail = state as StateFail;
									// UIData
									StateFailUI.UIData stateFailUIData = this.data.sub.newOrOld<StateFailUI.UIData>();
									{
										stateFailUIData.stateFail.v = new ReferenceData<StateFail> (stateFail);
									}
									this.data.sub.v = stateFailUIData;
								}
								break;
							case None.State.Type.Success:
								{
									StateSuccess stateSuccess = state as StateSuccess;
									// UIData
									StateSuccessUI.UIData stateSuccessUIData = this.data.sub.newOrOld<StateSuccessUI.UIData>();
									{
										stateSuccessUIData.stateSuccess.v = new ReferenceData<StateSuccess> (stateSuccess);
									}
									this.data.sub.v = stateSuccessUIData;
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
						Debug.LogError ("none null: " + this);
					}
					// txt
					{
						if (tvLogin != null) {
							tvLogin.text = txtLogin.get ("Login");
						} else {
							Debug.LogError ("tvLogin null: " + this);
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

		public StateNormalUI stateNormalPrefab;
		public StateFailUI stateFailPrefab;
		public StateSuccessUI stateSuccessPrefab;

		public Transform stateContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.none.allAddCallBack (this);
					uiData.sub.allAddCallBack (this);
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
				if (data is None) {
					dirty = true;
					return;
				}
				if (data is UIData.Sub) {
					UIData.Sub sub = data as UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case None.State.Type.Normal:
							{
								StateNormalUI.UIData stateNormalUIData = sub as StateNormalUI.UIData;
								UIUtils.Instantiate (stateNormalUIData, stateNormalPrefab, stateContainer);
							}
							break;
						case None.State.Type.Fail:
							{
								StateFailUI.UIData stateFailUIData = sub as StateFailUI.UIData;
								UIUtils.Instantiate (stateFailUIData, stateFailPrefab, stateContainer);
							}
							break;
						case None.State.Type.Success:
							{
								StateSuccessUI.UIData stateSuccessUIData = sub as StateSuccessUI.UIData;
								UIUtils.Instantiate (stateSuccessUIData, stateSuccessPrefab, stateContainer);
							}
							break;
						default:
							Debug.LogError ("Unknown type: " + sub.getType () + "; " + this);
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
				// Setting
				Setting.get().removeCallBack(this);
				// Child
				{
					uiData.none.allRemoveCallBack (this);
					uiData.sub.allRemoveCallBack (this);
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
				if (data is None) {
					return;
				}
				if (data is UIData.Sub) {
					UIData.Sub sub = data as UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case None.State.Type.Normal:
							{
								StateNormalUI.UIData stateNormalUIData = sub as StateNormalUI.UIData;
								stateNormalUIData.removeCallBackAndDestroy (typeof(StateNormalUI));
							}
							break;
						case None.State.Type.Fail:
							{
								StateFailUI.UIData stateFailUIData = sub as StateFailUI.UIData;
								stateFailUIData.removeCallBackAndDestroy (typeof(StateFailUI));
							}
							break;
						case None.State.Type.Success:
							{
								StateSuccessUI.UIData stateSuccessUIData = sub as StateSuccessUI.UIData;
								stateSuccessUIData.removeCallBackAndDestroy (typeof(StateSuccessUI));

							}
							break;
						default:
							Debug.LogError ("Unknown type: " + sub.getType () + "; " + this);
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
				case UIData.Property.none:
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
				if (wrapProperty.p is None) {
					switch ((None.Property)wrapProperty.n) {
					case None.Property.state:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is UIData.Sub) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
		}

		#endregion

		public void onClickBtnLogin()
		{
			if (this.data != null) {
				None none = this.data.none.v.data;
				if (none != null) {
					Login login = none.findDataInParent<Login> ();
					if (login != null) {
						// Chuyen sang log state
						LoginState.Log log = new LoginState.Log ();
						{
							log.uid = login.state.makeId ();
						}
						login.state.v = log;
					} else {
						Debug.LogError ("login null: " + this);
					}
				} else {
					Debug.LogError ("none null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}
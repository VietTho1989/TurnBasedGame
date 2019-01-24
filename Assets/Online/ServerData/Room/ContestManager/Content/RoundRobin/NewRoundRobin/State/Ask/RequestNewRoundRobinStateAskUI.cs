using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RequestNewRoundRobinStateAskUI : UIBehavior<RequestNewRoundRobinStateAskUI.UIData>
	{

		#region UIData

		public class UIData : RequestNewRoundRobinUI.UIData.Sub
		{

			public VP<ReferenceData<RequestNewRoundRobinStateAsk>> requestNewRoundRobinStateAsk;

			public VP<WhoCanAskAdapter.UIData> whoCanAskAdapter;

			#region Btn

			public abstract class Btn : Data
			{

				public enum Type
				{
					Accept,
					Cancel
				}

				public abstract Type getType();

			}

			public VP<Btn> btn;

			#endregion

			public enum Visibility
			{
				Show,
				Hide
			}

			public VP<Visibility> visibility;

			#region Constructor

			public enum Property
			{
				requestNewRoundRobinStateAsk,
				whoCanAskAdapter,
				btn,
				visibility
			}

			public UIData() : base()
			{
				this.requestNewRoundRobinStateAsk = new VP<ReferenceData<RequestNewRoundRobinStateAsk>>(this, (byte)Property.requestNewRoundRobinStateAsk, new ReferenceData<RequestNewRoundRobinStateAsk>(null));
				this.whoCanAskAdapter = new VP<WhoCanAskAdapter.UIData>(this, (byte)Property.whoCanAskAdapter, new WhoCanAskAdapter.UIData());
				this.btn = new VP<Btn>(this, (byte)Property.btn, null);
				this.visibility = new VP<Visibility>(this, (byte)Property.visibility, Visibility.Show);
			}

			#endregion

			public override RequestNewRoundRobin.State.Type getType ()
			{
				return RequestNewRoundRobin.State.Type.Ask;
			}

			public void reset()
			{
				this.visibility.v = Visibility.Show;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					// back
					if (!isProcess) {
						if (InputEvent.isBackEvent (e)) {
							if (this.visibility.v == Visibility.Show) {
								this.visibility.v = Visibility.Hide;
								isProcess = true;
							}
						}
					}
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		public static readonly TxtLanguage txtHide = new TxtLanguage ();
		public static readonly TxtLanguage txtShow = new TxtLanguage ();

		static RequestNewRoundRobinStateAskUI()
		{
			txtTitle.add (Language.Type.vi, "Yêu cầu vòng đấu vòng tròn mới: trạng thái hỏi");
			txtHide.add (Language.Type.vi, "Dấu yêu cầu vòng đấu vòng tròn mới");
			txtShow.add (Language.Type.vi, "Hiện yêu cầu vòng đấu vòng tròn mới");
		}

		#endregion

		public GameObject contentContainer;
		public Text tvVisibility;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					RequestNewRoundRobinStateAsk requestNewRoundRobinStateAsk = this.data.requestNewRoundRobinStateAsk.v.data;
					if (requestNewRoundRobinStateAsk != null) {
						// visibility
						{
							if (contentContainer != null && tvVisibility != null) {
								switch (this.data.visibility.v) {
								case UIData.Visibility.Show:
									{
										contentContainer.SetActive (true);
										tvVisibility.text = txtHide.get ("Hide Request New Round Robin Ask");
									}
									break;
								case UIData.Visibility.Hide:
									{
										contentContainer.SetActive (false);
										tvVisibility.text = txtShow.get ("Show Request New Round Robin Ask");
									}
									break;
								default:
									Debug.LogError ("unknown visiblity: " + this.data.visibility.v + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("contentContainer, tvVisibility null: " + this);
							}
						}
						// whoCanAskAdapter
						{
							WhoCanAskAdapter.UIData whoCanAskAdapter = this.data.whoCanAskAdapter.v;
							if (whoCanAskAdapter != null) {
								whoCanAskAdapter.requestNewRoundRobinStateAsk.v = new ReferenceData<RequestNewRoundRobinStateAsk> (requestNewRoundRobinStateAsk);
							} else {
								Debug.LogError ("whoCanAskAdapter null: " + this);
							}
						}
						// btn
						{
							uint profileId = Server.getProfileUserId (requestNewRoundRobinStateAsk);
							if (requestNewRoundRobinStateAsk.isCanAccept (profileId)) {
								RequestNewRoundRobinAskBtnAcceptUI.UIData btnAcceptUIData = this.data.btn.newOrOld<RequestNewRoundRobinAskBtnAcceptUI.UIData> ();
								{

								}
								this.data.btn.v = btnAcceptUIData;
							} else if (requestNewRoundRobinStateAsk.isCanCancel (profileId)) {
								RequestNewRoundRobinAskBtnCancelUI.UIData btnCancelUIData = this.data.btn.newOrOld<RequestNewRoundRobinAskBtnCancelUI.UIData> ();
								{

								}
								this.data.btn.v = btnCancelUIData;
							} else {
								this.data.btn.v = null;
							}
						}
					} else {
						// Debug.LogError ("requestNewRoundRobinStateAsk null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Request new roundrobin: state ask");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
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

		public WhoCanAskAdapter whoCanAskAdapterPrefab;
		public Transform whoCanAskAdapterContainer;

		public RequestNewRoundRobinAskBtnAcceptUI btnAcceptPrefab;
		public RequestNewRoundRobinAskBtnCancelUI btnCancelPrefab;
		public Transform btnContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.requestNewRoundRobinStateAsk.allAddCallBack (this);
					uiData.whoCanAskAdapter.allAddCallBack (this);
					uiData.btn.allAddCallBack (this);
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
				// RequestNewRoundRobinStateAsk
				{
					if (data is RequestNewRoundRobinStateAsk) {
						RequestNewRoundRobinStateAsk requestNewRoundRobinStateAsk = data as RequestNewRoundRobinStateAsk;
						// Reset
						{
							if (this.data != null) {
								this.data.reset ();
							} else {
								Debug.LogError ("data null: " + this);
							}
						}
						// Child
						{
							requestNewRoundRobinStateAsk.whoCanAsks.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is Human) {
							dirty = true;
							return;
						}
					}
				}
				if (data is WhoCanAskAdapter.UIData) {
					WhoCanAskAdapter.UIData whoCanAskAdapterUIData = data as WhoCanAskAdapter.UIData;
					// UI
					{
						UIUtils.Instantiate (whoCanAskAdapterUIData, whoCanAskAdapterPrefab, whoCanAskAdapterContainer);
					}
					dirty = true;
					return;
				}
				if (data is UIData.Btn) {
					UIData.Btn btn = data as UIData.Btn;
					// UI
					{
						switch (btn.getType ()) {
						case UIData.Btn.Type.Accept:
							{
								RequestNewRoundRobinAskBtnAcceptUI.UIData btnAcceptUIData = btn as RequestNewRoundRobinAskBtnAcceptUI.UIData;
								UIUtils.Instantiate (btnAcceptUIData, btnAcceptPrefab, btnContainer);
							}
							break;
						case UIData.Btn.Type.Cancel:
							{
								RequestNewRoundRobinAskBtnCancelUI.UIData btnCancelUIData = btn as RequestNewRoundRobinAskBtnCancelUI.UIData;
								UIUtils.Instantiate (btnCancelUIData, btnCancelPrefab, btnContainer);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + btn.getType () + "; " + this);
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
					uiData.requestNewRoundRobinStateAsk.allRemoveCallBack (this);
					uiData.whoCanAskAdapter.allRemoveCallBack (this);
					uiData.btn.allRemoveCallBack (this);
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
				// RequestNewRoundRobinStateAsk
				{
					if (data is RequestNewRoundRobinStateAsk) {
						RequestNewRoundRobinStateAsk requestNewRoundRobinStateAsk = data as RequestNewRoundRobinStateAsk;
						// Child
						{
							requestNewRoundRobinStateAsk.whoCanAsks.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is Human) {
							return;
						}
					}
				}
				if (data is WhoCanAskAdapter.UIData) {
					WhoCanAskAdapter.UIData whoCanAskAdapterUIData = data as WhoCanAskAdapter.UIData;
					// UI
					{
						whoCanAskAdapterUIData.removeCallBackAndDestroy (typeof(WhoCanAskAdapter));
					}
					return;
				}
				if (data is UIData.Btn) {
					UIData.Btn btn = data as UIData.Btn;
					// UI
					{
						switch (btn.getType ()) {
						case UIData.Btn.Type.Accept:
							{
								RequestNewRoundRobinAskBtnAcceptUI.UIData btnAcceptUIData = btn as RequestNewRoundRobinAskBtnAcceptUI.UIData;
								btnAcceptUIData.removeCallBackAndDestroy (typeof(RequestNewRoundRobinAskBtnAcceptUI));
							}
							break;
						case UIData.Btn.Type.Cancel:
							{
								RequestNewRoundRobinAskBtnCancelUI.UIData btnCancelUIData = btn as RequestNewRoundRobinAskBtnCancelUI.UIData;
								btnCancelUIData.removeCallBackAndDestroy (typeof(RequestNewRoundRobinAskBtnCancelUI));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + btn.getType () + "; " + this);
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
				case UIData.Property.requestNewRoundRobinStateAsk:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.whoCanAskAdapter:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.btn:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.visibility:
					dirty = true;
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
				// RequestNewRoundRobinStateAsk
				{
					if (wrapProperty.p is RequestNewRoundRobinStateAsk) {
						switch ((RequestNewRoundRobinStateAsk.Property)wrapProperty.n) {
						case RequestNewRoundRobinStateAsk.Property.whoCanAsks:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case RequestNewRoundRobinStateAsk.Property.accepts:
							dirty = true;
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					{
						if (wrapProperty.p is Human) {
							switch ((Human.Property)wrapProperty.n) {
							case Human.Property.playerId:
								dirty = true;
								break;
							case Human.Property.account:
								break;
							case Human.Property.state:
								break;
							case Human.Property.email:
								break;
							case Human.Property.phoneNumber:
								break;
							case Human.Property.status:
								break;
							case Human.Property.birthday:
								break;
							case Human.Property.sex:
								break;
							case Human.Property.connection:
								break;
							case Human.Property.ban:
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
					}
				}
				if (wrapProperty.p is WhoCanAskAdapter.UIData) {
					return;
				}
				if (wrapProperty.p is UIData.Btn) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnVisibility()
		{
			if (this.data != null) {
				switch (this.data.visibility.v) {
				case UIData.Visibility.Show:
					this.data.visibility.v = UIData.Visibility.Hide;
					break;
				case UIData.Visibility.Hide:
					this.data.visibility.v = UIData.Visibility.Show;
					break;
				default:
					Debug.LogError ("unknown visibility: " + this.data.visibility.v + "; " + this);
					break;
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewRoundStateAskUI : UIBehavior<RequestNewRoundStateAskUI.UIData>
	{

		#region UIData

		public class UIData : RequestNewRoundUI.UIData.Sub
		{

			public VP<ReferenceData<RequestNewRoundStateAsk>> requestNewRoundStateAsk;

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
				requestNewRoundStateAsk,
				whoCanAskAdapter,
				btn,
				visibility
			}

			public UIData() : base()
			{
				this.requestNewRoundStateAsk = new VP<ReferenceData<RequestNewRoundStateAsk>>(this, (byte)Property.requestNewRoundStateAsk, new ReferenceData<RequestNewRoundStateAsk>(null));
				this.whoCanAskAdapter = new VP<WhoCanAskAdapter.UIData>(this, (byte)Property.whoCanAskAdapter, new WhoCanAskAdapter.UIData());
				this.btn = new VP<Btn>(this, (byte)Property.btn, null);
				this.visibility = new VP<Visibility>(this, (byte)Property.visibility, Visibility.Show);
			}

			#endregion

			public override RequestNewRound.State.Type getType ()
			{
				return RequestNewRound.State.Type.Ask;
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

		public GameObject contentContainer;
		public Text tvVisibility;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					RequestNewRoundStateAsk requestNewRoundStateAsk = this.data.requestNewRoundStateAsk.v.data;
					if (requestNewRoundStateAsk != null) {
						// visibility
						{
							if (contentContainer != null && tvVisibility != null) {
								switch (this.data.visibility.v) {
								case UIData.Visibility.Show:
									{
										contentContainer.SetActive (true);
										tvVisibility.text = "Hide Request New Round Ask";
									}
									break;
								case UIData.Visibility.Hide:
									{
										contentContainer.SetActive (false);
										tvVisibility.text = "Show Request New Round Ask";
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
								whoCanAskAdapter.requestNewRoundStateAsk.v = new ReferenceData<RequestNewRoundStateAsk> (requestNewRoundStateAsk);
							} else {
								Debug.LogError ("whoCanAskAdapter null: " + this);
							}
						}
						// btn
						{
							uint profileId = Server.getProfileUserId (requestNewRoundStateAsk);
							if (requestNewRoundStateAsk.isCanAccept (profileId)) {
								RequestNewRoundAskBtnAcceptUI.UIData btnAcceptUIData = this.data.btn.newOrOld<RequestNewRoundAskBtnAcceptUI.UIData> ();
								{

								}
								this.data.btn.v = btnAcceptUIData;
							} else if (requestNewRoundStateAsk.isCanCancel (profileId)) {
								RequestNewRoundAskBtnCancelUI.UIData btnCancelUIData = this.data.btn.newOrOld<RequestNewRoundAskBtnCancelUI.UIData> ();
								{

								}
								this.data.btn.v = btnCancelUIData;
							} else {
								this.data.btn.v = null;
							}
						}
					} else {
						// Debug.LogError ("requestNewRoundStateAsk null: " + this);
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

		public RequestNewRoundAskBtnAcceptUI btnAcceptPrefab;
		public RequestNewRoundAskBtnCancelUI btnCancelPrefab;
		public Transform btnContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.requestNewRoundStateAsk.allAddCallBack (this);
					uiData.whoCanAskAdapter.allAddCallBack (this);
					uiData.btn.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				// RequestNewRoundStateAsk
				{
					if (data is RequestNewRoundStateAsk) {
						RequestNewRoundStateAsk requestNewRoundStateAsk = data as RequestNewRoundStateAsk;
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
							requestNewRoundStateAsk.whoCanAsks.allAddCallBack (this);
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
								RequestNewRoundAskBtnAcceptUI.UIData btnAcceptUIData = btn as RequestNewRoundAskBtnAcceptUI.UIData;
								UIUtils.Instantiate (btnAcceptUIData, btnAcceptPrefab, btnContainer);
							}
							break;
						case UIData.Btn.Type.Cancel:
							{
								RequestNewRoundAskBtnCancelUI.UIData btnCancelUIData = btn as RequestNewRoundAskBtnCancelUI.UIData;
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
				// Child
				{
					uiData.requestNewRoundStateAsk.allRemoveCallBack (this);
					uiData.whoCanAskAdapter.allRemoveCallBack (this);
					uiData.btn.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				// RequestNewRoundStateAsk
				{
					if (data is RequestNewRoundStateAsk) {
						RequestNewRoundStateAsk requestNewRoundStateAsk = data as RequestNewRoundStateAsk;
						// Child
						{
							requestNewRoundStateAsk.whoCanAsks.allRemoveCallBack (this);
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
								RequestNewRoundAskBtnAcceptUI.UIData btnAcceptUIData = btn as RequestNewRoundAskBtnAcceptUI.UIData;
								btnAcceptUIData.removeCallBackAndDestroy (typeof(RequestNewRoundAskBtnAcceptUI));
							}
							break;
						case UIData.Btn.Type.Cancel:
							{
								RequestNewRoundAskBtnCancelUI.UIData btnCancelUIData = btn as RequestNewRoundAskBtnCancelUI.UIData;
								btnCancelUIData.removeCallBackAndDestroy (typeof(RequestNewRoundAskBtnCancelUI));
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
				case UIData.Property.requestNewRoundStateAsk:
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
			// Child
			{
				// RequestNewRoundStateAsk
				{
					if (wrapProperty.p is RequestNewRoundStateAsk) {
						switch ((RequestNewRoundStateAsk.Property)wrapProperty.n) {
						case RequestNewRoundStateAsk.Property.whoCanAsks:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case RequestNewRoundStateAsk.Property.accepts:
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
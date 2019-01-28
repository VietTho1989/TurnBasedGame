﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

namespace GameManager.ContestManager
{
	public class RequestNewContestManagerStateAskUI : UIBehavior<RequestNewContestManagerStateAskUI.UIData>
	{

		#region UIData

		public class UIData : RequestNewContestManagerUI.UIData.Sub
		{

			public VP<ReferenceData<RequestNewContestManagerStateAsk>> requestNewContestManagerStateAsk;

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
				requestNewContestManagerStateAsk,
				whoCanAskAdapter,
				btn,
				visibility
			}

			public UIData() : base()
			{
				this.requestNewContestManagerStateAsk = new VP<ReferenceData<RequestNewContestManagerStateAsk>>(this, (byte)Property.requestNewContestManagerStateAsk, new ReferenceData<RequestNewContestManagerStateAsk>(null));
				this.whoCanAskAdapter = new VP<WhoCanAskAdapter.UIData>(this, (byte)Property.whoCanAskAdapter, new WhoCanAskAdapter.UIData());
				this.btn = new VP<Btn>(this, (byte)Property.btn, null);
				this.visibility = new VP<Visibility>(this, (byte)Property.visibility, Visibility.Show);
			}

			#endregion

			public override RequestNewContestManager.State.Type getType ()
			{
				return RequestNewContestManager.State.Type.Ask;
			}

			public void reset()
			{
				this.visibility.v = Visibility.Show;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		public static readonly TxtLanguage txtHide = new TxtLanguage ();
		public static readonly TxtLanguage txtShow = new TxtLanguage ();

		static RequestNewContestManagerStateAskUI()
		{
			txtTitle.add (Language.Type.vi, "Yêu cầu tạo giải đấu mới");
			txtHide.add (Language.Type.vi, "Giấu yêu cầu tạo giải đấy mới");
			txtShow.add (Language.Type.vi, "Hiện yêu cầu tạo giải đấu mới");
		}

		#endregion

		public GameObject contentContainer;
		public Text tvVisibility;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					RequestNewContestManagerStateAsk requestNewContestManagerStateAsk = this.data.requestNewContestManagerStateAsk.v.data;
					if (requestNewContestManagerStateAsk != null) {
						// visibility
						{
							if (contentContainer != null && tvVisibility != null) {
								switch (this.data.visibility.v) {
								case UIData.Visibility.Show:
									{
										contentContainer.SetActive (true);
										tvVisibility.text = txtHide.get ("Hide Request New Tournament");
									}
									break;
								case UIData.Visibility.Hide:
									{
										contentContainer.SetActive (false);
										tvVisibility.text = txtShow.get ("Show Request New Tournament");
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
								whoCanAskAdapter.requestNewContestManagerStateAsk.v = new ReferenceData<RequestNewContestManagerStateAsk> (requestNewContestManagerStateAsk);
							} else {
								Debug.LogError ("whoCanAskAdapter null: " + this);
							}
						}
						// btn
						{
							uint profileId = Server.getProfileUserId (requestNewContestManagerStateAsk);
							if (requestNewContestManagerStateAsk.isCanAccept (profileId)) {
								RequestNewContestManagerAskBtnAcceptUI.UIData btnAcceptUIData = this.data.btn.newOrOld<RequestNewContestManagerAskBtnAcceptUI.UIData> ();
								{

								}
								this.data.btn.v = btnAcceptUIData;
							} else if (requestNewContestManagerStateAsk.isCanCancel (profileId)) {
								RequestNewContestManagerAskBtnCancelUI.UIData btnCancelUIData = this.data.btn.newOrOld<RequestNewContestManagerAskBtnCancelUI.UIData> ();
								{

								}
								this.data.btn.v = btnCancelUIData;
							} else {
								this.data.btn.v = null;
							}
						}
					} else {
						Debug.LogError ("requestNewContestManagerStateAsk null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Request New Tournament: State Ask");
						} else {
							Debug.LogError ("lbTitle null: " + this);
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

		public WhoCanAskAdapter whoCanAskAdapterPrefab;
		public Transform whoCanAskAdapterContainer;

		public RequestNewContestManagerAskBtnAcceptUI btnAcceptPrefab;
		public RequestNewContestManagerAskBtnCancelUI btnCancelPrefab;
		public Transform btnContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.requestNewContestManagerStateAsk.allAddCallBack (this);
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
				// RequestNewContestManagerStateAsk
				{
					if (data is RequestNewContestManagerStateAsk) {
						RequestNewContestManagerStateAsk requestNewContestManagerStateAsk = data as RequestNewContestManagerStateAsk;
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
							requestNewContestManagerStateAsk.whoCanAsks.allAddCallBack (this);
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
								RequestNewContestManagerAskBtnAcceptUI.UIData btnAcceptUIData = btn as RequestNewContestManagerAskBtnAcceptUI.UIData;
								UIUtils.Instantiate (btnAcceptUIData, btnAcceptPrefab, btnContainer);
							}
							break;
						case UIData.Btn.Type.Cancel:
							{
								RequestNewContestManagerAskBtnCancelUI.UIData btnCancelUIData = btn as RequestNewContestManagerAskBtnCancelUI.UIData;
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
					uiData.requestNewContestManagerStateAsk.allRemoveCallBack (this);
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
				// RequestNewContestManagerStateAsk
				{
					if (data is RequestNewContestManagerStateAsk) {
						RequestNewContestManagerStateAsk requestNewContestManagerStateAsk = data as RequestNewContestManagerStateAsk;
						// Child
						{
							requestNewContestManagerStateAsk.whoCanAsks.allRemoveCallBack (this);
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
								RequestNewContestManagerAskBtnAcceptUI.UIData btnAcceptUIData = btn as RequestNewContestManagerAskBtnAcceptUI.UIData;
								btnAcceptUIData.removeCallBackAndDestroy (typeof(RequestNewContestManagerAskBtnAcceptUI));
							}
							break;
						case UIData.Btn.Type.Cancel:
							{
								RequestNewContestManagerAskBtnCancelUI.UIData btnCancelUIData = btn as RequestNewContestManagerAskBtnCancelUI.UIData;
								btnCancelUIData.removeCallBackAndDestroy (typeof(RequestNewContestManagerAskBtnCancelUI));
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
				case UIData.Property.requestNewContestManagerStateAsk:
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
				// RequestNewContestManagerStateAsk
				{
					if (wrapProperty.p is RequestNewContestManagerStateAsk) {
						switch ((RequestNewContestManagerStateAsk.Property)wrapProperty.n) {
						case RequestNewContestManagerStateAsk.Property.whoCanAsks:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case RequestNewContestManagerStateAsk.Property.accepts:
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
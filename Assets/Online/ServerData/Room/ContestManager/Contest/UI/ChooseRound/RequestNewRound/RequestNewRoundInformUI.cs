using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewRoundInformUI : UIBehavior<RequestNewRoundInformUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<RequestNewRound>> requestNewRound;

			#region limit

			public abstract class LimitUI : Data
			{

				public abstract RequestNewRound.Limit.Type getType();

			}

			public VP<LimitUI> limitUI;

			#endregion

			#region Constructor

			public enum Property
			{
				requestNewRound,
				limitUI
			}

			public UIData() : base()
			{
				this.requestNewRound = new VP<ReferenceData<RequestNewRound>>(this, (byte)Property.requestNewRound, new ReferenceData<RequestNewRound>(null));
				this.limitUI = new VP<LimitUI>(this, (byte)Property.limitUI, null);
			}

			#endregion

			public bool processEvent(Event e)
			{
				bool isProcess = false;
				{
					// Chac la ko can
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		static RequestNewRoundInformUI()
		{
			txtTitle.add (Language.Type.vi, "Thông Tin Yêu Cầu Set Mới");
		}

		#endregion

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					RequestNewRound requestNewRound = this.data.requestNewRound.v.data;
					if (requestNewRound != null) {
						// limitUI
						{
							RequestNewRound.Limit limit = requestNewRound.limit.v;
							if (limit != null) {
								switch (limit.getType ()) {
								case RequestNewRound.Limit.Type.NoLimit:
									{
										RequestNewRoundNoLimit noLimit = limit as RequestNewRoundNoLimit;
										// UIData
										RequestNewRoundNoLimitInformUI.UIData noLimitUIData = this.data.limitUI.newOrOld<RequestNewRoundNoLimitInformUI.UIData>();
										{
											noLimitUIData.noLimit.v = new ReferenceData<RequestNewRoundNoLimit> (noLimit);
										}
										this.data.limitUI.v = noLimitUIData;
									}
									break;
								case RequestNewRound.Limit.Type.HaveLimit:
									{
										RequestNewRoundHaveLimit haveLimit = limit as RequestNewRoundHaveLimit;
										// UIData
										RequestNewRoundHaveLimitInformUI.UIData haveLimitUIData = this.data.limitUI.newOrOld<RequestNewRoundHaveLimitInformUI.UIData>();
										{
											haveLimitUIData.haveLimit.v = new ReferenceData<RequestNewRoundHaveLimit> (haveLimit);
										}
										this.data.limitUI.v = haveLimitUIData;
									}
									break;
								default:
									Debug.LogError ("unknown type: " + limit.getType () + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("limit null: " + this);
							}
						}
					} else {
						Debug.LogError ("requestNewRound null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Request New Set Inform");
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

		public RequestNewRoundNoLimitInformUI noLimitPrefab;
		public RequestNewRoundHaveLimitInformUI haveLimitPrefab;
		public Transform limitUIContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.requestNewRound.allAddCallBack (this);
					uiData.limitUI.allAddCallBack (this);
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
				if (data is RequestNewRound) {
					dirty = true;
					return;
				}
				if (data is UIData.LimitUI) {
					UIData.LimitUI limitUIData = data as UIData.LimitUI;
					// UI
					{
						switch (limitUIData.getType ()) {
						case RequestNewRound.Limit.Type.NoLimit:
							{
								RequestNewRoundNoLimitInformUI.UIData noLimitUIData = limitUIData as RequestNewRoundNoLimitInformUI.UIData;
								UIUtils.Instantiate (noLimitUIData, noLimitPrefab, limitUIContainer);
							}
							break;
						case RequestNewRound.Limit.Type.HaveLimit:
							{
								RequestNewRoundHaveLimitInformUI.UIData haveLimitUIData = limitUIData as RequestNewRoundHaveLimitInformUI.UIData;
								UIUtils.Instantiate (haveLimitUIData, haveLimitPrefab, limitUIContainer);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + limitUIData.getType () + "; " + this);
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
					uiData.requestNewRound.allRemoveCallBack (this);
					uiData.limitUI.allRemoveCallBack (this);
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
				if (data is RequestNewRound) {
					return;
				}
				if (data is UIData.LimitUI) {
					UIData.LimitUI limitUIData = data as UIData.LimitUI;
					// UI
					{
						switch (limitUIData.getType ()) {
						case RequestNewRound.Limit.Type.NoLimit:
							{
								RequestNewRoundNoLimitInformUI.UIData noLimitUIData = limitUIData as RequestNewRoundNoLimitInformUI.UIData;
								noLimitUIData.removeCallBackAndDestroy (typeof(RequestNewRoundNoLimitInformUI));
							}
							break;
						case RequestNewRound.Limit.Type.HaveLimit:
							{
								RequestNewRoundHaveLimitInformUI.UIData haveLimitUIData = limitUIData as RequestNewRoundHaveLimitInformUI.UIData;
								haveLimitUIData.removeCallBackAndDestroy (typeof(RequestNewRoundHaveLimitInformUI));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + limitUIData.getType () + "; " + this);
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
				case UIData.Property.requestNewRound:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.limitUI:
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
				if (wrapProperty.p is RequestNewRound) {
					switch ((RequestNewRound.Property)wrapProperty.n) {
					case RequestNewRound.Property.state:
						break;
					case RequestNewRound.Property.limit:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is UIData.LimitUI) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
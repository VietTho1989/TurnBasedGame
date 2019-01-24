using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RequestNewRoundRobinStateAcceptUI : UIBehavior<RequestNewRoundRobinStateAcceptUI.UIData>
	{

		#region UIData

		public class UIData : RequestNewRoundRobinUI.UIData.Sub
		{

			public VP<ReferenceData<RequestNewRoundRobinStateAccept>> requestNewRoundRobinStateAccept;

			#region Constructor

			public enum Property
			{
				requestNewRoundRobinStateAccept
			}

			public UIData() : base()
			{
				this.requestNewRoundRobinStateAccept = new VP<ReferenceData<RequestNewRoundRobinStateAccept>>(this, (byte)Property.requestNewRoundRobinStateAccept, new ReferenceData<RequestNewRoundRobinStateAccept>(null));
			}

			#endregion

			public override RequestNewRoundRobin.State.Type getType ()
			{
				return RequestNewRoundRobin.State.Type.Accept;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{

				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text tvMessage;
		public static readonly TxtLanguage txtMessage = new TxtLanguage();

		static RequestNewRoundRobinStateAcceptUI()
		{
			txtMessage.add (Language.Type.vi, "Yêu cầu vòng đấu vòng tròn mới: trạng thái đồng ý");
		}

		#endregion

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					RequestNewRoundRobinStateAccept requestNewRoundRobinStateAccept = this.data.requestNewRoundRobinStateAccept.v.data;
					if (requestNewRoundRobinStateAccept != null) {

					} else {
						Debug.LogError ("requestNewRoundRobinStateAccept null: " + this);
					}
					// txt
					{
						if (tvMessage != null) {
							tvMessage.text = txtMessage.get ("Request new round robin: state accept");
						} else {
							Debug.LogError ("tvMessage null: " + this);
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

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.requestNewRoundRobinStateAccept.allAddCallBack (this);
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
			if (data is RequestNewRoundRobinStateAccept) {
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
					uiData.requestNewRoundRobinStateAccept.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Setting
			if (data is Setting) {
				return;
			}
			// Child
			if (data is RequestNewRoundRobinStateAccept) {
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
				case UIData.Property.requestNewRoundRobinStateAccept:
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
			if (wrapProperty.p is RequestNewRoundRobinStateAccept) {
				switch ((RequestNewRoundRobinStateAccept.Property)wrapProperty.n) {
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
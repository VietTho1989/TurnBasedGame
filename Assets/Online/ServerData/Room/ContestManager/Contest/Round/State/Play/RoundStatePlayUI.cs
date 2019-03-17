using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RoundStatePlayUI : UIHaveTransformDataBehavior<RoundStatePlayUI.UIData>
	{

		#region UIData

		public class UIData : RoundState.UIData
		{

			public VP<ReferenceData<RoundStatePlay>> roundStatePlay;

			#region Constructor

			public enum Property
			{
				roundStatePlay
			}

			public UIData() : base()
			{
				this.roundStatePlay = new VP<ReferenceData<RoundStatePlay>>(this, (byte)Property.roundStatePlay, new ReferenceData<RoundStatePlay>(null));
			}

			#endregion

			public override RoundState.Type getType ()
			{
				return RoundState.Type.Play;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text tvMessage;
		public static readonly TxtLanguage txtMessage = new TxtLanguage();

		static RoundStatePlayUI()
		{
			txtMessage.add (Language.Type.vi, "Đang Chơi");
		}

		#endregion

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					RoundStatePlay roundStatePlay = this.data.roundStatePlay.v.data;
					if (roundStatePlay != null) {

					} else {
						// Debug.LogError ("roundStatePlay null: " + this);
					}
					// txt
					{
						if (tvMessage != null) {
							tvMessage.text = txtMessage.get ("Playing");
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
					uiData.roundStatePlay.allAddCallBack (this);
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
			if (data is RoundStatePlay) {
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
					uiData.roundStatePlay.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Setting
			if (data is Setting) {
				return;
			}
			// Child
			if (data is RoundStatePlay) {
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
				case UIData.Property.roundStatePlay:
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
			if (wrapProperty.p is RoundStatePlay) {
				switch ((RoundStatePlay.Property)wrapProperty.n) {
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
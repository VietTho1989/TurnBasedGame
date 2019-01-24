using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class ResultUI : UIBehavior<ResultUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<Result>> result;

			#region Constructor

			public enum Property
			{
				result
			}

			public UIData() : base()
			{
				this.result = new VP<ReferenceData<Result>>(this, (byte)Property.result, new ReferenceData<Result>(null));
			}

			#endregion

		}

		#endregion

		#region Refresh

		#region txt

		public static readonly TxtLanguage txtNotFinish = new TxtLanguage ();

		static ResultUI()
		{
			txtNotFinish.add (Language.Type.vi, "Game chưa kết thúc");
		}

		#endregion

		public Text tvResult;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Result result = this.data.result.v.data;
					if (result != null) {
						// tvResult
						if (tvResult != null) {
							tvResult.text = result.score.v + "; " + result.reason.v;
						} else {
							Debug.LogError ("tvResult null: " + this);
						}
					} else {
						// Debug.LogError ("result null: " + this);
						// tvResult
						if (tvResult != null) {
							tvResult.text = txtNotFinish.get ("Game not finish");
						} else {
							Debug.LogError ("tvResult null: " + this);
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

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.result.allAddCallBack (this);
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
			if (data is Result) {
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
					uiData.result.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Setting
			if (data is Setting) {
				return;
			}
			// Child
			if (data is Result) {
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
				case UIData.Property.result:
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
			if (wrapProperty.p is Result) {
				switch ((Result.Property)wrapProperty.n) {
				case Result.Property.playerIndex:
					dirty = true;
					break;
				case Result.Property.score:
					dirty = true;
					break;
				case Result.Property.reason:
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
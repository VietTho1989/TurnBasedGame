using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RoundStateEndUI : UIBehavior<RoundStateEndUI.UIData>
	{

		#region UIData

		public class UIData : RoundState.UIData
		{

			public VP<ReferenceData<RoundStateEnd>> roundStateEnd;

			#region Constructor

			public enum Property
			{
				roundStateEnd
			}

			public UIData() : base()
			{
				this.roundStateEnd = new VP<ReferenceData<RoundStateEnd>>(this, (byte)Property.roundStateEnd, new ReferenceData<RoundStateEnd>(null));
			}

			#endregion

			public override RoundState.Type getType ()
			{
				return RoundState.Type.End;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public static readonly TxtLanguage txtTeam = new TxtLanguage();
		public static readonly TxtLanguage txtEnd = new TxtLanguage();

		static RoundStateEndUI()
		{
			txtTeam.add (Language.Type.vi, "Đội");
			txtEnd.add (Language.Type.vi, "Kết Thúc");
		}

		#endregion

		public Text tvEnd;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					RoundStateEnd roundStateEnd = this.data.roundStateEnd.v.data;
					if (roundStateEnd != null) {
						if (tvEnd != null) {
							StringBuilder builder = new StringBuilder ();
							{
								foreach (TeamResult teamResult in roundStateEnd.teamResults.vs) {
									builder.Append (txtTeam.get ("Team") + " " + teamResult.teamIndex.v + ": " + teamResult.score.v + "; ");
								}
							}
							tvEnd.text = txtEnd.get ("End") + ": " + builder.ToString ();
						} else {
							Debug.LogError ("tvEnd null: " + this);
						}
					} else {
						Debug.LogError ("roundStateEnd null: " + this);
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
					uiData.roundStateEnd.allAddCallBack (this);
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
				if (data is RoundStateEnd) {
					RoundStateEnd roundStateEnd = data as RoundStateEnd;
					// Child
					{
						roundStateEnd.teamResults.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is TeamResult) {
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
					uiData.roundStateEnd.allRemoveCallBack (this);
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
				if (data is RoundStateEnd) {
					RoundStateEnd roundStateEnd = data as RoundStateEnd;
					// Child
					{
						roundStateEnd.teamResults.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is TeamResult) {
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
				case UIData.Property.roundStateEnd:
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
				if (wrapProperty.p is RoundStateEnd) {
					switch ((RoundStateEnd.Property)wrapProperty.n) {
					case RoundStateEnd.Property.teamResults:
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
				// Child
				if (wrapProperty.p is TeamResult) {
					switch ((TeamResult.Property)wrapProperty.n) {
					case TeamResult.Property.teamIndex:
						dirty = true;
						break;
					case TeamResult.Property.score:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
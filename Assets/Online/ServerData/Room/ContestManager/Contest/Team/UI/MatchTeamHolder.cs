using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using UnityEngine.UI;
using Foundation.Tasks;
using AdvancedCoroutines;

namespace GameManager.Match
{
	public class MatchTeamHolder : SriaHolderBehavior<MatchTeamHolder.UIData>
	{

		#region UIData

		public class UIData : BaseItemViewsHolder
		{

			public VP<ReferenceData<MatchTeam>> matchTeam;

			#region Constructor

			public enum Property
			{
				matchTeam
			}

			public UIData() : base()
			{
				this.matchTeam = new VP<ReferenceData<MatchTeam>>(this, (byte)Property.matchTeam, new ReferenceData<MatchTeam>(null));
			}

			#endregion

			public void updateView(MatchTeamAdapter.UIData myParams)
			{
				// Find MatchTeam
				MatchTeam matchTeam = null;
				{
					if (ItemIndex >= 0 && ItemIndex < myParams.matchTeams.Count) {
						matchTeam = myParams.matchTeams [ItemIndex];
					} else {
						Debug.LogError ("ItemIndex error: " + this);
					}
				}
				// Update
				this.matchTeam.v = new ReferenceData<MatchTeam> (matchTeam);
			}

		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			base.refresh ();
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					MatchTeam matchTeam = this.data.matchTeam.v.data;
					if (matchTeam != null) {

					} else {
						Debug.LogError ("matchTeam null: " + this);
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		#endregion

		#region implement callBacks

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{

				}
				this.setDataNull (uiData);
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
				case UIData.Property.matchTeam:
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
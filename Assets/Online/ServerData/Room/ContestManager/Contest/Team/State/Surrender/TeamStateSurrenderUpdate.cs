using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class TeamStateSurrenderUpdate : UpdateBehavior<TeamStateSurrender>
	{

		#region Update

		public override void update ()
		{
			if (this.data != null) {

			} else {
				Debug.LogError ("data null: " + this);
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
			if (data is TeamStateSurrender) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is TeamStateSurrender) {
				TeamStateSurrender teamStateSurrender = data as TeamStateSurrender;
				// Child
				{

				}
				this.setDataNull (teamStateSurrender);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is TeamStateSurrender) {
				switch ((TeamStateSurrender.Property)wrapProperty.n) {
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
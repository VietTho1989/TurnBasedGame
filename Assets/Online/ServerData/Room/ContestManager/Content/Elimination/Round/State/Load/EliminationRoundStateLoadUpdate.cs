using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationRoundStateLoadUpdate : UpdateBehavior<EliminationRoundStateLoad>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EliminationRound eliminationRound = this.data.findDataInParent<EliminationRound> ();
					if (eliminationRound != null) {
						EliminationRoundStateStart eliminationRoundStateStart = new EliminationRoundStateStart ();
						{
							eliminationRoundStateStart.uid = eliminationRound.state.makeId ();
						}
						eliminationRound.state.v = eliminationRoundStateStart;
					} else {
						Debug.LogError ("eliminationRound null: " + this);
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
			if (data is EliminationRoundStateLoad) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is EliminationRoundStateLoad) {
				EliminationRoundStateLoad eliminationRoundStateLoad = data as EliminationRoundStateLoad;
				// Child
				{

				}
				this.setDataNull (eliminationRoundStateLoad);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is EliminationRoundStateLoad) {
				switch ((EliminationRoundStateLoad.Property)wrapProperty.n) {
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
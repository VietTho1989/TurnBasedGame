using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationRoundStateStartUpdate : UpdateBehavior<EliminationRoundStateStart>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EliminationRound eliminationRound = this.data.findDataInParent<EliminationRound> ();
					if (eliminationRound != null) {
						EliminationRoundStatePlay eliminationRoundStatePlay = new EliminationRoundStatePlay ();
						{
							eliminationRoundStatePlay.uid = eliminationRound.state.makeId ();
						}
						eliminationRound.state.v = eliminationRoundStatePlay;
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
			if (data is EliminationRoundStateStart) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is EliminationRoundStateStart) {
				EliminationRoundStateStart eliminationRoundStateStart = data as EliminationRoundStateStart;
				// Child
				{

				}
				this.setDataNull (eliminationRoundStateStart);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is EliminationRoundStateStart) {
				switch ((EliminationRoundStateStart.Property)wrapProperty.n) {
				default:
					Debug.LogError ("Don't process: " + data + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class BracketUpdate : UpdateBehavior<Bracket>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {

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
			if (data is Bracket) {
				Bracket bracket = data as Bracket;
				// Update
				{
					UpdateUtils.makeUpdate<BracketCheckEndUpdate, Bracket> (bracket, this.transform);
				}
				// Child
				{
					bracket.bracketContests.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is BracketContest) {
				BracketContest bracketContest = data as BracketContest;
				// Update
				{
					UpdateUtils.makeUpdate<BracketContestUpdate, BracketContest> (bracketContest, this.transform);
				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is Bracket) {
				Bracket bracket = data as Bracket;
				// Update
				{
					bracket.removeCallBackAndDestroy (typeof(BracketCheckEndUpdate));
				}
				// Child
				{
					bracket.bracketContests.allRemoveCallBack (this);
				}
				this.setDataNull (bracket);
				return;
			}
			// Child
			if (data is BracketContest) {
				BracketContest bracketContest = data as BracketContest;
				// Update
				{
					bracketContest.removeCallBackAndDestroy (typeof(BracketContestUpdate));
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is Bracket) {
				switch ((Bracket.Property)wrapProperty.n) {
				case Bracket.Property.state:
					break;
				case Bracket.Property.index:
					break;
				case Bracket.Property.bracketContests:
					{
						ValueChangeUtils.replaceCallBack(this, syncs);
						dirty = true;
					}
					break;
				case Bracket.Property.byeTeamIndexs:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is BracketContest) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
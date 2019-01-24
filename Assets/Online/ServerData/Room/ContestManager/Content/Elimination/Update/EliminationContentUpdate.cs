using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationContentUpdate : UpdateBehavior<EliminationContent>
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
			if (data is EliminationContent) {
				EliminationContent eliminationContent = data as EliminationContent;
				// Update
				{
					UpdateUtils.makeUpdate<EliminationContentCheckEndUpdate, EliminationContent> (eliminationContent, this.transform);
					UpdateUtils.makeUpdate<EliminationContentMakeNewRoundUpdate, EliminationContent> (eliminationContent, this.transform);
				}
				// Child
				{
					eliminationContent.requestNewRound.allAddCallBack (this);
					eliminationContent.rounds.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is RequestNewEliminationRound) {
					RequestNewEliminationRound requestNewEliminationRound = data as RequestNewEliminationRound;
					// Update
					{
						UpdateUtils.makeUpdate<RequestNewEliminationRoundUpdate, RequestNewEliminationRound> (requestNewEliminationRound, this.transform);
					}
					dirty = true;
					return;
				}
				if (data is EliminationRound) {
					EliminationRound eliminationRound = data as EliminationRound;
					// Update
					{
						UpdateUtils.makeUpdate<EliminationRoundUpdate, EliminationRound> (eliminationRound, this.transform);
					}
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is EliminationContent) {
				EliminationContent eliminationContent = data as EliminationContent;
				// Update
				{
					eliminationContent.removeCallBackAndDestroy (typeof(EliminationContentCheckEndUpdate));
					eliminationContent.removeCallBackAndDestroy (typeof(EliminationContentMakeNewRoundUpdate));
				}
				// Child
				{
					eliminationContent.requestNewRound.allRemoveCallBack (this);
					eliminationContent.rounds.allRemoveCallBack (this);
				}
				this.setDataNull (eliminationContent);
				return;
			}
			// Child
			{
				if (data is RequestNewEliminationRound) {
					RequestNewEliminationRound requestNewEliminationRound = data as RequestNewEliminationRound;
					// Update
					{
						requestNewEliminationRound.removeCallBackAndDestroy (typeof(RequestNewEliminationRoundUpdate));
					}
					return;
				}
				if (data is EliminationRound) {
					EliminationRound eliminationRound = data as EliminationRound;
					// Update
					{
						eliminationRound.removeCallBackAndDestroy (typeof(EliminationRoundUpdate));
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
			if (wrapProperty.p is EliminationContent) {
				switch ((EliminationContent.Property)wrapProperty.n) {
				case EliminationContent.Property.singleContestFactory:
					break;
				case EliminationContent.Property.initTeamCounts:
					break;
				case EliminationContent.Property.requestNewRound:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case EliminationContent.Property.rounds:
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
			{
				if (wrapProperty.p is RequestNewEliminationRound) {
					return;
				}
				if (wrapProperty.p is EliminationRound) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
		}

		#endregion

	}
}
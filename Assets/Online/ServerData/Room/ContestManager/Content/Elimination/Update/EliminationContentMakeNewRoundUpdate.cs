using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationContentMakeNewRoundUpdate : UpdateBehavior<EliminationContent>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// check need new round
					bool needNewRound = false;
					{
						if (this.data.rounds.vs.Count == 0) {
							needNewRound = true;
						} else {
							if (this.data.requestNewRound.v.state.v.getType () == RequestNewEliminationRound.State.Type.Accept) {
								// already accept new round: check all round end
								bool allRoundEnd = true;
								{
									foreach (EliminationRound eliminationRound in this.data.rounds.vs) {
										if (eliminationRound.isActive.v) {
											if (eliminationRound.state.v.getType () != EliminationRound.State.Type.End || eliminationRound.isLastRound ()) {
												allRoundEnd = false;
												break;
											}
										}
									}
								}
								if (allRoundEnd) {
									needNewRound = true;
								}
							} else {
								// not accept new round
							}
						}
					}
					// process
					if (needNewRound) {
						EliminationRound eliminationRound = new EliminationRound ();
						{
							eliminationRound.uid = this.data.rounds.makeId ();
							eliminationRound.index.v = this.data.rounds.vs.Count;
						}
						this.data.rounds.add (eliminationRound);
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

		private EliminationRoundCheckChange<EliminationContent> eliminationRoundCheckChange = new EliminationRoundCheckChange<EliminationContent> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is EliminationContent) {
				EliminationContent eliminationContent = data as EliminationContent;
				// CheckChange
				{
					eliminationRoundCheckChange.addCallBack (this);
					eliminationRoundCheckChange.setData (eliminationContent);
				}
				// Child
				{
					eliminationContent.requestNewRound.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is EliminationRoundCheckChange<EliminationContent>) {
				dirty = true;
				return;
			}
			// Child
			if (data is RequestNewEliminationRound) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is EliminationContent) {
				EliminationContent eliminationContent = data as EliminationContent;
				// CheckChange
				{
					eliminationRoundCheckChange.removeCallBack (this);
					eliminationRoundCheckChange.setData (null);
				}
				// Child
				{
					eliminationContent.requestNewRound.allRemoveCallBack (this);
				}
				this.setDataNull (eliminationContent);
				return;
			}
			// CheckChange
			if (data is EliminationRoundCheckChange<EliminationContent>) {
				return;
			}
			// Child
			if (data is RequestNewEliminationRound) {
				return;
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
						ValueChangeUtils.replaceCallBack(this, syncs);
						dirty = true;
					}
					break;
				case EliminationContent.Property.rounds:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if (wrapProperty.p is EliminationRoundCheckChange<EliminationContent>) {
				dirty = true;
				return;
			}
			// Child
			if (wrapProperty.p is RequestNewEliminationRound) {
				switch ((RequestNewEliminationRound.Property)wrapProperty.n) {
				case RequestNewEliminationRound.Property.state:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		#endregion

	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class MakeNewRoundUpdate : UpdateBehavior<Contest>
	{

		#region update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (this.data.rounds.vs.Count == 0) {
						// first round
						Round round = this.data.roundFactory.v.makeRound ();
						{
							round.uid = this.data.rounds.makeId ();
						}
						this.data.rounds.add (round);
					} else {
						// Check need make new round
						bool needMakeNewRound = false;
						{
							RequestNewRound requestNewRound = this.data.requestNewRound.v;
							if (requestNewRound != null) {
								if (requestNewRound.isCanMakeNewRound ()) {
									if (requestNewRound.state.v.getType () == RequestNewRound.State.Type.Accept) {
										needMakeNewRound = true;
									}
								}
							} else {
								Debug.LogError ("requestNewRound null: " + this);
							}
						}
						// Make new round
						if (needMakeNewRound) {
							Round round = this.data.roundFactory.v.makeRound ();
							{
								round.uid = this.data.rounds.makeId ();
							}
							this.data.rounds.add (round);
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

		private CheckCanMakeNewRoundChange<Contest> checkCanMakeNewRoundChange = new CheckCanMakeNewRoundChange<Contest>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is Contest) {
				Contest contest = data as Contest;
				// CheckChange
				{
					checkCanMakeNewRoundChange.addCallBack (this);
					checkCanMakeNewRoundChange.setData (contest);
				}
				// Child
				{
					contest.requestNewRound.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is CheckCanMakeNewRoundChange<Contest>) {
				dirty = true;
				return;
			}
			// Child
			{
				if (data is RequestNewRound) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is Contest) {
				Contest contest = data as Contest;
				// CheckChange
				{
					checkCanMakeNewRoundChange.removeCallBack (this);
					checkCanMakeNewRoundChange.setData (null);
				}
				// Child
				{
					contest.requestNewRound.allRemoveCallBack (this);
				}
				this.setDataNull (contest);
				return;
			}
			// CheckChange
			if (data is CheckCanMakeNewRoundChange<Contest>) {
				return;
			}
			// Child
			{
				if (data is RequestNewRound) {
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
			if (wrapProperty.p is Contest) {
				switch ((Contest.Property)wrapProperty.n) {
				case Contest.Property.state:
					break;
				case Contest.Property.playerPerTeam:
					break;
				case Contest.Property.teams:
					break;
				case Contest.Property.roundFactory:
					break;
				case Contest.Property.rounds:
					break;
				case Contest.Property.requestNewRound:
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
			// CheckChange
			if (wrapProperty.p is CheckCanMakeNewRoundChange<Contest>) {
				dirty = true;
				return;
			}
			// Child
			{
				if (wrapProperty.p is RequestNewRound) {
					switch ((RequestNewRound.Property)wrapProperty.n) {
					case RequestNewRound.Property.state:
						dirty = true;
						break;
					case RequestNewRound.Property.limit:
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
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationRoundCheckChange<K> : Data, ValueChangeCallBack where K : Data
	{

		public VP<int> change;

		private void notifyChange()
		{
			this.change.v = this.change.v + 1;
		}

		#region Constructor

		public enum Property
		{
			change
		}

		public EliminationRoundCheckChange() : base()
		{
			this.change = new VP<int> (this, (byte)Property.change, 0);
		}

		#endregion

		public K data;

		public void setData(K newData){
			if (this.data != newData) {
				// remove old
				{
					DataUtils.removeParentCallBack (this.data, this, ref this.eliminationContent);
				}
				// set new 
				{
					this.data = newData;
					DataUtils.addParentCallBack (this.data, this, ref this.eliminationContent);
				}
			} else {
				Debug.LogError ("the same: " + this + ", " + data + ", " + newData);
			}
		}

		#region implement callBacks

		private EliminationContent eliminationContent = null;
		private ContestManagerStatePlay contestManagerStatePlay = null;

		public void onAddCallBack<T> (T data) where T:Data
		{
			if (data is EliminationContent) {
				EliminationContent eliminationContent = data as EliminationContent;
				// Parent
				{
					DataUtils.addParentCallBack (eliminationContent, this, ref this.contestManagerStatePlay);
				}
				// Child
				{
					eliminationContent.rounds.allAddCallBack (this);
				}
				this.notifyChange ();
				return;
			}
			// Parent
			if (data is ContestManagerStatePlay) {
				this.notifyChange ();
				return;
			}
			// Child
			{
				if (data is EliminationRound) {
					EliminationRound eliminationRound = data as EliminationRound;
					// Child
					{
						eliminationRound.brackets.allAddCallBack (this);
					}
					this.notifyChange ();
					return;
				}
				// Child
				{
					if (data is Bracket) {
						Bracket bracket = data as Bracket;
						// Child
						{
							bracket.state.allAddCallBack (this);
						}
						this.notifyChange ();
						return;
					}
					// Child
					if (data is Bracket.State) {
						this.notifyChange ();
						return;
					}
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public void onRemoveCallBack<T> (T data, bool isHide) where T:Data
		{
			if (data is EliminationContent) {
				EliminationContent eliminationContent = data as EliminationContent;
				// Parent
				{
					DataUtils.removeParentCallBack (eliminationContent, this, ref this.contestManagerStatePlay);
				}
				// Child
				{
					eliminationContent.rounds.allRemoveCallBack (this);
				}
				this.eliminationContent = null;
				return;
			}
			// Parent
			if (data is ContestManagerStatePlay) {
				return;
			}
			// Child
			{
				if (data is EliminationRound) {
					EliminationRound eliminationRound = data as EliminationRound;
					// Child
					{
						eliminationRound.brackets.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is Bracket) {
						Bracket bracket = data as Bracket;
						// Child
						{
							bracket.state.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					if (data is Bracket.State) {
						return;
					}
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is EliminationContent) {
				switch ((EliminationContent.Property)wrapProperty.n) {
				case EliminationContent.Property.singleContestFactory:
					break;
				case EliminationContent.Property.initTeamCounts:
					this.notifyChange();
					break;
				case EliminationContent.Property.requestNewRound:
					break;
				case EliminationContent.Property.rounds:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						this.notifyChange ();
					}
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			if (wrapProperty.p is ContestManagerStatePlay) {
				switch ((ContestManagerStatePlay.Property)wrapProperty.n) {
				case ContestManagerStatePlay.Property.state:
					break;
				case ContestManagerStatePlay.Property.isForceEnd:
					break;
				case ContestManagerStatePlay.Property.teams:
					this.notifyChange();
					break;
				case ContestManagerStatePlay.Property.swap:
					break;
				case ContestManagerStatePlay.Property.content:
					break;
				case ContestManagerStatePlay.Property.contentTeamResult:
					break;
				case ContestManagerStatePlay.Property.gameTypeType:
					break;
				case ContestManagerStatePlay.Property.randomTeamIndex:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				if (wrapProperty.p is EliminationRound) {
					switch ((EliminationRound.Property)wrapProperty.n) {
					case EliminationRound.Property.isActive:
						this.notifyChange ();
						break;
					case EliminationRound.Property.state:
						break;
					case EliminationRound.Property.index:
						this.notifyChange();
						break;
					case EliminationRound.Property.brackets:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							this.notifyChange ();
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
					if (wrapProperty.p is Bracket) {
						switch ((Bracket.Property)wrapProperty.n) {
						case Bracket.Property.isActive:
							this.notifyChange ();
							break;
						case Bracket.Property.state:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								this.notifyChange ();
							}
							break;
						case Bracket.Property.index:
							this.notifyChange ();
							break;
						case Bracket.Property.bracketContests:
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
					if (wrapProperty.p is Bracket.State) {
						Bracket.State state = wrapProperty.p as Bracket.State;
						switch (state.getType ()) {
						case Bracket.State.Type.Play:
							break;
						case Bracket.State.Type.End:
							{
								switch ((BracketStateEnd.Property)wrapProperty.n) {
								case BracketStateEnd.Property.winTeamIndexs:
									this.notifyChange ();
									break;
								case BracketStateEnd.Property.loseTeamIndexs:
									this.notifyChange ();
									break;
								default:
									Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
									break;
								}
							}
							break;
						default:
							Debug.LogError ("unknown type: " + state.getType () + "; " + this);
							break;
						}
						return;
					}
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		#endregion

	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationRoundCheckEndUpdate : UpdateBehavior<EliminationRound>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// Find
					bool isEnd = true;
					{
						foreach (Bracket bracket in this.data.brackets.vs) {
							if (bracket.isActive.v) {
								if (bracket.state.v.getType () != Bracket.State.Type.End) {
									isEnd = false;
									break;
								}
							} else {
								Debug.LogError ("bracket not active: " + this);
							}
						}
					}
					// Process
					{
						if (isEnd) {
							// Find 
							EliminationRoundStateEnd end = null;
							{
								// find old
								if (this.data.state.v is EliminationRoundStateEnd) {
									end = this.data.state.v as EliminationRoundStateEnd;
								}
								// make new
								if (end == null) {
									end = new EliminationRoundStateEnd ();
									{
										end.uid = this.data.state.makeId ();
									}
									this.data.state.v = end;
								}
							}
							// Update
							{

							}
						} else {
							// Find
							EliminationRoundStatePlay play = null;
							{
								// find old
								if (this.data.state.v is EliminationRoundStatePlay) {
									play = this.data.state.v as EliminationRoundStatePlay;
								}
								// make new
								if (play == null) {
									play = new EliminationRoundStatePlay ();
									{
										play.uid = this.data.state.makeId ();
									}
									this.data.state.v = play;
								}
							}
							// Update
							{

							}
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

		public override void onAddCallBack<T> (T data)
		{
			if (data is EliminationRound) {
				EliminationRound eliminationRound = data as EliminationRound;
				// Child
				{
					eliminationRound.brackets.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is Bracket) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is EliminationRound) {
				EliminationRound eliminationRound = data as EliminationRound;
				// Child
				{
					eliminationRound.brackets.allRemoveCallBack (this);
				}
				this.setDataNull (eliminationRound);
				return;
			}
			// Child
			if (data is Bracket) {
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is EliminationRound) {
				switch ((EliminationRound.Property)wrapProperty.n) {
				case EliminationRound.Property.state:
					break;
				case EliminationRound.Property.index:
					break;
				case EliminationRound.Property.brackets:
					{
						ValueChangeUtils.replaceCallBack(this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("Don't process: " + data + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is Bracket) {
				switch ((Bracket.Property)wrapProperty.n) {
				case Bracket.Property.isActive:
					dirty = true;
					break;
				case Bracket.Property.state:
					dirty = true;
					break;
				case Bracket.Property.index:
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
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
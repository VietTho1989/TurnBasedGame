using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationRoundUpdate : UpdateBehavior<EliminationRound>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EliminationRound.State state = this.data.state.v;
					if (state != null) {
						// check need update
						bool needUpdate = false;
						{
							if (this.data.isActive.v) {
								switch (state.getType ()) {
								case EliminationRound.State.Type.Load:
								case EliminationRound.State.Type.Start:
									needUpdate = false;
									break;
								case EliminationRound.State.Type.Play:
								case EliminationRound.State.Type.End:
									needUpdate = true;
									break;
								default:
									Debug.LogError ("Unknown type: " + state.getType () + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("not active: " + this);
								needUpdate = false;
							}
						}
						// Process
						if (needUpdate) {
							UpdateUtils.makeUpdate<EliminationRoundMakeBracketUpdate, EliminationRound> (this.data, this.transform);
							foreach (Bracket bracket in this.data.brackets.vs) {
								UpdateUtils.makeUpdate<BracketUpdate, Bracket> (bracket, this.transform);
							}
							UpdateUtils.makeUpdate<EliminationRoundCheckEndUpdate, EliminationRound> (this.data, this.transform);
						} else {
							this.data.removeCallBackAndDestroy (typeof(EliminationRoundMakeBracketUpdate));
							foreach (Bracket bracket in this.data.brackets.vs) {
								bracket.removeCallBackAndDestroy (typeof(BracketUpdate));
							}
							this.data.removeCallBackAndDestroy (typeof(EliminationRoundCheckEndUpdate));
						}
					} else {
						Debug.LogError ("state null: " + this);
						EliminationRoundStateLoad load = new EliminationRoundStateLoad ();
						{
							load.uid = this.data.state.makeId ();
						}
						this.data.state.v = load;
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
				// Update
				{

				}
				// Child
				{
					eliminationRound.state.allAddCallBack (this);
					eliminationRound.brackets.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is EliminationRound.State) {
					EliminationRound.State state = data as EliminationRound.State;
					// Update
					{
						switch (state.getType ()) {
						case EliminationRound.State.Type.Load:
							{
								EliminationRoundStateLoad load = state as EliminationRoundStateLoad;
								UpdateUtils.makeUpdate<EliminationRoundStateLoadUpdate, EliminationRoundStateLoad> (load, this.transform);
							}
							break;
						case EliminationRound.State.Type.Start:
							{
								EliminationRoundStateStart start = state as EliminationRoundStateStart;
								UpdateUtils.makeUpdate<EliminationRoundStateStartUpdate, EliminationRoundStateStart> (start, this.transform);
							}
							break;
						case EliminationRound.State.Type.Play:
							{
								EliminationRoundStatePlay play = state as EliminationRoundStatePlay;
								UpdateUtils.makeUpdate<EliminationRoundStatePlayUpdate, EliminationRoundStatePlay> (play, this.transform);
							}
							break;
						case EliminationRound.State.Type.End:
							{
								EliminationRoundStateEnd end = state as EliminationRoundStateEnd;
								UpdateUtils.makeUpdate<EliminationRoundStateEndUpdate, EliminationRoundStateEnd> (end, this.transform);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + state.getType () + "; " + this);
							break;
						}
					}
					dirty = true;
					return;
				}
				if (data is Bracket) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is EliminationRound) {
				EliminationRound eliminationRound = data as EliminationRound;
				// Update
				{
					eliminationRound.removeCallBackAndDestroy (typeof(EliminationRoundMakeBracketUpdate));
					eliminationRound.removeCallBackAndDestroy (typeof(EliminationRoundCheckEndUpdate));
				}
				// Child
				{
					eliminationRound.state.allRemoveCallBack (this);
					eliminationRound.brackets.allRemoveCallBack (this);
				}
				this.setDataNull (eliminationRound);
				return;
			}
			// Child
			{
				if (data is EliminationRound.State) {
					EliminationRound.State state = data as EliminationRound.State;
					// Update
					{
						switch (state.getType ()) {
						case EliminationRound.State.Type.Load:
							{
								EliminationRoundStateLoad load = state as EliminationRoundStateLoad;
								load.removeCallBackAndDestroy (typeof(EliminationRoundStateLoadUpdate));
							}
							break;
						case EliminationRound.State.Type.Start:
							{
								EliminationRoundStateStart start = state as EliminationRoundStateStart;
								start.removeCallBackAndDestroy (typeof(EliminationRoundStateStartUpdate));
							}
							break;
						case EliminationRound.State.Type.Play:
							{
								EliminationRoundStatePlay play = state as EliminationRoundStatePlay;
								play.removeCallBackAndDestroy (typeof(EliminationRoundStatePlayUpdate));
							}
							break;
						case EliminationRound.State.Type.End:
							{
								EliminationRoundStateEnd end = state as EliminationRoundStateEnd;
								end.removeCallBackAndDestroy (typeof(EliminationRoundStateEndUpdate));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + state.getType () + "; " + this);
							break;
						}
					}
					return;
				}
				if (data is Bracket) {
					Bracket bracket = data as Bracket;
					// Update
					{
						bracket.removeCallBackAndDestroy (typeof(BracketUpdate));
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
			if (wrapProperty.p is EliminationRound) {
				switch ((EliminationRound.Property)wrapProperty.n) {
				case EliminationRound.Property.isActive:
					dirty = true;
					break;
				case EliminationRound.Property.state:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case EliminationRound.Property.index:
					break;
				case EliminationRound.Property.brackets:
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
				if (wrapProperty.p is EliminationRound.State) {
					return;
				}
				if (wrapProperty.p is Bracket) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
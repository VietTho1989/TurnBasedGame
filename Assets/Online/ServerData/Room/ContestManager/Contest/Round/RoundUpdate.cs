using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RoundUpdate : UpdateBehavior<Round>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					RoundState state = this.data.state.v;
					if (state != null) {
						switch (state.getType ()) {
						case RoundState.Type.Load:
						case RoundState.Type.Start:
							{
								this.data.removeCallBackAndDestroy (typeof(CheckEndRoundUpdate));
								foreach (RoundGame roundGame in this.data.roundGames.vs) {
									roundGame.removeCallBackAndDestroy (typeof(RoundGameUpdate));
								}
							}
							break;
						case RoundState.Type.Play:
						case RoundState.Type.End:
							{
								UpdateUtils.makeUpdate<CheckEndRoundUpdate, Round> (this.data, this.transform);
								foreach (RoundGame roundGame in this.data.roundGames.vs) {
									UpdateUtils.makeUpdate<RoundGameUpdate, RoundGame> (roundGame, this.transform);
								}
							}
							break;
						default:
							Debug.LogError ("unknown type: " + state.getType () + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("state null: " + this);
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
			if (data is Round) {
				Round round = data as Round;
				// Update
				{
					// o tren
				}
				// Child
				{
					round.state.allAddCallBack (this);
					// index
					round.roundGames.allAddCallBack(this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is RoundState) {
					RoundState roundState = data as RoundState;
					// Update
					{
						switch (roundState.getType ()) {
						case RoundState.Type.Load:
							{
								RoundStateLoad roundStateLoad = roundState as RoundStateLoad;
								UpdateUtils.makeUpdate<RoundStateLoadUpdate, RoundStateLoad> (roundStateLoad, this.transform);
							}
							break;
						case RoundState.Type.Start:
							{
								RoundStateStart roundStateStart = roundState as RoundStateStart;
								UpdateUtils.makeUpdate<RoundStateStartUpdate, RoundStateStart> (roundStateStart, this.transform);
							}
							break;
						case RoundState.Type.Play:
							{
								RoundStatePlay roundStatePlay = roundState as RoundStatePlay;
								UpdateUtils.makeUpdate<RoundStatePlayUpdate, RoundStatePlay> (roundStatePlay, this.transform);
							}
							break;
						case RoundState.Type.End:
							{
								RoundStateEnd roundStateEnd = roundState as RoundStateEnd;
								UpdateUtils.makeUpdate<RoundStateEndUpdate, RoundStateEnd> (roundStateEnd, this.transform);
							}
							break;
						default:
							Debug.LogError ("Unknown type: " + roundState.getType () + "; " + this);
							break;
						}
					}
					dirty = true;
					return;
				}
				if (data is RoundGame) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is Round) {
				Round round = data as Round;
				// Update
				{
					round.removeCallBackAndDestroy (typeof(CheckEndRoundUpdate));
				}
				// Child
				{
					round.state.allRemoveCallBack (this);
					// index
					round.roundGames.allRemoveCallBack(this);
				}
				this.setDataNull (round);
				return;
			}
			// Child
			{
				if (data is RoundState) {
					RoundState roundState = data as RoundState;
					// Update
					{
						switch (roundState.getType ()) {
						case RoundState.Type.Load:
							{
								RoundStateLoad roundStateLoad = roundState as RoundStateLoad;
								roundStateLoad.removeCallBackAndDestroy (typeof(RoundStateLoadUpdate));
							}
							break;
						case RoundState.Type.Start:
							{
								RoundStateStart roundStateStart = roundState as RoundStateStart;
								roundStateStart.removeCallBackAndDestroy (typeof(RoundStateStartUpdate));
							}
							break;
						case RoundState.Type.Play:
							{
								RoundStatePlay roundStatePlay = roundState as RoundStatePlay;
								roundStatePlay.removeCallBackAndDestroy (typeof(RoundStatePlayUpdate));
							}
							break;
						case RoundState.Type.End:
							{
								RoundStateEnd roundStateEnd = roundState as RoundStateEnd;
								roundStateEnd.removeCallBackAndDestroy (typeof(RoundStateEndUpdate));
							}
							break;
						default:
							Debug.LogError ("Unknown type: " + roundState.getType () + "; " + this);
							break;
						}
					}
					return;
				}
				if (data is RoundGame) {
					RoundGame roundGame = data as RoundGame;
					// Update
					{
						roundGame.removeCallBackAndDestroy (typeof(RoundGameUpdate));
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
			if (wrapProperty.p is Round) {
				switch ((Round.Property)wrapProperty.n) {
				case Round.Property.state:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case Round.Property.index:
					break;
				case Round.Property.roundGames:
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
				if (wrapProperty.p is RoundState) {
					return;
				}
				if (wrapProperty.p is RoundGame) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
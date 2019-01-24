using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match.Swap;

namespace GameManager.Match
{
	public class ContestManagerStatePlayUpdate : UpdateBehavior<ContestManagerStatePlay>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// contestManagerContentUpdate
					{
						ContestManagerContent content = this.data.content.v;
						if (content != null) {
							// Update
							if (!this.data.isForceEnd.v) {
								UpdateUtils.makeUpdate<ContestManagerContentUpdate, ContestManagerContent> (content, this.transform);
							} else {
								content.removeCallBackAndDestroy (typeof(ContestManagerContentUpdate));
							}
							// gameTypeType
							this.data.gameTypeType.v = content.getGameTypeType();
						} else {
							Debug.LogError ("content null: " + this);
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
			if (data is ContestManagerStatePlay) {
				ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
				// Update
				{
					UpdateUtils.makeUpdate<ContestManagerStatePlaySetStateUpdate, ContestManagerStatePlay> (contestManagerStatePlay, this.transform);
				}
				// Child
				{
					contestManagerStatePlay.state.allAddCallBack (this);
					contestManagerStatePlay.teams.allAddCallBack (this);
					contestManagerStatePlay.swap.allAddCallBack (this);
					contestManagerStatePlay.content.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is ContestManagerStatePlay.State) {
					ContestManagerStatePlay.State state = data as ContestManagerStatePlay.State;
					// Update
					{
						switch (state.getType ()) {
						case ContestManagerStatePlay.State.Type.Normal:
							{
								ContestManagerStatePlayNormal normal = state as ContestManagerStatePlayNormal;
								UpdateUtils.makeUpdate<ContestManagerStatePlayNormalUpdate, ContestManagerStatePlayNormal> (normal, this.transform);
							}
							break;
						case ContestManagerStatePlay.State.Type.End:
							{
								ContestManagerStatePlayEnd end = state as ContestManagerStatePlayEnd;
								UpdateUtils.makeUpdate<ContestManagerStatePlayEndUpdate, ContestManagerStatePlayEnd> (end, this.transform);
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
				if (data is MatchTeam) {
					MatchTeam matchTeam = data as MatchTeam;
					// Update
					{
						UpdateUtils.makeUpdate<MatchTeamUpdate, MatchTeam> (matchTeam, this.transform);
					}
					dirty = true;
					return;
				}
				if (data is Swap.Swap) {
					Swap.Swap swap = data as Swap.Swap;
					// Update
					{
						UpdateUtils.makeUpdate<SwapUpdate, Swap.Swap> (swap, this.transform);
					}
					dirty = true;
					return;
				}
				if (data is ContestManagerContent) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is ContestManagerStatePlay) {
				ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
				// Update
				{
					contestManagerStatePlay.removeCallBackAndDestroy (typeof(ContestManagerStatePlaySetStateUpdate));
				}
				// Child
				{
					contestManagerStatePlay.state.allRemoveCallBack (this);
					contestManagerStatePlay.teams.allRemoveCallBack (this);
					contestManagerStatePlay.swap.allRemoveCallBack (this);
					contestManagerStatePlay.content.allRemoveCallBack (this);
				}
				this.setDataNull (contestManagerStatePlay);
				return;
			}
			// Child
			{
				if (data is ContestManagerStatePlay.State) {
					ContestManagerStatePlay.State state = data as ContestManagerStatePlay.State;
					// Update
					{
						switch (state.getType ()) {
						case ContestManagerStatePlay.State.Type.Normal:
							{
								ContestManagerStatePlayNormal normal = state as ContestManagerStatePlayNormal;
								normal.removeCallBackAndDestroy (typeof(ContestManagerStatePlayNormalUpdate));
							}
							break;
						case ContestManagerStatePlay.State.Type.End:
							{
								ContestManagerStatePlayEnd end = state as ContestManagerStatePlayEnd;
								end.removeCallBackAndDestroy (typeof(ContestManagerStatePlayEndUpdate));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + state.getType () + "; " + this);
							break;
						}
					}
					return;
				}
				if (data is MatchTeam) {
					MatchTeam matchTeam = data as MatchTeam;
					// Update
					{
						matchTeam.removeCallBackAndDestroy (typeof(MatchTeamUpdate));
					}
					return;
				}
				if (data is Swap.Swap) {
					Swap.Swap swap = data as Swap.Swap;
					// Update
					{
						swap.removeCallBackAndDestroy (typeof(SwapUpdate));
					}
					return;
				}
				if (data is ContestManagerContent) {
					ContestManagerContent contestManagerContent = data as ContestManagerContent;
					// Update
					{
						contestManagerContent.removeCallBackAndDestroy (typeof(ContestManagerContentUpdate));
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
			if (wrapProperty.p is ContestManagerStatePlay) {
				switch ((ContestManagerStatePlay.Property)wrapProperty.n) {
				case ContestManagerStatePlay.Property.state:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case ContestManagerStatePlay.Property.teams:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case ContestManagerStatePlay.Property.swap:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case ContestManagerStatePlay.Property.content:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case ContestManagerStatePlay.Property.gameTypeType:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				if (wrapProperty.p is ContestManagerStatePlay.State) {
					return;
				}
				if (wrapProperty.p is MatchTeam) {
					return;
				}
				if (wrapProperty.p is Swap.Swap) {
					return;
				}
				if (wrapProperty.p is ContestManagerContent) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
		}

		#endregion

	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RoundRobinContentMakeNewRoundUpdate : UpdateBehavior<RoundRobinContent>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// find need to make new round
					bool needMakeNewRound = false;
					{
						if (this.data.roundRobins.vs.Count == 0) {
							needMakeNewRound = true;
						} else {
							// find all roundRobinEnd
							bool allRoundRobinEnd = true;
							{
								foreach (RoundRobin roundRobin in this.data.roundRobins.vs) {
									if (!(roundRobin.state.v is RoundRobinStateEnd)) {
										allRoundRobinEnd = false;
										break;
									}
								}
							}
							// Process
							if (allRoundRobinEnd) {
								// pass round count limit?
								if (this.data.roundRobins.vs.Count < this.data.getMaxRound ()) {
									// not pass max round, check request new round accept
									if (this.data.requestNewRoundRobin.v.state.v.getType () == RequestNewRoundRobin.State.Type.Accept) {
										needMakeNewRound = true;
									}
								} else {
									// pass max round
								}
							}
						}
					}
					// Make new round
					if (needMakeNewRound) {
						this.data.makeNewRound ();
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

		private ContestManagerStatePlay contestManagerStatePlay = null;
		private SingleContestFactoryCheckChange<SingleContestFactory> singleContestFactoryCheckChange = new SingleContestFactoryCheckChange<SingleContestFactory> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is RoundRobinContent) {
				RoundRobinContent roundRobinContent = data as RoundRobinContent;
				// Parent
				{
					DataUtils.addParentCallBack (roundRobinContent, this, ref contestManagerStatePlay);
				}
				// Child
				{
					roundRobinContent.singleContestFactory.allAddCallBack (this);
					roundRobinContent.roundRobins.allAddCallBack (this);
					roundRobinContent.requestNewRoundRobin.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			if (data is ContestManagerStatePlay) {
				dirty = true;
				return;
			}
			// Child
			{
				// singleContestFactory
				{
					if (data is SingleContestFactory) {
						SingleContestFactory singleContestFactory = data as SingleContestFactory;
						// CheckChange
						{
							singleContestFactoryCheckChange.addCallBack (this);
							singleContestFactoryCheckChange.setData (singleContestFactory);
						}
						dirty = true;
						return;
					}
					// CheckChange
					if (data is SingleContestFactoryCheckChange<SingleContestFactory>) {
						dirty = true;
						return;
					}
				}
				if (data is RoundRobin) {
					dirty = true;
					return;
				}
				if (data is RequestNewRoundRobin) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RoundRobinContent) {
				RoundRobinContent roundRobinContent = data as RoundRobinContent;
				// Parent
				{
					DataUtils.removeParentCallBack (roundRobinContent, this, ref contestManagerStatePlay);
				}
				// Child
				{
					roundRobinContent.singleContestFactory.allRemoveCallBack (this);
					roundRobinContent.roundRobins.allRemoveCallBack (this);
					roundRobinContent.requestNewRoundRobin.allRemoveCallBack (this);
				}
				this.setDataNull (roundRobinContent);
				return;
			}
			// Parent
			if (data is ContestManagerStatePlay) {
				return;
			}
			// Child
			{
				// singleContestFactory
				{
					if (data is SingleContestFactory) {
						// SingleContestFactory singleContestFactory = data as SingleContestFactory;
						// CheckChange
						{
							singleContestFactoryCheckChange.removeCallBack (this);
							singleContestFactoryCheckChange.setData (null);
						}
						return;
					}
					// CheckChange
					if (data is SingleContestFactoryCheckChange<SingleContestFactory>) {
						return;
					}
				}
				if (data is RoundRobin) {
					return;
				}
				if (data is RequestNewRoundRobin) {
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
			if (wrapProperty.p is RoundRobinContent) {
				switch ((RoundRobinContent.Property)wrapProperty.n) {
				case RoundRobinContent.Property.singleContestFactory:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case RoundRobinContent.Property.roundRobins:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case RoundRobinContent.Property.requestNewRoundRobin:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case RoundRobinContent.Property.needReturnRound:
					dirty = true;
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
					dirty = true;
					break;
				case ContestManagerStatePlay.Property.content:
					break;
				case ContestManagerStatePlay.Property.contentTeamResult:
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
				// singleContestFactory
				{
					if (wrapProperty.p is SingleContestFactory) {
						return;
					}
					// CheckChange
					if (wrapProperty.p is SingleContestFactoryCheckChange<SingleContestFactory>) {
						dirty = true;
						return;
					}
				}
				if (wrapProperty.p is RoundRobin) {
					switch ((RoundRobin.Property)wrapProperty.n) {
					case RoundRobin.Property.state:
						dirty = true;
						break;
					case RoundRobin.Property.index:
						break;
					case RoundRobin.Property.roundContests:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is RequestNewRoundRobin) {
					switch ((RequestNewRoundRobin.Property)wrapProperty.n) {
					case RequestNewRoundRobin.Property.state:
						dirty = true;
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
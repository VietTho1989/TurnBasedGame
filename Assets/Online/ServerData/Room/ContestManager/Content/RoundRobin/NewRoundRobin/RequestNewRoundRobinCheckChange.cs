using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RequestNewRoundRobinCheckChange<K> : Data, ValueChangeCallBack where K : Data
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

		public RequestNewRoundRobinCheckChange() : base()
		{
			this.change = new VP<int> (this, (byte)Property.change, 0);
		}

		#endregion

		public K data;

		public void setData(K newData){
			if (this.data != newData) {
				// remove old
				{
					DataUtils.removeParentCallBack (this.data, this, ref this.requestNewRoundRobin);
				}
				// set new 
				{
					this.data = newData;
					DataUtils.addParentCallBack (this.data, this, ref this.requestNewRoundRobin);
				}
			} else {
				Debug.LogError ("the same: " + this + ", " + data + ", " + newData);
			}
		}

		#region implement callBacks

		private RequestNewRoundRobin requestNewRoundRobin = null;

		private RoundRobinContent roundRobinContent = null;
		private ContestManagerStatePlay contestManagerStatePlay = null;

		private SingleContestFactoryCheckChange<SingleContestFactory> singleContestFactoryCheckChange = new SingleContestFactoryCheckChange<SingleContestFactory>();

		public void onAddCallBack<T> (T data) where T:Data
		{
			if (data is RequestNewRoundRobin) {
				RequestNewRoundRobin requestNewRoundRobin = data as RequestNewRoundRobin;
				// Parent
				{
					DataUtils.addParentCallBack (requestNewRoundRobin, this, ref this.roundRobinContent);
				}
				this.notifyChange ();
				return;
			}
			// Parent
			{
				if (data is RoundRobinContent) {
					RoundRobinContent roundRobinContent = data as RoundRobinContent;
					// Parent
					{
						DataUtils.addParentCallBack (roundRobinContent, this, ref this.contestManagerStatePlay);
					}
					// Child
					{
						roundRobinContent.singleContestFactory.allAddCallBack (this);
						roundRobinContent.roundRobins.allAddCallBack (this);
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
					// singleContestFactory
					{
						if (data is SingleContestFactory) {
							SingleContestFactory singleContestFactory = data as SingleContestFactory;
							// CheckChange
							{
								singleContestFactoryCheckChange.addCallBack (this);
								singleContestFactoryCheckChange.setData (singleContestFactory);
							}
							this.notifyChange ();
							return;
						}
						// CheckChange
						if (data is SingleContestFactoryCheckChange<SingleContestFactory>) {
							this.notifyChange ();
							return;
						}
					}
					if (data is RoundRobin) {
						this.notifyChange ();
						return;
					}
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public void onRemoveCallBack<T> (T data, bool isHide) where T:Data
		{
			if (data is RequestNewRoundRobin) {
				RequestNewRoundRobin requestNewRoundRobin = data as RequestNewRoundRobin;
				// Parent
				{
					DataUtils.removeParentCallBack (requestNewRoundRobin, this, ref this.roundRobinContent);
				}
				this.requestNewRoundRobin = null;
				return;
			}
			// Parent
			{
				if (data is RoundRobinContent) {
					RoundRobinContent roundRobinContent = data as RoundRobinContent;
					// Parent
					{
						DataUtils.removeParentCallBack (roundRobinContent, this, ref this.contestManagerStatePlay);
					}
					// Child
					{
						roundRobinContent.singleContestFactory.allRemoveCallBack (this);
						roundRobinContent.roundRobins.allRemoveCallBack (this);
					}
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
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is RequestNewRoundRobin) {
				switch ((RequestNewRoundRobin.Property)wrapProperty.n) {
				case RequestNewRoundRobin.Property.state:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			{
				if (wrapProperty.p is RoundRobinContent) {
					switch ((RoundRobinContent.Property)wrapProperty.n) {
					case RoundRobinContent.Property.singleContestFactory:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							this.notifyChange ();
						}
						break;
					case RoundRobinContent.Property.roundRobins:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							this.notifyChange ();
						}
						break;
					case RoundRobinContent.Property.requestNewRoundRobin:
						break;
					case RoundRobinContent.Property.needReturnRound:
						this.notifyChange ();
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
						this.notifyChange ();
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
							this.notifyChange ();
							return;
						}
					}
					if (wrapProperty.p is RoundRobin) {
						switch ((RoundRobin.Property)wrapProperty.n) {
						case RoundRobin.Property.state:
							this.notifyChange ();
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
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		#endregion

	}
}
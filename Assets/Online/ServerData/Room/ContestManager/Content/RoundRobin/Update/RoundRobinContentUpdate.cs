using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RoundRobinContentUpdate : UpdateBehavior<RoundRobinContent>
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
			if (data is RoundRobinContent) {
				RoundRobinContent roundRobinContent = data as RoundRobinContent;
				// Update
				{
					UpdateUtils.makeUpdate<RoundRobinContentCheckEndUpdate, RoundRobinContent> (roundRobinContent, this.transform);
					UpdateUtils.makeUpdate<RoundRobinContentMakeNewRoundUpdate, RoundRobinContent> (roundRobinContent, this.transform);
				}
				// Child
				{
					// singleContestFactory: ko can
					roundRobinContent.roundRobins.allAddCallBack(this);
					roundRobinContent.requestNewRoundRobin.allAddCallBack (this);
					// needReturnRound: ko can
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is RoundRobin) {
					RoundRobin roundRobin = data as RoundRobin;
					// Update
					{
						UpdateUtils.makeUpdate<RoundRobinUpdate, RoundRobin> (roundRobin, this.transform);
					}
					dirty = true;
					return;
				}
				if (data is RequestNewRoundRobin) {
					RequestNewRoundRobin requestNewRoundRobin = data as RequestNewRoundRobin;
					// Update
					{
						UpdateUtils.makeUpdate<RequestNewRoundRobinUpdate, RequestNewRoundRobin> (requestNewRoundRobin, this.transform);
					}
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
				// Update
				{
					roundRobinContent.removeCallBackAndDestroy (typeof(RoundRobinContentCheckEndUpdate));
					roundRobinContent.removeCallBackAndDestroy (typeof(RoundRobinContentMakeNewRoundUpdate));
				}
				// Child
				{
					// singleContestFactory: ko can
					roundRobinContent.roundRobins.allRemoveCallBack(this);
					roundRobinContent.requestNewRoundRobin.allRemoveCallBack (this);
					// needReturnRound: ko can
				}
				this.setDataNull (roundRobinContent);
				return;
			}
			// Child
			{
				if (data is RoundRobin) {
					RoundRobin roundRobin = data as RoundRobin;
					// Update
					{
						roundRobin.removeCallBackAndDestroy (typeof(RoundRobinUpdate));
					}
					return;
				}
				if (data is RequestNewRoundRobin) {
					RequestNewRoundRobin requestNewRoundRobin = data as RequestNewRoundRobin;
					// Update
					{
						requestNewRoundRobin.removeCallBackAndDestroy (typeof(RequestNewRoundRobinUpdate));
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
			if (wrapProperty.p is RoundRobinContent) {
				switch ((RoundRobinContent.Property)wrapProperty.n) {
				case RoundRobinContent.Property.singleContestFactory:
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
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				if (wrapProperty.p is RoundRobin) {
					return;
				}
				if (wrapProperty.p is RequestNewRoundRobin) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
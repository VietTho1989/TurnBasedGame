using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class ResultIdentity : DataIdentity
	{

		#region SyncVar

		#region playerIndex

		[SyncVar(hook="onChangePlayerIndex")]
		public System.Int32 playerIndex;

		public void onChangePlayerIndex(System.Int32 newPlayerIndex)
		{
			this.playerIndex = newPlayerIndex;
			if (this.netData.clientData != null) {
				this.netData.clientData.playerIndex.v = newPlayerIndex;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region score

		[SyncVar(hook="onChangeScore")]
		public System.Single score;

		public void onChangeScore(System.Single newScore)
		{
			this.score = newScore;
			if (this.netData.clientData != null) {
				this.netData.clientData.score.v = newScore;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region reason

		[SyncVar(hook="onChangeReason")]
		public GameState.Result.Reason reason;

		public void onChangeReason(GameState.Result.Reason newReason)
		{
			this.reason = newReason;
			if (this.netData.clientData != null) {
				this.netData.clientData.reason.v = newReason;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<Result> netData = new NetData<Result>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangePlayerIndex(this.playerIndex);
				this.onChangeScore(this.score);
				this.onChangeReason(this.reason);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.playerIndex);
				ret += GetDataSize (this.score);
				ret += GetDataSize (this.reason);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is Result) {
				Result result = data as Result;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, result.makeSearchInforms ());
					this.playerIndex = result.playerIndex.v;
					this.score = result.score.v;
					this.reason = result.reason.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (result);
					} else {
						Debug.LogError ("observer null");
					}
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is Result) {
				// Result result = data as Result;
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.setCheckChangeData (null);
					} else {
						Debug.LogError ("observer null");
					}
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is Result) {
				switch ((Result.Property)wrapProperty.n) {
				case Result.Property.playerIndex:
					this.playerIndex = (System.Int32)wrapProperty.getValue ();
					break;
				case Result.Property.score:
					this.score = (System.Single)wrapProperty.getValue ();
					break;
				case Result.Property.reason:
					this.reason = (GameState.Result.Reason)wrapProperty.getValue ();
					break;
				default:
					Debug.LogError ("Unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
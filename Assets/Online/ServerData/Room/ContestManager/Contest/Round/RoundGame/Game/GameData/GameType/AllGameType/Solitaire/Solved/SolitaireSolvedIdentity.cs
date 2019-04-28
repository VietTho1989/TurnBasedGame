using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class SolitaireSolvedIdentity : DataIdentity
	{

		#region SyncVar

		#region result

		[SyncVar(hook="onChangeResult")]
		public SolitaireSolved.SolveResult result;

		public void onChangeResult(SolitaireSolved.SolveResult newResult)
		{
			this.result = newResult;
			if (this.netData.clientData != null) {
				this.netData.clientData.result.v = newResult;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<SolitaireSolved> netData = new NetData<SolitaireSolved>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeResult(this.result);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.result);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is SolitaireSolved) {
				SolitaireSolved solitaireSolved = data as SolitaireSolved;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, solitaireSolved.makeSearchInforms ());
					this.result = solitaireSolved.result.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (solitaireSolved);
					} else {
						Debug.LogError ("observer null: " + this);
					}
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is SolitaireSolved) {
				// SolitaireSolved solitaireSolved = data as SolitaireSolved;
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.setCheckChangeData (null);
					} else {
						Debug.LogError ("observer null: " + this);
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
			if (wrapProperty.p is SolitaireSolved) {
				switch ((SolitaireSolved.Property)wrapProperty.n) {
				case SolitaireSolved.Property.result:
					this.result = (SolitaireSolved.SolveResult)wrapProperty.getValue ();
					break;
				case SolitaireSolved.Property.moves:
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
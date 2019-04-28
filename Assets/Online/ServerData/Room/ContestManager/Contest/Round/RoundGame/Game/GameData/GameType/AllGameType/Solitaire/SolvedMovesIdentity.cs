using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class SolvedMovesIdentity : DataIdentity
	{

		#region SyncVar

		#region moveIndex

		[SyncVar(hook="onChangeMoveIndex")]
		public System.Int32 moveIndex;

		public void onChangeMoveIndex(System.Int32 newMoveIndex)
		{
			this.moveIndex = newMoveIndex;
			if (this.netData.clientData != null) {
				this.netData.clientData.moveIndex.v = newMoveIndex;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<SolvedMoves> netData = new NetData<SolvedMoves>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeMoveIndex(this.moveIndex);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.moveIndex);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is SolvedMoves) {
				SolvedMoves solvedMoves = data as SolvedMoves;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, solvedMoves.makeSearchInforms ());
					this.moveIndex = solvedMoves.moveIndex.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (solvedMoves);
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
			if (data is SolvedMoves) {
				// SolvedMoves solvedMoves = data as SolvedMoves;
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
			if (wrapProperty.p is SolvedMoves) {
				switch ((SolvedMoves.Property)wrapProperty.n) {
				case SolvedMoves.Property.solved:
					break;
				case SolvedMoves.Property.moveIndex:
					this.moveIndex = (System.Int32)wrapProperty.getValue ();
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
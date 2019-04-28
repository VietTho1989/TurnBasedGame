using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan
{
	public class SeirawanMoveIdentity : DataIdentity
	{

		#region move

		[SyncVar(hook="onChangeMove")]
		public System.Int32 move;

		public void onChangeMove(System.Int32 newMove)
		{
			this.move = newMove;
			if (this.netData.clientData != null) {
				this.netData.clientData.move.v = newMove;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region chess960

		[SyncVar(hook="onChangeChess960")]
		public bool chess960;

		public void onChangeChess960(bool newChess960)
		{
			this.chess960 = newChess960;
			if (this.netData.clientData != null) {
				this.netData.clientData.chess960.v = newChess960;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region NetData

		private NetData<SeirawanMove> netData = new NetData<SeirawanMove>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeMove (this.move);
				this.onChangeChess960 (this.chess960);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.move);
				ret += GetDataSize (this.chess960);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is SeirawanMove) {
				SeirawanMove seirawanMove = data as SeirawanMove;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, seirawanMove.makeSearchInforms ());
					this.move = seirawanMove.move.v;
					this.chess960 = seirawanMove.chess960.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (seirawanMove);
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
			if (data is SeirawanMove) {
				// SeirawanMove seirawanMove = data as SeirawanMove;
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
			if (wrapProperty.p is SeirawanMove) {
				switch ((SeirawanMove.Property)wrapProperty.n) {
				case SeirawanMove.Property.move:
					this.move = (System.Int32)wrapProperty.getValue ();
					break;
				case SeirawanMove.Property.chess960:
					this.chess960 = (bool)wrapProperty.getValue ();
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
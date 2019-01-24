using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class LastMoveIdentity : DataIdentity
{

	#region SyncVar

	[SyncVar(hook="onChangeTurn")]
	public System.Int32 turn;

	public void onChangeTurn(System.Int32 newTurn)
	{
		this.turn = newTurn;
		if (this.netData.clientData != null) {
			this.netData.clientData.turn.v = newTurn;
		} else {
			// Debug.LogError ("clientData null");
		}
	}

	#endregion

	#region NetData

	private NetData<LastMove> netData = new NetData<LastMove>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeTurn(this.turn);
		} else {
			// Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.turn);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is LastMove) {
			LastMove lastMove = data as LastMove;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, lastMove.makeSearchInforms ());
				this.turn = lastMove.turn.v;
			}
			this.getDataSize ();
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (lastMove);
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
		if (data is LastMove) {
			// LastMove lastMove = data as LastMove;
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
		if (wrapProperty.p is LastMove) {
			switch ((LastMove.Property)wrapProperty.n) {
			case LastMove.Property.turn:
				this.turn = (int)wrapProperty.getValue ();
				break;
			case LastMove.Property.gameMove:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion
}
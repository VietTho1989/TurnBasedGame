using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class TurnChangeIdentity : DataIdentity
{

	#region SyncVar

	#region turn

	[SyncVar(hook="onChangeTurn")]
	public System.Int32 turn;

	public void onChangeTurn(System.Int32 newTurn)
	{
		this.turn = newTurn;
		if (this.netData.clientData != null) {
			this.netData.clientData.turn.v = newTurn;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

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

	#region gameTurn

	[SyncVar(hook="onChangeGameTurn")]
	public System.Int32 gameTurn;

	public void onChangeGameTurn(System.Int32 newGameTurn)
	{
		this.gameTurn = newGameTurn;
		if (this.netData.clientData != null) {
			this.netData.clientData.gameTurn.v = newGameTurn;
		} else {
			// Debug.LogError ("clientData null: "+this);
		}
	}

	#endregion

	#endregion

	#region NetData

	private NetData<TurnChange> netData = new NetData<TurnChange>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeTurn(this.turn);
			this.onChangePlayerIndex(this.playerIndex);
			this.onChangeGameTurn(this.gameTurn);
		} else {
			Debug.Log ("clientData null");
		}
	}

	public override int refreshDataSize ()
	{
		int ret = GetDataSize (this.netId);
		{
			ret += GetDataSize (this.turn);
			ret += GetDataSize (this.playerIndex);
			ret += GetDataSize (this.gameTurn);
		}
		return ret;
	}

	#endregion

	#region implemt callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is TurnChange) {
			TurnChange turnChange = data as TurnChange;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, turnChange.makeSearchInforms ());
				this.turn = turnChange.turn.v;
				this.playerIndex = turnChange.playerIndex.v;
				this.gameTurn = turnChange.gameTurn.v;
			}
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new HistoryChangeObserver (observer);
					observer.setCheckChangeData (turnChange);
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
		if (data is TurnChange) {
			// TurnChange turnChange = data as TurnChange;
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
		if (wrapProperty.p is TurnChange) {
			switch ((TurnChange.Property)wrapProperty.n) {
			case TurnChange.Property.turn:
				this.turn = (System.Int32)wrapProperty.getValue ();
				break;
			case TurnChange.Property.playerIndex:
				this.playerIndex = (System.Int32)wrapProperty.getValue ();
				break;
			case TurnChange.Property.gameTurn:
				this.gameTurn = (System.Int32)wrapProperty.getValue ();
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
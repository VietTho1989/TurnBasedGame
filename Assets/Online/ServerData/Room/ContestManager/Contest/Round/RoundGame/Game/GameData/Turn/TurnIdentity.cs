using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class TurnIdentity : DataIdentity
{

	#region SyncVar

	#region Turn

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

	#region playerIndex

	[SyncVar(hook="onChangePlayerIndex")]
	public System.Int32 playerIndex;

	public void onChangePlayerIndex(System.Int32 newPlayerIndex)
	{
		this.playerIndex = newPlayerIndex;
		if (this.netData.clientData != null) {
			this.netData.clientData.playerIndex.v = newPlayerIndex;
		} else {
			// Debug.LogError ("clientData null");
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
			// Debug.LogError ("clientData null");
		}
	}

	#endregion

	#endregion

	#region NetData

	private NetData<Turn> netData = new NetData<Turn>();

	public override NetDataDelegate getNetData ()
	{
		return this.netData;
	}

	public override void refreshClientData ()
	{
		if (this.netData.clientData != null) {
			this.onChangeTurn(this.turn);
			this.onChangePlayerIndex (this.playerIndex);
			this.onChangeGameTurn (this.gameTurn);
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
		if (data is Turn) {
			Turn turn = data as Turn;
			// Set new parent
			this.addTransformToParent();
			// Set property
			{
				this.serialize (this.searchInfor, turn.makeSearchInforms ());
				this.turn = turn.turn.v;
				this.playerIndex = turn.playerIndex.v;
				this.gameTurn = turn.gameTurn.v;
			}
			this.getDataSize ();
			// Observer
			{
				GameObserver observer = GetComponent<GameObserver> ();
				if (observer != null) {
					observer.checkChange = new FollowParentObserver (observer);
					observer.setCheckChangeData (turn);
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
		if (data is Turn) {
			// Turn turn = data as Turn;
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
		if (wrapProperty.p is Turn) {
			switch ((Turn.Property)wrapProperty.n) {
			case Turn.Property.turn:
				this.turn = (int)wrapProperty.getValue ();
				break;
			case Turn.Property.playerIndex:
				this.playerIndex = (int)wrapProperty.getValue();
				break;
			case Turn.Property.gameTurn:
				this.gameTurn = (int)wrapProperty.getValue ();
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
using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class HumanConnectionObserver : GameObserver.CheckChange
{

	public HumanConnectionObserver(GameObserver gameObserver) : base(gameObserver)
	{

	}

	#region setData

	public HumanConnection data = null;

	public override void setData(Data newData)
	{
		// set
		if (this.data != newData) {
			// remove old
			if (this.data != null) {
				this.data.removeCallBack (this);
			}
			// set new 
			{
				this.data = newData as HumanConnection;
				if (this.data != null) {
					this.data.addCallBack (this);
				}
			}
		} else {
			// Debug.LogError ("the same: " + this + ", " + data + ", " + newData);
		}
	}


	public override Type getType ()
	{
		return Type.HumanConnection;
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is HumanConnection) {
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is HumanConnection) {
			// set data null
			{
				if (this.data == data) {
					this.data = null;
				} else {
					Debug.LogError ("why different");
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
		if (wrapProperty.p is HumanConnection) {
			switch ((HumanConnection.Property)wrapProperty.n) {
			case HumanConnection.Property.playerId:
				break;
			case HumanConnection.Property.connection:
				{
					gameObserver.dirty = true;
					gameObserver.needRefresh = true;
				}
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public override void refreshObserverConnections ()
	{
		gameObserver.allConnections.Clear ();
		if (this.data != null) {
			if (this.data.connection.v != null) {
				gameObserver.allConnections.Add (this.data.connection.v);
			} else {
				// Debug.LogError ("humanConnection connection null: " + humanConnection + "; " + this);
			}
		} else {
			Debug.LogError ("humanConnection null: " + this);
		}
		// Debug.LogError ("refreshObserverConnections: humConnectionObserver: " + gameObserver.allConnections.Count);
	}

	public override void onChangeParentObservers (Dictionary<int, NetworkConnection>.ValueCollection parentObserver)
	{
		gameObserver.dirty = true;
		gameObserver.needRefresh = true;
	}

}
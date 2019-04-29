using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618

public class HistoryChangeObserver : GameObserver.CheckChange
{

	public HistoryChangeObserver(GameObserver gameObserver) : base(gameObserver)
	{

	}

	#region setData

	public HistoryChange data = null;

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
				this.data = newData as HistoryChange;
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
		return Type.HistoryChange;
	}

	#endregion

	#region implement callBacks

	private History history = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is HistoryChange) {
			HistoryChange historyChange = data as HistoryChange;
			// Parent
			{
				DataUtils.addParentCallBack (historyChange, this, ref this.history);
			}
			return;
		}
		// Parent
		{
			if (data is History) {
				History history = data as History;
				// Child
				{
					history.humanConnections.allAddCallBack (this);
				}
				return;
			}
			// Child
			if (data is HumanConnection) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is HistoryChange) {
			HistoryChange historyChange = data as HistoryChange;
			// Parent
			{
				DataUtils.removeParentCallBack (historyChange, this, ref this.history);
			}
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
		// Parent
		{
			if (data is History) {
				History history = data as History;
				// Child
				{
					history.humanConnections.allRemoveCallBack (this);
				}
				return;
			}
			// Child
			if (data is HumanConnection) {
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
		if (wrapProperty.p is HistoryChange) {
			return;
		}
		// Parent
		{
			if (wrapProperty.p is History) {
				switch ((History.Property)wrapProperty.n) {
				case History.Property.isActive:
					break;
				case History.Property.changes:
					break;
				case History.Property.position:
					break;
				case History.Property.changeCount:
					break;
				case History.Property.humanConnections:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
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
			// Child
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
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public override void refreshObserverConnections ()
	{
		gameObserver.allConnections.Clear ();
		if (this.data != null) {
			History history = this.data.findDataInParent<History> ();
			if (history != null) {
				foreach (HumanConnection humanConnection in history.humanConnections.vs) {
					if (humanConnection.connection.v != null) {
						gameObserver.allConnections.Add (humanConnection.connection.v);
					}
				}
			} else {
				Debug.LogError ("history null: " + this);
			}
		} else {
			Debug.LogError ("humanConnection null: " + this);
		}
		// Debug.LogError ("refreshObserverConnections: humConnectionObserver: " + gameObserver.allConnections.Count);
	}

	public override void onChangeParentObservers (System.Collections.ObjectModel.ReadOnlyCollection<NetworkConnection> parentObserver)
	{
		gameObserver.dirty = true;
		gameObserver.needRefresh = true;
	}

}
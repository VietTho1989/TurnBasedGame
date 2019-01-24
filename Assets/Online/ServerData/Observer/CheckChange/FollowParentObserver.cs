using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class FollowParentObserver : GameObserver.CheckChange, ValueChangeCallBack
{

	public FollowParentObserver(GameObserver gameObserver) : base(gameObserver)
	{

	}

	#region setData

	private Data data;

	public override void setData(Data newData){
		if (this.data != newData) {
			// remove old
			/*if (this.data != null) {
				this.data.removeCallBack (this);
			}*/
			// set new
			this.data = newData;
			{
				// dirty = true;
				// needRefresh = true;
			}
			/*if (this.data != null) {
				this.data.addCallBack (this);
			}*/
		} else {
			// Debug.LogError ("the same");
		}
	}

	public override Type getType ()
	{
		return Type.FollowParent;
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		gameObserver.dirty = true;
		gameObserver.needRefresh = true;
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{

	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{

	}

	#endregion

	#region Global

	public override void onChangeParentObservers (Dictionary<int, NetworkConnection>.ValueCollection parentObserver)
	{
		gameObserver.dirty = true;
		gameObserver.needRefresh = true;
	}

	public override void refreshObserverConnections ()
	{
		gameObserver.allConnections.Clear ();
		List<NetworkConnection> parentObserver = gameObserver.getParentObserver ();
		if (parentObserver != null) {
			// Debug.LogError ("FollowParentObserver: getAllObserverConnection: " + parentObserver.Count + "; " + this + "; " + this.gameObject);
			gameObserver.allConnections.AddRange(parentObserver);
		} else {
			// Debug.LogError ("parentObserver null: " + this);
		}
	}

	#endregion

}
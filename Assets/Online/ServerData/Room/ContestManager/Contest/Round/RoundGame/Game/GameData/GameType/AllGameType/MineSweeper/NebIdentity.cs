using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace MineSweeper
{
	public class NebIdentity : DataIdentity
	{

		#region SyncVar

		[SyncVar]
		public int interior;

		[SyncVar]
		public int fringe;

		[SyncVar]
		public int boundary;

		#endregion

		#region NetData

		private NetData<Neb> netData = new NetData<Neb>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.interior);
				ret += GetDataSize (this.fringe);
				ret += GetDataSize (this.boundary);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is Neb) {
				Neb neb = data as Neb;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, neb.makeSearchInforms ());
					this.interior = neb.interior.vs.Count;
					this.fringe = neb.fringe.vs.Count;
					this.boundary = neb.boundary.vs.Count;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (neb);
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
			if (data is Neb) {
				// Neb neb = data as Neb;
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
			if (wrapProperty.p is Neb) {
				switch ((Neb.Property)wrapProperty.n) {
				case Neb.Property.interior:
					{
						Neb neb = wrapProperty.p as Neb;
						this.interior = neb.interior.vs.Count;
					}
					break;
				case Neb.Property.fringe:
					{
						Neb neb = wrapProperty.p as Neb;
						this.fringe = neb.fringe.vs.Count;
					}
					break;
				case Neb.Property.boundary:
					{
						Neb neb = wrapProperty.p as Neb;
						this.boundary = neb.boundary.vs.Count;
					}
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
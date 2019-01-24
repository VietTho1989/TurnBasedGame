using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
	public class BoardStaticsIdentity : DataIdentity
	{

		#region SyncVar

		#region size

		[SyncVar(hook="onChangeSize")]
		public System.Int32 size;

		public void onChangeSize(System.Int32 newSize)
		{
			this.size = newSize;
			if (this.netData.clientData != null) {
				this.netData.clientData.size.v = newSize;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region nei8

		public SyncListInt nei8 = new SyncListInt();

		private void OnNei8Changed(SyncListInt.Operation op, int index, int item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.nei8, this.nei8, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region dnei

		public SyncListInt dnei = new SyncListInt();

		private void OnDneiChanged(SyncListInt.Operation op, int index, int item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.dnei, this.dnei, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region h

		public SyncListUInt64 h = new SyncListUInt64();

		private void OnHChanged(SyncListUInt64.Operation op, int index, MyUInt64 item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.h, this.h, op, index, MyUInt64.uLongConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region coord

		public SyncListByte coord = new SyncListByte();

		private void OnCoordChanged(SyncListByte.Operation op, int index, MyByte item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.coord, this.coord, op, index, MyByte.byteConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#endregion

		#region NetData

		private NetData<BoardStatics> netData = new NetData<BoardStatics>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void addSyncListCallBack ()
		{
			base.addSyncListCallBack ();
			this.nei8.Callback += OnNei8Changed;
			this.dnei.Callback += OnDneiChanged;
			this.h.Callback += OnHChanged;
			this.coord.Callback += OnCoordChanged;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeSize(this.size);
				IdentityUtils.refresh(this.netData.clientData.nei8, this.nei8);
				IdentityUtils.refresh(this.netData.clientData.dnei, this.dnei);
				IdentityUtils.refresh(this.netData.clientData.h, this.h, MyUInt64.uLongConvert);
				IdentityUtils.refresh(this.netData.clientData.coord, this.coord, MyByte.byteConvert);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.size);
				ret += GetDataSize (this.nei8);
				ret += GetDataSize (this.dnei);
				ret += GetDataSize (this.h);
				ret += GetDataSize (this.coord);
				return ret;
			}
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is BoardStatics) {
				BoardStatics boardStatics = data as BoardStatics;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, boardStatics.makeSearchInforms ());
					this.size = boardStatics.size.v;
					IdentityUtils.InitSync(this.nei8, boardStatics.nei8.vs);
					IdentityUtils.InitSync(this.dnei, boardStatics.dnei.vs);
					IdentityUtils.InitSync(this.h, boardStatics.h, MyUInt64.myUInt64Convert);
					IdentityUtils.InitSync(this.coord, boardStatics.coord, MyByte.myByteConvert);
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (boardStatics);
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
			if (data is BoardStatics) {
				// BoardStatics boardStatics = data as BoardStatics;
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
			if (wrapProperty.p is BoardStatics) {
				switch ((BoardStatics.Property)wrapProperty.n) {
				case BoardStatics.Property.size:
					this.size = (System.Int32)wrapProperty.getValue ();
					break;
				case BoardStatics.Property.nei8:
					IdentityUtils.UpdateSyncList (this.nei8, syncs, GlobalCast<T>.CastingInt32);
					break;
				case BoardStatics.Property.dnei:
					IdentityUtils.UpdateSyncList (this.dnei, syncs, GlobalCast<T>.CastingInt32);
					break;
				case BoardStatics.Property.h:
					IdentityUtils.UpdateSyncList (this.h, syncs, GlobalCast<T>.CastingMyUInt64);
					break;
				case BoardStatics.Property.coord:
					IdentityUtils.UpdateSyncList (this.coord, syncs, GlobalCast<T>.CastingMyByte);
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
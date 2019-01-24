using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Shatranj
{
	public class ShatranjStateInfoIdentity : DataIdentity
	{

		#region SyncVar

		#region pawnKey

		[SyncVar(hook="onChangePawnKey")]
		public System.UInt64 pawnKey;

		public void onChangePawnKey(System.UInt64 newPawnKey)
		{
			this.pawnKey = newPawnKey;
			if (this.netData.clientData != null) {
				this.netData.clientData.pawnKey.v = newPawnKey;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region materialKey

		[SyncVar(hook="onChangeMaterialKey")]
		public System.UInt64 materialKey;

		public void onChangeMaterialKey(System.UInt64 newMaterialKey)
		{
			this.materialKey = newMaterialKey;
			if (this.netData.clientData != null) {
				this.netData.clientData.materialKey.v = newMaterialKey;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region nonPawnMaterial

		public SyncListInt nonPawnMaterial = new SyncListInt();

		private void OnNonPawnMaterialChanged(SyncListInt.Operation op, int index, int item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.nonPawnMaterial, this.nonPawnMaterial, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region rule50

		[SyncVar(hook="onChangeRule50")]
		public System.Int32 rule50;

		public void onChangeRule50(System.Int32 newRule50)
		{
			this.rule50 = newRule50;
			if (this.netData.clientData != null) {
				this.netData.clientData.rule50.v = newRule50;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region pliesFromNull

		[SyncVar(hook="onChangePliesFromNull")]
		public System.Int32 pliesFromNull;

		public void onChangePliesFromNull(System.Int32 newPliesFromNull)
		{
			this.pliesFromNull = newPliesFromNull;
			if (this.netData.clientData != null) {
				this.netData.clientData.pliesFromNull.v = newPliesFromNull;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region psq

		[SyncVar(hook="onChangePsq")]
		public System.Int32 psq;

		public void onChangePsq(System.Int32 newPsq)
		{
			this.psq = newPsq;
			if (this.netData.clientData != null) {
				this.netData.clientData.psq.v = newPsq;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region key

		[SyncVar(hook="onChangeKey")]
		public System.UInt64 key;

		public void onChangeKey(System.UInt64 newKey)
		{
			this.key = newKey;
			if (this.netData.clientData != null) {
				this.netData.clientData.key.v = newKey;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region checkersBB

		[SyncVar(hook="onChangeCheckersBB")]
		public System.UInt64 checkersBB;

		public void onChangeCheckersBB(System.UInt64 newCheckersBB)
		{
			this.checkersBB = newCheckersBB;
			if (this.netData.clientData != null) {
				this.netData.clientData.checkersBB.v = newCheckersBB;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region capturedPiece

		[SyncVar(hook="onChangeCapturedPiece")]
		public System.Int32 capturedPiece;

		public void onChangeCapturedPiece(System.Int32 newCapturedPiece)
		{
			this.capturedPiece = newCapturedPiece;
			if (this.netData.clientData != null) {
				this.netData.clientData.capturedPiece.v = newCapturedPiece;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region blockersForKing

		public SyncListUInt64 blockersForKing = new SyncListUInt64();

		private void OnBlockersForKingChanged(SyncListUInt64.Operation op, int index, MyUInt64 item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.blockersForKing, this.blockersForKing, op, index, MyUInt64.uLongConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region pinnersForKing

		public SyncListUInt64 pinnersForKing = new SyncListUInt64();

		private void OnPinnersForKingChanged(SyncListUInt64.Operation op, int index, MyUInt64 item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.pinnersForKing, this.pinnersForKing, op, index, MyUInt64.uLongConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region checkSquares

		public SyncListUInt64 checkSquares = new SyncListUInt64();

		private void OnCheckSquaresChanged(SyncListUInt64.Operation op, int index, MyUInt64 item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.checkSquares, this.checkSquares, op, index, MyUInt64.uLongConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#endregion

		#region NetData

		private NetData<ShatranjStateInfo> netData = new NetData<ShatranjStateInfo>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void addSyncListCallBack ()
		{
			base.addSyncListCallBack ();
			this.nonPawnMaterial.Callback += OnNonPawnMaterialChanged;
			this.blockersForKing.Callback += OnBlockersForKingChanged;
			this.pinnersForKing.Callback += OnPinnersForKingChanged;
			this.checkSquares.Callback += OnCheckSquaresChanged;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangePawnKey(this.pawnKey);
				this.onChangeMaterialKey(this.materialKey);
				IdentityUtils.refresh(this.netData.clientData.nonPawnMaterial, this.nonPawnMaterial);
				this.onChangeRule50(this.rule50);
				this.onChangePliesFromNull(this.pliesFromNull);
				this.onChangePsq(this.psq);
				this.onChangeKey(this.key);
				this.onChangeCheckersBB(this.checkersBB);
				this.onChangeCapturedPiece(this.capturedPiece);
				IdentityUtils.refresh(this.netData.clientData.blockersForKing, this.blockersForKing, MyUInt64.uLongConvert);
				IdentityUtils.refresh(this.netData.clientData.pinnersForKing, this.pinnersForKing, MyUInt64.uLongConvert);
				IdentityUtils.refresh(this.netData.clientData.checkSquares, this.checkSquares, MyUInt64.uLongConvert);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.pawnKey);
				ret += GetDataSize (this.materialKey);
				ret += GetDataSize (this.nonPawnMaterial);
				ret += GetDataSize (this.rule50);
				ret += GetDataSize (this.pliesFromNull);
				ret += GetDataSize (this.psq);
				ret += GetDataSize (this.key);
				ret += GetDataSize (this.checkersBB);
				ret += GetDataSize (this.capturedPiece);
				ret += GetDataSize (this.blockersForKing);
				ret += GetDataSize (this.pinnersForKing);
				ret += GetDataSize (this.checkSquares);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is ShatranjStateInfo) {
				ShatranjStateInfo stateInfo = data as ShatranjStateInfo;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, stateInfo.makeSearchInforms ());
					this.pawnKey = stateInfo.pawnKey.v;
					this.materialKey = stateInfo.materialKey.v;
					IdentityUtils.InitSync(this.nonPawnMaterial, stateInfo.nonPawnMaterial.vs);
					this.rule50 = stateInfo.rule50.v;
					this.pliesFromNull = stateInfo.pliesFromNull.v;
					this.psq = stateInfo.psq.v;
					this.key = stateInfo.key.v;
					this.checkersBB = stateInfo.checkersBB.v;
					this.capturedPiece = stateInfo.capturedPiece.v;
					IdentityUtils.InitSync(this.blockersForKing, stateInfo.blockersForKing, MyUInt64.myUInt64Convert);
					IdentityUtils.InitSync(this.pinnersForKing, stateInfo.pinnersForKing, MyUInt64.myUInt64Convert);
					IdentityUtils.InitSync(this.checkSquares, stateInfo.checkSquares, MyUInt64.myUInt64Convert);
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (stateInfo);
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
			if (data is ShatranjStateInfo) {
				// StateInfo stateInfo = data as StateInfo;
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
			if (wrapProperty.p is ShatranjStateInfo) {
				switch ((ShatranjStateInfo.Property)wrapProperty.n) {
				case ShatranjStateInfo.Property.pawnKey:
					this.pawnKey = (System.UInt64)wrapProperty.getValue ();
					break;
				case ShatranjStateInfo.Property.materialKey:
					this.materialKey = (System.UInt64)wrapProperty.getValue ();
					break;
				case ShatranjStateInfo.Property.nonPawnMaterial:
					IdentityUtils.UpdateSyncList (this.nonPawnMaterial, syncs, GlobalCast<T>.CastingInt32);
					break;
				case ShatranjStateInfo.Property.rule50:
					this.rule50 = (System.Int32)wrapProperty.getValue ();
					break;
				case ShatranjStateInfo.Property.pliesFromNull:
					this.pliesFromNull = (System.Int32)wrapProperty.getValue ();
					break;
				case ShatranjStateInfo.Property.psq:
					this.psq = (System.Int32)wrapProperty.getValue ();
					break;
				case ShatranjStateInfo.Property.key:
					this.key = (System.UInt64)wrapProperty.getValue ();
					break;
				case ShatranjStateInfo.Property.checkersBB:
					this.checkersBB = (System.UInt64)wrapProperty.getValue ();
					break;
				case ShatranjStateInfo.Property.capturedPiece:
					this.capturedPiece = (System.Int32)wrapProperty.getValue ();
					break;
				case ShatranjStateInfo.Property.blockersForKing:
					IdentityUtils.UpdateSyncList (this.blockersForKing, syncs, GlobalCast<T>.CastingMyUInt64);
					break;
				case ShatranjStateInfo.Property.pinnersForKing:
					IdentityUtils.UpdateSyncList (this.pinnersForKing, syncs, GlobalCast<T>.CastingMyUInt64);
					break;
				case ShatranjStateInfo.Property.checkSquares:
					IdentityUtils.UpdateSyncList (this.checkSquares, syncs, GlobalCast<T>.CastingMyUInt64);
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
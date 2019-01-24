using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Chess
{
	public class StateInfoIdentity : DataIdentity
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
				// Debug.LogError ("clientData null: " + this);
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
				// Debug.LogError ("clientData null: " + this);
			}
		}

		#endregion

		#region nonPawnMaterial

		public SyncListInt nonPawnMaterial = new SyncListInt();

		private void OnNonPawnMaterialChanged(SyncList<System.Int32>.Operation op, int index, int item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.nonPawnMaterial, this.nonPawnMaterial, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region castlingRights

		[SyncVar(hook="onChangeCastlingRights")]
		public System.Int32 castlingRights;

		public void onChangeCastlingRights(System.Int32 newCastlingRights)
		{
			this.castlingRights = newCastlingRights;
			if (this.netData.clientData != null) {
				this.netData.clientData.castlingRights.v = newCastlingRights;
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
				// Debug.LogError ("clientData null: " + this);
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
				// Debug.LogError ("clientData null: " + this);
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
				// Debug.LogError ("clientData null: " + this);
			}
		}

		#endregion

		#region epSquare

		[SyncVar(hook="onChangeEpSquare")]
		public System.Int32 epSquare;

		public void onChangeEpSquare(System.Int32 newEpSquare)
		{
			this.epSquare = newEpSquare;
			if (this.netData.clientData != null) {
				this.netData.clientData.epSquare.v = newEpSquare;
			} else {
				// Debug.LogError ("clientData null: " + this);
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
				// Debug.LogError ("clientData null: " + this);
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
				// Debug.LogError ("clientData null: " + this);
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
				// Debug.LogError ("clientData null: " + this);
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
				// Debug.Log ("clientData null: " + this);
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
				// Debug.Log ("clientData null: " + this);
			}
		}
		#endregion

		#endregion

		#region NetData

		private NetData<StateInfo> netData = new NetData<StateInfo>();

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
				this.onChangePawnKey (this.pawnKey);
				this.onChangeMaterialKey (this.materialKey);
				IdentityUtils.refresh (this.netData.clientData.nonPawnMaterial, this.nonPawnMaterial);
				this.onChangeCastlingRights (this.castlingRights);
				this.onChangeRule50 (this.rule50);
				this.onChangePliesFromNull (this.pliesFromNull);
				this.onChangePsq (this.psq);
				this.onChangeEpSquare (this.epSquare);
				this.onChangeKey (this.key);
				this.onChangeCheckersBB (this.checkersBB);
				this.onChangeCapturedPiece (this.capturedPiece);
				IdentityUtils.refresh (this.netData.clientData.blockersForKing, this.blockersForKing, MyUInt64.uLongConvert);
				IdentityUtils.refresh (this.netData.clientData.pinnersForKing, this.pinnersForKing, MyUInt64.uLongConvert);
				IdentityUtils.refresh (this.netData.clientData.checkSquares, this.checkSquares, MyUInt64.uLongConvert);
			} else {
				// Debug.Log ("clientData null: " + this);
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.pawnKey);
				ret += GetDataSize (this.materialKey);
				ret += GetDataSize (this.nonPawnMaterial);
				ret += GetDataSize (this.castlingRights);
				ret += GetDataSize (this.rule50);
				ret += GetDataSize (this.pliesFromNull);
				ret += GetDataSize (this.psq);
				ret += GetDataSize (this.epSquare);
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
			if (data is StateInfo) {
				StateInfo stateInfo = data as StateInfo;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, stateInfo.makeSearchInforms ());
					this.pawnKey = stateInfo.pawnKey.v;
					this.materialKey = stateInfo.materialKey.v;
					IdentityUtils.InitSync(this.nonPawnMaterial, stateInfo.nonPawnMaterial.vs);
					this.castlingRights = stateInfo.castlingRights.v;
					this.rule50 = stateInfo.rule50.v;
					this.pliesFromNull = stateInfo.pliesFromNull.v;
					this.psq = stateInfo.psq.v;
					this.epSquare = stateInfo.epSquare.v;
					this.key = stateInfo.key.v;
					this.checkersBB = stateInfo.checkersBB.v;
					this.capturedPiece = stateInfo.capturedPiece.v;
					IdentityUtils.InitSync(this.blockersForKing, stateInfo.blockersForKing, MyUInt64.myUInt64Convert);
					IdentityUtils.InitSync(this.pinnersForKing, stateInfo.pinnersForKing, MyUInt64.myUInt64Convert);
					IdentityUtils.InitSync(this.checkSquares, stateInfo.checkSquares, MyUInt64.myUInt64Convert);
				}
				this.getDataSize ();
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
			if (data is StateInfo) {
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
			if (wrapProperty.p is StateInfo) {
				switch ((StateInfo.Property)wrapProperty.n) {
				case StateInfo.Property.pawnKey:
					this.pawnKey = (ulong)wrapProperty.getValue ();
					break;
				case StateInfo.Property.materialKey:
					this.materialKey = (ulong)wrapProperty.getValue ();
					break;
				case StateInfo.Property.nonPawnMaterial:
					IdentityUtils.UpdateSyncList (this.nonPawnMaterial, syncs, GlobalCast<T>.CastingInt32);
					break;
				case StateInfo.Property.castlingRights:
					this.castlingRights = (int)wrapProperty.getValue ();
					break;
				case StateInfo.Property.rule50:
					this.rule50 = (int)wrapProperty.getValue ();
					break;
				case StateInfo.Property.pliesFromNull:
					this.pliesFromNull = (int)wrapProperty.getValue ();
					break;
				case StateInfo.Property.psq:
					this.psq = (int)wrapProperty.getValue ();
					break;
				case StateInfo.Property.epSquare:
					this.epSquare = (int)wrapProperty.getValue ();
					break;
				case StateInfo.Property.key:
					this.key = (ulong)wrapProperty.getValue ();
					break;
				case StateInfo.Property.checkersBB:
					this.checkersBB = (ulong)wrapProperty.getValue ();
					break;
				case StateInfo.Property.capturedPiece:
					this.capturedPiece = (int)wrapProperty.getValue ();
					break;
				case StateInfo.Property.blockersForKing:
					IdentityUtils.UpdateSyncList (this.blockersForKing, syncs, GlobalCast<T>.CastingMyUInt64);
					break;
				case StateInfo.Property.pinnersForKing:
					IdentityUtils.UpdateSyncList (this.pinnersForKing, syncs, GlobalCast<T>.CastingMyUInt64);
					break;
				case StateInfo.Property.checkSquares:
					IdentityUtils.UpdateSyncList (this.checkSquares, syncs, GlobalCast<T>.CastingMyUInt64);
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

	}
}
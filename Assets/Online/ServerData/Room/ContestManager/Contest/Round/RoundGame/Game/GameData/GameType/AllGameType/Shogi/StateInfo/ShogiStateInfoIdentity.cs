using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Shogi
{
	public class ShogiStateInfoIdentity : DataIdentity
	{

		#region SyncVar

		#region material

		[SyncVar(hook="onChangeMaterial")]
		public int material;

		public void onChangeMaterial(int newMaterial)
		{
			this.material = newMaterial;
			if (this.netData.clientData != null) {
				this.netData.clientData.material.v = newMaterial;
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

		#region continuousCheck

		public SyncListInt continuousCheck = new SyncListInt();

		private void OnContinuousCheckChanged(SyncList<System.Int32>.Operation op, int index, int item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.continuousCheck, this.continuousCheck, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region boardKey

		[SyncVar(hook="onChangeBoardKey")]
		public System.UInt64 boardKey;

		public void onChangeBoardKey(System.UInt64 newBoardKey)
		{
			this.boardKey = newBoardKey;
			if (this.netData.clientData != null) {
				this.netData.clientData.boardKey.v = newBoardKey;
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}

		#endregion

		#region handKey

		[SyncVar(hook="onChangeHandKey")]
		public System.UInt64 handKey;

		public void onChangeHandKey(System.UInt64 newHandKey)
		{
			this.handKey = newHandKey;
			if (this.netData.clientData != null) {
				this.netData.clientData.handKey.v = newHandKey;
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}

		#endregion

		#region checkersBB

		[SyncVar(hook="onChangeCheckersBB")]
		public Common.BitBoard checkersBB;

		public void onChangeCheckersBB(Common.BitBoard newCheckersBB)
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
		public Common.Piece capturedPiece;

		public void onChangeCapturedPiece(Common.Piece newCapturedPiece)
		{
			this.capturedPiece = newCapturedPiece;
			if (this.netData.clientData != null) {
				this.netData.clientData.capturedPiece.v = newCapturedPiece;
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}

		#endregion

		#region hand

		[SyncVar(hook="onChangeHand")]
		public System.UInt32 hand;

		public void onChangeHand(System.UInt32 newHand)
		{
			this.hand = newHand;
			if (this.netData.clientData != null) {
				this.netData.clientData.hand.v = newHand;
			} else {
				// Debug.LogError ("clientData null: " + this);
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
			this.continuousCheck.Callback += OnContinuousCheckChanged;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeMaterial(this.material);
				this.onChangePliesFromNull(this.pliesFromNull);
				IdentityUtils.refresh(this.netData.clientData.continuousCheck, this.continuousCheck);
				this.onChangeBoardKey(this.boardKey);
				this.onChangeHandKey(this.handKey);
				this.onChangeCheckersBB(this.checkersBB);
				this.onChangeCapturedPiece(this.capturedPiece);
				this.onChangeHand(this.hand);
			} else {
				// Debug.Log ("clientData null: " + this);
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.material);
				ret += GetDataSize (this.pliesFromNull);
				ret += GetDataSize (this.continuousCheck);
				ret += GetDataSize (this.boardKey);
				ret += GetDataSize (this.handKey);
				ret += 8 + 8; // GetDataSize (this.checkersBB);
				ret += 4;// GetDataSize (this.capturedPiece);
				ret += GetDataSize (this.hand);
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
					this.material = stateInfo.material.v;
					this.pliesFromNull = stateInfo.pliesFromNull.v;
					IdentityUtils.InitSync(this.continuousCheck, stateInfo.continuousCheck.vs);
					this.boardKey = stateInfo.boardKey.v;
					this.handKey = stateInfo.handKey.v;
					this.checkersBB = stateInfo.checkersBB.v;
					this.capturedPiece = stateInfo.capturedPiece.v;
					this.hand = stateInfo.hand.v;
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
				case StateInfo.Property.material:
					this.material = (int)wrapProperty.getValue ();
					break;
				case StateInfo.Property.pliesFromNull:
					this.pliesFromNull = (int)wrapProperty.getValue ();
					break;
				case StateInfo.Property.continuousCheck:
					IdentityUtils.UpdateSyncList (this.continuousCheck, syncs, GlobalCast<T>.CastingInt32);
					break;
				case StateInfo.Property.boardKey:
					this.boardKey = (ulong)wrapProperty.getValue ();
					break;
				case StateInfo.Property.handKey:
					this.handKey = (ulong)wrapProperty.getValue ();
					break;
				case StateInfo.Property.checkersBB:
					this.checkersBB = (Common.BitBoard)wrapProperty.getValue ();
					break;
				case StateInfo.Property.capturedPiece:
					this.capturedPiece = (Common.Piece)wrapProperty.getValue ();
					break;
				case StateInfo.Property.hand:
					this.hand = (uint)wrapProperty.getValue ();
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
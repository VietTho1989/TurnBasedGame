using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Shogi
{
	public class ShogiIdentity : DataIdentity
	{

		#region SyncVar

		#region byTypeBB

		public Common.SyncListBitBoard byTypeBB = new Common.SyncListBitBoard();

		private void OnByTypeBBChanged(SyncList<Common.BitBoard>.Operation op, int index, Common.BitBoard item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.byTypeBB, this.byTypeBB, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}

		#endregion

		#region byColorBB

		public Common.SyncListBitBoard byColorBB = new Common.SyncListBitBoard();

		private void OnByColorBBChanged(SyncList<Common.BitBoard>.Operation op, int index, Common.BitBoard item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.byColorBB, this.byColorBB, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region goldsBB

		[SyncVar(hook="onChangeGoldsBB")]
		public Common.BitBoard goldsBB;

		public void onChangeGoldsBB(Common.BitBoard newGoldsBB)
		{
			this.goldsBB = newGoldsBB;
			if (this.netData.clientData != null) {
				this.netData.clientData.goldsBB.v = newGoldsBB;
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}

		#endregion

		#region piece

		public SyncListInt piece = new SyncListInt();

		private void OnPieceChanged(SyncList<int>.Operation op, int index, int item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.piece, this.piece, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}

		#endregion

		#region kingSquare

		public SyncListInt kingSquare = new SyncListInt();

		private void OnKingSquareChanged(SyncList<int>.Operation op, int index, int item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.kingSquare, this.kingSquare, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region hand

		public SyncListUInt hand = new SyncListUInt();

		private void OnHandChanged(SyncList<System.UInt32>.Operation op, int index, uint item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.hand, this.hand, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region turn

		[SyncVar(hook="onChangeTurn")]
		public int turn;

		public void onChangeTurn(int newTurn)
		{
			this.turn = newTurn;
			if (this.netData.clientData != null) {
				this.netData.clientData.turn.v = newTurn;
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}

		#endregion

		#region startState

		[SyncVar]
		public int startState;

		#endregion

		#region st

		[SyncVar]
		public int st;

		#endregion

		#region gamePly

		[SyncVar(hook="onChangeGamePly")]
		public System.Int32 gamePly;

		public void onChangeGamePly(System.Int32 newGamePly)
		{
			this.gamePly = newGamePly;
			if (this.netData.clientData != null) {
				this.netData.clientData.gamePly.v = newGamePly;
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}

		#endregion

		#region nodes

		[SyncVar(hook="onChangeNodes")]
		public System.Int64 nodes;

		public void onChangeNodes(System.Int64 newNodes)
		{
			this.nodes = newNodes;
			if (this.netData.clientData != null) {
				this.netData.clientData.nodes.v = newNodes;
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}

		#endregion

		#region isCustom

		[SyncVar(hook="onChangeIsCustom")]
		public bool isCustom;

		public void onChangeIsCustom(bool newIsCustom)
		{
			this.isCustom = newIsCustom;
			if (this.netData.clientData != null) {
				this.netData.clientData.isCustom.v = newIsCustom;
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<Shogi> netData = new NetData<Shogi>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void addSyncListCallBack ()
		{
			base.addSyncListCallBack ();
			this.byTypeBB.Callback += OnByTypeBBChanged;
			this.byColorBB.Callback += OnByColorBBChanged;
			this.piece.Callback += OnPieceChanged;
			this.kingSquare.Callback += OnKingSquareChanged;
			this.hand.Callback += OnHandChanged;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				IdentityUtils.refresh(this.netData.clientData.byTypeBB, this.byTypeBB);
				IdentityUtils.refresh(this.netData.clientData.byColorBB, this.byColorBB);
				this.onChangeGoldsBB(this.goldsBB);
				IdentityUtils.refresh (this.netData.clientData.piece, this.piece);
				IdentityUtils.refresh (this.netData.clientData.kingSquare, this.kingSquare);
				IdentityUtils.refresh(this.netData.clientData.hand, this.hand);
				this.onChangeTurn(this.turn);
				this.onChangeGamePly(this.gamePly);
				this.onChangeNodes(this.nodes);
				this.onChangeIsCustom (this.isCustom);
			} else {
				Debug.Log ("clientData null: " + this);
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.byTypeBB);
				ret += GetDataSize (this.byColorBB);
				ret += 8 + 8;// GetDataSize (this.goldsBB);
				ret += GetDataSize (this.piece);
				ret += GetDataSize (this.kingSquare);
				ret += GetDataSize (this.hand);
				ret += GetDataSize (this.turn);
				ret += GetDataSize (this.gamePly);
				ret += GetDataSize (this.nodes);
				ret += GetDataSize (this.isCustom);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is Shogi) {
				Shogi shogi = data as Shogi;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, shogi.makeSearchInforms ());
					IdentityUtils.InitSync (this.byTypeBB, shogi.byTypeBB.vs);
					IdentityUtils.InitSync (this.byColorBB, shogi.byColorBB.vs);
					this.goldsBB = shogi.goldsBB.v;
					IdentityUtils.InitSync (this.piece, shogi.piece.vs);
					IdentityUtils.InitSync (this.kingSquare, shogi.kingSquare.vs);
					IdentityUtils.InitSync (this.hand, shogi.hand.vs);
					this.turn = shogi.turn.v;
					this.startState = shogi.startState.vs.Count;
					this.st = shogi.st.vs.Count;
					this.gamePly = shogi.gamePly.v;
					this.nodes = shogi.nodes.v;
					this.isCustom = shogi.isCustom.v;
				}
				this.getDataSize ();
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (shogi);
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
			if (data is Shogi) {
				// Shogi shogi = data as Shogi;
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
			if (wrapProperty.p is Shogi) {
				switch ((Shogi.Property)wrapProperty.n) {
				case Shogi.Property.byTypeBB:
					IdentityUtils.UpdateSyncList (this.byTypeBB, syncs, GlobalCast<T>.CastingShogi_Common_BitBoard); 
					break;
				case Shogi.Property.byColorBB:
					IdentityUtils.UpdateSyncList (this.byColorBB, syncs, GlobalCast<T>.CastingShogi_Common_BitBoard);
					break;
				case Shogi.Property.goldsBB:
					this.goldsBB = (Common.BitBoard)wrapProperty.getValue ();
					break;
				case Shogi.Property.piece:
					IdentityUtils.UpdateSyncList (this.piece, syncs, GlobalCast<T>.CastingInt32);
					break;
				case Shogi.Property.kingSquare:
					IdentityUtils.UpdateSyncList (this.kingSquare, syncs, GlobalCast<T>.CastingInt32);
					break;
				case Shogi.Property.hand:
					IdentityUtils.UpdateSyncList (this.hand, syncs, GlobalCast<T>.CastingUInt32);
					break;
				case Shogi.Property.turn:
					this.turn = (int)wrapProperty.getValue ();
					break;
				case Shogi.Property.startState:
					{
						Shogi shogi = wrapProperty.p as Shogi;
						this.startState = shogi.startState.vs.Count;
					}
					break;
				case Shogi.Property.st:
					{
						Shogi shogi = wrapProperty.p as Shogi;
						this.st = shogi.st.vs.Count;
					}
					break;
				case Shogi.Property.gamePly:
					this.gamePly = (int)wrapProperty.getValue ();
					break;
				case Shogi.Property.nodes:
					this.nodes = (long)wrapProperty.getValue ();
					break;
				case Shogi.Property.isCustom:
					this.isCustom = (bool)wrapProperty.getValue ();
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
		}

		#endregion
	}
}
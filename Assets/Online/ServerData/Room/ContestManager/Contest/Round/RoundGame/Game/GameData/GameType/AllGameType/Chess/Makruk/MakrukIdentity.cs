using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Makruk
{
	public class MakrukIdentity : DataIdentity
	{

		#region SyncVar

		#region board

		public SyncListInt board = new SyncListInt();

		private void OnBoardChanged(SyncListInt.Operation op, int index, int item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.board, this.board, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region byTypeBB

		public SyncListUInt64 byTypeBB = new SyncListUInt64();

		private void OnByTypeBBChanged(SyncListUInt64.Operation op, int index, MyUInt64 item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.byTypeBB, this.byTypeBB, op, index, MyUInt64.uLongConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region byColorBB

		public SyncListUInt64 byColorBB = new SyncListUInt64();

		private void OnByColorBBChanged(SyncListUInt64.Operation op, int index, MyUInt64 item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.byColorBB, this.byColorBB, op, index, MyUInt64.uLongConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region pieceCount

		public SyncListInt pieceCount = new SyncListInt();

		private void OnPieceCountChanged(SyncListInt.Operation op, int index, int pieceCount)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.pieceCount, this.pieceCount, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region pieceList

		public SyncListInt pieceList = new SyncListInt();

		private void OnPieceListChanged(SyncListInt.Operation op, int index, int piece)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.pieceList, this.pieceList, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region index

		public SyncListInt index = new SyncListInt();

		private void OnIndexChanged(SyncListInt.Operation op, int index, int item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.index, this.index, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
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
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region sideToMove

		[SyncVar(hook="onChangeSideToMove")]
		public System.Int32 sideToMove;

		public void onChangeSideToMove(System.Int32 newSideToMove)
		{
			this.sideToMove = newSideToMove;
			if (this.netData.clientData != null) {
				this.netData.clientData.sideToMove.v = newSideToMove;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region st

		[SyncVar]
		public int st;

		#endregion

		#region chess960

		[SyncVar(hook="onChangeChess960")]
		public System.Boolean chess960;

		public void onChangeChess960(System.Boolean newChess960)
		{
			this.chess960 = newChess960;
			if (this.netData.clientData != null) {
				this.netData.clientData.chess960.v = newChess960;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region isCustom

		[SyncVar(hook="onChangeIsCustom")]
		public System.Boolean isCustom;

		public void onChangeIsCustom(System.Boolean newIsCustom)
		{
			this.isCustom = newIsCustom;
			if (this.netData.clientData != null) {
				this.netData.clientData.isCustom.v = newIsCustom;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<Makruk> netData = new NetData<Makruk>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void addSyncListCallBack ()
		{
			base.addSyncListCallBack ();
			this.board.Callback += OnBoardChanged;
			this.byTypeBB.Callback += OnByTypeBBChanged;
			this.byColorBB.Callback += OnByColorBBChanged;
			this.pieceCount.Callback += OnPieceCountChanged;
			this.pieceList.Callback += OnPieceListChanged;
			this.index.Callback += OnIndexChanged;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				IdentityUtils.refresh(this.netData.clientData.board, this.board);
				IdentityUtils.refresh(this.netData.clientData.byTypeBB, this.byTypeBB, MyUInt64.uLongConvert);
				IdentityUtils.refresh(this.netData.clientData.byColorBB, this.byColorBB, MyUInt64.uLongConvert);
				IdentityUtils.refresh(this.netData.clientData.pieceCount, this.pieceCount);
				IdentityUtils.refresh(this.netData.clientData.pieceList, this.pieceList);
				IdentityUtils.refresh(this.netData.clientData.index, this.index);
				this.onChangeGamePly(this.gamePly);
				this.onChangeSideToMove(this.sideToMove);
				this.onChangeChess960(this.chess960);
				this.onChangeIsCustom(this.isCustom);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.board);
				ret += GetDataSize (this.byTypeBB);
				ret += GetDataSize (this.byColorBB);
				ret += GetDataSize (this.pieceCount);
				ret += GetDataSize (this.pieceList);
				ret += GetDataSize (this.index);
				ret += GetDataSize (this.gamePly);
				ret += GetDataSize (this.sideToMove);
				ret += GetDataSize (this.chess960);
				ret += GetDataSize (this.isCustom);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is Makruk) {
				Makruk makruk = data as Makruk;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, makruk.makeSearchInforms ());
					IdentityUtils.InitSync(this.board, makruk.board.vs);
					IdentityUtils.InitSync(this.byTypeBB, makruk.byTypeBB, MyUInt64.myUInt64Convert);
					IdentityUtils.InitSync(this.byColorBB, makruk.byColorBB, MyUInt64.myUInt64Convert);
					IdentityUtils.InitSync(this.pieceCount, makruk.pieceCount.vs);
					IdentityUtils.InitSync(this.pieceList, makruk.pieceList.vs);
					IdentityUtils.InitSync(this.index, makruk.index.vs);
					this.gamePly = makruk.gamePly.v;
					this.sideToMove = makruk.sideToMove.v;
					this.st = makruk.st.vs.Count;
					this.chess960 = makruk.chess960.v;
					this.isCustom = makruk.isCustom.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (makruk);
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
			if (data is Makruk) {
				// Makruk makruk = data as Makruk;
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
			if (wrapProperty.p is Makruk) {
				switch ((Makruk.Property)wrapProperty.n) {
				case Makruk.Property.board:
					IdentityUtils.UpdateSyncList (this.board, syncs, GlobalCast<T>.CastingInt32);
					break;
				case Makruk.Property.byTypeBB:
					IdentityUtils.UpdateSyncList (this.byTypeBB, syncs, GlobalCast<T>.CastingMyUInt64);
					break;
				case Makruk.Property.byColorBB:
					IdentityUtils.UpdateSyncList (this.byColorBB, syncs, GlobalCast<T>.CastingMyUInt64);
					break;
				case Makruk.Property.pieceCount:
					IdentityUtils.UpdateSyncList (this.pieceCount, syncs, GlobalCast<T>.CastingInt32);
					break;
				case Makruk.Property.pieceList:
					IdentityUtils.UpdateSyncList (this.pieceList, syncs, GlobalCast<T>.CastingInt32);
					break;
				case Makruk.Property.index:
					IdentityUtils.UpdateSyncList (this.index, syncs, GlobalCast<T>.CastingInt32);
					break;
				case Makruk.Property.gamePly:
					this.gamePly = (System.Int32)wrapProperty.getValue ();
					break;
				case Makruk.Property.sideToMove:
					this.sideToMove = (System.Int32)wrapProperty.getValue ();
					break;
				case Makruk.Property.st:
					{
						Makruk makruk = wrapProperty.p as Makruk;
						this.st = makruk.st.vs.Count;
					}
					break;
				case Makruk.Property.chess960:
					this.chess960 = (System.Boolean)wrapProperty.getValue ();
					break;
				case Makruk.Property.isCustom:
					this.isCustom = (System.Boolean)wrapProperty.getValue ();
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
using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi
{
	public class XiangqiIdentity : DataIdentity
	{

		#region SyncVar

		#region sdPlayer

		[SyncVar(hook="onChangeSdPlayer")]
		public System.Int32 sdPlayer;

		public void onChangeSdPlayer(System.Int32 newSdPlayer)
		{
			this.sdPlayer = newSdPlayer;
			if (this.netData.clientData != null) {
				this.netData.clientData.sdPlayer.v = newSdPlayer;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region ucpcSquares

		public SyncListByte ucpcSquares = new SyncListByte();

		private void OnUcpcSquaresChanged(SyncListByte.Operation op, int index, MyByte item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.ucpcSquares, this.ucpcSquares, op, index, MyByte.byteConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region ucsqPieces

		public SyncListByte ucsqPieces = new SyncListByte();

		private void OnUcsqPiecesChanged(SyncListByte.Operation op, int index, MyByte item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.ucsqPieces, this.ucsqPieces, op, index, MyByte.byteConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region dwBitPiece

		[SyncVar(hook="onChangeDwBitPiece")]
		public System.UInt32 dwBitPiece;

		public void onChangeDwBitPiece(System.UInt32 newDwBitPiece)
		{
			this.dwBitPiece = newDwBitPiece;
			if (this.netData.clientData != null) {
				this.netData.clientData.dwBitPiece.v = newDwBitPiece;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region wBitRanks

		public SyncListUShort wBitRanks = new SyncListUShort();

		private void OnWBitRanksChanged(SyncListUShort.Operation op, int index, MyUShort item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.wBitRanks, this.wBitRanks, op, index, MyUShort.ushortConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region wBitFiles

		public SyncListUShort wBitFiles = new SyncListUShort();

		private void OnWBitFilesChanged(SyncListUShort.Operation op, int index, MyUShort item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.wBitFiles, this.wBitFiles, op, index, MyUShort.ushortConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region vlWhite

		[SyncVar(hook="onChangeVlWhite")]
		public System.Int32 vlWhite;

		public void onChangeVlWhite(System.Int32 newVlWhite)
		{
			this.vlWhite = newVlWhite;
			if (this.netData.clientData != null) {
				this.netData.clientData.vlWhite.v = newVlWhite;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region vlBlack

		[SyncVar(hook="onChangeVlBlack")]
		public System.Int32 vlBlack;

		public void onChangeVlBlack(System.Int32 newVlBlack)
		{
			this.vlBlack = newVlBlack;
			if (this.netData.clientData != null) {
				this.netData.clientData.vlBlack.v = newVlBlack;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region nMoveNum

		[SyncVar(hook="onChangeNMoveNum")]
		public System.Int32 nMoveNum;

		public void onChangeNMoveNum(System.Int32 newNMoveNum)
		{
			this.nMoveNum = newNMoveNum;
			if (this.netData.clientData != null) {
				this.netData.clientData.nMoveNum.v = newNMoveNum;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region nDistance

		[SyncVar(hook="onChangeNDistance")]
		public System.Int32 nDistance;

		public void onChangeNDistance(System.Int32 newNDistance)
		{
			this.nDistance = newNDistance;
			if (this.netData.clientData != null) {
				this.netData.clientData.nDistance.v = newNDistance;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region rbsList

		[SyncVar]
		public int rbsList;

		#endregion

		#region ucRepHash

		public SyncListUInt ucRepHash = new SyncListUInt();

		private void OnUcRepHashChanged(SyncListUInt.Operation op, int index, uint item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.ucRepHash, this.ucRepHash, op, index);
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
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<Xiangqi> netData = new NetData<Xiangqi>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void addSyncListCallBack ()
		{
			base.addSyncListCallBack ();
			this.ucpcSquares.Callback += OnUcpcSquaresChanged;
			this.ucsqPieces.Callback += OnUcsqPiecesChanged;
			this.wBitRanks.Callback += OnWBitRanksChanged;
			this.wBitFiles.Callback += OnWBitFilesChanged;
			this.ucRepHash.Callback += OnUcRepHashChanged;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeSdPlayer (this.sdPlayer);
				IdentityUtils.refresh (this.netData.clientData.ucpcSquares, this.ucpcSquares, MyByte.byteConvert);
				IdentityUtils.refresh (this.netData.clientData.ucsqPieces, this.ucsqPieces, MyByte.byteConvert);
				this.onChangeDwBitPiece (this.dwBitPiece);
				IdentityUtils.refresh (this.netData.clientData.wBitRanks, this.wBitRanks, MyUShort.ushortConvert);
				IdentityUtils.refresh (this.netData.clientData.wBitFiles, this.wBitFiles, MyUShort.ushortConvert);
				this.onChangeVlWhite (this.vlWhite);
				this.onChangeVlBlack (this.vlBlack);
				this.onChangeNMoveNum (this.nMoveNum);
				this.onChangeNDistance (this.nDistance);
				IdentityUtils.refresh (this.netData.clientData.ucRepHash, this.ucRepHash);
				this.onChangeIsCustom (this.isCustom);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.sdPlayer);
				ret += GetDataSize (this.ucpcSquares);
				ret += GetDataSize (this.ucsqPieces);
				ret += GetDataSize (this.dwBitPiece);
				ret += GetDataSize (this.wBitRanks);
				ret += GetDataSize (this.wBitFiles);
				ret += GetDataSize (this.vlWhite);
				ret += GetDataSize (this.vlBlack);
				ret += GetDataSize (this.nMoveNum);
				ret += GetDataSize (this.nDistance);
				ret += GetDataSize (this.ucRepHash);
				ret += GetDataSize (this.isCustom);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is Xiangqi) {
				Xiangqi xiangqi = data as Xiangqi;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, xiangqi.makeSearchInforms ());
					this.sdPlayer = xiangqi.sdPlayer.v;
					IdentityUtils.InitSync(this.ucpcSquares, xiangqi.ucpcSquares, MyByte.myByteConvert);
					IdentityUtils.InitSync(this.ucsqPieces, xiangqi.ucsqPieces, MyByte.myByteConvert);
					this.dwBitPiece = xiangqi.dwBitPiece.v;
					IdentityUtils.InitSync(this.wBitRanks, xiangqi.wBitRanks, MyUShort.myUShortConvert);
					IdentityUtils.InitSync(this.wBitFiles, xiangqi.wBitFiles, MyUShort.myUShortConvert);
					this.vlWhite = xiangqi.vlWhite.v;
					this.vlBlack = xiangqi.vlBlack.v;
					this.nMoveNum = xiangqi.nMoveNum.v;
					this.nDistance = xiangqi.nDistance.v;
					this.rbsList = xiangqi.rbsList.vs.Count;
					IdentityUtils.InitSync(this.ucRepHash, xiangqi.ucRepHash.vs);
					this.isCustom = xiangqi.isCustom.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (xiangqi);
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
			if (data is Xiangqi) {
				// Xiangqi xiangqi = data as Xiangqi;
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
			if (wrapProperty.p is Xiangqi) {
				switch ((Xiangqi.Property)wrapProperty.n) {
				case Xiangqi.Property.sdPlayer:
					this.sdPlayer = (System.Int32)wrapProperty.getValue ();
					break;
				case Xiangqi.Property.ucpcSquares:
					IdentityUtils.UpdateSyncList (this.ucpcSquares, syncs, GlobalCast<T>.CastingMyByte);
					break;
				case Xiangqi.Property.ucsqPieces:
					IdentityUtils.UpdateSyncList (this.ucsqPieces, syncs, GlobalCast<T>.CastingMyByte);
					break;
				case Xiangqi.Property.zobr:
					break;
				case Xiangqi.Property.dwBitPiece:
					this.dwBitPiece = (System.UInt32)wrapProperty.getValue ();
					break;
				case Xiangqi.Property.wBitRanks:
					IdentityUtils.UpdateSyncList (this.wBitRanks, syncs, GlobalCast<T>.CastingMyUShort);
					break;
				case Xiangqi.Property.wBitFiles:
					IdentityUtils.UpdateSyncList (this.wBitFiles, syncs, GlobalCast<T>.CastingMyUShort);
					break;
				case Xiangqi.Property.vlWhite:
					this.vlWhite = (System.Int32)wrapProperty.getValue ();
					break;
				case Xiangqi.Property.vlBlack:
					this.vlBlack = (System.Int32)wrapProperty.getValue ();
					break;
				case Xiangqi.Property.nMoveNum:
					this.nMoveNum = (System.Int32)wrapProperty.getValue ();
					break;
				case Xiangqi.Property.nDistance:
					this.nDistance = (System.Int32)wrapProperty.getValue ();
					break;
				case Xiangqi.Property.rbsList:
					{
						Xiangqi xiangqi = wrapProperty.p as Xiangqi;
						this.rbsList = xiangqi.rbsList.vs.Count;
					}
					break;
				case Xiangqi.Property.ucRepHash:
					IdentityUtils.UpdateSyncList (this.ucRepHash, syncs, GlobalCast<T>.CastingUInt32);
					break;
				case Xiangqi.Property.isCustom:
					this.isCustom = (bool)wrapProperty.getValue ();
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
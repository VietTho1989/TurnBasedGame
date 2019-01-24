using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
	public class BoardIdentity : DataIdentity
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

		#region size2

		[SyncVar(hook="onChangeSize2")]
		public System.Int32 size2;

		public void onChangeSize2(System.Int32 newSize2)
		{
			this.size2 = newSize2;
			if (this.netData.clientData != null) {
				this.netData.clientData.size2.v = newSize2;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region bits2

		[SyncVar(hook="onChangeBits2")]
		public System.Int32 bits2;

		public void onChangeBits2(System.Int32 newBits2)
		{
			this.bits2 = newBits2;
			if (this.netData.clientData != null) {
				this.netData.clientData.bits2.v = newBits2;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region captures

		public SyncListInt captures = new SyncListInt();

		private void OnCapturesChanged(SyncListInt.Operation op, int index, int item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.captures, this.captures, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region komi

		[SyncVar(hook="onChangeKomi")]
		public System.Single komi;

		public void onChangeKomi(System.Single newKomi)
		{
			this.komi = newKomi;
			if (this.netData.clientData != null) {
				this.netData.clientData.komi.v = newKomi;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region handicap

		[SyncVar(hook="onChangeHandicap")]
		public System.Int32 handicap;

		public void onChangeHandicap(System.Int32 newHandicap)
		{
			this.handicap = newHandicap;
			if (this.netData.clientData != null) {
				this.netData.clientData.handicap.v = newHandicap;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region rules

		[SyncVar(hook="onChangeRules")]
		public System.Int32 rules;

		public void onChangeRules(System.Int32 newRules)
		{
			this.rules = newRules;
			if (this.netData.clientData != null) {
				this.netData.clientData.rules.v = newRules;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region moves

		[SyncVar(hook="onChangeMoves")]
		public System.Int32 moves;

		public void onChangeMoves(System.Int32 newMoves)
		{
			this.moves = newMoves;
			if (this.netData.clientData != null) {
				this.netData.clientData.moves.v = newMoves;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region superko_violation

		[SyncVar(hook="onChangeSuperko_violation")]
		public System.Byte superko_violation;

		public void onChangeSuperko_violation(System.Byte newSuperko_violation)
		{
			this.superko_violation = newSuperko_violation;
			if (this.netData.clientData != null) {
				this.netData.clientData.superko_violation.v = newSuperko_violation;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region b

		public SyncListInt b = new SyncListInt();

		private void OnBChanged(SyncListInt.Operation op, int index, int item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.b, this.b, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region g

		public SyncListInt g = new SyncListInt();

		private void OnGChanged(SyncListInt.Operation op, int index, int item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.g, this.g, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}
		#endregion

		#region pp

		public SyncListInt pp = new SyncListInt();

		private void OnPpChanged(SyncListInt.Operation op, int index, int item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.pp, this.pp, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}

		#endregion

		#region pat3

		public SyncListUInt pat3 = new SyncListUInt();

		private void OnPat3Changed(SyncListUInt.Operation op, int index, uint item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.pat3, this.pat3, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}

		#endregion

		#region gi

		[SyncVar]
		public int gi;

		#endregion

		#region c

		public SyncListInt c = new SyncListInt();

		private void OnCChanged(SyncListInt.Operation op, int index, int item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.c, this.c, op, index);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}

		#endregion

		#region clen

		[SyncVar(hook="onChangeClen")]
		public System.Int32 clen;

		public void onChangeClen(System.Int32 newClen)
		{
			this.clen = newClen;
			if (this.netData.clientData != null) {
				this.netData.clientData.clen.v = newClen;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region last_ko_age

		[SyncVar(hook="onChangeLast_ko_age")]
		public System.Int32 last_ko_age;

		public void onChangeLast_ko_age(System.Int32 newLast_ko_age)
		{
			this.last_ko_age = newLast_ko_age;
			if (this.netData.clientData != null) {
				this.netData.clientData.last_ko_age.v = newLast_ko_age;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region quicked

		[SyncVar(hook="onChangeQuicked")]
		public System.Int32 quicked;

		public void onChangeQuicked(System.Int32 newQuicked)
		{
			this.quicked = newQuicked;
			if (this.netData.clientData != null) {
				this.netData.clientData.quicked.v = newQuicked;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region history_hash

		public SyncListUInt64 history_hash = new SyncListUInt64();

		private void OnHistory_hashChanged(SyncListUInt64.Operation op, int index, MyUInt64 item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.history_hash, this.history_hash, op, index, MyUInt64.uLongConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}

		#endregion

		#region hash

		[SyncVar(hook="onChangeHash")]
		public System.UInt64 hash;

		public void onChangeHash(System.UInt64 newHash)
		{
			this.hash = newHash;
			if (this.netData.clientData != null) {
				this.netData.clientData.hash.v = newHash;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region qhash

		public SyncListUInt64 qhash = new SyncListUInt64();

		private void OnQhashChanged(SyncListUInt64.Operation op, int index, MyUInt64 item)
		{
			if (this.netData.clientData != null) {
				IdentityUtils.onSyncListChange (this.netData.clientData.qhash, this.qhash, op, index, MyUInt64.uLongConvert);
			} else {
				// Debug.LogError ("clientData null: " + this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<Board> netData = new NetData<Board>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void addSyncListCallBack ()
		{
			base.addSyncListCallBack ();
			this.captures.Callback += OnCapturesChanged;
			this.b.Callback += OnBChanged;
			this.g.Callback += OnGChanged;
			this.pp.Callback += OnPpChanged;
			this.pat3.Callback += OnPat3Changed;
			this.c.Callback += OnCChanged;
			this.history_hash.Callback += OnHistory_hashChanged;
			this.qhash.Callback += OnQhashChanged;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeSize(this.size);
				this.onChangeSize2(this.size2);
				this.onChangeBits2(this.bits2);
				IdentityUtils.refresh(this.netData.clientData.captures, this.captures);
				this.onChangeKomi(this.komi);
				this.onChangeHandicap(this.handicap);
				this.onChangeRules(this.rules);
				this.onChangeMoves(this.moves);
				this.onChangeSuperko_violation(this.superko_violation);
				IdentityUtils.refresh(this.netData.clientData.b, this.b);
				IdentityUtils.refresh(this.netData.clientData.g, this.g);
				IdentityUtils.refresh(this.netData.clientData.pp, this.pp);
				IdentityUtils.refresh(this.netData.clientData.pat3, this.pat3);
				IdentityUtils.refresh(this.netData.clientData.c, this.c);
				this.onChangeClen(this.clen);
				this.onChangeLast_ko_age(this.last_ko_age);
				this.onChangeQuicked(this.quicked);
				IdentityUtils.refresh(this.netData.clientData.history_hash, this.history_hash, MyUInt64.uLongConvert);
				this.onChangeHash(this.hash);
				IdentityUtils.refresh(this.netData.clientData.qhash, this.qhash, MyUInt64.uLongConvert);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.size);
				ret += GetDataSize (this.size2);
				ret += GetDataSize (this.bits2);
				ret += GetDataSize (this.captures);
				ret += GetDataSize (this.komi);
				ret += GetDataSize (this.handicap);
				ret += GetDataSize (this.rules);
				ret += GetDataSize (this.moves);
				ret += GetDataSize (this.superko_violation);
				ret += GetDataSize (this.b);
				ret += GetDataSize (this.g);
				ret += GetDataSize (this.pp);
				ret += GetDataSize (this.pat3);
				ret += GetDataSize (this.c);
				ret += GetDataSize (this.clen);
				ret += GetDataSize (this.last_ko_age);
				ret += GetDataSize (this.quicked);
				ret += GetDataSize (this.history_hash);
				ret += GetDataSize (this.hash);
				ret += GetDataSize (this.qhash);
				return ret;
			}
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is Board) {
				Board board = data as Board;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, board.makeSearchInforms ());
					this.size = board.size.v;
					this.size2 = board.size2.v;
					this.bits2 = board.bits2.v;
					IdentityUtils.InitSync(this.captures, board.captures.vs);
					this.komi = board.komi.v;
					this.handicap = board.handicap.v;
					this.rules = board.rules.v;
					this.moves = board.moves.v;
					this.superko_violation = board.superko_violation.v;
					IdentityUtils.InitSync(this.b, board.b.vs);
					IdentityUtils.InitSync(this.g, board.g.vs);
					IdentityUtils.InitSync(this.pp, board.pp.vs);
					IdentityUtils.InitSync(this.pat3, board.pat3.vs);
					this.gi = board.gi.vs.Count;
					IdentityUtils.InitSync(this.c, board.c.vs);
					this.clen = board.clen.v;
					this.last_ko_age = board.last_ko_age.v;
					this.quicked = board.quicked.v;
					IdentityUtils.InitSync(this.history_hash, board.history_hash, MyUInt64.myUInt64Convert);
					this.hash = board.hash.v;
					IdentityUtils.InitSync(this.qhash, board.qhash, MyUInt64.myUInt64Convert);
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (board);
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
			if (data is Board) {
				// Board board = data as Board;
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
			if (wrapProperty.p is Board) {
				switch ((Board.Property)wrapProperty.n) {
				case Board.Property.size:
					this.size = (System.Int32)wrapProperty.getValue ();
					break;
				case Board.Property.size2:
					this.size2 = (System.Int32)wrapProperty.getValue ();
					break;
				case Board.Property.bits2:
					this.bits2 = (System.Int32)wrapProperty.getValue ();
					break;
				case Board.Property.captures:
					IdentityUtils.UpdateSyncList (this.captures, syncs, GlobalCast<T>.CastingInt32);
					break;
				case Board.Property.komi:
					this.komi = (System.Single)wrapProperty.getValue ();
					break;
				case Board.Property.handicap:
					this.handicap = (System.Int32)wrapProperty.getValue ();
					break;
				case Board.Property.rules:
					this.rules = (System.Int32)wrapProperty.getValue ();
					break;
				case Board.Property.moves:
					this.moves = (System.Int32)wrapProperty.getValue ();
					break;
				case Board.Property.last_move:
					break;
				case Board.Property.last_move2:
					break;
				case Board.Property.last_move3:
					break;
				case Board.Property.last_move4:
					break;
				case Board.Property.superko_violation:
					this.superko_violation = (System.Byte)wrapProperty.getValue ();
					break;
				case Board.Property.b:
					IdentityUtils.UpdateSyncList (this.b, syncs, GlobalCast<T>.CastingInt32);
					break;
				case Board.Property.g:
					IdentityUtils.UpdateSyncList (this.g, syncs, GlobalCast<T>.CastingInt32);
					break;
				case Board.Property.pp:
					IdentityUtils.UpdateSyncList (this.pp, syncs, GlobalCast<T>.CastingInt32);
					break;
				case Board.Property.pat3:
					IdentityUtils.UpdateSyncList (this.pat3, syncs, GlobalCast<T>.CastingUInt32);
					break;
				case Board.Property.gi:
					{
						Board board = wrapProperty.p as Board;
						this.gi = board.gi.vs.Count;
					}
					break;
				case Board.Property.c:
					IdentityUtils.UpdateSyncList (this.c, syncs, GlobalCast<T>.CastingInt32);
					break;
				case Board.Property.clen:
					this.clen = (System.Int32)wrapProperty.getValue ();
					break;
				case Board.Property.symmetry:
					break;
				case Board.Property.last_ko:
					break;
				case Board.Property.last_ko_age:
					this.last_ko_age = (System.Int32)wrapProperty.getValue ();
					break;
				case Board.Property.ko:
					break;
				case Board.Property.quicked:
					this.quicked = (System.Int32)wrapProperty.getValue ();
					break;
				case Board.Property.history_hash:
					IdentityUtils.UpdateSyncList (this.history_hash, syncs, GlobalCast<T>.CastingMyUInt64);
					break;
				case Board.Property.hash:
					this.hash = (System.UInt64)wrapProperty.getValue ();
					break;
				case Board.Property.qhash:
					IdentityUtils.UpdateSyncList (this.qhash, syncs, GlobalCast<T>.CastingMyUInt64);
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
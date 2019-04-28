using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught
{
	public class VarIdentity : DataIdentity
	{

		#region SyncVar

		#region Variant

		[SyncVar(hook="onChangeVariant")]
		public System.Int32 Variant;

		public void onChangeVariant(System.Int32 newVariant)
		{
			this.Variant = newVariant;
			if (this.netData.clientData != null) {
				this.netData.clientData.Variant.v = newVariant;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region Book

		[SyncVar(hook="onChangeBook")]
		public System.Boolean Book;

		public void onChangeBook(System.Boolean newBook)
		{
			this.Book = newBook;
			if (this.netData.clientData != null) {
				this.netData.clientData.Book.v = newBook;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region Book_Ply

		[SyncVar(hook="onChangeBook_Ply")]
		public System.Int32 Book_Ply;

		public void onChangeBook_Ply(System.Int32 newBook_Ply)
		{
			this.Book_Ply = newBook_Ply;
			if (this.netData.clientData != null) {
				this.netData.clientData.Book_Ply.v = newBook_Ply;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region Book_Margin

		[SyncVar(hook="onChangeBook_Margin")]
		public System.Int32 Book_Margin;

		public void onChangeBook_Margin(System.Int32 newBook_Margin)
		{
			this.Book_Margin = newBook_Margin;
			if (this.netData.clientData != null) {
				this.netData.clientData.Book_Margin.v = newBook_Margin;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region Ponder

		[SyncVar(hook="onChangePonder")]
		public System.Boolean Ponder;

		public void onChangePonder(System.Boolean newPonder)
		{
			this.Ponder = newPonder;
			if (this.netData.clientData != null) {
				this.netData.clientData.Ponder.v = newPonder;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region SMP

		[SyncVar(hook="onChangeSMP")]
		public System.Boolean SMP;

		public void onChangeSMP(System.Boolean newSMP)
		{
			this.SMP = newSMP;
			if (this.netData.clientData != null) {
				this.netData.clientData.SMP.v = newSMP;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region SMP_Threads

		[SyncVar(hook="onChangeSMP_Threads")]
		public System.Int32 SMP_Threads;

		public void onChangeSMP_Threads(System.Int32 newSMP_Threads)
		{
			this.SMP_Threads = newSMP_Threads;
			if (this.netData.clientData != null) {
				this.netData.clientData.SMP_Threads.v = newSMP_Threads;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region TT_Size

		[SyncVar(hook="onChangeTT_Size")]
		public System.Int32 TT_Size;

		public void onChangeTT_Size(System.Int32 newTT_Size)
		{
			this.TT_Size = newTT_Size;
			if (this.netData.clientData != null) {
				this.netData.clientData.TT_Size.v = newTT_Size;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region BB

		[SyncVar(hook="onChangeBB")]
		public System.Boolean BB;

		public void onChangeBB(System.Boolean newBB)
		{
			this.BB = newBB;
			if (this.netData.clientData != null) {
				this.netData.clientData.BB.v = newBB;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region BB_Size

		[SyncVar(hook="onChangeBB_Size")]
		public System.Int32 BB_Size;

		public void onChangeBB_Size(System.Int32 newBB_Size)
		{
			this.BB_Size = newBB_Size;
			if (this.netData.clientData != null) {
				this.netData.clientData.BB_Size.v = newBB_Size;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region pickBestMove

		[SyncVar(hook="onChangePickBestMove")]
		public System.Int32 pickBestMove;

		public void onChangePickBestMove(System.Int32 newPickBestMove)
		{
			this.pickBestMove = newPickBestMove;
			if (this.netData.clientData != null) {
				this.netData.clientData.pickBestMove.v = newPickBestMove;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<Var> netData = new NetData<Var>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeVariant(this.Variant);
				this.onChangeBook(this.Book);
				this.onChangeBook_Ply(this.Book_Ply);
				this.onChangeBook_Margin(this.Book_Margin);
				this.onChangePonder(this.Ponder);
				this.onChangeSMP(this.SMP);
				this.onChangeSMP_Threads(this.SMP_Threads);
				this.onChangeTT_Size(this.TT_Size);
				this.onChangeBB(this.BB);
				this.onChangeBB_Size(this.BB_Size);
				this.onChangePickBestMove(this.pickBestMove);
			} else {
				Debug.Log ("clientData null: " + this);
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.Variant);
				ret += GetDataSize (this.Book);
				ret += GetDataSize (this.Book_Ply);
				ret += GetDataSize (this.Book_Margin);
				ret += GetDataSize (this.Ponder);
				ret += GetDataSize (this.SMP);
				ret += GetDataSize (this.SMP_Threads);
				ret += GetDataSize (this.TT_Size);
				ret += GetDataSize (this.BB);
				ret += GetDataSize (this.BB_Size);
				ret += GetDataSize (this.pickBestMove);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is Var) {
				Var var = data as Var;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, var.makeSearchInforms ());
					this.Variant = var.Variant.v;
					this.Book = var.Book.v;
					this.Book_Ply = var.Book_Ply.v;
					this.Book_Margin = var.Book_Margin.v;
					this.Ponder = var.Ponder.v;
					this.SMP = var.SMP.v;
					this.SMP_Threads = var.SMP_Threads.v;
					this.TT_Size = var.TT_Size.v;
					this.BB = var.BB.v;
					this.BB_Size = var.BB_Size.v;
					this.pickBestMove = var.pickBestMove.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (var);
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
			if (data is Var) {
				// Var var = data as Var;
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
			if (wrapProperty.p is Var) {
				switch ((Var.Property)wrapProperty.n) {
				case Var.Property.Variant:
					this.Variant = (System.Int32)wrapProperty.getValue ();
					break;
				case Var.Property.Book:
					this.Book = (System.Boolean)wrapProperty.getValue ();
					break;
				case Var.Property.Book_Ply:
					this.Book_Ply = (System.Int32)wrapProperty.getValue ();
					break;
				case Var.Property.Book_Margin:
					this.Book_Margin = (System.Int32)wrapProperty.getValue ();
					break;
				case Var.Property.Ponder:
					this.Ponder = (System.Boolean)wrapProperty.getValue ();
					break;
				case Var.Property.SMP:
					this.SMP = (System.Boolean)wrapProperty.getValue ();
					break;
				case Var.Property.SMP_Threads:
					this.SMP_Threads = (System.Int32)wrapProperty.getValue ();
					break;
				case Var.Property.TT_Size:
					this.TT_Size = (System.Int32)wrapProperty.getValue ();
					break;
				case Var.Property.BB:
					this.BB = (System.Boolean)wrapProperty.getValue ();
					break;
				case Var.Property.BB_Size:
					this.BB_Size = (System.Int32)wrapProperty.getValue ();
					break;
				case Var.Property.pickBestMove:
					this.pickBestMove = (System.Int32)wrapProperty.getValue ();
					break;
				default:
					Debug.LogError ("Unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
		}

		#endregion

	}
}
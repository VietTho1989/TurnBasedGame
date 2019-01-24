using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class SolitaireMoveAnimationIdentity : DataIdentity
	{

		#region SyncVar

		#region From

		[SyncVar(hook="onChangeMoveFrom")]
		public System.Byte From;

		public void onChangeMoveFrom(System.Byte newFrom)
		{
			this.From = newFrom;
			if (this.netData.clientData != null) {
				this.netData.clientData.From.v = newFrom;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region To

		[SyncVar(hook="onChangeTo")]
		public System.Byte To;

		public void onChangeTo(System.Byte newTo)
		{
			this.To = newTo;
			if (this.netData.clientData != null) {
				this.netData.clientData.To.v = newTo;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region Count

		[SyncVar(hook="onChangeCount")]
		public System.Byte Count;

		public void onChangeCount(System.Byte newCount)
		{
			this.Count = newCount;
			if (this.netData.clientData != null) {
				this.netData.clientData.Count.v = newCount;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region Extra

		[SyncVar(hook="onChangeExtra")]
		public System.Byte Extra;

		public void onChangeExtra(System.Byte newExtra)
		{
			this.Extra = newExtra;
			if (this.netData.clientData != null) {
				this.netData.clientData.Extra.v = newExtra;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region drawCount

		[SyncVar(hook="onChangeDrawCount")]
		public System.Int32 drawCount;

		public void onChangeDrawCount(System.Int32 newDrawCount)
		{
			this.drawCount = newDrawCount;
			if (this.netData.clientData != null) {
				this.netData.clientData.drawCount.v = newDrawCount;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region duration

		[SyncVar(hook="onChangeDuration")]
		public System.Single duration;

		public void onChangeDuration(System.Single newDuration)
		{
			this.duration = newDuration;
			if (this.netData.clientData != null) {
				this.netData.clientData.duration.v = newDuration;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region drawAmount

		[SyncVar(hook="onChangeDrawAmount")]
		public System.Int32 drawAmount;

		public void onChangeDrawAmount(System.Int32 newDrawAmount)
		{
			this.drawAmount = newDrawAmount;
			if (this.netData.clientData != null) {
				this.netData.clientData.drawAmount.v = newDrawAmount;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region drawDuration

		[SyncVar(hook="onChangeDrawDuration")]
		public System.Single drawDuration;

		public void onChangeDrawDuration(System.Single newDrawDuration)
		{
			this.drawDuration = newDrawDuration;
			if (this.netData.clientData != null) {
				this.netData.clientData.drawDuration.v = newDrawDuration;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region moveDuration

		[SyncVar(hook="onChangeMoveDuration")]
		public System.Single moveDuration;

		public void onChangeMoveDuration(System.Single newMoveDuration)
		{
			this.moveDuration = newMoveDuration;
			if (this.netData.clientData != null) {
				this.netData.clientData.moveDuration.v = newMoveDuration;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region from

		[SyncVar(hook="onChangeFrom")]
		public UnityEngine.Vector2 from;

		public void onChangeFrom(UnityEngine.Vector2 newFrom)
		{
			this.from = newFrom;
			if (this.netData.clientData != null) {
				this.netData.clientData.from.v = newFrom;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region dest

		[SyncVar(hook="onChangeDest")]
		public UnityEngine.Vector2 dest;

		public void onChangeDest(UnityEngine.Vector2 newDest)
		{
			this.dest = newDest;
			if (this.netData.clientData != null) {
				this.netData.clientData.dest.v = newDest;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region isFlip

		[SyncVar(hook="onChangeIsFlip")]
		public System.Boolean isFlip;

		public void onChangeIsFlip(System.Boolean newIsFlip)
		{
			this.isFlip = newIsFlip;
			if (this.netData.clientData != null) {
				this.netData.clientData.isFlip.v = newIsFlip;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region fromRank

		[SyncVar(hook="onChangeFromRank")]
		public System.Byte fromRank;

		public void onChangeFromRank(System.Byte newFromRank)
		{
			this.fromRank = newFromRank;
			if (this.netData.clientData != null) {
				this.netData.clientData.fromRank.v = newFromRank;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region fromSuit

		[SyncVar(hook="onChangeFromSuit")]
		public System.Byte fromSuit;

		public void onChangeFromSuit(System.Byte newFromSuit)
		{
			this.fromSuit = newFromSuit;
			if (this.netData.clientData != null) {
				this.netData.clientData.fromSuit.v = newFromSuit;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<SolitaireMoveAnimation> netData = new NetData<SolitaireMoveAnimation>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeMoveFrom(this.From);
				this.onChangeTo(this.To);
				this.onChangeCount(this.Count);
				this.onChangeExtra(this.Extra);
				this.onChangeDrawCount(this.drawCount);
				this.onChangeDuration(this.duration);
				this.onChangeDrawAmount(this.drawAmount);
				this.onChangeDrawDuration(this.drawDuration);
				this.onChangeMoveDuration(this.moveDuration);
				this.onChangeFrom(this.from);
				this.onChangeDest(this.dest);
				this.onChangeIsFlip(this.isFlip);
				this.onChangeFromRank(this.fromRank);
				this.onChangeFromSuit(this.fromSuit);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.From);
				ret += GetDataSize (this.To);
				ret += GetDataSize (this.Count);
				ret += GetDataSize (this.Extra);
				ret += GetDataSize (this.drawCount);
				ret += GetDataSize (this.duration);
				ret += GetDataSize (this.drawAmount);
				ret += GetDataSize (this.drawDuration);
				ret += GetDataSize (this.moveDuration);
				ret += GetDataSize (this.from);
				ret += GetDataSize (this.dest);
				ret += GetDataSize (this.isFlip);
				ret += GetDataSize (this.fromRank);
				ret += GetDataSize (this.fromSuit);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is SolitaireMoveAnimation) {
				SolitaireMoveAnimation solitaireMoveAnimation = data as SolitaireMoveAnimation;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, solitaireMoveAnimation.makeSearchInforms ());
					this.From = solitaireMoveAnimation.From.v;
					this.To = solitaireMoveAnimation.To.v;
					this.Count = solitaireMoveAnimation.Count.v;
					this.Extra = solitaireMoveAnimation.Extra.v;
					this.drawCount = solitaireMoveAnimation.drawCount.v;
					this.duration = solitaireMoveAnimation.duration.v;
					this.drawAmount = solitaireMoveAnimation.drawAmount.v;
					this.drawDuration = solitaireMoveAnimation.drawDuration.v;
					this.moveDuration = solitaireMoveAnimation.moveDuration.v;
					this.from = solitaireMoveAnimation.from.v;
					this.dest = solitaireMoveAnimation.dest.v;
					this.isFlip = solitaireMoveAnimation.isFlip.v;
					this.fromRank = solitaireMoveAnimation.fromRank.v;
					this.fromSuit = solitaireMoveAnimation.fromSuit.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (solitaireMoveAnimation);
					} else {
						Debug.LogError ("observer null: " + this);
					}
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is SolitaireMoveAnimation) {
				// SolitaireMoveAnimation solitaireMoveAnimation = data as SolitaireMoveAnimation;
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.setCheckChangeData (null);
					} else {
						Debug.LogError ("observer null: " + this);
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
			if (wrapProperty.p is SolitaireMoveAnimation) {
				switch ((SolitaireMoveAnimation.Property)wrapProperty.n) {
				case SolitaireMoveAnimation.Property.From:
					this.From = (System.Byte)wrapProperty.getValue ();
					break;
				case SolitaireMoveAnimation.Property.To:
					this.To = (System.Byte)wrapProperty.getValue ();
					break;
				case SolitaireMoveAnimation.Property.Count:
					this.Count = (System.Byte)wrapProperty.getValue ();
					break;
				case SolitaireMoveAnimation.Property.Extra:
					this.Extra = (System.Byte)wrapProperty.getValue ();
					break;
				case SolitaireMoveAnimation.Property.piles:
					break;
				case SolitaireMoveAnimation.Property.drawCount:
					this.drawCount = (System.Int32)wrapProperty.getValue ();
					break;
				case SolitaireMoveAnimation.Property.duration:
					this.duration = (System.Single)wrapProperty.getValue ();
					break;
				case SolitaireMoveAnimation.Property.drawAmount:
					this.drawAmount = (System.Int32)wrapProperty.getValue ();
					break;
				case SolitaireMoveAnimation.Property.drawDuration:
					this.drawDuration = (System.Single)wrapProperty.getValue ();
					break;
				case SolitaireMoveAnimation.Property.moveDuration:
					this.moveDuration = (System.Single)wrapProperty.getValue ();
					break;
				case SolitaireMoveAnimation.Property.from:
					this.from = (UnityEngine.Vector2)wrapProperty.getValue ();
					break;
				case SolitaireMoveAnimation.Property.dest:
					this.dest = (UnityEngine.Vector2)wrapProperty.getValue ();
					break;
				case SolitaireMoveAnimation.Property.isFlip:
					this.isFlip = (System.Boolean)wrapProperty.getValue ();
					break;
				case SolitaireMoveAnimation.Property.fromRank:
					this.fromRank = (System.Byte)wrapProperty.getValue ();
					break;
				case SolitaireMoveAnimation.Property.fromSuit:
					this.fromSuit = (System.Byte)wrapProperty.getValue ();
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
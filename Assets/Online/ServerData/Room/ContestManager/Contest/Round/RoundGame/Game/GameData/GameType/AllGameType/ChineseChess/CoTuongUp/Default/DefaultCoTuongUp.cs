using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CoTuongUp
{
	public class DefaultCoTuongUp : DefaultGameType
	{

		#region allowViewCapture

		public VP<bool> allowViewCapture;

		public void requestChangeAllowViewCapture(uint userId, bool newAllowViewCapture){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeAllowViewCapture (userId, newAllowViewCapture);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is DefaultCoTuongUpIdentity) {
							DefaultCoTuongUpIdentity defaultCoTuongUpIdentity = dataIdentity as DefaultCoTuongUpIdentity;
							defaultCoTuongUpIdentity.requestChangeAllowViewCapture (userId, newAllowViewCapture);
						} else {
							Debug.LogError ("Why isn't correct identity");
						}
					} else {
						Debug.LogError ("cannot find dataIdentity");
					}
				}
			} else {
				Debug.LogError ("You cannot request: " + this);
			}
		}

		public void changeAllowViewCapture(uint userId, bool newAllowViewCapture){
			if (GameManager.Match.ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.allowViewCapture.v = newAllowViewCapture;
			} else {
				Debug.LogError ("cannot change config: " + this);
			}
		}

		#endregion

		#region allow watcher view hidden

		public VP<bool> allowWatcherViewHidden;

		public void requestChangeAllowWatcherViewHidden(uint userId, bool newAllowWatcherViewHidden){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeAllowWatcherViewHidden (userId, newAllowWatcherViewHidden);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is DefaultCoTuongUpIdentity) {
							DefaultCoTuongUpIdentity defaultCoTuongUpIdentity = dataIdentity as DefaultCoTuongUpIdentity;
							defaultCoTuongUpIdentity.requestChangeAllowWatcherViewHidden (userId, newAllowWatcherViewHidden);
						} else {
							Debug.LogError ("Why isn't correct identity");
						}
					} else {
						Debug.LogError ("cannot find dataIdentity");
					}
				}
			} else {
				Debug.LogError ("You cannot request: " + this);
			}
		}

		public void changeAllowWatcherViewHidden(uint userId, bool newAllowWatcherViewHidden){
			if (GameManager.Match.ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.allowWatcherViewHidden.v = newAllowWatcherViewHidden;
			} else {
				Debug.LogError ("cannot change config: " + this);
			}
		}

		#endregion

		#region allowOnlyFlip

		public VP<bool> allowOnlyFlip;

		public void requestChangeAllowOnlyFlip(uint userId, bool newAllowOnlyFlip){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeAllowOnlyFlip (userId, newAllowOnlyFlip);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is DefaultCoTuongUpIdentity) {
							DefaultCoTuongUpIdentity defaultCoTuongUpIdentity = dataIdentity as DefaultCoTuongUpIdentity;
							defaultCoTuongUpIdentity.requestChangeAllowOnlyFlip (userId, newAllowOnlyFlip);
						} else {
							Debug.LogError ("Why isn't correct identity");
						}
					} else {
						Debug.LogError ("cannot find dataIdentity");
					}
				}
			} else {
				Debug.LogError ("You cannot request: " + this);
			}
		}

		public void changeAllowOnlyFlip(uint userId, bool newAllowOnlyFlip){
			if (GameManager.Match.ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.allowOnlyFlip.v = newAllowOnlyFlip;
			} else {
				Debug.LogError ("cannot change config: " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			allowViewCapture,
			allowWatcherViewHidden,
			allowOnlyFlip
		}

		public DefaultCoTuongUp () : base ()
		{
			this.allowViewCapture = new VP<bool> (this, (byte)Property.allowViewCapture, true);
			this.allowWatcherViewHidden = new VP<bool> (this, (byte)Property.allowWatcherViewHidden, false);
			this.allowOnlyFlip = new VP<bool> (this, (byte)Property.allowOnlyFlip, true);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.CO_TUONG_UP;
		}

		public override GameType makeDefaultGameType ()
		{
			CoTuongUp coTuongUp = new CoTuongUp ();
			{
				// property
				{
					coTuongUp.allowViewCapture.v = this.allowViewCapture.v;
					coTuongUp.allowWatcherViewHidden.v = this.allowWatcherViewHidden.v;
					coTuongUp.allowOnlyFlip.v = this.allowOnlyFlip.v;
				}
				coTuongUp.turn.v = 0;
				coTuongUp.side.v = Common.Side.Red;
				// Nodes
				{
					coTuongUp.nodes.clear ();
					Node node = new Node ();
					{
						node.uid = coTuongUp.nodes.makeId ();
						// ply
						node.ply.v = 0;
						// pieces
						{
							// RedList
							List<byte> redList = new byte[] {
								Common.HR, Common.HN, Common.HB, Common.HA, Common.HA, Common.HB, Common.HN, Common.HR,
								Common.HC, Common.HC,
								Common.HP, Common.HP, Common.HP, Common.HP, Common.HP
							}.ToList ();
							// BlackList
							List<byte> blackList = new byte[] {
								Common.hr, Common.hn, Common.hb, Common.ha, Common.ha, Common.hb, Common.hn, Common.hr,
								Common.hc, Common.hc,
								Common.hp, Common.hp, Common.hp, Common.hp, Common.hp
							}.ToList ();
							for (int i = 0; i < Common.DefaultBoard.Length; i++) {
								byte piece = Common.DefaultBoard [i];
								if (piece == Common.x || piece == Common.k || piece == Common.K) {
									node.pieces.add (piece);
								} else {
									switch (Common.getPieceSide(piece)) {
									case Common.Side.Red:
										{
											// add random from red list
											if (redList.Count > 0) {
												int index = UnityEngine.Random.Range (0, redList.Count);
												if (index >= 0 && index < redList.Count) {
													node.pieces.add (redList [index]);
													redList.RemoveAt (index);
												} else {
													Debug.LogError ("Why index wrong: " + this);
													node.pieces.add (redList [0]);
												}
											} else {
												Debug.LogError ("Why don't have any red piece");
											}
										}
										break;
									case Common.Side.Black:
										{
											// add random from black list
											if (blackList.Count > 0) {
												int index = UnityEngine.Random.Range (0, blackList.Count);
												if (index >= 0 && index < blackList.Count) {
													node.pieces.add (blackList [index]);
													blackList.RemoveAt (index);
												} else {
													Debug.LogError ("Why index wrong: " + this);
													node.pieces.add (blackList [0]);
												}
											} else {
												Debug.LogError ("Why don't have any black piece");
											}
										}
										break;
									default:
										Debug.LogError ("unknown chinese chess piece type: " + Common.getPieceSide (piece));
										node.pieces.add (piece);
										break;
									}
								}
							}
						}
						// captures
					}
					coTuongUp.nodes.add (node);
				}
			}
			return coTuongUp;
		}

	}
}
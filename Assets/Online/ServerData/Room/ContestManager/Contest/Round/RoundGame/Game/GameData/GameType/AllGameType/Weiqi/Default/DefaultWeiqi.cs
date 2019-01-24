using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
	public class DefaultWeiqi : DefaultGameType
	{

		#region Size

		/** 5->19*/
		public VP<int> size;// = 19;

		public void requestChangeSize(uint userId, int newSize){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeSize (userId, newSize);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is DefaultWeiqiIdentity) {
							DefaultWeiqiIdentity defaultWeiqiIdentity = dataIdentity as DefaultWeiqiIdentity;
							defaultWeiqiIdentity.requestChangeSize (userId, newSize);
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

		public void changeSize(uint userId, int newSize){
			if (GameManager.Match.ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.size.v = newSize;
			} else {
				Debug.LogError ("cannot change config: " + this);
			}
		}

		#endregion

		#region Komi

		public VP<float> komi;// = 5.5f;

		public void requestChangeKomi(uint userId, float newKomi){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeKomi (userId, newKomi);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is DefaultWeiqiIdentity) {
							DefaultWeiqiIdentity defaultWeiqiIdentity = dataIdentity as DefaultWeiqiIdentity;
							defaultWeiqiIdentity.requestChangeKomi (userId, newKomi);
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

		public void changeKomi(uint userId, float newKomi){
			if (GameManager.Match.ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.komi.v = newKomi;
			} else {
				Debug.LogError ("cannot change config: " + this);
			}
		}

		#endregion

		#region Rule

		public VP<int> rule;// (int)Common.go_ruleset.RULES_CHINESE;

		public void requestChangeRule(uint userId, int newRule){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeRule (userId, newRule);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is DefaultWeiqiIdentity) {
							DefaultWeiqiIdentity defaultWeiqiIdentity = dataIdentity as DefaultWeiqiIdentity;
							defaultWeiqiIdentity.requestChangeRule (userId, newRule);
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

		public void changeRule(uint userId, int newRule){
			if (GameManager.Match.ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.rule.v = newRule;
			} else {
				Debug.LogError ("cannot change config: " + this);
			}
		}

		#endregion

		public VP<int> handicap;// = 0;

		public void requestChangeHandicap(uint userId, int newHandicap){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeHandicap (userId, newHandicap);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is DefaultWeiqiIdentity) {
							DefaultWeiqiIdentity defaultWeiqiIdentity = dataIdentity as DefaultWeiqiIdentity;
							defaultWeiqiIdentity.requestChangeHandicap (userId, newHandicap);
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

		public void changeHandicap(uint userId, int newHandicap){
			if (GameManager.Match.ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.handicap.v = newHandicap;
			} else {
				Debug.LogError ("cannot change config: " + this);
			}
		}

		#region Constructor

		public enum Property
		{
			size,
			komi,
			rule,
			handicap
		}

		public DefaultWeiqi() : base()
		{
			this.size = new VP<int> (this, (byte)Property.size, 19);
			this.komi = new VP<float> (this, (byte)Property.komi, 5.5f);
			this.rule = new VP<int> (this, (byte)Property.rule, (int)Common.go_ruleset.RULES_CHINESE);
			this.handicap = new VP<int> (this, (byte)Property.handicap, 0);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.Weiqi;
		}

		public override GameType makeDefaultGameType ()
		{
			// init
			int size = this.size.v;
			float komi = this.komi.v;
			int rule = this.rule.v;
			int handicap = this.handicap.v;
			Weiqi startWeiqi = Core.unityMakeDefaultPosition(size, komi, rule, handicap);
			return startWeiqi;
		}

	}
}
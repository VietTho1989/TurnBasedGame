using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
	public class DefaultMineSweeper : DefaultGameType
	{

		#region N

		public VP<int> N;

		public void requestChangeN(uint userId, int newN){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeN (userId, newN);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is DefaultMineSweeperIdentity) {
							DefaultMineSweeperIdentity defaultMineSweeperIdentity = dataIdentity as DefaultMineSweeperIdentity;
							defaultMineSweeperIdentity.requestChangeN (userId, newN);
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

		public void changeN(uint userId, int newN){
			if (GameManager.Match.ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.N.v = newN;
			} else {
				Debug.LogError ("cannot change config: " + this);
			}
		}

		#endregion

		#region M

		public VP<int> M;

		public void requestChangeM(uint userId, int newM){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeM (userId, newM);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is DefaultMineSweeperIdentity) {
							DefaultMineSweeperIdentity defaultMineSweeperIdentity = dataIdentity as DefaultMineSweeperIdentity;
							defaultMineSweeperIdentity.requestChangeM (userId, newM);
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

		public void changeM(uint userId, int newM){
			if (GameManager.Match.ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.M.v = newM;
			} else {
				Debug.LogError ("cannot change config: " + this);
			}
		}

		#endregion

		#region minK

		public VP<float> minK;

		public void requestChangeMinK(uint userId, float newMinK){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeMinK (userId, newMinK);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is DefaultMineSweeperIdentity) {
							DefaultMineSweeperIdentity defaultMineSweeperIdentity = dataIdentity as DefaultMineSweeperIdentity;
							defaultMineSweeperIdentity.requestChangeMinK (userId, newMinK);
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

		public void changeMinK(uint userId, float newMinK){
			if (GameManager.Match.ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.minK.v = newMinK;
			} else {
				Debug.LogError ("cannot change config: " + this);
			}
		}

		#endregion

		#region maxK

		public VP<float> maxK;

		public void requestChangeMaxK(uint userId, float newMaxK){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeMaxK (userId, newMaxK);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is DefaultMineSweeperIdentity) {
							DefaultMineSweeperIdentity defaultMineSweeperIdentity = dataIdentity as DefaultMineSweeperIdentity;
							defaultMineSweeperIdentity.requestChangeMaxK (userId, newMaxK);
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

		public void changeMaxK(uint userId, float newMaxK){
			if (GameManager.Match.ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.maxK.v = newMaxK;
			} else {
				Debug.LogError ("cannot change config: " + this);
			}
		}

		#endregion

		#region allowWatchBomb

		public VP<bool> allowWatchBomb;

		public void requestChangeAllowWatchBomb(uint userId, bool newAllowWatchBomb){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeAllowWatchBomb (userId, newAllowWatchBomb);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is DefaultMineSweeperIdentity) {
							DefaultMineSweeperIdentity defaultMineSweeperIdentity = dataIdentity as DefaultMineSweeperIdentity;
							defaultMineSweeperIdentity.requestChangeAllowWatchBomb (userId, newAllowWatchBomb);
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

		public void changeAllowWatchBomb(uint userId, bool newAllowWatchBomb){
			if (GameManager.Match.ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.allowWatchBomb.v = newAllowWatchBomb;
			} else {
				Debug.LogError ("cannot change config: " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			N,
			M,
			minK,
			maxK,
			allowWatchBomb
		}

		public DefaultMineSweeper() : base()
		{
			this.N = new VP<int> (this, (byte)Property.N, 10);
			this.M = new VP<int> (this, (byte)Property.M, 10);
			this.minK = new VP<float> (this, (byte)Property.minK, 0.1f);
			this.maxK = new VP<float> (this, (byte)Property.maxK, 0.2f);
			this.allowWatchBomb = new VP<bool> (this, (byte)Property.allowWatchBomb, true);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.MineSweeper;
		}

		public override GameType makeDefaultGameType ()
		{
			int N = Mathf.Clamp (this.N.v, MineSweeper.MIN_DIMENSION_SIZE, MineSweeper.MAX_DIMENSION_SIZE);
			int M = Mathf.Clamp (this.M.v, MineSweeper.MIN_DIMENSION_SIZE, MineSweeper.MAX_DIMENSION_SIZE);
			int K = (N*M) / 10;
			{
				float percent = 0.1f;
				{
					if (0 < this.minK.v && this.minK.v <= this.maxK.v && this.maxK.v < 1) {
						if (this.minK.v == this.maxK.v) {
							percent = this.minK.v;
						} else {
							percent = Random.Range (this.minK.v, this.maxK.v);
						}
					}
				}
				K = (int)(N * M * percent);
			}
			MineSweeper mineSweeper = Core.unityMakeDefaultPosition (N, M, K);
			{
				mineSweeper.allowWatchBoomb.v = this.allowWatchBomb.v;
			}
			return mineSweeper;
		}

	}
}
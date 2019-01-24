using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
	public class MineSweeperAI : Computer.AI
	{

		#region firstMoveType

		public enum FirstMoveType
		{
			Random,
			Center,
			Corner
		}

		public VP<FirstMoveType> firstMoveType;

		public void requestChangeFirstMoveType(uint userId, int newFirstMoveType){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeFirstMoveType (userId, newFirstMoveType);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is MineSweeperAIIdentity) {
							MineSweeperAIIdentity mineSweeperAIIdentity = dataIdentity as MineSweeperAIIdentity;
							mineSweeperAIIdentity.requestChangeFirstMoveType (userId, newFirstMoveType);
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

		public void changeFirstMoveType(uint userId, int newFirstMoveType){
			if (isCanRequest (userId)) {
				this.firstMoveType.v = (FirstMoveType)newFirstMoveType;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			firstMoveType
		}

		public MineSweeperAI() : base()
		{
			this.firstMoveType = new VP<FirstMoveType> (this, (byte)Property.firstMoveType, FirstMoveType.Random);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.MineSweeper;
		}

	}
}
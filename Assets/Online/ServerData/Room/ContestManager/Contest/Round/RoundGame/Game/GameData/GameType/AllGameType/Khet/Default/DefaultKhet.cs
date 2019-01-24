using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
	public class DefaultKhet : DefaultGameType
	{

		#region startPos

		public enum StartPos
		{
			Standard,
			Dynasty,
			Imhotep
		}

		public VP<StartPos> startPos;

		public void requestChangeStartPos(uint userId, StartPos newStartPos){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeStartPos (userId, newStartPos);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is DefaultKhetIdentity) {
							DefaultKhetIdentity defaultKhetIdentity = dataIdentity as DefaultKhetIdentity;
							defaultKhetIdentity.requestChangeStartPos (userId, newStartPos);
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

		public void changeStartPos(uint userId, StartPos newStartPos){
			if (GameManager.Match.ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.startPos.v = newStartPos;
			} else {
				Debug.LogError ("cannot change config: " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			startPos
		}

		public DefaultKhet() : base()
		{
			this.startPos = new VP<StartPos> (this, (byte)Property.startPos, StartPos.Standard);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.Khet;
		}

		public override GameType makeDefaultGameType ()
		{
			string strFen = Khet.Standard;
			{
				switch (this.startPos.v) {
				case StartPos.Standard:
					strFen = Khet.Standard;
					break;
				case StartPos.Dynasty:
					strFen = Khet.Dynasty;
					break;
				case StartPos.Imhotep:
					strFen = Khet.Imhotep;
					break;
				default:
					Debug.LogError ("unknown startPos: " + this.startPos.v);
					break;
				}
			}
			Khet newKhet = Core.unityMakePositionByFen (strFen);
			return newKhet;
		}

	}
}
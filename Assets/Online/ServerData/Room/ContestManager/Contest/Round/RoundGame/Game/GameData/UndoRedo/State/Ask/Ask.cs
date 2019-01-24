using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UndoRedo
{
	public class Ask : UndoRedoRequest.State
	{

		public enum Answer
		{
			None,
			Accept,
			Cancel
		}

		public VP<RequestInform> requestInform;

		public LP<Human> whoCanAsks;

		public LP<uint> accepts;

		public LP<uint> cancels;

		#region Constructor

		public enum Property
		{
			requestInform,
			whoCanAsks,
			accepts,
			cancels
		}

		public Ask() : base()
		{
			this.requestInform = new VP<RequestInform> (this, (byte)Property.requestInform, new RequestLastYourTurn ());
			this.whoCanAsks = new LP<Human> (this, (byte)Property.whoCanAsks);
			this.accepts = new LP<uint> (this, (byte)Property.accepts);
			this.cancels = new LP<uint> (this, (byte)Property.cancels);
		}

		#endregion

		public override Type getType ()
		{
			return Type.Ask;
		}

		#region request answer

		public void requestAnswer(uint userId, Answer answer) {
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.answer (userId, answer);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is AskIdentity) {
							AskIdentity askIdentity = dataIdentity as AskIdentity;
							askIdentity.requestAnswer (userId, answer);
						} else {
							Debug.LogError ("Why isn't correct identity");
						}
					} else {
						Debug.LogError ("cannot find dataIdentity");
					}
				}
			} else {
				Debug.LogError ("You cannot request");
			}
		}

		public void answer(uint userId, Answer answer)
		{
			if (UndoRedoRequest.getWhoCanAnswer (this).Contains (userId)) {
				switch (answer) {
				case Answer.None:
					break;
				case Answer.Accept:
					{
						if (!this.accepts.vs.Contains (userId)) {
							this.accepts.add (userId);
						} else {
							Debug.LogError ("already accept: " + userId);
						}
					}
					break;
				case Answer.Cancel:
					{
						if (!this.cancels.vs.Contains (userId)) {
							this.cancels.add (userId);
						} else {
							Debug.LogError ("already cancel: " + userId);
						}
					}
					break;
				default:
					Debug.LogError ("unknown answer: " + answer + "; " + this);
					break;
				}
			} else {
				Debug.LogError ("cannot request: " + userId);
			}
		}

		#endregion

	}
}
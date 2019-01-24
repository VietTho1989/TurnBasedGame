using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaitInputAction : GameAction
{

	public VP<float> serverTime;

	public VP<float> clientTime;

	#region Sub

	public abstract class Sub : Data
	{

		public enum Type
		{
			Human,
			AI
		}

		public abstract Type getType ();

	}

	public VP<Sub> sub;

	#endregion

	public LP<InputData> inputs;

	public VP<ClientInput> clientInput;

	#region Constructor

	public enum Property
	{
		serverTime,
		clientTime,
		sub,
		inputs,
		clientInput
	}

	public WaitInputAction() : base()
	{
		this.serverTime = new VP<float> (this, (byte)Property.serverTime, 0);
		this.clientTime = new VP<float> (this, (byte)Property.clientTime, 0);
		this.sub = new VP<Sub> (this, (byte)Property.sub, null);
		this.inputs = new LP<InputData> (this, (byte)Property.inputs);
		{
			this.clientInput = new VP<ClientInput> (this, (byte)Property.clientInput, new ClientInput ());
			this.clientInput.ni = 0;
		}
	}

	#endregion

	public override Type getType ()
	{
		return Type.WaitInput;
	}

	#region sendInput

	public bool isCanSendInput(uint userId){
		bool ret = false;
		{
			// Check sub
			if (this.sub.v != null) {
				// Human Input
				if (this.sub.v is WaitHumanInput) {
					WaitHumanInput waitHumanInput = this.sub.v as WaitHumanInput;
					if (waitHumanInput.userId.v == userId) {
						ret = true;
					}
				}
				// AI Input
				else if (this.sub.v is WaitAIInput) {
					WaitAIInput waitAIInput = this.sub.v as WaitAIInput;
					if (waitAIInput.userThink.v == userId) {
						ret = true;
					}
				}
			} else {
				Debug.LogError ("sub null: " + this);
			}
		}
		return ret;
	}

	public void requestSendInput(uint userId, GameMove gameMove, float clientTime)
	{
		// Debug.LogError ("requestSendInput: " + gameMove);
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.sendInput (userId, gameMove, clientTime);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is WaitInputActionIdentity) {
						WaitInputActionIdentity waitInputActionIdentity = dataIdentity as WaitInputActionIdentity;
						waitInputActionIdentity.requestSendInput (userId, gameMove, clientTime);
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

	public void sendInput(uint userId, GameMove gameMove, float clientTime){
		if (this.isCanSendInput (userId)) {
			// Add input
			InputData inputData = new InputData ();
			{
				inputData.uid = this.inputs.makeId ();
				inputData.gameMove.v = gameMove;
				inputData.userSend.v = userId;
				inputData.clientTime.v = clientTime;
			}
			this.inputs.add (inputData);
		} else {
			Debug.LogError ("Cannot send input: " + userId + ", " + gameMove);
		}
	}

	#endregion

}
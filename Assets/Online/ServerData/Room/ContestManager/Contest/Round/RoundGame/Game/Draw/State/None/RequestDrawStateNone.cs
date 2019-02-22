using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RequestDrawStateNone : RequestDraw.State
{

	#region Constructor

	public enum Property
	{

	}

	public RequestDrawStateNone() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.None;
	}

	#region Request Draw

	public bool isCanRequestDraw(uint userId){
		if (Game.IsPlaying (this, false)) {
			RequestDraw requestDraw = this.findDataInParent<RequestDraw> ();
			if (requestDraw != null) {
				HashSet<uint> whoCanAnswer = requestDraw.getWhoCanAsk ();
				if (whoCanAnswer.Contains (userId)) {
					return true;
				}
			} else {
				Debug.LogError ("requestDraw null");
			}
		} else {
			// Debug.LogError ("game isn't playing: " + this);
		}
		// return
		return false;
	}

	public void requestMakeRequestDraw(uint userId){
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.makeRequestDraw (userId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is RequestDrawStateNoneIdentity) {
						RequestDrawStateNoneIdentity requestDrawStateNoneIdentity = dataIdentity as RequestDrawStateNoneIdentity;
						requestDrawStateNoneIdentity.requestMakeRequestDraw (userId);
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

	public void makeRequestDraw(uint userId){
		if (isCanRequestDraw (userId)) {
			RequestDraw requestDraw = this.findDataInParent<RequestDraw> ();
			if (requestDraw != null) {
				RequestDrawStateAsk askState = requestDraw.state.newOrOld<RequestDrawStateAsk> ();
				{
					// accepts
					{
						askState.accepts.clear ();
						askState.accepts.add (userId);
					}
					// refuse
					askState.refuses.clear();
				}
				requestDraw.state.v = askState;
			} else {
				Debug.LogError ("requestDraw null");
			}
		} else {
			Debug.LogError ("Cannot request draw: " + userId);
		}
	}

	#endregion

}
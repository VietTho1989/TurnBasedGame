using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientInput : Data
{

	#region Sub

	public abstract class Sub : Data
	{

		public enum Type
		{
			None,
			Send
		}

		public abstract Type getType();

	}

	public VP<Sub> sub;

	#endregion

	#region Constructor

	public enum Property
	{
		sub
	}

	public ClientInput() : base()
	{
		this.sub = new VP<Sub> (this, (byte)Property.sub, new ClientInputNone ());
	}

	#endregion

	public void makeSend(GameMove gameMove)
	{
		bool isMakeNew = false;
		// Find ClientInputSend
		ClientInputSend send = null;
		{
			// find old
			if (this.sub.v is ClientInputSend) {
				send = this.sub.v as ClientInputSend;
			}
			// make new
			if (send == null) {
				send = new ClientInputSend ();
				{
					send.uid = this.sub.makeId ();
				}
				isMakeNew = true;
			}
		}
		// Update Property
		{
			// state
			send.state.v = ClientInputSend.State.Send;
			// gameMove
			{
				GameMove newGameMove = (GameMove)DataUtils.cloneData (gameMove);
				{
					newGameMove.uid = send.gameMove.makeId ();
				}
				send.gameMove.v = newGameMove;
			}
			// clientTimeSend
			{
				float clientTime = 0;
				{
					WaitInputAction waitInputAction = this.findDataInParent<WaitInputAction> ();
					if (waitInputAction != null) {
						clientTime = waitInputAction.clientTime.v;
					} else {
						Debug.LogError ("waitInputAction null: " + this);
					}
				}
				send.clientTimeSend.v = clientTime;
			}
		}
		// add
		if (isMakeNew) {
			this.sub.v = send;
		}
	}

	public void cancelSend()
	{
		bool isMakeNew = false;
		// Find none
		ClientInputNone none = null;
		{
			// find old
			if (this.sub.v is ClientInputNone) {
				none = this.sub.v as ClientInputNone;
			}
			// make new
			if (none == null) {
				none = new ClientInputNone ();
				{
					none.uid = this.sub.makeId ();
				}
				isMakeNew = true;
			}
		}
		// Update Property
		{
			
		}
		// set
		if (isMakeNew) {
			this.sub.v = none;
		}
	}

}
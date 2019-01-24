using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TypingUpdate : UpdateBehavior<Typing>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {

			} else {
				Debug.LogError ("data null: " + this);
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is Typing) {
			Typing typing = data as Typing;
			// Child
			{
				typing.typingPlayers.allAddCallBack (this);
			}
			return;
		}
		if (data is TypingPlayer) {
			TypingPlayer typingPlayer = data as TypingPlayer;
			UpdateUtils.makeUpdate<TypingPlayerUpdate, TypingPlayer> (typingPlayer, this.transform);
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is Typing) {
			Typing typing = data as Typing;
			// Child
			{
				typing.typingPlayers.allRemoveCallBack (this);
			}
			// set data null
			this.setDataNull (typing);
			return;
		}
		if (data is TypingPlayer) {
			TypingPlayer typingPlayer = data as TypingPlayer;
			typingPlayer.removeCallBackAndDestroy (typeof(TypingPlayerUpdate));
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is Typing) {
			switch ((Typing.Property)wrapProperty.n) {
			case Typing.Property.isEnable:
				break;
			case Typing.Property.stopDuration:
				break;
			case Typing.Property.nextReceiveTime:
				break;
			case Typing.Property.typingPlayers:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion
}
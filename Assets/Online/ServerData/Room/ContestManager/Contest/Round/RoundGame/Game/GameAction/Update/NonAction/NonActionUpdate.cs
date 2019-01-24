using UnityEngine;
using System.Collections;

public class NonActionUpdate : GameActionsUpdate.Sub<NonAction>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null && this.data.getDataParent()!=null) {
				// Co the chon team?
				{

				}
				// Chuyen sang startTurnAction
				{
					Game game = this.data.findDataInParent<Game> ();
					if (game != null) {
						// StartTurn
						StartTurnAction startTurnAction = game.gameAction.newOrOld<StartTurnAction>();
						{

						}
						game.gameAction.v = startTurnAction;
					} else {
						Debug.LogError ("game null: " + this);
					}
				}
			} else {
				Debug.LogError ("null");
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
		if (data is NonAction) {
			// NonAction nonAction = data as NonAction;
			dirty = true;
			return;
		}
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is NonAction) {
			NonAction nonAction = data as NonAction;
			// set data null
			this.setDataNull (nonAction);
			return;
		}
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, System.Collections.Generic.List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is NonAction) {
			switch ((NonAction.Property)wrapProperty.n) {
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
	}

	#endregion

}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerStateSurrenderUpdate : UpdateBehavior<GamePlayerStateSurrender>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				
			} else {
				Debug.LogError ("data null");
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
		if (data is GamePlayerStateSurrender) {
			GamePlayerStateSurrender gamePlayerStateSurrender = data as GamePlayerStateSurrender;
			// Child
			{
				gamePlayerStateSurrender.state.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is GamePlayerStateSurrender.State) {
			GamePlayerStateSurrender.State state = data as GamePlayerStateSurrender.State;
			// Update
			{
				switch (state.getType ()) {
				case GamePlayerStateSurrender.State.Type.None:
					{
						GamePlayerStateSurrenderNone none = state as GamePlayerStateSurrenderNone;
						UpdateUtils.makeUpdate<GamePlayerStateSurrenderNoneUpdate, GamePlayerStateSurrenderNone> (none, this.transform);
					}
					break;
				case GamePlayerStateSurrender.State.Type.Ask:
					{
						GamePlayerStateSurrenderAsk ask = state as GamePlayerStateSurrenderAsk;
						UpdateUtils.makeUpdate<GamePlayerStateSurrenderAskUpdate, GamePlayerStateSurrenderAsk> (ask, this.transform);
					}
					break;
				default:
					Debug.LogError ("unknown type: " + state.getType () + "; " + this);
					break;
				}
			}
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is GamePlayerStateSurrender) {
			GamePlayerStateSurrender gamePlayerStateSurrender = data as GamePlayerStateSurrender;
			// Child
			{
				gamePlayerStateSurrender.state.allRemoveCallBack (this);
			}
			this.setDataNull (gamePlayerStateSurrender);
			return;
		}
		// Child
		if (data is GamePlayerStateSurrender.State) {
			GamePlayerStateSurrender.State state = data as GamePlayerStateSurrender.State;
			// Update
			{
				switch (state.getType ()) {
				case GamePlayerStateSurrender.State.Type.None:
					{
						GamePlayerStateSurrenderNone none = state as GamePlayerStateSurrenderNone;
						none.removeCallBackAndDestroy (typeof(GamePlayerStateSurrenderNoneUpdate));
					}
					break;
				case GamePlayerStateSurrender.State.Type.Ask:
					{
						GamePlayerStateSurrenderAsk ask = state as GamePlayerStateSurrenderAsk;
						ask.removeCallBackAndDestroy (typeof(GamePlayerStateSurrenderAskUpdate));
					}
					break;
				default:
					Debug.LogError ("unknown type: " + state.getType () + "; " + this);
					break;
				}
			}
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is GamePlayerStateSurrender) {
			switch ((GamePlayerStateSurrender.Property)wrapProperty.n) {
			case GamePlayerStateSurrender.Property.state:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		if (wrapProperty.p is GamePlayerStateSurrender.State) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
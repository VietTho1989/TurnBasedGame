using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerUpdate : UpdateBehavior<GamePlayer>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
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
		if (data is GamePlayer) {
			GamePlayer gamePlayer = data as GamePlayer;
			// Check Left
			{
				UpdateUtils.makeUpdate<GamePlayerCheckLeft, GamePlayer> (gamePlayer, this.transform);
			}
			// child
			{
				gamePlayer.inform.allAddCallBack(this);
				gamePlayer.state.allAddCallBack (this);
			}
			return;
		}
		// Child
		{
			if (data is GamePlayer.Inform) {
				GamePlayer.Inform inform = data as GamePlayer.Inform;
				{
					if (inform is Human) {
						Human human = inform as Human;
						// Make Update
						{
							UpdateUtils.makeUpdate<HumanUpdate, Human> (human, this.transform);
						}
					}
				}
				return;
			}
			if (data is GamePlayer.State) {
				GamePlayer.State state = data as GamePlayer.State;
				switch (state.getType ()) {
				case GamePlayer.State.Type.Normal:
					{
						GamePlayerStateNormal gamePlayerStateNormal = state as GamePlayerStateNormal;
						UpdateUtils.makeUpdate<GamePlayerStateNormalUpdate, GamePlayerStateNormal> (gamePlayerStateNormal, this.transform);
					}
					break;
				case GamePlayer.State.Type.Surrender:
					{
						GamePlayerStateSurrender gamePlayerStateSurrender = state as GamePlayerStateSurrender;
						UpdateUtils.makeUpdate<GamePlayerStateSurrenderUpdate, GamePlayerStateSurrender> (gamePlayerStateSurrender, this.transform);
					}
					break;
				default:
					Debug.LogError ("unknown type: " + state.getType ());
					break;
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is GamePlayer) {
			GamePlayer gamePlayer = data as GamePlayer;
			// Update
			{
				gamePlayer.removeCallBackAndDestroy (typeof(GamePlayerCheckLeft));
			}
			// child
			{
				gamePlayer.inform.allRemoveCallBack(this);
				gamePlayer.state.allRemoveCallBack(this);
			}
			// set data null
			this.setDataNull (gamePlayer);
			return;
		}
		// Child
		{
			if (data is GamePlayer.Inform) {
				GamePlayer.Inform inform = data as GamePlayer.Inform;
				switch (inform.getType ()) {
				case GamePlayer.Inform.Type.Computer:
					break;
				case GamePlayer.Inform.Type.Human:
					{
						Human human = (Human)(object)inform;
						human.removeCallBackAndDestroy (typeof(HumanUpdate));
					}
					break;
				case GamePlayer.Inform.Type.None:
					break;
				default:
					Debug.LogError ("unknown type: " + inform.getType ());
					break;
				}
				return;
			}
			if (data is GamePlayer.State) {
				GamePlayer.State state = data as GamePlayer.State;
				switch (state.getType ()) {
				case GamePlayer.State.Type.Normal:
					{
						GamePlayerStateNormal gamePlayerStateNormal = state as GamePlayerStateNormal;
						gamePlayerStateNormal.removeCallBackAndDestroy (typeof(GamePlayerStateNormalUpdate));
					}
					break;
				case GamePlayer.State.Type.Surrender:
					{
						GamePlayerStateSurrender gamePlayerStateSurrender = state as GamePlayerStateSurrender;
						gamePlayerStateSurrender.removeCallBackAndDestroy (typeof(GamePlayerStateSurrenderUpdate));
					}
					break;
				default:
					Debug.LogError ("unknown type: " + state.getType ());
					break;
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is GamePlayer) {
			switch ((GamePlayer.Property)wrapProperty.n) {
			case GamePlayer.Property.playerIndex:
				break;
			case GamePlayer.Property.inform:
				ValueChangeUtils.replaceCallBack (this, syncs);
				break;
			case GamePlayer.Property.state:
				ValueChangeUtils.replaceCallBack (this, syncs);
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			if (wrapProperty.p is GamePlayer.Inform) {
				return;
			}
			if (wrapProperty.p is GamePlayer.State) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
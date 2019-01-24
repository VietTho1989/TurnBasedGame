using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameState;

public class GameActionsNotPauseUpdate : UpdateBehavior<Game>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				if (this.transform.childCount >= 1) {
					GameObject content = this.transform.GetChild (0).gameObject;
					// need Pause?
					bool needPause = true;
					{
						if (Game.IsPlayingOrFinish (this.data)) {
							needPause = false;
						}
					}
					// Pause
					if (needPause) {
						Debug.LogError ("need pause");
						content.SetActive (false);
					} else {
						Debug.LogError ("Don't need pause");
						content.SetActive (true);
					}
				} else {
					Debug.LogError ("Why don't have child");
				}
			} else {
				Debug.LogError ("gameAction null");
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	private GameIsPlayingChange<Game> gameIsPlayingChange = new GameIsPlayingChange<Game>();

	public override void onAddCallBack<T> (T data)
	{
		if (data is Game) {
			Game game = data as Game;
			// CheckChange
			{
				gameIsPlayingChange.addCallBack (this);
				gameIsPlayingChange.setData (game);
			}
			dirty = true;
			return;
		}
		// CheckChange
		if (data is GameIsPlayingChange<Game>) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is Game) {
			Game game = data as Game;
			// CheckChange
			{
				gameIsPlayingChange.removeCallBack (this);
				gameIsPlayingChange.setData (null);
			}
			this.setDataNull (game);
			return;
		}
		// CheckChange
		if (data is GameIsPlayingChange<Game>) {
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is Game) {
			return;
		}
		// CheckChange
		if (wrapProperty.p is GameIsPlayingChange<Game>) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
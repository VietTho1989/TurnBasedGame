using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameTypeUpdate : UpdateBehavior<GameType>
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
		if (data is GameType) {
			GameType gameType = data as GameType;
			// Update
			{
				// check game finish
				UpdateUtils.makeUpdate<CheckGameFinishUpdate, GameType> (gameType, this.transform);
				// weiqi
				switch (gameType.getType ()) {
				case GameType.Type.Weiqi:
					{
						Weiqi.Weiqi weiqi = gameType as Weiqi.Weiqi;
						UpdateUtils.makeUpdate<Weiqi.WeiqiUpdate, Weiqi.Weiqi> (weiqi, this.transform);
					}
					break;
				default:
					// Debug.LogError ("unknown gameType: " + gameType + "; " + this);
					break;
				}
			}
			dirty = true;
			return;
		}
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is GameType) {
			GameType gameType = data as GameType;
			// Update
			{
				// check game finish
				gameType.removeCallBackAndDestroy(typeof(CheckGameFinishUpdate));
				// weiqi
				switch (gameType.getType ()) {
				case GameType.Type.Weiqi:
					{
						Weiqi.Weiqi weiqi = gameType as Weiqi.Weiqi;
						weiqi.removeCallBackAndDestroy (typeof(Weiqi.WeiqiUpdate));
					}
					break;
				default:
					// Debug.LogError ("unknown gameType: " + gameType + "; " + this);
					break;
				}
			}
			this.setDataNull (gameType);
			return;
		}
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is GameType) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
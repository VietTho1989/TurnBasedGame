using UnityEngine;
using System.Collections;

public class GamePlayerStateNormalUpdate : UpdateBehavior<GamePlayerStateNormal>
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
		if (data is GamePlayerStateNormal) {
			return;
		}
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is GamePlayerStateNormal) {
			GamePlayerStateNormal gamePlayerStateNormal = data as GamePlayerStateNormal;
			// set data null
			this.setDataNull (gamePlayerStateNormal);
			return;
		}
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, System.Collections.Generic.List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
	}

	#endregion

}
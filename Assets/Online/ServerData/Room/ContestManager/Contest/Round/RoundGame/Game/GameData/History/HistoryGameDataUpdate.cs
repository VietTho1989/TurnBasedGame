using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HistoryGameDataUpdate : UpdateBehavior<GameData>
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
		for (int i = 0; i < data.pts.Count; i++) {
			WrapProperty property = data.pts [i];
			if (property.nh != 0) {
				if (Generic.IsAddCallBackInterface (property.getValueType ())) {
					property.allAddCallBack (this);
				}
			}
		}
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		data.removeCallBackAllChildren (this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.nh != 0) {
			// Make History Change
			if (this.data != null) {
				Game game = this.data.findDataInParent<Game> ();
				if (game != null) {
					game.history.v.makeHistoryChange (wrapProperty, syncs);
				} else {
					Debug.LogError ("game null: " + this);
				}
			} else {
				Debug.LogError ("gameData null: " + this);
			}
			// CallBack
			if (typeof(T).IsSubclassOf (typeof(Data))) {
				ValueChangeUtils.replaceCallBack (this, syncs);
			}
		}
	}

	#endregion
}
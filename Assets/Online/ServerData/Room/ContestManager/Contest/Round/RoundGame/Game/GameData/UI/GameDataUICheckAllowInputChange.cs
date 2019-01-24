using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDataUICheckAllowInputChange<K> : Data, ValueChangeCallBack where K : Data
{

	public VP<int> change;

	private void notifyChange()
	{
		this.change.v = this.change.v + 1;
	}

	#region Constructor

	public enum Property
	{
		change
	}

	public GameDataUICheckAllowInputChange() : base()
	{
		this.change = new VP<int> (this, (byte)Property.change, 0);
	}

	#endregion

	public K data;

	public void setData(K newData){
		if (this.data != newData) {
			// remove old
			{
				DataUtils.removeParentCallBack (this.data, this, ref this.gameDataUIData);
			}
			// set new 
			{
				this.data = newData;
				DataUtils.addParentCallBack (this.data, this, ref this.gameDataUIData);
			}
		} else {
			Debug.LogError ("the same: " + this + ", " + data + ", " + newData);
		}
	}

	#region implement callBacks

	private GameDataUI.UIData gameDataUIData = null;

	public void onAddCallBack<T> (T data) where T:Data
	{
		if(data is GameDataUI.UIData){
			// GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
			this.notifyChange ();
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public void onRemoveCallBack<T> (T data, bool isHide) where T:Data
	{
		// gameDataUIData
		if(data is GameDataUI.UIData){
			// GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is GameDataUI.UIData) {
			switch ((GameDataUI.UIData.Property)wrapProperty.n) {
			case GameDataUI.UIData.Property.gameData:
				break;
			case GameDataUI.UIData.Property.board:
				break;
			case GameDataUI.UIData.Property.allowLastMove:
				break;
			case GameDataUI.UIData.Property.hintUI:
				break;
			case GameDataUI.UIData.Property.allowInput:
				this.notifyChange ();
				break;
			case GameDataUI.UIData.Property.turn:
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
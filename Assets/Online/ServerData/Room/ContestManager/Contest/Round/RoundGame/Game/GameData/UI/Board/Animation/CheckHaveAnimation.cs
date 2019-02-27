using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckHaveAnimation<K> : Data, ValueChangeCallBack where K : Data
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

	public CheckHaveAnimation() : base()
	{
		this.change = new VP<int> (this, (byte)Property.change, 0);
	}

	#endregion

	public K data;

	public void setData(K newData){
		if (this.data != newData) {
			// remove old
			{
				DataUtils.removeParentCallBack (this.data, this, ref this.gameDataBoardUIData);
			}
			// set new 
			{
				this.data = newData;
				DataUtils.addParentCallBack (this.data, this, ref this.gameDataBoardUIData);
			}
		} else {
			Debug.LogError ("the same: " + this + ", " + data + ", " + newData);
		}
	}

	#region implement callBacks

	private GameDataBoardUI.UIData gameDataBoardUIData = null;

	public void onAddCallBack<T> (T data) where T:Data
	{
		if (data is GameDataBoardUI.UIData) {
			GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
			// Child
			{
				gameDataBoardUIData.animationManager.allAddCallBack (this);
			}
			this.notifyChange ();
			return;
		}
		// Child
		{
			if (data is AnimationManager) {
				this.notifyChange ();
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public void onRemoveCallBack<T> (T data, bool isHide) where T:Data
	{
		if (data is GameDataBoardUI.UIData) {
			GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
			// Child
			{
				gameDataBoardUIData.animationManager.allRemoveCallBack (this);
			}
			this.gameDataBoardUIData = null;
			return;
		}
		// Child
		{
			if (data is AnimationManager) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is GameDataBoardUI.UIData) {
			switch ((GameDataBoardUI.UIData.Property)wrapProperty.n) {
			case GameDataBoardUI.UIData.Property.gameData:
				break;
			case GameDataBoardUI.UIData.Property.animationManager:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					this.notifyChange ();
				}
				break;
			case GameDataBoardUI.UIData.Property.sub:
				break;
			case GameDataBoardUI.UIData.Property.perspective:
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			if (wrapProperty.p is AnimationManager) {
				switch ((AnimationManager.Property)wrapProperty.n) {
				case AnimationManager.Property.animationProgresses:
					this.notifyChange ();
					break;
				case AnimationManager.Property.lastMove:
					break;
				case AnimationManager.Property.state:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	#endregion

}
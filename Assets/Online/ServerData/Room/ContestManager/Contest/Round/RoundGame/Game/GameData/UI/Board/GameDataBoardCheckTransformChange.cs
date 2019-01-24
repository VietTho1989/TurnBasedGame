using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * TODO sau nay se them miniGameDataUI
 * */
public class GameDataBoardCheckTransformChange<K> : Data, ValueChangeCallBack where K : Data
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

	public GameDataBoardCheckTransformChange() : base()
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
			{
				gameDataBoardUIData.updateTransform.allAddCallBack (this);
				gameDataBoardUIData.perspective.allAddCallBack (this);
			}
			this.notifyChange ();
			return;
		}
		if (data is UpdateTransform.UpdateData) {
			this.notifyChange ();
			return;
		}
		if (data is Perspective) {
			this.notifyChange ();
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public void onRemoveCallBack<T> (T data, bool isHide) where T:Data
	{
		if (data is GameDataBoardUI.UIData) {
			GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
			{
				gameDataBoardUIData.updateTransform.allRemoveCallBack (this);
				gameDataBoardUIData.perspective.allRemoveCallBack (this);
			}
			return;
		}
		if (data is UpdateTransform.UpdateData) {
			return;
		}
		if (data is Perspective) {
			return;
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
			case GameDataBoardUI.UIData.Property.sub:
				break;
			case GameDataBoardUI.UIData.Property.perspective:
				{
					ValueChangeUtils.replaceCallBack(this, syncs);
					this.notifyChange();
				}
				break;
			case GameDataBoardUI.UIData.Property.perspectiveUIData:
				break;
			case GameDataBoardUI.UIData.Property.updateTransform:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		if (wrapProperty.p is UpdateTransform.UpdateData) {
			this.notifyChange ();
			return;
		}
		if (wrapProperty.p is Perspective) {
			switch ((Perspective.Property)wrapProperty.n) {
			case Perspective.Property.playerView:
				this.notifyChange ();
				break;
			case Perspective.Property.sub:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	#endregion

}
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
            // Child
			{
                // transformData
                {
                    GameDataBoardUI gameDataBoardUI = gameDataBoardUIData.findDataInParent<GameDataBoardUI>();
                    if (gameDataBoardUI != null)
                    {
                        gameDataBoardUI.transformData.addCallBack(this);
                    }
                    else
                    {
                        // Debug.LogError("gameDataBoardUI null");
                    }
                }
				gameDataBoardUIData.perspective.allAddCallBack (this);
			}
			this.notifyChange ();
			return;
		}
        // Child
        {
            if (data is TransformData)
            {
                this.notifyChange();
                return;
            }
            if (data is Perspective)
            {
                this.notifyChange();
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
                // transformData
                {
                    GameDataBoardUI gameDataBoardUI = gameDataBoardUIData.findDataInParent<GameDataBoardUI>();
                    if (gameDataBoardUI != null)
                    {
                        gameDataBoardUI.transformData.removeCallBack(this);
                    }
                    else
                    {
                        Debug.LogError("gameDataBoardUI null");
                    }
                }
                gameDataBoardUIData.perspective.allRemoveCallBack (this);
			}
			return;
		}
        // Child
        {
            if (data is TransformData)
            {
                return;
            }
            if (data is Perspective)
            {
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
			case GameDataBoardUI.UIData.Property.sub:
				break;
			case GameDataBoardUI.UIData.Property.perspective:
				{
					ValueChangeUtils.replaceCallBack(this, syncs);
					this.notifyChange();
				}
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
        // Child
        {
            if (wrapProperty.p is TransformData)
            {
                this.notifyChange();
                return;
            }
            if (wrapProperty.p is Perspective)
            {
                switch ((Perspective.Property)wrapProperty.n)
                {
                    case Perspective.Property.playerView:
                        this.notifyChange();
                        break;
                    case Perspective.Property.sub:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
        }
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	#endregion

}
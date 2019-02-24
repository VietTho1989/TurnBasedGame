using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameState;

public class BtnPauseUnPauseUI : UIBehavior<BtnPauseUnPauseUI.UIData>
{

    #region UIData

    public class UIData : BtnPauseUI.UIData.Sub
    {

        public VP<ReferenceData<PlayUnPause>> playUnPause;

        #region Constructor

        public enum Property
        {
            playUnPause
        }

        public UIData() : base()
        {
            this.playUnPause = new VP<ReferenceData<PlayUnPause>>(this, (byte)Property.playUnPause, new ReferenceData<PlayUnPause>(null));
        }

        #endregion

        public override Play.Sub.Type getType()
        {
            return Play.Sub.Type.UnPause;
        }

    }

    #endregion

    #region Refresh

    public Button btnUnPause;
    public Text tvUnPause;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                PlayUnPause playUnPause = this.data.playUnPause.v.data;
                if (playUnPause != null)
                {

                }
                else
                {
                    Debug.LogError("playUnPause null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return false;
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
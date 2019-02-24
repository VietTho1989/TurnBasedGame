using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameState;

public class BtnPausePauseUI : UIBehavior<BtnPausePauseUI.UIData>
{

    #region UIData

    public class UIData : BtnPauseUI.UIData.Sub
    {

        public VP<ReferenceData<PlayPause>> playPause;

        #region Constructor

        public enum Property
        {
            playPause
        }

        public UIData() : base()
        {
            this.playPause = new VP<ReferenceData<PlayPause>>(this, (byte)Property.playPause, new ReferenceData<PlayPause>(null));
        }

        #endregion

        public override Play.Sub.Type getType()
        {
            return Play.Sub.Type.Pause;
        }

    }

    #endregion

    #region Refresh

    public Button btnPause;
    public Text tvPause;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                PlayPause playPause = this.data.playPause.v.data;
                if (playPause != null)
                {

                }
                else
                {
                    Debug.LogError("playPause null");
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
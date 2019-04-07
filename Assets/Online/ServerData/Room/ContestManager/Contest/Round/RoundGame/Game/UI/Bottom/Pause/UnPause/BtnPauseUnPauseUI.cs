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

    #region txt

    private static readonly TxtLanguage txtUnPause = new TxtLanguage("Unpausing");

    static BtnPauseUnPauseUI()
    {
        txtUnPause.add(Language.Type.vi, "Huỷ dừng");
    }

    #endregion

    #region Refresh

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
                    if (tvUnPause != null)
                    {
                        tvUnPause.text = txtUnPause.get() + " " + Mathf.Min(playUnPause.time.v, playUnPause.duration.v) + "/" + playUnPause.duration.v;
                    }
                    else
                    {
                        Debug.LogError("tvUnPause null");
                    }
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
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.playUnPause.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        if(data is PlayUnPause)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.playUnPause.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        if (data is PlayUnPause)
        {
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is UIData)
        {
            switch ((UIData.Property)wrapProperty.n)
            {
                case UIData.Property.playUnPause:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        if (wrapProperty.p is PlayUnPause)
        {
            switch ((PlayUnPause.Property)wrapProperty.n)
            {
                case PlayUnPause.Property.human:
                    break;
                case PlayUnPause.Property.time:
                    dirty = true;
                    break;
                case PlayUnPause.Property.duration:
                    dirty = true;
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameState;

public class BtnPauseUI : UIBehavior<BtnPauseUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<Play>> play;

        #region sub

        public abstract class Sub : Data
        {

            public abstract Play.Sub.Type getType();

        }

        public VP<Sub> sub;

        #endregion

        #region Constructor

        public enum Property
        {
            play,
            sub
        }

        public UIData() : base()
        {
            this.play = new VP<ReferenceData<Play>>(this, (byte)Property.play, new ReferenceData<Play>(null));
            this.sub = new VP<Sub>(this, (byte)Property.sub, null);
        }

        #endregion

    }

    #endregion

    #region txt

    public Text tvNotPlaying;
    private static readonly TxtLanguage txtNotPlaying = new TxtLanguage();

    static BtnPauseUI()
    {
        txtNotPlaying.add(Language.Type.vi, "Không Chơi");
    }

    #endregion

    #region Refresh

    public GameObject notPlayingContainer;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                Play play = this.data.play.v.data;
                if (play != null)
                {
                    // notPlayingContainer
                    if (notPlayingContainer != null)
                    {
                        notPlayingContainer.SetActive(false);
                    }
                    else
                    {
                        Debug.LogError("notPlayingContainer null");
                    }
                    // sub
                    {
                        switch (play.sub.v.getType())
                        {
                            case Play.Sub.Type.Normal:
                                {
                                    PlayNormal playNormal = play.sub.v as PlayNormal;
                                    // UI
                                    {
                                        BtnPauseNormalUI.UIData normalUIData = this.data.sub.newOrOld<BtnPauseNormalUI.UIData>();
                                        {
                                            normalUIData.playNormal.v = new ReferenceData<PlayNormal>(playNormal);
                                        }
                                        this.data.sub.v = normalUIData;
                                    }
                                }
                                break;
                            case Play.Sub.Type.Pause:
                                {
                                    PlayPause playPause = play.sub.v as PlayPause;
                                    // UI
                                    {
                                        BtnPausePauseUI.UIData pauseUIData = this.data.sub.newOrOld<BtnPausePauseUI.UIData>();
                                        {
                                            pauseUIData.playPause.v = new ReferenceData<PlayPause>(playPause);
                                        }
                                        this.data.sub.v = pauseUIData;
                                    }
                                }
                                break;
                            case Play.Sub.Type.UnPause:
                                {
                                    PlayUnPause playUnPause = play.sub.v as PlayUnPause;
                                    // UI
                                    {
                                        BtnPauseUnPauseUI.UIData unPauseUIData = this.data.sub.newOrOld<BtnPauseUnPauseUI.UIData>();
                                        {
                                            unPauseUIData.playUnPause.v = new ReferenceData<PlayUnPause>(playUnPause);
                                        }
                                        this.data.sub.v = unPauseUIData;
                                    }
                                }
                                break;
                            default:
                                Debug.LogError("unknown sub: " + play.sub.v);
                                break;
                        }
                    }
                }
                else
                {
                    Debug.LogError("play null");
                    // notPlayingContainer
                    if (notPlayingContainer != null)
                    {
                        notPlayingContainer.SetActive(true);
                    }
                    else
                    {
                        Debug.LogError("notPlayingContainer null");
                    }
                    // sub
                    this.data.sub.v = null;
                }
                // txt
                {
                    if (tvNotPlaying != null)
                    {
                        tvNotPlaying.text = txtNotPlaying.get("Not Playing");
                    }
                    else
                    {
                        Debug.LogError("tvNotPlaying null");
                    }
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
        return true;
    }

    #endregion

    #region implement callBacks

    public BtnPauseNormalUI normalPrefab;
    public BtnPausePauseUI pausePrefab;
    public BtnPauseUnPauseUI unpausePrefab;
    private static readonly UIRectTransform subRect = UIConstants.FullParent;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.play.allAddCallBack(this);
                uiData.sub.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Setting
        if(data is Setting)
        {
            dirty = true;
            return;
        }
        // Child
        {
            if (data is Play)
            {
                dirty = true;
                return;
            }
            if(data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case Play.Sub.Type.Normal:
                            {
                                BtnPauseNormalUI.UIData normalUIData = sub as BtnPauseNormalUI.UIData;
                                UIUtils.Instantiate(normalUIData, normalPrefab, this.transform, subRect);
                            }
                            break;
                        case Play.Sub.Type.Pause:
                            {
                                BtnPausePauseUI.UIData pauseUIData = sub as BtnPausePauseUI.UIData;
                                UIUtils.Instantiate(pauseUIData, pausePrefab, this.transform, subRect);
                            }
                            break;
                        case Play.Sub.Type.UnPause:
                            {
                                BtnPauseUnPauseUI.UIData unpauseUIData = sub as BtnPauseUnPauseUI.UIData;
                                UIUtils.Instantiate(unpauseUIData, unpausePrefab, this.transform, subRect);
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType());
                            break;
                    }
                }
                dirty = true;
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().removeCallBack(this);
            // Child
            {
                uiData.play.allRemoveCallBack(this);
                uiData.sub.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if (data is Setting)
        {
            return;
        }
        // Child
        {
            if (data is Play)
            {
                return;
            }
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case Play.Sub.Type.Normal:
                            {
                                BtnPauseNormalUI.UIData normalUIData = sub as BtnPauseNormalUI.UIData;
                                normalUIData.removeCallBackAndDestroy(typeof(BtnPauseNormalUI));
                            }
                            break;
                        case Play.Sub.Type.Pause:
                            {
                                BtnPausePauseUI.UIData pauseUIData = sub as BtnPausePauseUI.UIData;
                                pauseUIData.removeCallBackAndDestroy(typeof(BtnPausePauseUI));
                            }
                            break;
                        case Play.Sub.Type.UnPause:
                            {
                                BtnPauseUnPauseUI.UIData unpauseUIData = sub as BtnPauseUnPauseUI.UIData;
                                unpauseUIData.removeCallBackAndDestroy(typeof(BtnPauseUnPauseUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType());
                            break;
                    }
                }
                return;
            }
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
                case UIData.Property.play:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.sub:
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
        // Setting
        if (wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
                case Setting.Property.language:
                    dirty = true;
                    break;
                case Setting.Property.style:
                    break;
                case Setting.Property.showLastMove:
                    break;
                case Setting.Property.viewUrlImage:
                    break;
                case Setting.Property.animationSetting:
                    break;
                case Setting.Property.maxThinkCount:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is Play)
            {
                switch ((Play.Property)wrapProperty.n)
                {
                    case Play.Property.sub:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            if(wrapProperty.p is UIData.Sub)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
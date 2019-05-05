using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerStateBtnUI : UIBehavior<GamePlayerStateBtnUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<GamePlayer.State>> state;

        public VP<GamePlayerStateUI.UIData> stateUIData;

        #region Constructor

        public enum Property
        {
            state,
            stateUIData
        }

        public UIData() : base()
        {
            this.state = new VP<ReferenceData<GamePlayer.State>>(this, (byte)Property.state, new ReferenceData<GamePlayer.State>(null));
            this.stateUIData = new VP<GamePlayerStateUI.UIData>(this, (byte)Property.stateUIData, null);
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // stateUIData
                if (!isProcess)
                {
                    GamePlayerStateUI.UIData stateUIData = this.stateUIData.v;
                    if (stateUIData != null)
                    {
                        isProcess = stateUIData.processEvent(e);
                    }
                    else
                    {
                        // Debug.LogError("stateUIData null");
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        GamePlayerStateBtnUI gamePlayerStateBtnUI = this.findCallBack<GamePlayerStateBtnUI>();
                        if (gamePlayerStateBtnUI != null)
                        {
                            isProcess = gamePlayerStateBtnUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("gamePlayerStateBtnUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region Refresh

    public GameObject highlightIndicator;

    public Sprite spriteStateNormal;
    public Sprite spriteStateSurrender;
    public Image ivState;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                GamePlayer.State state = this.data.state.v.data;
                if (state != null)
                {
                    // highlight
                    if (highlightIndicator != null)
                    {
                        bool isHighlight = false;
                        {
                            switch (state.getType())
                            {
                                case GamePlayer.State.Type.Normal:
                                    {

                                    }
                                    break;
                                case GamePlayer.State.Type.Surrender:
                                    {
                                        GamePlayerStateSurrender surrender = state as GamePlayerStateSurrender;
                                        if(surrender.state.v.getType()== GamePlayerStateSurrender.State.Type.Ask)
                                        {
                                            isHighlight = true;
                                        }
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + state.getType());
                                    break;
                            }
                        }
                        highlightIndicator.SetActive(isHighlight);
                    }
                    else
                    {
                        Debug.LogError("highlightIndicator null");
                    }
                    // ivState
                    if (ivState != null)
                    {
                        switch (state.getType())
                        {
                            case GamePlayer.State.Type.Normal:
                                ivState.sprite = spriteStateNormal;
                                break;
                            case GamePlayer.State.Type.Surrender:
                                ivState.sprite = spriteStateSurrender;
                                break;
                            default:
                                Debug.LogError("unknown type: " + state.getType());
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("ivState null");
                    }
                    // stateUIData
                    {
                        GamePlayerStateUI.UIData stateUIData = this.data.stateUIData.v;
                        if (stateUIData != null)
                        {
                            stateUIData.state.v = new ReferenceData<GamePlayer.State>(state);
                        }
                        else
                        {
                            Debug.LogError("stateUIData null");
                        }
                    }
                }
                else
                {
                    // Debug.LogError("state null");
                }
            }
            else
            {
                // Debug.LogError("data null");
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public GamePlayerStateUI stateUIPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.state.allAddCallBack(this);
                uiData.stateUIData.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if(data is GamePlayer.State)
            {
                dirty = true;
                return;
            }
            if(data is GamePlayerStateUI.UIData)
            {
                GamePlayerStateUI.UIData stateUIData = data as GamePlayerStateUI.UIData;
                // UI
                {
                    Transform stateUIContainer = null;
                    {
                        GameUI.UIData gameUIData = stateUIData.findDataInParent<GameUI.UIData>();
                        if (gameUIData != null)
                        {
                            GameUI gameUI = gameUIData.findCallBack<GameUI>();
                            if (gameUI != null)
                            {
                                stateUIContainer = gameUI.dialogContainer;
                            }
                            else
                            {
                                Debug.LogError("gameUI null");
                            }
                        }
                        else
                        {
                            Debug.LogError("gameUIData null");
                        }
                    }
                    UIUtils.Instantiate(stateUIData, stateUIPrefab, stateUIContainer);
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
            // Child
            {
                uiData.state.allRemoveCallBack(this);
                uiData.stateUIData.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is GamePlayer.State)
            {
                return;
            }
            if (data is GamePlayerStateUI.UIData)
            {
                GamePlayerStateUI.UIData stateUIData = data as GamePlayerStateUI.UIData;
                // UI
                {
                    stateUIData.removeCallBackAndDestroy(typeof(GamePlayerStateUI));
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
                case UIData.Property.state:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.stateUIData:
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
        {
            if (wrapProperty.p is GamePlayer.State)
            {
                GamePlayer.State state = wrapProperty.p as GamePlayer.State;
                switch (state.getType())
                {
                    case GamePlayer.State.Type.Normal:
                        break;
                    case GamePlayer.State.Type.Surrender:
                        {
                            switch ((GamePlayerStateSurrender.Property)wrapProperty.n)
                            {
                                case GamePlayerStateSurrender.Property.state:
                                    dirty = true;
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            if (wrapProperty.p is GamePlayerStateUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnShow()
    {
        if (this.data != null)
        {
            GamePlayer.State state = this.data.state.v.data;
            if (state != null)
            {
                GamePlayerStateUI.UIData stateUIData = this.data.stateUIData.newOrOld<GamePlayerStateUI.UIData>();
                {
                    stateUIData.state.v = new ReferenceData<GamePlayer.State>(state);
                }
                this.data.stateUIData.v = stateUIData;
            }
            else
            {
                Debug.LogError("state null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hint;

namespace Solitaire
{
    public class ShowHintUI : UIBehavior<ShowHintUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<LastMoveSub> sub;

            #region Constructor

            public enum Property
            {
                sub
            }

            public UIData() : base()
            {
                this.sub = new VP<LastMoveSub>(this, (byte)Property.sub, null);
            }

            #endregion

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Solitaire ? 1 : 0;
        }

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    bool canShowHint = false;
                    {
                        SolitaireGameDataUI.UIData solitaireGameDataUIData = this.data.findDataInParent<SolitaireGameDataUI.UIData>();
                        if (solitaireGameDataUIData != null)
                        {
                            if (!solitaireGameDataUIData.isOnAnimation.v)
                            {
                                canShowHint = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("solitaireGameDataUIData null: " + this);
                        }
                    }
                    if (canShowHint)
                    {
                        // Find HintMove
                        GameMove hintMove = null;
                        {
                            GameDataUI.UIData gameDataUIData = this.data.findDataInParent<GameDataUI.UIData>();
                            if (gameDataUIData != null)
                            {
                                HintUI.UIData hintUIData = gameDataUIData.hintUI.v;
                                if (hintUIData != null)
                                {
                                    if (hintUIData.state.v != null && hintUIData.state.v is ShowUI.UIData)
                                    {
                                        ShowUI.UIData showUIData = hintUIData.state.v as ShowUI.UIData;
                                        hintMove = showUIData.hintMove.v;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("hintUIData null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("gameDataUIData null: " + this);
                            }
                        }
                        if (hintMove != null)
                        {
                            switch (hintMove.getType())
                            {
                                case GameMove.Type.SolitaireMove:
                                    {
                                        SolitaireMove solitaireMove = hintMove as SolitaireMove;
                                        // Find
                                        SolitaireMoveUI.UIData solitaireMoveUIData = this.data.sub.newOrOld<SolitaireMoveUI.UIData>();
                                        {
                                            // move
                                            solitaireMoveUIData.solitaireMove.v = new ReferenceData<SolitaireMove>(solitaireMove);
                                            // isHint
                                            solitaireMoveUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = solitaireMoveUIData;
                                    }
                                    break;
                                case GameMove.Type.SolitaireReset:
                                    {
                                        SolitaireReset solitaireReset = hintMove as SolitaireReset;
                                        // Find
                                        SolitaireResetUI.UIData solitaireResetUIData = this.data.sub.newOrOld<SolitaireResetUI.UIData>();
                                        {
                                            // move
                                            solitaireResetUIData.solitaireReset.v = new ReferenceData<SolitaireReset>(solitaireReset);
                                            // isHint
                                            solitaireResetUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = solitaireResetUIData;
                                    }
                                    break;
                                default:
                                    {
                                        Debug.LogError("unknown hintMove: " + hintMove + ";" + this);
                                        this.data.sub.v = null;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            // Debug.LogError ("hintMove null: " + this);
                            this.data.sub.v = null;
                        }
                    }
                    else
                    {
                        // Debug.LogError ("cannot show hint: " + this);
                        this.data.sub.v = null;
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public SolitaireMoveUI solitaireMovePrefab;
        public SolitaireResetUI solitaireResetPrefab;

        private SolitaireGameDataUI.UIData solitaireGameDataUIData = null;
        private GameDataUI.UIData gameDataUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.solitaireGameDataUIData);
                    DataUtils.addParentCallBack(uiData, this, ref this.gameDataUIData);
                }
                // Child
                {
                    uiData.sub.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                // solitaireGameDataUIData
                if (data is SolitaireGameDataUI.UIData)
                {
                    dirty = true;
                    return;
                }
                // gameDataUIData
                {
                    if (data is GameDataUI.UIData)
                    {
                        GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                        // Child
                        {
                            gameDataUIData.hintUI.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is HintUI.UIData)
                        {
                            HintUI.UIData hintUIData = data as HintUI.UIData;
                            // Child
                            {
                                hintUIData.state.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if (data is HintUI.UIData.State)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }

            }
            // Child
            {
                if (data is LastMoveSub)
                {
                    LastMoveSub sub = data as LastMoveSub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case GameMove.Type.SolitaireMove:
                                {
                                    SolitaireMoveUI.UIData solitaireMoveUIData = sub as SolitaireMoveUI.UIData;
                                    UIUtils.Instantiate(solitaireMoveUIData, solitaireMovePrefab, this.transform);
                                }
                                break;
                            case GameMove.Type.SolitaireReset:
                                {
                                    SolitaireResetUI.UIData solitaireResetUIData = sub as SolitaireResetUI.UIData;
                                    UIUtils.Instantiate(solitaireResetUIData, solitaireResetPrefab, this.transform);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType() + "; " + this);
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.solitaireGameDataUIData);
                    DataUtils.removeParentCallBack(uiData, this, ref this.gameDataUIData);
                }
                // Child
                {
                    uiData.sub.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                // solitaireGameDataUIData
                if (data is SolitaireGameDataUI.UIData)
                {
                    return;
                }
                // gameDataUIData
                {
                    if (data is GameDataUI.UIData)
                    {
                        GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                        // Child
                        {
                            gameDataUIData.hintUI.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is HintUI.UIData)
                        {
                            HintUI.UIData hintUIData = data as HintUI.UIData;
                            {
                                hintUIData.state.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        if (data is HintUI.UIData.State)
                        {
                            return;
                        }
                    }
                }

            }
            // Child
            {
                if (data is LastMoveSub)
                {
                    LastMoveSub sub = data as LastMoveSub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case GameMove.Type.SolitaireMove:
                                {
                                    SolitaireMoveUI.UIData solitaireMoveUIData = sub as SolitaireMoveUI.UIData;
                                    solitaireMoveUIData.removeCallBackAndDestroy(typeof(SolitaireMoveUI));
                                }
                                break;
                            case GameMove.Type.SolitaireReset:
                                {
                                    SolitaireResetUI.UIData solitaireResetUIData = sub as SolitaireResetUI.UIData;
                                    solitaireResetUIData.removeCallBackAndDestroy(typeof(SolitaireResetUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType() + "; " + this);
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
            // Parent
            {
                // solitaireGameDataUIData
                if (wrapProperty.p is SolitaireGameDataUI.UIData)
                {
                    switch ((SolitaireGameDataUI.UIData.Property)wrapProperty.n)
                    {
                        case SolitaireGameDataUI.UIData.Property.gameData:
                            break;
                        case SolitaireGameDataUI.UIData.Property.isOnAnimation:
                            dirty = true;
                            break;
                        case SolitaireGameDataUI.UIData.Property.board:
                            break;
                        case SolitaireGameDataUI.UIData.Property.lastMove:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // gameDataUIData
                {
                    if (wrapProperty.p is GameDataUI.UIData)
                    {
                        switch ((GameDataUI.UIData.Property)wrapProperty.n)
                        {
                            case GameDataUI.UIData.Property.gameData:
                                break;
                            case GameDataUI.UIData.Property.board:
                                break;
                            case GameDataUI.UIData.Property.allowLastMove:
                                break;
                            case GameDataUI.UIData.Property.hintUI:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case GameDataUI.UIData.Property.allowInput:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is HintUI.UIData)
                        {
                            switch ((HintUI.UIData.Property)wrapProperty.n)
                            {
                                case HintUI.UIData.Property.gameData:
                                    break;
                                case HintUI.UIData.Property.autoHint:
                                    break;
                                case HintUI.UIData.Property.state:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case HintUI.UIData.Property.ai:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Child
                        {
                            if (wrapProperty.p is HintUI.UIData.State)
                            {
                                HintUI.UIData.State state = wrapProperty.p as HintUI.UIData.State;
                                {
                                    switch (state.getType())
                                    {
                                        case HintUI.UIData.State.Type.Not:
                                            break;
                                        case HintUI.UIData.State.Type.Normal:
                                            break;
                                        case HintUI.UIData.State.Type.Get:
                                            break;
                                        case HintUI.UIData.State.Type.Getting:
                                            break;
                                        case HintUI.UIData.State.Type.Show:
                                            {
                                                switch ((ShowUI.UIData.Property)wrapProperty.n)
                                                {
                                                    case ShowUI.UIData.Property.hintMove:
                                                        dirty = true;
                                                        break;
                                                    default:
                                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                        break;
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                            break;
                                    }
                                }
                                return;
                            }
                        }
                    }
                }
            }
            // Child
            {
                if (wrapProperty.p is LastMoveSub)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
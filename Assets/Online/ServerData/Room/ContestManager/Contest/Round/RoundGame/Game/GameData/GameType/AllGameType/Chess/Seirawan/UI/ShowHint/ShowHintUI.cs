using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hint;
using Seirawan.NoneRule;

namespace Seirawan
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
                        SeirawanGameDataUI.UIData seirawanGameDataUIData = this.data.findDataInParent<SeirawanGameDataUI.UIData>();
                        if (seirawanGameDataUIData != null)
                        {
                            if (!seirawanGameDataUIData.isOnAnimation.v)
                            {
                                canShowHint = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("seirawanGameDataUIData null: " + this);
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
                                case GameMove.Type.SeirawanMove:
                                    {
                                        SeirawanMove seirawanMove = hintMove as SeirawanMove;
                                        // Find
                                        SeirawanMoveUI.UIData seirawanMoveUIData = this.data.sub.newOrOld<SeirawanMoveUI.UIData>();
                                        {
                                            // move
                                            seirawanMoveUIData.seirawanMove.v = new ReferenceData<SeirawanMove>(seirawanMove);
                                            // isHint
                                            seirawanMoveUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = seirawanMoveUIData;
                                    }
                                    break;
                                case GameMove.Type.SeirawanCustomSet:
                                    {
                                        SeirawanCustomSet seirawanCustomSet = hintMove as SeirawanCustomSet;
                                        // Find
                                        SeirawanCustomSetUI.UIData seirawanCustomSetUIData = this.data.sub.newOrOld<SeirawanCustomSetUI.UIData>();
                                        {
                                            // move
                                            seirawanCustomSetUIData.seirawanCustomSet.v = new ReferenceData<SeirawanCustomSet>(seirawanCustomSet);
                                            // isHint
                                            seirawanCustomSetUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = seirawanCustomSetUIData;
                                    }
                                    break;
                                case GameMove.Type.SeirawanCustomMove:
                                    {
                                        SeirawanCustomMove seirawanCustomMove = hintMove as SeirawanCustomMove;
                                        // Find
                                        SeirawanCustomMoveUI.UIData seirawanCustomMoveUIData = this.data.sub.newOrOld<SeirawanCustomMoveUI.UIData>();
                                        {
                                            // move
                                            seirawanCustomMoveUIData.seirawanCustomMove.v = new ReferenceData<SeirawanCustomMove>(seirawanCustomMove);
                                            // isHint
                                            seirawanCustomMoveUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = seirawanCustomMoveUIData;
                                    }
                                    break;
                                case GameMove.Type.SeirawanCustomHand:
                                    {
                                        SeirawanCustomHand seirawanCustomHand = hintMove as SeirawanCustomHand;
                                        // Find
                                        SeirawanCustomHandUI.UIData seirawanCustomHandUIData = this.data.sub.newOrOld<SeirawanCustomHandUI.UIData>();
                                        {
                                            // move
                                            seirawanCustomHandUIData.seirawanCustomHand.v = new ReferenceData<SeirawanCustomHand>(seirawanCustomHand);
                                            // isHint
                                            seirawanCustomHandUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = seirawanCustomHandUIData;
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
                        Debug.LogError("cannot show hint: " + this);
                        this.data.sub.v = null;
                    }
                }
                else
                {
                    // Debug.Log ("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public SeirawanMoveUI seirawanMovePrefab;
        public SeirawanCustomSetUI seirawanCustomSetPrefab;
        public SeirawanCustomMoveUI seirawanCustomMovePrefab;
        public SeirawanCustomHandUI seirawanCustomHandPrefab;

        private SeirawanGameDataUI.UIData seirawanGameDataUIData = null;
        private GameDataUI.UIData gameDataUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.seirawanGameDataUIData);
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
                // seirawanGameDataUIData
                if (data is SeirawanGameDataUI.UIData)
                {
                    // SeirawanGameDataUI.UIData seirawanGameDataUIData = data as SeirawanGameDataUI.UIData;
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
                    // HintUI
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
                        // State
                        if (data is HintUI.UIData.State)
                        {
                            HintUI.UIData.State state = data as HintUI.UIData.State;
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
                                            ShowUI.UIData showUIData = state as ShowUI.UIData;
                                            showUIData.hintMove.allAddCallBack(this);
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                        break;
                                }
                            }
                            dirty = true;
                            return;
                        }
                        if (data is GameMove)
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
                    {
                        switch (sub.getType())
                        {
                            case GameMove.Type.SeirawanMove:
                                {
                                    SeirawanMoveUI.UIData seirawanMoveUIData = sub as SeirawanMoveUI.UIData;
                                    UIUtils.Instantiate(seirawanMoveUIData, seirawanMovePrefab, this.transform);
                                }
                                break;
                            case GameMove.Type.SeirawanCustomSet:
                                {
                                    SeirawanCustomSetUI.UIData seirawanCustomSetUIData = sub as SeirawanCustomSetUI.UIData;
                                    UIUtils.Instantiate(seirawanCustomSetUIData, seirawanCustomSetPrefab, this.transform);
                                }
                                break;
                            case GameMove.Type.SeirawanCustomMove:
                                {
                                    SeirawanCustomMoveUI.UIData seirawanCustomMoveUIData = sub as SeirawanCustomMoveUI.UIData;
                                    UIUtils.Instantiate(seirawanCustomMoveUIData, seirawanCustomMovePrefab, this.transform);
                                }
                                break;
                            case GameMove.Type.SeirawanCustomHand:
                                {
                                    SeirawanCustomHandUI.UIData seirawanCustomHandUIData = sub as SeirawanCustomHandUI.UIData;
                                    UIUtils.Instantiate(seirawanCustomHandUIData, seirawanCustomHandPrefab, this.transform);
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.seirawanGameDataUIData);
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
                // seirawanGameDataUIData
                if (data is SeirawanGameDataUI.UIData)
                {
                    // SeirawanGameDataUI.UIData seirawanGameDataUIData = data as SeirawanGameDataUI.UIData;
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
                    // HintUI
                    {
                        if (data is HintUI.UIData)
                        {
                            HintUI.UIData hintUIData = data as HintUI.UIData;
                            {
                                hintUIData.state.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // State
                        if (data is HintUI.UIData.State)
                        {
                            HintUI.UIData.State state = data as HintUI.UIData.State;
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
                                            ShowUI.UIData showUIData = state as ShowUI.UIData;
                                            showUIData.hintMove.allRemoveCallBack(this);
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                        break;
                                }
                            }
                            return;
                        }
                        if (data is GameMove)
                        {
                            // GameMove gameMove = data as GameMove;
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
                    {
                        switch (sub.getType())
                        {
                            case GameMove.Type.SeirawanMove:
                                {
                                    SeirawanMoveUI.UIData seirawanMoveUIData = sub as SeirawanMoveUI.UIData;
                                    seirawanMoveUIData.removeCallBackAndDestroy(typeof(SeirawanMoveUI));
                                }
                                break;
                            case GameMove.Type.SeirawanCustomSet:
                                {
                                    SeirawanCustomSetUI.UIData seirawanCustomSetUIData = sub as SeirawanCustomSetUI.UIData;
                                    seirawanCustomSetUIData.removeCallBackAndDestroy(typeof(SeirawanCustomSetUI));
                                }
                                break;
                            case GameMove.Type.SeirawanCustomMove:
                                {
                                    SeirawanCustomMoveUI.UIData seirawanCustomMoveUIData = sub as SeirawanCustomMoveUI.UIData;
                                    seirawanCustomMoveUIData.removeCallBackAndDestroy(typeof(SeirawanCustomMoveUI));
                                }
                                break;
                            case GameMove.Type.SeirawanCustomHand:
                                {
                                    SeirawanCustomHandUI.UIData seirawanCustomHandUIData = sub as SeirawanCustomHandUI.UIData;
                                    seirawanCustomHandUIData.removeCallBackAndDestroy(typeof(SeirawanCustomHandUI));
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
                        Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Parent
            {
                // seirawanGameDataUIData
                if (wrapProperty.p is SeirawanGameDataUI.UIData)
                {
                    switch ((SeirawanGameDataUI.UIData.Property)wrapProperty.n)
                    {
                        case SeirawanGameDataUI.UIData.Property.gameData:
                            break;
                        case SeirawanGameDataUI.UIData.Property.isOnAnimation:
                            dirty = true;
                            break;
                        case SeirawanGameDataUI.UIData.Property.board:
                            break;
                        case SeirawanGameDataUI.UIData.Property.lastMove:
                            break;
                        default:
                            Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
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
                                Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // HintUI
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
                                    Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // State
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
                                                    {
                                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                                        dirty = true;
                                                    }
                                                    break;
                                                default:
                                                    Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
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
                        if (wrapProperty.p is GameMove)
                        {
                            return;
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
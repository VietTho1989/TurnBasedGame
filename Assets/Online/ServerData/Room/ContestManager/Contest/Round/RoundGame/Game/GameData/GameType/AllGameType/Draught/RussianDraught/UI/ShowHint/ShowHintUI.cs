using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hint;
using RussianDraught.NoneRule;

namespace RussianDraught
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
                        RussianDraughtGameDataUI.UIData russianDraughtGameDataUIData = this.data.findDataInParent<RussianDraughtGameDataUI.UIData>();
                        if (russianDraughtGameDataUIData != null)
                        {
                            if (!russianDraughtGameDataUIData.isOnAnimation.v)
                            {
                                canShowHint = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("russianDraughtGameDataUIData null: " + this);
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
                                case GameMove.Type.RussianDraughtMove:
                                    {
                                        RussianDraughtMove russianDraughtMove = hintMove as RussianDraughtMove;
                                        // Find
                                        RussianDraughtMoveUI.UIData russianDraughtMoveUIData = this.data.sub.newOrOld<RussianDraughtMoveUI.UIData>();
                                        {
                                            // move
                                            russianDraughtMoveUIData.russianDraughtMove.v = new ReferenceData<RussianDraughtMove>(russianDraughtMove);
                                            // isHint
                                            russianDraughtMoveUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = russianDraughtMoveUIData;
                                    }
                                    break;
                                case GameMove.Type.RussianDraughtCustomSet:
                                    {
                                        RussianDraughtCustomSet russianDraughtCustomSet = hintMove as RussianDraughtCustomSet;
                                        // Find
                                        RussianDraughtCustomSetUI.UIData russianDraughtCustomSetUIData = this.data.sub.newOrOld<RussianDraughtCustomSetUI.UIData>();
                                        {
                                            // move
                                            russianDraughtCustomSetUIData.russianDraughtCustomSet.v = new ReferenceData<RussianDraughtCustomSet>(russianDraughtCustomSet);
                                            // isHint
                                            russianDraughtCustomSetUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = russianDraughtCustomSetUIData;
                                    }
                                    break;
                                case GameMove.Type.RussianDraughtCustomMove:
                                    {
                                        RussianDraughtCustomMove russianDraughtCustomMove = hintMove as RussianDraughtCustomMove;
                                        // Find
                                        RussianDraughtCustomMoveUI.UIData russianDraughtCustomMoveUIData = this.data.sub.newOrOld<RussianDraughtCustomMoveUI.UIData>();
                                        {
                                            // move
                                            russianDraughtCustomMoveUIData.russianDraughtCustomMove.v = new ReferenceData<RussianDraughtCustomMove>(russianDraughtCustomMove);
                                            // isHint
                                            russianDraughtCustomMoveUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = russianDraughtCustomMoveUIData;
                                    }
                                    break;
                                case GameMove.Type.RussianDraughtCustomFen:
                                    {
                                        RussianDraughtCustomFen russianDraughtCustomFen = hintMove as RussianDraughtCustomFen;
                                        // Find
                                        RussianDraughtCustomFenUI.UIData russianDraughtCustomFenUIData = this.data.sub.newOrOld<RussianDraughtCustomFenUI.UIData>();
                                        {
                                            // move
                                            russianDraughtCustomFenUIData.russianDraughtCustomFen.v = new ReferenceData<RussianDraughtCustomFen>(russianDraughtCustomFen);
                                            // isHint
                                            russianDraughtCustomFenUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = russianDraughtCustomFenUIData;
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

        public RussianDraughtMoveUI russianDraughtMovePrefab;
        public RussianDraughtCustomSetUI russianDraughtCustomSetPrefab;
        public RussianDraughtCustomMoveUI russianDraughtCustomMovePrefab;
        public RussianDraughtCustomFenUI russianDraughtCustomFenPrefab;

        private RussianDraughtGameDataUI.UIData russianDraughtGameDataUIData = null;
        private GameDataUI.UIData gameDataUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.russianDraughtGameDataUIData);
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
                // russianDraughtGameDataUIData
                if (data is RussianDraughtGameDataUI.UIData)
                {
                    // RussianDraughtGameDataUI.UIData russianDraughtGameDataUIData = data as RussianDraughtGameDataUI.UIData;
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
                            case GameMove.Type.RussianDraughtMove:
                                {
                                    RussianDraughtMoveUI.UIData russianDraughtMoveUIData = sub as RussianDraughtMoveUI.UIData;
                                    UIUtils.Instantiate(russianDraughtMoveUIData, russianDraughtMovePrefab, this.transform);
                                }
                                break;
                            case GameMove.Type.RussianDraughtCustomSet:
                                {
                                    RussianDraughtCustomSetUI.UIData russianDraughtCustomSetUIData = sub as RussianDraughtCustomSetUI.UIData;
                                    UIUtils.Instantiate(russianDraughtCustomSetUIData, russianDraughtCustomSetPrefab, this.transform);
                                }
                                break;
                            case GameMove.Type.RussianDraughtCustomMove:
                                {
                                    RussianDraughtCustomMoveUI.UIData russianDraughtCustomMoveUIData = sub as RussianDraughtCustomMoveUI.UIData;
                                    UIUtils.Instantiate(russianDraughtCustomMoveUIData, russianDraughtCustomMovePrefab, this.transform);
                                }
                                break;
                            case GameMove.Type.RussianDraughtCustomFen:
                                {
                                    RussianDraughtCustomFenUI.UIData russianDraughtCustomFenUIData = sub as RussianDraughtCustomFenUI.UIData;
                                    UIUtils.Instantiate(russianDraughtCustomFenUIData, russianDraughtCustomFenPrefab, this.transform);
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.russianDraughtGameDataUIData);
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
                // russianDraughtGameDataUIData
                if (data is RussianDraughtGameDataUI.UIData)
                {
                    // RussianDraughtGameDataUI.UIData russianDraughtGameDataUIData = data as RussianDraughtGameDataUI.UIData;
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
                            // Child
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
                            case GameMove.Type.RussianDraughtMove:
                                {
                                    RussianDraughtMoveUI.UIData russianDraughtMoveUIData = sub as RussianDraughtMoveUI.UIData;
                                    russianDraughtMoveUIData.removeCallBackAndDestroy(typeof(RussianDraughtMoveUI));
                                }
                                break;
                            case GameMove.Type.RussianDraughtCustomSet:
                                {
                                    RussianDraughtCustomSetUI.UIData russianDraughtCustomSetUIData = sub as RussianDraughtCustomSetUI.UIData;
                                    russianDraughtCustomSetUIData.removeCallBackAndDestroy(typeof(RussianDraughtCustomSetUI));
                                }
                                break;
                            case GameMove.Type.RussianDraughtCustomMove:
                                {
                                    RussianDraughtCustomMoveUI.UIData russianDraughtCustomMoveUIData = sub as RussianDraughtCustomMoveUI.UIData;
                                    russianDraughtCustomMoveUIData.removeCallBackAndDestroy(typeof(RussianDraughtCustomMoveUI));
                                }
                                break;
                            case GameMove.Type.RussianDraughtCustomFen:
                                {
                                    RussianDraughtCustomFenUI.UIData russianDraughtCustomFenUIData = sub as RussianDraughtCustomFenUI.UIData;
                                    russianDraughtCustomFenUIData.removeCallBackAndDestroy(typeof(RussianDraughtCustomFenUI));
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
                // russianDraughtGameDataUIData
                if (wrapProperty.p is RussianDraughtGameDataUI.UIData)
                {
                    switch ((RussianDraughtGameDataUI.UIData.Property)wrapProperty.n)
                    {
                        case RussianDraughtGameDataUI.UIData.Property.gameData:
                            break;
                        case RussianDraughtGameDataUI.UIData.Property.board:
                            break;
                        case RussianDraughtGameDataUI.UIData.Property.isOnAnimation:
                            dirty = true;
                            break;
                        case RussianDraughtGameDataUI.UIData.Property.lastMove:
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
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
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
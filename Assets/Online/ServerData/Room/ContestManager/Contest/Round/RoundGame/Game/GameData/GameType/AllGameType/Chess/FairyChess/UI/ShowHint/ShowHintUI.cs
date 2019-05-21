using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hint;
using FairyChess.NoneRule;

namespace FairyChess
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
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.FairyChess ? 1 : 0;
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
                        FairyChessGameDataUI.UIData fairyChessGameDataUIData = this.data.findDataInParent<FairyChessGameDataUI.UIData>();
                        if (fairyChessGameDataUIData != null)
                        {
                            if (!fairyChessGameDataUIData.isOnAnimation.v)
                            {
                                canShowHint = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("fairyChessGameDataUIData null: " + this);
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
                                case GameMove.Type.FairyChessMove:
                                    {
                                        FairyChessMove fairyChessMove = hintMove as FairyChessMove;
                                        // Find
                                        FairyChessMoveUI.UIData fairyChessMoveUIData = this.data.sub.newOrOld<FairyChessMoveUI.UIData>();
                                        {
                                            // move
                                            fairyChessMoveUIData.fairyChessMove.v = new ReferenceData<FairyChessMove>(fairyChessMove);
                                            // isHint
                                            fairyChessMoveUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = fairyChessMoveUIData;
                                    }
                                    break;
                                case GameMove.Type.FairyChessCustomSet:
                                    {
                                        FairyChessCustomSet fairyChessCustomSet = hintMove as FairyChessCustomSet;
                                        // Find
                                        FairyChessCustomSetUI.UIData fairyChessCustomSetUIData = this.data.sub.newOrOld<FairyChessCustomSetUI.UIData>();
                                        {
                                            // move
                                            fairyChessCustomSetUIData.fairyChessCustomSet.v = new ReferenceData<FairyChessCustomSet>(fairyChessCustomSet);
                                            // isHint
                                            fairyChessCustomSetUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = fairyChessCustomSetUIData;
                                    }
                                    break;
                                case GameMove.Type.FairyChessCustomMove:
                                    {
                                        FairyChessCustomMove fairyChessCustomMove = hintMove as FairyChessCustomMove;
                                        // Find
                                        FairyChessCustomMoveUI.UIData fairyChessCustomMoveUIData = this.data.sub.newOrOld<FairyChessCustomMoveUI.UIData>();
                                        {
                                            // move
                                            fairyChessCustomMoveUIData.fairyChessCustomMove.v = new ReferenceData<FairyChessCustomMove>(fairyChessCustomMove);
                                            // isHint
                                            fairyChessCustomMoveUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = fairyChessCustomMoveUIData;
                                    }
                                    break;
                                case GameMove.Type.FairyChessCustomHand:
                                    {
                                        FairyChessCustomHand fairyChessCustomHand = hintMove as FairyChessCustomHand;
                                        // Find
                                        FairyChessCustomHandUI.UIData fairyChessCustomHandUIData = this.data.sub.newOrOld<FairyChessCustomHandUI.UIData>();
                                        {
                                            // move
                                            fairyChessCustomHandUIData.fairyChessCustomHand.v = new ReferenceData<FairyChessCustomHand>(fairyChessCustomHand);
                                            // isHint
                                            fairyChessCustomHandUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = fairyChessCustomHandUIData;
                                    }
                                    break;
                                case GameMove.Type.FairyChessCustomFen:
                                    {
                                        FairyChessCustomFen fairyChessCustomFen = hintMove as FairyChessCustomFen;
                                        // Find
                                        FairyChessCustomFenUI.UIData fairyChessCustomFenUIData = this.data.sub.newOrOld<FairyChessCustomFenUI.UIData>();
                                        {
                                            // move
                                            fairyChessCustomFenUIData.fairyChessCustomFen.v = new ReferenceData<FairyChessCustomFen>(fairyChessCustomFen);
                                            // isHint
                                            fairyChessCustomFenUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = fairyChessCustomFenUIData;
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

        public FairyChessMoveUI fairyChessMovePrefab;
        public FairyChessCustomSetUI fairyChessCustomSetPrefab;
        public FairyChessCustomMoveUI fairyChessCustomMovePrefab;
        public FairyChessCustomHandUI fairyChessCustomHandPrefab;
        public FairyChessCustomFenUI fairyChessCustomFenPrefab;

        private FairyChessGameDataUI.UIData fairyChessGameDataUIData = null;
        private GameDataUI.UIData gameDataUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.fairyChessGameDataUIData);
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
                // fairyChessGameDataUIData
                if (data is FairyChessGameDataUI.UIData)
                {
                    // FairyChessGameDataUI.UIData fairyChessGameDataUIData = data as FairyChessGameDataUI.UIData;
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
                            case GameMove.Type.FairyChessMove:
                                {
                                    FairyChessMoveUI.UIData fairyChessMoveUIData = sub as FairyChessMoveUI.UIData;
                                    UIUtils.Instantiate(fairyChessMoveUIData, fairyChessMovePrefab, this.transform);
                                }
                                break;
                            case GameMove.Type.FairyChessCustomSet:
                                {
                                    FairyChessCustomSetUI.UIData fairyChessCustomSetUIData = sub as FairyChessCustomSetUI.UIData;
                                    UIUtils.Instantiate(fairyChessCustomSetUIData, fairyChessCustomSetPrefab, this.transform);
                                }
                                break;
                            case GameMove.Type.FairyChessCustomMove:
                                {
                                    FairyChessCustomMoveUI.UIData fairyChessCustomMoveUIData = sub as FairyChessCustomMoveUI.UIData;
                                    UIUtils.Instantiate(fairyChessCustomMoveUIData, fairyChessCustomMovePrefab, this.transform);
                                }
                                break;
                            case GameMove.Type.FairyChessCustomHand:
                                {
                                    FairyChessCustomHandUI.UIData fairyChessCustomHandUIData = sub as FairyChessCustomHandUI.UIData;
                                    UIUtils.Instantiate(fairyChessCustomHandUIData, fairyChessCustomHandPrefab, this.transform);
                                }
                                break;
                            case GameMove.Type.FairyChessCustomFen:
                                {
                                    FairyChessCustomFenUI.UIData fairyChessCustomFenUIData = sub as FairyChessCustomFenUI.UIData;
                                    UIUtils.Instantiate(fairyChessCustomFenUIData, fairyChessCustomFenPrefab, this.transform);
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.fairyChessGameDataUIData);
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
                // fairyChessGameDataUIData
                if (data is FairyChessGameDataUI.UIData)
                {
                    // FairyChessGameDataUI.UIData fairyChessGameDataUIData = data as FairyChessGameDataUI.UIData;
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
                            case GameMove.Type.FairyChessMove:
                                {
                                    FairyChessMoveUI.UIData fairyChessMoveUIData = sub as FairyChessMoveUI.UIData;
                                    fairyChessMoveUIData.removeCallBackAndDestroy(typeof(FairyChessMoveUI));
                                }
                                break;
                            case GameMove.Type.FairyChessCustomSet:
                                {
                                    FairyChessCustomSetUI.UIData fairyChessCustomSetUIData = sub as FairyChessCustomSetUI.UIData;
                                    fairyChessCustomSetUIData.removeCallBackAndDestroy(typeof(FairyChessCustomSetUI));
                                }
                                break;
                            case GameMove.Type.FairyChessCustomMove:
                                {
                                    FairyChessCustomMoveUI.UIData fairyChessCustomMoveUIData = sub as FairyChessCustomMoveUI.UIData;
                                    fairyChessCustomMoveUIData.removeCallBackAndDestroy(typeof(FairyChessCustomMoveUI));
                                }
                                break;
                            case GameMove.Type.FairyChessCustomHand:
                                {
                                    FairyChessCustomHandUI.UIData fairyChessCustomHandUIData = sub as FairyChessCustomHandUI.UIData;
                                    fairyChessCustomHandUIData.removeCallBackAndDestroy(typeof(FairyChessCustomHandUI));
                                }
                                break;
                            case GameMove.Type.FairyChessCustomFen:
                                {
                                    FairyChessCustomFenUI.UIData fairyChessCustomFenUIData = sub as FairyChessCustomFenUI.UIData;
                                    fairyChessCustomFenUIData.removeCallBackAndDestroy(typeof(FairyChessCustomFenUI));
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
                // fairyChessGameDataUIData
                if (wrapProperty.p is FairyChessGameDataUI.UIData)
                {
                    switch ((FairyChessGameDataUI.UIData.Property)wrapProperty.n)
                    {
                        case FairyChessGameDataUI.UIData.Property.gameData:
                            break;
                        case FairyChessGameDataUI.UIData.Property.isOnAnimation:
                            dirty = true;
                            break;
                        case FairyChessGameDataUI.UIData.Property.board:
                            break;
                        case FairyChessGameDataUI.UIData.Property.lastMove:
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
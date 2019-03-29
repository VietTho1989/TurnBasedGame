using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Hint;
using Shatranj.NoneRule;

namespace Shatranj
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
                        ShatranjGameDataUI.UIData shatranjGameDataUIData = this.data.findDataInParent<ShatranjGameDataUI.UIData>();
                        if (shatranjGameDataUIData != null)
                        {
                            if (!shatranjGameDataUIData.isOnAnimation.v)
                            {
                                canShowHint = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("shatranjGameDataUIData null: " + this);
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
                                case GameMove.Type.ShatranjMove:
                                    {
                                        ShatranjMove shatranjMove = hintMove as ShatranjMove;
                                        // Find
                                        ShatranjMoveUI.UIData shatranjMoveUIData = this.data.sub.newOrOld<ShatranjMoveUI.UIData>();
                                        {
                                            // move
                                            shatranjMoveUIData.shatranjMove.v = new ReferenceData<ShatranjMove>(shatranjMove);
                                            // isHint
                                            shatranjMoveUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = shatranjMoveUIData;
                                    }
                                    break;
                                case GameMove.Type.ShatranjCustomSet:
                                    {
                                        ShatranjCustomSet shatranjCustomSet = hintMove as ShatranjCustomSet;
                                        // Find
                                        ShatranjCustomSetUI.UIData shatranjCustomSetUIData = this.data.sub.newOrOld<ShatranjCustomSetUI.UIData>();
                                        {
                                            // move
                                            shatranjCustomSetUIData.shatranjCustomSet.v = new ReferenceData<ShatranjCustomSet>(shatranjCustomSet);
                                            // isHint
                                            shatranjCustomSetUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = shatranjCustomSetUIData;
                                    }
                                    break;
                                case GameMove.Type.ShatranjCustomMove:
                                    {
                                        ShatranjCustomMove shatranjCustomMove = hintMove as ShatranjCustomMove;
                                        // Find
                                        ShatranjCustomMoveUI.UIData shatranjCustomMoveUIData = this.data.sub.newOrOld<ShatranjCustomMoveUI.UIData>();
                                        {
                                            // move
                                            shatranjCustomMoveUIData.shatranjCustomMove.v = new ReferenceData<ShatranjCustomMove>(shatranjCustomMove);
                                            // isHint
                                            shatranjCustomMoveUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = shatranjCustomMoveUIData;
                                    }
                                    break;
                                case GameMove.Type.ShatranjCustomFen:
                                    {
                                        ShatranjCustomFen shatranjCustomFen = hintMove as ShatranjCustomFen;
                                        // Find
                                        ShatranjCustomFenUI.UIData shatranjCustomFenUIData = this.data.sub.newOrOld<ShatranjCustomFenUI.UIData>();
                                        {
                                            // move
                                            shatranjCustomFenUIData.shatranjCustomFen.v = new ReferenceData<ShatranjCustomFen>(shatranjCustomFen);
                                            // isHint
                                            shatranjCustomFenUIData.isHint.v = true;
                                        }
                                        this.data.sub.v = shatranjCustomFenUIData;
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

        public ShatranjMoveUI shatranjMovePrefab;
        public ShatranjCustomSetUI shatranjCustomSetPrefab;
        public ShatranjCustomMoveUI shatranjCustomMovePrefab;
        public ShatranjCustomFenUI shatranjCustomFenPrefab;

        private ShatranjGameDataUI.UIData shatranjGameDataUIData = null;
        private GameDataUI.UIData gameDataUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.shatranjGameDataUIData);
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
                // shatranjGameDataUIData
                if (data is ShatranjGameDataUI.UIData)
                {
                    // ShatranjGameDataUI.UIData shatranjGameDataUIData = data as ShatranjGameDataUI.UIData;
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
                            case GameMove.Type.ShatranjMove:
                                {
                                    ShatranjMoveUI.UIData shatranjMoveUIData = sub as ShatranjMoveUI.UIData;
                                    UIUtils.Instantiate(shatranjMoveUIData, shatranjMovePrefab, this.transform);
                                }
                                break;
                            case GameMove.Type.ShatranjCustomSet:
                                {
                                    ShatranjCustomSetUI.UIData shatranjCustomSetUIData = sub as ShatranjCustomSetUI.UIData;
                                    UIUtils.Instantiate(shatranjCustomSetUIData, shatranjCustomSetPrefab, this.transform);
                                }
                                break;
                            case GameMove.Type.ShatranjCustomMove:
                                {
                                    ShatranjCustomMoveUI.UIData shatranjCustomMoveUIData = sub as ShatranjCustomMoveUI.UIData;
                                    UIUtils.Instantiate(shatranjCustomMoveUIData, shatranjCustomMovePrefab, this.transform);
                                }
                                break;
                            case GameMove.Type.ShatranjCustomFen:
                                {
                                    ShatranjCustomFenUI.UIData shatranjCustomFenUIData = sub as ShatranjCustomFenUI.UIData;
                                    UIUtils.Instantiate(shatranjCustomFenUIData, shatranjCustomFenPrefab, this.transform);
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.shatranjGameDataUIData);
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
                // shatranjGameDataUIData
                if (data is ShatranjGameDataUI.UIData)
                {
                    // ShatranjGameDataUI.UIData shatranjGameDataUIData = data as ShatranjGameDataUI.UIData;
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
                            case GameMove.Type.ShatranjMove:
                                {
                                    ShatranjMoveUI.UIData shatranjMoveUIData = sub as ShatranjMoveUI.UIData;
                                    shatranjMoveUIData.removeCallBackAndDestroy(typeof(ShatranjMoveUI));
                                }
                                break;
                            case GameMove.Type.ShatranjCustomSet:
                                {
                                    ShatranjCustomSetUI.UIData shatranjCustomSetUIData = sub as ShatranjCustomSetUI.UIData;
                                    shatranjCustomSetUIData.removeCallBackAndDestroy(typeof(ShatranjCustomSetUI));
                                }
                                break;
                            case GameMove.Type.ShatranjCustomMove:
                                {
                                    ShatranjCustomMoveUI.UIData shatranjCustomMoveUIData = sub as ShatranjCustomMoveUI.UIData;
                                    shatranjCustomMoveUIData.removeCallBackAndDestroy(typeof(ShatranjCustomMoveUI));
                                }
                                break;
                            case GameMove.Type.ShatranjCustomFen:
                                {
                                    ShatranjCustomFenUI.UIData shatranjCustomFenUIData = sub as ShatranjCustomFenUI.UIData;
                                    shatranjCustomFenUIData.removeCallBackAndDestroy(typeof(ShatranjCustomFenUI));
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
                // shatranjGameDataUIData
                if (wrapProperty.p is ShatranjGameDataUI.UIData)
                {
                    switch ((ShatranjGameDataUI.UIData.Property)wrapProperty.n)
                    {
                        case ShatranjGameDataUI.UIData.Property.gameData:
                            break;
                        case ShatranjGameDataUI.UIData.Property.isOnAnimation:
                            dirty = true;
                            break;
                        case ShatranjGameDataUI.UIData.Property.board:
                            break;
                        case ShatranjGameDataUI.UIData.Property.lastMove:
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
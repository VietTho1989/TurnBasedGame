using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
    public class CardLastMoveUI : UIBehavior<CardLastMoveUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            #region Constructor

            public enum Property
            {

            }

            public UIData() : base()
            {

            }

            #endregion

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Solitaire ? 10 : 0;
        }

        #region Refresh

        public Image imgLastMove;
        public GameObject flipIndicator;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // find last move
                    GameMove gameMove = null;
                    {
                        SolitaireGameDataUI.UIData solitaireGameDataUIData = this.data.findDataInParent<SolitaireGameDataUI.UIData>();
                        if (solitaireGameDataUIData != null)
                        {
                            LastMoveUI.UIData lastMoveUIData = solitaireGameDataUIData.lastMove.v;
                            if (lastMoveUIData != null)
                            {
                                LastMoveSub lastMoveSub = lastMoveUIData.sub.v;
                                if (lastMoveSub != null)
                                {
                                    switch (lastMoveSub.getType())
                                    {
                                        case GameMove.Type.SolitaireMove:
                                            {
                                                SolitaireMoveUI.UIData solitaireMoveUIData = lastMoveSub as SolitaireMoveUI.UIData;
                                                gameMove = solitaireMoveUIData.solitaireMove.v.data;
                                            }
                                            break;
                                        case GameMove.Type.SolitaireReset:
                                            break;
                                        case GameMove.Type.None:
                                            break;
                                        default:
                                            Debug.LogError("unknown move: " + lastMoveSub.getType());
                                            break;
                                    }
                                }
                                else
                                {
                                    // Debug.LogError ("lastMoveSub null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("lastMoveUIData null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("solitaireGameDataUIData null: " + this);
                        }
                    }
                    // imgLastMove
                    {
                        if (imgLastMove != null)
                        {
                            if (gameMove != null)
                            {
                                switch (gameMove.getType())
                                {
                                    case GameMove.Type.SolitaireMove:
                                        {
                                            SolitaireMove solitaireMove = gameMove as SolitaireMove;
                                            // find isShow
                                            bool isShow = false;
                                            {
                                                if (solitaireMove.From.v != solitaireMove.To.v)
                                                {
                                                    PileUI.UIData pileUIData = this.data.findDataInParent<PileUI.UIData>();
                                                    if (pileUIData != null)
                                                    {
                                                        if (pileUIData.pileIndex.v == solitaireMove.To.v)
                                                        {
                                                            CardUI.UIData cardUIData = this.data.findDataInParent<CardUI.UIData>();
                                                            if (cardUIData != null)
                                                            {
                                                                if (pileUIData.cards.vs.Count - cardUIData.cardIndex.v <= solitaireMove.Count.v)
                                                                {
                                                                    isShow = true;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Debug.LogError("cardUIData null: " + this);
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("pileUIData null: " + this);
                                                    }
                                                }
                                                else
                                                {
                                                    // Debug.LogError ("the same from, to: " + solitaireMove.print ());
                                                }
                                            }
                                            // process
                                            imgLastMove.enabled = isShow;
                                        }
                                        break;
                                    case GameMove.Type.None:
                                        imgLastMove.enabled = false;
                                        break;
                                    default:
                                        Debug.LogError("unknown move type: " + gameMove.getType());
                                        imgLastMove.enabled = false;
                                        break;
                                }
                            }
                            else
                            {
                                // Debug.LogError ("gameMove null: " + this);
                                imgLastMove.enabled = false;
                            }
                        }
                        else
                        {
                            Debug.LogError("imgLastMove null: " + this);
                        }
                    }
                    // flipIndicator
                    {
                        if (flipIndicator != null)
                        {
                            if (gameMove != null)
                            {
                                switch (gameMove.getType())
                                {
                                    case GameMove.Type.SolitaireMove:
                                        {
                                            SolitaireMove solitaireMove = gameMove as SolitaireMove;
                                            // find isFlip
                                            bool isFlip = false;
                                            {
                                                if (solitaireMove.Extra.v > 0)
                                                {
                                                    if ((Pile.Piles)solitaireMove.From.v != Pile.Piles.WASTE)
                                                    {
                                                        PileUI.UIData pileUIData = this.data.findDataInParent<PileUI.UIData>();
                                                        if (pileUIData != null)
                                                        {
                                                            if (pileUIData.pileIndex.v == solitaireMove.From.v)
                                                            {
                                                                CardUI.UIData cardUIData = this.data.findDataInParent<CardUI.UIData>();
                                                                if (cardUIData != null)
                                                                {
                                                                    if (cardUIData.cardIndex.v == pileUIData.cards.vs.Count - 1)
                                                                    {
                                                                        isFlip = true;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Debug.LogError("cardUIData null: " + this);
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("pileUIData null: " + this);
                                                        }
                                                    }
                                                }
                                            }
                                            // set
                                            flipIndicator.SetActive(isFlip);
                                        }
                                        break;
                                    case GameMove.Type.None:
                                        flipIndicator.SetActive(false);
                                        break;
                                    default:
                                        Debug.LogError("unknown gameMove: " + gameMove.getType());
                                        flipIndicator.SetActive(false);
                                        break;
                                }
                            }
                            else
                            {
                                flipIndicator.SetActive(false);
                            }
                        }
                        else
                        {
                            Debug.LogError("FlipIndicator null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        private PileUI.UIData pileUIData = null;
        private CardUI.UIData cardUIData = null;
        private SolitaireGameDataUI.UIData solitaireGameDataUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.pileUIData);
                    DataUtils.addParentCallBack(uiData, this, ref this.cardUIData);
                    DataUtils.addParentCallBack(uiData, this, ref this.solitaireGameDataUIData);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is PileUI.UIData)
                {
                    dirty = true;
                    return;
                }
                if (data is CardUI.UIData)
                {
                    dirty = true;
                    return;
                }
                // solitaireGameDataUIData
                {
                    if (data is SolitaireGameDataUI.UIData)
                    {
                        SolitaireGameDataUI.UIData solitaireGameDataUIData = data as SolitaireGameDataUI.UIData;
                        // Child
                        {
                            solitaireGameDataUIData.lastMove.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is LastMoveUI.UIData)
                        {
                            LastMoveUI.UIData lastMoveUIData = data as LastMoveUI.UIData;
                            // Child
                            {
                                lastMoveUIData.sub.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        {
                            if (data is LastMoveSub)
                            {
                                LastMoveSub lastMoveSub = data as LastMoveSub;
                                // Child
                                {
                                    switch (lastMoveSub.getType())
                                    {
                                        case GameMove.Type.SolitaireMove:
                                            {
                                                SolitaireMoveUI.UIData solitaireMoveUIData = lastMoveSub as SolitaireMoveUI.UIData;
                                                solitaireMoveUIData.solitaireMove.allAddCallBack(this);
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + lastMoveSub.getType() + "; " + this);
                                            break;
                                    }
                                }
                                dirty = true;
                                return;
                            }
                            // Child
                            if (data is SolitaireMove)
                            {
                                dirty = true;
                                return;
                            }
                        }
                    }
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.pileUIData);
                    DataUtils.removeParentCallBack(uiData, this, ref this.cardUIData);
                    DataUtils.removeParentCallBack(uiData, this, ref this.solitaireGameDataUIData);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                if (data is PileUI.UIData)
                {
                    return;
                }
                if (data is CardUI.UIData)
                {
                    return;
                }
                // solitaireGameDataUIData
                {
                    if (data is SolitaireGameDataUI.UIData)
                    {
                        SolitaireGameDataUI.UIData solitaireGameDataUIData = data as SolitaireGameDataUI.UIData;
                        // Child
                        {
                            solitaireGameDataUIData.lastMove.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is LastMoveUI.UIData)
                        {
                            LastMoveUI.UIData lastMoveUIData = data as LastMoveUI.UIData;
                            // Child
                            {
                                lastMoveUIData.sub.allRemoveCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        {
                            if (data is LastMoveSub)
                            {
                                LastMoveSub lastMoveSub = data as LastMoveSub;
                                // Child
                                {
                                    switch (lastMoveSub.getType())
                                    {
                                        case GameMove.Type.SolitaireMove:
                                            {
                                                SolitaireMoveUI.UIData solitaireMoveUIData = lastMoveSub as SolitaireMoveUI.UIData;
                                                solitaireMoveUIData.solitaireMove.allRemoveCallBack(this);
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + lastMoveSub.getType() + "; " + this);
                                            break;
                                    }
                                }
                                return;
                            }
                            // Child
                            if (data is SolitaireMove)
                            {
                                return;
                            }
                        }
                    }
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
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Parent
            {
                if (wrapProperty.p is PileUI.UIData)
                {
                    switch ((PileUI.UIData.Property)wrapProperty.n)
                    {
                        case PileUI.UIData.Property.pile:
                            break;
                        case PileUI.UIData.Property.pileIndex:
                            dirty = true;
                            break;
                        case PileUI.UIData.Property.cards:
                            break;
                        case PileUI.UIData.Property.pileLastMoveUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is CardUI.UIData)
                {
                    switch ((CardUI.UIData.Property)wrapProperty.n)
                    {
                        case CardUI.UIData.Property.card:
                            break;
                        case CardUI.UIData.Property.cardIndex:
                            dirty = true;
                            break;
                        case CardUI.UIData.Property.isDown:
                            break;
                        case CardUI.UIData.Property.cardLastMoveUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // solitaireGameDataUIData
                {
                    if (wrapProperty.p is SolitaireGameDataUI.UIData)
                    {
                        switch ((SolitaireGameDataUI.UIData.Property)wrapProperty.n)
                        {
                            case SolitaireGameDataUI.UIData.Property.gameData:
                                break;
                            case SolitaireGameDataUI.UIData.Property.transformOrganizer:
                                break;
                            case SolitaireGameDataUI.UIData.Property.isOnAnimation:
                                break;
                            case SolitaireGameDataUI.UIData.Property.board:
                                break;
                            case SolitaireGameDataUI.UIData.Property.lastMove:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case SolitaireGameDataUI.UIData.Property.showHint:
                                break;
                            case SolitaireGameDataUI.UIData.Property.inputUI:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is LastMoveUI.UIData)
                        {
                            switch ((LastMoveUI.UIData.Property)wrapProperty.n)
                            {
                                case LastMoveUI.UIData.Property.gameData:
                                    break;
                                case LastMoveUI.UIData.Property.sub:
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
                            if (wrapProperty.p is LastMoveSub)
                            {
                                LastMoveSub lastMoveSub = wrapProperty.p as LastMoveSub;
                                // Child
                                {
                                    switch (lastMoveSub.getType())
                                    {
                                        case GameMove.Type.SolitaireMove:
                                            {
                                                switch ((SolitaireMoveUI.UIData.Property)wrapProperty.n)
                                                {
                                                    case SolitaireMoveUI.UIData.Property.solitaireMove:
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
                                            Debug.LogError("unknown type: " + lastMoveSub.getType() + "; " + this);
                                            break;
                                    }
                                }
                                return;
                            }
                            // Child
                            if (wrapProperty.p is SolitaireMove)
                            {
                                switch ((SolitaireMove.Property)wrapProperty.n)
                                {
                                    case SolitaireMove.Property.From:
                                        dirty = true;
                                        break;
                                    case SolitaireMove.Property.To:
                                        dirty = true;
                                        break;
                                    case SolitaireMove.Property.Count:
                                        dirty = true;
                                        break;
                                    case SolitaireMove.Property.Extra:
                                        dirty = true;
                                        break;
                                    default:
                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                        break;
                                }
                                return;
                            }
                        }
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
    public class UseRuleInputUI : UIBehavior<UseRuleInputUI.UIData>
    {

        #region UIData

        public class UIData : InputUI.UIData.Sub
        {

            public VP<ReferenceData<Solitaire>> solitaire;

            #region Sub

            public abstract class Sub : Data
            {

                public enum Type
                {
                    None,
                    Card
                }

                public abstract Type getType();

                public abstract bool processEvent(Event e);

                public abstract void onClickCard(Card card);

                public abstract void onClickPile(Pile pile);

            }

            public VP<Sub> sub;

            #endregion

            #region Constructor

            public enum Property
            {
                solitaire,
                sub
            }

            public UIData() : base()
            {
                this.solitaire = new VP<ReferenceData<Solitaire>>(this, (byte)Property.solitaire, new ReferenceData<Solitaire>(null));
                this.sub = new VP<Sub>(this, (byte)Property.sub, new UseRuleInputNoneUI.UIData());
            }

            #endregion

            public override Type getType()
            {
                return Type.UseRule;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {

                }
                return isProcess;
            }

            public override void onClickCard(Card card)
            {
                // check is draw move
                bool isDrawMove = false;
                {
                    Solitaire solitaire = this.solitaire.v.data;
                    if (solitaire != null)
                    {
                        if (solitaire.isHaveDrawMove())
                        {
                            Pile pile = card.findDataInParent<Pile>();
                            if (pile != null)
                            {
                                Debug.LogError("onClickCard: Count: " + pile.size.v);
                                if (solitaire.piles.vs.IndexOf(pile) == (int)Pile.Piles.STOCK)
                                {
                                    isDrawMove = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("solitaire null");
                    }
                }
                // process
                if (!isDrawMove)
                {
                    Sub sub = this.sub.v;
                    if (sub != null)
                    {
                        sub.onClickCard(card);
                    }
                    else
                    {
                        Debug.LogError("sub null");
                    }
                }
                else
                {
                    sendDrawMove();
                }
            }

            public override void onClickPile(Pile pile)
            {
                // check is draw move
                bool isDrawMove = false;
                {
                    Solitaire solitaire = this.solitaire.v.data;
                    if (solitaire != null)
                    {
                        if (solitaire.isHaveDrawMove())
                        {
                            if (solitaire.piles.vs.IndexOf(pile) == (int)Pile.Piles.STOCK)
                            {
                                isDrawMove = true;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("solitaire null");
                    }
                }
                // process
                if (!isDrawMove)
                {
                    Sub sub = this.sub.v;
                    if (sub != null)
                    {
                        sub.onClickPile(pile);
                    }
                    else
                    {
                        Debug.LogError("sub null");
                    }
                }
                else
                {
                    sendDrawMove();
                }
            }

            private void sendDrawMove()
            {
                ClientInput clientInput = InputUI.UIData.findClientInput(this);
                if (clientInput != null)
                {
                    Solitaire solitaire = this.solitaire.v.data;
                    if (solitaire != null)
                    {
                        // get stock pile
                        Pile stockPile = null;
                        {
                            int pileIndex = (int)Pile.Piles.STOCK;
                            if (pileIndex >= 0 && pileIndex < solitaire.piles.vs.Count)
                            {
                                stockPile = solitaire.piles.vs[pileIndex];
                                Debug.LogError("stockPile: " + stockPile.size.v + ", " + stockPile.upSize.v + ", " + stockPile.downSize.v);
                            }
                        }
                        // get waste pile
                        Pile wastePile = null;
                        {
                            int pileIndex = (int)Pile.Piles.WASTE;
                            if (pileIndex >= 0 && pileIndex < solitaire.piles.vs.Count)
                            {
                                wastePile = solitaire.piles.vs[pileIndex];
                                Debug.LogError("wastePile: " + wastePile.size.v + ", " + wastePile.upSize.v + ", " + wastePile.downSize.v);
                            }
                        }
                        // process
                        if (stockPile != null && wastePile != null)
                        {
                            SolitaireMove drawMove = new SolitaireMove();
                            {
                                drawMove.From.v = (byte)Pile.Piles.WASTE;
                                drawMove.To.v = (byte)Pile.Piles.WASTE;
                                drawMove.Count.v = 1;
                                // extra
                                {
                                    // find drawCount
                                    int drawCount = solitaire.drawCount.v;
                                    if (drawCount <= 0)
                                    {
                                        Debug.LogError("why drawCount<=0: " + drawCount);
                                        drawCount = 1;
                                    }
                                    drawMove.Extra.v = (byte)drawCount;
                                }
                            }
                            clientInput.makeSend(drawMove);
                        }
                    }
                    else
                    {
                        Debug.LogError("solitaire null");
                    }
                }
                else
                {
                    Debug.LogError("clientInput null: " + this);
                }
            }

            public void reset()
            {
                UseRuleInputNoneUI.UIData noneUIData = this.sub.newOrOld<UseRuleInputNoneUI.UIData>();
                {

                }
                this.sub.v = noneUIData;
            }

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
                    Solitaire solitaire = this.data.solitaire.v.data;
                    if (solitaire != null)
                    {

                    }
                    else
                    {
                        Debug.LogError("solitaire null: " + this);
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

        public UseRuleInputNoneUI nonePrefab;
        public UseRuleInputCardUI cardPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.solitaire.allAddCallBack(this);
                    uiData.sub.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is Solitaire)
                {
                    // reset
                    {
                        if (this.data != null)
                        {
                            this.data.reset();
                        }
                        else
                        {
                            Debug.LogError("data null: " + this);
                        }
                    }
                    dirty = true;
                    return;
                }
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case UIData.Sub.Type.None:
                                {
                                    UseRuleInputNoneUI.UIData noneUIData = sub as UseRuleInputNoneUI.UIData;
                                    UIUtils.Instantiate(noneUIData, nonePrefab, this.transform);
                                }
                                break;
                            case UIData.Sub.Type.Card:
                                {
                                    UseRuleInputCardUI.UIData cardUIData = sub as UseRuleInputCardUI.UIData;
                                    UIUtils.Instantiate(cardUIData, cardPrefab, this.transform);
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
                // Child
                {
                    uiData.solitaire.allRemoveCallBack(this);
                    uiData.sub.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            {
                if (data is Solitaire)
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
                            case UIData.Sub.Type.None:
                                {
                                    UseRuleInputNoneUI.UIData noneUIData = sub as UseRuleInputNoneUI.UIData;
                                    noneUIData.removeCallBackAndDestroy(typeof(UseRuleInputNoneUI));
                                }
                                break;
                            case UIData.Sub.Type.Card:
                                {
                                    UseRuleInputCardUI.UIData cardUIData = sub as UseRuleInputCardUI.UIData;
                                    cardUIData.removeCallBackAndDestroy(typeof(UseRuleInputCardUI));
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
                    case UIData.Property.solitaire:
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
            // Child
            {
                if (wrapProperty.p is Solitaire)
                {
                    return;
                }
                if (wrapProperty.p is UIData.Sub)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
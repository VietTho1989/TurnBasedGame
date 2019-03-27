using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
    public class CardUI : UIBehavior<CardUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<Card>> card;

            public VP<int> cardIndex;

            public VP<bool> isDown;

            public VP<CardLastMoveUI.UIData> cardLastMoveUIData;

            #region Constructor

            public enum Property
            {
                card,
                cardIndex,
                isDown,
                cardLastMoveUIData
            }

            public UIData() : base()
            {
                this.card = new VP<ReferenceData<Card>>(this, (byte)Property.card, new ReferenceData<Card>(null));
                this.cardIndex = new VP<int>(this, (byte)Property.cardIndex, 0);
                this.isDown = new VP<bool>(this, (byte)Property.isDown, true);
                this.cardLastMoveUIData = new VP<CardLastMoveUI.UIData>(this, (byte)Property.cardLastMoveUIData, new CardLastMoveUI.UIData());
            }

            #endregion

        }

        #endregion

        #region Refresh

        public const float CardX = 4.0f;// 1.5f;
        public const float CardY = 4.0f;// 3.0f;

        public Text tvInfo;
        public GameObject faceDown;

        public Image background;

        public GameObject chooseInputCard;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Card card = this.data.card.v.data;
                    if (card != null)
                    {
                        // name
                        {
                            this.name = (Card.Cards)card.Rank.v + "" + (Card.Suits)card.Suit.v;
                        }
                        // Find MoveAnimation
                        MoveAnimation moveAnimation = null;
                        float time = 0;
                        float duration = 0;
                        {
                            GameDataBoardUI.UIData.getCurrentMoveAnimationInfo(this.data, out moveAnimation, out time, out duration);
                        }
                        // check load full
                        bool isLoadFull = true;
                        {
                            // moveAnimation
                            if (moveAnimation != null)
                            {
                                if (!moveAnimation.isLoadFullData())
                                {
                                    Debug.LogError("moveAnimation not load full");
                                    isLoadFull = false;
                                }
                            }
                            else
                            {
                                // Debug.LogError ("moveAnimation null");
                            }
                        }
                        // process
                        if (isLoadFull)
                        {
                            // tvInfo
                            if (tvInfo != null)
                            {
                                StringBuilder builder = new StringBuilder();
                                {
                                    builder.AppendLine("Suit: " + card.Suit.v);
                                    builder.AppendLine("Rank: " + card.Rank.v);
                                    builder.AppendLine("IsOdd: " + card.IsOdd.v);
                                    builder.AppendLine("IsRed: " + card.IsRed.v);
                                    builder.AppendLine("Foundation: " + card.Foundation.v);
                                    builder.AppendLine("Value: " + card.Value.v);
                                    builder.AppendLine("Card Index: " + this.data.cardIndex.v);
                                    builder.AppendLine("IsDown: " + this.data.isDown.v);
                                }
                                tvInfo.text = builder.ToString();
                            }
                            else
                            {
                                Debug.LogError("tvInfo null");
                            }
                            // faceDown
                            if (faceDown != null)
                            {
                                bool isFaceDown = this.data.isDown.v;
                                // isStock
                                {
                                    PileUI.UIData pileUIData = this.data.findDataInParent<PileUI.UIData>();
                                    if (pileUIData != null)
                                    {
                                        if (pileUIData.pileIndex.v == (int)Pile.Piles.STOCK)
                                        {
                                            isFaceDown = true;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("pileUIData null: " + this);
                                    }
                                }
                                // animation
                                {
                                    if (moveAnimation != null)
                                    {
                                        switch (moveAnimation.getType())
                                        {
                                            case GameMove.Type.SolitaireMove:
                                                {
                                                    SolitaireMoveAnimation solitaireMoveAnimation = moveAnimation as SolitaireMoveAnimation;
                                                    if (solitaireMoveAnimation.isFlip.v)
                                                    {
                                                        if (time >= solitaireMoveAnimation.drawDuration.v + solitaireMoveAnimation.moveDuration.v)
                                                        {
                                                            if (solitaireMoveAnimation.Extra.v > 0)
                                                            {
                                                                if (solitaireMoveAnimation.From.v != (int)Pile.Piles.WASTE)
                                                                {
                                                                    PileUI.UIData pileUIData = this.data.findDataInParent<PileUI.UIData>();
                                                                    if (pileUIData != null)
                                                                    {
                                                                        if (pileUIData.pileIndex.v == solitaireMoveAnimation.From.v)
                                                                        {
                                                                            if (this.data.cardIndex.v == pileUIData.cards.vs.Count - solitaireMoveAnimation.Count.v - 1)
                                                                            {
                                                                                float flipTime = time - (solitaireMoveAnimation.drawDuration.v + solitaireMoveAnimation.moveDuration.v);
                                                                                int flipFlop = Mathf.CeilToInt(flipTime / (SolitaireMoveAnimation.FlipTime / 4));
                                                                                isFaceDown = (flipFlop % 2 != 0);
                                                                                // Debug.LogError ("flip card animation: " + flipFlop  + ", " + flipTime + ", "
                                                                                //	+ duration + ", " + card.Suit.v + ", " + card.Rank.v + "; " + this);
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
                                                    }
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown moveAnimation: " + moveAnimation.getType());
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        // Debug.LogError ("moveAnimation null: " + this);
                                    }
                                }
                                faceDown.SetActive(isFaceDown);
                            }
                            else
                            {
                                Debug.LogError("faceDown null: " + this);
                            }
                            // position
                            {
                                float x = 0;
                                float y = 0;
                                {
                                    PileUI.UIData pileUIData = this.data.findDataInParent<PileUI.UIData>();
                                    if (pileUIData != null)
                                    {
                                        switch ((Pile.Piles)pileUIData.pileIndex.v)
                                        {
                                            /*case Pile.Piles.STOCK:
                                        case Pile.Piles.WASTE:
                                            {
                                                y = -this.data.cardIndex.v / CardY;
                                            }
                                            break;*/
                                            case Pile.Piles.WASTE:
                                                {
                                                    // find drawCount
                                                    int drawCount = 1;
                                                    {
                                                        BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData>();
                                                        if (boardUIData != null)
                                                        {
                                                            Solitaire solitaire = boardUIData.solitaire.v.data;
                                                            if (solitaire != null)
                                                            {
                                                                drawCount = solitaire.drawCount.v;
                                                            }
                                                            else
                                                            {
                                                                Debug.LogError("solitaire null: " + this);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("boardUIData null: " + this);
                                                        }
                                                    }
                                                    if (this.data.cardIndex.v >= pileUIData.cards.vs.Count - drawCount)
                                                    {
                                                        x = (this.data.cardIndex.v - (pileUIData.cards.vs.Count - drawCount)) / CardX;
                                                        // Debug.LogError("pile waste: " + x + "; " + this.data.cardIndex.v + ", " + pileUIData.cards.vs.Count + ", " + drawCount);
                                                    }
                                                }
                                                break;
                                            case Pile.Piles.TABLEAU1:
                                            case Pile.Piles.TABLEAU2:
                                            case Pile.Piles.TABLEAU3:
                                            case Pile.Piles.TABLEAU4:
                                            case Pile.Piles.TABLEAU5:
                                            case Pile.Piles.TABLEAU6:
                                            case Pile.Piles.TABLEAU7:
                                                y = -this.data.cardIndex.v / CardY;
                                                break;
                                            case Pile.Piles.STOCK:
                                                break;
                                            case Pile.Piles.FOUNDATION1C:
                                                break;
                                            case Pile.Piles.FOUNDATION2D:
                                                break;
                                            case Pile.Piles.FOUNDATION3S:
                                                break;
                                            case Pile.Piles.FOUNDATION4H:
                                                break;
                                            default:
                                                Debug.LogError("unknown pile: " + pileUIData.pileIndex.v);
                                                break;
                                        }
                                        // moveAnimation
                                        if (moveAnimation != null)
                                        {
                                            switch (moveAnimation.getType())
                                            {
                                                case GameMove.Type.SolitaireMove:
                                                    {
                                                        SolitaireMoveAnimation solitaireMoveAnimation = moveAnimation as SolitaireMoveAnimation;
                                                        if (time >= solitaireMoveAnimation.drawDuration.v)
                                                        {
                                                            if (solitaireMoveAnimation.moveDuration.v > 0)
                                                            {
                                                                // in moveDuration, check this card move
                                                                if (pileUIData.pileIndex.v == solitaireMoveAnimation.From.v)
                                                                {
                                                                    // find startCardIndex
                                                                    int startCardIndex = pileUIData.cards.vs.Count - solitaireMoveAnimation.Count.v;
                                                                    // check need animation
                                                                    bool needAnimation = false;
                                                                    {
                                                                        switch ((Pile.Piles)solitaireMoveAnimation.From.v)
                                                                        {
                                                                            case Pile.Piles.WASTE:
                                                                                {
                                                                                    if (card.Rank.v == solitaireMoveAnimation.fromRank.v && card.Suit.v == solitaireMoveAnimation.fromSuit.v)
                                                                                    {
                                                                                        needAnimation = true;
                                                                                    }
                                                                                }
                                                                                break;
                                                                            case Pile.Piles.TABLEAU1:
                                                                            case Pile.Piles.TABLEAU2:
                                                                            case Pile.Piles.TABLEAU3:
                                                                            case Pile.Piles.TABLEAU4:
                                                                            case Pile.Piles.TABLEAU5:
                                                                            case Pile.Piles.TABLEAU6:
                                                                            case Pile.Piles.TABLEAU7:
                                                                            case Pile.Piles.STOCK:
                                                                            case Pile.Piles.FOUNDATION1C:
                                                                            case Pile.Piles.FOUNDATION2D:
                                                                            case Pile.Piles.FOUNDATION3S:
                                                                            case Pile.Piles.FOUNDATION4H:
                                                                                if (this.data.cardIndex.v >= startCardIndex)
                                                                                {
                                                                                    needAnimation = true;
                                                                                }
                                                                                break;
                                                                            default:
                                                                                Debug.LogError("unknown pile: " + solitaireMoveAnimation.From.v);
                                                                                break;
                                                                        }
                                                                    }
                                                                    if (needAnimation)
                                                                    {
                                                                        Vector2 from = solitaireMoveAnimation.from.v;
                                                                        Vector2 dest = solitaireMoveAnimation.dest.v;
                                                                        // delta
                                                                        {
                                                                            // from
                                                                            switch ((Pile.Piles)solitaireMoveAnimation.From.v)
                                                                            {
                                                                                case Pile.Piles.WASTE:
                                                                                    // TODO con rut quan bai tu 1 so cho chua giai quyet
                                                                                    break;
                                                                                case Pile.Piles.TABLEAU1:
                                                                                case Pile.Piles.TABLEAU2:
                                                                                case Pile.Piles.TABLEAU3:
                                                                                case Pile.Piles.TABLEAU4:
                                                                                case Pile.Piles.TABLEAU5:
                                                                                case Pile.Piles.TABLEAU6:
                                                                                case Pile.Piles.TABLEAU7:
                                                                                    {
                                                                                        from -= new Vector2(0, (this.data.cardIndex.v - startCardIndex) / CardY);
                                                                                    }
                                                                                    break;
                                                                                case Pile.Piles.STOCK:
                                                                                    break;
                                                                                case Pile.Piles.FOUNDATION1C:
                                                                                    break;
                                                                                case Pile.Piles.FOUNDATION2D:
                                                                                    break;
                                                                                case Pile.Piles.FOUNDATION3S:
                                                                                    break;
                                                                                case Pile.Piles.FOUNDATION4H:
                                                                                    break;
                                                                                default:
                                                                                    Debug.LogError("unknown pile: " + solitaireMoveAnimation.From.v);
                                                                                    break;
                                                                            }
                                                                            // dest
                                                                            switch ((Pile.Piles)solitaireMoveAnimation.To.v)
                                                                            {
                                                                                case Pile.Piles.WASTE:
                                                                                    break;
                                                                                case Pile.Piles.TABLEAU1:
                                                                                case Pile.Piles.TABLEAU2:
                                                                                case Pile.Piles.TABLEAU3:
                                                                                case Pile.Piles.TABLEAU4:
                                                                                case Pile.Piles.TABLEAU5:
                                                                                case Pile.Piles.TABLEAU6:
                                                                                case Pile.Piles.TABLEAU7:
                                                                                    {
                                                                                        dest -= new Vector2(0, (this.data.cardIndex.v - startCardIndex) / CardY);
                                                                                    }
                                                                                    break;
                                                                                case Pile.Piles.STOCK:
                                                                                    break;
                                                                                case Pile.Piles.FOUNDATION1C:
                                                                                    break;
                                                                                case Pile.Piles.FOUNDATION2D:
                                                                                    break;
                                                                                case Pile.Piles.FOUNDATION3S:
                                                                                    break;
                                                                                case Pile.Piles.FOUNDATION4H:
                                                                                    break;
                                                                                default:
                                                                                    Debug.LogError("unknown pile: " + solitaireMoveAnimation.To.v);
                                                                                    break;
                                                                            }
                                                                        }
                                                                        // convert to local transform
                                                                        {
                                                                            // find boardUI
                                                                            BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData>();
                                                                            if (boardUIData != null)
                                                                            {
                                                                                BoardUI boardUI = boardUIData.findCallBack<BoardUI>();
                                                                                if (boardUI != null)
                                                                                {
                                                                                    Vector2 worldFrom = boardUI.transform.TransformPoint(from);
                                                                                    Vector2 worldDest = boardUI.transform.TransformPoint(dest);
                                                                                    // local in this card
                                                                                    {
                                                                                        PileUI pileUI = pileUIData.findCallBack<PileUI>();
                                                                                        if (pileUI != null)
                                                                                        {
                                                                                            from = pileUI.transform.InverseTransformPoint(worldFrom);
                                                                                            dest = pileUI.transform.InverseTransformPoint(worldDest);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            Debug.LogError("pileUI null: " + this);
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    Debug.LogError("boardUI null");
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                Debug.LogError("boardUIData null");
                                                                            }
                                                                        }
                                                                        // set
                                                                        Vector2 localPosition = Vector2.Lerp(from, dest, (time - solitaireMoveAnimation.drawDuration.v) / solitaireMoveAnimation.moveDuration.v);
                                                                        x = localPosition.x;
                                                                        y = localPosition.y;
                                                                        // Debug.LogError ("card moveAnimation: " + localPosition + ", " + solitaireMoveAnimation.drawDuration.v + ", "
                                                                        // + solitaireMoveAnimation.moveDuration.v + ", " + time + ", " + duration + ", " + from + ", " + dest);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    break;
                                                default:
                                                    Debug.LogError("unknown moveAnimation: " + moveAnimation.getType());
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            // Debug.LogError ("moveAnimation null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("pileUIData null: " + this);
                                    }
                                }
                                this.transform.localPosition = new Vector2(x, y);
                            }
                            // background
                            {
                                if (background != null)
                                {
                                    Sprite sprite = SolitaireSpriteContainer.get().getSprite(card);
                                    background.sprite = sprite;
                                }
                                else
                                {
                                    Debug.LogError("background null: " + this);
                                }
                            }
                            // chooseInputCard
                            {
                                if (chooseInputCard != null)
                                {
                                    bool isChoose = false;
                                    {
                                        SolitaireGameDataUI.UIData solitaireGameDataUIData = this.data.findDataInParent<SolitaireGameDataUI.UIData>();
                                        if (solitaireGameDataUIData != null)
                                        {
                                            InputUI.UIData inputUIData = solitaireGameDataUIData.inputUI.v;
                                            if (inputUIData != null)
                                            {
                                                InputUI.UIData.Sub inputSub = inputUIData.sub.v;
                                                if (inputSub != null)
                                                {
                                                    if (inputSub.getType() == InputUI.UIData.Sub.Type.UseRule)
                                                    {
                                                        UseRuleInputUI.UIData useRuleInputUIData = inputSub as UseRuleInputUI.UIData;
                                                        // sub
                                                        UseRuleInputUI.UIData.Sub useRuleSub = useRuleInputUIData.sub.v;
                                                        if (useRuleSub != null)
                                                        {
                                                            if (useRuleSub.getType() == UseRuleInputUI.UIData.Sub.Type.Card)
                                                            {
                                                                UseRuleInputCardUI.UIData cardUIData = useRuleSub as UseRuleInputCardUI.UIData;
                                                                if (cardUIData.card.v.data == card)
                                                                {
                                                                    isChoose = true;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("useRuleSub null");
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    // Debug.LogError ("sub null");
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("inputUIData null");
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("solitaireGameDataUIData null");
                                        }
                                    }
                                    chooseInputCard.SetActive(isChoose);
                                }
                                else
                                {
                                    Debug.LogError("chooseInputCard null");
                                }
                            }
                        }
                        else
                        {
                            // Debug.LogError ("card null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("not load full");
                        dirty = true;
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

        private PileUI.UIData pileUIData = null;
        private BoardUI.UIData boardUIData = null;
        private SolitaireGameDataUI.UIData solitaireGameDataUIData = null;

        public CardLastMoveUI cardLastMovePrefab;
        public Transform cardLastMoveContainer;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.pileUIData);
                    DataUtils.addParentCallBack(uiData, this, ref this.boardUIData);
                    DataUtils.addParentCallBack(uiData, this, ref this.solitaireGameDataUIData);
                }
                // Child
                {
                    uiData.card.allAddCallBack(this);
                    uiData.cardLastMoveUIData.allAddCallBack(this);
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
                // boardUIData
                {
                    if (data is BoardUI.UIData)
                    {
                        BoardUI.UIData boardUIData = data as BoardUI.UIData;
                        // Child
                        {
                            boardUIData.solitaire.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is Solitaire)
                    {
                        dirty = true;
                        return;
                    }
                }
                // solitaireGameDataUIData
                {
                    if (data is SolitaireGameDataUI.UIData)
                    {
                        SolitaireGameDataUI.UIData solitaireGameDataUIData = data as SolitaireGameDataUI.UIData;
                        // Child
                        {
                            solitaireGameDataUIData.inputUI.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is InputUI.UIData)
                        {
                            InputUI.UIData inputUIData = data as InputUI.UIData;
                            // Child
                            {
                                inputUIData.sub.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        {
                            if (data is InputUI.UIData.Sub)
                            {
                                InputUI.UIData.Sub sub = data as InputUI.UIData.Sub;
                                // Child
                                {
                                    switch (sub.getType())
                                    {
                                        case InputUI.UIData.Sub.Type.UseRule:
                                            {
                                                UseRuleInputUI.UIData useRuleInputUIData = sub as UseRuleInputUI.UIData;
                                                useRuleInputUIData.sub.allAddCallBack(this);
                                            }
                                            break;
                                        case InputUI.UIData.Sub.Type.NoneRule:
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + sub.getType());
                                            break;
                                    }
                                }
                                dirty = true;
                                return;
                            }
                            // Child
                            {
                                if (data is UseRuleInputUI.UIData)
                                {
                                    UseRuleInputUI.UIData useRuleInputUIData = data as UseRuleInputUI.UIData;
                                    // Child
                                    {
                                        useRuleInputUIData.sub.allAddCallBack(this);
                                    }
                                    dirty = true;
                                    return;
                                }
                                // Child
                                if (data is UseRuleInputUI.UIData.Sub)
                                {
                                    dirty = true;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            // Child
            {
                if (data is Card)
                {
                    dirty = true;
                    return;
                }
                if (data is CardLastMoveUI.UIData)
                {
                    CardLastMoveUI.UIData cardLastMoveUIData = data as CardLastMoveUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(cardLastMoveUIData, cardLastMovePrefab, cardLastMoveContainer);
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.pileUIData);
                    DataUtils.removeParentCallBack(uiData, this, ref this.boardUIData);
                    DataUtils.removeParentCallBack(uiData, this, ref this.solitaireGameDataUIData);
                }
                // Child
                {
                    uiData.card.allRemoveCallBack(this);
                    uiData.cardLastMoveUIData.allRemoveCallBack(this);
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
                // boardUIData
                {
                    if (data is BoardUI.UIData)
                    {
                        BoardUI.UIData boardUIData = data as BoardUI.UIData;
                        // Child
                        {
                            boardUIData.solitaire.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is Solitaire)
                    {
                        return;
                    }
                }
                // solitaireGameDataUIData
                {
                    if (data is SolitaireGameDataUI.UIData)
                    {
                        SolitaireGameDataUI.UIData solitaireGameDataUIData = data as SolitaireGameDataUI.UIData;
                        // Child
                        {
                            solitaireGameDataUIData.inputUI.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is InputUI.UIData)
                        {
                            InputUI.UIData inputUIData = data as InputUI.UIData;
                            // Child
                            {
                                inputUIData.sub.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        {
                            if (data is InputUI.UIData.Sub)
                            {
                                InputUI.UIData.Sub sub = data as InputUI.UIData.Sub;
                                // Child
                                {
                                    switch (sub.getType())
                                    {
                                        case InputUI.UIData.Sub.Type.UseRule:
                                            {
                                                UseRuleInputUI.UIData useRuleInputUIData = sub as UseRuleInputUI.UIData;
                                                useRuleInputUIData.sub.allRemoveCallBack(this);
                                            }
                                            break;
                                        case InputUI.UIData.Sub.Type.NoneRule:
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + sub.getType());
                                            break;
                                    }
                                }
                                return;
                            }
                            // Child
                            {
                                if (data is UseRuleInputUI.UIData)
                                {
                                    UseRuleInputUI.UIData useRuleInputUIData = data as UseRuleInputUI.UIData;
                                    // Child
                                    {
                                        useRuleInputUIData.sub.allRemoveCallBack(this);
                                    }
                                    return;
                                }
                                // Child
                                if (data is UseRuleInputUI.UIData.Sub)
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            // Child
            {
                if (data is Card)
                {
                    return;
                }
                if (data is CardLastMoveUI.UIData)
                {
                    CardLastMoveUI.UIData cardLastMoveUIData = data as CardLastMoveUI.UIData;
                    // UI
                    {
                        cardLastMoveUIData.removeCallBackAndDestroy(typeof(CardLastMoveUI));
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
                    case UIData.Property.card:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.cardIndex:
                        dirty = true;
                        break;
                    case UIData.Property.isDown:
                        dirty = true;
                        break;
                    case UIData.Property.cardLastMoveUIData:
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
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // boardUIData
                {
                    if (wrapProperty.p is BoardUI.UIData)
                    {
                        switch ((BoardUI.UIData.Property)wrapProperty.n)
                        {
                            case BoardUI.UIData.Property.solitaire:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case BoardUI.UIData.Property.piles:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is Solitaire)
                    {
                        switch ((Solitaire.Property)wrapProperty.n)
                        {
                            case Solitaire.Property.piles:
                                break;
                            case Solitaire.Property.cards:
                                break;
                            case Solitaire.Property.movesAvailableCount:
                                break;
                            case Solitaire.Property.movesAvailable:
                                break;
                            case Solitaire.Property.drawCount:
                                dirty = true;
                                break;
                            case Solitaire.Property.roundCount:
                                break;
                            case Solitaire.Property.foundationCount:
                                break;
                            case Solitaire.Property.solvedMoves:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
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
                                break;
                            case SolitaireGameDataUI.UIData.Property.showHint:
                                break;
                            case SolitaireGameDataUI.UIData.Property.inputUI:
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
                        if (wrapProperty.p is InputUI.UIData)
                        {
                            switch ((InputUI.UIData.Property)wrapProperty.n)
                            {
                                case InputUI.UIData.Property.solitaire:
                                    break;
                                case InputUI.UIData.Property.sub:
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
                            if (wrapProperty.p is InputUI.UIData.Sub)
                            {
                                InputUI.UIData.Sub sub = wrapProperty.p as InputUI.UIData.Sub;
                                // Child
                                {
                                    switch (sub.getType())
                                    {
                                        case InputUI.UIData.Sub.Type.UseRule:
                                            {
                                                switch ((UseRuleInputUI.UIData.Property)wrapProperty.n)
                                                {
                                                    case UseRuleInputUI.UIData.Property.solitaire:
                                                        break;
                                                    case UseRuleInputUI.UIData.Property.sub:
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
                                        case InputUI.UIData.Sub.Type.NoneRule:
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + sub.getType());
                                            break;
                                    }
                                }
                                return;
                            }
                            // Child
                            {
                                if (wrapProperty.p is UseRuleInputUI.UIData)
                                {
                                    switch ((UseRuleInputUI.UIData.Property)wrapProperty.n)
                                    {
                                        case UseRuleInputUI.UIData.Property.solitaire:
                                            break;
                                        case UseRuleInputUI.UIData.Property.sub:
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
                                if (wrapProperty.p is UseRuleInputUI.UIData.Sub)
                                {
                                    UseRuleInputUI.UIData.Sub sub = wrapProperty.p as UseRuleInputUI.UIData.Sub;
                                    switch (sub.getType())
                                    {
                                        case UseRuleInputUI.UIData.Sub.Type.None:
                                            break;
                                        case UseRuleInputUI.UIData.Sub.Type.Card:
                                            {
                                                switch ((UseRuleInputCardUI.UIData.Property)wrapProperty.n)
                                                {
                                                    case UseRuleInputCardUI.UIData.Property.card:
                                                        dirty = true;
                                                        break;
                                                    default:
                                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                        break;
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + sub.getType());
                                            break;
                                    }
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            // Child
            {
                if (wrapProperty.p is Card)
                {
                    switch ((Card.Property)wrapProperty.n)
                    {
                        case Card.Property.Suit:
                            dirty = true;
                            break;
                        case Card.Property.Rank:
                            dirty = true;
                            break;
                        case Card.Property.IsOdd:
                            dirty = true;
                            break;
                        case Card.Property.IsRed:
                            dirty = true;
                            break;
                        case Card.Property.Foundation:
                            dirty = true;
                            break;
                        case Card.Property.Value:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is CardLastMoveUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickCard()
        {
            if (this.data != null)
            {
                Card card = this.data.card.v.data;
                if (card != null)
                {
                    SolitaireGameDataUI.UIData solitaireGameDataUIData = this.data.findDataInParent<SolitaireGameDataUI.UIData>();
                    if (solitaireGameDataUIData != null)
                    {
                        InputUI.UIData inputUIData = solitaireGameDataUIData.inputUI.v;
                        if (inputUIData != null)
                        {
                            InputUI.UIData.Sub sub = inputUIData.sub.v;
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
                            Debug.LogError("inputUIData null");
                        }
                    }
                    else
                    {
                        Debug.LogError("solitaireGameDataUIData null");
                    }
                }
                else
                {
                    Debug.LogError("card null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}
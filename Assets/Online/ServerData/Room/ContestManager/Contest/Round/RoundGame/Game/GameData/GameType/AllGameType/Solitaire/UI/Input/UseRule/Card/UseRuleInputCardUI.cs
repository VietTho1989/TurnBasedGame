using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
    public class UseRuleInputCardUI : UIBehavior<UseRuleInputCardUI.UIData>
    {

        #region UIData

        public class UIData : UseRuleInputUI.UIData.Sub
        {

            public VP<ReferenceData<Card>> card;

            public VP<UseRuleInputCardBtnUI.UIData> btns;

            #region Constructor

            public enum Property
            {
                card,
                btns
            }

            public UIData() : base()
            {
                this.card = new VP<ReferenceData<Card>>(this, (byte)Property.card, new ReferenceData<Card>(null));
                this.btns = new VP<UseRuleInputCardBtnUI.UIData>(this, (byte)Property.btns, new UseRuleInputCardBtnUI.UIData());
            }

            #endregion

            public override Type getType()
            {
                return Type.Card;
            }

            public override void onClickCard(Card card)
            {
                Card currentCard = this.card.v.data;
                if (currentCard != null)
                {
                    Pile pile = card.findDataInParent<Pile>();
                    if (pile != null)
                    {
                        Pile currentPile = currentCard.findDataInParent<Pile>();
                        if (currentPile != null)
                        {
                            Solitaire solitaire = card.findDataInParent<Solitaire>();
                            if (solitaire != null)
                            {
                                if (currentCard == card)
                                {
                                    // check canFlip
                                    bool isCanFlip = false;
                                    {
                                        switch ((Pile.Piles)solitaire.piles.vs.IndexOf(pile))
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
                                                    if (pile.down.vs.Contains(card))
                                                    {
                                                        if (pile.down.vs.IndexOf(card) == pile.down.vs.Count - 1)
                                                        {
                                                            isCanFlip = true;
                                                        }
                                                    }
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
                                                Debug.LogError("unknown pile: " + solitaire.piles.vs.IndexOf(pile));
                                                break;
                                        }
                                    }
                                    // process
                                    if (isCanFlip)
                                    {
                                        // send flip move
                                        ClientInput clientInput = InputUI.UIData.findClientInput(this);
                                        if (clientInput != null)
                                        {
                                            SolitaireMove solitaireMove = new SolitaireMove();
                                            {
                                                solitaireMove.From.v = (byte)solitaire.piles.vs.IndexOf(pile);
                                                solitaireMove.To.v = (byte)solitaire.piles.vs.IndexOf(pile);
                                                solitaireMove.Count.v = 0;
                                                solitaireMove.Extra.v = 1;
                                            }
                                            clientInput.makeSend(solitaireMove);
                                        }
                                        else
                                        {
                                            Debug.LogError("clientInput null");
                                        }
                                    }
                                    else
                                    {
                                        // move to foundation?
                                        bool isMoveToFoundation = false;
                                        {
                                            switch ((Pile.Piles)solitaire.piles.vs.IndexOf(pile))
                                            {
                                                case Pile.Piles.WASTE:
                                                case Pile.Piles.TABLEAU1:
                                                case Pile.Piles.TABLEAU2:
                                                case Pile.Piles.TABLEAU3:
                                                case Pile.Piles.TABLEAU4:
                                                case Pile.Piles.TABLEAU5:
                                                case Pile.Piles.TABLEAU6:
                                                case Pile.Piles.TABLEAU7:
                                                    {
                                                        // check is last card
                                                        if (pile.up.vs.Contains(card))
                                                        {
                                                            if (pile.up.vs.IndexOf(card) == pile.up.vs.Count - 1)
                                                            {
                                                                // check foundation correct rank
                                                                // find last rank in foundation
                                                                byte lastRank = 0;
                                                                {
                                                                    // find foundation pile
                                                                    Pile foundationPile = null;
                                                                    {
                                                                        // get pileIndex
                                                                        int pileIndex = (int)Pile.Piles.FOUNDATION1C;
                                                                        {
                                                                            switch ((Card.Suits)card.Suit.v)
                                                                            {
                                                                                case Card.Suits.CLUBS:
                                                                                    pileIndex = (int)Pile.Piles.FOUNDATION1C;
                                                                                    break;
                                                                                case Card.Suits.DIAMONDS:
                                                                                    pileIndex = (int)Pile.Piles.FOUNDATION2D;
                                                                                    break;
                                                                                case Card.Suits.SPADES:
                                                                                    pileIndex = (int)Pile.Piles.FOUNDATION3S;
                                                                                    break;
                                                                                case Card.Suits.HEARTS:
                                                                                    pileIndex = (int)Pile.Piles.FOUNDATION4H;
                                                                                    break;
                                                                                default:
                                                                                    Debug.LogError("unknown suit: " + card.Suit.v);
                                                                                    break;
                                                                            }
                                                                        }
                                                                        // process
                                                                        if (pileIndex >= 0 && pileIndex < solitaire.piles.vs.Count)
                                                                        {
                                                                            foundationPile = solitaire.piles.vs[pileIndex];
                                                                        }
                                                                    }
                                                                    if (foundationPile != null)
                                                                    {
                                                                        if (foundationPile.up.vs.Count > 0)
                                                                        {
                                                                            Card lastCard = foundationPile.up.vs[foundationPile.up.vs.Count - 1];
                                                                            lastRank = lastCard.Rank.v;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        Debug.LogError("foundationPile null");
                                                                    }
                                                                }
                                                                if (card.Rank.v == lastRank + 1)
                                                                {
                                                                    isMoveToFoundation = true;
                                                                }
                                                                else
                                                                {
                                                                    Debug.LogError("not correct rank: " + card.Rank.v + ", " + lastRank);
                                                                }
                                                            }
                                                        }
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
                                                    Debug.LogError("unknown pile: " + solitaire.piles.vs.IndexOf(pile));
                                                    break;
                                            }
                                        }
                                        // process
                                        if (isMoveToFoundation)
                                        {
                                            // send to foundation
                                            ClientInput clientInput = InputUI.UIData.findClientInput(this);
                                            if (clientInput != null)
                                            {
                                                SolitaireMove solitaireMove = new SolitaireMove();
                                                {
                                                    solitaireMove.From.v = (byte)solitaire.piles.vs.IndexOf(pile);
                                                    // to
                                                    {
                                                        byte to = (byte)Pile.Piles.FOUNDATION1C;
                                                        switch ((Card.Suits)card.Suit.v)
                                                        {
                                                            case Card.Suits.CLUBS:
                                                                to = (byte)Pile.Piles.FOUNDATION1C;
                                                                break;
                                                            case Card.Suits.DIAMONDS:
                                                                to = (byte)Pile.Piles.FOUNDATION2D;
                                                                break;
                                                            case Card.Suits.SPADES:
                                                                to = (byte)Pile.Piles.FOUNDATION3S;
                                                                break;
                                                            case Card.Suits.HEARTS:
                                                                to = (byte)Pile.Piles.FOUNDATION4H;
                                                                break;
                                                            default:
                                                                Debug.LogError("unknown suit: " + card.Suit.v);
                                                                break;
                                                        }
                                                        solitaireMove.To.v = to;
                                                    }
                                                    solitaireMove.Count.v = 1;
                                                    solitaireMove.Extra.v = 0;
                                                }
                                                clientInput.makeSend(solitaireMove);
                                            }
                                            else
                                            {
                                                Debug.LogError("clientInput null");
                                            }
                                        }
                                        else
                                        {
                                            // tro ve none
                                            UseRuleInputUI.UIData useRuleInputUIData = this.findDataInParent<UseRuleInputUI.UIData>();
                                            if (useRuleInputUIData != null)
                                            {
                                                UseRuleInputNoneUI.UIData noneUIData = new UseRuleInputNoneUI.UIData();
                                                {
                                                    noneUIData.uid = useRuleInputUIData.sub.makeId();
                                                }
                                                useRuleInputUIData.sub.v = noneUIData;
                                            }
                                            else
                                            {
                                                Debug.LogError("useRuleInputUIData null");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // move card
                                    bool isMoveCard = false;
                                    {
                                        if (currentPile != pile)
                                        {
                                            // check current card correct
                                            bool isCurrentCardUp = false;
                                            {
                                                switch ((Pile.Piles)solitaire.piles.vs.IndexOf(currentPile))
                                                {
                                                    case Pile.Piles.WASTE:
                                                        {
                                                            // need to be last card
                                                            if (currentPile.up.vs.Contains(currentCard))
                                                            {
                                                                if (currentPile.up.vs.IndexOf(currentCard) == currentPile.up.vs.Count - 1)
                                                                {
                                                                    isCurrentCardUp = true;
                                                                }
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
                                                        {
                                                            if (currentPile.up.vs.Contains(currentCard))
                                                            {
                                                                isCurrentCardUp = true;
                                                            }
                                                        }
                                                        break;
                                                    case Pile.Piles.STOCK:
                                                        break;
                                                    case Pile.Piles.FOUNDATION1C:
                                                    case Pile.Piles.FOUNDATION2D:
                                                    case Pile.Piles.FOUNDATION3S:
                                                    case Pile.Piles.FOUNDATION4H:
                                                        {
                                                            if (currentPile.up.vs.Contains(currentCard))
                                                            {
                                                                if (currentPile.up.vs.IndexOf(currentCard) == currentPile.up.vs.Count - 1)
                                                                {
                                                                    isCurrentCardUp = true;
                                                                }
                                                            }
                                                        }
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown pile: " + solitaire.piles.vs.IndexOf(currentPile));
                                                        break;
                                                }
                                            }
                                            // check destination
                                            bool isDestinationCardLastUp = false;
                                            {
                                                switch ((Pile.Piles)solitaire.piles.vs.IndexOf(pile))
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
                                                            if (pile.up.vs.Contains(card))
                                                            {
                                                                if (pile.up.vs.IndexOf(card) == pile.up.vs.Count - 1)
                                                                {
                                                                    isDestinationCardLastUp = true;
                                                                }
                                                            }
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
                                                        Debug.LogError("unknown pile: " + pile);
                                                        break;
                                                }
                                            }
                                            // check correct rank
                                            bool isCorrectRankSuit = false;
                                            {
                                                if (card.Rank.v == currentCard.Rank.v + 1)
                                                {
                                                    if (card.Suit.v == (byte)Card.Suits.CLUBS || card.Suit.v == (byte)Card.Suits.SPADES)
                                                    {
                                                        if (currentCard.Suit.v == (byte)Card.Suits.DIAMONDS || currentCard.Suit.v == (byte)Card.Suits.HEARTS)
                                                        {
                                                            isCorrectRankSuit = true;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("not correct suit");
                                                        }
                                                    }
                                                    else if (card.Suit.v == (byte)Card.Suits.DIAMONDS || card.Suit.v == (byte)Card.Suits.HEARTS)
                                                    {
                                                        if (currentCard.Suit.v == (byte)Card.Suits.CLUBS || currentCard.Suit.v == (byte)Card.Suits.SPADES)
                                                        {
                                                            isCorrectRankSuit = true;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("not correct suit");
                                                        }
                                                    }
                                                }
                                            }
                                            // process
                                            if (isCurrentCardUp && isDestinationCardLastUp && isCorrectRankSuit)
                                            {
                                                isMoveCard = true;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("need different pile");
                                        }
                                    }
                                    // process
                                    if (isMoveCard)
                                    {
                                        ClientInput clientInput = InputUI.UIData.findClientInput(this);
                                        if (clientInput != null)
                                        {
                                            SolitaireMove solitaireMove = new SolitaireMove();
                                            {
                                                solitaireMove.From.v = (byte)solitaire.piles.vs.IndexOf(currentPile);
                                                solitaireMove.To.v = (byte)solitaire.piles.vs.IndexOf(pile);
                                                // count
                                                {
                                                    byte count = 1;
                                                    {
                                                        switch ((Pile.Piles)solitaire.piles.vs.IndexOf(currentPile))
                                                        {
                                                            case Pile.Piles.WASTE:
                                                                count = 1;
                                                                break;
                                                            case Pile.Piles.TABLEAU1:
                                                            case Pile.Piles.TABLEAU2:
                                                            case Pile.Piles.TABLEAU3:
                                                            case Pile.Piles.TABLEAU4:
                                                            case Pile.Piles.TABLEAU5:
                                                            case Pile.Piles.TABLEAU6:
                                                            case Pile.Piles.TABLEAU7:
                                                                {
                                                                    int currentCardIndex = currentPile.up.vs.IndexOf(currentCard);
                                                                    if (currentCardIndex >= 0 && currentCardIndex < currentPile.up.vs.Count)
                                                                    {
                                                                        count = (byte)(currentPile.up.vs.Count - currentCardIndex);
                                                                    }
                                                                    else
                                                                    {
                                                                        Debug.LogError("currentCardIndex error: " + currentCardIndex);
                                                                    }
                                                                }
                                                                break;
                                                            case Pile.Piles.STOCK:
                                                                break;
                                                            case Pile.Piles.FOUNDATION1C:
                                                            case Pile.Piles.FOUNDATION2D:
                                                            case Pile.Piles.FOUNDATION3S:
                                                            case Pile.Piles.FOUNDATION4H:
                                                                count = 1;
                                                                break;
                                                            default:
                                                                Debug.LogError("unknown pile: " + solitaire.piles.vs.IndexOf(currentPile));
                                                                break;
                                                        }
                                                    }
                                                    solitaireMove.Count.v = count;
                                                }
                                                solitaireMove.Extra.v = 0;
                                            }
                                            clientInput.makeSend(solitaireMove);
                                        }
                                        else
                                        {
                                            Debug.LogError("clientInput null");
                                        }
                                    }
                                    else
                                    {
                                        this.card.v = new ReferenceData<Card>(card);
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("solitaire null");
                            }
                        }
                        else
                        {
                            Debug.LogError("currentPile null");
                        }
                    }
                    else
                    {
                        Debug.LogError("pile null");
                    }
                }
                else
                {
                    Debug.LogError("currentCard null");
                }
            }

            public override void onClickPile(Pile pile)
            {
                Card currentCard = this.card.v.data;
                if (currentCard != null)
                {
                    Pile currentPile = currentCard.findDataInParent<Pile>();
                    if (currentPile != null)
                    {
                        if (currentPile != pile)
                        {
                            Solitaire solitaire = currentCard.findDataInParent<Solitaire>();
                            if (solitaire != null)
                            {
                                // check is table pile
                                bool isTableAUPile = false;
                                {
                                    switch ((Pile.Piles)solitaire.piles.vs.IndexOf(pile))
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
                                            isTableAUPile = true;
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
                                            Debug.LogError("unknown pile: " + solitaire.piles.vs.IndexOf(pile));
                                            break;
                                    }
                                }
                                // process
                                if (isTableAUPile)
                                {
                                    // check isEmpty pile
                                    if (pile.up.vs.Count == 0)
                                    {
                                        // check card from correct
                                        bool isCardFromCorrect = false;
                                        {
                                            if (currentCard.Rank.v == (byte)Card.Cards.KING)
                                            {
                                                switch ((Pile.Piles)solitaire.piles.vs.IndexOf(currentPile))
                                                {
                                                    case Pile.Piles.WASTE:
                                                        {
                                                            if (currentPile.up.vs.Contains(currentCard))
                                                            {
                                                                if (currentPile.up.vs.IndexOf(currentCard) == currentPile.up.vs.Count - 1)
                                                                {
                                                                    isCardFromCorrect = true;
                                                                }
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
                                                        {
                                                            if (currentPile.up.vs.Contains(currentCard))
                                                            {
                                                                isCardFromCorrect = true;
                                                            }
                                                        }
                                                        break;
                                                    case Pile.Piles.STOCK:
                                                        break;
                                                    case Pile.Piles.FOUNDATION1C:
                                                    case Pile.Piles.FOUNDATION2D:
                                                    case Pile.Piles.FOUNDATION3S:
                                                    case Pile.Piles.FOUNDATION4H:
                                                        {
                                                            if (currentPile.up.vs.Contains(currentCard))
                                                            {
                                                                if (currentPile.up.vs.IndexOf(currentCard) == currentPile.up.vs.Count - 1)
                                                                {
                                                                    isCardFromCorrect = true;
                                                                }
                                                            }
                                                        }
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown pile: " + solitaire.piles.vs.IndexOf(currentPile));
                                                        break;
                                                }
                                            }
                                        }
                                        // process
                                        if (isCardFromCorrect)
                                        {
                                            ClientInput clientInput = InputUI.UIData.findClientInput(this);
                                            if (clientInput != null)
                                            {
                                                SolitaireMove solitaireMove = new SolitaireMove();
                                                {
                                                    solitaireMove.From.v = (byte)solitaire.piles.vs.IndexOf(currentPile);
                                                    solitaireMove.To.v = (byte)solitaire.piles.vs.IndexOf(pile);
                                                    // count
                                                    {
                                                        byte count = 1;
                                                        {
                                                            switch ((Pile.Piles)solitaire.piles.vs.IndexOf(currentPile))
                                                            {
                                                                case Pile.Piles.WASTE:
                                                                    count = 1;
                                                                    break;
                                                                case Pile.Piles.TABLEAU1:
                                                                case Pile.Piles.TABLEAU2:
                                                                case Pile.Piles.TABLEAU3:
                                                                case Pile.Piles.TABLEAU4:
                                                                case Pile.Piles.TABLEAU5:
                                                                case Pile.Piles.TABLEAU6:
                                                                case Pile.Piles.TABLEAU7:
                                                                    {
                                                                        int currentCardIndex = currentPile.up.vs.IndexOf(currentCard);
                                                                        if (currentCardIndex >= 0 && currentCardIndex < currentPile.up.vs.Count)
                                                                        {
                                                                            count = (byte)(currentPile.up.vs.Count - currentCardIndex);
                                                                        }
                                                                        else
                                                                        {
                                                                            Debug.LogError("currentCardIndex error: " + currentCardIndex);
                                                                        }
                                                                    }
                                                                    break;
                                                                case Pile.Piles.STOCK:
                                                                    break;
                                                                case Pile.Piles.FOUNDATION1C:
                                                                case Pile.Piles.FOUNDATION2D:
                                                                case Pile.Piles.FOUNDATION3S:
                                                                case Pile.Piles.FOUNDATION4H:
                                                                    count = 1;
                                                                    break;
                                                                default:
                                                                    Debug.LogError("unknown pile: " + solitaire.piles.vs.IndexOf(currentPile));
                                                                    break;
                                                            }
                                                        }
                                                        solitaireMove.Count.v = count;
                                                    }
                                                    solitaireMove.Extra.v = 0;
                                                }
                                                clientInput.makeSend(solitaireMove);
                                            }
                                            else
                                            {
                                                Debug.LogError("clientInput null");
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("card from not correct");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("not empty pile");
                                    }
                                }
                                else
                                {
                                    Debug.LogError("not tableAUPile");
                                }
                            }
                            else
                            {
                                Debug.LogError("solitaire null");
                            }
                        }
                        else
                        {
                            Debug.LogError("why the same pile");
                        }
                    }
                    else
                    {
                        Debug.LogError("currentPile null");
                    }
                }
                else
                {
                    Debug.LogError("currentCard null");
                }
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            UseRuleInputCardUI useRuleInputCardUI = this.findCallBack<UseRuleInputCardUI>();
                            if (useRuleInputCardUI != null)
                            {
                                isProcess = useRuleInputCardUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("useRuleInputCardUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt, rect

        static UseRuleInputCardUI()
        {
            // rect
            {
                // btnsRect
                {
                    // anchoredPosition: (0.0, 0.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 0.0);
                    // offsetMin: (0.0, 0.0); offsetMax: (0.0, 30.0); sizeDelta: (0.0, 30.0)
                    btnsRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    btnsRect.anchorMin = new Vector2(0.0f, 1.0f);
                    btnsRect.anchorMax = new Vector2(1.0f, 1.0f);
                    btnsRect.pivot = new Vector2(0.5f, 0.0f);
                    btnsRect.offsetMin = new Vector2(0.0f, 0.0f);
                    btnsRect.offsetMax = new Vector2(0.0f, 30.0f);
                    btnsRect.sizeDelta = new Vector2(0.0f, 30.0f);
                }
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
                    Card card = this.data.card.v.data;
                    if (card != null)
                    {

                    }
                    else
                    {
                        Debug.LogError("card null: " + this);
                        UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData>();
                        if (useRuleInputUIData != null)
                        {
                            UseRuleInputNoneUI.UIData noneUIData = new UseRuleInputNoneUI.UIData();
                            {
                                noneUIData.uid = useRuleInputUIData.sub.makeId();
                            }
                            useRuleInputUIData.sub.v = noneUIData;
                        }
                        else
                        {
                            Debug.LogError("useRuleInputUIData null: " + this);
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
            return false;
        }

        #endregion

        #region implement callBacks

        public UseRuleInputCardBtnUI btnsPrefab;
        private static readonly UIRectTransform btnsRect = new UIRectTransform();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.btns.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if(data is UseRuleInputCardBtnUI.UIData)
            {
                UseRuleInputCardBtnUI.UIData btnsUIData = data as UseRuleInputCardBtnUI.UIData;
                // UI
                {
                    // Find container
                    Transform btnsContainer = null;
                    {
                        GameDataBoardUI.UIData gameDataBoardUIData = btnsUIData.findDataInParent<GameDataBoardUI.UIData>();
                        if (gameDataBoardUIData != null)
                        {
                            GameDataBoardUI gameDataBoardUI = gameDataBoardUIData.findCallBack<GameDataBoardUI>();
                            if (gameDataBoardUI != null)
                            {
                                btnsContainer = gameDataBoardUI.transform;
                            }
                            else
                            {
                                Debug.LogError("gameDataBoardUI null");
                            }
                        }
                        else
                        {
                            Debug.LogError("gameDataBoardUIData null");
                        }
                    }
                    // set
                    UIUtils.Instantiate(btnsUIData, btnsPrefab, btnsContainer, btnsRect);
                    UIRectTransform.SetSiblingIndex(btnsUIData, 0);
                }
                dirty = true;
                return;
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
                    uiData.btns.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            if (data is UseRuleInputCardBtnUI.UIData)
            {
                UseRuleInputCardBtnUI.UIData btnsUIData = data as UseRuleInputCardBtnUI.UIData;
                // UI
                {
                    btnsUIData.removeCallBackAndDestroy(typeof(UseRuleInputCardBtnUI));
                }
                return;
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
                        dirty = true;
                        break;
                    case UIData.Property.btns:
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
            if (wrapProperty.p is UseRuleInputCardBtnUI.UIData)
            {
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public override void Awake()
        {
            base.Awake();
            // OnClick
            {
                UIUtils.SetButtonOnClick(btnFlip, onClickBtnFlip);
            }
        }

        public bool useShortKey(Event e)
        {
            bool isProcess = false;
            {
                if (e.isKey && e.type == EventType.KeyUp)
                {
                    switch (e.keyCode)
                    {
                        case KeyCode.F:
                            {
                                if (btnFlip != null && btnFlip.gameObject.activeInHierarchy && btnFlip.interactable)
                                {
                                    this.onClickBtnFlip();
                                    isProcess = true;
                                }
                                else
                                {
                                    Debug.LogError("cannot click");
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return isProcess;
        }

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnBack()
        {
            if (this.data != null)
            {
                UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData>();
                if (useRuleInputUIData != null)
                {
                    UseRuleInputNoneUI.UIData noneUIData = new UseRuleInputNoneUI.UIData();
                    {
                        noneUIData.uid = useRuleInputUIData.sub.makeId();
                    }
                    useRuleInputUIData.sub.v = noneUIData;
                }
                else
                {
                    Debug.LogError("useRuleInputUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

        public Button btnFlip;

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnFlip()
        {

        }

    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Rule;

namespace CoTuongUp.UseRule
{
    public class ClickDestUI : UIBehavior<ClickDestUI.UIData>, IPointerDownHandler
    {

        #region UIData

        public class UIData : ShowUI.UIData.Sub
        {

            public VP<byte> coord;

            public LP<LegalMoveUI.UIData> legalMoves;

            #region keyEvent

            public VP<byte> keyX;

            public VP<byte> keyY;

            #endregion

            #region Constructor

            public enum Property
            {
                coord,
                legalMoves,
                keyX,
                keyY
            }

            public UIData() : base()
            {
                this.coord = new VP<byte>(this, (byte)Property.coord, 0);
                this.legalMoves = new LP<LegalMoveUI.UIData>(this, (byte)Property.legalMoves);
                // keyEvent
                {
                    this.keyX = new VP<byte>(this, (byte)Property.keyX, 20);
                    this.keyY = new VP<byte>(this, (byte)Property.keyY, 20);
                }
            }

            #endregion

            public override Type getType()
            {
                return Type.ClickDest;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    if (InputEvent.isEnter(e))
                    {
                        // enter
                        ClickDestUI clickDestUI = this.findCallBack<ClickDestUI>();
                        if (clickDestUI != null)
                        {
                            clickDestUI.onEnterKey();
                        }
                        else
                        {
                            Debug.LogError("clickDestUI null: " + this);
                        }
                        isProcess = true;
                    }
                    else if (InputEvent.isArrow(e))
                    {
                        if (this.keyX.v >= 0 && this.keyX.v < 9
                            && this.keyY.v >= 0 && this.keyY.v < 10)
                        {
                            // find new key position
                            byte newKeyX = this.keyX.v;
                            byte newKeyY = this.keyY.v;
                            {
                                switch (e.keyCode)
                                {
                                    case KeyCode.LeftArrow:
                                        newKeyX--;
                                        break;
                                    case KeyCode.RightArrow:
                                        newKeyX++;
                                        break;
                                    case KeyCode.UpArrow:
                                        newKeyY--;
                                        break;
                                    case KeyCode.DownArrow:
                                        newKeyY++;
                                        break;
                                    default:
                                        Debug.LogError("unknown keyCode: " + e.keyCode);
                                        break;
                                }
                            }
                            // set
                            if (newKeyX >= 0 && newKeyX < 9
                                && newKeyY >= 0 && newKeyY < 10)
                            {
                                this.keyX.v = newKeyX;
                                this.keyY.v = newKeyY;
                            }
                        }
                        else
                        {
                            // bring to lastMove
                            byte lastKeyX = 4;
                            byte lastKeyY = 5;
                            {
                                Common.parseCoord(this.coord.v, out lastKeyX, out lastKeyY);
                            }
                            // set
                            this.keyX.v = lastKeyX;
                            this.keyY.v = lastKeyY;
                        }
                        isProcess = true;
                    }
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            ClickDestUI clickDestUI = this.findCallBack<ClickDestUI>();
                            if (clickDestUI != null)
                            {
                                isProcess = clickDestUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("clickDestUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region Refresh

        public GameObject ivSelect;

        public GameObject keySelect;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // keySelect
                    {
                        if (keySelect != null)
                        {
                            if (this.data.keyX.v >= 0 && this.data.keyX.v < 9
                                && this.data.keyY.v >= 0 && this.data.keyY.v < 10)
                            {
                                keySelect.SetActive(true);
                                keySelect.transform.localPosition = Common.convertCoordToLocalPosition(Common.makeCoord(this.data.keyX.v, this.data.keyY.v));
                            }
                            else
                            {
                                keySelect.SetActive(false);
                            }
                        }
                        else
                        {
                            Debug.LogError("keySelect null: " + this);
                        }
                    }
                    // imgSelect
                    if (ivSelect != null)
                    {
                        ivSelect.SetActive(true);
                        // transform
                        ivSelect.transform.localPosition = Common.convertCoordToLocalPosition(this.data.coord.v);
                        // TODO co the co rotate
                        {
                            // TODO Can hoan thien
                        }
                    }
                    else
                    {
                        Debug.LogError("imgSelect null: " + this);
                    }
                    // Legal moves
                    {
                        List<LegalMoveUI.UIData> oldLegalMoves = new List<LegalMoveUI.UIData>();
                        // get oldLegalMoves
                        oldLegalMoves.AddRange(this.data.legalMoves.vs);
                        // Update
                        {
                            // Get legal move list
                            List<CoTuongUpMove> legalMoves = new List<CoTuongUpMove>();
                            {
                                ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData>();
                                if (showUIData != null)
                                {
                                    for (int i = 0; i < showUIData.legalMoves.vs.Count; i++)
                                    {
                                        CoTuongUpMove coTuongUpMove = showUIData.legalMoves.vs[i];
                                        Rules.Move move = CoTuongUpMove.getMove(coTuongUpMove.move.v);
                                        if (Common.makeCoord(move.from.x, move.from.y) == this.data.coord.v
                                            && Common.makeCoord(move.dest.x, move.dest.y) != this.data.coord.v)
                                        {
                                            legalMoves.Add(coTuongUpMove);
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("showUIData null: " + this);
                                }
                            }
                            // Debug.LogError ("clickDestClickUI: " + GameUtils.Utils.getListString (legalMoves) + "; " + this);
                            // Make UI
                            {
                                for (int legalMoveIndex = 0; legalMoveIndex < legalMoves.Count; legalMoveIndex++)
                                {
                                    CoTuongUpMove legalMove = legalMoves[legalMoveIndex];
                                    // Find LegalMoveUIData
                                    LegalMoveUI.UIData legalMoveUIData = null;
                                    {
                                        // Find old
                                        {
                                            for (int i = 0; i < oldLegalMoves.Count; i++)
                                            {
                                                LegalMoveUI.UIData check = oldLegalMoves[i];
                                                if (check.legalMove.v.data == legalMove)
                                                {
                                                    legalMoveUIData = check;
                                                    break;
                                                }
                                                else if (check.legalMove.v.data == null)
                                                {
                                                    legalMoveUIData = check;
                                                }
                                            }
                                            if (legalMoveUIData != null)
                                            {
                                                oldLegalMoves.Remove(legalMoveUIData);
                                            }
                                        }
                                        // Make new
                                        if (legalMoveUIData == null)
                                        {
                                            legalMoveUIData = new LegalMoveUI.UIData();
                                            {
                                                legalMoveUIData.uid = this.data.legalMoves.makeId();
                                            }
                                            this.data.legalMoves.add(legalMoveUIData);
                                        }
                                    }
                                    // Update property
                                    if (legalMoveUIData != null)
                                    {
                                        // legalMove
                                        legalMoveUIData.legalMove.v = new ReferenceData<CoTuongUpMove>(legalMove);
                                    }
                                    else
                                    {
                                        Debug.LogError("legalMoveUIData null: " + this);
                                    }
                                }
                            }
                        }
                        // Remove old
                        foreach (LegalMoveUI.UIData legalMoveUIData in oldLegalMoves)
                        {
                            legalMoveUIData.legalMove.v = new ReferenceData<CoTuongUpMove>(null);
                        }
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                    // imgSelect
                    if (ivSelect != null)
                    {
                        ivSelect.SetActive(false);
                    }
                    else
                    {
                        Debug.LogError("imgSelect null: " + this);
                    }
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return false;
        }

        #endregion

        public bool isHaveFlipMove()
        {
            bool haveFlipMove = false;
            {
                if (this.data != null)
                {
                    ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData>();
                    if (showUIData != null)
                    {
                        for (int i = 0; i < showUIData.legalMoves.vs.Count; i++)
                        {
                            CoTuongUpMove coTuongUpMove = showUIData.legalMoves.vs[i];
                            Rules.Move move = CoTuongUpMove.getMove(coTuongUpMove.move.v);
                            if (Common.makeCoord(move.from.x, move.from.y) == this.data.coord.v
                               && Common.makeCoord(move.dest.x, move.dest.y) == this.data.coord.v)
                            {
                                haveFlipMove = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("showUIData null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("data null");
                }
            }
            return haveFlipMove;
        }

        #region implement callBacks

        private ShowUI.UIData showUIData = null;

        public LegalMoveUI legalMovePrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.showUIData);
                }
                // Child
                {
                    uiData.legalMoves.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is ShowUI.UIData)
                {
                    ShowUI.UIData showUIData = data as ShowUI.UIData;
                    // Child
                    {
                        showUIData.legalMoves.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is CoTuongUpMove)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            {
                if (data is LegalMoveUI.UIData)
                {
                    LegalMoveUI.UIData legalMoveUIData = data as LegalMoveUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(legalMoveUIData, legalMovePrefab, this.transform);
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.showUIData);
                }
                // Child
                {
                    uiData.legalMoves.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                if (data is ShowUI.UIData)
                {
                    ShowUI.UIData showUIData = data as ShowUI.UIData;
                    // Child
                    {
                        showUIData.legalMoves.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is CoTuongUpMove)
                {
                    return;
                }
            }
            // Child
            {
                if (data is LegalMoveUI.UIData)
                {
                    LegalMoveUI.UIData legalMoveUIData = data as LegalMoveUI.UIData;
                    // UI
                    {
                        legalMoveUIData.removeCallBackAndDestroy(typeof(LegalMoveUI));
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
                    case UIData.Property.coord:
                        dirty = true;
                        break;
                    case UIData.Property.legalMoves:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.keyX:
                        dirty = true;
                        break;
                    case UIData.Property.keyY:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Parent
            {
                if (wrapProperty.p is ShowUI.UIData)
                {
                    switch ((ShowUI.UIData.Property)wrapProperty.n)
                    {
                        case ShowUI.UIData.Property.legalMoves:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case ShowUI.UIData.Property.sub:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is CoTuongUpMove)
                {
                    switch ((CoTuongUpMove.Property)wrapProperty.n)
                    {
                        case CoTuongUpMove.Property.move:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            // Child
            {
                if (wrapProperty.p is LegalMoveUI.UIData)
                {
                    return;
                }
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

        public Button btnFlip;

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnFlip()
        {
            if (this.data != null)
            {
                CoTuongUp coTuongUp = null;
                // Check isActive
                bool isActive = false;
                {
                    UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData>();
                    if (useRuleInputUIData != null)
                    {
                        coTuongUp = useRuleInputUIData.coTuongUp.v.data;
                        if (coTuongUp != null)
                        {
                            if (Game.IsPlaying(coTuongUp))
                            {
                                isActive = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("coTuongUp null: " + this);
                            return;
                        }
                    }
                    else
                    {
                        Debug.LogError("useRuleInputUIData null: " + this);
                    }
                }
                if (isActive)
                {
                    // Check is legal moves
                    bool isLegalMove = false;
                    int move = -1;
                    {
                        Rules.Move ruleMove = new Rules.Move();
                        {
                            byte x = 0;
                            byte y = 0;
                            Common.parseCoord(this.data.coord.v, out x, out y);
                            // from
                            {

                                ruleMove.from.x = x;
                                ruleMove.from.y = y;
                            }
                            // dest
                            {
                                ruleMove.dest.x = x;
                                ruleMove.dest.y = y;
                            }
                        }
                        move = CoTuongUpMove.makeMove(ruleMove).move.v;
                        if (coTuongUp.isLegalMove(move))
                        {
                            isLegalMove = true;
                        }
                    }
                    // process
                    if (isLegalMove)
                    {
                        ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                        if (clientInput != null)
                        {
                            CoTuongUpMove coTuongUpMove = new CoTuongUpMove();
                            {
                                coTuongUpMove.move.v = move;
                            }
                            clientInput.makeSend(coTuongUpMove);
                        }
                        else
                        {
                            Debug.LogError("clientInput null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("not legal move: " + this);
                    }
                }
                else
                {
                    Debug.LogError("not active: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        #region onPointerDown

        private void clickDest(byte x, byte y)
        {
            if (this.data != null)
            {
                CoTuongUp coTuongUp = null;
                // Check isActive
                bool isActive = false;
                {
                    UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData>();
                    if (useRuleInputUIData != null)
                    {
                        coTuongUp = useRuleInputUIData.coTuongUp.v.data;
                        if (coTuongUp != null)
                        {
                            if (Game.IsPlaying(coTuongUp))
                            {
                                isActive = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("coTuongUp null: " + this);
                            return;
                        }
                    }
                    else
                    {
                        Debug.LogError("useRuleInputUIData null: " + this);
                    }
                }
                if (isActive)
                {
                    if (x >= 0 && x < 9 && y >= 0 && y < 10)
                    {
                        byte coord = Common.makeCoord((byte)x, (byte)y);
                        if (coord == this.data.coord.v)
                        {
                            // click the same piece
                            if (isHaveFlipMove())
                            {
                                // flip
                                this.onClickBtnFlip();
                            }
                            else
                            {
                                // back
                                ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData>();
                                if (showUIData != null)
                                {
                                    ClickPieceUI.UIData clickPieceUIData = new ClickPieceUI.UIData();
                                    {
                                        clickPieceUIData.uid = showUIData.sub.makeId();
                                    }
                                    showUIData.sub.v = clickPieceUIData;
                                }
                                else
                                {
                                    Debug.LogError("showuIData null: " + this);
                                }
                            }
                        }
                        else
                        {
                            byte piece = coTuongUp.getPieceByCoord(coord);
                            if (Common.getPieceSide(piece) == coTuongUp.side.v)
                            {
                                this.data.coord.v = coord;
                            }
                            else
                            {
                                // Check is legal moves
                                bool isLegalMove = false;
                                int move = -1;
                                {
                                    Rules.Move ruleMove = new Rules.Move();
                                    {
                                        // from
                                        {
                                            byte fromX = 0;
                                            byte fromY = 0;
                                            Common.parseCoord(this.data.coord.v, out fromX, out fromY);
                                            ruleMove.from.x = fromX;
                                            ruleMove.from.y = fromY;
                                        }
                                        // dest
                                        {
                                            ruleMove.dest.x = (byte)x;
                                            ruleMove.dest.y = (byte)y;
                                        }
                                    }
                                    move = CoTuongUpMove.makeMove(ruleMove).move.v;
                                    if (coTuongUp.isLegalMove(move))
                                    {
                                        isLegalMove = true;
                                    }
                                }
                                // process
                                if (isLegalMove)
                                {
                                    ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                                    if (clientInput != null)
                                    {
                                        CoTuongUpMove coTuongUpMove = new CoTuongUpMove();
                                        {
                                            coTuongUpMove.move.v = move;
                                        }
                                        clientInput.makeSend(coTuongUpMove);
                                    }
                                    else
                                    {
                                        Debug.LogError("clientInput null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("not legal move: " + this);
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("click outside board: " + this);
                    }
                }
                else
                {
                    Debug.LogError("not active: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void onEnterKey()
        {
            if (this.data != null)
            {
                this.clickDest(this.data.keyX.v, this.data.keyY.v);
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Vector3 localPosition = transform.InverseTransformPoint(eventData.position);
            int x = 0;
            int y = 0;
            Common.convertLocalPositionToXY(localPosition, out x, out y);
            // Debug.LogError ("localPosition: " + localPosition + ", " + x + ", " + y);
            this.clickDest((byte)x, (byte)y);
        }
    }

    #endregion

}
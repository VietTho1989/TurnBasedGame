using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught.NoneRule
{
    public class ClickMoveUI : UIBehavior<ClickMoveUI.UIData>, IPointerDownHandler
    {

        #region UIData

        public class UIData : NoneRuleInputUI.UIData.Sub
        {

            public VP<int> square;

            public VP<int> keyX;

            public VP<int> keyY;

            #region Constructor

            public enum Property
            {
                square,
                keyX,
                keyY
            }

            public UIData() : base()
            {
                this.square = new VP<int>(this, (byte)Property.square, 0);
                this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
                this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
            }

            #endregion

            public override Type getType()
            {
                return Type.ClickMove;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    if (InputEvent.isEnter(e))
                    {
                        // enter
                        ClickMoveUI clickMoveUI = this.findCallBack<ClickMoveUI>();
                        if (clickMoveUI != null)
                        {
                            clickMoveUI.onEnterKey();
                        }
                        else
                        {
                            Debug.LogError("clickMoveUI null: " + this);
                        }
                        isProcess = true;
                    }
                    else if (InputEvent.isArrow(e))
                    {
                        if (this.keyX.v >= 0 && this.keyX.v < 10
                            && this.keyY.v >= 0 && this.keyY.v < 10)
                        {
                            // find new key position
                            int newKeyX = this.keyX.v;
                            int newKeyY = this.keyY.v;
                            {
                                switch (e.keyCode)
                                {
                                    case KeyCode.LeftArrow:
                                        newKeyX -= 2;
                                        break;
                                    case KeyCode.RightArrow:
                                        newKeyX += 2;
                                        break;
                                    case KeyCode.UpArrow:
                                        {
                                            newKeyY--;
                                            newKeyX += this.keyY.v % 2 == 0 ? 1 : -1;
                                        }
                                        break;
                                    case KeyCode.DownArrow:
                                        {
                                            newKeyY++;
                                            newKeyX += this.keyY.v % 2 == 0 ? 1 : -1;
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown keyCode: " + e.keyCode);
                                        break;
                                }
                            }
                            // set
                            if (newKeyX >= 0 && newKeyX < 10
                                && newKeyY >= 0 && newKeyY < 10)
                            {
                                this.keyX.v = newKeyX;
                                this.keyY.v = newKeyY;
                            }
                        }
                        else
                        {
                            this.keyX.v = Common.square_file(this.square.v);
                            this.keyY.v = Common.square_rank(this.square.v);
                        }
                        isProcess = true;
                    }
                    // back
                    if (!isProcess)
                    {
                        if (InputEvent.isBackEvent(e))
                        {
                            ClickMoveUI clickMoveUI = this.findCallBack<ClickMoveUI>();
                            if (clickMoveUI != null)
                            {
                                clickMoveUI.onClickBtnBack();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("clickMoveUI null");
                            }
                        }
                    }
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            ClickMoveUI clickMoveUI = this.findCallBack<ClickMoveUI>();
                            if (clickMoveUI != null)
                            {
                                isProcess = clickMoveUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("clickMoveUI null: " + this);
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
                            if (this.data.keyX.v >= 0 && this.data.keyX.v < 10
                                && this.data.keyY.v >= 0 && this.data.keyY.v < 10)
                            {
                                keySelect.SetActive(true);
                                keySelect.transform.localPosition = Common.convertSquareToLocalPosition(Common.square_make(this.data.keyX.v, this.data.keyY.v));
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
                    // find internationalDraught
                    InternationalDraught internationalDraught = null;
                    {
                        NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                        if (noneRuleInputUIData != null)
                        {
                            internationalDraught = noneRuleInputUIData.internationalDraught.v.data;
                        }
                        else
                        {
                            Debug.LogError("noneRuleInputUIData null: " + this);
                        }
                    }
                    // Process
                    if (internationalDraught != null)
                    {
                        // clickPiece?
                        {
                            // find isClickPiece
                            bool isClickPiece = false;
                            {
                                Common.Piece_Side pieceSide = (Common.Piece_Side)internationalDraught.getPieceSide(this.data.square.v);
                                if (pieceSide != Common.Piece_Side.Empty)
                                {
                                    isClickPiece = true;
                                }
                            }
                            // Process
                            if (!isClickPiece)
                            {
                                // change to none
                                NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                                if (noneRuleInputUIData != null)
                                {
                                    ClickNoneUI.UIData clickNoneUIData = new ClickNoneUI.UIData();
                                    {
                                        clickNoneUIData.uid = noneRuleInputUIData.sub.makeId();
                                    }
                                    noneRuleInputUIData.sub.v = clickNoneUIData;
                                }
                                else
                                {
                                    Debug.LogError("noneRuleInputUIData null: " + this);
                                }
                            }
                        }
                        // imgSelect
                        {
                            if (ivSelect != null)
                            {
                                // position
                                ivSelect.transform.localPosition = Common.convertSquareToLocalPosition(this.data.square.v);
                                // Scale
                                {
                                    int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                    ivSelect.transform.localScale = (playerView == 0 ? new Vector3(1f, 1f, 1f) : new Vector3(1f, -1f, 1f));
                                }
                            }
                            else
                            {
                                Debug.LogError("imgSelect null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("internationalDraught null: " + this);
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
            return false;
        }

        #endregion

        #region implement callBacks

        private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();
        private NoneRuleInputUI.UIData noneRuleInputUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // CheckChange
                {
                    perspectiveChange.addCallBack(this);
                    perspectiveChange.setData(uiData);
                }
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.noneRuleInputUIData);
                }
                dirty = true;
                return;
            }
            // CheckChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is NoneRuleInputUI.UIData)
                {
                    NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
                    // Child
                    {
                        noneRuleInputUIData.internationalDraught.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is InternationalDraught)
                    {
                        InternationalDraught internationalDraught = data as InternationalDraught;
                        // Child
                        {
                            internationalDraught.node.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is Node)
                        {
                            Node node = data as Node;
                            // Child
                            {
                                node.p_pos.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if (data is Pos)
                        {
                            dirty = true;
                            return;
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
                // CheckChange
                {
                    perspectiveChange.removeCallBack(this);
                    perspectiveChange.setData(null);
                }
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.noneRuleInputUIData);
                }
                this.setDataNull(uiData);
                return;
            }
            // CheckChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                return;
            }
            // Parent
            {
                if (data is NoneRuleInputUI.UIData)
                {
                    NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
                    // Child
                    {
                        noneRuleInputUIData.internationalDraught.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is InternationalDraught)
                    {
                        InternationalDraught internationalDraught = data as InternationalDraught;
                        // Child
                        {
                            internationalDraught.node.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is Node)
                        {
                            Node node = data as Node;
                            // Child
                            {
                                node.p_pos.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        if (data is Pos)
                        {
                            return;
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
                    case UIData.Property.square:
                        dirty = true;
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
            // CheckChange
            if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                if (wrapProperty.p is NoneRuleInputUI.UIData)
                {
                    switch ((NoneRuleInputUI.UIData.Property)wrapProperty.n)
                    {
                        case NoneRuleInputUI.UIData.Property.internationalDraught:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case NoneRuleInputUI.UIData.Property.sub:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is InternationalDraught)
                    {
                        switch ((InternationalDraught.Property)wrapProperty.n)
                        {
                            case InternationalDraught.Property.node:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case InternationalDraught.Property.var:
                                break;
                            case InternationalDraught.Property.lastMove:
                                break;
                            case InternationalDraught.Property.ply:
                                break;
                            case InternationalDraught.Property.captureSize:
                                break;
                            case InternationalDraught.Property.captureSquares:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is Node)
                        {
                            switch ((Node.Property)wrapProperty.n)
                            {
                                case Node.Property.p_pos:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case Node.Property.p_ply:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Child
                        if (wrapProperty.p is Pos)
                        {
                            switch ((Pos.Property)wrapProperty.n)
                            {
                                case Pos.Property.p_piece:
                                    dirty = true;
                                    break;
                                case Pos.Property.p_side:
                                    dirty = true;
                                    break;
                                case Pos.Property.p_all:
                                    dirty = true;
                                    break;
                                case Pos.Property.p_turn:
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
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        private void clickMove(int x, int y)
        {
            if (this.data != null)
            {
                InternationalDraught internationalDraught = null;
                // Check isActive
                bool isActive = false;
                {
                    NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                    if (noneRuleInputUIData != null)
                    {
                        internationalDraught = noneRuleInputUIData.internationalDraught.v.data;
                        if (internationalDraught != null)
                        {
                            if (Game.IsPlaying(internationalDraught))
                            {
                                isActive = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("internationDraught null: " + this);
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
                    if (x >= 0 && x < 10 && y >= 0 && y < 10)
                    {
                        int square = Common.square_make(x, y);
                        if (this.data.square.v == square)
                        {
                            NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                            if (noneRuleInputUIData != null)
                            {
                                ClickNoneUI.UIData clickNoneUIData = new ClickNoneUI.UIData();
                                {
                                    clickNoneUIData.uid = noneRuleInputUIData.sub.makeId();
                                }
                                noneRuleInputUIData.sub.v = clickNoneUIData;
                            }
                            else
                            {
                                Debug.LogError("noneRuleInputUIData null: " + this);
                            }
                        }
                        else
                        {
                            if (Common.square_is_dark(x, y))
                            {
                                // send move
                                ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                                if (clientInput != null)
                                {
                                    InternationalDraughtCustomMove internationalDraughtCustomMove = new InternationalDraughtCustomMove();
                                    {
                                        internationalDraughtCustomMove.fromSquare.v = this.data.square.v;
                                        internationalDraughtCustomMove.destSquare.v = square;
                                    }
                                    clientInput.makeSend(internationalDraughtCustomMove);
                                }
                                else
                                {
                                    Debug.LogError("clientInput null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("not correct square: " + this);
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
                this.clickMove(this.data.keyX.v, this.data.keyY.v);
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            // Debug.LogError ("OnPointerDown: " + eventData);
            // get square
            Vector3 localPosition = transform.InverseTransformPoint(eventData.position);
            int x = 0;
            int y = 0;
            Common.convertLocalPositionToXY(localPosition, out x, out y);
            Debug.LogError("localPositition: " + localPosition + "; " + x + "; " + y);
            this.clickMove(x, y);
        }

        #region back

        public override void Awake()
        {
            base.Awake();
            // OnClick
            {

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
                NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                if (noneRuleInputUIData != null)
                {
                    ClickNoneUI.UIData clickNoneUIData = new ClickNoneUI.UIData();
                    {
                        clickNoneUIData.uid = noneRuleInputUIData.sub.makeId();
                    }
                    noneRuleInputUIData.sub.v = clickNoneUIData;
                }
                else
                {
                    Debug.LogError("noneRuleInputUIData null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

        #endregion

    }
}
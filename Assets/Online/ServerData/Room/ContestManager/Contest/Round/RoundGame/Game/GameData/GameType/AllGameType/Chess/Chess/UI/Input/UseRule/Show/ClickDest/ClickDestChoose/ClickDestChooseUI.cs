using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Chess.UseRule
{
    public class ClickDestChooseUI : UIBehavior<ClickDestChooseUI.UIData>, BtnChosenMoveUI.OnClick
    {

        #region UIData

        public class UIData : ClickDestUI.UIData.Sub
        {

            public VP<int> x;

            public VP<int> y;

            public LP<BtnChosenMoveUI.UIData> btnChosenMoves;

            #region Constructor

            public enum Property
            {
                x,
                y,
                btnChosenMoves
            }

            public UIData() : base()
            {
                this.x = new VP<int>(this, (byte)Property.x, 0);
                this.y = new VP<int>(this, (byte)Property.y, 0);
                this.btnChosenMoves = new LP<BtnChosenMoveUI.UIData>(this, (byte)Property.btnChosenMoves);
            }

            #endregion

            public override Type getType()
            {
                return Type.Choose;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // back
                    if (!isProcess)
                    {
                        if (InputEvent.isBackEvent(e))
                        {
                            ClickDestChooseUI clickDestChooseUI = this.findCallBack<ClickDestChooseUI>();
                            if (clickDestChooseUI != null)
                            {
                                clickDestChooseUI.onClickCancel();
                            }
                            else
                            {
                                Debug.LogError("clickDestChooseUI null: " + this);
                            }
                            isProcess = true;
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;

        public Button btnCancel;
        public Text tvCancel;

        #endregion

        #region Refresh

        public RectTransform contentContainer;
        public RectTransform scrollRect;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    List<ChessMove> chessMoves = new List<ChessMove>();
                    {
                        ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData>();
                        ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData>();
                        if (showUIData != null && clickDestUIData != null)
                        {
                            int fromX = clickDestUIData.x.v;
                            int fromY = clickDestUIData.y.v;
                            int destX = this.data.x.v;
                            int destY = this.data.y.v;
                            for (int i = 0; i < showUIData.legalMoves.vs.Count; i++)
                            {
                                ChessMove legalMove = showUIData.legalMoves.vs[i];
                                if (ChessMove.IsClickCorrectPosition(legalMove.move.v, fromX, fromY, destX, destY))
                                {
                                    chessMoves.Add(legalMove);
                                }
                            }
                        }
                    }
                    // contentContainer
                    {
                        if (contentContainer != null)
                        {
                            if (chessMoves.Count > 1)
                            {
                                contentContainer.gameObject.SetActive(true);
                            }
                            else
                            {
                                contentContainer.gameObject.SetActive(false);
                            }
                        }
                        else
                        {
                            Debug.LogError("contentContainer null: " + this);
                        }
                    }
                    // btnChoseMoves
                    if (chessMoves.Count == 0)
                    {
                        Debug.LogError("why chessMoves count = 0: " + this);
                        // chuyen ve ClickPieceUI
                        ShowUI.UIData showUI = this.data.findDataInParent<ShowUI.UIData>();
                        if (showUI != null)
                        {
                            ClickPieceUI.UIData clickPieceUIData = new ClickPieceUI.UIData();
                            {
                                clickPieceUIData.uid = showUI.sub.makeId();
                            }
                            showUI.sub.v = clickPieceUIData;
                        }
                        else
                        {
                            Debug.LogError("showUI null: " + this);
                        }
                    }
                    else if (chessMoves.Count == 1)
                    {
                        ChessMove chessMove = chessMoves[0];
                        // Send by clientInput
                        {
                            ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                            if (clientInput != null)
                            {
                                clientInput.makeSend(chessMove);
                            }
                            else
                            {
                                Debug.LogError("clientInput null: " + this);
                            }
                        }
                    }
                    else
                    {
                        List<BtnChosenMoveUI.UIData> oldBntChoseMoves = new List<BtnChosenMoveUI.UIData>();
                        // get olds
                        oldBntChoseMoves.AddRange(this.data.btnChosenMoves.vs);
                        // Update
                        {
                            for (int i = 0; i < chessMoves.Count; i++)
                            {
                                ChessMove chessMove = chessMoves[i];
                                // Find bntChoseMoveUI
                                BtnChosenMoveUI.UIData btnChoseMoveUIData = null;
                                {
                                    // Find old
                                    if (oldBntChoseMoves.Count > 0)
                                    {
                                        btnChoseMoveUIData = oldBntChoseMoves[0];
                                        oldBntChoseMoves.RemoveAt(0);
                                    }
                                    // Make new
                                    if (btnChoseMoveUIData == null)
                                    {
                                        btnChoseMoveUIData = new BtnChosenMoveUI.UIData();
                                        {
                                            btnChoseMoveUIData.uid = this.data.btnChosenMoves.makeId();
                                        }
                                        this.data.btnChosenMoves.add(btnChoseMoveUIData);
                                    }
                                }
                                // Update Property
                                if (btnChoseMoveUIData != null)
                                {
                                    // chessMove
                                    btnChoseMoveUIData.chessMove.v = new ReferenceData<ChessMove>(chessMove);
                                    // onClick
                                    btnChoseMoveUIData.onClick.v = this;
                                }
                                else
                                {
                                    Debug.LogError("btnChoseMoveUIData null: " + this);
                                }
                            }
                        }
                        // Remove old
                        for (int i = 0; i < oldBntChoseMoves.Count; i++)
                        {
                            this.data.btnChosenMoves.remove(oldBntChoseMoves[i]);
                        }
                    }
                    // UI
                    {
                        float buttonSize = Setting.get().getButtonSize();
                        float deltaY = 0;
                        // header
                        {
                            UIRectTransform.SetTitleTransform(lbTitle);
                            deltaY += buttonSize;
                        }
                        // scrollRect
                        {
                            UIRectTransform.SetPosY(scrollRect, deltaY);
                            deltaY += 80;
                        }
                        // btnCancel
                        {
                            if (btnCancel != null)
                            {
                                UIRectTransform.SetPosY((RectTransform)btnCancel.transform, deltaY + 10);
                            }
                            else
                            {
                                Debug.LogError("btnCancel null");
                            }
                            deltaY += 50;
                        }
                        // set height
                        if (contentContainer != null)
                        {
                            UIRectTransform.SetHeight(contentContainer, deltaY);
                        }
                        else
                        {
                            Debug.LogError("contentContainer null");
                        }
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = ClickPosTxt.txtClickDestChooseTitle.get();
                            Setting.get().setTitleTextSize(lbTitle);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                        if (tvCancel != null)
                        {
                            tvCancel.text = ClickPosTxt.txtCancel.get();
                        }
                        else
                        {
                            Debug.LogError("tvCancel null");
                        }
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                    if (contentContainer != null)
                    {
                        contentContainer.gameObject.SetActive(false);
                    }
                    else
                    {
                        Debug.LogError("contentContainer null: " + this);
                    }
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region Refresh

        public BtnChosenMoveUI btnChoseMovePrefab;
        public Transform btnChoseMovesContainter;

        private ShowUI.UIData showUIData = null;
        private ClickDestUI.UIData clickDestUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.showUIData);
                    DataUtils.addParentCallBack(uiData, this, ref this.clickDestUIData);
                }
                // Child
                {
                    uiData.btnChosenMoves.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Setting
            if (data is Setting)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                // showUIData
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
                    if (data is ChessMove)
                    {
                        dirty = true;
                        return;
                    }
                }
                // clickDestUIData
                if (data is ClickDestUI.UIData)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            {
                if (data is BtnChosenMoveUI.UIData)
                {
                    BtnChosenMoveUI.UIData btnChoseMoveUIData = data as BtnChosenMoveUI.UIData;
                    {
                        UIUtils.Instantiate(btnChoseMoveUIData, btnChoseMovePrefab, btnChoseMovesContainter);
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
                // Setting
                Setting.get().removeCallBack(this);
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.showUIData);
                    DataUtils.removeParentCallBack(uiData, this, ref this.clickDestUIData);
                }
                // Child
                {
                    uiData.btnChosenMoves.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Parent
            {
                // showUIData
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
                    if (data is ChessMove)
                    {
                        return;
                    }
                }
                // clickDestUIData
                if (data is ClickDestUI.UIData)
                {
                    return;
                }
            }
            // Child
            {
                if (data is BtnChosenMoveUI.UIData)
                {
                    BtnChosenMoveUI.UIData btnChoseMoveUIData = data as BtnChosenMoveUI.UIData;
                    // UI
                    {
                        btnChoseMoveUIData.removeCallBackAndDestroy(typeof(BtnChosenMoveUI));
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
                    case UIData.Property.x:
                        dirty = true;
                        break;
                    case UIData.Property.y:
                        dirty = true;
                        break;
                    case UIData.Property.btnChosenMoves:
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
            // Setting
            if (wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
                        dirty = true;
                        break;
                    case Setting.Property.style:
                        break;
                    case Setting.Property.contentTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.titleTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.labelTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.buttonSize:
                        dirty = true;
                        break;
                    case Setting.Property.confirmQuit:
                        break;
                    case Setting.Property.showLastMove:
                        break;
                    case Setting.Property.viewUrlImage:
                        break;
                    case Setting.Property.animationSetting:
                        break;
                    case Setting.Property.maxThinkCount:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Parent
            {
                // showUIData
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
                    if (wrapProperty.p is ChessMove)
                    {
                        switch ((ChessMove.Property)wrapProperty.n)
                        {
                            case ChessMove.Property.move:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                // clickDestUIData
                if (wrapProperty.p is ClickDestUI.UIData)
                {
                    switch ((ClickDestUI.UIData.Property)wrapProperty.n)
                    {
                        case ClickDestUI.UIData.Property.x:
                            dirty = true;
                            break;
                        case ClickDestUI.UIData.Property.y:
                            dirty = true;
                            break;
                        case ClickDestUI.UIData.Property.sub:
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
                if (wrapProperty.p is BtnChosenMoveUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickMove(ChessMove chessMove)
        {
            if (this.data != null)
            {
                // send move
                ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                if (clientInput != null)
                {
                    clientInput.makeSend(chessMove);
                }
                else
                {
                    Debug.LogError("clientInput null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void onClickCancel()
        {
            Debug.LogError("onClickCancel: " + this);
            if (this.data != null)
            {
                ShowUI.UIData showUI = this.data.findDataInParent<ShowUI.UIData>();
                if (showUI != null)
                {
                    ClickPieceUI.UIData clickPieceUIData = new ClickPieceUI.UIData();
                    {
                        clickPieceUIData.uid = showUI.sub.makeId();
                    }
                    showUI.sub.v = clickPieceUIData;
                }
                else
                {
                    Debug.LogError("showUI null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}
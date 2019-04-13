using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Shogi.UseRule
{
    public class DropPieceUI : UIBehavior<DropPieceUI.UIData>, BtnChosenMoveUI.OnClick
    {

        #region UIData

        public class UIData : ShowUI.UIData.Sub
        {

            public VP<Common.Square> square;

            public LP<BtnChosenMoveUI.UIData> btnChosenMoves;

            #region Constructor

            public enum Property
            {
                square,
                btnChosenMoves
            }

            public UIData() : base()
            {
                this.square = new VP<Common.Square>(this, (byte)Property.square, Common.Square.SQ11);
                this.btnChosenMoves = new LP<BtnChosenMoveUI.UIData>(this, (byte)Property.btnChosenMoves);
            }

            #endregion

            public override Type getType()
            {
                return Type.DropPiece;
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
                            DropPieceUI dropPieceUI = this.findCallBack<DropPieceUI>();
                            if (dropPieceUI != null)
                            {
                                dropPieceUI.onClickCancel();
                            }
                            else
                            {
                                Debug.LogError("dropPieceUI null: " + this);
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
                    List<ShogiMove> shogiMoves = new List<ShogiMove>();
                    {
                        ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData>();
                        if (showUIData != null)
                        {
                            for (int i = 0; i < showUIData.legalMoves.vs.Count; i++)
                            {
                                ShogiMove legalMove = showUIData.legalMoves.vs[i];
                                if (legalMove.isDrop())
                                {
                                    if (legalMove.to() == this.data.square.v)
                                    {
                                        shogiMoves.Add(legalMove);
                                    }
                                }
                            }
                        }
                    }
                    // contentContainer
                    {
                        if (contentContainer != null)
                        {
                            if (shogiMoves.Count >= 1)
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
                    if (shogiMoves.Count == 0)
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
                    else
                    {
                        List<BtnChosenMoveUI.UIData> oldBtnChoseMoves = new List<BtnChosenMoveUI.UIData>();
                        // get olds
                        oldBtnChoseMoves.AddRange(this.data.btnChosenMoves.vs);
                        // Update
                        {
                            for (int i = 0; i < shogiMoves.Count; i++)
                            {
                                ShogiMove shogiMove = shogiMoves[i];
                                // Find bntChoseMoveUI
                                BtnChosenMoveUI.UIData btnChoseMoveUIData = null;
                                {
                                    // Find old
                                    if (oldBtnChoseMoves.Count > 0)
                                    {
                                        btnChoseMoveUIData = oldBtnChoseMoves[0];
                                        oldBtnChoseMoves.RemoveAt(0);
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
                                    btnChoseMoveUIData.shogiMove.v = new ReferenceData<ShogiMove>(shogiMove);
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
                        foreach (BtnChosenMoveUI.UIData oldBtnChoseMove in oldBtnChoseMoves)
                        {
                            this.data.btnChosenMoves.remove(oldBtnChoseMove);
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
                            lbTitle.text = ClickPosTxt.txtDropPieceTitle.get();
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

        #region implement callBacks

        public BtnChosenMoveUI btnChoseMovePrefab;
        public Transform btnChoseMovesContainter;

        private ShowUI.UIData showUIData = null;

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
                    // Child
                    if (data is ShogiMove)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // Child
            {
                if (data is BtnChosenMoveUI.UIData)
                {
                    BtnChosenMoveUI.UIData btnChoseMoveUIData = data as BtnChosenMoveUI.UIData;
                    // UI
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
                    // Child
                    if (data is ShogiMove)
                    {
                        return;
                    }
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
                    case UIData.Property.square:
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
                    // Child
                    if (wrapProperty.p is ShogiMove)
                    {
                        switch ((ShogiMove.Property)wrapProperty.n)
                        {
                            case ShogiMove.Property.move:
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

        public void onClickMove(ShogiMove shogiMove)
        {
            if (this.data != null)
            {
                // Send
                ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                if (clientInput != null)
                {
                    clientInput.makeSend(shogiMove);
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
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace HEX
{
    public class HexMoveUI : UIBehavior<HexMoveUI.UIData>
    {

        #region UIData

        public class UIData : LastMoveSub
        {

            public VP<ReferenceData<HexMove>> hexMove;

            public VP<bool> isHint;

            #region Constructor

            public enum Property
            {
                hexMove,
                isHint
            }

            public UIData() : base()
            {
                this.hexMove = new VP<ReferenceData<HexMove>>(this, (byte)Property.hexMove, new ReferenceData<HexMove>(null));
                this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
            }

            #endregion

            public override GameMove.Type getType()
            {
                return GameMove.Type.HexMove;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Hex ? 1 : 0;
        }

        #region Refresh

        public GameObject contentContainer;
        public UILineRenderer lineRenderer;

        public Image imgHint;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    HexMove hexMove = this.data.hexMove.v.data;
                    if (hexMove != null)
                    {
                        // find boardUIData
                        BoardUI.UIData boardUIData = null;
                        {
                            HexGameDataUI.UIData hexGameDataUIData = this.data.findDataInParent<HexGameDataUI.UIData>();
                            if (hexGameDataUIData != null)
                            {
                                boardUIData = hexGameDataUIData.board.v;
                            }
                            else
                            {
                                Debug.LogError("hexGameDataUIData null: " + this);
                            }
                        }
                        // Process
                        if (boardUIData != null)
                        {
                            if (boardUIData.boardSize.v >= Hex.MIN_BOARD_SIZE && boardUIData.boardSize.v <= Hex.MAX_BOARD_SIZE)
                            {
                                System.UInt16 x = 0;
                                System.UInt16 y = 0;
                                {
                                    if (boardUIData.boardSize.v > 0)
                                    {
                                        x = (System.UInt16)(hexMove.move.v % boardUIData.boardSize.v);
                                        y = (System.UInt16)(hexMove.move.v / boardUIData.boardSize.v);
                                    }
                                    else
                                    {
                                        Debug.LogError("why board size too small: " + this);
                                    }
                                }
                                // check inside board or not
                                bool isInsideBoard = false;
                                {
                                    if (x >= 0 && x < boardUIData.boardSize.v && y >= 0 && y < boardUIData.boardSize.v)
                                    {
                                        isInsideBoard = true;
                                    }
                                }
                                // Process
                                if (isInsideBoard)
                                {
                                    // lineRenderer
                                    if (lineRenderer != null)
                                    {
                                        // find localPos
                                        Vector2 localPos = Common.GetLocalPosition(x, y, boardUIData);
                                        // Make point list
                                        {
                                            Vector2[] points = new Vector2[5];
                                            {
                                                points[0] = new Vector2(localPos.x + 0.5f, localPos.y + 0.5f);
                                                points[1] = new Vector2(localPos.x - 0.5f, localPos.y + 0.5f);
                                                points[2] = new Vector2(localPos.x - 0.5f, localPos.y - 0.5f);
                                                points[3] = new Vector2(localPos.x + 0.5f, localPos.y - 0.5f);
                                                points[4] = new Vector2(localPos.x + 0.5f, localPos.y + 0.5f);
                                            }
                                            lineRenderer.Points = points;
                                        }
                                        // color
                                        lineRenderer.color = this.data.isHint.v ? Global.HintColor : Global.NormalColor;
                                    }
                                    else
                                    {
                                        Debug.LogError("lineRender null: " + this);
                                    }
                                    // imgHint
                                    if (imgHint != null)
                                    {
                                        if (this.data.isHint.v)
                                        {
                                            imgHint.enabled = true;
                                            switch (hexMove.color.v)
                                            {
                                                case Common.Color.Red:
                                                    imgHint.color = new Color(1, 0, 0, 0.5f);
                                                    break;
                                                case Common.Color.Blue:
                                                    imgHint.color = new Color(0, 0, 1, 0.5f);
                                                    break;
                                                case Common.Color.Empty:
                                                    imgHint.color = Global.TransparentColor;
                                                    break;
                                                default:
                                                    Debug.LogError("unknown color: " + hexMove.color.v + "; " + this);
                                                    imgHint.color = Global.TransparentColor;
                                                    break;
                                            }
                                            // position
                                            {
                                                imgHint.transform.localPosition = Common.GetLocalPosition(x, y, boardUIData);
                                            }
                                            // scale
                                            {
                                                int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                                imgHint.gameObject.transform.localScale = (playerView == 0 ? new Vector3(1, 1, 1) : new Vector3(1, -1, 1));
                                            }
                                        }
                                        else
                                        {
                                            imgHint.enabled = false;
                                            imgHint.color = Global.TransparentColor;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("imgHint null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("not inside board");
                                }
                            }
                            else
                            {
                                Debug.LogError("boardSize error: " + boardUIData.boardSize.v + "; " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("boardUIData null: " + this);
                        }
                    }
                    else
                    {
                        // Debug.LogError ("hexMove null: " + this);
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

        private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();
        private HexGameDataUI.UIData hexGameDataUIData = null;

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
                    DataUtils.addParentCallBack(uiData, this, ref this.hexGameDataUIData);
                }
                // Child
                {
                    uiData.hexMove.allAddCallBack(this);
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
                if (data is HexGameDataUI.UIData)
                {
                    HexGameDataUI.UIData hexGameDataUIData = data as HexGameDataUI.UIData;
                    // Child
                    {
                        hexGameDataUIData.board.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is BoardUI.UIData)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            if (data is HexMove)
            {
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
                // CheckChange
                {
                    perspectiveChange.removeCallBack(this);
                    perspectiveChange.setData(null);
                }
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.hexGameDataUIData);
                }
                // Child
                {
                    uiData.hexMove.allRemoveCallBack(this);
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
                if (data is HexGameDataUI.UIData)
                {
                    HexGameDataUI.UIData hexGameDataUIData = data as HexGameDataUI.UIData;
                    // Child
                    {
                        hexGameDataUIData.board.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is BoardUI.UIData)
                {
                    return;
                }
            }
            // Child
            if (data is HexMove)
            {
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
                    case UIData.Property.hexMove:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.isHint:
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
                if (wrapProperty.p is HexGameDataUI.UIData)
                {
                    switch ((HexGameDataUI.UIData.Property)wrapProperty.n)
                    {
                        case HexGameDataUI.UIData.Property.gameData:
                            break;
                        case HexGameDataUI.UIData.Property.transformOrganizer:
                            break;
                        case HexGameDataUI.UIData.Property.isOnAnimation:
                            break;
                        case HexGameDataUI.UIData.Property.board:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case HexGameDataUI.UIData.Property.lastMove:
                            break;
                        case HexGameDataUI.UIData.Property.showHint:
                            break;
                        case HexGameDataUI.UIData.Property.inputUI:
                            break;
                        default:
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is BoardUI.UIData)
                {
                    switch ((BoardUI.UIData.Property)wrapProperty.n)
                    {
                        case BoardUI.UIData.Property.hex:
                            break;
                        case BoardUI.UIData.Property.boardSize:
                            dirty = true;
                            break;
                        case BoardUI.UIData.Property.pieces:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            // Child
            if (wrapProperty.p is HexMove)
            {
                switch ((HexMove.Property)wrapProperty.n)
                {
                    case HexMove.Property.move:
                        dirty = true;
                        break;
                    case HexMove.Property.boardSize:
                        dirty = true;
                        break;
                    case HexMove.Property.color:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
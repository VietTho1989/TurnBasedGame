using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace Reversi
{
    public class ReversiMoveUI : UIBehavior<ReversiMoveUI.UIData>
    {

        #region UIData

        public class UIData : LastMoveSub
        {

            public VP<ReferenceData<ReversiMove>> reversiMove;

            public VP<bool> isHint;

            #region Constructor

            public enum Property
            {
                reversiMove,
                isHint
            }

            public UIData() : base()
            {
                this.reversiMove = new VP<ReferenceData<ReversiMove>>(this, (byte)Property.reversiMove, new ReferenceData<ReversiMove>(null));
                this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
            }

            #endregion

            public override GameMove.Type getType()
            {
                return GameMove.Type.ReversiMove;
            }
        }

        #endregion

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
                    ReversiMove reversiMove = this.data.reversiMove.v.data;
                    if (reversiMove != null)
                    {
                        // contentContainer
                        if (contentContainer != null)
                        {
                            if (reversiMove.move.v >= 0 && reversiMove.move.v < 64)
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
                        // Find Reversi
                        Reversi reversi = null;
                        {
                            ReversiGameDataUI.UIData reversiGameDataUIData = this.data.findDataInParent<ReversiGameDataUI.UIData>();
                            if (reversiGameDataUIData != null)
                            {
                                GameData gameData = reversiGameDataUIData.gameData.v.data;
                                if (gameData != null)
                                {
                                    if (gameData.gameType.v != null && gameData.gameType.v is Reversi)
                                    {
                                        reversi = gameData.gameType.v as Reversi;
                                    }
                                    else
                                    {
                                        Debug.LogError("reversi null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameData null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("reversiGameDataUIData null: " + this);
                            }
                        }
                        // get coord
                        int x = reversiMove.move.v % 8;
                        int y = 7 - reversiMove.move.v / 8;
                        // UILineRenderer
                        if (lineRenderer != null)
                        {
                            Vector2[] points = new Vector2[5];
                            {
                                float radius = 0.25f;
                                points[0] = new Vector2(x + radius - 8 / 2.0f + 0.5f, y + radius - 8 / 2.0f + 0.5f);
                                points[1] = new Vector2(x - radius - 8 / 2.0f + 0.5f, y + radius - 8 / 2.0f + 0.5f);
                                points[2] = new Vector2(x - radius - 8 / 2.0f + 0.5f, y - radius - 8 / 2.0f + 0.5f);
                                points[3] = new Vector2(x + radius - 8 / 2.0f + 0.5f, y - radius - 8 / 2.0f + 0.5f);
                                points[4] = new Vector2(x + radius - 8 / 2.0f + 0.5f, y + radius - 8 / 2.0f + 0.5f);
                            }
                            lineRenderer.Points = points;
                        }
                        else
                        {
                            Debug.LogError("lineRenderer null: " + this);
                        }
                        // imgHint
                        if (imgHint != null)
                        {
                            if (this.data.isHint.v)
                            {
                                // sprite
                                {
                                    // find playerIndex
                                    int playerIndex = 0;
                                    {
                                        if (reversi != null)
                                        {
                                            playerIndex = reversi.getPlayerIndex();
                                        }
                                        else
                                        {
                                            Debug.LogError("reversi null: " + this);
                                        }
                                    }
                                    // process: black move first
                                    imgHint.sprite = ReversiSpriteContainer.get().getSprite(playerIndex == 0 ? Reversi.BLACK : Reversi.WHITE);
                                }
                                // position
                                imgHint.transform.localPosition = new Vector3(x - 8 / 2.0f + 0.5f, y - 8 / 2.0f + 0.5f, 0);
                            }
                            else
                            {
                                imgHint.sprite = ReversiSpriteContainer.get().getSprite(-1);
                            }
                            // scale
                            {
                                int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                imgHint.gameObject.transform.localScale = (playerView == 0 ? new Vector3(1, 1, 1) : new Vector3(1, -1, 1));
                            }
                        }
                        else
                        {
                            Debug.LogError("imgHint null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("reversiMove null: " + this);
                        // contentContainer
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

        private ReversiGameDataUI.UIData reversiGameDataUIData = null;
        private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();

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
                    DataUtils.addParentCallBack(uiData, this, ref this.reversiGameDataUIData);
                }
                // Child
                {
                    uiData.reversiMove.allAddCallBack(this);
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
                if (data is ReversiGameDataUI.UIData)
                {
                    ReversiGameDataUI.UIData reversiGameDataUIData = data as ReversiGameDataUI.UIData;
                    // Child
                    {
                        reversiGameDataUIData.gameData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // GameData
                {
                    if (data is GameData)
                    {
                        GameData gameData = data as GameData;
                        {
                            gameData.gameType.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    if (data is GameType)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // Child
            if (data is ReversiMove)
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.reversiGameDataUIData);
                }
                // Child
                {
                    uiData.reversiMove.allRemoveCallBack(this);
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
                if (data is ReversiGameDataUI.UIData)
                {
                    ReversiGameDataUI.UIData reversiGameDataUIData = data as ReversiGameDataUI.UIData;
                    // Child
                    {
                        reversiGameDataUIData.gameData.allRemoveCallBack(this);
                    }
                    return;
                }
                // GameData
                {
                    if (data is GameData)
                    {
                        GameData gameData = data as GameData;
                        // Child
                        {
                            gameData.gameType.allRemoveCallBack(this);
                        }
                        return;
                    }
                    if (data is GameType)
                    {
                        return;
                    }
                }
            }
            // Child
            if (data is ReversiMove)
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
                    case UIData.Property.reversiMove:
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
                if (wrapProperty.p is ReversiGameDataUI.UIData)
                {
                    switch ((ReversiGameDataUI.UIData.Property)wrapProperty.n)
                    {
                        case ReversiGameDataUI.UIData.Property.gameData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case ReversiGameDataUI.UIData.Property.transformOrganizer:
                            break;
                        case ReversiGameDataUI.UIData.Property.board:
                            break;
                        case ReversiGameDataUI.UIData.Property.isOnAnimation:
                            break;
                        case ReversiGameDataUI.UIData.Property.lastMove:
                            break;
                        case ReversiGameDataUI.UIData.Property.showHint:
                            break;
                        case ReversiGameDataUI.UIData.Property.inputUI:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // GameData
                {
                    if (wrapProperty.p is GameData)
                    {
                        switch ((GameData.Property)wrapProperty.n)
                        {
                            case GameData.Property.gameType:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case GameData.Property.useRule:
                                break;
                            case GameData.Property.turn:
                                break;
                            case GameData.Property.timeControl:
                                break;
                            case GameData.Property.lastMove:
                                break;
                            case GameData.Property.state:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    if (wrapProperty.p is GameType)
                    {
                        if (wrapProperty.p is Reversi)
                        {
                            switch ((Reversi.Property)wrapProperty.n)
                            {
                                case Reversi.Property.side:
                                    dirty = true;
                                    break;
                                case Reversi.Property.white:
                                    break;
                                case Reversi.Property.black:
                                    break;
                                case Reversi.Property.nMoveNum:
                                    break;
                                case Reversi.Property.moves:
                                    break;
                                case Reversi.Property.changes:
                                    break;
                                case Reversi.Property.oldSides:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        return;
                    }
                }
            }
            // Child
            if (wrapProperty.p is ReversiMove)
            {
                switch ((ReversiMove.Property)wrapProperty.n)
                {
                    case ReversiMove.Property.move:
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
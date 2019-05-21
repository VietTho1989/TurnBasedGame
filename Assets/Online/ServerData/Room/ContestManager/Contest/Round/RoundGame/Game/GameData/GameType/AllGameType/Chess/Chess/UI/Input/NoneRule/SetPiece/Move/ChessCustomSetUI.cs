using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Chess.NoneRule
{
    public class ChessCustomSetUI : UIBehavior<ChessCustomSetUI.UIData>
    {

        #region UIData

        public class UIData : LastMoveSub
        {

            public VP<ReferenceData<ChessCustomSet>> chessCustomSet;

            public VP<bool> isHint;

            #region Constructor

            public enum Property
            {
                chessCustomSet,
                isHint
            }

            public UIData() : base()
            {
                this.chessCustomSet = new VP<ReferenceData<ChessCustomSet>>(this, (byte)Property.chessCustomSet, new ReferenceData<ChessCustomSet>(null));
                this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
            }

            #endregion

            public override GameMove.Type getType()
            {
                return GameMove.Type.ChessCustomSet;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.CHESS ? 1 : 0;
        }

        #region Refresh

        public UILineRenderer lineRenderer;

        public Image imgHint;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    ChessCustomSet chessCustomSet = this.data.chessCustomSet.v.data;
                    if (chessCustomSet != null)
                    {
                        // lineRenderer
                        if (lineRenderer != null)
                        {
                            Vector2[] points = new Vector2[5];
                            {
                                Vector3 localPos = Common.convertXYToLocalPosition(chessCustomSet.x.v, chessCustomSet.y.v);
                                points[0] = new Vector2(localPos.x + 0.5f, localPos.y + 0.5f);
                                points[1] = new Vector2(localPos.x - 0.5f, localPos.y + 0.5f);
                                points[2] = new Vector2(localPos.x - 0.5f, localPos.y - 0.5f);
                                points[3] = new Vector2(localPos.x + 0.5f, localPos.y - 0.5f);
                                points[4] = new Vector2(localPos.x + 0.5f, localPos.y + 0.5f);
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
                                imgHint.sprite = ChessSpriteContainer.get().getSprite(chessCustomSet.piece.v);
                                // position
                                {
                                    imgHint.transform.localPosition = Common.convertXYToLocalPosition(chessCustomSet.x.v, chessCustomSet.y.v);
                                }
                                // scale
                                {
                                    int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                    imgHint.gameObject.transform.localScale = (playerView == 0 ? new Vector3(1, 1, 1) : new Vector3(1, -1, 1));
                                }
                            }
                            else
                            {
                                imgHint.sprite = ChessSpriteContainer.get().getSprite(Common.Piece.NO_PIECE);
                            }
                        }
                        else
                        {
                            Debug.LogError("imgHint null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("chessCustomSet null: " + this);
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
                // Child
                {
                    uiData.chessCustomSet.allAddCallBack(this);
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
            // Child
            if (data is ChessCustomSet)
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
                // Child
                {
                    uiData.chessCustomSet.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // CheckChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                return;
            }
            // Child
            if (data is ChessCustomSet)
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
                    case UIData.Property.chessCustomSet:
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
            // Child
            if (wrapProperty.p is ChessCustomSet)
            {
                switch ((ChessCustomSet.Property)wrapProperty.n)
                {
                    case ChessCustomSet.Property.x:
                        dirty = true;
                        break;
                    case ChessCustomSet.Property.y:
                        dirty = true;
                        break;
                    case ChessCustomSet.Property.piece:
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
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess.UseRule
{
    public class LegalMoveUI : UIBehavior<LegalMoveUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<FairyChessMove>> legalMove;

            #region Constructor

            public enum Property
            {
                legalMove
            }

            public UIData() : base()
            {
                this.legalMove = new VP<ReferenceData<FairyChessMove>>(this, (byte)Property.legalMove, new ReferenceData<FairyChessMove>(null));
            }

            #endregion

        }

        #endregion

        #region Refresh

        public GameObject contentContainer;

        public UICircle ivType;
        private static readonly Color normalColor = Color.blue;
        private static readonly Color promotionColor = Color.yellow;
        private static readonly Color passantColor = Color.gray;
        private static readonly Color castlingColor = Color.green;
        private static readonly Color piece_promotionColor = Color.magenta;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // contentContainer
                    if (contentContainer != null)
                    {
                        if (this.data.legalMove.v.data != null)
                        {
                            contentContainer.SetActive(true);
                        }
                        else
                        {
                            contentContainer.SetActive(false);
                        }
                    }
                    else
                    {
                        Debug.LogError("contentContainer null: " + this);
                    }
                    // Update
                    {
                        FairyChessMove legalMove = this.data.legalMove.v.data;
                        if (legalMove != null)
                        {
                            // position
                            {
                                int fromX = 0;
                                int fromY = 0;
                                int destX = 0;
                                int destY = 0;
                                FairyChessMove.GetClickPosition(legalMove.move.v, out fromX, out fromY, out destX, out destY);
                                this.transform.localPosition = new Vector3(destX - 3.5f, destY - 3.5f, 0);
                            }
                            // imgType
                            if (ivType != null)
                            {
                                FairyChessMove.Move move = new FairyChessMove.Move(legalMove.move.v);
                                switch (move.type)
                                {
                                    case Common.MoveType.NORMAL:
                                        ivType.color = normalColor;
                                        break;
                                    case Common.MoveType.PROMOTION:
                                        ivType.color = promotionColor;
                                        break;
                                    case Common.MoveType.ENPASSANT:
                                        ivType.color = passantColor;
                                        break;
                                    case Common.MoveType.CASTLING:
                                        ivType.color = castlingColor;
                                        break;
                                    case Common.MoveType.PIECE_PROMOTION:
                                        ivType.color = piece_promotionColor;
                                        break;
                                    default:
                                        Debug.LogError("unknown move type: " + move.type + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("imgType null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("legalMove null: " + this);
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

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.legalMove.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            if (data is FairyChessMove)
            {
                // FairyChessMove legalMove = data as FairyChessMove;
                {

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
                {
                    uiData.legalMove.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            if (data is FairyChessMove)
            {
                // FairyChessMove legalMove = data as FairyChessMove;
                {

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
                    case UIData.Property.legalMove:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    default:
                        Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            if (wrapProperty.p is FairyChessMove)
            {
                switch ((FairyChessMove.Property)wrapProperty.n)
                {
                    case FairyChessMove.Property.move:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
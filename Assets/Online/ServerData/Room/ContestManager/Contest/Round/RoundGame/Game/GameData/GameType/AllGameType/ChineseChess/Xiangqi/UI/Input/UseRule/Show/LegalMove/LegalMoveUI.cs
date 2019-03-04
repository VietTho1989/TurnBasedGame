using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi.UseRule
{
    public class LegalMoveUI : UIBehavior<LegalMoveUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<LegalMove>> legalMove;

            #region Constructor

            public enum Property
            {
                legalMove
            }

            public UIData() : base()
            {
                this.legalMove = new VP<ReferenceData<LegalMove>>(this, (byte)Property.legalMove, new ReferenceData<LegalMove>(null));
            }

            #endregion

        }

        #endregion

        #region Refresh

        private static readonly Color colorNone = Color.blue;
        private static readonly Color colorDraw = Color.magenta;
        private static readonly Color colorLoss = new Color(255 / 255.0f, 102/255.0f, 0);
        private static readonly Color colorWin = Color.red;

        public UICircle ivType;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // Image
                    {
                        if (ivType != null)
                        {
                            // Sprite
                            LegalMove legalMove = this.data.legalMove.v.data;
                            if (legalMove != null)
                            {
                                ivType.gameObject.SetActive(true);
                                switch (legalMove.repStatus.v)
                                {
                                    case (int)Common.RepStatus.REP_NONE:
                                        ivType.color = colorNone;
                                        break;
                                    case (int)Common.RepStatus.REP_DRAW:
                                        ivType.color = colorDraw;
                                        break;
                                    case (int)Common.RepStatus.REP_LOSS:
                                        ivType.color = colorLoss;
                                        break;
                                    case (int)Common.RepStatus.REP_WIN:
                                        ivType.color = colorWin;
                                        break;
                                    default:
                                        Debug.LogError("unknown repStatus: " + this);
                                        ivType.color = colorNone;
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("legalMove null: " + this);
                                ivType.gameObject.SetActive(false);
                            }
                            // Scale
                            {
                                int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                ivType.transform.localScale = (playerView == 0 ? new Vector3(1, 1, 1) : new Vector3(1, -1, 1));
                            }
                        }
                        else
                        {
                            Debug.LogError("imgLegal null: " + this);
                        }
                    }
                    // Position
                    {
                        LegalMove legalMove = this.data.legalMove.v.data;
                        if (legalMove != null)
                        {
                            Common.MoveStruct moveStruct = new Common.MoveStruct(legalMove.move.v);
                            this.transform.localPosition = new Vector3(moveStruct.destX - 4f, moveStruct.destY - 4.5f, 0);
                        }
                        else
                        {
                            // Debug.LogError ("legalMove null: " + this);
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
                    uiData.legalMove.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // checkChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Child
            if (data is LegalMove)
            {
                // LegalMove legalMove = data as LegalMove;
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
                // CheckChange
                {
                    perspectiveChange.removeCallBack(this);
                    perspectiveChange.setData(null);
                }
                // Child
                {
                    uiData.legalMove.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // checkChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                return;
            }
            // Child
            if (data is LegalMove)
            {
                // LegalMove legalMove = data as LegalMove;
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
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Check Change
            if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Child
            if (wrapProperty.p is LegalMove)
            {
                switch ((LegalMove.Property)wrapProperty.n)
                {
                    case LegalMove.Property.move:
                        dirty = true;
                        break;
                    case LegalMove.Property.repStatus:
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
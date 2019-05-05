using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CoTuongUp.NoneRule
{
    public class ChoosePieceHolder : SriaHolderBehavior<ChoosePieceHolder.UIData>
    {

        #region UIData

        public class UIData : BaseItemViewsHolder
        {

            public VP<byte> piece;

            #region Constructor

            public enum Property
            {
                piece
            }

            public UIData() : base()
            {
                this.piece = new VP<byte>(this, (byte)Property.piece, Common.x);
            }

            #endregion

            public void updateView(ChoosePieceAdapter.UIData myParams)
            {
                // Find
                byte piece = Common.x;
                {
                    if (ItemIndex >= 0 && ItemIndex < myParams.pieces.Count)
                    {
                        piece = myParams.pieces[ItemIndex];
                    }
                    else
                    {
                        Debug.LogError("ItemIdex error: " + this);
                    }
                }
                // Update
                this.piece.v = piece;
            }

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            ChoosePieceHolder choosePieceHolder = this.findCallBack<ChoosePieceHolder>();
                            if (choosePieceHolder != null)
                            {
                                isProcess = choosePieceHolder.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("choosePieceHolder null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        public Text tvChoose;

        #endregion

        #region Refresh

        public Image imgPiece;

        public override void refresh()
        {
            base.refresh();
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // imgPiece
                    {
                        if (imgPiece != null)
                        {
                            imgPiece.sprite = CoTuongUpSpriteContainer.get().getSprite(this.data.piece.v, Setting.get().style.v);
                        }
                        else
                        {
                            Debug.LogError("imgPiece null: " + this);
                        }
                    }
                    // txt
                    {
                        if (tvChoose != null)
                        {
                            tvChoose.text = ClickPosTxt.txtChoose.get();
                        }
                        else
                        {
                            Debug.LogError("tvChoose null");
                        }
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        #endregion

        #region implement callBacks

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                // Setting
                Setting.get().addCallBack(this);
                dirty = true;
                return;
            }
            // Setting
            if (data is Setting)
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
                // Setting
                Setting.get().removeCallBack(this);
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
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
                    case UIData.Property.piece:
                        dirty = true;
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
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnChoose()
        {
            if (this.data != null)
            {
                // Find ClientInput
                ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                // Process
                if (clientInput != null)
                {
                    CoTuongUpCustomSet coTuongUpCustomSet = new CoTuongUpCustomSet();
                    {
                        // coord
                        {
                            SetPieceUI.UIData setPieceUIData = this.data.findDataInParent<SetPieceUI.UIData>();
                            if (setPieceUIData != null)
                            {
                                coTuongUpCustomSet.coord.v = setPieceUIData.coord.v;
                            }
                            else
                            {
                                Debug.LogError("setPieceUIData null: " + this);
                            }
                        }
                        // piece
                        {
                            // find piece
                            byte piece = this.data.piece.v;
                            {
                                // find isHide
                                bool isHide = false;
                                {
                                    SetPieceUI.UIData setPieceUIData = this.data.findDataInParent<SetPieceUI.UIData>();
                                    if (setPieceUIData != null)
                                    {
                                        SetPieceUI setPieceUI = setPieceUIData.findCallBack<SetPieceUI>();
                                        if (setPieceUI != null)
                                        {
                                            if (setPieceUI.tgHide != null)
                                            {
                                                isHide = setPieceUI.tgHide.isOn;
                                            }
                                            else
                                            {
                                                Debug.LogError("tgHide null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("setPieceUI null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("setPieceUIData null: " + this);
                                    }
                                }
                                // process
                                if (isHide)
                                {
                                    piece = Common.Visibility.hide(piece);
                                }
                            }
                            coTuongUpCustomSet.piece.v = piece;
                        }
                    }
                    clientInput.makeSend(coTuongUpCustomSet);
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

    }
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris
{
    public class BoardPhaseUI : UIBehavior<BoardPhaseUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            #region Constructor

            public enum Property
            {

            }

            public UIData() : base()
            {

            }

            #endregion

        }

        #endregion

        #region txt

        public Text tvPhase;
        private static readonly TxtLanguage txtPosition = new TxtLanguage("Phase Position");
        private static readonly TxtLanguage txtPlay = new TxtLanguage("Phase Play");
        private static readonly TxtLanguage txtFly = new TxtLanguage("Phase Fly");

        static BoardPhaseUI()
        {
            txtPosition.add(Language.Type.vi, "Giai Đoạn Đặt Quân");
            txtPlay.add(Language.Type.vi, "Giai Đoạn Chơi");
            txtFly.add(Language.Type.vi, "Giai Đoạn Bay");
        }

        #endregion

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // find phase
                    BoardUI.UIData.Phase phase = BoardUI.UIData.Phase.Position;
                    {
                        BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData>();
                        if (boardUIData != null)
                        {
                            phase = boardUIData.phase.v;
                        }
                        else
                        {
                            Debug.LogError("boardUIData null");
                        }
                    }
                    // set
                    if (tvPhase != null)
                    {
                        switch (phase)
                        {
                            case BoardUI.UIData.Phase.Position:
                                tvPhase.text = txtPosition.get();
                                break;
                            case BoardUI.UIData.Phase.Play:
                                tvPhase.text = txtPlay.get();
                                break;
                            case BoardUI.UIData.Phase.Fly:
                                tvPhase.text = txtFly.get();
                                break;
                            default:
                                Debug.LogError("unknown phase: " + phase);
                                break;
                        }
                        // show or not
                        {
                            bool show = true;
                            {
                                MiniGameDataUI.UIData miniGameDataUIData = this.data.findDataInParent<MiniGameDataUI.UIData>();
                                if (miniGameDataUIData != null)
                                {
                                    show = false;
                                }
                                else
                                {
                                    Debug.LogError("miniGameDataUIData null");
                                }
                            }
                            tvPhase.enabled = show;
                        }
                    }
                    else
                    {
                        Debug.LogError("tvPhase null");
                    }
                }
                else
                {
                    Debug.LogError("data null");
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        private BoardUI.UIData boardUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if(data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.boardUIData);
                }
                dirty = true;
                return;
            }
            // Setting
            if(data is Setting)
            {
                dirty = true;
                return;
            }
            // Parent
            if(data is BoardUI.UIData)
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
                Setting.get().addCallBack(this);
                // Child
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.boardUIData);
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
            if (data is BoardUI.UIData)
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
            if (wrapProperty.p is BoardUI.UIData)
            {
                switch ((BoardUI.UIData.Property)wrapProperty.n)
                {
                    case BoardUI.UIData.Property.nineMenMorris:
                        break;
                    case BoardUI.UIData.Property.pieces:
                        break;
                    case BoardUI.UIData.Property.phase:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
        }

        #endregion

    }
}
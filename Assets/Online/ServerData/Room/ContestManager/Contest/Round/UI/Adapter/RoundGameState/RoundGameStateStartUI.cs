using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameState;

namespace GameManager.Match
{
    public class RoundGameStateStartUI : UIBehavior<RoundGameStateStartUI.UIData>
    {

        #region UIData

        public class UIData : ChooseRoundGameHolder.UIData.StateUI
        {

            public VP<ReferenceData<Start>> start;

            #region Constructor

            public enum Property
            {
                start
            }

            public UIData() : base()
            {
                this.start = new VP<ReferenceData<Start>>(this, (byte)Property.start, new ReferenceData<Start>(null));
            }

            #endregion

            public override State.Type getType()
            {
                return State.Type.Start;
            }

        }

        #endregion

        #region txt

        public Text tvMessage;
        private static readonly TxtLanguage txtMessage = new TxtLanguage("Starting");

        static RoundGameStateStartUI()
        {
            txtMessage.add(Language.Type.vi, "Đang Bắt Đầu");
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
                    Start start = this.data.start.v.data;
                    if (start != null)
                    {

                    }
                    else
                    {
                        Debug.LogError("start null: " + this);
                    }
                    // txt
                    {
                        if (tvMessage != null)
                        {
                            tvMessage.text = txtMessage.get();
                        }
                        else
                        {
                            Debug.LogError("tvMessage null: " + this);
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
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.start.allAddCallBack(this);
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
            // Child
            if (data is Start)
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
                // Child
                {
                    uiData.start.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Child
            if (data is Start)
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
                    case UIData.Property.start:
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
            // Child
            if (wrapProperty.p is Start)
            {
                switch ((Start.Property)wrapProperty.n)
                {
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
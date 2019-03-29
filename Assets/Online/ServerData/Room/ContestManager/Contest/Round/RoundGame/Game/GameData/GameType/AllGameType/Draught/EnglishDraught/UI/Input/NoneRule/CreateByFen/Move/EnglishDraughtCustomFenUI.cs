using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught.NoneRule
{
    public class EnglishDraughtCustomFenUI : UIBehavior<EnglishDraughtCustomFenUI.UIData>
    {

        #region UIData

        public class UIData : LastMoveSub
        {

            public VP<ReferenceData<EnglishDraughtCustomFen>> englishDraughtCustomFen;

            public VP<bool> isHint;

            #region Constructor

            public enum Property
            {
                englishDraughtCustomFen,
                isHint
            }

            public UIData() : base()
            {
                this.englishDraughtCustomFen = new VP<ReferenceData<EnglishDraughtCustomFen>>(this, (byte)Property.englishDraughtCustomFen, new ReferenceData<EnglishDraughtCustomFen>(null));
                this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
            }

            #endregion

            public override GameMove.Type getType()
            {
                return GameMove.Type.EnglishDraughtCustomFen;
            }

        }

        #endregion

        #region txt

        public Text tvMessage;

        #endregion

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EnglishDraughtCustomFen englishDraughtCustomFen = this.data.englishDraughtCustomFen.v.data;
                    if (englishDraughtCustomFen != null)
                    {
                        // txt
                        {
                            if (tvMessage != null)
                            {
                                tvMessage.text = ClickPosTxt.txtCreateByFenMove.get(ClickPosTxt.DefaultCreateByFenMove);
                            }
                            else
                            {
                                Debug.LogError("tvMessage null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("englishDraughtCustomFen null");
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

        public override void onAddCallBack<T>(T data)
        {
            if(data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.englishDraughtCustomFen.allAddCallBack(this);
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
            // Child
            if(data is EnglishDraughtCustomFen)
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
                    uiData.englishDraughtCustomFen.allRemoveCallBack(this);
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
            if (data is EnglishDraughtCustomFen)
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
                    case UIData.Property.englishDraughtCustomFen:
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
                    case Setting.Property.defaultChosenGame:
                        break;
                    case Setting.Property.defaultRoomName:
                        break;
                    case Setting.Property.defaultChatRoomStyle:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            if (wrapProperty.p is EnglishDraughtCustomFen)
            {
                switch ((EnglishDraughtCustomFen.Property)wrapProperty.n)
                {
                    case EnglishDraughtCustomFen.Property.fen:
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
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace RussianDraught
{
    public class RussianDraughtFenUI : UIBehavior<RussianDraughtFenUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<RussianDraught>> russianDraught;

            #region Constructor

            public enum Property
            {
                russianDraught
            }

            public UIData() : base()
            {
                this.russianDraught = new VP<ReferenceData<RussianDraught>>(this, (byte)Property.russianDraught, new ReferenceData<RussianDraught>(null));
            }

            #endregion

        }

        #endregion

        #region Refresh

        public Text tvFen;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    RussianDraught russianDraught = this.data.russianDraught.v.data;
                    if (russianDraught != null)
                    {
                        // tvFen
                        if (tvFen != null)
                        {
                            tvFen.text = Core.unityPositionToFen(russianDraught, Core.CanCorrect);
                            Setting.get().setContentTextSize(tvFen);
                        }
                        else
                        {
                            Debug.LogError("tvFen null: " + this);
                        }
                    }
                    else
                    {
                        // Debug.LogError("russianDraught null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError("data null: " + this);
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
                    uiData.russianDraught.allAddCallBack(this);
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
            {
                data.addCallBackAllChildren(this);
                dirty = true;
                return;
            }
            // Debug.LogError ("Don't process: " + data + "; " + this);
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
                    uiData.russianDraught.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if(data is Setting)
            {
                return;
            }
            // Child
            {
                data.removeCallBackAllChildren(this);
                return;
            }
            // Debug.LogError ("Don't process: " + data + "; " + this);
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
                    case UIData.Property.russianDraught:
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
            if(wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
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
                    case Setting.Property.confirmQuit:
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
            {
                if (Generic.IsAddCallBackInterface<T>())
                {
                    ValueChangeUtils.replaceCallBack(this, syncs);
                }
                dirty = true;
                return;
            }
            // Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
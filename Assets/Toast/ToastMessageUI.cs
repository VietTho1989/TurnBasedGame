using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ToastMessageUI : UIBehavior<ToastMessageUI.UIData>
{

    #region UIData

    public class UIData : Data
    {
        public VP<ReferenceData<ToastMessage>> toastMessage;

        #region Constructor

        public enum Property
        {
            toastMessage
        }

        public UIData() : base()
        {
            this.toastMessage = new VP<ReferenceData<ToastMessage>>(this, (byte)Property.toastMessage, new ReferenceData<ToastMessage>(null));
        }

        #endregion
    }

    #endregion

    #region Refresh

    public GameObject toastMessageContainer;
    public Text tvMessage;

    public WrapContent wrapContent;

    public LayoutElement layOutMaxSize;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                ToastMessage toastMessage = this.data.toastMessage.v.data;
                // Container
                if (toastMessageContainer != null)
                {
                    toastMessageContainer.SetActive(toastMessage != null ? true : false);
                }
                else
                {
                    Debug.LogError("toastMessageContainer null: " + this);
                }
                // Content
                if (toastMessage != null)
                {
                    // tvMessage
                    {
                        if (tvMessage != null && layOutMaxSize!=null)
                        {
                            tvMessage.text = toastMessage.message.v;
                            // find overSize or not
                            {
                                bool isOverSize = false;
                                {
                                    float MaxSize = 440;
                                    float testSize = tvMessage.cachedTextGenerator.GetPreferredWidth(tvMessage.text, tvMessage.GetGenerationSettings(new Vector2(MaxSize, 30)));
                                    if (testSize > MaxSize)
                                    {
                                        isOverSize = true;
                                    }
                                }
                                layOutMaxSize.enabled = isOverSize;
                            }
                        }
                        else
                        {
                            Debug.LogError("tvMessage, layoutMaxSize null");
                        }
                    }
                    // Alpha
                    {
                        // TODO Can hoan thien

                        // fadeIn 1second
                    }
                }
                else
                {
                    // Debug.LogError ("toastMessage null: " + this);
                }
                // wrapContent
                {
                    if (wrapContent != null)
                    {
                        wrapContent.dirty = true;
                        wrapContent.refresh();
                    }
                    else
                    {
                        Debug.LogError("wrapContent null");
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
        return false;
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
                uiData.toastMessage.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        if (data is ToastMessage)
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
            // Child
            {
                uiData.toastMessage.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        if (data is ToastMessage)
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
                case UIData.Property.toastMessage:
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
        // Child
        if (wrapProperty.p is ToastMessage)
        {
            switch ((ToastMessage.Property)wrapProperty.n)
            {
                case ToastMessage.Property.toastIndex:
                    break;
                case ToastMessage.Property.message:
                    dirty = true;
                    break;
                case ToastMessage.Property.time:
                    dirty = true;
                    break;
                case ToastMessage.Property.duration:
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
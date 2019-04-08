using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RequestChangeStringUI : UIBehavior<RequestChangeStringUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<RequestChangeStringUpdate.UpdateData> updateData;

        #region compare

        public VP<bool> showDifferent;

        public VP<string> compare;

        #endregion

        public VP<string> placeHolder;

        public VP<InputField.ContentType> contentType;

        #region Constructor

        public enum Property
        {
            updateData,
            showDifferent,
            compare,
            placeHolder,
            contentType
        }

        public UIData() : base()
        {
            this.updateData = new VP<RequestChangeStringUpdate.UpdateData>(this, (byte)Property.updateData, new RequestChangeStringUpdate.UpdateData());
            this.showDifferent = new VP<bool>(this, (byte)Property.showDifferent, false);
            this.compare = new VP<string>(this, (byte)Property.compare, "");
            this.placeHolder = new VP<string>(this, (byte)Property.placeHolder, "");
            this.contentType = new VP<InputField.ContentType>(this, (byte)Property.contentType, InputField.ContentType.Standard);
        }

        #endregion

    }

    #endregion

    #region Refresh

    public InputField edtValue;

    public override void Awake()
    {
        base.Awake();
        if (edtValue != null)
        {
            edtValue.onEndEdit.AddListener(delegate
            {
                if (edtValue.gameObject.activeInHierarchy)
                {
                    if (this.data != null)
                    {
                        string newValue = edtValue.text;
                        this.data.updateData.v.current.v = newValue;
                    }
                    else
                    {
                        Debug.LogError("data null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("edtValue not active: " + this);
                }
            });
        }
        else
        {
            Debug.LogError("edtValue null: " + this);
        }
    }

    public static readonly Color DifferentColor = Color.red;
    public static readonly Color NormalColor = new Color(50 / 255f, 50 / 255f, 50 / 255f);
    public static readonly Color RequestColor = new Color(52 / 255f, 152 / 255f, 13 / 255f);
    public Text tvValue;

    public Image imgBackGround;

    public Text tvPlaceHolder;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // Update UI
                {
                    // interactable, contentType
                    if (edtValue != null)
                    {
                        edtValue.interactable = this.data.updateData.v.canRequestChange.v;
                        edtValue.contentType = this.data.contentType.v;
                    }
                    else
                    {
                        Debug.LogError("edtValue null");
                    }
                    // background
                    if (imgBackGround != null)
                    {
                        imgBackGround.enabled = this.data.updateData.v.canRequestChange.v;
                    }
                    else
                    {
                        Debug.LogError("imgBackGround null");
                    }
                    // placeHolder
                    if (tvPlaceHolder != null)
                    {
                        tvPlaceHolder.text = this.data.placeHolder.v;
                        tvPlaceHolder.fontSize = Mathf.Clamp(Setting.get().contentTextSize.v, Setting.MinContentTextSize, Setting.MaxContentTextSize);
                    }
                    else
                    {
                        Debug.LogError("tvPlaceHolder null");
                    }
                    // set value
                    {
                        // edtValue
                        if (edtValue != null)
                        {
                            edtValue.text = this.data.updateData.v.current.v;
                        }
                        else
                        {
                            Debug.LogError("edtValue null: " + this);
                        }
                        // tvValue
                        if (tvValue != null)
                        {
                            // color
                            {
                                if (this.data.updateData.v.request.v != null)
                                {
                                    switch (this.data.updateData.v.changeState.v)
                                    {
                                        case Data.ChangeState.None:
                                            {
                                                // check different
                                                bool isDifferent = false;
                                                {
                                                    if (this.data.showDifferent.v)
                                                    {
                                                        RequestChangeStringUpdate.UpdateData updateData = this.data.updateData.v;
                                                        if (updateData != null)
                                                        {
                                                            if (updateData.current.v != this.data.compare.v)
                                                            {
                                                                isDifferent = true;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("updateData null: " + this);
                                                        }
                                                    }
                                                }
                                                // Process
                                                if (isDifferent)
                                                {
                                                    tvValue.color = DifferentColor;
                                                }
                                                else
                                                {
                                                    tvValue.color = NormalColor;
                                                }
                                            }
                                            break;
                                        case Data.ChangeState.Request:
                                        case Data.ChangeState.Requesting:
                                            tvValue.color = RequestColor;
                                            break;
                                        default:
                                            Debug.LogError("unknown state: " + this.data.updateData.v.changeState.v + "; " + this);
                                            break;
                                    }
                                }
                                else
                                {
                                    tvValue.color = NormalColor;
                                }
                            }
                            // textSize
                            {
                                tvValue.fontSize = Mathf.Clamp(Setting.get().contentTextSize.v, Setting.MinContentTextSize, Setting.MaxContentTextSize);
                            }
                        }
                        else
                        {
                            Debug.LogError("tvValue null");
                        }

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
                uiData.updateData.allAddCallBack(this);
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
        {
            if (data is RequestChangeStringUpdate.UpdateData)
            {
                RequestChangeStringUpdate.UpdateData updateData = data as RequestChangeStringUpdate.UpdateData;
                // Update
                {
                    UpdateUtils.makeUpdate<RequestChangeStringUpdate, RequestChangeStringUpdate.UpdateData>(updateData, this.transform);
                }
                dirty = true;
                return;
            }
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
                uiData.updateData.allRemoveCallBack(this);
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
        {
            if (data is RequestChangeStringUpdate.UpdateData)
            {
                RequestChangeStringUpdate.UpdateData updateData = data as RequestChangeStringUpdate.UpdateData;
                // Update
                {
                    updateData.removeCallBackAndDestroy(typeof(RequestChangeStringUpdate));
                }
                return;
            }
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
                case UIData.Property.updateData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.showDifferent:
                    dirty = true;
                    break;
                case UIData.Property.compare:
                    dirty = true;
                    break;
                case UIData.Property.placeHolder:
                    dirty = true;
                    break;
                case UIData.Property.contentType:
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
            if (wrapProperty.p is RequestChangeStringUpdate.UpdateData)
            {
                switch ((RequestChangeStringUpdate.UpdateData.Property)wrapProperty.n)
                {
                    case RequestChangeStringUpdate.UpdateData.Property.origin:
                        break;
                    case RequestChangeStringUpdate.UpdateData.Property.current:
                        dirty = true;
                        break;
                    case RequestChangeStringUpdate.UpdateData.Property.canRequestChange:
                        dirty = true;
                        break;
                    case RequestChangeStringUpdate.UpdateData.Property.changeState:
                        dirty = true;
                        break;
                    case RequestChangeStringUpdate.UpdateData.Property.serverState:
                        break;
                    case RequestChangeStringUpdate.UpdateData.Property.request:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
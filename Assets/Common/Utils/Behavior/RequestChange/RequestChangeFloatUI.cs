using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeFloatUI : UIBehavior<RequestChangeFloatUI.UIData>
{

    #region UIData

    public class UIData : RequestChange.UIData<float>
    {

        public VP<RequestChangeFloatUpdate.UpdateData> updateData;

        public VP<FloatLimit> limit;

        #region compare

        public VP<bool> showDifferent;

        public VP<float> compare;

        #endregion

        #region Constructor

        public enum Property
        {
            updateData,
            limit,
            // comare
            showDifferent,
            compare
        }

        public UIData() : base()
        {
            this.updateData = new VP<RequestChangeFloatUpdate.UpdateData>(this, (byte)Property.updateData, new RequestChangeFloatUpdate.UpdateData());
            this.limit = new VP<FloatLimit>(this, (byte)Property.limit, new FloatLimit.No());
            // compare
            {
                this.showDifferent = new VP<bool>(this, (byte)Property.showDifferent, false);
                this.compare = new VP<float>(this, (byte)Property.compare, 0);
            }
        }

        #endregion

        #region implement base

        public override RequestChangeUpdate<float>.UpdateData getUpdate()
        {
            return this.updateData.v;
        }

        public override void setShowDifferent(bool showDifferent)
        {
            this.showDifferent.v = showDifferent;
        }

        public override void setCompare(float compare)
        {
            this.compare.v = compare;
        }

        #endregion

    }

    #endregion

    #region Refresh

    public InputField edtValue;
    public Slider sliderValue;

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
                        float newValue = this.data.updateData.v.current.v;
                        if (System.Single.TryParse(edtValue.text, out newValue))
                        {
                            this.data.updateData.v.current.v = newValue;
                        }
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
        if (sliderValue != null)
        {
            sliderValue.onValueChanged.AddListener(delegate
            {
                // Debug.LogError ("sliderValue: onValueChanged: " + sliderValue.value);
                if (sliderValue.gameObject.activeInHierarchy)
                {
                    if (this.data != null)
                    {
                        this.data.updateData.v.current.v = sliderValue.value;
                    }
                    else
                    {
                        Debug.LogError("data null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError("slider not active: "+this);
                }
            });
        }
        else
        {
            Debug.LogError("sliderValue null: " + this);
        }
    }

    public static readonly Color DifferentColor = Color.red;
    public static readonly Color NormalColor = new Color(50 / 255f, 50 / 255f, 50 / 255f);
    public static readonly Color RequestColor = new Color(52 / 255f, 152 / 255f, 13 / 255f);
    public Text tvValue;

    public Text tvPlaceHolder;

    public Image imgBackground;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // slider
                {
                    if (sliderValue != null)
                    {
                        FloatLimit floatLimit = this.data.limit.v;
                        if (floatLimit != null)
                        {
                            switch (floatLimit.getType())
                            {
                                case FloatLimit.Type.No:
                                    {
                                        // slider
                                        sliderValue.gameObject.SetActive(false);
                                        // edtValue
                                        if (edtValue != null)
                                        {
                                            UIConstants.RequestChangeFullRect.set((RectTransform)edtValue.transform);
                                        }
                                        else
                                        {
                                            Debug.LogError("edtValue null");
                                        }
                                    }
                                    break;
                                case FloatLimit.Type.Have:
                                    {
                                        // slider
                                        FloatLimit.Have have = floatLimit as FloatLimit.Have;
                                        if (have.min.v < have.max.v)
                                        {
                                            sliderValue.gameObject.SetActive(true);
                                            sliderValue.minValue = have.min.v;
                                            sliderValue.maxValue = have.max.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("why min >= max: " + have.min.v + "; " + have.max.v);
                                            sliderValue.gameObject.SetActive(false);
                                        }
                                        // edtValue
                                        if (edtValue != null)
                                        {
                                            if (sliderValue.gameObject.activeSelf)
                                            {
                                                UIConstants.RequestChangePartRect.set((RectTransform)edtValue.transform);
                                            }
                                            else
                                            {
                                                UIConstants.RequestChangeFullRect.set((RectTransform)edtValue.transform);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("edtValue null");
                                        }
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + floatLimit.getType() + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("limit null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("sliderValue null: " + this);
                    }
                }
                // Update UI
                {
                    // Process
                    if (this.data.updateData.v.canRequestChange.v)
                    {
                        // make interactable
                        if (edtValue != null)
                        {
                            edtValue.interactable = true;
                        }
                        else
                        {
                            Debug.LogError("edtValue null: " + this);
                        }
                        if (sliderValue != null)
                        {
                            sliderValue.interactable = true;
                        }
                        else
                        {
                            Debug.LogError("sliderValue null: " + this);
                        }
                        // background
                        if (imgBackground != null)
                        {
                            imgBackground.enabled = true;
                        }
                        else
                        {
                            Debug.LogError("imgBackground null");
                        }
                    }
                    else
                    {
                        // disable interactable
                        if (edtValue != null)
                        {
                            edtValue.interactable = false;
                        }
                        else
                        {
                            Debug.LogError("edtValue null: " + this);
                        }
                        if (sliderValue != null)
                        {
                            sliderValue.interactable = false;
                        }
                        else
                        {
                            Debug.LogError("sliderValue null: " + this);
                        }
                        // background
                        if (imgBackground != null)
                        {
                            imgBackground.enabled = false;
                        }
                        else
                        {
                            Debug.LogError("imgBackground null");
                        }
                    }
                    // set value
                    {
                        // edtValue
                        if (edtValue != null)
                        {
                            edtValue.text = "" + this.data.updateData.v.current.v;
                        }
                        else
                        {
                            Debug.LogError("edtValue null: " + this);
                        }
                        // sliderValue
                        if (sliderValue != null)
                        {
                            sliderValue.value = this.data.updateData.v.current.v;
                        }
                        else
                        {
                            Debug.LogError("sliderValue null: " + this);
                        }
                        // tvValue
                        if (tvValue != null)
                        {
                            // color
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
                                                    RequestChangeFloatUpdate.UpdateData updateData = this.data.updateData.v;
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
                                        {
                                            tvValue.color = RequestColor;
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + this.data.updateData.v.changeState.v + "; " + this);
                                        break;
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
                        // tvPlaceHolder
                        if (tvPlaceHolder != null)
                        {
                            tvPlaceHolder.fontSize = Mathf.Clamp(Setting.get().contentTextSize.v, Setting.MinContentTextSize, Setting.MaxContentTextSize);
                        }
                        else
                        {
                            Debug.LogError("tvPlaceHolder null");
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
                uiData.limit.allAddCallBack(this);
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
            if (data is RequestChangeFloatUpdate.UpdateData)
            {
                RequestChangeFloatUpdate.UpdateData updateData = data as RequestChangeFloatUpdate.UpdateData;
                // Update
                {
                    UpdateUtils.makeUpdate<RequestChangeFloatUpdate, RequestChangeFloatUpdate.UpdateData>(updateData, this.transform);
                }
                dirty = true;
                return;
            }
            if (data is FloatLimit)
            {
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
                uiData.limit.allRemoveCallBack(this);
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
            if (data is RequestChangeFloatUpdate.UpdateData)
            {
                RequestChangeFloatUpdate.UpdateData updateData = data as RequestChangeFloatUpdate.UpdateData;
                // Update
                {
                    updateData.removeCallBackAndDestroy(typeof(RequestChangeFloatUpdate));
                }
                return;
            }
            if (data is FloatLimit)
            {
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
                case UIData.Property.limit:
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
                case Setting.Property.buttonSize:
                    dirty = true;
                    break;
                case Setting.Property.itemSize:
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
            if (wrapProperty.p is RequestChangeFloatUpdate.UpdateData)
            {
                switch ((RequestChangeFloatUpdate.UpdateData.Property)wrapProperty.n)
                {
                    case RequestChangeFloatUpdate.UpdateData.Property.origin:
                        break;
                    case RequestChangeFloatUpdate.UpdateData.Property.current:
                        dirty = true;
                        break;
                    case RequestChangeFloatUpdate.UpdateData.Property.canRequestChange:
                        dirty = true;
                        break;
                    case RequestChangeFloatUpdate.UpdateData.Property.changeState:
                        dirty = true;
                        break;
                    case RequestChangeFloatUpdate.UpdateData.Property.serverState:
                        break;
                    case RequestChangeFloatUpdate.UpdateData.Property.request:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            if (wrapProperty.p is FloatLimit)
            {
                if (wrapProperty.p is FloatLimit.Have)
                {
                    switch ((FloatLimit.Have.Property)wrapProperty.n)
                    {
                        case FloatLimit.Have.Property.min:
                            dirty = true;
                            break;
                        case FloatLimit.Have.Property.max:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
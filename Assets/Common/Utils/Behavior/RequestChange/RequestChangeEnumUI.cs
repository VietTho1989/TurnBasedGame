using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RequestChangeEnumUI : UIBehavior<RequestChangeEnumUI.UIData>
{

    #region UIData

    public class UIData : RequestChange.UIData<int>
    {

        public VP<RequestChangeIntUpdate.UpdateData> updateData;

        public LP<string> options;

        #region compare

        public VP<bool> showDifferent;

        public VP<int> compare;

        #endregion

        #region Constructor

        public enum Property
        {
            updateData,
            options,
            // comare
            showDifferent,
            compare
        }

        public UIData() : base()
        {
            this.updateData = new VP<RequestChangeIntUpdate.UpdateData>(this, (byte)Property.updateData, new RequestChangeIntUpdate.UpdateData());
            this.options = new LP<string>(this, (byte)Property.options);
            // compare
            {
                this.showDifferent = new VP<bool>(this, (byte)Property.showDifferent, false);
                this.compare = new VP<int>(this, (byte)Property.compare, 0);
            }
        }

        #endregion

        #region implement base

        public override RequestChangeUpdate<int>.UpdateData getUpdate()
        {
            return this.updateData.v;
        }

        public override void setShowDifferent(bool showDifferent)
        {
            this.showDifferent.v = showDifferent;
        }

        public override void setCompare(int compare)
        {
            this.compare.v = compare;
        }

        #endregion

    }

    public static void RefreshOptions(RequestChangeEnumUI.UIData requestChangeEnumUIData, List<string> options)
    {
        if (requestChangeEnumUIData != null)
        {
            requestChangeEnumUIData.options.copyList(options);
        }
        else
        {
            Debug.LogError("requestChangeEnumUIData null");
        }
    }

    #endregion

    #region Refresh

    public Dropdown drValues;

    private int tempNotRefresh = 0;

    public override void Awake()
    {
        base.Awake();
        if (drValues != null)
        {
            drValues.onValueChanged.AddListener(delegate (int newValue)
            {
                if (this.data != null)
                {
                    this.data.updateData.v.current.v = newValue;
                    tempNotRefresh = 8;
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            });
        }
        else
        {
            Debug.LogError("drValue null: " + this);
        }
    }

    public static readonly Color DifferentColor = Color.red;
    public static readonly Color NormalColor = new Color(50 / 255f, 50 / 255f, 50 / 255f);
    public static readonly Color RequestColor = new Color(52 / 255f, 152 / 255f, 13 / 255f);
    public Text label;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                if (tempNotRefresh > 0)
                {
                    tempNotRefresh--;
                    dirty = true;
                    return;
                }
                // Make options
                if (drValues != null)
                {
                    // remove 
                    {
                        if (drValues.options.Count > this.data.options.vs.Count)
                        {
                            drValues.options.RemoveRange(this.data.options.vs.Count, drValues.options.Count - this.data.options.vs.Count);
                        }
                    }
                    for (int i = 0; i < this.data.options.vs.Count; i++)
                    {
                        if (i < drValues.options.Count)
                        {
                            // Update
                            drValues.options[i].text = this.data.options.vs[i];
                        }
                        else
                        {
                            // Add new
                            Dropdown.OptionData optionData = new Dropdown.OptionData();
                            {
                                optionData.text = this.data.options.vs[i];
                            }
                            drValues.options.Add(optionData);
                        }
                    }
                    drValues.RefreshShownValue();
                }
                else
                {
                    Debug.LogError("drValues null: " + this);
                }
                // Interactable
                if (this.data.updateData.v.canRequestChange.v)
                {
                    // drValues
                    if (drValues != null)
                    {
                        drValues.interactable = true;
                    }
                    else
                    {
                        Debug.LogError("drValues null: " + this);
                    }
                }
                else
                {
                    // drValues
                    if (drValues != null)
                    {
                        drValues.interactable = false;
                    }
                    else
                    {
                        Debug.LogError("drValues null: " + this);
                    }
                }
                // drValues
                if (drValues != null)
                {
                    drValues.value = this.data.updateData.v.current.v;
                }
                else
                {
                    Debug.LogError("drValues null: " + this);
                }
                // label
                if (label != null)
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
                                            RequestChangeIntUpdate.UpdateData updateData = this.data.updateData.v;
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
                                        label.color = DifferentColor;
                                    }
                                    else
                                    {
                                        label.color = NormalColor;
                                    }
                                }
                                break;
                            case Data.ChangeState.Request:
                            case Data.ChangeState.Requesting:
                                label.color = RequestColor;
                                break;
                            default:
                                Debug.LogError("unknown state: " + this.data.updateData.v.changeState.v + "; " + this);
                                break;
                        }
                    }
                    // textSize
                    {
                        label.fontSize = Mathf.Clamp(Setting.get().contentTextSize.v, Setting.MinContentTextSize, Setting.MaxContentTextSize);
                    }
                }
                else
                {
                    Debug.LogError("label null");
                }
            }
            else
            {
                // Debug.Log ("data null: " + this);
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
            if (data is RequestChangeIntUpdate.UpdateData)
            {
                RequestChangeIntUpdate.UpdateData updateData = data as RequestChangeIntUpdate.UpdateData;
                // Update
                {
                    UpdateUtils.makeUpdate<RequestChangeIntUpdate, RequestChangeIntUpdate.UpdateData>(updateData, this.transform);
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
            if (data is RequestChangeIntUpdate.UpdateData)
            {
                RequestChangeIntUpdate.UpdateData updateData = data as RequestChangeIntUpdate.UpdateData;
                // Update
                {
                    updateData.removeCallBackAndDestroy(typeof(RequestChangeIntUpdate));
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
                case UIData.Property.options:
                    dirty = true;
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
            if (wrapProperty.p is RequestChangeIntUpdate.UpdateData)
            {
                switch ((RequestChangeIntUpdate.UpdateData.Property)wrapProperty.n)
                {
                    case RequestChangeIntUpdate.UpdateData.Property.origin:
                        break;
                    case RequestChangeIntUpdate.UpdateData.Property.current:
                        dirty = true;
                        break;
                    case RequestChangeIntUpdate.UpdateData.Property.canRequestChange:
                        dirty = true;
                        break;
                    case RequestChangeIntUpdate.UpdateData.Property.changeState:
                        dirty = true;
                        break;
                    case RequestChangeIntUpdate.UpdateData.Property.serverState:
                        break;
                    case RequestChangeIntUpdate.UpdateData.Property.request:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
    }

    #endregion

}
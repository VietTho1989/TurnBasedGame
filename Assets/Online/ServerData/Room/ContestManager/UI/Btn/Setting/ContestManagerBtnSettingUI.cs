using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

public class ContestManagerBtnSettingUI : UIBehavior<ContestManagerBtnSettingUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        #region  Visibility

        public enum Visibility
        {
            Show,
            Hide
        }

        public VP<Visibility> visibility;

        #endregion

        #region Constructor

        public enum Property
        {
            visibility
        }

        public UIData() : base()
        {
            this.visibility = new VP<Visibility>(this, (byte)Property.visibility, Visibility.Hide);
        }

        #endregion

        public void reset()
        {
            this.visibility.v = Visibility.Hide;
        }

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

    private ContestManagerUI.UIData contestManagerUIData = null;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Parent
            {
                DataUtils.addParentCallBack(uiData, this, ref this.contestManagerUIData);
            }
            dirty = true;
            return;
        }
        // Parent
        {
            if(data is ContestManagerUI.UIData)
            {
                ContestManagerUI.UIData contestManagerUIData = data as ContestManagerUI.UIData;
                // Child
                {
                    contestManagerUIData.sub.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if(data is ContestManagerUI.UIData.Sub)
            {
                // reset
                {
                    if (this.data != null)
                    {
                        this.data.reset();
                    }
                    else
                    {
                        Debug.LogError("data null");
                    }
                }
                dirty = true;
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            this.setDataNull(uiData);
            return;
        }
        // Parent
        {
            if (data is ContestManagerUI.UIData)
            {
                ContestManagerUI.UIData contestManagerUIData = data as ContestManagerUI.UIData;
                // Child
                {
                    contestManagerUIData.sub.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            if (data is ContestManagerUI.UIData.Sub)
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
        if(wrapProperty.p is UIData)
        {
            switch ((UIData.Property)wrapProperty.n)
            {
                case UIData.Property.visibility:
                    dirty = true;
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Parent
        {
            if (wrapProperty.p is ContestManagerUI.UIData)
            {
                switch ((ContestManagerUI.UIData.Property)wrapProperty.n)
                {
                    case ContestManagerUI.UIData.Property.contestManager:
                        break;
                    case ContestManagerUI.UIData.Property.sub:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case ContestManagerUI.UIData.Property.btns:
                        break;
                    case ContestManagerUI.UIData.Property.roomChat:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            if (wrapProperty.p is ContestManagerUI.UIData.Sub)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnSetting()
    {
        if (this.data != null)
        {
            switch (this.data.visibility.v)
            {
                case UIData.Visibility.Show:
                    this.data.visibility.v = UIData.Visibility.Hide;
                    break;
                case UIData.Visibility.Hide:
                    this.data.visibility.v = UIData.Visibility.Show;
                    break;
                default:
                    Debug.LogError("unknown visibility: " + this.data.visibility.v);
                    break;
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}
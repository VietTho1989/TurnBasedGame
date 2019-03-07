using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ProcessMoveActionUI : UIBehavior<ProcessMoveActionUI.UIData>
{

    #region UIData

    public class UIData : GameActionsUI.UIData.Sub
    {

        public VP<ReferenceData<ProcessMoveAction>> processMoveAction;

        public override GameAction.Type getType()
        {
            return GameAction.Type.ProcessMove;
        }

        #region Constructor

        public enum Property
        {
            processMoveAction
        }

        public UIData() : base()
        {
            this.processMoveAction = new VP<ReferenceData<ProcessMoveAction>>(this, (byte)Property.processMoveAction, new ReferenceData<ProcessMoveAction>(null));
        }

        #endregion
    }

    #endregion

    #region Refresh

    #region txt

    public static readonly TxtLanguage txtProcessMove = new TxtLanguage();

    static ProcessMoveActionUI()
    {
        txtProcessMove.add(Language.Type.vi, "Đang xử lý nước đi");
    }

    #endregion

    public Text tvContent;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                ProcessMoveAction processMoveAction = this.data.processMoveAction.v.data;
                if (processMoveAction != null)
                {
                    if (tvContent != null)
                    {
                        tvContent.text = txtProcessMove.get("Processing move");
                    }
                    else
                    {
                        Debug.LogError("tvContent null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("processMoveAction null: " + this);
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
                uiData.processMoveAction.allAddCallBack(this);
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
        if (data is ProcessMoveAction)
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
                uiData.processMoveAction.allRemoveCallBack(this);
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
        if (data is ProcessMoveAction)
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
                case UIData.Property.processMoveAction:
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
        // Child
        if (wrapProperty.p is ProcessMoveAction)
        {
            switch ((ProcessMoveAction.Property)wrapProperty.n)
            {
                case ProcessMoveAction.Property.state:
                    dirty = true;
                    break;
                case ProcessMoveAction.Property.inputData:
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
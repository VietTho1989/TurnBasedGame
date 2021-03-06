﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UndoRedoActionUI : UIBehavior<UndoRedoActionUI.UIData>
{

    #region UIData

    public class UIData : GameActionsUI.UIData.Sub
    {

        public VP<ReferenceData<UndoRedoAction>> undoRedoAction;

        #region Constructor

        public enum Property
        {
            undoRedoAction
        }

        public UIData() : base()
        {
            this.undoRedoAction = new VP<ReferenceData<UndoRedoAction>>(this, (byte)Property.undoRedoAction, new ReferenceData<UndoRedoAction>(null));
        }

        #endregion

        public override GameAction.Type getType()
        {
            return GameAction.Type.UndoRedo;
        }

    }

    #endregion

    #region txt

    public Text tvMessage;
    public static readonly TxtLanguage txtMessage = new TxtLanguage("Undoing/Redoing");

    static UndoRedoActionUI()
    {
        txtMessage.add(Language.Type.vi, "Đang đi lại");
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
                uiData.undoRedoAction.allAddCallBack(this);
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
        if (data is UndoRedoAction)
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
                uiData.undoRedoAction.allRemoveCallBack(this);
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
        if (data is UndoRedoAction)
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
                case UIData.Property.undoRedoAction:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                default:
                    Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
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
        if (wrapProperty.p is UndoRedoAction)
        {
            switch ((UndoRedoAction.Property)wrapProperty.n)
            {
                case UndoRedoAction.Property.state:
                    break;
                case UndoRedoAction.Property.requestInform:
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
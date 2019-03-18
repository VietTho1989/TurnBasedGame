using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BtnUndoRedoUI : UIBehavior<BtnUndoRedoUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<UndoRedoRequest>> undoRedoRequest;

        #region Constructor

        public enum Property
        {
            undoRedoRequest
        }

        public UIData() : base()
        {
            this.undoRedoRequest = new VP<ReferenceData<UndoRedoRequest>>(this, (byte)Property.undoRedoRequest, new ReferenceData<UndoRedoRequest>(null));
        }

        #endregion

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage();

    static BtnUndoRedoUI()
    {
        txtTitle.add(Language.Type.vi, "Đi Lại");
    }

    #endregion

    #region Refresh

    public GameObject highlightIndicator;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                UndoRedoRequest undoRedoRequest = this.data.undoRedoRequest.v.data;
                if (undoRedoRequest != null)
                {
                    if (highlightIndicator != null)
                    {
                        bool isHighLight = false;
                        {
                            if(undoRedoRequest.state.v is UndoRedo.Ask)
                            {
                                isHighLight = true;
                            }
                        }
                        highlightIndicator.SetActive(isHighLight);
                    }
                    else
                    {
                        Debug.LogError("highlightIndicator null");
                    }
                }
                else
                {
                    Debug.LogError("game null");
                }
                // txt
                {
                    if (lbTitle != null)
                    {
                        lbTitle.text = txtTitle.get("Undo/Redo");
                    }
                    else
                    {
                        Debug.LogError("lbTitle null");
                    }
                }
            }
            else
            {
                Debug.LogError("data nulll");
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
                uiData.undoRedoRequest.allAddCallBack(this);
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
        if (data is UndoRedoRequest)
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
                uiData.undoRedoRequest.allRemoveCallBack(this);
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
        if (data is UndoRedoRequest)
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
                case UIData.Property.undoRedoRequest:
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
        if (wrapProperty.p is UndoRedoRequest)
        {
            switch ((UndoRedoRequest.Property)wrapProperty.n)
            {
                case UndoRedoRequest.Property.state:
                    dirty = true;
                    break;
                case UndoRedoRequest.Property.count:
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

    public void onClickBtnUndoRedo()
    {
        if (this.data != null)
        {
            UndoRedoRequest undoRedoRequest = this.data.undoRedoRequest.v.data;
            if (undoRedoRequest != null)
            {
                GameUI.UIData gameUIData = this.data.findDataInParent<GameUI.UIData>();
                if (gameUIData != null)
                {
                    UndoRedoRequestUI.UIData undoRedoRequestUIData = gameUIData.undoRedoRequestUIData.newOrOld<UndoRedoRequestUI.UIData>();
                    {

                    }
                    gameUIData.undoRedoRequestUIData.v = undoRedoRequestUIData;
                    // showAnimationUI
                    {
                        ShowAnimationUI.UIData showAnimationUIData = undoRedoRequestUIData.showAnimation.v;
                        if (showAnimationUIData != null)
                        {
                            showAnimationUIData.show();
                        }
                        else
                        {
                            Debug.LogError("showAnimationUIData null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("gameUIData null");
                }
            }
            else
            {
                Debug.LogError("undoRedoRequest null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}
﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PerspectiveAutoUI : UIHaveTransformDataBehavior<PerspectiveAutoUI.UIData>
{

    #region UIData

    public class UIData : PerspectiveUI.UIData.Sub
    {

        public VP<ReferenceData<PerspectiveAuto>> auto;

        #region Constructor

        public enum Property
        {
            auto
        }

        public UIData() : base()
        {
            this.auto = new VP<ReferenceData<PerspectiveAuto>>(this, (byte)Property.auto, new ReferenceData<PerspectiveAuto>(null));
        }

        #endregion

        public override Perspective.Sub.Type getType()
        {
            return Perspective.Sub.Type.Auto;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        PerspectiveAutoUI perspectiveAutoUI = this.findCallBack<PerspectiveAutoUI>();
                        if (perspectiveAutoUI != null)
                        {
                            isProcess = perspectiveAutoUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("perspectiveAutoUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Auto set player perspective");

    public Text tvChange;
    private static readonly TxtLanguage txtChange = new TxtLanguage("Change to force");

    static PerspectiveAutoUI()
    {
        txtTitle.add(Language.Type.vi, "Tự động đặt góc nhìn");
        txtChange.add(Language.Type.vi, "Chuyển sang bắt buộc");
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
                    if (lbTitle != null)
                    {
                        lbTitle.text = txtTitle.get();
                    }
                    else
                    {
                        Debug.LogError("lbTitle null");
                    }
                    if (tvChange != null)
                    {
                        tvChange.text = txtChange.get();
                    }
                    else
                    {
                        Debug.LogError("tvChange null");
                    }
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
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
                uiData.auto.allAddCallBack(this);
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
        if (data is PerspectiveAuto)
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
                uiData.auto.allRemoveCallBack(this);
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
        if (data is PerspectiveAuto)
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
                case UIData.Property.auto:
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
        if (wrapProperty.p is PerspectiveAuto)
        {
            switch ((PerspectiveAuto.Property)wrapProperty.n)
            {
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public override void Awake()
    {
        base.Awake();
        // OnClick
        {
            UIUtils.SetButtonOnClick(btnForce, onClickBtnChangeToForce);
        }
    }

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (e.isKey && e.type == EventType.KeyUp)
            {
                switch (e.keyCode)
                {
                    case KeyCode.F:
                        {
                            if (btnForce != null && btnForce.gameObject.activeInHierarchy && btnForce.interactable)
                            {
                                this.onClickBtnChangeToForce();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("cannot click");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        return isProcess;
    }

    public Button btnForce;

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnChangeToForce()
    {
        if (this.data != null)
        {
            PerspectiveAuto perspectiveAuto = this.data.auto.v.data;
            if (perspectiveAuto != null)
            {
                Perspective perspective = perspectiveAuto.findDataInParent<Perspective>();
                if (perspective != null)
                {
                    PerspectiveForce force = new PerspectiveForce();
                    {
                        force.uid = perspective.sub.makeId();
                        force.playerIndex.v = perspective.playerView.v + 1;
                    }
                    perspective.sub.v = force;
                }
                else
                {
                    Debug.LogError("perspective null: " + this);
                }
            }
            else
            {
                Debug.LogError("perspectiveAuto null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}
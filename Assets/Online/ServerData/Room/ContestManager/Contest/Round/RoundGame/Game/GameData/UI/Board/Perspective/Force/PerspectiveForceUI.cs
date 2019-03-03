using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PerspectiveForceUI : UIBehavior<PerspectiveForceUI.UIData>, HaveTransformData
{

    #region UIData

    public class UIData : PerspectiveUI.UIData.Sub
    {

        public VP<ReferenceData<PerspectiveForce>> force;

        #region Constructor

        public enum Property
        {
            force
        }

        public UIData() : base()
        {
            this.force = new VP<ReferenceData<PerspectiveForce>>(this, (byte)Property.force, new ReferenceData<PerspectiveForce>(null));
        }

        #endregion

        public override Perspective.Sub.Type getType()
        {
            return Perspective.Sub.Type.Force;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {

            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage();

    public Text tvChange;
    private static readonly TxtLanguage txtChange = new TxtLanguage();

    public Text tvAuto;
    private static readonly TxtLanguage txtAuto = new TxtLanguage();

    static PerspectiveForceUI()
    {
        txtTitle.add(Language.Type.vi, "Người chơi chọn góc nhìn");
        txtChange.add(Language.Type.vi, "Thay Đổi");
        txtAuto.add(Language.Type.vi, "Tự Động");
    }

    #endregion

    #region TransformData

    public TransformData transformData = new TransformData();

    private void updateTransformData()
    {
        this.transformData.update(this.transform);
    }

    public TransformData getTransformData()
    {
        return this.transformData;
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
                        lbTitle.text = txtTitle.get("Player choose perspective");
                    }
                    else
                    {
                        Debug.LogError("lbTitle null");
                    }
                    if (tvChange != null)
                    {
                        tvChange.text = txtChange.get("Change");
                    }
                    else
                    {
                        Debug.LogError("tvChange null: " + this);
                    }
                    if (tvAuto != null)
                    {
                        tvAuto.text = txtAuto.get("Auto");
                    }
                    else
                    {
                        Debug.LogError("tvAuto null: " + this);
                    }
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }
        updateTransformData();
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
            // Global
            Global.get().addCallBack(this);
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.force.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Global
        if (data is Global)
        {
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
        if (data is PerspectiveForce)
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
            // Global
            Global.get().removeCallBack(this);
            // Setting
            Setting.get().removeCallBack(this);
            // Child
            {
                uiData.force.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Global
        if (data is Global)
        {
            return;
        }
        // Setting
        if (data is Setting)
        {
            return;
        }
        // Child
        if (data is PerspectiveForce)
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
                case UIData.Property.force:
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
        // Global
        if (wrapProperty.p is Global)
        {
            Global.OnValueTransformChange(wrapProperty, this);
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
        if (wrapProperty.p is PerspectiveForce)
        {
            switch ((PerspectiveForce.Property)wrapProperty.n)
            {
                case PerspectiveForce.Property.playerIndex:
                    dirty = true;
                    break;
                default:
                    Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnAuto()
    {
        if (this.data != null)
        {
            PerspectiveForce force = this.data.force.v.data;
            if (force != null)
            {
                Perspective perspective = force.findDataInParent<Perspective>();
                if (perspective != null)
                {
                    PerspectiveAuto auto = new PerspectiveAuto();
                    {
                        auto.uid = perspective.sub.makeId();
                    }
                    perspective.sub.v = auto;
                }
                else
                {
                    Debug.LogError("perspective null: " + this);
                }
            }
            else
            {
                Debug.LogError("force null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    public void onClickBtnChange()
    {
        if (this.data != null)
        {
            PerspectiveForce force = this.data.force.v.data;
            if (force != null)
            {
                force.playerIndex.v = force.playerIndex.v + 1;
            }
            else
            {
                Debug.LogError("force null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}
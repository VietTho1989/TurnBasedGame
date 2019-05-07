using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SqliteServerUI : UIBehavior<SqliteServerUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public Server.Type serverType = Server.Type.Offline;

        #region sub

        public abstract class Sub : Data
        {

            public enum Type
            {
                NoDatabase,
                HaveDatabase
            }

            public abstract Type getType();

            public abstract bool processEvent(Event e);

            public abstract MainUI.UIData.AllowShowBanner getAllowShowBanner();

        }

        public VP<Sub> sub;

        #endregion

        #region Constructor

        public enum Property
        {
            sub
        }

        public UIData() : base()
        {
            this.sub = new VP<Sub>(this, (byte)Property.sub, new NoDatabaseServerUI.UIData());
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // sub
                if (!isProcess)
                {
                    Sub sub = this.sub.v;
                    if (sub != null)
                    {
                        isProcess = sub.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("sub null: " + this);
                    }
                }
            }
            return isProcess;
        }

        public bool isShowOther()
        {
            bool show = false;
            {
                SqliteServerUI.UIData.Sub sub = this.sub.v;
                if (sub != null)
                {
                    switch (sub.getType())
                    {
                        case SqliteServerUI.UIData.Sub.Type.NoDatabase:
                            {
                                NoDatabaseServerUI.UIData noDatabaseServerUIData = sub as NoDatabaseServerUI.UIData;
                                if (noDatabaseServerUIData.sub.v.getType() == NoDatabaseServerUI.UIData.Sub.Type.None)
                                {
                                    show = true;
                                }
                            }
                            break;
                        case SqliteServerUI.UIData.Sub.Type.HaveDatabase:
                            {
                                HaveDatabaseServerUI.UIData haveDatabaseServerUIData = sub as HaveDatabaseServerUI.UIData;
                                if (haveDatabaseServerUIData.sub.v.getType() != HaveDatabaseServerUI.UIData.Sub.Type.Update)
                                {
                                    show = true;
                                }
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                            break;
                    }
                }
                else
                {
                    Debug.LogError("sub null: " + this);
                }
            }
            return show;
        }

        public MainUI.UIData.AllowShowBanner getAllowShowBanner()
        {
            MainUI.UIData.AllowShowBanner ret = MainUI.UIData.AllowShowBanner.ForceShow;
            {
                Sub sub = this.sub.v;
                if (sub != null)
                {
                    ret = sub.getAllowShowBanner();
                }
                else
                {
                    Debug.LogError("sub null");
                }
            }
            return ret;
        }

    }

    #endregion

    #region txt

    private static readonly TxtLanguage txtNoDatabase = new TxtLanguage("No AutoSave");
    private static readonly TxtLanguage txtHaveDatabase = new TxtLanguage("Have AutoSave");

    static SqliteServerUI()
    {
        txtNoDatabase.add(Language.Type.vi, "Không Tự Lưu Trữ");
        txtHaveDatabase.add(Language.Type.vi, "Có Tự Lưu Trữ");
    }

    #endregion

    #region Refresh

    public Dropdown drSubType;

    public override void Awake()
    {
        base.Awake();
        if (drSubType != null)
        {
            // event
            drSubType.onValueChanged.AddListener(delegate (int newValue)
            {
                if (drSubType.gameObject.activeInHierarchy)
                {
                    if (this.data != null)
                    {
                        switch ((UIData.Sub.Type)newValue)
                        {
                            case UIData.Sub.Type.NoDatabase:
                                {
                                    if (!(this.data.sub.v is NoDatabaseServerUI.UIData))
                                    {
                                        NoDatabaseServerUI.UIData noDatabaseServerUIData = new NoDatabaseServerUI.UIData();
                                        {
                                            noDatabaseServerUIData.uid = this.data.sub.makeId();
                                        }
                                        this.data.sub.v = noDatabaseServerUIData;
                                    }
                                    else
                                    {
                                        Debug.LogError("already noDataServerUIData");
                                    }
                                }
                                break;
                            case UIData.Sub.Type.HaveDatabase:
                                {
                                    if (!(this.data.sub.v is HaveDatabaseServerUI.UIData))
                                    {
                                        HaveDatabaseServerUI.UIData haveDatabaseServerUIData = new HaveDatabaseServerUI.UIData();
                                        {
                                            haveDatabaseServerUIData.uid = this.data.sub.makeId();
                                        }
                                        this.data.sub.v = haveDatabaseServerUIData;
                                    }
                                }
                                break;
                            default:
                                Debug.LogError("unknown sub type: " + newValue + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("data null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("drEditType not active: " + this);
                }
            });
        }
        else
        {
            Debug.LogError("drValue null: " + this);
        }
    }

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // edtSubType
                if (drSubType != null)
                {
                    // options
                    {
                        // get
                        List<string> options = new List<string>();
                        {
                            options.Add(txtNoDatabase.get());
                            options.Add(txtHaveDatabase.get());
                        }
                        // update
                        bool needRefresh = false;
                        if (drSubType.options.Count == options.Count)
                        {
                            for (int i = 0; i < options.Count; i++)
                            {
                                if (drSubType.options[i].text != options[i])
                                {
                                    needRefresh = true;
                                    drSubType.options[i].text = options[i];
                                }
                            }
                        }
                        else
                        {
                            needRefresh = true;
                            drSubType.AddOptions(options);
                        }
                        // refresh
                        if (needRefresh)
                        {
                            drSubType.RefreshShownValue();
                        }
                    }
                    bool show = false;
                    {
                        UIData.Sub sub = this.data.sub.v;
                        if (sub != null)
                        {
                            switch (sub.getType())
                            {
                                case UIData.Sub.Type.NoDatabase:
                                    {
                                        NoDatabaseServerUI.UIData noDataBaseServerUIData = sub as NoDatabaseServerUI.UIData;
                                        if (noDataBaseServerUIData.sub.v.getType() == NoDatabaseServerUI.UIData.Sub.Type.None)
                                        {
                                            show = true;
                                        }
                                    }
                                    break;
                                case UIData.Sub.Type.HaveDatabase:
                                    {
                                        HaveDatabaseServerUI.UIData haveDatabaseServerUIData = sub as HaveDatabaseServerUI.UIData;
                                        if (haveDatabaseServerUIData.sub.v.getType() == HaveDatabaseServerUI.UIData.Sub.Type.None)
                                        {
                                            show = true;
                                        }
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("sub null: " + this);
                        }
                    }
                    drSubType.gameObject.SetActive(show);
                    // drSubType.transform.SetAsLastSibling();
                }
                else
                {
                    Debug.LogError("drSubType null: " + this);
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

    public NoDatabaseServerUI noDatabaseServerPrefab;
    public HaveDatabaseServerUI haveDatabaseServerPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.sub.allAddCallBack(this);
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
        if (data is UIData.Sub)
        {
            UIData.Sub sub = data as UIData.Sub;
            // UI
            {
                switch (sub.getType())
                {
                    case UIData.Sub.Type.NoDatabase:
                        {
                            NoDatabaseServerUI.UIData noDatabaseServerUIData = sub as NoDatabaseServerUI.UIData;
                            UIUtils.Instantiate(noDatabaseServerUIData, noDatabaseServerPrefab, this.transform, UIConstants.FullParent);
                        }
                        break;
                    case UIData.Sub.Type.HaveDatabase:
                        {
                            HaveDatabaseServerUI.UIData haveDatabaseServerUIData = sub as HaveDatabaseServerUI.UIData;
                            UIUtils.Instantiate(haveDatabaseServerUIData, haveDatabaseServerPrefab, this.transform, UIConstants.FullParent);
                        }
                        break;
                    default:
                        Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                        break;
                }
            }
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
                uiData.sub.allRemoveCallBack(this);
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
        if (data is UIData.Sub)
        {
            UIData.Sub sub = data as UIData.Sub;
            // UI
            {
                switch (sub.getType())
                {
                    case UIData.Sub.Type.NoDatabase:
                        {
                            NoDatabaseServerUI.UIData noDatabaseServerUIData = sub as NoDatabaseServerUI.UIData;
                            noDatabaseServerUIData.removeCallBackAndDestroy(typeof(NoDatabaseServerUI));
                        }
                        break;
                    case UIData.Sub.Type.HaveDatabase:
                        {
                            HaveDatabaseServerUI.UIData haveDatabaseServerUIData = sub as HaveDatabaseServerUI.UIData;
                            haveDatabaseServerUIData.removeCallBackAndDestroy(typeof(HaveDatabaseServerUI));
                        }
                        break;
                    default:
                        Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                        break;
                }
            }
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
                case UIData.Property.sub:
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
        if (wrapProperty.p is UIData.Sub)
        {
            UIData.Sub sub = wrapProperty.p as UIData.Sub;
            switch (sub.getType())
            {
                case UIData.Sub.Type.NoDatabase:
                    {
                        switch ((NoDatabaseServerUI.UIData.Property)wrapProperty.n)
                        {
                            case NoDatabaseServerUI.UIData.Property.sub:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                    }
                    break;
                case UIData.Sub.Type.HaveDatabase:
                    {
                        switch ((HaveDatabaseServerUI.UIData.Property)wrapProperty.n)
                        {
                            case HaveDatabaseServerUI.UIData.Property.sub:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                    }
                    break;
                default:
                    Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
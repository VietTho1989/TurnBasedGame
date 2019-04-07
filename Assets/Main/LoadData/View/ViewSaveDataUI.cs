using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ViewSaveDataUI : UIBehavior<ViewSaveDataUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<Save> save;

        #region Sub

        public abstract class Sub : Data
        {

            public enum Type
            {
                Game
            }

            public abstract Type getType();

            public abstract bool processEvent(Event e);

        }

        public VP<Sub> sub;

        #endregion

        #region Constructor

        public enum Property
        {
            save,
            sub
        }

        public UIData() : base()
        {
            this.save = new VP<Save>(this, (byte)Property.save, null);
            this.sub = new VP<Sub>(this, (byte)Property.sub, null);
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
                // Back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        ViewSaveDataUI viewSaveDataUI = this.findCallBack<ViewSaveDataUI>();
                        if (viewSaveDataUI != null)
                        {
                            if (this.save.v != null)
                            {
                                viewSaveDataUI.onClickBtnBack();
                                isProcess = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("viewSaveDataUI null: " + this);
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
    private static readonly TxtLanguage txtTitle = new TxtLanguage("View Saved Game");

    static ViewSaveDataUI()
    {
        txtTitle.add(Language.Type.vi, "Xem Game Lưu Trữ");
    }

    #endregion

    #region Refresh

    public Button btnBack;
    public Image background;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                Save save = this.data.save.v;
                if (save != null)
                {
                    // sub
                    {
                        if (save.version == Global.VersionCode)
                        {
                            if (save.content is SaveData)
                            {
                                SaveData saveData = save.content as SaveData;
                                if (saveData.data != null)
                                {
                                    if (saveData.data is Game)
                                    {
                                        Game game = saveData.data as Game;
                                        // find
                                        ViewSaveGameUI.UIData viewSaveGameUIData = this.data.sub.newOrOld<ViewSaveGameUI.UIData>();
                                        {
                                            viewSaveGameUIData.game.v = new ReferenceData<Game>(game);
                                        }
                                        this.data.sub.v = viewSaveGameUIData;
                                    }
                                    else
                                    {
                                        this.data.sub.v = null;
                                    }
                                }
                                else
                                {
                                    this.data.sub.v = null;
                                }
                            }
                            else
                            {
                                this.data.sub.v = null;
                            }
                        }
                        else
                        {
                            Debug.LogError("not correct version: " + this);
                            this.data.sub.v = null;
                        }
                    }
                    // showContent
                    {
                        if (background != null)
                        {
                            background.enabled = true;
                        }
                        else
                        {
                            Debug.LogError("background null");
                        }
                        if (lbTitle != null)
                        {
                            lbTitle.gameObject.SetActive(true);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                        if (btnBack != null)
                        {
                            btnBack.gameObject.SetActive(true);
                        }
                        else
                        {
                            Debug.LogError("btnBack null");
                        }
                        UIRectTransform.SetActive(this.data.sub.v, true);
                    }
                }
                else
                {
                    // Debug.LogError ("save null: " + this);
                    // hide content
                    {
                        if (background != null)
                        {
                            background.enabled = false;
                        }
                        else
                        {
                            Debug.LogError("background null");
                        }
                        if (lbTitle != null)
                        {
                            lbTitle.gameObject.SetActive(false);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                        if (btnBack != null)
                        {
                            btnBack.gameObject.SetActive(false);
                        }
                        else
                        {
                            Debug.LogError("btnBack null");
                        }
                        UIRectTransform.SetActive(this.data.sub.v, false);
                    }
                }
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

    public ViewSaveGameUI viewSaveGamePrefab;
    private static readonly UIRectTransform viewSaveGameRect = UIRectTransform.CreateFullRect(10, 10, 30, 0);

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
                    case UIData.Sub.Type.Game:
                        {
                            ViewSaveGameUI.UIData viewSaveGameUIData = sub as ViewSaveGameUI.UIData;
                            UIUtils.Instantiate(viewSaveGameUIData, viewSaveGamePrefab, this.transform, viewSaveGameRect);
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
                    case UIData.Sub.Type.Game:
                        {
                            ViewSaveGameUI.UIData viewSaveGameUIData = sub as ViewSaveGameUI.UIData;
                            viewSaveGameUIData.removeCallBackAndDestroy(typeof(ViewSaveGameUI));
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
                case UIData.Property.save:
                    dirty = true;
                    break;
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
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            this.data.save.v = null;
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}
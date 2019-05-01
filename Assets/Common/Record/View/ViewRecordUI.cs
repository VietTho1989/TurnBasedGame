using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Record
{
    public class ViewRecordUI : UIBehavior<ViewRecordUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<DataRecord> dataRecord;

            #region Sub

            public abstract class Sub : Data
            {

                public enum Type
                {
                    Game
                }

                public abstract Type getType();

            }

            public VP<Sub> sub;

            #endregion

            public VP<ViewRecordControllerUI.UIData> controller;

            #region Constructor

            public enum Property
            {
                dataRecord,
                sub,
                controller
            }

            public UIData() : base()
            {
                this.dataRecord = new VP<DataRecord>(this, (byte)Property.dataRecord, null);
                this.sub = new VP<Sub>(this, (byte)Property.sub, null);
                this.controller = new VP<ViewRecordControllerUI.UIData>(this, (byte)Property.controller, new ViewRecordControllerUI.UIData());
            }

            #endregion

            public bool processEvent(Event e)
            {
                Debug.LogError("processEvent: " + e + "; " + this);
                bool isProcess = false;
                {
                    // sub
                    {

                    }
                    // controller
                    {

                    }
                    // back
                    if (!isProcess)
                    {
                        if (InputEvent.isBackEvent(e))
                        {
                            ViewRecordUI viewRecordUI = this.findCallBack<ViewRecordUI>();
                            if (viewRecordUI != null)
                            {
                                viewRecordUI.onClickBtnBack();
                            }
                            else
                            {
                                Debug.LogError("viewRecordUI null: " + this);
                            }
                            isProcess = true;
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("View Replay");

        static ViewRecordUI()
        {
            txtTitle.add(Language.Type.vi, "Xem Replay");
            // rect
            {
                // viewRecordControllerRect
                {
                    // anchoredPosition: (0.0, 0.0); anchorMin: (0.5, 0.0); anchorMax: (0.5, 0.0); pivot: (0.5, 0.0);
                    // offsetMin: (-240.0, 0.0); offsetMax: (240.0, 30.0); sizeDelta: (480.0, 30.0);
                    viewRecordControllerRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    viewRecordControllerRect.anchorMin = new Vector2(0.5f, 0.0f);
                    viewRecordControllerRect.anchorMax = new Vector2(0.5f, 0.0f);
                    viewRecordControllerRect.pivot = new Vector2(0.5f, 0.0f);
                    viewRecordControllerRect.offsetMin = new Vector2(-240.0f, 0.0f);
                    viewRecordControllerRect.offsetMax = new Vector2(240.0f, 30.0f);
                    viewRecordControllerRect.sizeDelta = new Vector2(480.0f, 30.0f);
                }
            }
        }

        #endregion

        #region Refresh

        public Transform contentContainer;

        public Button btnBack;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    DataRecord dataRecord = this.data.dataRecord.v;
                    if (dataRecord != null)
                    {
                        // contentContainer
                        {
                            if (contentContainer != null)
                            {
                                contentContainer.gameObject.SetActive(true);
                            }
                            else
                            {
                                Debug.LogError("contentContainer null: " + this);
                            }
                        }
                        // sub
                        {
                            if (dataRecord.version == Global.VersionCode)
                            {
                                if (dataRecord.data != null)
                                {
                                    if (dataRecord.data is Game)
                                    {
                                        Game game = dataRecord.data as Game;
                                        // find
                                        ViewGameRecordUI.UIData viewGameRecordUIData = this.data.sub.newOrOld<ViewGameRecordUI.UIData>();
                                        {
                                            viewGameRecordUIData.game.v = new ReferenceData<Game>(game);
                                        }
                                        this.data.sub.v = viewGameRecordUIData;
                                    }
                                    else
                                    {
                                        this.data.sub.v = null;
                                        Debug.LogError("unknown data");
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
                        // controller
                        {
                            ViewRecordControllerUI.UIData viewRecordControllerUIData = this.data.controller.v;
                            if (viewRecordControllerUIData != null)
                            {
                                viewRecordControllerUIData.dataRecord.v = dataRecord;
                            }
                            else
                            {
                                Debug.LogError("viewRecordControllerUIData null: " + this);
                            }
                        }
                        // siblingIndex
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.transform.SetSiblingIndex(0);
                            }
                            else
                            {
                                Debug.LogError("lbTitle null");
                            }
                            if (btnBack != null)
                            {
                                btnBack.transform.SetSiblingIndex(1);
                            }
                            else
                            {
                                Debug.LogError("btnBack null");
                            }
                            UIRectTransform.SetSiblingIndex(this.data.sub.v, 2);
                            UIRectTransform.SetSiblingIndex(this.data.controller.v, 3);
                        }
                    }
                    else
                    {
                        Debug.LogError("dataRecord null: " + this);
                        // contentContainer
                        {
                            if (contentContainer != null)
                            {
                                contentContainer.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("contentContainer null: " + this);
                            }
                        }
                    }
                    // UI
                    {
                        // header
                        {
                            UIRectTransform.SetTitleTransform(lbTitle);
                            UIRectTransform.SetButtonTopLeftTransform(btnBack);
                        }
                        // sub
                        UIRectTransform.Set(this.data.sub.v, CreateSubRect());
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get();
                            Setting.get().setTitleTextSize(lbTitle);
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

        public ViewGameRecordUI viewGameRecordPrefab;

        private static UIRectTransform CreateSubRect()
        {
            return UIRectTransform.CreateFullRect(0, 0, Setting.get().getButtonSize(), 30);
        }

        public ViewRecordControllerUI viewRecordControllerPrefab;
        private static readonly UIRectTransform viewRecordControllerRect = new UIRectTransform();

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
                    uiData.controller.allAddCallBack(this);
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
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case UIData.Sub.Type.Game:
                                {
                                    ViewGameRecordUI.UIData viewGameRecordUIData = sub as ViewGameRecordUI.UIData;
                                    UIUtils.Instantiate(viewGameRecordUIData, viewGameRecordPrefab, contentContainer, CreateSubRect());
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
                if (data is ViewRecordControllerUI.UIData)
                {
                    ViewRecordControllerUI.UIData viewRecordControllerUIData = data as ViewRecordControllerUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(viewRecordControllerUIData, viewRecordControllerPrefab, contentContainer, viewRecordControllerRect);
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
                    uiData.sub.allRemoveCallBack(this);
                    uiData.controller.allRemoveCallBack(this);
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
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case UIData.Sub.Type.Game:
                                {
                                    ViewGameRecordUI.UIData viewGameRecordUIData = sub as ViewGameRecordUI.UIData;
                                    viewGameRecordUIData.removeCallBackAndDestroy(typeof(ViewGameRecordUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                break;
                        }
                    }
                    return;
                }
                if (data is ViewRecordControllerUI.UIData)
                {
                    ViewRecordControllerUI.UIData viewRecordControllerUIData = data as ViewRecordControllerUI.UIData;
                    // UI
                    {
                        viewRecordControllerUIData.removeCallBackAndDestroy(typeof(ViewRecordControllerUI));
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
                    case UIData.Property.dataRecord:
                        dirty = true;
                        break;
                    case UIData.Property.sub:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.controller:
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
                    case Setting.Property.confirmQuit:
                        break;
                    case Setting.Property.boardIndex:
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
            {
                if (wrapProperty.p is UIData.Sub)
                {
                    return;
                }
                if (wrapProperty.p is ViewRecordControllerUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnBack()
        {
            if (this.data != null)
            {
                this.data.dataRecord.v = null;
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}
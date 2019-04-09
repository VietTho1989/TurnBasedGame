using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
    public class WeiqiAIUI : UIHaveTransformDataBehavior<WeiqiAIUI.UIData>
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<WeiqiAI>> editAI;

            public VP<UIRectTransform.ShowType> showType;

            #region canResign

            public VP<RequestChangeBoolUI.UIData> canResign;

            public void makeRequestChangeCanResign(RequestChangeUpdate<bool>.UpdateData update, bool newCanResign)
            {
                // Find weiqiAI
                WeiqiAI weiqiAI = null;
                {
                    EditData<WeiqiAI> editWeiqiAI = this.editAI.v;
                    if (editWeiqiAI != null)
                    {
                        weiqiAI = editWeiqiAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editWeiqiAI null: " + this);
                    }
                }
                // Process
                if (weiqiAI != null)
                {
                    weiqiAI.requestChangeCanResign(Server.getProfileUserId(weiqiAI), newCanResign);
                }
                else
                {
                    Debug.LogError("weiqiAI null: " + this);
                }
            }

            #endregion

            #region useBook

            public VP<RequestChangeBoolUI.UIData> useBook;

            public void makeRequestChangeUseBook(RequestChangeUpdate<bool>.UpdateData update, bool newUseBook)
            {
                // Find weiqiAI
                WeiqiAI weiqiAI = null;
                {
                    EditData<WeiqiAI> editWeiqiAI = this.editAI.v;
                    if (editWeiqiAI != null)
                    {
                        weiqiAI = editWeiqiAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editWeiqiAI null: " + this);
                    }
                }
                // Process
                if (weiqiAI != null)
                {
                    weiqiAI.requestChangeUseBook(Server.getProfileUserId(weiqiAI), newUseBook);
                }
                else
                {
                    Debug.LogError("weiqiAI null: " + this);
                }
            }

            #endregion

            #region time

            public VP<RequestChangeIntUI.UIData> time;

            public void makeRequestChangeTime(RequestChangeUpdate<int>.UpdateData update, int newTime)
            {
                // Find weiqiAI
                WeiqiAI weiqiAI = null;
                {
                    EditData<WeiqiAI> editWeiqiAI = this.editAI.v;
                    if (editWeiqiAI != null)
                    {
                        weiqiAI = editWeiqiAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editWeiqiAI null: " + this);
                    }
                }
                // Process
                if (weiqiAI != null)
                {
                    weiqiAI.requestChangeTime(Server.getProfileUserId(weiqiAI), newTime);
                }
                else
                {
                    Debug.LogError("weiqiAI null: " + this);
                }
            }

            #endregion

            #region games

            public VP<RequestChangeIntUI.UIData> games;

            public void makeRequestChangeGames(RequestChangeUpdate<int>.UpdateData update, int newGames)
            {
                // Find weiqiAI
                WeiqiAI weiqiAI = null;
                {
                    EditData<WeiqiAI> editWeiqiAI = this.editAI.v;
                    if (editWeiqiAI != null)
                    {
                        weiqiAI = editWeiqiAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editWeiqiAI null: " + this);
                    }
                }
                // Process
                if (weiqiAI != null)
                {
                    weiqiAI.requestChangeGames(Server.getProfileUserId(weiqiAI), newGames);
                }
                else
                {
                    Debug.LogError("weiqiAI null: " + this);
                }
            }

            #endregion

            #region engine

            public VP<RequestChangeEnumUI.UIData> engine;

            public void makeRequestChangeEngine(RequestChangeUpdate<int>.UpdateData update, int newEngine)
            {
                // Find weiqiAI
                WeiqiAI weiqiAI = null;
                {
                    EditData<WeiqiAI> editWeiqiAI = this.editAI.v;
                    if (editWeiqiAI != null)
                    {
                        weiqiAI = editWeiqiAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editWeiqiAI null: " + this);
                    }
                }
                // Process
                if (weiqiAI != null)
                {
                    switch (newEngine)
                    {
                        case 0:
                            newEngine = (int)Common.engine_id.E_RANDOM;
                            break;
                        case 1:
                            newEngine = (int)Common.engine_id.E_UCT;
                            break;
                        default:
                            Debug.LogError("unknown engine: " + newEngine + "; " + this);
                            newEngine = (int)Common.engine_id.E_UCT;
                            break;
                    }
                    weiqiAI.requestChangeEngine(Server.getProfileUserId(weiqiAI), newEngine);
                }
                else
                {
                    Debug.LogError("weiqiAI null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editAI,
                showType,
                canResign,
                useBook,
                time,
                games,
                engine
            }

            public UIData() : base()
            {
                this.editAI = new VP<EditData<WeiqiAI>>(this, (byte)Property.editAI, new EditData<WeiqiAI>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // canResign
                {
                    this.canResign = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.canResign, new RequestChangeBoolUI.UIData());
                    // event
                    this.canResign.v.updateData.v.request.v = makeRequestChangeCanResign;
                }
                // useBook
                {
                    this.useBook = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.useBook, new RequestChangeBoolUI.UIData());
                    // event
                    this.useBook.v.updateData.v.request.v = makeRequestChangeUseBook;
                }
                // time
                {
                    this.time = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.time, new RequestChangeIntUI.UIData());
                    // event
                    this.time.v.updateData.v.request.v = makeRequestChangeTime;
                }
                // games
                {
                    this.games = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.games, new RequestChangeIntUI.UIData());
                    // event
                    this.games.v.updateData.v.request.v = makeRequestChangeGames;
                }
                // engine
                {
                    this.engine = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.engine, new RequestChangeEnumUI.UIData());
                    // event
                    this.engine.v.updateData.v.request.v = makeRequestChangeEngine;
                    {
                        this.engine.v.options.add("RANDOM");
                        this.engine.v.options.add("UCT");
                    }
                }
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.Weiqi;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Weiqi AI");

        public Text lbCanResign;
        private static readonly TxtLanguage txtCanResign = new TxtLanguage("Can resign");

        public Text lbUseBook;
        private static readonly TxtLanguage txtUseBook = new TxtLanguage("Use book");

        public Text lbTime;
        private static readonly TxtLanguage txtTime = new TxtLanguage("Time");

        public Text lbGames;
        private static readonly TxtLanguage txtGames = new TxtLanguage("Games");

        public Text lbEngine;
        private static readonly TxtLanguage txtEngine = new TxtLanguage("Engine");

        static WeiqiAIUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Cờ Vây AI");
                txtCanResign.add(Language.Type.vi, "Có thể từ bỏ");
                txtUseBook.add(Language.Type.vi, "Dùng sách");
                txtTime.add(Language.Type.vi, "Thời gian");
                txtGames.add(Language.Type.vi, "Games");
                txtEngine.add(Language.Type.vi, "Engine");
            }
        }

        #endregion

        #region Refresh

        private bool needReset = true;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<WeiqiAI> editWeiqiAI = this.data.editAI.v;
                    if (editWeiqiAI != null)
                    {
                        editWeiqiAI.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editWeiqiAI);
                            // get server state
                            Server.State.Type serverState = RequestChange.GetServerState(editWeiqiAI);
                            // set origin
                            {
                                RequestChange.RefreshUI(this.data.canResign.v, editWeiqiAI, serverState, needReset, editData => editData.canResign.v);
                                RequestChange.RefreshUI(this.data.useBook.v, editWeiqiAI, serverState, needReset, editData => editData.useBook.v);
                                RequestChange.RefreshUI(this.data.time.v, editWeiqiAI, serverState, needReset, editData => editData.time.v);
                                RequestChange.RefreshUI(this.data.games.v, editWeiqiAI, serverState, needReset, editData => editData.games.v);
                                RequestChange.RefreshUI(this.data.engine.v, editWeiqiAI, serverState, needReset, editData => editData.getEngineId());
                            }
                            needReset = false;
                        }
                    }
                    else
                    {
                        Debug.LogError("editShatranjAI null: " + this);
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // header
                        UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                        // canResign
                        {
                            if (this.data.canResign.v != null)
                            {
                                if (lbCanResign != null)
                                {
                                    lbCanResign.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbCanResign.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbCanResign null");
                                }
                                UIRectTransform.SetPosY(this.data.canResign.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbCanResign != null)
                                {
                                    lbCanResign.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbCanResign null");
                                }
                            }
                        }
                        // useBook
                        {
                            if (this.data.useBook.v != null)
                            {
                                if (lbUseBook != null)
                                {
                                    lbUseBook.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbUseBook.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbUseBook null");
                                }
                                UIRectTransform.SetPosY(this.data.useBook.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbUseBook != null)
                                {
                                    lbUseBook.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbUseBook null");
                                }
                            }
                        }
                        // time
                        {
                            if (this.data.time.v != null)
                            {
                                if (lbTime != null)
                                {
                                    lbTime.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbTime.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbTime null");
                                }
                                UIRectTransform.SetPosY(this.data.time.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbTime != null)
                                {
                                    lbTime.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbTime null");
                                }
                            }
                        }
                        // games
                        {
                            if (this.data.games.v != null)
                            {
                                if (lbGames != null)
                                {
                                    lbGames.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbGames.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbGames null");
                                }
                                UIRectTransform.SetPosY(this.data.games.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbGames != null)
                                {
                                    lbGames.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbGames null");
                                }
                            }
                        }
                        // engine
                        {
                            if (this.data.engine.v != null)
                            {
                                if (lbEngine != null)
                                {
                                    lbEngine.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbEngine.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbEngine null");
                                }
                                UIRectTransform.SetPosY(this.data.engine.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbEngine != null)
                                {
                                    lbEngine.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbEngine null");
                                }
                            }
                        }
                        // set
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
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
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (lbCanResign != null)
                        {
                            lbCanResign.text = txtCanResign.get();
                            Setting.get().setLabelTextSize(lbCanResign);
                        }
                        else
                        {
                            Debug.LogError("lbCanResign null: " + this);
                        }
                        if (lbUseBook != null)
                        {
                            lbUseBook.text = txtUseBook.get();
                            Setting.get().setLabelTextSize(lbUseBook);
                        }
                        else
                        {
                            Debug.LogError("lbUseBook null: " + this);
                        }
                        if (lbTime != null)
                        {
                            lbTime.text = txtTime.get();
                            Setting.get().setLabelTextSize(lbTime);
                        }
                        else
                        {
                            Debug.LogError("lbTime null: " + this);
                        }
                        if (lbGames != null)
                        {
                            lbGames.text = txtGames.get();
                            Setting.get().setLabelTextSize(lbGames);
                        }
                        else
                        {
                            Debug.LogError("lbGames null: " + this);
                        }
                        if (lbEngine != null)
                        {
                            lbEngine.text = txtEngine.get();
                            Setting.get().setLabelTextSize(lbEngine);
                        }
                        else
                        {
                            Debug.LogError("lbEngine null: " + this);
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

        public RequestChangeIntUI requestIntPrefab;
        public RequestChangeBoolUI requestBoolPrefab;
        public RequestChangeEnumUI requestEnumPrefab;

        private Server server = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.editAI.allAddCallBack(this);
                    uiData.canResign.allAddCallBack(this);
                    uiData.useBook.allAddCallBack(this);
                    uiData.time.allAddCallBack(this);
                    uiData.games.allAddCallBack(this);
                    uiData.engine.allAddCallBack(this);
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
                // editAI
                {
                    if (data is EditData<WeiqiAI>)
                    {
                        EditData<WeiqiAI> editAI = data as EditData<WeiqiAI>;
                        // Child
                        {
                            editAI.show.allAddCallBack(this);
                            editAI.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is WeiqiAI)
                        {
                            WeiqiAI weiqiAI = data as WeiqiAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack(weiqiAI, this, ref this.server);
                            }
                            dirty = true;
                            needReset = true;
                            return;
                        }
                        // Parent
                        {
                            if (data is Server)
                            {
                                dirty = true;
                                return;
                            }
                        }
                    }
                }
                if (data is RequestChangeIntUI.UIData)
                {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.time:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.games:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("wrapProperty null: " + this);
                        }
                    }
                    dirty = true;
                    return;
                }
                if (data is RequestChangeBoolUI.UIData)
                {
                    RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.canResign:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.useBook:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("wrapProperty null: " + this);
                        }
                    }
                    dirty = true;
                    return;
                }
                if (data is RequestChangeEnumUI.UIData)
                {
                    RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.engine:
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, UIConstants.RequestEnumRect);
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("wrapProperty null: " + this);
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
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().removeCallBack(this);
                // Child
                {
                    uiData.editAI.allRemoveCallBack(this);
                    uiData.canResign.allRemoveCallBack(this);
                    uiData.useBook.allRemoveCallBack(this);
                    uiData.time.allRemoveCallBack(this);
                    uiData.games.allRemoveCallBack(this);
                    uiData.engine.allRemoveCallBack(this);
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
                // editAI
                {
                    if (data is EditData<WeiqiAI>)
                    {
                        EditData<WeiqiAI> editAI = data as EditData<WeiqiAI>;
                        // Child
                        {
                            editAI.show.allRemoveCallBack(this);
                            editAI.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is WeiqiAI)
                        {
                            WeiqiAI weiqiAI = data as WeiqiAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(weiqiAI, this, ref this.server);
                            }
                            return;
                        }
                        // Parent
                        {
                            if (data is Server)
                            {
                                return;
                            }
                        }
                    }
                }
                if (data is RequestChangeIntUI.UIData)
                {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
                    }
                    return;
                }
                if (data is RequestChangeBoolUI.UIData)
                {
                    RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeBoolUI));
                    }
                    return;
                }
                if (data is RequestChangeEnumUI.UIData)
                {
                    RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
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
                    case UIData.Property.editAI:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.canResign:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.useBook:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.time:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.games:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.engine:
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
                    case Setting.Property.contentTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.titleTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.labelTextSize:
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
            {
                // editAI
                {
                    if (wrapProperty.p is EditData<WeiqiAI>)
                    {
                        switch ((EditData<WeiqiAI>.Property)wrapProperty.n)
                        {
                            case EditData<WeiqiAI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<WeiqiAI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<WeiqiAI>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<WeiqiAI>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<WeiqiAI>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<WeiqiAI>.Property.editType:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is WeiqiAI)
                        {
                            switch ((WeiqiAI.Property)wrapProperty.n)
                            {
                                case WeiqiAI.Property.canResign:
                                    dirty = true;
                                    break;
                                case WeiqiAI.Property.useBook:
                                    dirty = true;
                                    break;
                                case WeiqiAI.Property.time:
                                    dirty = true;
                                    break;
                                case WeiqiAI.Property.games:
                                    dirty = true;
                                    break;
                                case WeiqiAI.Property.engine:
                                    dirty = true;
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        if (wrapProperty.p is Server)
                        {
                            Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                            return;
                        }
                    }
                }
                if (wrapProperty.p is RequestChangeIntUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is RequestChangeBoolUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is RequestChangeEnumUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
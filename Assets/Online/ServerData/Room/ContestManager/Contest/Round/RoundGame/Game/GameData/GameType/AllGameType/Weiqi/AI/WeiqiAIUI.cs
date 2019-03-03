using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
    public class WeiqiAIUI : UIBehavior<WeiqiAIUI.UIData>, HaveTransformData
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
                            newEngine = (int)Common.engine_id.E_PATTERNPLAY;
                            break;
                        case 2:
                            newEngine = (int)Common.engine_id.E_MONTECARLO;
                            break;
                        case 3:
                            newEngine = (int)Common.engine_id.E_UCT;
                            break;
                        default:
                            Debug.LogError("unknown engine: " + newEngine + "; " + this);
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
                        this.engine.v.options.add("PATTERNPLAY");
                        this.engine.v.options.add("MONTECARLO");
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
        public static readonly TxtLanguage txtTitle = new TxtLanguage();

        public Text lbCanResign;
        public static readonly TxtLanguage txtCanResign = new TxtLanguage();

        public Text lbUseBook;
        public static readonly TxtLanguage txtUseBook = new TxtLanguage();

        public Text lbTime;
        public static readonly TxtLanguage txtTime = new TxtLanguage();

        public Text lbGames;
        public static readonly TxtLanguage txtGames = new TxtLanguage();

        public Text lbEngine;
        public static readonly TxtLanguage txtEngine = new TxtLanguage();

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
            // rect
            {
                canResignRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                useBookRect.setPosY(UIConstants.HeaderHeight + 1 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                timeRect.setPosY(UIConstants.HeaderHeight + 2 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                gamesRect.setPosY(UIConstants.HeaderHeight + 3 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                engineRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
            }
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

        private bool needReset = true;

        public Image header;

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
                        // get show
                        WeiqiAI show = editWeiqiAI.show.v.data;
                        WeiqiAI compare = editWeiqiAI.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editWeiqiAI.compareOtherType.v.data != null)
                                    {
                                        if (editWeiqiAI.compareOtherType.v.data.GetType() != show.GetType())
                                        {
                                            isDifferent = true;
                                        }
                                    }
                                }
                                lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
                            }
                            else
                            {
                                Debug.LogError("lbTitle null: " + this);
                            }
                            // get server state
                            Server.State.Type serverState = Server.State.Type.Connect;
                            {
                                Server server = show.findDataInParent<Server>();
                                if (server != null)
                                {
                                    if (server.state.v != null)
                                    {
                                        serverState = server.state.v.getType();
                                    }
                                    else
                                    {
                                        Debug.LogError("server state null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("server null: " + this);
                                }
                            }
                            // set origin
                            {
                                // canResign
                                {
                                    RequestChangeBoolUI.UIData canResign = this.data.canResign.v;
                                    if (canResign != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<bool>.UpdateData updateData = canResign.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.canResign.v;
                                            updateData.canRequestChange.v = editWeiqiAI.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                canResign.showDifferent.v = true;
                                                canResign.compare.v = compare.canResign.v;
                                            }
                                            else
                                            {
                                                canResign.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("canResign null: " + this);
                                    }
                                }
                                // useBook
                                {
                                    RequestChangeBoolUI.UIData useBook = this.data.useBook.v;
                                    if (useBook != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<bool>.UpdateData updateData = useBook.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.useBook.v;
                                            updateData.canRequestChange.v = editWeiqiAI.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                useBook.showDifferent.v = true;
                                                useBook.compare.v = compare.useBook.v;
                                            }
                                            else
                                            {
                                                useBook.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("useBook null: " + this);
                                    }
                                }
                                // time
                                {
                                    RequestChangeIntUI.UIData time = this.data.time.v;
                                    if (time != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<int>.UpdateData updateData = time.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.time.v;
                                            updateData.canRequestChange.v = editWeiqiAI.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                time.showDifferent.v = true;
                                                time.compare.v = compare.time.v;
                                            }
                                            else
                                            {
                                                time.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("time null: " + this);
                                    }
                                }
                                // games
                                {
                                    RequestChangeIntUI.UIData games = this.data.games.v;
                                    if (games != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<int>.UpdateData updateData = games.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.games.v;
                                            updateData.canRequestChange.v = editWeiqiAI.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                games.showDifferent.v = true;
                                                games.compare.v = compare.games.v;
                                            }
                                            else
                                            {
                                                games.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("games null: " + this);
                                    }
                                }
                                // engine
                                {
                                    RequestChangeEnumUI.UIData engine = this.data.engine.v;
                                    if (engine != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<int>.UpdateData updateData = engine.updateData.v;
                                        if (updateData != null)
                                        {
                                            {
                                                int engineId = 0;
                                                {
                                                    switch ((Common.engine_id)show.engine.v)
                                                    {
                                                        case Common.engine_id.E_RANDOM:
                                                            engineId = 0;
                                                            break;
                                                        case Common.engine_id.E_REPLAY:
                                                            engineId = 1;
                                                            break;
                                                        case Common.engine_id.E_PATTERNSCAN:
                                                            engineId = 3;
                                                            break;
                                                        case Common.engine_id.E_PATTERNPLAY:
                                                            engineId = 3;
                                                            break;
                                                        case Common.engine_id.E_MONTECARLO:
                                                            engineId = 2;
                                                            break;
                                                        case Common.engine_id.E_UCT:
                                                            engineId = 3;
                                                            break;
                                                        case Common.engine_id.E_DISTRIBUTED:
                                                            engineId = 3;
                                                            break;
                                                        case Common.engine_id.E_JOSEKI:
                                                            engineId = 3;
                                                            break;
                                                        case Common.engine_id.E_DCNN:
                                                            engineId = 3;
                                                            break;
                                                        case Common.engine_id.E_MAX:
                                                            engineId = 3;
                                                            break;
                                                        default:
                                                            Debug.LogError("unknown engine_id: " + show.engine.v);
                                                            break;
                                                    }
                                                }
                                                updateData.origin.v = engineId;
                                            }
                                            updateData.canRequestChange.v = editWeiqiAI.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                engine.showDifferent.v = true;
                                                engine.compare.v = compare.engine.v;
                                            }
                                            else
                                            {
                                                engine.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("engine null: " + this);
                                    }
                                }
                            }
                            // reset?
                            if (needReset)
                            {
                                needReset = false;
                                // canResign
                                {
                                    RequestChangeBoolUI.UIData canResign = this.data.canResign.v;
                                    if (canResign != null)
                                    {
                                        RequestChangeUpdate<bool>.UpdateData updateData = canResign.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.canResign.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("canResign null: " + this);
                                    }
                                }
                                // useBook
                                {
                                    RequestChangeBoolUI.UIData useBook = this.data.useBook.v;
                                    if (useBook != null)
                                    {
                                        RequestChangeUpdate<bool>.UpdateData updateData = useBook.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.useBook.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("useBook null: " + this);
                                    }
                                }
                                // time
                                {
                                    RequestChangeIntUI.UIData time = this.data.time.v;
                                    if (time != null)
                                    {
                                        RequestChangeUpdate<int>.UpdateData updateData = time.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.time.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("time null: " + this);
                                    }
                                }
                                // games
                                {
                                    RequestChangeIntUI.UIData games = this.data.games.v;
                                    if (games != null)
                                    {
                                        RequestChangeUpdate<int>.UpdateData updateData = games.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.games.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("games null: " + this);
                                    }
                                }
                                // engine
                                {
                                    RequestChangeEnumUI.UIData engine = this.data.engine.v;
                                    if (engine != null)
                                    {
                                        RequestChangeUpdate<int>.UpdateData updateData = engine.updateData.v;
                                        if (updateData != null)
                                        {
                                            {
                                                int engineId = 0;
                                                {
                                                    switch ((Common.engine_id)show.engine.v)
                                                    {
                                                        case Common.engine_id.E_RANDOM:
                                                            engineId = 0;
                                                            break;
                                                        case Common.engine_id.E_REPLAY:
                                                            engineId = 1;
                                                            break;
                                                        case Common.engine_id.E_PATTERNSCAN:
                                                            engineId = 3;
                                                            break;
                                                        case Common.engine_id.E_PATTERNPLAY:
                                                            engineId = 3;
                                                            break;
                                                        case Common.engine_id.E_MONTECARLO:
                                                            engineId = 2;
                                                            break;
                                                        case Common.engine_id.E_UCT:
                                                            engineId = 3;
                                                            break;
                                                        case Common.engine_id.E_DISTRIBUTED:
                                                            engineId = 3;
                                                            break;
                                                        case Common.engine_id.E_JOSEKI:
                                                            engineId = 3;
                                                            break;
                                                        case Common.engine_id.E_DCNN:
                                                            engineId = 3;
                                                            break;
                                                        case Common.engine_id.E_MAX:
                                                            engineId = 3;
                                                            break;
                                                        default:
                                                            Debug.LogError("unknown engine_id: " + show.engine.v);
                                                            break;
                                                    }
                                                }
                                                updateData.current.v = engineId;
                                            }
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("engine null: " + this);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("shatranjAI null: " + this);
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
                        {
                            switch (this.data.showType.v)
                            {
                                case UIRectTransform.ShowType.Normal:
                                    {
                                        if (lbTitle != null)
                                        {
                                            lbTitle.gameObject.SetActive(true);
                                        }
                                        else
                                        {
                                            Debug.LogError("lbTitle null");
                                        }
                                        if (header != null)
                                        {
                                            header.gameObject.SetActive(true);
                                        }
                                        else
                                        {
                                            Debug.LogError("header null");
                                        }
                                        deltaY += UIConstants.HeaderHeight;
                                    }
                                    break;
                                case UIRectTransform.ShowType.HeadLess:
                                    {
                                        if (lbTitle != null)
                                        {
                                            lbTitle.gameObject.SetActive(false);
                                        }
                                        else
                                        {
                                            Debug.LogError("lbTitle null");
                                        }
                                        if (header != null)
                                        {
                                            header.gameObject.SetActive(false);
                                        }
                                        else
                                        {
                                            Debug.LogError("header null");
                                        }
                                    }
                                    break;
                                case UIRectTransform.ShowType.OnlyHead:
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + this.data.showType.v);
                                    break;
                            }
                        }
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
                            lbTitle.text = txtTitle.get("Weiqi AI");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (lbCanResign != null)
                        {
                            lbCanResign.text = txtCanResign.get("Can resign");
                        }
                        else
                        {
                            Debug.LogError("lbCanResign null: " + this);
                        }
                        if (lbUseBook != null)
                        {
                            lbUseBook.text = txtUseBook.get("Use book");
                        }
                        else
                        {
                            Debug.LogError("lbUseBook null: " + this);
                        }
                        if (lbTime != null)
                        {
                            lbTime.text = txtTime.get("Time");
                        }
                        else
                        {
                            Debug.LogError("lbTime null: " + this);
                        }
                        if (lbGames != null)
                        {
                            lbGames.text = txtGames.get("Games");
                        }
                        else
                        {
                            Debug.LogError("lbGames null: " + this);
                        }
                        if (lbEngine != null)
                        {
                            lbEngine.text = txtEngine.get("Engine");
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
            updateTransformData();
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        private static readonly UIRectTransform canResignRect = new UIRectTransform(UIConstants.RequestBoolRect);
        private static readonly UIRectTransform useBookRect = new UIRectTransform(UIConstants.RequestBoolRect);
        private static readonly UIRectTransform timeRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform gamesRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform engineRect = new UIRectTransform(UIConstants.RequestEnumRect);

        public RequestChangeIntUI requestIntPrefab;
        public RequestChangeBoolUI requestBoolPrefab;
        public RequestChangeEnumUI requestEnumPrefab;

        private Server server = null;

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
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, timeRect);
                                    break;
                                case UIData.Property.games:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, gamesRect);
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
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, canResignRect);
                                    break;
                                case UIData.Property.useBook:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, useBookRect);
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
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, engineRect);
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
                // Global
                Global.get().removeCallBack(this);
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
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
    public class DefaultWeiqiUI : UIHaveTransformDataBehavior<DefaultWeiqiUI.UIData>
    {

        #region UIData

        public class UIData : DefaultGameTypeUI
        {

            public VP<EditData<DefaultWeiqi>> editDefaultWeiqi;

            public VP<UIRectTransform.ShowType> showType;

            #region boardSize

            public VP<RequestChangeIntUI.UIData> size;

            public void makeRequestChangeSize(RequestChangeUpdate<int>.UpdateData update, int newSize)
            {
                // Find
                DefaultWeiqi defaultWeiqi = null;
                {
                    EditData<DefaultWeiqi> editDefaultWeiqi = this.editDefaultWeiqi.v;
                    if (editDefaultWeiqi != null)
                    {
                        defaultWeiqi = editDefaultWeiqi.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultWeiqi null: " + this);
                    }
                }
                // Process
                if (defaultWeiqi != null)
                {
                    defaultWeiqi.requestChangeSize(Server.getProfileUserId(defaultWeiqi), newSize);
                }
                else
                {
                    Debug.LogError("defaultWeiqi null: " + this);
                }
            }

            #endregion

            #region komi

            public VP<RequestChangeFloatUI.UIData> komi;

            public void makeRequestChangeKomi(RequestChangeUpdate<float>.UpdateData update, float newKomi)
            {
                // Find
                DefaultWeiqi defaultWeiqi = null;
                {
                    EditData<DefaultWeiqi> editDefaultWeiqi = this.editDefaultWeiqi.v;
                    if (editDefaultWeiqi != null)
                    {
                        defaultWeiqi = editDefaultWeiqi.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultWeiqi null: " + this);
                    }
                }
                // Process
                if (defaultWeiqi != null)
                {
                    defaultWeiqi.requestChangeKomi(Server.getProfileUserId(defaultWeiqi), newKomi);
                }
                else
                {
                    Debug.LogError("defaultWeiqi null: " + this);
                }
            }

            #endregion

            #region rule

            public VP<RequestChangeEnumUI.UIData> rule;

            public void makeRequestChangeRule(RequestChangeUpdate<int>.UpdateData update, int newRule)
            {
                // Find
                DefaultWeiqi defaultWeiqi = null;
                {
                    EditData<DefaultWeiqi> editDefaultWeiqi = this.editDefaultWeiqi.v;
                    if (editDefaultWeiqi != null)
                    {
                        defaultWeiqi = editDefaultWeiqi.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultWeiqi null: " + this);
                    }
                }
                // Process
                if (defaultWeiqi != null)
                {
                    defaultWeiqi.requestChangeRule(Server.getProfileUserId(defaultWeiqi), newRule);
                }
                else
                {
                    Debug.LogError("defaultWeiqi null: " + this);
                }
            }

            #endregion

            #region handicap

            public VP<RequestChangeIntUI.UIData> handicap;

            public void makeRequestChangeHandicap(RequestChangeUpdate<int>.UpdateData update, int newHandicap)
            {
                // Find
                DefaultWeiqi defaultWeiqi = null;
                {
                    EditData<DefaultWeiqi> editDefaultWeiqi = this.editDefaultWeiqi.v;
                    if (editDefaultWeiqi != null)
                    {
                        defaultWeiqi = editDefaultWeiqi.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editDefaultWeiqi null: " + this);
                    }
                }
                // Process
                if (defaultWeiqi != null)
                {
                    defaultWeiqi.requestChangeHandicap(Server.getProfileUserId(defaultWeiqi), newHandicap);
                }
                else
                {
                    Debug.LogError("defaultWeiqi null: " + this);
                }
            }

            #endregion

            public VP<MiniGameDataUI.UIData> miniGameDataUIData;

            #region Constructor

            public enum Property
            {
                editDefaultWeiqi,
                showType,

                size,
                komi,
                rule,
                handicap,

                miniGameDataUIData
            }

            public UIData() : base()
            {
                this.editDefaultWeiqi = new VP<EditData<DefaultWeiqi>>(this, (byte)Property.editDefaultWeiqi, new EditData<DefaultWeiqi>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // size
                {
                    this.size = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.size, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.size.v.limit.makeId();
                            have.min.v = 5;
                            have.max.v = 19;
                        }
                        this.size.v.limit.v = have;
                    }
                    // event
                    this.size.v.updateData.v.request.v = makeRequestChangeSize;
                }
                // komi
                {
                    this.komi = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.komi, new RequestChangeFloatUI.UIData());
                    // event
                    this.komi.v.updateData.v.request.v = makeRequestChangeKomi;
                }
                // rule
                {
                    this.rule = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.rule, new RequestChangeEnumUI.UIData());
                    // event
                    this.rule.v.updateData.v.request.v = makeRequestChangeRule;
                    {
                        this.rule.v.options.add("Chinese");
                        this.rule.v.options.add("AGA");
                        this.rule.v.options.add("New Zealand");
                        this.rule.v.options.add("Japanese");
                        this.rule.v.options.add("Stones only");
                        this.rule.v.options.add("Siming");
                    }
                }
                // handicap
                {
                    this.handicap = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.handicap, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.handicap.v.limit.makeId();
                            have.min.v = 0;
                            have.max.v = 9;
                        }
                        this.handicap.v.limit.v = have;
                    }
                    // event
                    this.handicap.v.updateData.v.request.v = makeRequestChangeHandicap;
                }
                this.miniGameDataUIData = new VP<MiniGameDataUI.UIData>(this, (byte)Property.miniGameDataUIData, new MiniGameDataUI.UIData());
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
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Default Weiqi");

        public Text lbSize;
        private static readonly TxtLanguage txtSize = new TxtLanguage("Size");

        public Text lbKomi;
        private static readonly TxtLanguage txtKomi = new TxtLanguage("Komi");

        public Text lbRule;
        private static readonly TxtLanguage txtRule = new TxtLanguage("Rule");

        public Text lbHandicap;
        private static readonly TxtLanguage txtHandicap = new TxtLanguage("Handicap");

        static DefaultWeiqiUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Mặc Định Cờ Vây");
                txtSize.add(Language.Type.vi, "Kích thước");
                txtKomi.add(Language.Type.vi, "Komi");
                txtRule.add(Language.Type.vi, "Luật");
                txtHandicap.add(Language.Type.vi, "Chấp");
            }
            // rect
            {
                sizeRect.setPosY(UIConstants.HeaderHeight + UIConstants.DefaultMiniGameDataUISize + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                komiRect.setPosY(UIConstants.HeaderHeight + UIConstants.DefaultMiniGameDataUISize + 1 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                ruleRect.setPosY(UIConstants.HeaderHeight + UIConstants.DefaultMiniGameDataUISize + 2 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                handicapRect.setPosY(UIConstants.HeaderHeight + UIConstants.DefaultMiniGameDataUISize + 3 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
            }
        }

        #endregion

        #region Refresh

        private bool needReset = true;
        private bool miniGameDataDirty = true;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<DefaultWeiqi> editDefaultWeiqi = this.data.editDefaultWeiqi.v;
                    if (editDefaultWeiqi != null)
                    {
                        editDefaultWeiqi.update();
                        // get show
                        DefaultWeiqi show = editDefaultWeiqi.show.v.data;
                        DefaultWeiqi compare = editDefaultWeiqi.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editDefaultWeiqi.compareOtherType.v.data != null)
                                    {
                                        if (editDefaultWeiqi.compareOtherType.v.data.GetType() != show.GetType())
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
                            // request
                            {
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
                                    // size
                                    {
                                        RequestChangeIntUI.UIData size = this.data.size.v;
                                        if (size != null)
                                        {
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = size.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.size.v;
                                                updateData.canRequestChange.v = editDefaultWeiqi.canEdit.v;
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
                                                    size.showDifferent.v = true;
                                                    size.compare.v = compare.size.v;
                                                }
                                                else
                                                {
                                                    size.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("size null: " + this);
                                        }
                                    }
                                    // komi
                                    {
                                        RequestChangeFloatUI.UIData komi = this.data.komi.v;
                                        if (komi != null)
                                        {
                                            // update
                                            RequestChangeUpdate<float>.UpdateData updateData = komi.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.komi.v;
                                                updateData.canRequestChange.v = editDefaultWeiqi.canEdit.v;
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
                                                    komi.showDifferent.v = true;
                                                    komi.compare.v = compare.komi.v;
                                                }
                                                else
                                                {
                                                    komi.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("komi null: " + this);
                                        }
                                    }
                                    // rule
                                    {
                                        RequestChangeEnumUI.UIData rule = this.data.rule.v;
                                        if (rule != null)
                                        {
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = rule.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.rule.v;
                                                updateData.canRequestChange.v = editDefaultWeiqi.canEdit.v;
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
                                                    rule.showDifferent.v = true;
                                                    rule.compare.v = compare.rule.v;
                                                }
                                                else
                                                {
                                                    rule.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("rule null: " + this);
                                        }
                                    }
                                    // handicap
                                    {
                                        RequestChangeIntUI.UIData handicap = this.data.handicap.v;
                                        if (handicap != null)
                                        {
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = handicap.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.handicap.v;
                                                updateData.canRequestChange.v = editDefaultWeiqi.canEdit.v;
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
                                                    handicap.showDifferent.v = true;
                                                    handicap.compare.v = compare.handicap.v;
                                                }
                                                else
                                                {
                                                    handicap.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("handicap null: " + this);
                                        }
                                    }
                                }
                                // reset?
                                if (needReset)
                                {
                                    needReset = false;
                                    // size
                                    {
                                        RequestChangeIntUI.UIData size = this.data.size.v;
                                        if (size != null)
                                        {
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = size.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.current.v = show.size.v;
                                                updateData.changeState.v = Data.ChangeState.None;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("size null: " + this);
                                        }
                                    }
                                    // komi
                                    {
                                        RequestChangeFloatUI.UIData komi = this.data.komi.v;
                                        if (komi != null)
                                        {
                                            // update
                                            RequestChangeUpdate<float>.UpdateData updateData = komi.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.current.v = show.komi.v;
                                                updateData.changeState.v = Data.ChangeState.None;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("komi null: " + this);
                                        }
                                    }
                                    // rule
                                    {
                                        RequestChangeEnumUI.UIData rule = this.data.rule.v;
                                        if (rule != null)
                                        {
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = rule.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.current.v = show.rule.v;
                                                updateData.changeState.v = Data.ChangeState.None;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("rule null: " + this);
                                        }
                                    }
                                    // handicap
                                    {
                                        RequestChangeIntUI.UIData handicap = this.data.handicap.v;
                                        if (handicap != null)
                                        {
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = handicap.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.current.v = show.handicap.v;
                                                updateData.changeState.v = Data.ChangeState.None;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("handicap null: " + this);
                                        }
                                    }
                                }
                            }
                            // miniGameDataUIData
                            if (miniGameDataDirty)
                            {
                                miniGameDataDirty = false;
                                // find miniGameDataUIData
                                MiniGameDataUI.UIData miniGameDataUIData = this.data.miniGameDataUIData.newOrOld<MiniGameDataUI.UIData>();
                                {
                                    // gameData
                                    {
                                        // Find GameData
                                        GameData gameData = null;
                                        {
                                            // Find old
                                            if (miniGameDataUIData.gameData.v.data != null)
                                            {
                                                gameData = miniGameDataUIData.gameData.v.data;
                                            }
                                            // Make new
                                            if (gameData == null)
                                            {
                                                gameData = new GameData();
                                                miniGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                        }
                                        // Update Property
                                        {
                                            // GameType
                                            {
                                                // Find Weiqi
                                                Weiqi weiqi = gameData.gameType.newOrOld<Weiqi>();
                                                {
                                                    // Check need update
                                                    bool needUpdate = false;
                                                    {
                                                        Board board = weiqi.b.v;
                                                        if (board != null)
                                                        {
                                                            if (board.size.v != show.size.v + 2 || board.komi.v != show.komi.v
                                                               || board.rules.v != show.rule.v || board.handicap.v != show.handicap.v)
                                                            {
                                                                needUpdate = true;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("board null: " + this);
                                                            needUpdate = true;
                                                        }
                                                    }
                                                    // Update Property
                                                    if (needUpdate)
                                                    {
                                                        // Make new weiqi to update
                                                        Weiqi newWeiqi = (Weiqi)show.makeDefaultGameType();
                                                        // Copy
                                                        DataUtils.copyData(weiqi, newWeiqi);
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("Don't need update: " + this);
                                                    }
                                                }
                                                gameData.gameType.v = weiqi;
                                            }
                                        }
                                    }
                                }
                                this.data.miniGameDataUIData.v = miniGameDataUIData;
                            }
                        }
                        else
                        {
                            Debug.LogError("show null: " + this);
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
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown showType: " + this.data.showType.v);
                                        break;
                                }
                            }
                            // miniGameDataUI
                            {
                                UIRectTransform.SetPosY(this.data.miniGameDataUIData.v, deltaY + UIConstants.DefaultMiniGameDataUIPadding);
                                deltaY += UIConstants.DefaultMiniGameDataUISize;
                            }
                            // size
                            {
                                if (this.data.size.v != null)
                                {
                                    if (lbSize != null)
                                    {
                                        lbSize.gameObject.SetActive(true);
                                        UIRectTransform.SetPosY(lbSize.rectTransform, deltaY);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbSize null");
                                    }
                                    UIRectTransform.SetPosY(this.data.size.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbSize != null)
                                    {
                                        lbSize.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbSize null");
                                    }
                                }
                            }
                            // komi
                            {
                                if (this.data.komi.v != null)
                                {
                                    if (lbKomi != null)
                                    {
                                        lbKomi.gameObject.SetActive(true);
                                        UIRectTransform.SetPosY(lbKomi.rectTransform, deltaY);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbKomi null");
                                    }
                                    UIRectTransform.SetPosY(this.data.komi.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbKomi != null)
                                    {
                                        lbKomi.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbKomi null");
                                    }
                                }
                            }
                            // rule
                            {
                                if (this.data.rule.v != null)
                                {
                                    if (lbRule != null)
                                    {
                                        lbRule.gameObject.SetActive(true);
                                        UIRectTransform.SetPosY(lbRule.rectTransform, deltaY);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbRule null");
                                    }
                                    UIRectTransform.SetPosY(this.data.rule.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbRule != null)
                                    {
                                        lbRule.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbRule null");
                                    }
                                }
                            }
                            // handicap
                            {
                                if (this.data.handicap.v != null)
                                {
                                    if (lbHandicap != null)
                                    {
                                        lbHandicap.gameObject.SetActive(true);
                                        UIRectTransform.SetPosY(lbHandicap.rectTransform, deltaY);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbHandicap null");
                                    }
                                    UIRectTransform.SetPosY(this.data.handicap.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbHandicap != null)
                                    {
                                        lbHandicap.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbHandicap null");
                                    }
                                }
                            }
                            // Set
                            UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                        }
                        // txt
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.text = txtTitle.get();
                            }
                            else
                            {
                                Debug.LogError("lbTitle null: " + this);
                            }
                            if (lbSize != null)
                            {
                                lbSize.text = txtSize.get();
                            }
                            else
                            {
                                Debug.LogError("lbSize null: " + this);
                            }
                            if (lbKomi != null)
                            {
                                lbKomi.text = txtKomi.get();
                            }
                            else
                            {
                                Debug.LogError("lbKomi null: " + this);
                            }
                            if (lbRule != null)
                            {
                                lbRule.text = txtRule.get();
                            }
                            else
                            {
                                Debug.LogError("lbRule null: " + this);
                            }
                            if (lbHandicap != null)
                            {
                                lbHandicap.text = txtHandicap.get();
                            }
                            else
                            {
                                Debug.LogError("lbHandicap null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("editDefaultWeiqi null: " + this);
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

        public MiniGameDataUI miniGameDataUIPrefab;

        public RequestChangeIntUI requestIntPrefab;
        public RequestChangeFloatUI requestFloatPrefab;
        public RequestChangeEnumUI requestEnumPrefab;

        private static readonly UIRectTransform sizeRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform komiRect = new UIRectTransform(UIConstants.RequestRect);
        private static readonly UIRectTransform ruleRect = new UIRectTransform(UIConstants.RequestEnumRect);
        private static readonly UIRectTransform handicapRect = new UIRectTransform(UIConstants.RequestRect);

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
                    uiData.editDefaultWeiqi.allAddCallBack(this);
                    uiData.size.allAddCallBack(this);
                    uiData.komi.allAddCallBack(this);
                    uiData.rule.allAddCallBack(this);
                    uiData.handicap.allAddCallBack(this);
                    uiData.miniGameDataUIData.allAddCallBack(this);
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
                // editDefaultWeiqi
                {
                    if (data is EditData<DefaultWeiqi>)
                    {
                        EditData<DefaultWeiqi> editDefaultWeiqi = data as EditData<DefaultWeiqi>;
                        // Child
                        {
                            editDefaultWeiqi.show.allAddCallBack(this);
                            editDefaultWeiqi.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultWeiqi)
                        {
                            DefaultWeiqi defaultWeiqi = data as DefaultWeiqi;
                            // Parent
                            {
                                DataUtils.addParentCallBack(defaultWeiqi, this, ref this.server);
                            }
                            needReset = true;
                            miniGameDataDirty = true;
                            dirty = true;
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
                                case UIData.Property.size:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, sizeRect);
                                    break;
                                case UIData.Property.handicap:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, handicapRect);
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
                if (data is RequestChangeFloatUI.UIData)
                {
                    RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.komi:
                                    UIUtils.Instantiate(requestChange, requestFloatPrefab, this.transform, komiRect);
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
                                case UIData.Property.rule:
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, ruleRect);
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
                // MiniGameDataUIData
                {
                    if (data is MiniGameDataUI.UIData)
                    {
                        MiniGameDataUI.UIData miniGameDataUIData = data as MiniGameDataUI.UIData;
                        // UI
                        {
                            UIUtils.Instantiate(miniGameDataUIData, miniGameDataUIPrefab, this.transform, UIConstants.MiniGameDataUIRect);
                        }
                        // Child
                        {
                            miniGameDataUIData.gameData.allAddCallBack(this);
                        }
                        miniGameDataDirty = true;
                        dirty = true;
                        return;
                    }
                    // GameData
                    {
                        if (data is GameData)
                        {
                            GameData gameData = data as GameData;
                            {
                                gameData.gameType.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // GameType
                        {
                            data.addCallBackAllChildren(this);
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            // Debug.LogError ("Don't process: " + data + "; " + this);
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
                    uiData.editDefaultWeiqi.allRemoveCallBack(this);
                    uiData.size.allRemoveCallBack(this);
                    uiData.komi.allRemoveCallBack(this);
                    uiData.rule.allRemoveCallBack(this);
                    uiData.handicap.allRemoveCallBack(this);
                    uiData.miniGameDataUIData.allRemoveCallBack(this);
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
                // editDefaultWeiqi
                {
                    if (data is EditData<DefaultWeiqi>)
                    {
                        EditData<DefaultWeiqi> editDefaultWeiqi = data as EditData<DefaultWeiqi>;
                        // Child
                        {
                            editDefaultWeiqi.show.allRemoveCallBack(this);
                            editDefaultWeiqi.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultWeiqi)
                        {
                            DefaultWeiqi defaultWeiqi = data as DefaultWeiqi;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(defaultWeiqi, this, ref this.server);
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
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeBoolUI));
                    }
                    return;
                }
                if (data is RequestChangeFloatUI.UIData)
                {
                    RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeFloatUI));
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
                // MiniGameDataUIData
                {
                    if (data is MiniGameDataUI.UIData)
                    {
                        MiniGameDataUI.UIData miniGameDataUIData = data as MiniGameDataUI.UIData;
                        // UI
                        {
                            miniGameDataUIData.removeCallBackAndDestroy(typeof(MiniGameDataUI));
                        }
                        // Child
                        {
                            miniGameDataUIData.gameData.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // GameData
                    {
                        if (data is GameData)
                        {
                            GameData gameData = data as GameData;
                            {
                                gameData.gameType.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // GameType
                        {
                            data.removeCallBackAllChildren(this);
                            return;
                        }
                    }
                }
            }
            // Debug.LogError ("Don't process: " + data + "; " + this);
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
                    case UIData.Property.editDefaultWeiqi:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.size:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.komi:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.rule:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.handicap:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.miniGameDataUIData:
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
            {
                // EditDefaultWeiqi
                {
                    if (wrapProperty.p is EditData<DefaultWeiqi>)
                    {
                        switch ((EditData<DefaultWeiqi>.Property)wrapProperty.n)
                        {
                            case EditData<DefaultWeiqi>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<DefaultWeiqi>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultWeiqi>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<DefaultWeiqi>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<DefaultWeiqi>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<DefaultWeiqi>.Property.editType:
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
                        if (wrapProperty.p is DefaultWeiqi)
                        {
                            switch ((DefaultWeiqi.Property)wrapProperty.n)
                            {
                                case DefaultWeiqi.Property.size:
                                    miniGameDataDirty = true;
                                    dirty = true;
                                    break;
                                case DefaultWeiqi.Property.komi:
                                    miniGameDataDirty = true;
                                    dirty = true;
                                    break;
                                case DefaultWeiqi.Property.rule:
                                    miniGameDataDirty = true;
                                    dirty = true;
                                    break;
                                case DefaultWeiqi.Property.handicap:
                                    miniGameDataDirty = true;
                                    dirty = true;
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Parent
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
                if (wrapProperty.p is RequestChangeFloatUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is RequestChangeEnumUI.UIData)
                {
                    return;
                }
                // MiniGameDataUIData
                {
                    if (wrapProperty.p is MiniGameDataUI.UIData)
                    {
                        switch ((MiniGameDataUI.UIData.Property)wrapProperty.n)
                        {
                            case MiniGameDataUI.UIData.Property.gameData:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case MiniGameDataUI.UIData.Property.board:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // GameData
                    {
                        if (wrapProperty.p is GameData)
                        {
                            switch ((GameData.Property)wrapProperty.n)
                            {
                                case GameData.Property.gameType:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case GameData.Property.useRule:
                                    break;
                                case GameData.Property.turn:
                                    break;
                                case GameData.Property.timeControl:
                                    break;
                                case GameData.Property.lastMove:
                                    break;
                                case GameData.Property.state:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // GameType
                        {
                            if (Generic.IsAddCallBackInterface<T>())
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                            }
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            // Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
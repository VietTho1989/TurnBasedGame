using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Shogi
{
    public class DefaultShogiUI : UIHaveTransformDataBehavior<DefaultShogiUI.UIData>
    {

        #region UIData

        public class UIData : DefaultGameTypeUI
        {

            public VP<EditData<DefaultShogi>> editDefaultShogi;

            public VP<UIRectTransform.ShowType> showType;

            public VP<MiniGameDataUI.UIData> miniGameDataUIData;

            #region Constructor

            public enum Property
            {
                editDefaultShogi,
                showType,
                miniGameDataUIData
            }

            public UIData() : base()
            {
                this.editDefaultShogi = new VP<EditData<DefaultShogi>>(this, (byte)Property.editDefaultShogi, new EditData<DefaultShogi>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                this.miniGameDataUIData = new VP<MiniGameDataUI.UIData>(this, (byte)Property.miniGameDataUIData, new MiniGameDataUI.UIData());
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.SHOGI;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Default Shogi");

        static DefaultShogiUI()
        {
            txtTitle.add(Language.Type.vi, "Mặc Định Shogi");
        }

        #endregion

        #region Refresh

        protected bool needReset = true;
        private bool miniGameDataDirty = true;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<DefaultShogi> editDefaultShogi = this.data.editDefaultShogi.v;
                    if (editDefaultShogi != null)
                    {
                        editDefaultShogi.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editDefaultShogi);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editDefaultShogi);
                                // set origin
                                {

                                }
                                needReset = false;
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
                                                // Find shogi
                                                Shogi shogi = gameData.gameType.newOrOld<Shogi>();
                                                {
                                                    // Make new shogi to update
                                                    Shogi newShogi = null;
                                                    {
                                                        DefaultShogi show = editDefaultShogi.show.v.data;
                                                        if (show != null)
                                                        {
                                                            newShogi = show.makeDefaultGameType() as Shogi;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("show null");
                                                        }
                                                    }
                                                    // Copy
                                                    DataUtils.copyData(shogi, newShogi);
                                                }
                                                gameData.gameType.v = shogi;
                                            }
                                        }
                                    }
                                }
                                this.data.miniGameDataUIData.v = miniGameDataUIData;
                            }
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // header
                            UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                            // miniGameDataUI
                            {
                                UIRectTransform.SetPosY(this.data.miniGameDataUIData.v, deltaY + UIConstants.DefaultMiniGameDataUIPadding);
                                deltaY += UIConstants.DefaultMiniGameDataUISize;
                            }
                            // Set
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
                        }
                    }
                    else
                    {
                        Debug.LogError("editDefaultShogi null: " + this);
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
                    uiData.editDefaultShogi.allAddCallBack(this);
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
                // editDefaultShogi
                {
                    if (data is EditData<DefaultShogi>)
                    {
                        EditData<DefaultShogi> editDefaultShogi = data as EditData<DefaultShogi>;
                        // Child
                        {
                            editDefaultShogi.show.allAddCallBack(this);
                            editDefaultShogi.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultShogi)
                        {
                            DefaultShogi defaultShogi = data as DefaultShogi;
                            // Parent
                            {
                                DataUtils.addParentCallBack(defaultShogi, this, ref this.server);
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
                    uiData.editDefaultShogi.allRemoveCallBack(this);
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
                // editDefaultShogi
                {
                    if (data is EditData<DefaultShogi>)
                    {
                        EditData<DefaultShogi> editDefaultShogi = data as EditData<DefaultShogi>;
                        // Child
                        {
                            editDefaultShogi.show.allRemoveCallBack(this);
                            editDefaultShogi.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is DefaultShogi)
                        {
                            DefaultShogi defaultShogi = data as DefaultShogi;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(defaultShogi, this, ref this.server);
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
                    case UIData.Property.editDefaultShogi:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
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
            // EditDefaultShogi
            {
                if (wrapProperty.p is EditData<DefaultShogi>)
                {
                    switch ((EditData<DefaultShogi>.Property)wrapProperty.n)
                    {
                        case EditData<DefaultShogi>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<DefaultShogi>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<DefaultShogi>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<DefaultShogi>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<DefaultShogi>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<DefaultShogi>.Property.editType:
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
                    if (wrapProperty.p is DefaultShogi)
                    {
                        switch ((DefaultShogi.Property)wrapProperty.n)
                        {
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
            // Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
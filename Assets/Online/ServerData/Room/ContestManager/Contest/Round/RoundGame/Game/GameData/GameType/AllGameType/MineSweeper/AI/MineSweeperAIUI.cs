using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
    public class MineSweeperAIUI : UIHaveTransformDataBehavior<MineSweeperAIUI.UIData>
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<MineSweeperAI>> editAI;

            public VP<UIRectTransform.ShowType> showType;

            #region firstMoveType

            public VP<RequestChangeEnumUI.UIData> firstMoveType;

            public void makeRequestChangeFirstMoveType(RequestChangeUpdate<int>.UpdateData update, int newFirstMoveType)
            {
                // Find mineSweeperAI
                MineSweeperAI mineSweeperAI = null;
                {
                    EditData<MineSweeperAI> editMineSweeperAI = this.editAI.v;
                    if (editMineSweeperAI != null)
                    {
                        mineSweeperAI = editMineSweeperAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editMineSweeperAI null: " + this);
                    }
                }
                // Process
                if (mineSweeperAI != null)
                {
                    mineSweeperAI.requestChangeFirstMoveType(Server.getProfileUserId(mineSweeperAI), newFirstMoveType);
                }
                else
                {
                    Debug.LogError("mineSweeperAI null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editAI,
                showType,
                firstMoveType
            }

            public UIData() : base()
            {
                this.editAI = new VP<EditData<MineSweeperAI>>(this, (byte)Property.editAI, new EditData<MineSweeperAI>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // firstMoveType
                {
                    this.firstMoveType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.firstMoveType, new RequestChangeEnumUI.UIData());
                    // event
                    this.firstMoveType.v.updateData.v.request.v = makeRequestChangeFirstMoveType;
                    // Options
                    foreach (MineSweeperAI.FirstMoveType firstMoveType in System.Enum.GetValues(typeof(MineSweeperAI.FirstMoveType)))
                    {
                        this.firstMoveType.v.options.add(firstMoveType.ToString());
                    }
                }
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.MineSweeper;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        public static readonly TxtLanguage txtTitle = new TxtLanguage();

        public Text lbFirstMoveType;
        public static readonly TxtLanguage txtFirstMoveType = new TxtLanguage();

        static MineSweeperAIUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Dò Mìn AI");
                txtFirstMoveType.add(Language.Type.vi, "Loại nước đi đầu tiên");
            }
            // rect
            {
                firstMoveTypeRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
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
                    EditData<MineSweeperAI> editMineSweeperAI = this.data.editAI.v;
                    if (editMineSweeperAI != null)
                    {
                        editMineSweeperAI.update();
                        // get show
                        MineSweeperAI show = editMineSweeperAI.show.v.data;
                        MineSweeperAI compare = editMineSweeperAI.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editMineSweeperAI.compareOtherType.v.data != null)
                                    {
                                        if (editMineSweeperAI.compareOtherType.v.data.GetType() != show.GetType())
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
                                // firstMoveType
                                {
                                    RequestChangeEnumUI.UIData firstMoveType = this.data.firstMoveType.v;
                                    if (firstMoveType != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<int>.UpdateData updateData = firstMoveType.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = (int)show.firstMoveType.v;
                                            updateData.canRequestChange.v = editMineSweeperAI.canEdit.v;
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
                                                firstMoveType.showDifferent.v = true;
                                                firstMoveType.compare.v = (int)compare.firstMoveType.v;
                                            }
                                            else
                                            {
                                                firstMoveType.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("firstMoveType null: " + this);
                                    }
                                }
                            }
                            // reset?
                            if (needReset)
                            {
                                needReset = false;
                                // firstMoveType
                                {
                                    RequestChangeEnumUI.UIData firstMoveType = this.data.firstMoveType.v;
                                    if (firstMoveType != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<int>.UpdateData updateData = firstMoveType.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = (int)show.firstMoveType.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("firstMoveType null: " + this);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("show null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("editMineSweeperAI null: " + this);
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
                                case UIRectTransform.ShowType.OnlyHead:
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + this.data.showType.v);
                                    break;
                            }
                        }
                        // firstMoveType
                        {
                            if (this.data.firstMoveType.v != null)
                            {
                                if (lbFirstMoveType != null)
                                {
                                    lbFirstMoveType.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbFirstMoveType.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbFirstMoveType null");
                                }
                                UIRectTransform.SetPosY(this.data.firstMoveType.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbFirstMoveType != null)
                                {
                                    lbFirstMoveType.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbFirstMoveType null");
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
                            lbTitle.text = txtTitle.get("Mine Sweeper AI");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (lbFirstMoveType != null)
                        {
                            lbFirstMoveType.text = txtFirstMoveType.get("First move type");
                        }
                        else
                        {
                            Debug.LogError("lbFirstMoveType null: " + this);
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

        public RequestChangeEnumUI requestEnumPrefab;

        public static readonly UIRectTransform firstMoveTypeRect = new UIRectTransform(UIConstants.RequestEnumRect);

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
                    uiData.firstMoveType.allAddCallBack(this);
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
                    if (data is EditData<MineSweeperAI>)
                    {
                        EditData<MineSweeperAI> editAI = data as EditData<MineSweeperAI>;
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
                        if (data is MineSweeperAI)
                        {
                            MineSweeperAI mineSweeperAI = data as MineSweeperAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack(mineSweeperAI, this, ref this.server);
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
                // firstMoveType
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
                                case UIData.Property.firstMoveType:
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, firstMoveTypeRect);
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
                    uiData.firstMoveType.allRemoveCallBack(this);
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
                    if (data is EditData<MineSweeperAI>)
                    {
                        EditData<MineSweeperAI> editAI = data as EditData<MineSweeperAI>;
                        // Child
                        {
                            editAI.show.allRemoveCallBack(this);
                            editAI.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is MineSweeperAI)
                        {
                            MineSweeperAI mineSweeperAI = data as MineSweeperAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(mineSweeperAI, this, ref this.server);
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
                // firstMoveType
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
                    case UIData.Property.firstMoveType:
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
                // editAI
                {
                    if (wrapProperty.p is EditData<MineSweeperAI>)
                    {
                        switch ((EditData<MineSweeperAI>.Property)wrapProperty.n)
                        {
                            case EditData<MineSweeperAI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<MineSweeperAI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<MineSweeperAI>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<MineSweeperAI>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<MineSweeperAI>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<MineSweeperAI>.Property.editType:
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
                        if (wrapProperty.p is MineSweeperAI)
                        {
                            switch ((MineSweeperAI.Property)wrapProperty.n)
                            {
                                case MineSweeperAI.Property.firstMoveType:
                                    dirty = true;
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Parent
                        {
                            if (wrapProperty.p is Server)
                            {
                                Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                                return;
                            }
                        }
                    }
                }
                // firstMoveType
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
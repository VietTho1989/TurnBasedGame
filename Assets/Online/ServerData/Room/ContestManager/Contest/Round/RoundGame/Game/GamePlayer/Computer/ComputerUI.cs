using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ComputerUI : UIBehavior<ComputerUI.UIData>
{

    #region UIData

    public class UIData : InformUI
    {

        public VP<EditData<Computer>> editComputer;

        public VP<UIRectTransform.ShowType> showType;

        public VP<ComputerAvatarUI.UIData> avatar;

        #region name

        public VP<RequestChangeStringUI.UIData> name;

        public void makeRequestChangeName(RequestChangeUpdate<string>.UpdateData update, string newName)
        {
            // Find
            Computer computer = null;
            {
                EditData<Computer> editComputer = this.editComputer.v;
                if (editComputer != null)
                {
                    computer = editComputer.show.v.data;
                }
                else
                {
                    Debug.LogError("editComputer null: " + this);
                }
            }
            // Process
            if (computer != null)
            {
                computer.requestChangeName(Server.getProfileUserId(computer), newName);
            }
            else
            {
                Debug.LogError("computer null: " + this);
            }
        }

        #endregion

        #region avatarUrl

        public VP<RequestChangeStringUI.UIData> avatarUrl;

        public void makeRequestChangeAvatarUrl(RequestChangeUpdate<string>.UpdateData update, string newAvatarUrl)
        {
            // Find
            Computer computer = null;
            {
                EditData<Computer> editComputer = this.editComputer.v;
                if (editComputer != null)
                {
                    computer = editComputer.show.v.data;
                }
                else
                {
                    Debug.LogError("editComputer null: " + this);
                }
            }
            // Process
            if (computer != null)
            {
                computer.requestChangeAvatarUrl(Server.getProfileUserId(computer), newAvatarUrl);
            }
            else
            {
                Debug.LogError("computer null: " + this);
            }
        }

        #endregion

        public VP<AIUI.UIData> aiUIData;

        public VP<UIRectTransform.ShowType> aiUIDataShowType;

        #region Constructor

        public enum Property
        {
            editComputer,
            showType,
            avatar,
            name,
            avatarUrl,
            aiUIData,
            aiUIDataShowType
        }

        public UIData() : base()
        {
            this.editComputer = new VP<EditData<Computer>>(this, (byte)Property.editComputer, new EditData<Computer>());
            this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
            this.avatar = new VP<ComputerAvatarUI.UIData>(this, (byte)Property.avatar, new ComputerAvatarUI.UIData());
            // name
            {
                this.name = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.name, new RequestChangeStringUI.UIData());
                // event
                this.name.v.updateData.v.request.v = makeRequestChangeName;
            }
            // avatarUrl
            {
                this.avatarUrl = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.avatarUrl, new RequestChangeStringUI.UIData());
                // event
                this.avatarUrl.v.updateData.v.request.v = makeRequestChangeAvatarUrl;
            }
            this.aiUIData = new VP<AIUI.UIData>(this, (byte)Property.aiUIData, new AIUI.UIData());
            this.aiUIDataShowType = new VP<UIRectTransform.ShowType>(this, (byte)Property.aiUIDataShowType, UIRectTransform.ShowType.Normal);
        }

        #endregion

        public override GamePlayer.Inform.Type getType()
        {
            return GamePlayer.Inform.Type.Computer;
        }

    }

    #endregion

    #region Refresh

    #region txt

    public Text lbTitle;
    public static readonly TxtLanguage txtTitle = new TxtLanguage();

    public Text lbName;
    public static readonly TxtLanguage txtName = new TxtLanguage();

    public Text lbAvatarUrl;
    public static readonly TxtLanguage txtAvatarUrl = new TxtLanguage();

    static ComputerUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Máy Tính");
            txtName.add(Language.Type.vi, "Tên");
            txtAvatarUrl.add(Language.Type.vi, "Đường dẫn avatar");
        }
        // rect
        {
            // computerAvatarRect
            {
                // anchoredPosition: (-10.0, -100.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 1.0);
                // offsetMin: (-46.0, -136.0); offsetMax: (-10.0, -100.0); sizeDelta: (36.0, 36.0);
                computerAvatarRect.anchoredPosition = new Vector3(-10.0f, -100.0f, 0);
                computerAvatarRect.anchorMin = new Vector2(1.0f, 1.0f);
                computerAvatarRect.anchorMax = new Vector2(1.0f, 1.0f);
                computerAvatarRect.pivot = new Vector2(1.0f, 1.0f);
                computerAvatarRect.offsetMin = new Vector2(-46.0f, -136.0f);
                computerAvatarRect.offsetMax = new Vector2(-10.0f, -100.0f);
                computerAvatarRect.sizeDelta = new Vector2(36.0f, 36.0f);
            }
            // avatarUrlRect
            {
                float paddingLeft = 90;
                float paddingRight = 56;
                avatarUrlRect.anchoredPosition = new Vector3((paddingLeft - paddingRight) / 2, 0f, 0f);
                avatarUrlRect.anchorMin = new Vector2(0.0f, 1.0f);
                avatarUrlRect.anchorMax = new Vector2(1.0f, 1.0f);
                avatarUrlRect.pivot = new Vector2(0.5f, 1f);
                avatarUrlRect.offsetMin = new Vector2(paddingLeft, -UIConstants.RequestEnumHeight);
                avatarUrlRect.offsetMax = new Vector2(-paddingRight, 0);
                avatarUrlRect.sizeDelta = new Vector2(-paddingLeft - paddingRight, UIConstants.RequestEnumHeight);
                // posY
                avatarUrlRect.setPosY(UIConstants.HeaderHeight + 1 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
            }
        }
    }

    #endregion

    private bool needReset = true;

    public Image header;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                EditData<Computer> editComputer = this.data.editComputer.v;
                if (editComputer != null)
                {
                    // update
                    editComputer.update();
                    // get show
                    Computer show = editComputer.show.v.data;
                    Computer compare = editComputer.compare.v.data;
                    if (show != null)
                    {
                        // different
                        if (lbTitle != null)
                        {
                            bool isDifferent = false;
                            {
                                if (editComputer.compareOtherType.v.data != null)
                                {
                                    if (editComputer.compareOtherType.v.data.GetType() != show.GetType())
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
                                // Debug.LogError ("server null: " + this);
                            }
                        }
                        // set origin
                        {
                            // name
                            {
                                RequestChangeStringUI.UIData name = this.data.name.v;
                                if (name != null)
                                {
                                    // updateData
                                    RequestChangeUpdate<string>.UpdateData updateData = name.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.origin.v = show.computerName.v;
                                        updateData.canRequestChange.v = editComputer.canEdit.v;
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
                                            name.showDifferent.v = true;
                                            name.compare.v = compare.computerName.v;
                                        }
                                        else
                                        {
                                            name.showDifferent.v = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("name null: " + this);
                                }
                            }
                            // avatarUrl
                            {
                                RequestChangeStringUI.UIData avatarUrl = this.data.avatarUrl.v;
                                if (avatarUrl != null)
                                {
                                    // updateData
                                    RequestChangeUpdate<string>.UpdateData updateData = avatarUrl.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.origin.v = show.avatarUrl.v;
                                        updateData.canRequestChange.v = editComputer.canEdit.v;
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
                                            avatarUrl.showDifferent.v = true;
                                            avatarUrl.compare.v = compare.avatarUrl.v;
                                        }
                                        else
                                        {
                                            avatarUrl.showDifferent.v = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("avatarUrl null: " + this);
                                }
                            }
                            // AIUIData
                            {
                                AIUI.UIData ai = this.data.aiUIData.v;
                                if (ai != null)
                                {
                                    EditData<Computer.AI> editComputerAI = ai.editAI.v;
                                    if (editComputerAI != null)
                                    {
                                        // origin
                                        {
                                            Computer.AI origin = null;
                                            {
                                                Computer originComputer = editComputer.origin.v.data;
                                                if (originComputer != null)
                                                {
                                                    origin = originComputer.ai.v;
                                                }
                                                else
                                                {
                                                    Debug.LogError("originComputer null: " + this);
                                                }
                                            }
                                            editComputerAI.origin.v = new ReferenceData<Computer.AI>(origin);
                                        }
                                        // show
                                        {
                                            Computer.AI showComputerAI = null;
                                            {
                                                Computer showComputer = editComputer.show.v.data;
                                                if (showComputer != null)
                                                {
                                                    showComputerAI = showComputer.ai.v;
                                                }
                                                else
                                                {
                                                    Debug.LogError("showComputer null: " + this);
                                                }
                                            }
                                            editComputerAI.show.v = new ReferenceData<Computer.AI>(showComputerAI);
                                        }
                                        // compare
                                        {
                                            Computer.AI compareComputerAI = null;
                                            {
                                                Computer compareComputer = editComputer.compare.v.data;
                                                if (compareComputer != null)
                                                {
                                                    compareComputerAI = compareComputer.ai.v;
                                                }
                                                else
                                                {
                                                    // Debug.LogError("compareComputer null: " + this);
                                                }
                                            }
                                            editComputerAI.compare.v = new ReferenceData<Computer.AI>(compareComputerAI);
                                        }
                                        // compare other type
                                        {
                                            Computer.AI compareOtherTypeComputerAI = null;
                                            {
                                                Computer compareOtherTypeComputer = (Computer)editComputer.compareOtherType.v.data;
                                                if (compareOtherTypeComputer != null)
                                                {
                                                    compareOtherTypeComputerAI = compareOtherTypeComputer.ai.v;
                                                }
                                            }
                                            editComputerAI.compareOtherType.v = new ReferenceData<Data>(compareOtherTypeComputerAI);
                                        }
                                        // canEdit
                                        editComputerAI.canEdit.v = editComputer.canEdit.v;
                                        // editType
                                        editComputerAI.editType.v = editComputer.editType.v;
                                    }
                                    else
                                    {
                                        Debug.LogError("editComputerAI null: " + this);
                                    }
                                    // aiUIDataShowType
                                    ai.subShowType.v = this.data.aiUIDataShowType.v;
                                }
                                else
                                {
                                    Debug.LogError("aiUIData null: " + this);
                                }
                            }
                            // avatar
                            {
                                ComputerAvatarUI.UIData avatar = this.data.avatar.v;
                                if (avatar != null)
                                {
                                    avatar.computer.v = new ReferenceData<Computer>(show);
                                }
                                else
                                {
                                    Debug.LogError("avatar null: " + this);
                                }
                            }
                        }
                        // reset?
                        if (needReset)
                        {
                            needReset = false;
                            // name
                            {
                                RequestChangeStringUI.UIData name = this.data.name.v;
                                if (name != null)
                                {
                                    // updateData
                                    RequestChangeUpdate<string>.UpdateData updateData = name.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.current.v = show.computerName.v;
                                        updateData.changeState.v = Data.ChangeState.None;
                                    }
                                    else
                                    {
                                        Debug.LogError("updateData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("name null: " + this);
                                }
                            }
                            // avatarUrl
                            {
                                RequestChangeStringUI.UIData avatarUrl = this.data.avatarUrl.v;
                                if (avatarUrl != null)
                                {
                                    // updateData
                                    RequestChangeUpdate<string>.UpdateData updateData = avatarUrl.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.current.v = show.avatarUrl.v;
                                        updateData.changeState.v = Data.ChangeState.None;
                                    }
                                    else
                                    {
                                        Debug.LogError("updateData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("avatarUrl null: " + this);
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("computer null: " + this);
                    }
                    // UI Size
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
                                default:
                                    Debug.LogError("unknown showType: " + this.data.showType.v);
                                    break;
                            }
                        }
                        // name
                        {
                            if (this.data.name.v != null)
                            {
                                if (lbName != null)
                                {
                                    lbName.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbName.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbName null");
                                }
                                UIRectTransform.SetPosY(this.data.name.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbName != null)
                                {
                                    lbName.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbName null");
                                }
                            }
                        }
                        // avatar, avatarUrl
                        {
                            if (this.data.avatarUrl.v != null)
                            {
                                if (lbAvatarUrl != null)
                                {
                                    lbAvatarUrl.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbAvatarUrl.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbAvatarUrl null");
                                }
                                UIRectTransform.SetPosY(this.data.avatarUrl.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                                UIRectTransform.SetPosY(this.data.avatar.v, deltaY + 12);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbAvatarUrl != null)
                                {
                                    lbAvatarUrl.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbAvatarUrl null");
                                }
                            }
                        }
                        // aiUIData
                        deltaY += UIRectTransform.SetPosY(this.data.aiUIData.v, deltaY);
                        // set
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("Computer");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (lbName != null)
                        {
                            lbName.text = txtName.get("Name");
                        }
                        else
                        {
                            Debug.LogError("lbName null: " + this);
                        }
                        if (lbAvatarUrl != null)
                        {
                            lbAvatarUrl.text = txtAvatarUrl.get("Avatar url");
                        }
                        else
                        {
                            Debug.LogError("lbAvatarUrl null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("editComputer null: " + this);
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

    public ComputerAvatarUI computerAvatarPrefab;
    private static readonly UIRectTransform computerAvatarRect = new UIRectTransform();

    public RequestChangeStringUI requestStringPrefab;

    private static readonly UIRectTransform nameRect = new UIRectTransform(UIConstants.RequestEnumRect, UIConstants.HeaderHeight + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
    private static readonly UIRectTransform avatarUrlRect = new UIRectTransform(UIConstants.RequestEnumRect, UIConstants.HeaderHeight + UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);

    public AIUI aiUIPrefab;

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
                uiData.editComputer.allAddCallBack(this);
                uiData.avatar.allAddCallBack(this);
                uiData.name.allAddCallBack(this);
                uiData.avatarUrl.allAddCallBack(this);
                uiData.aiUIData.allAddCallBack(this);
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
            // editComputer
            {
                if (data is EditData<Computer>)
                {
                    EditData<Computer> editComputer = data as EditData<Computer>;
                    // Child
                    {
                        editComputer.origin.allAddCallBack(this);
                        editComputer.show.allAddCallBack(this);
                        editComputer.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is Computer)
                    {
                        Computer computer = data as Computer;
                        // Parent
                        {
                            DataUtils.addParentCallBack(computer, this, ref this.server);
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
            if (data is ComputerAvatarUI.UIData)
            {
                ComputerAvatarUI.UIData computerAvatarUIData = data as ComputerAvatarUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(computerAvatarUIData, computerAvatarPrefab, this.transform, computerAvatarRect);
                }
                dirty = true;
                return;
            }
            // name, avatarUrl
            if (data is RequestChangeStringUI.UIData)
            {
                RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.name:
                                {
                                    UIUtils.Instantiate(requestChange, requestStringPrefab, this.transform, nameRect);
                                }
                                break;
                            case UIData.Property.avatarUrl:
                                {
                                    UIUtils.Instantiate(requestChange, requestStringPrefab, this.transform, avatarUrlRect);
                                }
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
            // aiUIData
            {
                if (data is AIUI.UIData)
                {
                    AIUI.UIData aiUIData = data as AIUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(aiUIData, aiUIPrefab, this.transform);
                    }
                    // Child
                    {
                        TransformData.AddCallBack(aiUIData, this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is TransformData)
                {
                    dirty = true;
                    return;
                }
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
                uiData.editComputer.allRemoveCallBack(this);
                uiData.avatar.allRemoveCallBack(this);
                uiData.name.allRemoveCallBack(this);
                uiData.avatarUrl.allRemoveCallBack(this);
                uiData.aiUIData.allRemoveCallBack(this);
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
            // editComputer
            {
                if (data is EditData<Computer>)
                {
                    EditData<Computer> editComputer = data as EditData<Computer>;
                    // Child
                    {
                        editComputer.origin.allRemoveCallBack(this);
                        editComputer.show.allRemoveCallBack(this);
                        editComputer.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is Computer)
                    {
                        Computer computer = data as Computer;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(computer, this, ref this.server);
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
            if (data is ComputerAvatarUI.UIData)
            {
                ComputerAvatarUI.UIData computerAvatarUIData = data as ComputerAvatarUI.UIData;
                // UI
                {
                    computerAvatarUIData.removeCallBackAndDestroy(typeof(ComputerAvatarUI));
                }
                return;
            }
            // name, avatarUrl
            if (data is RequestChangeStringUI.UIData)
            {
                RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeStringUI));
                }
                return;
            }
            // aiUIData
            {
                if (data is AIUI.UIData)
                {
                    AIUI.UIData aiUIData = data as AIUI.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(aiUIData, this);
                    }
                    // UI
                    {
                        aiUIData.removeCallBackAndDestroy(typeof(AIUI));
                    }
                    return;
                }
                // Child
                if (data is TransformData)
                {
                    return;
                }
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
                case UIData.Property.editComputer:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.showType:
                    dirty = true;
                    break;
                case UIData.Property.avatar:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.name:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.avatarUrl:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.aiUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.aiUIDataShowType:
                    dirty = true;
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
            // editComputer
            {
                if (wrapProperty.p is EditData<Computer>)
                {
                    switch ((EditData<Computer>.Property)wrapProperty.n)
                    {
                        case EditData<Computer>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<Computer>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<Computer>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<Computer>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<Computer>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<Computer>.Property.editType:
                            dirty = true;
                            break;
                        default:
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is Computer)
                    {
                        switch ((Computer.Property)wrapProperty.n)
                        {
                            case Computer.Property.computerName:
                                dirty = true;
                                break;
                            case Computer.Property.avatarUrl:
                                dirty = true;
                                break;
                            case Computer.Property.ai:
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
            // avatar
            if (wrapProperty.p is ComputerAvatarUI.UIData)
            {
                return;
            }
            // name, avatarUrl
            if (wrapProperty.p is RequestChangeStringUI.UIData)
            {
                return;
            }
            // aiUIData
            {
                if (wrapProperty.p is AIUI.UIData)
                {
                    return;
                }
                // Child
                if (wrapProperty.p is TransformData)
                {
                    switch ((TransformData.Property)wrapProperty.n)
                    {
                        case TransformData.Property.anchoredPosition:
                            break;
                        case TransformData.Property.anchorMin:
                            break;
                        case TransformData.Property.anchorMax:
                            break;
                        case TransformData.Property.pivot:
                            break;
                        case TransformData.Property.offsetMin:
                            break;
                        case TransformData.Property.offsetMax:
                            break;
                        case TransformData.Property.sizeDelta:
                            break;
                        case TransformData.Property.rotation:
                            break;
                        case TransformData.Property.scale:
                            break;
                        case TransformData.Property.size:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
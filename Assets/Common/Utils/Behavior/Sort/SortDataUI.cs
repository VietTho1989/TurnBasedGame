using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SortDataUI : UIBehavior<SortDataUI.UIData>
{

    #region UIData

    public class UIData : Data
    {
        public VP<EditData<SortData>> editSortData;

        #region filter

        public VP<RequestChangeStringUI.UIData> filter;

        public void makeRequestChangeFilter(RequestChangeUpdate<string>.UpdateData update, string newFilter)
        {
            // Find
            SortData sortData = null;
            {
                EditData<SortData> editSortData = this.editSortData.v;
                if (editSortData != null)
                {
                    sortData = editSortData.show.v.data;
                }
                else
                {
                    Debug.LogError("editSortData null: " + this);
                }
            }
            // Process
            if (sortData != null)
            {
                sortData.filter.v = newFilter;
            }
            else
            {
                Debug.LogError("sortData null: " + this);
            }
        }

        #endregion

        #region sortType

        public VP<RequestChangeEnumUI.UIData> sortType;

        public void makeRequestChangeSortType(RequestChangeUpdate<int>.UpdateData update, int newSortType)
        {
            // Find
            SortData sortData = null;
            {
                EditData<SortData> editSortData = this.editSortData.v;
                if (editSortData != null)
                {
                    sortData = editSortData.show.v.data;
                }
                else
                {
                    Debug.LogError("editSortData null: " + this);
                }
            }
            // Process
            if (sortData != null)
            {
                sortData.sortType.v = (SortData.SortType)newSortType;
            }
            else
            {
                Debug.LogError("sortData null: " + this);
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            editSortData,
            filter,
            sortType
        }

        public UIData() : base()
        {
            this.editSortData = new VP<EditData<SortData>>(this, (byte)Property.editSortData, new EditData<SortData>());
            // filter
            {
                this.filter = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.filter, new RequestChangeStringUI.UIData());
                // event
                this.filter.v.updateData.v.request.v = makeRequestChangeFilter;
            }
            // sortType
            {
                this.sortType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.sortType, new RequestChangeEnumUI.UIData());
                // event
                this.sortType.v.updateData.v.request.v = makeRequestChangeSortType;
                // Options
                // TODO Sau nay options phai co language nua
                foreach (SortData.SortType sortType in System.Enum.GetValues(typeof(SortData.SortType)))
                {
                    this.sortType.v.options.add(sortType.ToString());
                }
            }
        }

        #endregion

    }

    #endregion

    #region txt, rect

    static SortDataUI()
    {
        // rect
        {
            // filterRect
            {
                // anchoredPosition: (0.0, 0.0); anchorMin: (0.0, 0.5); anchorMax: (0.5, 0.5); pivot: (0.5, 0.5); 
                // offsetMin: (0.0, -15.0); offsetMax: (0.0, 15.0); sizeDelta: (0.0, 30.0);
                filterRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                filterRect.anchorMin = new Vector2(0.0f, 0.5f);
                filterRect.anchorMax = new Vector2(0.5f, 0.5f);
                filterRect.pivot = new Vector2(0.5f, 0.5f);
                filterRect.offsetMin = new Vector2(0.0f, -15.0f);
                filterRect.offsetMax = new Vector2(0.0f, 15.0f);
                filterRect.sizeDelta = new Vector2(0.0f, 30.0f);
            }
            // sortTypeRect
            {
                // anchoredPosition: (0.0, 0.0); anchorMin: (0.5, 0.5); anchorMax: (1.0, 0.5); pivot: (0.5, 0.5); 
                // offsetMin: (0.0, -15.0); offsetMax: (0.0, 15.0); sizeDelta: (0.0, 30.0);
                sortTypeRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                sortTypeRect.anchorMin = new Vector2(0.5f, 0.5f);
                sortTypeRect.anchorMax = new Vector2(1.0f, 0.5f);
                sortTypeRect.pivot = new Vector2(0.5f, 0.5f);
                sortTypeRect.offsetMin = new Vector2(0.0f, -15.0f);
                sortTypeRect.offsetMax = new Vector2(0.0f, 15.0f);
                sortTypeRect.sizeDelta = new Vector2(0.0f, 30.0f);
            }
        }
    }

    #endregion

    #region Refresh

    private bool needReset = true;
    public GameObject differentIndicator;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                EditData<SortData> editSortData = this.data.editSortData.v;
                if (editSortData != null)
                {
                    editSortData.update();
                    // get show
                    SortData show = editSortData.show.v.data;
                    SortData compare = editSortData.compare.v.data;
                    if (show != null)
                    {
                        // differentIndicator
                        if (differentIndicator != null)
                        {
                            bool isDifferent = false;
                            {
                                if (editSortData.compareOtherType.v.data != null)
                                {
                                    if (editSortData.compareOtherType.v.data.GetType() != show.GetType())
                                    {
                                        isDifferent = true;
                                    }
                                }
                            }
                            differentIndicator.SetActive(isDifferent);
                        }
                        else
                        {
                            // Debug.LogError ("differentIndicator null: " + this);
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
                            // filter
                            {
                                RequestChangeStringUI.UIData filter = this.data.filter.v;
                                if (filter != null)
                                {
                                    // update
                                    RequestChangeUpdate<string>.UpdateData updateData = filter.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.origin.v = show.filter.v;
                                        updateData.canRequestChange.v = editSortData.canEdit.v;
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
                                            filter.showDifferent.v = true;
                                            filter.compare.v = compare.filter.v;
                                        }
                                        else
                                        {
                                            filter.showDifferent.v = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("filter null: " + this);
                                }
                            }
                            // sortType
                            {
                                RequestChangeEnumUI.UIData sortType = this.data.sortType.v;
                                if (sortType != null)
                                {
                                    // options
                                    {
                                        sortType.options.copyList(SortData.getSortTypeList());
                                    }
                                    // update
                                    RequestChangeUpdate<int>.UpdateData updateData = sortType.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.origin.v = (int)show.sortType.v;
                                        updateData.canRequestChange.v = editSortData.canEdit.v;
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
                                            sortType.showDifferent.v = true;
                                            sortType.compare.v = (int)compare.sortType.v;
                                        }
                                        else
                                        {
                                            sortType.showDifferent.v = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("sortType null: " + this);
                                }
                            }
                        }
                        // reset?
                        if (needReset)
                        {
                            needReset = false;
                            // filter
                            {
                                RequestChangeStringUI.UIData filter = this.data.filter.v;
                                if (filter != null)
                                {
                                    // update
                                    RequestChangeUpdate<string>.UpdateData updateData = filter.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.current.v = show.filter.v;
                                        updateData.changeState.v = Data.ChangeState.None;
                                    }
                                    else
                                    {
                                        Debug.LogError("updateData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("filter null: " + this);
                                }
                            }
                            // sortType
                            {
                                RequestChangeEnumUI.UIData sortType = this.data.sortType.v;
                                if (sortType != null)
                                {
                                    // update
                                    RequestChangeUpdate<int>.UpdateData updateData = sortType.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.current.v = (int)show.sortType.v;
                                        updateData.changeState.v = Data.ChangeState.None;
                                    }
                                    else
                                    {
                                        Debug.LogError("updateData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("sortType null: " + this);
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
                    Debug.LogError("editSortData null: " + this);
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

    public RequestChangeStringUI requestStringPrefab;
    public RequestChangeEnumUI requestEnumPrefab;

    private static readonly UIRectTransform filterRect = new UIRectTransform();
    private static readonly UIRectTransform sortTypeRect = new UIRectTransform();

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
                uiData.editSortData.allAddCallBack(this);
                uiData.filter.allAddCallBack(this);
                uiData.sortType.allAddCallBack(this);
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
            // editSortData
            {
                if (data is EditData<SortData>)
                {
                    EditData<SortData> editSortData = data as EditData<SortData>;
                    // Child
                    {
                        editSortData.show.allAddCallBack(this);
                        editSortData.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is SortData)
                    {
                        SortData sortData = data as SortData;
                        // Parent
                        {
                            DataUtils.addParentCallBack(sortData, this, ref this.server);
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
                            case UIData.Property.filter:
                                UIUtils.Instantiate(requestChange, requestStringPrefab, this.transform, filterRect);
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
                            case UIData.Property.sortType:
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, sortTypeRect);
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
                uiData.editSortData.allRemoveCallBack(this);
                uiData.filter.allRemoveCallBack(this);
                uiData.sortType.allRemoveCallBack(this);
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
            // editSortData
            {
                if (data is EditData<SortData>)
                {
                    EditData<SortData> editSortData = data as EditData<SortData>;
                    // Child
                    {
                        editSortData.show.allRemoveCallBack(this);
                        editSortData.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is SortData)
                    {
                        SortData sortData = data as SortData;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(sortData, this, ref this.server);
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
            if (data is RequestChangeStringUI.UIData)
            {
                RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeStringUI));
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
                case UIData.Property.editSortData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.filter:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.sortType:
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
        {
            // editSortData
            {
                if (wrapProperty.p is EditData<SortData>)
                {
                    switch ((EditData<SortData>.Property)wrapProperty.n)
                    {
                        case EditData<SortData>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<SortData>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<SortData>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<SortData>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<SortData>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<SortData>.Property.editType:
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
                    if (wrapProperty.p is SortData)
                    {
                        switch ((SortData.Property)wrapProperty.n)
                        {
                            case SortData.Property.filter:
                                dirty = true;
                                break;
                            case SortData.Property.sortType:
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
            if (wrapProperty.p is RequestChangeStringUI.UIData)
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
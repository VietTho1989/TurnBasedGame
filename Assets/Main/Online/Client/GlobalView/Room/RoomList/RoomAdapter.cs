using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

public class RoomAdapter : SRIA<RoomAdapter.UIData, RoomHolder.UIData>
{

    #region UIData

    [Serializable]
    public class UIData : BaseParams
    {

        public VP<SortDataUI.UIData> sortData;

        public LP<RoomHolder.UIData> holders;

        #region Constructor

        public enum Property
        {
            sortData,
            holders
        }

        public UIData() : base()
        {
            // sortData
            {
                this.sortData = new VP<SortDataUI.UIData>(this, (byte)Property.sortData, new SortDataUI.UIData());
                {
                    EditData<SortData> editSortData = this.sortData.v.editSortData.v;
                    if (editSortData != null)
                    {
                        editSortData.origin.v = new ReferenceData<SortData>(new SortData());
                        editSortData.canEdit.v = true;
                        editSortData.editType.v = EditType.Immediate;
                    }
                    else
                    {
                        Debug.LogError("editSortData null: " + this);
                    }
                }
            }
            this.holders = new LP<RoomHolder.UIData>(this, (byte)Property.holders);
        }

        #endregion

        [NonSerialized]
        public List<Room> rooms = new List<Room>();

        public void reset()
        {
            this.rooms.Clear();
        }

    }

    #endregion

    #region Adapter

    public RoomHolder holderPrefab;

    protected override RoomHolder.UIData CreateViewsHolder(int itemIndex)
    {
        RoomHolder.UIData uiData = new RoomHolder.UIData();
        {
            // add
            {
                uiData.uid = this.data.holders.makeId();
                this.data.holders.add(uiData);
            }
            // MakeUI
            if (holderPrefab != null)
            {
                uiData.Init(holderPrefab.gameObject, itemIndex);
            }
            else
            {
                Debug.LogError("holderPrefab null: " + this);
            }
        }
        return uiData;
    }

    protected override void UpdateViewsHolder(RoomHolder.UIData newOrRecycled)
    {
        newOrRecycled.updateView(_Params);
    }

    #endregion

    #region txt

    public Text tvNoRooms;
    private static readonly TxtLanguage txtNoRooms = new TxtLanguage("Don't have any rooms");

    static RoomAdapter()
    {
        // txt
        txtNoRooms.add(Language.Type.vi, "Không có phòng nào cả");
        // rect
        {
            // sortDataRect
            {
                // anchoredPosition: (0.0, 0.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 1.0);
                // offsetMin: (-160.0, -30.0); offsetMax: (0.0, 0.0); sizeDelta: (160.0, 30.0);
                sortDataRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                sortDataRect.anchorMin = new Vector2(1.0f, 1.0f);
                sortDataRect.anchorMax = new Vector2(1.0f, 1.0f);
                sortDataRect.pivot = new Vector2(1.0f, 1.0f);
                sortDataRect.offsetMin = new Vector2(-160.0f, -30.0f);
                sortDataRect.offsetMax = new Vector2(0.0f, 0.0f);
                sortDataRect.sizeDelta = new Vector2(160.0f, 30.0f);
            }
        }
    }

    #endregion

    #region Refresh

    public GameObject noRooms;

    public override void refresh()
    {
        if (dirty)
        {
            if (this.Initialized)
            {
                dirty = false;
                if (this.data != null)
                {
                    List<Room> rooms = new List<Room>();
                    // filter
                    {
                        // add
                        {
                            RoomContainerUI.UIData roomContainerUIData = this.data.findDataInParent<RoomContainerUI.UIData>();
                            if (roomContainerUIData != null)
                            {
                                foreach (ReferenceData<Room> referenceRoom in roomContainerUIData.rooms.vs)
                                {
                                    rooms.Add(referenceRoom.data);
                                }
                            }
                            else
                            {
                                Debug.LogError("roomContainerUIData null");
                            }
                        }
                        // find sort
                        SortData sortData = null;
                        {
                            SortDataUI.UIData sortDataUIData = this.data.sortData.v;
                            if (sortDataUIData != null)
                            {
                                EditData<SortData> editSortData = sortDataUIData.editSortData.v;
                                if (editSortData != null)
                                {
                                    sortData = editSortData.show.v.data;
                                }
                                else
                                {
                                    Debug.LogError("editSortData null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("sortDataUIData null: " + this);
                            }
                        }
                        // Process
                        if (sortData != null)
                        {
                            // filter string
                            {
                                if (!string.IsNullOrEmpty(sortData.filter.v))
                                {
                                    for (int i = rooms.Count - 1; i >= 0; i--)
                                    {
                                        Room room = rooms[i];
                                        Debug.LogError("filter room: " + room.name.v + "; " + sortData.filter.v);
                                        if (!room.name.v.Contains(sortData.filter.v))
                                        {
                                            rooms.RemoveAt(i);
                                        }
                                    }
                                }
                            }
                            // sort
                            {
                                switch (sortData.sortType.v)
                                {
                                    case SortData.SortType.None:
                                        break;
                                    case SortData.SortType.Name:
                                        {
                                            rooms.Sort(delegate (Room p1, Room p2)
                                            {
                                                if (p1 == null)
                                                {
                                                    return 1;
                                                }
                                                if (p2 == null)
                                                {
                                                    return -1;
                                                }
                                                return p1.name.v.CompareTo(p2.name.v);
                                            });
                                        }
                                        break;
                                    case SortData.SortType.Kind:
                                        {
                                            // TODO Can hoan thien
                                        }
                                        break;
                                    case SortData.SortType.Date:
                                        {
                                            rooms.Sort(delegate (Room p1, Room p2)
                                            {
                                                if (p1 == null)
                                                {
                                                    return 1;
                                                }
                                                if (p2 == null)
                                                {
                                                    return -1;
                                                }
                                                return p1.uid.CompareTo(p2.uid);
                                            });
                                        }
                                        break;
                                    default:
                                        Debug.LogError("Unknown type: " + sortData.sortType.v + "; " + this);
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("sortData null: " + this);
                        }
                    }
                    // Make list
                    {
                        int min = Mathf.Min(rooms.Count, _Params.rooms.Count);
                        // Update
                        {
                            for (int i = 0; i < min; i++)
                            {
                                if (rooms[i] != _Params.rooms[i])
                                {
                                    // change param
                                    _Params.rooms[i] = rooms[i];
                                    // Update holder
                                    foreach (RoomHolder.UIData holder in this.data.holders.vs)
                                    {
                                        if (holder.ItemIndex == i)
                                        {
                                            holder.room.v = new ReferenceData<Room>(rooms[i]);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        // Add or Remove
                        {
                            if (rooms.Count > min)
                            {
                                // Add
                                int insertCount = rooms.Count - min;
                                List<Room> addItems = rooms.GetRange(min, insertCount);
                                _Params.rooms.AddRange(addItems);
                                InsertItems(min, insertCount, false, false);
                            }
                            else
                            {
                                // Remove
                                int deleteCount = _Params.rooms.Count - min;
                                if (deleteCount > 0)
                                {
                                    RemoveItems(min, deleteCount, false, false);
                                    _Params.rooms.RemoveRange(min, deleteCount);
                                }
                            }
                        }
                    }
                    // NoRooms
                    {
                        if (noRooms != null)
                        {
                            bool haveAny = false;
                            {
                                foreach (RoomHolder.UIData holder in this.data.holders.vs)
                                {
                                    if (holder.room.v.data != null)
                                    {
                                        RoomHolder holderUI = holder.findCallBack<RoomHolder>();
                                        if (holderUI != null)
                                        {
                                            if (holderUI.gameObject.activeSelf)
                                            {
                                                haveAny = true;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("holderUI null: " + this);
                                        }
                                    }
                                }
                            }
                            noRooms.SetActive(!haveAny);
                        }
                        else
                        {
                            Debug.LogError("noRooms null: " + this);
                        }
                    }
                    // txt
                    {
                        if (tvNoRooms != null)
                        {
                            tvNoRooms.text = txtNoRooms.get();
                        }
                        else
                        {
                            Debug.LogError("tvNoRooms null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
            else
            {
                Debug.LogError("not initalized: " + this);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public SortDataUI sortDataPrefab;
    private static readonly UIRectTransform sortDataRect = new UIRectTransform();

    private RoomContainerUI.UIData roomContainerUIData = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Parent
            {
                DataUtils.addParentCallBack(uiData, this, ref this.roomContainerUIData);
            }
            // Child
            {
                uiData.sortData.allAddCallBack(this);
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
        // Parent
        if (data is RoomContainerUI.UIData)
        {
            dirty = true;
            return;
        }
        // Child
        {
            if (data is SortDataUI.UIData)
            {
                SortDataUI.UIData sortDataUIData = data as SortDataUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(sortDataUIData, sortDataPrefab, this.transform, sortDataRect);
                }
                // Child
                {
                    sortDataUIData.editSortData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is EditData<SortData>)
                {
                    EditData<SortData> editSortData = data as EditData<SortData>;
                    // Child
                    {
                        editSortData.show.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is SortData)
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
            // Parent
            {
                DataUtils.removeParentCallBack(uiData, this, ref this.roomContainerUIData);
            }
            // Child
            {
                uiData.sortData.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if (data is Setting)
        {
            return;
        }
        // Parent
        if (data is RoomContainerUI.UIData)
        {
            return;
        }
        // Child
        {
            if (data is SortDataUI.UIData)
            {
                SortDataUI.UIData sortDataUIData = data as SortDataUI.UIData;
                // UI
                {
                    sortDataUIData.removeCallBackAndDestroy(typeof(SortDataUI));
                }
                // Child
                {
                    sortDataUIData.editSortData.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            {
                if (data is EditData<SortData>)
                {
                    EditData<SortData> editSortData = data as EditData<SortData>;
                    // Child
                    {
                        editSortData.show.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is SortData)
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
                case UIData.Property.sortData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.holders:
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
        // Parent
        if (wrapProperty.p is RoomContainerUI.UIData)
        {
            switch ((RoomContainerUI.UIData.Property)wrapProperty.n)
            {
                case RoomContainerUI.UIData.Property.profileId:
                    break;
                case RoomContainerUI.UIData.Property.rooms:
                    dirty = true;
                    break;
                case RoomContainerUI.UIData.Property.sub:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is SortDataUI.UIData)
            {
                switch ((SortDataUI.UIData.Property)wrapProperty.n)
                {
                    case SortDataUI.UIData.Property.editSortData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case SortDataUI.UIData.Property.filter:
                        break;
                    case SortDataUI.UIData.Property.sortType:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is EditData<SortData>)
                {
                    switch ((EditData<SortData>.Property)wrapProperty.n)
                    {
                        case EditData<SortData>.Property.origin:
                            break;
                        case EditData<SortData>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<SortData>.Property.compare:
                            break;
                        case EditData<SortData>.Property.compareOtherType:
                            break;
                        case EditData<SortData>.Property.canEdit:
                            break;
                        case EditData<SortData>.Property.editType:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
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
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
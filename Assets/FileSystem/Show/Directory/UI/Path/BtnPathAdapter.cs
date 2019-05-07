using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace FileSystem
{
    public class BtnPathAdapter : SRIA<BtnPathAdapter.UIData, BtnPathHolder.UIData>
    {

        #region UIData

        [Serializable]
        public class UIData : BaseParams
        {

            public VP<ReferenceData<ShowDirectory>> showDirectory;

            public LP<BtnPathHolder.UIData> holders;

            #region Constructor

            public enum Property
            {
                showDirectory,
                holders
            }

            public UIData() : base()
            {
                this.showDirectory = new VP<ReferenceData<ShowDirectory>>(this, (byte)Property.showDirectory, new ReferenceData<ShowDirectory>(null));
                this.holders = new LP<BtnPathHolder.UIData>(this, (byte)Property.holders);
            }

            #endregion

            [NonSerialized]
            public List<DirectoryInfo> dirs = new List<DirectoryInfo>();

            public void reset()
            {
                this.dirs.Clear();
            }

        }

        #endregion

        #region Adapter

        public BtnPathHolder holderPrefab;

        protected override BtnPathHolder.UIData CreateViewsHolder(int itemIndex)
        {
            BtnPathHolder.UIData uiData = new BtnPathHolder.UIData();
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

        protected override void UpdateViewsHolder(BtnPathHolder.UIData newOrRecycled)
        {
            newOrRecycled.updateView(_Params);
        }

        #endregion

        #region txt

        public Text tvNoDirs;
        private static readonly TxtLanguage txtNoDirs = new TxtLanguage("Don't have any directories");

        static BtnPathAdapter()
        {
            txtNoDirs.add(Language.Type.vi, "Không có đường dẫn nào cả");
        }

        #endregion

        #region Refresh

        public GameObject noDirs;

        private bool firstInit = false;

        public override void refresh()
        {
            if (dirty)
            {
                if (this.Initialized)
                {
                    dirty = false;
                    if (this.data != null)
                    {
                        ShowDirectory showDirectory = this.data.showDirectory.v.data;
                        if (showDirectory != null)
                        {
                            List<DirectoryInfo> dirs = new List<DirectoryInfo>();
                            // get
                            {
                                DirectoryInfo dir = showDirectory.directory.v;
                                while (dir != null)
                                {
                                    dirs.Insert(0, dir);
                                    dir = dir.Parent;
                                }
                            }
                            // Make list
                            {
                                int min = Mathf.Min(dirs.Count, _Params.dirs.Count);
                                // Update
                                {
                                    for (int i = 0; i < min; i++)
                                    {
                                        if (dirs[i] != _Params.dirs[i])
                                        {
                                            // change param
                                            _Params.dirs[i] = dirs[i];
                                            // Update holder
                                            foreach (BtnPathHolder.UIData holder in this.data.holders.vs)
                                            {
                                                if (holder.ItemIndex == i)
                                                {
                                                    holder.dir.v = dirs[i];
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                // Add or Remove
                                {
                                    if (dirs.Count > min)
                                    {
                                        // Add
                                        int insertCount = dirs.Count - min;
                                        List<DirectoryInfo> addItems = dirs.GetRange(min, insertCount);
                                        _Params.dirs.AddRange(addItems);
                                        InsertItems(min, insertCount, false, false);
                                    }
                                    else
                                    {
                                        // Remove
                                        int deleteCount = _Params.dirs.Count - min;
                                        if (deleteCount > 0)
                                        {
                                            RemoveItems(min, deleteCount, false, false);
                                            _Params.dirs.RemoveRange(min, deleteCount);
                                        }
                                    }
                                }
                            }
                            // NoDirs
                            {
                                if (noDirs != null)
                                {
                                    bool haveAny = false;
                                    {
                                        foreach (BtnPathHolder.UIData holder in this.data.holders.vs)
                                        {
                                            if (holder.dir.v != null)
                                            {
                                                BtnPathHolder holderUI = holder.findCallBack<BtnPathHolder>();
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
                                    noDirs.SetActive(!haveAny);
                                }
                                else
                                {
                                    Debug.LogError("noDirs null: " + this);
                                }
                            }
                            // firstInit
                            {
                                if (firstInit)
                                {
                                    firstInit = false;
                                    // this.ScrollTo(dirs.Count - 1);
                                    // Debug.LogError("smotthScroll");
                                    // this.SmoothScrollTo(dirs.Count - 1, 0.3f, 0, 0f, null, true);
                                    // Debug.LogError("firstScroll: " + dirs.Count);
                                    // this.SmoothScrollTo(dirs.Count - 1, 0.3f, 0, 0f, null, true);
                                    StartCoroutine(TaskScrollToBottom(dirs.Count));
                                }
                            }
                            // txt
                            {
                                if (tvNoDirs != null)
                                {
                                    tvNoDirs.text = txtNoDirs.get();
                                }
                                else
                                {
                                    Debug.LogError("tvNoDirs null: " + this);
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("server null: " + this);
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
            return false;
        }

        #endregion

        public IEnumerator TaskScrollToBottom(int dirCount)
        {
            yield return new WaitForSeconds(0.5f);
            if (this.data != null)
            {
                int index = dirCount - 1;
                if (index > 0)
                {
                    // this.SmoothScrollTo(index, 0.3f, 1, 1f, null, true);
                    this.ScrollTo(index, 1, 1);
                    // this.ScrollTo(index, 1f, 1f);
                }
                else
                {
                    Debug.LogError("Don't have anything to scroll: " + index);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        #region implement callBacks

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.showDirectory.allAddCallBack(this);
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
            if (data is ShowDirectory)
            {
                // reset
                {
                    if (this.data != null)
                    {
                        this.data.reset();
                    }
                    else
                    {
                        Debug.LogError("data null: " + this);
                    }
                }
                firstInit = true;
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
                    uiData.showDirectory.allRemoveCallBack(this);
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
            if (data is ShowDirectory)
            {
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
                    case UIData.Property.showDirectory:
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
            // Child
            if (wrapProperty.p is ShowDirectory)
            {
                switch ((ShowDirectory.Property)wrapProperty.n)
                {
                    case ShowDirectory.Property.state:
                        break;
                    case ShowDirectory.Property.directory:
                        dirty = true;
                        break;
                    case ShowDirectory.Property.directoryHistory:
                        break;
                    case ShowDirectory.Property.files:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
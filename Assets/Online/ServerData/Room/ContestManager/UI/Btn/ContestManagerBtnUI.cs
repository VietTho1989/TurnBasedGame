using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

public class ContestManagerBtnUI : UIBehavior<ContestManagerBtnUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ContestManagerBtnChatUI.UIData> btnChat;

        public VP<ContestManagerBtnRoomUserUI.UIData> btnRoomUser;

        public VP<ContestManagerBtnSettingUI.UIData> btnSetting;

        #region Constructor

        public enum Property
        {
            btnChat,
            btnRoomUser,
            btnSetting
        }

        public UIData() : base()
        {
            this.btnChat = new VP<ContestManagerBtnChatUI.UIData>(this, (byte)Property.btnChat, new ContestManagerBtnChatUI.UIData());
            this.btnRoomUser = new VP<ContestManagerBtnRoomUserUI.UIData>(this, (byte)Property.btnRoomUser, new ContestManagerBtnRoomUserUI.UIData());
            this.btnSetting = new VP<ContestManagerBtnSettingUI.UIData>(this, (byte)Property.btnSetting, new ContestManagerBtnSettingUI.UIData());
        }

        #endregion

    }

    #endregion

    #region txt, rect

    static ContestManagerBtnUI()
    {
        // btnChatRect
        {
            // anchoredPosition: (0.0, 0.0); anchorMin: (0.0, 0.5); anchorMax: (0.0, 0.5); pivot: (0.0, 0.5);
            // offsetMin: (0.0, -15.0); offsetMax: (30.0, 15.0); sizeDelta: (30.0, 30.0);
            btnChatRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
            btnChatRect.anchorMin = new Vector2(0.0f, 0.5f);
            btnChatRect.anchorMax = new Vector2(0.0f, 0.5f);
            btnChatRect.pivot = new Vector2(0.0f, 0.5f);
            btnChatRect.offsetMin = new Vector2(0.0f, -15.0f);
            btnChatRect.offsetMax = new Vector2(30.0f, 15.0f);
            btnChatRect.sizeDelta = new Vector2(30.0f, 30.0f);
        }
        // btnRoomUserRect
        {
            btnRoomUserRect.anchoredPosition = new Vector3(30.0f, 0.0f, 0.0f);
            btnRoomUserRect.anchorMin = new Vector2(0.0f, 0.5f);
            btnRoomUserRect.anchorMax = new Vector2(0.0f, 0.5f);
            btnRoomUserRect.pivot = new Vector2(0.0f, 0.5f);
            btnRoomUserRect.offsetMin = new Vector2(30.0f, -15.0f);
            btnRoomUserRect.offsetMax = new Vector2(60.0f, 15.0f);
            btnRoomUserRect.sizeDelta = new Vector2(30.0f, 30.0f);
        }
        // btnSettingRect
        {
            btnSettingRect.anchoredPosition = new Vector3(60.0f, 0.0f, 0.0f);
            btnSettingRect.anchorMin = new Vector2(0.0f, 0.5f);
            btnSettingRect.anchorMax = new Vector2(0.0f, 0.5f);
            btnSettingRect.pivot = new Vector2(0.0f, 0.5f);
            btnSettingRect.offsetMin = new Vector2(60.0f, -15.0f);
            btnSettingRect.offsetMax = new Vector2(90.0f, 15.0f);
            btnSettingRect.sizeDelta = new Vector2(30.0f, 30.0f);
        }
    }

    #endregion

    #region Refresh

    public Image bg;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // find
                bool isPlaying = false;
                {
                    ContestManagerUI.UIData contestManagerUIData = this.data.findDataInParent<ContestManagerUI.UIData>();
                    if (contestManagerUIData != null)
                    {
                        ContestManagerUI.UIData.Sub sub = contestManagerUIData.sub.v;
                        if (sub != null)
                        {
                            if (sub.getType() == ContestManager.State.Type.Play)
                            {
                                isPlaying = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("sub null");
                        }
                    }
                    else
                    {
                        Debug.LogError("contestManagerUIData null");
                    }
                }
                // set btn visibility
                {
                    if (bg != null)
                    {
                        bg.gameObject.SetActive(isPlaying);
                    }
                    else
                    {
                        Debug.LogError("bg null");
                    }
                    UIRectTransform.SetActive(this.data.btnChat.v, isPlaying);
                    UIRectTransform.SetActive(this.data.btnRoomUser.v, isPlaying);
                    UIRectTransform.SetActive(this.data.btnSetting.v, isPlaying);
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public ContestManagerBtnChatUI btnChatPrefab;
    private static readonly UIRectTransform btnChatRect = new UIRectTransform();

    public ContestManagerBtnRoomUserUI btnRoomUserPrefab;
    private static readonly UIRectTransform btnRoomUserRect = new UIRectTransform();

    public ContestManagerBtnSettingUI btnSettingPrefab;
    private static readonly UIRectTransform btnSettingRect = new UIRectTransform();

    private ContestManagerUI.UIData contestManagerUIData = null;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Parent
            {
                DataUtils.addParentCallBack(uiData, this, ref this.contestManagerUIData);
            }
            // Child
            {
                uiData.btnChat.allAddCallBack(this);
                uiData.btnRoomUser.allAddCallBack(this);
                uiData.btnSetting.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Parent
        if (data is ContestManagerUI.UIData)
        {
            dirty = true;
            return;
        }
        // Child
        {
            if(data is ContestManagerBtnChatUI.UIData)
            {
                ContestManagerBtnChatUI.UIData btnChatUIData = data as ContestManagerBtnChatUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnChatUIData, btnChatPrefab, this.transform, btnChatRect);
                }
                dirty = true;
                return;
            }
            if(data is ContestManagerBtnRoomUserUI.UIData)
            {
                ContestManagerBtnRoomUserUI.UIData btnRoomUserUIData = data as ContestManagerBtnRoomUserUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnRoomUserUIData, btnRoomUserPrefab, this.transform, btnRoomUserRect);
                }
                dirty = true;
                return;
            }
            if(data is ContestManagerBtnSettingUI.UIData)
            {
                ContestManagerBtnSettingUI.UIData btnSettingUIData = data as ContestManagerBtnSettingUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnSettingUIData, btnSettingPrefab, this.transform, btnSettingRect);
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
            // Parent
            {
                DataUtils.removeParentCallBack(uiData, this, ref this.contestManagerUIData);
            }
            // Child
            {
                uiData.btnChat.allRemoveCallBack(this);
                uiData.btnRoomUser.allRemoveCallBack(this);
                uiData.btnSetting.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Parent
        if (data is ContestManagerUI.UIData)
        {
            return;
        }
        // Child
        {
            if (data is ContestManagerBtnChatUI.UIData)
            {
                ContestManagerBtnChatUI.UIData btnChatUIData = data as ContestManagerBtnChatUI.UIData;
                // UI
                {
                    btnChatUIData.removeCallBackAndDestroy(typeof(ContestManagerBtnChatUI));
                }
                return;
            }
            if (data is ContestManagerBtnRoomUserUI.UIData)
            {
                ContestManagerBtnRoomUserUI.UIData btnRoomUserUIData = data as ContestManagerBtnRoomUserUI.UIData;
                // UI
                {
                    btnRoomUserUIData.removeCallBackAndDestroy(typeof(ContestManagerBtnRoomUserUI));
                }
                return;
            }
            if (data is ContestManagerBtnSettingUI.UIData)
            {
                ContestManagerBtnSettingUI.UIData btnSettingUIData = data as ContestManagerBtnSettingUI.UIData;
                // UI
                {
                    btnSettingUIData.removeCallBackAndDestroy(typeof(ContestManagerBtnSettingUI));
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
                case UIData.Property.btnChat:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnRoomUser:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnSetting:
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
        // Parent
        if (wrapProperty.p is ContestManagerUI.UIData)
        {
            switch ((ContestManagerUI.UIData.Property)wrapProperty.n)
            {
                case ContestManagerUI.UIData.Property.contestManager:
                    break;
                case ContestManagerUI.UIData.Property.sub:
                    dirty = true;
                    break;
                case ContestManagerUI.UIData.Property.btns:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is ContestManagerBtnChatUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is ContestManagerBtnRoomUserUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is ContestManagerBtnSettingUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SettingTimeStepUpdate : MonoBehaviour, ValueChangeCallBack
{

    #region lifeCycle

    void Awake()
    {
        Setting.get().addCallBack(this);
    }

    void OnDestroy()
    {
        Setting.get().removeCallBack(this);
    }

    private bool firstUpdate = true;

    private void Update()
    {
        this.enabled = false;
        // find
        bool needUpdate = true;
        {
            if (firstUpdate)
            {
                firstUpdate = false;
                if (Setting.get().timeStep.v == Setting.DefaultTimeStep)
                {
                    needUpdate = false;
                }
            }
        }
        // process
        if (needUpdate)
        {
            Time.fixedDeltaTime = 1.0f / Mathf.Clamp(Setting.get().timeStep.v, Setting.MinTimeStep, Setting.MaxTimeStep);
        }
    }

    #endregion

    #region implement callBacks

    public void onAddCallBack<T>(T data) where T : Data
    {
        if(data is Setting)
        {
            this.enabled = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
    {
        if (data is Setting)
        {
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if(wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
                case Setting.Property.fastStart:
                    break;
                case Setting.Property.timeStep:
                    this.enabled = true;
                    break;
                case Setting.Property.language:
                    break;
                case Setting.Property.useShortKey:
                    break;
                case Setting.Property.style:
                    break;
                case Setting.Property.contentTextSize:
                    break;
                case Setting.Property.titleTextSize:
                    break;
                case Setting.Property.labelTextSize:
                    break;
                case Setting.Property.buttonSize:
                    break;
                case Setting.Property.itemSize:
                    break;
                case Setting.Property.confirmQuit:
                    break;
                case Setting.Property.boardIndex:
                    break;
                case Setting.Property.showLastMove:
                    break;
                case Setting.Property.viewUrlImage:
                    break;
                case Setting.Property.animationSetting:
                    break;
                case Setting.Property.maxThinkCount:
                    break;
                case Setting.Property.defaultChosenGame:
                    break;
                case Setting.Property.defaultRoomName:
                    break;
                case Setting.Property.defaultChatRoomStyle:
                    break;
                case Setting.Property.screenCaptureSetting:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
    }

    #endregion

}
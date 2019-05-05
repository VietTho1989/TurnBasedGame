using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
    public class BtnRoundRobinContentUI : UIHaveTransformDataBehavior<BtnRoundRobinContentUI.UIData>
    {

        #region UIData

        public class UIData : RoomBtnUI.UIData.Sub
        {

            public VP<ReferenceData<RoundRobinContentUI.UIData>> roundRobinContentUIData;

            #region Constructor

            public enum Property
            {
                roundRobinContentUIData
            }

            public UIData() : base()
            {
                this.roundRobinContentUIData = new VP<ReferenceData<RoundRobinContentUI.UIData>>(this, (byte)Property.roundRobinContentUIData, new ReferenceData<RoundRobinContentUI.UIData>(null));
            }

            #endregion

            public override Type getType()
            {
                return Type.RoundRobinContent;
            }

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            BtnRoundRobinContentUI btnRoundRobinContentUI = this.findCallBack<BtnRoundRobinContentUI>();
                            if (btnRoundRobinContentUI != null)
                            {
                                isProcess = btnRoundRobinContentUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("btnRoundRobinContentUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtRoundRobinContent = new TxtLanguage("Round-robin");

        static BtnRoundRobinContentUI()
        {
            txtRoundRobinContent.add(Language.Type.vi, "Vòng tròn");
        }

        #endregion

        #region Refresh

        public Text tvRoundRobinContent;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    RoundRobinContentUI.UIData roundRobinContentUIData = this.data.roundRobinContentUIData.v.data;
                    if (roundRobinContentUIData != null)
                    {
                        // tvRoundRobinContent
                        {
                            if (tvRoundRobinContent != null)
                            {
                                int roundRobinIndex = 0;
                                int roundRobinCount = 1;
                                {
                                    // roundRobinIndex
                                    {
                                        RoundRobinUI.UIData roundRobinUIData = roundRobinContentUIData.roundRobinUIData.v;
                                        if (roundRobinUIData != null)
                                        {
                                            RoundRobin roundRobin = roundRobinUIData.roundRobin.v.data;
                                            if (roundRobin != null)
                                            {
                                                roundRobinIndex = roundRobin.index.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("roundRobin null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("roundRobinUIData null: " + this);
                                        }
                                    }
                                    // roundRobinCount
                                    {
                                        RoundRobinContent roundRobinContent = roundRobinContentUIData.roundRobinContent.v.data;
                                        if (roundRobinContent != null)
                                        {
                                            roundRobinCount = roundRobinContent.roundRobins.vs.Count;
                                        }
                                        else
                                        {
                                            // Debug.LogError ("roundRobinContent null: " + this);
                                        }
                                    }
                                }
                                tvRoundRobinContent.text = txtRoundRobinContent.get() + " " + (roundRobinIndex + 1) + "/" + roundRobinCount;
                            }
                            else
                            {
                                Debug.LogError("tvRoundRobinContent null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("roundRobinContentUIData null: " + this);
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

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.roundRobinContentUIData.allAddCallBack(this);
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
                if (data is RoundRobinContentUI.UIData)
                {
                    RoundRobinContentUI.UIData roundRobinContentUIData = data as RoundRobinContentUI.UIData;
                    // Child
                    {
                        roundRobinContentUIData.roundRobinContent.allAddCallBack(this);
                        roundRobinContentUIData.roundRobinUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is RoundRobinContent)
                    {
                        dirty = true;
                        return;
                    }
                    // roundRobinUIData
                    {
                        if (data is RoundRobinUI.UIData)
                        {
                            RoundRobinUI.UIData roundRobinUIData = data as RoundRobinUI.UIData;
                            // Child
                            {
                                roundRobinUIData.roundRobin.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if (data is RoundRobin)
                        {
                            dirty = true;
                            return;
                        }
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
                    uiData.roundRobinContentUIData.allRemoveCallBack(this);
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
                if (data is RoundRobinContentUI.UIData)
                {
                    RoundRobinContentUI.UIData roundRobinContentUIData = data as RoundRobinContentUI.UIData;
                    // Child
                    {
                        roundRobinContentUIData.roundRobinContent.allRemoveCallBack(this);
                        roundRobinContentUIData.roundRobinUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is RoundRobinContent)
                    {
                        return;
                    }
                    // roundRobinUIData
                    {
                        if (data is RoundRobinUI.UIData)
                        {
                            RoundRobinUI.UIData roundRobinUIData = data as RoundRobinUI.UIData;
                            // Child
                            {
                                roundRobinUIData.roundRobin.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        if (data is RoundRobin)
                        {
                            return;
                        }
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
                    case UIData.Property.roundRobinContentUIData:
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
                if (wrapProperty.p is RoundRobinContentUI.UIData)
                {
                    switch ((RoundRobinContentUI.UIData.Property)wrapProperty.n)
                    {
                        case RoundRobinContentUI.UIData.Property.roundRobinContent:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case RoundRobinContentUI.UIData.Property.roundRobinUIData:
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
                // Child
                {
                    if (wrapProperty.p is RoundRobinContent)
                    {
                        switch ((RoundRobinContent.Property)wrapProperty.n)
                        {
                            case RoundRobinContent.Property.singleContestFactory:
                                break;
                            case RoundRobinContent.Property.roundRobins:
                                dirty = true;
                                break;
                            case RoundRobinContent.Property.requestNewRoundRobin:
                                break;
                            case RoundRobinContent.Property.needReturnRound:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // roundRobinUIData
                    {
                        if (wrapProperty.p is RoundRobinUI.UIData)
                        {
                            switch ((RoundRobinUI.UIData.Property)wrapProperty.n)
                            {
                                case RoundRobinUI.UIData.Property.roundRobin:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case RoundRobinUI.UIData.Property.roundContestUIData:
                                    break;
                                case RoundRobinUI.UIData.Property.chooseRoundContestUIData:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Child
                        if (wrapProperty.p is RoundRobin)
                        {
                            switch ((RoundRobin.Property)wrapProperty.n)
                            {
                                case RoundRobin.Property.state:
                                    break;
                                case RoundRobin.Property.index:
                                    dirty = true;
                                    break;
                                case RoundRobin.Property.roundContests:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnRoundRobinContent()
        {
            if (this.data != null)
            {
                RoundRobinContentUI.UIData roundRobinContentUIData = this.data.roundRobinContentUIData.v.data;
                if (roundRobinContentUIData != null)
                {
                    ChooseRoundRobinUI.UIData chooseRoundRobinUIData = roundRobinContentUIData.chooseRoundRobinUIData.newOrOld<ChooseRoundRobinUI.UIData>();
                    {

                    }
                    roundRobinContentUIData.chooseRoundRobinUIData.v = chooseRoundRobinUIData;
                }
                else
                {
                    Debug.LogError("roundRobinContentUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}
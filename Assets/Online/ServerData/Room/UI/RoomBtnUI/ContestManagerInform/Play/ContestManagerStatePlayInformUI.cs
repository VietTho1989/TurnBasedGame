using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class ContestManagerStatePlayInformUI : UIBehavior<ContestManagerStatePlayInformUI.UIData>
    {

        #region UIData

        public class UIData : ContestManagerInformUI.UIData.StateUI
        {

            public VP<ReferenceData<ContestManagerStatePlay>> contestManagerStatePlay;

            public VP<ContestManagerPlayBtnForceEndUI.UIData> btnForceEnd;

            #region Constructor

            public enum Property
            {
                contestManagerStatePlay,
                btnForceEnd
            }

            public UIData() : base()
            {
                this.contestManagerStatePlay = new VP<ReferenceData<ContestManagerStatePlay>>(this, (byte)Property.contestManagerStatePlay, new ReferenceData<ContestManagerStatePlay>(null));
                this.btnForceEnd = new VP<ContestManagerPlayBtnForceEndUI.UIData>(this, (byte)Property.btnForceEnd, new ContestManagerPlayBtnForceEndUI.UIData());
            }

            #endregion

            public override ContestManager.State.Type getType()
            {
                return ContestManager.State.Type.Play;
            }

        }

        #endregion

        #region txt

        public Text lbForceEnd;
        public static readonly TxtLanguage txtForceEnd = new TxtLanguage();

        static ContestManagerStatePlayInformUI()
        {
            // txt
            txtForceEnd.add(Language.Type.vi, "Buộc kết thúc");
            // rect
            {
                // btnForceEndRect
                {
                    // anchoredPosition: (90.0, -10.0); anchorMin: (0.0, 1.0); anchorMax: (0.0, 1.0); pivot: (0.0, 1.0);
                    // offsetMin: (90.0, -50.0); offsetMax: (130.0, -10.0); sizeDelta: (40.0, 40.0);
                    btnForceEndRect.anchoredPosition = new Vector3(90.0f, -10.0f, 0.0f);
                    btnForceEndRect.anchorMin = new Vector2(0.0f, 1.0f);
                    btnForceEndRect.anchorMax = new Vector2(0.0f, 1.0f);
                    btnForceEndRect.pivot = new Vector2(0.0f, 1.0f);
                    btnForceEndRect.offsetMin = new Vector2(90.0f, -50.0f);
                    btnForceEndRect.offsetMax = new Vector2(130.0f, -10.0f);
                    btnForceEndRect.sizeDelta = new Vector2(40.0f, 40.0f);
                }
            }
        }

        #endregion

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    ContestManagerStatePlay contestManagerStatePlay = this.data.contestManagerStatePlay.v.data;
                    if (contestManagerStatePlay != null)
                    {
                        // btnForceEnd
                        {
                            ContestManagerPlayBtnForceEndUI.UIData btnForceEnd = this.data.btnForceEnd.v;
                            if (btnForceEnd != null)
                            {
                                btnForceEnd.contestManagerStatePlay.v = new ReferenceData<ContestManagerStatePlay>(contestManagerStatePlay);
                            }
                            else
                            {
                                Debug.LogError("btnForceEnd null: " + this);
                            }
                        }
                        // txt
                        {
                            if (lbForceEnd != null)
                            {
                                lbForceEnd.text = txtForceEnd.get("Force end");
                            }
                            else
                            {
                                Debug.LogError("lbForceEnd null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("contestManagerStatePlay null: " + this);
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

        public ContestManagerPlayBtnForceEndUI btnForceEndPrefab;
        private static readonly UIRectTransform btnForceEndRect = new UIRectTransform();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.contestManagerStatePlay.allAddCallBack(this);
                    uiData.btnForceEnd.allAddCallBack(this);
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
                if (data is ContestManagerStatePlay)
                {
                    dirty = true;
                    return;
                }
                if (data is ContestManagerPlayBtnForceEndUI.UIData)
                {
                    ContestManagerPlayBtnForceEndUI.UIData btnForceEnd = data as ContestManagerPlayBtnForceEndUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(btnForceEnd, btnForceEndPrefab, this.transform, btnForceEndRect);
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
                    uiData.contestManagerStatePlay.allRemoveCallBack(this);
                    uiData.btnForceEnd.allRemoveCallBack(this);
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
                if (data is ContestManagerStatePlay)
                {
                    return;
                }
                if (data is ContestManagerPlayBtnForceEndUI.UIData)
                {
                    ContestManagerPlayBtnForceEndUI.UIData btnForceEnd = data as ContestManagerPlayBtnForceEndUI.UIData;
                    // UI
                    {
                        btnForceEnd.removeCallBackAndDestroy(typeof(ContestManagerPlayBtnForceEndUI));
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
                    case UIData.Property.contestManagerStatePlay:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.btnForceEnd:
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
                        Debug.LogError("Don't proccess: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is ContestManagerStatePlay)
                {
                    return;
                }
                if (wrapProperty.p is ContestManagerPlayBtnForceEndUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
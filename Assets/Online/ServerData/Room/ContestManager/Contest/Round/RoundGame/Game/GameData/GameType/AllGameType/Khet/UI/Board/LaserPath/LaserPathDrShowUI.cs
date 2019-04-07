using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
    public class LaserPathDrShowUI : UIBehavior<LaserPathDrShowUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            #region Constructor

            public enum Property
            {

            }

            public UIData() : base()
            {

            }

            #endregion

        }

        #endregion

        #region drShow

        public Dropdown drShow;

        public override void Awake()
        {
            base.Awake();
            if (drShow != null)
            {
                drShow.onValueChanged.AddListener(delegate (int newValue) {
                    if (this.data != null)
                    {
                        LaserPathUI.UIData laserPathUIData = this.data.findDataInParent<LaserPathUI.UIData>();
                        if (laserPathUIData != null)
                        {
                            laserPathUIData.show.v = (LaserPathUI.UIData.Show)newValue;
                        }
                        else
                        {
                            Debug.LogError("laserPathUIData null");
                        }
                    }
                    else
                    {
                        Debug.LogError("data null: " + this);
                    }
                });
            }
            else
            {
                Debug.LogError("drShow null: " + this);
            }
        }

        private static readonly TxtLanguage txtAll = new TxtLanguage("All");
        private static readonly TxtLanguage txtSilver = new TxtLanguage("Silver");
        private static readonly TxtLanguage txtRed = new TxtLanguage("Red");
        private static readonly TxtLanguage txtNone = new TxtLanguage("None");

        static LaserPathDrShowUI()
        {
            txtAll.add(Language.Type.vi, "Tất cả");
            txtSilver.add(Language.Type.vi, "Bạc");
            txtRed.add(Language.Type.vi, "Đỏ");
            txtNone.add(Language.Type.vi, "Không");
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
                    // drShow
                    {
                        if (drShow != null)
                        {
                            // options
                            {
                                string[] options = {
                                        txtAll.get (),
                                        txtSilver.get (),
                                        txtRed.get (),
                                        txtNone.get ()
                                    };
                                UIUtils.RefreshDropDownOptions(drShow, options);
                            }
                            // set value
                            {
                                LaserPathUI.UIData.Show show = LaserPathUI.UIData.Show.All;
                                {
                                    LaserPathUI.UIData laserPathUIData = this.data.findDataInParent<LaserPathUI.UIData>();
                                    if (laserPathUIData != null)
                                    {
                                        show = laserPathUIData.show.v;
                                    }
                                    else
                                    {
                                        Debug.LogError("laserPathUIData null");
                                    }
                                }
                                drShow.value = (int)show;
                            }
                            drShow.RefreshShownValue();
                            // show or not
                            {
                                bool isShow = true;
                                {
                                    MiniGameDataUI.UIData miniGameDataUIData = this.data.findDataInParent<MiniGameDataUI.UIData>();
                                    if (miniGameDataUIData != null)
                                    {
                                        isShow = false;
                                    }
                                }
                                drShow.gameObject.SetActive(isShow);
                            }
                        }
                        else
                        {
                            Debug.LogError("drShow null");
                        }
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

        private LaserPathUI.UIData laserPathUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if(data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.laserPathUIData);
                }
                dirty = true;
                return;
            }
            // Setting
            if(data is Setting)
            {
                dirty = true;
                return;
            }
            // Parent
            if (data is LaserPathUI.UIData)
            {
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.laserPathUIData);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if(data is Setting)
            {
                return;
            }
            // Parent
            if (data is LaserPathUI.UIData)
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
                return;
            }
            // Setting
            if(wrapProperty.p is Setting)
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
            // Parent
            if (wrapProperty.p is LaserPathUI.UIData)
            {
                switch ((LaserPathUI.UIData.Property)wrapProperty.n)
                {
                    case LaserPathUI.UIData.Property.khet:
                        break;
                    case LaserPathUI.UIData.Property.laserPoints:
                        break;
                    case LaserPathUI.UIData.Property.force:
                        break;
                    case LaserPathUI.UIData.Property.show:
                        dirty = true;
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
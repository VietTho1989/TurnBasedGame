using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Record
{
    public class ViewRecordControllerStatePlayUI : UIBehavior<ViewRecordControllerStatePlayUI.UIData>
    {

        #region UIData

        public class UIData : ViewRecordControllerUI.UIData.StateUI
        {

            public VP<ReferenceData<ViewRecordControllerStatePlay>> play;

            #region Constructor

            public enum Property
            {
                play
            }

            public UIData() : base()
            {
                this.play = new VP<ReferenceData<ViewRecordControllerStatePlay>>(this, (byte)Property.play, new ReferenceData<ViewRecordControllerStatePlay>(null));
            }

            #endregion

            public override ViewRecordControllerUI.UIData.State.Type getType()
            {
                return ViewRecordControllerUI.UIData.State.Type.Play;
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
                            ViewRecordControllerStatePlayUI viewRecordControllerStatePlayUI = this.findCallBack<ViewRecordControllerStatePlayUI>();
                            if (viewRecordControllerStatePlayUI != null)
                            {
                                isProcess = viewRecordControllerStatePlayUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("viewRecordControllerStatePlayUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtPause = new TxtLanguage("Pause");
        private static readonly TxtLanguage txtPlay = new TxtLanguage("Play");

        static ViewRecordControllerStatePlayUI()
        {
            txtPause.add(Language.Type.vi, "Tạm Dừng");
            txtPlay.add(Language.Type.vi, "Chơi");
        }

        #endregion

        #region Refresh

        public Text tvPlay;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    ViewRecordControllerStatePlay play = this.data.play.v.data;
                    if (play != null)
                    {
                        // tvPlay
                        {
                            if (tvPlay != null)
                            {
                                switch (play.state.v)
                                {
                                    case ViewRecordControllerStatePlay.State.Normal:
                                        {
                                            tvPlay.text = txtPause.get();
                                        }
                                        break;
                                    case ViewRecordControllerStatePlay.State.Pause:
                                        {
                                            tvPlay.text = txtPlay.get();
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + play.state.v + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("tvPlay null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("play null: " + this);
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

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.play.allAddCallBack(this);
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
            if (data is ViewRecordControllerStatePlay)
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
                // Child
                {
                    uiData.play.allRemoveCallBack(this);
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
            if (data is ViewRecordControllerStatePlay)
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
                    case UIData.Property.play:
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
            if (wrapProperty.p is ViewRecordControllerStatePlay)
            {
                switch ((ViewRecordControllerStatePlay.Property)wrapProperty.n)
                {
                    case ViewRecordControllerStatePlay.Property.time:
                        break;
                    case ViewRecordControllerStatePlay.Property.state:
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

        public bool useShortKey(Event e)
        {
            bool isProcess = false;
            {
                if (e.isKey && e.type == EventType.KeyUp)
                {
                    switch (e.keyCode)
                    {
                        case KeyCode.P:
                            {
                                if (btnPlay != null && btnPlay.interactable)
                                {
                                    this.onClickBtnPlay();
                                    isProcess = true;
                                }
                                else
                                {
                                    Debug.LogError("cannot click");
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return isProcess;
        }

        public Button btnPlay;

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnPlay()
        {
            if (this.data != null)
            {
                ViewRecordControllerStatePlay play = this.data.play.v.data;
                if (play != null)
                {
                    switch (play.state.v)
                    {
                        case ViewRecordControllerStatePlay.State.Normal:
                            play.state.v = ViewRecordControllerStatePlay.State.Pause;
                            break;
                        case ViewRecordControllerStatePlay.State.Pause:
                            play.state.v = ViewRecordControllerStatePlay.State.Normal;
                            break;
                        default:
                            Debug.LogError("unknown state: " + play.state.v + "; " + this);
                            break;
                    }
                }
                else
                {
                    Debug.LogError("play null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}
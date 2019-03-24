using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContestManagerBtnChatUI : UIBehavior<ContestManagerBtnChatUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        #region visibility

        public enum Visibility
        {
            Show,
            Hide
        }

        private static readonly TxtLanguage txtShow = new TxtLanguage();
        private static readonly TxtLanguage txtHide = new TxtLanguage();

        public static List<string> GetStrVisibility()
        {
            List<string> ret = new List<string>();
            {
                ret.Add(txtShow.get("Show"));
                ret.Add(txtHide.get("Hide"));
            }
            return ret;
        }

        public VP<Visibility> visibility;

        #endregion

        #region style

        public enum Style
        {
            Overlay,
            Full,
            Push
        }

        private static readonly TxtLanguage txtOverlay = new TxtLanguage();
        private static readonly TxtLanguage txtFull = new TxtLanguage();
        private static readonly TxtLanguage txtPush = new TxtLanguage();

        public static List<string> GetStrStyles()
        {
            List<string> ret = new List<string>();
            {
                ret.Add(txtOverlay.get("Overlay"));
                ret.Add(txtFull.get("By Side"));
                ret.Add(txtPush.get("Push"));
            }
            return ret;
        }

        static UIData()
        {
            // visibility
            {
                txtShow.add(Language.Type.vi, "Hiện");
                txtHide.add(Language.Type.vi, "Ẩn");
            }
            // style
            {
                txtOverlay.add(Language.Type.vi, "Đặt Lên");
                txtFull.add(Language.Type.vi, "Ngay Cạnh");
                txtPush.add(Language.Type.vi, "Đẩy");
            }
        }

        public VP<Style> style;

        #endregion

        #region Constructor

        public enum Property
        {
            visibility,
            style
        }

        public UIData() : base()
        {
            this.visibility = new VP<Visibility>(this, (byte)Property.visibility, Setting.get().defaultChatRoomStyle.v.getVisibility());
            this.style = new VP<Style>(this, (byte)Property.style, Setting.get().defaultChatRoomStyle.v.getStyle());
            // Debug.LogWarning("btnChat constructor: " + this.visibility.v + ", " + this.style.v);
        }

        #endregion

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

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            this.setDataNull(uiData);
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if(wrapProperty.p is UIData)
        {
            switch ((UIData.Property)wrapProperty.n)
            {
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnChat()
    {
        if (this.data != null)
        {
            this.data.visibility.v = UIData.Visibility.Show;
            Setting.get().defaultChatRoomStyle.v.setLastVisibility(UIData.Visibility.Show);
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}
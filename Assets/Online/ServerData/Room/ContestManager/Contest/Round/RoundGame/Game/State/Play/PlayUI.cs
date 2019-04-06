using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Ads;

namespace GameState
{
    public class PlayUI : UIBehavior<PlayUI.UIData>
    {

        #region UIData

        public class UIData : StateUI.UIData.Sub
        {

            public VP<ReferenceData<Play>> play;

            #region Sub

            public abstract class Sub : Data
            {

                public abstract Play.Sub.Type getType();

            }

            public VP<Sub> sub;

            #endregion

            public VP<BtnRequestNewUI.UIData> btnRequestNew;

            #region Constructor

            public enum Property
            {
                play,
                sub,
                btnRequestNew
            }

            public UIData() : base()
            {
                this.play = new VP<ReferenceData<Play>>(this, (byte)Property.play, new ReferenceData<Play>(null));
                this.sub = new VP<Sub>(this, (byte)Property.sub, null);
                this.btnRequestNew = new VP<BtnRequestNewUI.UIData>(this, (byte)Property.btnRequestNew, new BtnRequestNewUI.UIData());
            }

            #endregion

            public override State.Type getType()
            {
                return State.Type.Play;
            }

        }

        #endregion

        #region Refresh

        public UIData.Sub lastSub = null;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Play play = this.data.play.v.data;
                    if (play != null)
                    {
                        // sub
                        {
                            Play.Sub sub = play.sub.v;
                            if (sub != null)
                            {
                                switch (sub.getType())
                                {
                                    case Play.Sub.Type.Normal:
                                        {
                                            PlayNormal playNormal = sub as PlayNormal;
                                            // UIData
                                            PlayNormalUI.UIData playNormalUIData = this.data.sub.newOrOld<PlayNormalUI.UIData>();
                                            {
                                                playNormalUIData.playNormal.v = new ReferenceData<PlayNormal>(playNormal);
                                            }
                                            this.data.sub.v = playNormalUIData;
                                        }
                                        break;
                                    case Play.Sub.Type.Pause:
                                        {
                                            PlayPause playPause = sub as PlayPause;
                                            // UIData
                                            PlayPauseUI.UIData playPauseUIData = this.data.sub.newOrOld<PlayPauseUI.UIData>();
                                            {
                                                playPauseUIData.playPause.v = new ReferenceData<PlayPause>(playPause);
                                            }
                                            this.data.sub.v = playPauseUIData;
                                        }
                                        break;
                                    case Play.Sub.Type.UnPause:
                                        {
                                            PlayUnPause playUnPause = sub as PlayUnPause;
                                            // UIData
                                            PlayUnPauseUI.UIData playUnPauseUIData = this.data.sub.newOrOld<PlayUnPauseUI.UIData>();
                                            {
                                                playUnPauseUIData.playUnPause.v = new ReferenceData<PlayUnPause>(playUnPause);
                                            }
                                            this.data.sub.v = playUnPauseUIData;
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("sub null: " + this);
                            }
                        }
                        // siblingIndex
                        {
                            UIRectTransform.SetSiblingIndex(this.data.sub.v, 0);
                            UIRectTransform.SetSiblingIndex(this.data.btnRequestNew.v, 1);
                        }
                        // position
                        {
                            // find
                            RectTransform boardTransform = null;
                            float boardLeft = 0;
                            float boardRight = 0;
                            float boardTop = 0;
                            float boardBottom = 0;
                            {
                                GameUI.UIData gameUIData = this.data.findDataInParent<GameUI.UIData>();
                                if (gameUIData != null)
                                {
                                    GameDataUI.UIData gameDataUIData = gameUIData.gameDataUI.v;
                                    if (gameDataUIData != null)
                                    {
                                        GameDataBoardUI.UIData gameDataBoardUIData = gameDataUIData.board.v;
                                        if (gameDataBoardUIData != null)
                                        {
                                            // boardTransform
                                            {
                                                GameDataBoardUI gameDataBoardUI = gameDataBoardUIData.findCallBack<GameDataBoardUI>();
                                                if (gameDataBoardUI != null)
                                                {
                                                    boardTransform = (RectTransform)gameDataBoardUI.transform;
                                                }
                                                else
                                                {
                                                    Debug.LogError("gameDataBoardUI null");
                                                }
                                            }
                                            // margin
                                            {
                                                boardLeft = gameDataBoardUIData.left.v;
                                                boardRight = gameDataBoardUIData.right.v;
                                                boardTop = gameDataBoardUIData.top.v;
                                                boardBottom = gameDataBoardUIData.bottom.v;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("gameDataBoardUIData null");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("gameDataUIData null");
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameUIData null");
                                }
                            }
                            // process
                            if (boardTransform != null)
                            {
                                // find
                                float left = boardTransform.rect.xMin;
                                float right = boardTransform.rect.xMax;
                                float top = boardTransform.rect.yMin;
                                float bottom = boardTransform.rect.yMax;
                                {
                                    UIRectTransform.GetMargin(boardTransform, out left, out right, out top, out bottom);
                                    left -= boardLeft;
                                    right += boardRight;
                                    top -= boardTop;
                                    bottom += boardBottom;
                                }
                                // process
                                RectTransform btnRequestNewTransform = null;
                                {
                                    BtnRequestNewUI.UIData btnRequestNewUIData = this.data.btnRequestNew.v;
                                    if (btnRequestNewUIData != null)
                                    {
                                        BtnRequestNewUI btnRequestNewUI = btnRequestNewUIData.findCallBack<BtnRequestNewUI>();
                                        if (btnRequestNewUI != null)
                                        {
                                            btnRequestNewTransform = (RectTransform)btnRequestNewUI.transform;
                                        }
                                        else
                                        {
                                            Debug.LogError("btnRequestNewUI null");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("btnRequestNewUIData null");
                                    }
                                }
                                if (btnRequestNewTransform != null)
                                {
                                    // get gameActions dimension
                                    float endWidth = btnRequestNewTransform.rect.width;
                                    float endHeight = btnRequestNewTransform.rect.height;
                                    // get gameDataUI dimension
                                    float gameWidth = 0;
                                    float gameHeight = 0;
                                    {
                                        RectTransform gameDataUITransform = (RectTransform)this.transform;
                                        if (gameDataUITransform != null)
                                        {
                                            gameWidth = gameDataUITransform.rect.width;
                                            gameHeight = gameDataUITransform.rect.height;
                                        }
                                        else
                                        {
                                            Debug.LogError("gameDataUITransform null");
                                        }
                                    }
                                    // portrait view
                                    if (gameWidth <= gameHeight)
                                    {
                                        float x = 0;
                                        btnRequestNewTransform.anchoredPosition = new Vector2(x, bottom + 60 / 2 + GameDataBoardUI.Margin);
                                    }
                                    // landscape view
                                    else
                                    {
                                        float x = left - endWidth / 2 - GameDataBoardUI.Margin; ;
                                        btnRequestNewTransform.anchoredPosition = new Vector2(x, 30);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameActionsTransform null");
                                }
                            }
                            else
                            {
                                Debug.LogError("boardTransform null");
                            }
                        }
                        // ShowAds
                        {
                            if (lastSub == null)
                            {
                                if (this.data.sub.v != null)
                                {
                                    switch (this.data.sub.v.getType())
                                    {
                                        case Play.Sub.Type.Normal:
                                            {
                                                if (AdsManager.get().hideAdsWhenGameNotPause.v)
                                                {
                                                    AdsManager.get().prepareBannerVisibility.v = AdsManager.PrepareBannerVisibility.Hide;
                                                }
                                            }
                                            break;
                                        case Play.Sub.Type.Pause:
                                        case Play.Sub.Type.UnPause:
                                            {
                                                if (AdsManager.get().showAdsWhenGamePause.v)
                                                {
                                                    AdsManager.get().prepareBannerVisibility.v = AdsManager.PrepareBannerVisibility.Show;
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + this.data.sub.v.getType());
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                if (lastSub != this.data.sub.v)
                                {
                                    if (lastSub.getType() == Play.Sub.Type.Normal)
                                    {
                                        // showAdsWhenGamePause
                                        if (this.data.sub.v != null)
                                        {
                                            switch (this.data.sub.v.getType())
                                            {
                                                case Play.Sub.Type.Normal:
                                                    break;
                                                case Play.Sub.Type.Pause:
                                                case Play.Sub.Type.UnPause:
                                                    {
                                                        if (AdsManager.get().showAdsWhenGamePause.v)
                                                        {
                                                            AdsManager.get().prepareBannerVisibility.v = AdsManager.PrepareBannerVisibility.Show;
                                                        }
                                                    }
                                                    break;
                                                default:
                                                    Debug.LogError("unknown type: " + this.data.sub.v.getType());
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // hideAdsWhenGamePlayAgain
                                        if (this.data.sub.v != null)
                                        {
                                            switch (this.data.sub.v.getType())
                                            {
                                                case Play.Sub.Type.Normal:
                                                    {
                                                        if (AdsManager.get().hideAdsWhenGameNotPause.v)
                                                        {
                                                            AdsManager.get().bannerVisibility.v = AdsManager.BannerVisibility.Hide;
                                                        }
                                                    }
                                                    break;
                                                case Play.Sub.Type.Pause:
                                                case Play.Sub.Type.UnPause:
                                                    break;
                                                default:
                                                    Debug.LogError("unknown type: " + this.data.sub.v.getType());
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                            lastSub = this.data.sub.v;
                        }
                    }
                    else
                    {
                        // Debug.LogError("play null: " + this);
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

        public PlayNormalUI playNormalPrefab;
        public PlayPauseUI playPausePrefab;
        public PlayUnPauseUI playUnPausePrefab;

        public BtnRequestNewUI btnRequestNewPrefab;
        private static readonly UIRectTransform btnRequestNewRect = UIRectTransform.CreateCenterRect(120, 30);

        static PlayUI()
        {
            btnRequestNewRect.setPosY(-7.5f);
        }

        private GameUI.UIData gameUIData = null;
        private GameDataBoardTransformCheckChange<GameDataUI.UIData> gameDataBoardTransformCheckChange = new GameDataBoardTransformCheckChange<GameDataUI.UIData>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.gameUIData);
                }
                // Child
                {
                    uiData.play.allAddCallBack(this);
                    uiData.sub.allAddCallBack(this);
                    uiData.btnRequestNew.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is GameUI.UIData)
                {
                    GameUI.UIData gameUIData = data as GameUI.UIData;
                    // Child
                    {
                        gameUIData.gameDataUI.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is GameDataUI.UIData)
                    {
                        GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                        // CheckChange
                        {
                            gameDataBoardTransformCheckChange.addCallBack(this);
                            gameDataBoardTransformCheckChange.setData(gameDataUIData);
                        }
                        dirty = true;
                        return;
                    }
                    // CheckChange
                    if (data is GameDataBoardTransformCheckChange<GameDataUI.UIData>)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // Child
            {
                if (data is Play)
                {
                    lastSub = null;
                    dirty = true;
                    return;
                }
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case Play.Sub.Type.Normal:
                                {
                                    PlayNormalUI.UIData playNormalUIData = sub as PlayNormalUI.UIData;
                                    UIUtils.Instantiate(playNormalUIData, playNormalPrefab, this.transform);
                                }
                                break;
                            case Play.Sub.Type.Pause:
                                {
                                    PlayPauseUI.UIData playPauseUIData = sub as PlayPauseUI.UIData;
                                    UIUtils.Instantiate(playPauseUIData, playPausePrefab, this.transform);
                                }
                                break;
                            case Play.Sub.Type.UnPause:
                                {
                                    PlayUnPauseUI.UIData playUnPauseUIData = sub as PlayUnPauseUI.UIData;
                                    UIUtils.Instantiate(playUnPauseUIData, playUnPausePrefab, this.transform);
                                }
                                break;
                            default:
                                Debug.LogError("Unknown type: " + sub.getType() + "; " + this);
                                break;
                        }
                    }
                    dirty = true;
                    return;
                }
                if (data is BtnRequestNewUI.UIData)
                {
                    BtnRequestNewUI.UIData btnRequestNewUIData = data as BtnRequestNewUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(btnRequestNewUIData, btnRequestNewPrefab, this.transform, btnRequestNewRect);
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.gameUIData);
                }
                // Child
                {
                    uiData.play.allRemoveCallBack(this);
                    uiData.sub.allRemoveCallBack(this);
                    uiData.btnRequestNew.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                if (data is GameUI.UIData)
                {
                    GameUI.UIData gameUIData = data as GameUI.UIData;
                    // Child
                    {
                        gameUIData.gameDataUI.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is GameDataUI.UIData)
                    {
                        GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                        // CheckChange
                        {
                            gameDataBoardTransformCheckChange.removeCallBack(this);
                            gameDataBoardTransformCheckChange.setData(null);
                        }
                        return;
                    }
                    // CheckChange
                    if (data is GameDataBoardTransformCheckChange<GameDataUI.UIData>)
                    {
                        return;
                    }
                }
            }
            // Child
            {
                if (data is Play)
                {
                    return;
                }
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case Play.Sub.Type.Normal:
                                {
                                    PlayNormalUI.UIData playNormalUIData = sub as PlayNormalUI.UIData;
                                    playNormalUIData.removeCallBackAndDestroy(typeof(PlayNormalUI));
                                }
                                break;
                            case Play.Sub.Type.Pause:
                                {
                                    PlayPauseUI.UIData playPauseUIData = sub as PlayPauseUI.UIData;
                                    playPauseUIData.removeCallBackAndDestroy(typeof(PlayPauseUI));
                                }
                                break;
                            case Play.Sub.Type.UnPause:
                                {
                                    PlayUnPauseUI.UIData playUnPauseUIData = sub as PlayUnPauseUI.UIData;
                                    playUnPauseUIData.removeCallBackAndDestroy(typeof(PlayUnPauseUI));
                                }
                                break;
                            default:
                                Debug.LogError("Unknown type: " + sub.getType() + "; " + this);
                                break;
                        }
                    }
                    return;
                }
                if (data is BtnRequestNewUI.UIData)
                {
                    BtnRequestNewUI.UIData btnRequestNewUIData = data as BtnRequestNewUI.UIData;
                    // UI
                    {
                        btnRequestNewUIData.removeCallBackAndDestroy(typeof(BtnRequestNewUI));
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
                    case UIData.Property.play:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.sub:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.btnRequestNew:
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
            {
                if (wrapProperty.p is GameUI.UIData)
                {
                    switch ((GameUI.UIData.Property)wrapProperty.n)
                    {
                        case GameUI.UIData.Property.game:
                            break;
                        case GameUI.UIData.Property.isReplay:
                            break;
                        case GameUI.UIData.Property.gameDataUI:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case GameUI.UIData.Property.gameBottom:
                            break;
                        case GameUI.UIData.Property.undoRedoRequestUIData:
                            break;
                        case GameUI.UIData.Property.requestDraw:
                            break;
                        case GameUI.UIData.Property.gameChatRoom:
                            break;
                        case GameUI.UIData.Property.gameHistoryUIData:
                            break;
                        case GameUI.UIData.Property.stateUI:
                            break;
                        case GameUI.UIData.Property.saveUIData:
                            break;
                        case GameUI.UIData.Property.gameInformationUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is GameDataUI.UIData)
                    {
                        return;
                    }
                    // CheckChange
                    if (wrapProperty.p is GameDataBoardTransformCheckChange<GameDataUI.UIData>)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // Child
            {
                if (wrapProperty.p is Play)
                {
                    switch ((Play.Property)wrapProperty.n)
                    {
                        case Play.Property.sub:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is UIData.Sub)
                {
                    return;
                }
                if (wrapProperty.p is BtnRequestNewUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
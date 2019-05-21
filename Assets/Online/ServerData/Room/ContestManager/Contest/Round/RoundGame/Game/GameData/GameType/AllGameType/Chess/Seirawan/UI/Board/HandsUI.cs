using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan
{
    public class HandsUI : UIBehavior<HandsUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<bool> whiteElephantInHand;

            public VP<bool> whiteHawkInHand;

            public VP<bool> blackElephantInHand;

            public VP<bool> blackHawkInHand;

            #region Constructor

            public enum Property
            {
                whiteElephantInHand,
                whiteHawkInHand,
                blackElephantInHand,
                blackHawkInHand
            }

            public UIData() : base()
            {
                this.whiteElephantInHand = new VP<bool>(this, (byte)Property.whiteElephantInHand, true);
                this.whiteHawkInHand = new VP<bool>(this, (byte)Property.whiteHawkInHand, true);
                this.blackElephantInHand = new VP<bool>(this, (byte)Property.blackElephantInHand, true);
                this.blackHawkInHand = new VP<bool>(this, (byte)Property.blackHawkInHand, true);
            }

            #endregion

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Seirawan ? 4 : 0;
        }

        #region Refresh

        public Image imgWhiteElephant;
        public Image imgWhiteHawk;

        public Image imgBlackElephant;
        public Image imgBlackHawk;

        public RectTransform whiteHand;
        public RectTransform blackHand;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // check load full
                    bool isLoadFull = true;
                    {
                        // animation
                        if (isLoadFull)
                        {
                            isLoadFull = AnimationManager.IsLoadFull(this.data);
                        }
                    }
                    // process
                    if (isLoadFull)
                    {
                        int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                        // Find MoveAnimation
                        MoveAnimation moveAnimation = null;
                        float time = 0;
                        float duration = 0;
                        {
                            GameDataBoardUI.UIData.getCurrentMoveAnimationInfo(this.data, out moveAnimation, out time, out duration);
                        }
                        // Find Color
                        Common.Color color = Common.Color.WHITE;
                        {
                            BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData>();
                            if (boardUIData != null)
                            {
                                Seirawan seirawan = boardUIData.seirawan.v.data;
                                if (seirawan != null)
                                {
                                    color = seirawan.getPlayerIndex() == 0 ? Common.Color.WHITE : Common.Color.BLACK;
                                }
                                else
                                {
                                    Debug.LogError("seirawan null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("boardUIData null: " + this);
                            }
                        }
                        // whiteElephant
                        if (imgWhiteElephant != null)
                        {
                            imgWhiteElephant.enabled = this.data.whiteElephantInHand.v;
                            imgWhiteElephant.sprite = SeirawanSpriteContainer.get().getSprite(Common.Piece.W_ELEPHANT);
                            // scale
                            {
                                float scale = 1;
                                if (moveAnimation != null)
                                {
                                    switch (moveAnimation.getType())
                                    {
                                        case GameMove.Type.SeirawanMove:
                                            {
                                                SeirawanMoveAnimation seirawanMoveAnimation = moveAnimation as SeirawanMoveAnimation;
                                                if (Common.is_gating(seirawanMoveAnimation.move.v))
                                                {
                                                    if (Common.gating_type(seirawanMoveAnimation.move.v) == Common.PieceType.ELEPHANT)
                                                    {
                                                        if (color == Common.Color.BLACK)
                                                        {
                                                            if (time >= duration - SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration)
                                                            {
                                                                scale = 1 - MoveAnimation.getAccelerateDecelerateInterpolation(
                                                                    (time - (duration - SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration)) /
                                                                    (SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration));
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown moveAnimation: " + moveAnimation + "; " + this);
                                            break;
                                    }
                                }
                                else
                                {
                                    // Debug.LogError ("moveAnimation null: " + this);
                                }
                                imgWhiteElephant.transform.localScale = (playerView == 0 ? new Vector3(scale, scale, scale) : new Vector3(scale, -scale, scale));
                            }
                        }
                        else
                        {
                            Debug.LogError("imgWhiteElephant null: " + this);
                        }
                        // WhiteHawk
                        if (imgWhiteHawk != null)
                        {
                            imgWhiteHawk.enabled = this.data.whiteHawkInHand.v;
                            imgWhiteHawk.sprite = SeirawanSpriteContainer.get().getSprite(Common.Piece.W_HAWK);
                            // scale
                            {
                                float scale = 1;
                                if (moveAnimation != null)
                                {
                                    switch (moveAnimation.getType())
                                    {
                                        case GameMove.Type.SeirawanMove:
                                            {
                                                SeirawanMoveAnimation seirawanMoveAnimation = moveAnimation as SeirawanMoveAnimation;
                                                if (Common.is_gating(seirawanMoveAnimation.move.v))
                                                {
                                                    if (Common.gating_type(seirawanMoveAnimation.move.v) == Common.PieceType.HAWK)
                                                    {
                                                        if (color == Common.Color.BLACK)
                                                        {
                                                            if (time >= duration - SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration)
                                                            {
                                                                scale = 1 - MoveAnimation.getAccelerateDecelerateInterpolation(
                                                                    (time - (duration - SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration)) /
                                                                    (SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration));
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown moveAnimation: " + moveAnimation + "; " + this);
                                            break;
                                    }
                                }
                                else
                                {
                                    // Debug.LogError ("moveAnimation null: " + this);
                                }
                                imgWhiteHawk.transform.localScale = (playerView == 0 ? new Vector3(scale, scale, scale) : new Vector3(scale, -scale, scale));
                            }
                        }
                        else
                        {
                            Debug.LogError("imgWhiteHawk null: " + this);
                        }
                        // blackElephant
                        if (imgBlackElephant != null)
                        {
                            imgBlackElephant.enabled = this.data.blackElephantInHand.v;
                            imgBlackElephant.sprite = SeirawanSpriteContainer.get().getSprite(Common.Piece.B_ELEPHANT);
                            // scale
                            {
                                float scale = 1;
                                if (moveAnimation != null)
                                {
                                    switch (moveAnimation.getType())
                                    {
                                        case GameMove.Type.SeirawanMove:
                                            {
                                                SeirawanMoveAnimation seirawanMoveAnimation = moveAnimation as SeirawanMoveAnimation;
                                                if (Common.is_gating(seirawanMoveAnimation.move.v))
                                                {
                                                    if (Common.gating_type(seirawanMoveAnimation.move.v) == Common.PieceType.ELEPHANT)
                                                    {
                                                        if (color == Common.Color.WHITE)
                                                        {
                                                            if (time >= duration - SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration)
                                                            {
                                                                scale = 1 - MoveAnimation.getAccelerateDecelerateInterpolation(
                                                                    (time - (duration - SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration)) /
                                                                    (SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration));
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown moveAnimation: " + moveAnimation + "; " + this);
                                            break;
                                    }
                                }
                                else
                                {
                                    // Debug.LogError ("moveAnimation null: " + this);
                                }
                                imgBlackElephant.transform.localScale = (playerView == 0 ? new Vector3(scale, scale, scale) : new Vector3(scale, -scale, scale));
                            }
                        }
                        else
                        {
                            Debug.LogError("imgBlackElephant null: " + this);
                        }
                        // blackHawk
                        if (imgBlackHawk != null)
                        {
                            imgBlackHawk.enabled = this.data.blackHawkInHand.v;
                            imgBlackHawk.sprite = SeirawanSpriteContainer.get().getSprite(Common.Piece.B_HAWK);
                            // scale
                            {
                                float scale = 1;
                                if (moveAnimation != null)
                                {
                                    switch (moveAnimation.getType())
                                    {
                                        case GameMove.Type.SeirawanMove:
                                            {
                                                SeirawanMoveAnimation seirawanMoveAnimation = moveAnimation as SeirawanMoveAnimation;
                                                if (Common.is_gating(seirawanMoveAnimation.move.v))
                                                {
                                                    if (Common.gating_type(seirawanMoveAnimation.move.v) == Common.PieceType.HAWK)
                                                    {
                                                        if (color == Common.Color.WHITE)
                                                        {
                                                            if (time >= duration - SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration)
                                                            {
                                                                scale = 1 - MoveAnimation.getAccelerateDecelerateInterpolation(
                                                                    (time - (duration - SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration)) /
                                                                    (SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration));
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown moveAnimation: " + moveAnimation + "; " + this);
                                            break;
                                    }
                                }
                                else
                                {
                                    // Debug.LogError ("moveAnimation null: " + this);
                                }
                                imgBlackHawk.transform.localScale = (playerView == 0 ? new Vector3(scale, scale, scale) : new Vector3(scale, -scale, scale));
                            }
                        }
                        else
                        {
                            Debug.LogError("imgBlackHawk null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("not load full");
                        dirty = true;
                    }
                    // hand
                    {
                        if(whiteHand!=null && blackHand != null)
                        {
                            // find distance
                            float distance = 4.6f;
                            {
                                switch (Setting.get().boardIndex.v)
                                {
                                    case Setting.BoardIndex.None:
                                        break;
                                    case Setting.BoardIndex.InBoard:
                                        break;
                                    case Setting.BoardIndex.OutBoard:
                                        distance = 5.1f;
                                        break;
                                    default:
                                        Debug.LogError("unknown boardIndex: " + Setting.get().boardIndex.v);
                                        break;
                                }
                            }
                            // whiteHand
                            {
                                UIRectTransform rect = new UIRectTransform();
                                {
                                    // anchoredPosition: (4.6, 0.0); anchorMin: (0.5, 0.5); anchorMax: (0.5, 0.5); pivot: (0.5, 0.5);
                                    // offsetMin: (4.1, -4.0); offsetMax: (5.1, 4.0); sizeDelta: (1.0, 8.0);
                                    rect.anchoredPosition = new Vector3(distance, 0.0f, 0.0f);
                                    rect.anchorMin = new Vector2(0.5f, 0.5f);
                                    rect.anchorMax = new Vector2(0.5f, 0.5f);
                                    rect.offsetMin = new Vector2(distance - 0.5f, -4.0f);
                                    rect.offsetMax = new Vector2(distance + 0.5f, 4.0f);
                                    rect.sizeDelta = new Vector2(1.0f, 8.0f);
                                }
                                rect.set(whiteHand);
                            }
                            // blackHand
                            {
                                UIRectTransform rect = new UIRectTransform();
                                {
                                    rect.anchoredPosition = new Vector3(-distance, 0.0f, 0.0f);
                                    rect.anchorMin = new Vector2(0.5f, 0.5f);
                                    rect.anchorMax = new Vector2(0.5f, 0.5f);
                                    rect.offsetMin = new Vector2(-distance + 0.5f, -4.0f);
                                    rect.offsetMax = new Vector2(-distance - 0.5f, 4.0f);
                                    rect.sizeDelta = new Vector2(1.0f, 8.0f);
                                }
                                rect.set(blackHand);
                            }
                        }
                        else
                        {
                            Debug.LogError("whiteHand, blackHand null");
                        }
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

        private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();
        private AnimationManagerCheckChange<UIData> animationManagerCheckChange = new AnimationManagerCheckChange<UIData>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // CheckChange
                {
                    // perspective
                    {
                        perspectiveChange.addCallBack(this);
                        perspectiveChange.setData(uiData);
                    }
                    // animationManager 
                    {
                        animationManagerCheckChange.needTimeChange = true;
                        animationManagerCheckChange.addCallBack(this);
                        animationManagerCheckChange.setData(uiData);
                    }
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
            // CheckChange
            {
                if (data is GameDataBoardCheckPerspectiveChange<UIData>)
                {
                    dirty = true;
                    return;
                }
                if (data is AnimationManagerCheckChange<UIData>)
                {
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
                // CheckChange
                {
                    // perspective
                    {
                        perspectiveChange.removeCallBack(this);
                        perspectiveChange.setData(null);
                    }
                    // animationManager 
                    {
                        animationManagerCheckChange.removeCallBack(this);
                        animationManagerCheckChange.setData(null);
                    }
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if(data is Setting)
            {
                return;
            }
            // CheckChange
            {
                if (data is GameDataBoardCheckPerspectiveChange<UIData>)
                {
                    return;
                }
                if (data is AnimationManagerCheckChange<UIData>)
                {
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
                    case UIData.Property.whiteElephantInHand:
                        dirty = true;
                        break;
                    case UIData.Property.whiteHawkInHand:
                        dirty = true;
                        break;
                    case UIData.Property.blackElephantInHand:
                        dirty = true;
                        break;
                    case UIData.Property.blackHawkInHand:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Setting
            if(wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
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
                    case Setting.Property.defaultChosenGame:
                        break;
                    case Setting.Property.defaultRoomName:
                        break;
                    case Setting.Property.defaultChatRoomStyle:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // CheckChange
            {
                if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>)
                {
                    dirty = true;
                    return;
                }
                if (wrapProperty.p is AnimationManagerCheckChange<UIData>)
                {
                    dirty = true;
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
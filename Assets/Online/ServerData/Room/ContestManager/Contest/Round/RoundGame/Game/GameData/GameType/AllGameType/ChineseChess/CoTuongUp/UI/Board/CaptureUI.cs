using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace CoTuongUp
{
    public class CaptureUI : UIBehavior<CaptureUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<byte> piece;

            #region Constructor

            public enum Property
            {
                piece
            }

            public UIData() : base()
            {
                this.piece = new VP<byte>(this, (byte)Property.piece, Common.x);
            }

            #endregion

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.CO_TUONG_UP ? 1 : 0;
        }

        #region Refresh

        public Image img;

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
                        // parent container
                        {
                            BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData>();
                            if (boardUIData != null)
                            {
                                BoardUI boardUI = boardUIData.findCallBack<BoardUI>();
                                if (boardUI != null)
                                {
                                    if (boardUI.redCaptureContainer != null && boardUI.blackCaptureContainer != null)
                                    {
                                        switch (Common.getPieceSide(this.data.piece.v))
                                        {
                                            case Common.Side.Black:
                                                {
                                                    if (this.transform.parent != boardUI.blackCaptureContainer)
                                                    {
                                                        this.transform.SetParent(boardUI.blackCaptureContainer, false);
                                                    }
                                                }
                                                break;
                                            case Common.Side.Red:
                                            default:
                                                {
                                                    if (this.transform.parent != boardUI.redCaptureContainer)
                                                    {
                                                        this.transform.SetParent(boardUI.redCaptureContainer, false);
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("captureContainer null");
                                    }
                                }
                                else
                                {
                                    Debug.LogError("boardUI null");
                                }
                            }
                            else
                            {
                                Debug.LogError("boardUIData null");
                            }
                        }
                        // img
                        if (img != null)
                        {
                            if (!Common.Visibility.isHide(this.data.piece.v))
                            {
                                img.color = new Color(1f, 1f, 1f, 1f);
                                img.sprite = CoTuongUpSpriteContainer.get().getSprite(this.data.piece.v, Setting.get().style.v);
                            }
                            else
                            {
                                // canView hidden piece?
                                bool canView = false;
                                {
                                    BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData>();
                                    if (boardUIData != null)
                                    {
                                        CoTuongUp coTuongUp = boardUIData.coTuongUp.v.data;
                                        if (coTuongUp != null)
                                        {
                                            if (coTuongUp.allowViewCapture.v)
                                            {
                                                canView = true;
                                            }
                                            else
                                            {
                                                if (coTuongUp.allowWatcherViewHidden.v && boardUIData.isWatcher.v)
                                                {
                                                    canView = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("coTuongUp null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("boardUIData null: " + this);
                                    }
                                }
                                // process
                                if (canView)
                                {
                                    img.color = new Color(1f, 1f, 1f, 0.75f);
                                    img.sprite = CoTuongUpSpriteContainer.get().getSprite(Common.Visibility.flip(this.data.piece.v), Setting.get().style.v);
                                }
                                else
                                {
                                    img.color = new Color(1f, 1f, 1f, 1f);
                                    img.sprite = CoTuongUpSpriteContainer.get().getSprite(this.data.piece.v, Setting.get().style.v);
                                }
                            }
                            // Scale
                            {
                                int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                this.transform.localScale = (playerView == 0 ? new Vector3(1, 1, 1) : new Vector3(1, -1, 1));
                            }
                        }
                        else
                        {
                            Debug.LogError("img null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("not load full");
                        dirty = true;
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

        private BoardUI.UIData boardUIData = null;
        private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // CheckChange
                {
                    perspectiveChange.addCallBack(this);
                    perspectiveChange.setData(uiData);
                }
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.boardUIData);
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
            // Parent
            {
                // BoardUIData
                {
                    if (data is BoardUI.UIData)
                    {
                        BoardUI.UIData boardUIData = data as BoardUI.UIData;
                        {
                            boardUIData.coTuongUp.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    if (data is CoTuongUp)
                    {
                        dirty = true;
                        return;
                    }
                }
                // checkChange
                if (data is GameDataBoardCheckPerspectiveChange<UIData>)
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
                    perspectiveChange.removeCallBack(this);
                    perspectiveChange.setData(null);
                }
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.boardUIData);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Parent
            {
                // BoardUIData
                {
                    if (data is BoardUI.UIData)
                    {
                        BoardUI.UIData boardUIData = data as BoardUI.UIData;
                        {
                            boardUIData.coTuongUp.allRemoveCallBack(this);
                        }
                        return;
                    }
                    if (data is CoTuongUp)
                    {
                        return;
                    }
                }
                // checkChange
                if (data is GameDataBoardCheckPerspectiveChange<UIData>)
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
                    case UIData.Property.piece:
                        dirty = true;
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
                        break;
                    case Setting.Property.style:
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
            // Parent
            {
                // boardUIData
                {
                    if (wrapProperty.p is BoardUI.UIData)
                    {
                        switch ((BoardUI.UIData.Property)wrapProperty.n)
                        {
                            case BoardUI.UIData.Property.coTuongUp:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case BoardUI.UIData.Property.isWatcher:
                                dirty = true;
                                break;
                            case BoardUI.UIData.Property.pieces:
                                break;
                            case BoardUI.UIData.Property.captures:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    if (wrapProperty.p is CoTuongUp)
                    {
                        switch ((CoTuongUp.Property)wrapProperty.n)
                        {
                            case CoTuongUp.Property.allowViewCapture:
                                dirty = true;
                                break;
                            case CoTuongUp.Property.allowWatcherViewHidden:
                                dirty = true;
                                break;
                            case CoTuongUp.Property.allowOnlyFlip:
                                break;
                            case CoTuongUp.Property.turn:
                                break;
                            case CoTuongUp.Property.side:
                                break;
                            case CoTuongUp.Property.nodes:
                                break;
                            case CoTuongUp.Property.plyDraw:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                // Check Change
                if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>)
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
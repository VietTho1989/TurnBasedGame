using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Rule;

namespace CoTuongUp
{
    public class PieceUI : UIBehavior<PieceUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<byte> coord;

            public VP<byte> piece;

            public VP<bool> blindFold;

            #region Constructor

            public enum Property
            {
                coord,
                piece,
                blindFold
            }

            public UIData() : base()
            {
                this.coord = new VP<byte>(this, (byte)Property.coord, 0);
                this.piece = new VP<byte>(this, (byte)Property.piece, Common.x);
                this.blindFold = new VP<bool>(this, (byte)Property.blindFold, false);
            }

            #endregion

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.CO_TUONG_UP ? 32 : 0;
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
                    if (this.data.coord.v >= 0 && this.data.coord.v < 90)
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
                            // Find MoveAnimation
                            MoveAnimation moveAnimation = null;
                            float time = 0;
                            float duration = 0;
                            {
                                GameDataBoardUI.UIData.getCurrentMoveAnimationInfo(this.data, out moveAnimation, out time, out duration);
                            }
                            // image
                            if (img != null)
                            {
                                if (!this.data.blindFold.v)
                                {
                                    img.enabled = true;
                                    // find piece
                                    byte piece = this.data.piece.v;
                                    {
                                        if (moveAnimation != null)
                                        {
                                            switch (moveAnimation.getType())
                                            {
                                                case GameMove.Type.CoTuongUpMove:
                                                    {
                                                        CoTuongUpMoveAnimation coTuongUpMoveAnimation = moveAnimation as CoTuongUpMoveAnimation;
                                                        // Get inform
                                                        Rules.Move move = CoTuongUpMove.getMove(coTuongUpMoveAnimation.move.v);
                                                        byte fromCoord = Common.makeCoord(move.from.x, move.from.y);
                                                        // byte destCoord = Common.makeCoord (move.dest.x, move.dest.y);
                                                        if (fromCoord == this.data.coord.v)
                                                        {
                                                            if (coTuongUpMoveAnimation.isFlipMove())
                                                            {
                                                                float flipDuration = CoTuongUpMoveAnimation.FlipDuration * AnimationManager.DefaultDuration;
                                                                if (duration >= flipDuration)
                                                                {
                                                                    float flipTime = time - (duration - flipDuration);
                                                                    if (flipTime >= 0)
                                                                    {
                                                                        if (flipTime <= flipDuration / 2)
                                                                        {
                                                                            piece = this.data.piece.v;
                                                                        }
                                                                        else
                                                                        {
                                                                            piece = Common.Visibility.flip(this.data.piece.v);
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Debug.LogError("why flipDuration < duration");
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
                                    }
                                    // Process
                                    {
                                        if (!Common.Visibility.isHide(piece))
                                        {
                                            img.color = new Color(1f, 1f, 1f, 1f);
                                            img.sprite = CoTuongUpSpriteContainer.get().getSprite(piece, Setting.get().style.v);
                                        }
                                        else
                                        {
                                            // check canView
                                            bool canView = false;
                                            {
                                                BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData>();
                                                if (boardUIData != null)
                                                {
                                                    canView = boardUIData.isWatcher.v;
                                                }
                                                else
                                                {
                                                    Debug.LogError("boardUIData null: " + this);
                                                }
                                            }
                                            if (canView)
                                            {
                                                img.color = new Color(1f, 1f, 1f, 0.5f);
                                                img.sprite = CoTuongUpSpriteContainer.get().getSprite(Common.Visibility.flip(piece), Setting.get().style.v);
                                            }
                                            else
                                            {
                                                img.color = new Color(1f, 1f, 1f, 1f);
                                                img.sprite = CoTuongUpSpriteContainer.get().getSprite(Common.HK, Setting.get().style.v);// hidden
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    img.enabled = false;
                                }
                            }
                            else
                            {
                                Debug.LogError("img null: " + this);
                            }
                            // Position
                            {
                                Vector3 localPosition = Common.convertCoordToLocalPosition(this.data.coord.v);
                                if (moveAnimation != null)
                                {
                                    switch (moveAnimation.getType())
                                    {
                                        case GameMove.Type.CoTuongUpMove:
                                            {
                                                CoTuongUpMoveAnimation coTuongUpMoveAnimation = moveAnimation as CoTuongUpMoveAnimation;
                                                // Get inform
                                                Rules.Move move = CoTuongUpMove.getMove(coTuongUpMoveAnimation.move.v);
                                                byte fromCoord = Common.makeCoord(move.from.x, move.from.y);
                                                byte destCoord = Common.makeCoord(move.dest.x, move.dest.y);
                                                // Process
                                                if (fromCoord != destCoord)
                                                {
                                                    if (fromCoord == this.data.coord.v)
                                                    {
                                                        this.transform.SetAsLastSibling();
                                                        // find moveDuration
                                                        float moveDuration = duration;
                                                        {
                                                            if (coTuongUpMoveAnimation.isFlipMove())
                                                            {
                                                                float flipDuration = CoTuongUpMoveAnimation.FlipDuration * AnimationManager.DefaultDuration;
                                                                moveDuration = duration - flipDuration;
                                                            }
                                                        }
                                                        // Process
                                                        if (moveDuration > 0)
                                                        {
                                                            Vector3 fromPos = Common.convertCoordToLocalPosition(fromCoord);
                                                            Vector3 destPos = Common.convertCoordToLocalPosition(destCoord);
                                                            localPosition = Vector3.Lerp(fromPos, destPos, MoveAnimation.getAccelerateDecelerateInterpolation(time / moveDuration));
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("moveDuration = 0: " + this);
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

                                }
                                this.transform.localPosition = localPosition;
                            }
                            // Scale
                            {
                                int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                // find localScale
                                float localScale = 1;
                                {
                                    if (moveAnimation != null)
                                    {
                                        switch (moveAnimation.getType())
                                        {
                                            case GameMove.Type.CoTuongUpMove:
                                                {
                                                    CoTuongUpMoveAnimation coTuongUpMoveAnimation = moveAnimation as CoTuongUpMoveAnimation;
                                                    // Get Inform
                                                    Rules.Move move = CoTuongUpMove.getMove(coTuongUpMoveAnimation.move.v);
                                                    byte fromCoord = Common.makeCoord(move.from.x, move.from.y);
                                                    // byte destCoord = Common.makeCoord (move.dest.x, move.dest.y);
                                                    if (fromCoord == this.data.coord.v)
                                                    {
                                                        if (coTuongUpMoveAnimation.isFlipMove())
                                                        {
                                                            float flipDuration = CoTuongUpMoveAnimation.FlipDuration * AnimationManager.DefaultDuration;
                                                            if (duration >= flipDuration)
                                                            {
                                                                float flipTime = time - (duration - flipDuration);
                                                                if (flipTime > 0)
                                                                {
                                                                    if (flipTime < flipDuration / 2)
                                                                    {
                                                                        localScale = 1 - MoveAnimation.getAccelerateDecelerateInterpolation(flipTime / (flipDuration / 2));
                                                                    }
                                                                    else
                                                                    {
                                                                        localScale = MoveAnimation.getAccelerateDecelerateInterpolation((flipTime - (flipDuration / 2)) / (flipDuration / 2));
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Debug.LogError("why flipDuration < duration");
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
                                }
                                this.transform.localScale = (playerView == 0 ? new Vector3(localScale, localScale, 1) : new Vector3(localScale, -localScale, 1));
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
                        // outside board
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
            // checkChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Parent
            if (data is BoardUI.UIData)
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
            // checkChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                return;
            }
            // Parent
            if (data is BoardUI.UIData)
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
                    case UIData.Property.coord:
                        dirty = true;
                        break;
                    case UIData.Property.piece:
                        dirty = true;
                        break;
                    case UIData.Property.blindFold:
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
            // Check Change
            if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                if (wrapProperty.p is BoardUI.UIData)
                {
                    switch ((BoardUI.UIData.Property)wrapProperty.n)
                    {
                        case BoardUI.UIData.Property.coTuongUp:
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
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
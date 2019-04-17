using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
    public class PieceUI : UIBehavior<PieceUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<int> coord;

            public VP<Common.stone> stone;

            public VP<bool> isDead;

            public VP<int> owner;

            public VP<int> lastMove;

            public VP<bool> blindFold;

            #region Constructor

            public enum Property
            {
                coord,
                stone,
                isDead,
                owner,
                lastMove,
                blindFold
            }

            public UIData() : base()
            {
                this.coord = new VP<int>(this, (byte)Property.coord, 0);
                this.stone = new VP<Common.stone>(this, (byte)Property.stone, Common.stone.S_NONE);
                this.isDead = new VP<bool>(this, (byte)Property.isDead, false);
                this.owner = new VP<int>(this, (byte)Property.owner, 0);
                this.lastMove = new VP<int>(this, (byte)Property.lastMove, -1);
                this.blindFold = new VP<bool>(this, (byte)Property.blindFold, false);
            }

            #endregion

        }

        #endregion

        #region Refresh

        public Image imgStone;

        public Image imgScore;

        public Text tvLastMove;
        public Image imgLastMove;

        public Image imgDead;

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
                        // weiqi
                        if (isLoadFull)
                        {
                            BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData>();
                            if (boardUIData != null)
                            {
                                Weiqi weiqi = boardUIData.weiqi.v.data;
                                if (weiqi != null)
                                {
                                    Board board = weiqi.b.v;
                                    if (board != null)
                                    {
                                        if (board.b.vs.Count == 0)
                                        {
                                            isLoadFull = false;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("board null");
                                        isLoadFull = false;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("weiqi null");
                                }
                            }
                            else
                            {
                                Debug.LogError("boardUIData null");
                            }
                        }
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
                        // active or not
                        bool isActive = true;
                        {
                            if (this.data.coord.v >= 0)
                            {
                                isActive = true;
                            }
                            else
                            {
                                isActive = false;
                            }
                        }
                        // Process
                        if (isActive)
                        {
                            // Get BoardSize
                            int boardSize = 21;
                            {
                                BoardUI.UIData boardUI = this.data.findDataInParent<BoardUI.UIData>();
                                if (boardUI != null)
                                {
                                    boardSize = boardUI.boardSize.v;
                                }
                                else
                                {
                                    Debug.LogError("boardUI null: " + this);
                                }
                            }
                            // get mode
                            BoardUI.UIData.Mode mode = BoardUI.UIData.Mode.Normal;
                            {
                                BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData>();
                                if (boardUIData != null)
                                {
                                    mode = boardUIData.mode.v;
                                }
                                else
                                {
                                    Debug.LogError("boardUIData null: " + this);
                                }
                                // Debug.Log ("mode: " + mode + "; " + this);
                            }

                            // position
                            {
                                // Debug.Log ("pieceUI: boardSize: " + boardSize);
                                // Set Position
                                if (boardSize > 0)
                                {
                                    int x = Common.coord_x(boardSize, this.data.coord.v);
                                    int y = Common.coord_y(boardSize, this.data.coord.v);
                                    this.transform.localPosition = new Vector3(x + 0.5f - boardSize / 2.0f, y + 0.5f - boardSize / 2.0f, 0);
                                }
                                else
                                {
                                    Debug.LogError("error, why boardSize <=0: " + boardSize);
                                }
                            }
                            // Name
                            {
                                if (this.data.coord.v >= 0)
                                {
                                    string strCoord = Common.coordToString(this.data.coord.v, boardSize);
                                    this.gameObject.name = "PieceUI: " + strCoord + "; " + this.data.coord;
                                }
                                else
                                {
                                    this.gameObject.name = "PieceUI: None";
                                }
                            }
                            // image stone
                            {
                                if (imgStone != null)
                                {
                                    if (!this.data.blindFold.v)
                                    {
                                        imgStone.enabled = true;
                                        // sprite
                                        imgStone.sprite = WeiqiSpriteContainer.get().getSprite(this.data.stone.v);
                                        // alpha
                                        float alpha = 0.4f;
                                        switch (mode)
                                        {
                                            case BoardUI.UIData.Mode.Normal:
                                                {
                                                    this.imgStone.color = new Color(1f, 1f, 1f, 1f);
                                                }
                                                break;
                                            case BoardUI.UIData.Mode.Score:
                                                {
                                                    switch (this.data.owner.v)
                                                    {
                                                        case 1:
                                                            // black
                                                            {
                                                                if (this.data.stone.v == Common.stone.S_BLACK)
                                                                {
                                                                    this.imgStone.color = new Color(1f, 1f, 1f, 1f);
                                                                }
                                                                else if (this.data.stone.v == Common.stone.S_WHITE)
                                                                {
                                                                    this.imgStone.color = new Color(1f, 1f, 1f, alpha);
                                                                }
                                                                else
                                                                {
                                                                    this.imgStone.color = new Color(1f, 1f, 1f, 0);
                                                                }
                                                            }
                                                            break;
                                                        case 2:
                                                            // white
                                                            {
                                                                if (this.data.stone.v == Common.stone.S_BLACK)
                                                                {
                                                                    this.imgStone.color = new Color(1f, 1f, 1f, alpha);
                                                                }
                                                                else if (this.data.stone.v == Common.stone.S_WHITE)
                                                                {
                                                                    this.imgStone.color = new Color(1f, 1f, 1f, 1f);
                                                                }
                                                                else
                                                                {
                                                                    this.imgStone.color = new Color(1f, 1f, 1f, 0);
                                                                }
                                                            }
                                                            break;
                                                        default:
                                                            this.imgStone.color = new Color(1f, 1f, 1f, 0f);
                                                            break;
                                                    }
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown mode: " + mode + "; " + this);
                                                break;
                                        }
                                        // Scale
                                        {
                                            int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                            imgStone.transform.localScale = (playerView == 0 ? new Vector3(1, 1, 1) : new Vector3(1, -1, 1));
                                        }
                                    }
                                    else
                                    {
                                        imgStone.enabled = false;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("image null: " + this);
                                }
                            }
                            // owner
                            {
                                if (imgScore != null)
                                {
                                    if (!this.data.blindFold.v)
                                    {
                                        imgScore.enabled = true;
                                        // sprite
                                        {
                                            Common.stone stone = Common.stone.S_BLACK;
                                            switch (this.data.owner.v)
                                            {
                                                case 1:
                                                    // black
                                                    stone = Common.stone.S_BLACK;
                                                    break;
                                                case 2:
                                                    // white
                                                    stone = Common.stone.S_WHITE;
                                                    break;
                                                default:
                                                    stone = Common.stone.S_NONE;
                                                    break;
                                            }
                                            imgScore.sprite = WeiqiSpriteContainer.get().getSprite(stone);
                                        }
                                        // alpha
                                        {
                                            switch (mode)
                                            {
                                                case BoardUI.UIData.Mode.Normal:
                                                    this.imgScore.color = new Color(1f, 1f, 1f, 0f);
                                                    break;
                                                case BoardUI.UIData.Mode.Score:
                                                    {
                                                        if ((this.data.owner.v == 1 && this.data.stone.v == Common.stone.S_BLACK) || (this.data.owner.v == 2 && this.data.stone.v == Common.stone.S_WHITE))
                                                        {
                                                            this.imgScore.color = new Color(1f, 1f, 1f, 0f);
                                                        }
                                                        else
                                                        {
                                                            this.imgScore.color = new Color(1f, 1f, 1f, 1f);
                                                        }
                                                    }
                                                    break;
                                                default:
                                                    Debug.LogError("unknown mode: " + mode + "; " + this);
                                                    break;
                                            }
                                        }
                                        // Scale
                                        {
                                            int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                            imgScore.transform.localScale = (playerView == 0 ? new Vector3(1, 1, 1) : new Vector3(1, -1, 1));
                                        }
                                    }
                                    else
                                    {
                                        imgScore.enabled = false;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("imgScore null: " + this);
                                }
                            }
                            // last 
                            {
                                if (tvLastMove != null)
                                {
                                    if (!this.data.blindFold.v)
                                    {
                                        // text
                                        if (this.data.lastMove.v >= 1 && this.data.lastMove.v <= 4)
                                        {
                                            tvLastMove.text = "" + this.data.lastMove.v;
                                        }
                                        else
                                        {
                                            tvLastMove.text = "";
                                        }
                                        // color
                                        {
                                            if (this.data.stone.v == Common.stone.S_BLACK)
                                            {
                                                tvLastMove.color = Color.white;
                                            }
                                            else if (this.data.stone.v == Common.stone.S_WHITE)
                                            {
                                                tvLastMove.color = Color.black;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        tvLastMove.text = "";
                                    }
                                }
                                else
                                {
                                    Debug.LogError("tvLastMove null: " + this);
                                }
                                if (imgLastMove != null)
                                {
                                    if (!this.data.blindFold.v)
                                    {
                                        if (this.data.lastMove.v == 1)
                                        {
                                            imgLastMove.enabled = true;
                                        }
                                        else
                                        {
                                            imgLastMove.enabled = false;
                                        }
                                        // Scale
                                        {
                                            int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                            imgLastMove.transform.localScale = (playerView == 0 ? new Vector3(1, 1, 1) : new Vector3(1, -1, 1));
                                        }
                                    }
                                    else
                                    {
                                        imgLastMove.enabled = false;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("imgLastMove null: " + this);
                                }
                            }
                            // deadGroup
                            {
                                if (imgDead != null)
                                {
                                    if (!this.data.blindFold.v)
                                    {
                                        if (this.data.stone.v == Common.stone.S_BLACK || this.data.stone.v == Common.stone.S_WHITE)
                                        {
                                            switch (mode)
                                            {
                                                case BoardUI.UIData.Mode.Normal:
                                                    {
                                                        if (this.data.isDead.v)
                                                        {
                                                            imgDead.enabled = true;
                                                        }
                                                        else
                                                        {
                                                            imgDead.enabled = false;
                                                        }
                                                    }
                                                    break;
                                                case BoardUI.UIData.Mode.Score:
                                                    {
                                                        imgDead.enabled = false;
                                                    }
                                                    break;
                                                default:
                                                    Debug.LogError("unknown mode: " + mode + "; " + this);
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            imgDead.enabled = false;
                                        }
                                        // Scale
                                        {
                                            int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                            imgDead.transform.localScale = (playerView == 0 ? new Vector3(1, 1, 1) : new Vector3(1, -1, 1));
                                        }
                                    }
                                    else
                                    {
                                        imgDead.enabled = false;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("imgDead null: " + this);
                                }
                            }
                            // Scale
                            {
                                // localScale
                                float localScale = 1;
                                {
                                    if (moveAnimation != null)
                                    {
                                        switch (moveAnimation.getType())
                                        {
                                            case GameMove.Type.WeiqiMove:
                                                {
                                                    WeiqiMoveAnimation weiqiMoveAnimation = moveAnimation as WeiqiMoveAnimation;
                                                    // find scale
                                                    if (weiqiMoveAnimation.coord.v == this.data.coord.v)
                                                    {
                                                        if (duration > 0)
                                                        {
                                                            if (time <= WeiqiMoveAnimation.AppearDuration * AnimationManager.DefaultDuration)
                                                            {
                                                                localScale = MoveAnimation.getAccelerateDecelerateInterpolation(time / (WeiqiMoveAnimation.AppearDuration * AnimationManager.DefaultDuration));
                                                            }
                                                            else
                                                            {
                                                                if (weiqiMoveAnimation.captureCoords.vs.Contains(this.data.coord.v))
                                                                {
                                                                    if (time >= (WeiqiMoveAnimation.AppearDuration + WeiqiMoveAnimation.StandDuration) * AnimationManager.DefaultDuration)
                                                                    {
                                                                        localScale = 1 - MoveAnimation.getAccelerateDecelerateInterpolation(
                                                                            (time - (WeiqiMoveAnimation.AppearDuration + WeiqiMoveAnimation.StandDuration) * AnimationManager.DefaultDuration)
                                                                            / (WeiqiMoveAnimation.CaptureDuration * AnimationManager.DefaultDuration));
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            localScale = 0;
                                                        }
                                                    }
                                                    else if (weiqiMoveAnimation.captureCoords.vs.Contains(this.data.coord.v))
                                                    {
                                                        if (duration > 0)
                                                        {
                                                            if (time >= (WeiqiMoveAnimation.AppearDuration + WeiqiMoveAnimation.StandDuration) * AnimationManager.DefaultDuration)
                                                            {
                                                                localScale = 1 - MoveAnimation.getAccelerateDecelerateInterpolation(
                                                                    (time - (WeiqiMoveAnimation.AppearDuration + WeiqiMoveAnimation.StandDuration) * AnimationManager.DefaultDuration)
                                                                    / (WeiqiMoveAnimation.CaptureDuration * AnimationManager.DefaultDuration));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            localScale = 1;
                                                        }
                                                    }
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                this.transform.localScale = new Vector3(localScale, localScale, 1);
                            }
                        }
                        else
                        {

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
                    // Debug.Log ("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        private BoardUI.UIData boardUI = null;
        private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // CheckChange
                {
                    perspectiveChange.addCallBack(this);
                    perspectiveChange.setData(uiData);
                }
                // parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.boardUI);
                }
                dirty = true;
                return;
            }
            // checkChange
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
                // CheckChange
                {
                    perspectiveChange.removeCallBack(this);
                    perspectiveChange.setData(null);
                }
                // parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.boardUI);
                }
                this.setDataNull(uiData);
                return;
            }
            // checkChange
            {
                if (data is GameDataBoardCheckPerspectiveChange<UIData>)
                {
                    return;
                }
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
                    case UIData.Property.stone:
                        dirty = true;
                        break;
                    case UIData.Property.isDead:
                        dirty = true;
                        break;
                    case UIData.Property.owner:
                        dirty = true;
                        break;
                    case UIData.Property.lastMove:
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
            // Check Change
            if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Parent
            if (wrapProperty.p is BoardUI.UIData)
            {
                switch ((BoardUI.UIData.Property)wrapProperty.n)
                {
                    case BoardUI.UIData.Property.weiqi:
                        break;
                    case BoardUI.UIData.Property.background:
                        break;
                    case BoardUI.UIData.Property.mode:
                        dirty = true;
                        break;
                    case BoardUI.UIData.Property.boardSize:
                        dirty = true;
                        break;
                    case BoardUI.UIData.Property.pieces:
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
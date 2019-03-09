using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
    public class PieceUI : UIBehavior<PieceUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<int> x;

            public VP<int> y;

            public VP<sbyte> piece;

            public VP<sbyte> bomb;

            public VP<sbyte> flag;

            #region Constructor

            public enum Property
            {
                x,
                y,
                piece,
                bomb,
                flag
            }

            public UIData() : base()
            {
                this.x = new VP<int>(this, (byte)Property.x, 0);
                this.y = new VP<int>(this, (byte)Property.y, 0);
                this.piece = new VP<sbyte>(this, (byte)Property.piece, 0);
                this.bomb = new VP<sbyte>(this, (byte)Property.bomb, 0);
                this.flag = new VP<sbyte>(this, (byte)Property.flag, 0);
            }

            #endregion

        }

        #endregion

        #region Refresh

        public GameObject piece;
        public Text tvPiece;

        public Image imgBomb;
        public GameObject flag;

        private readonly Color alphaColor = new Color(1, 1, 1, 0.5f);

        #region color

        private static readonly Color color1 = new Color(2 / 255f, 32 / 255f, 254 / 255f);
        private static readonly Color color2 = new Color(17 / 255f, 112 / 255f, 12 / 255f);
        private static readonly Color color3 = new Color(255 / 255f, 24 / 255f, 42 / 255f);
        private static readonly Color color4 = new Color(2 / 255f, 12 / 255f, 127 / 255f);
        private static readonly Color color5 = new Color(124 / 255f, 0 / 255f, 0 / 255f);

        #endregion

        private static readonly Color bombColor = new Color(230/255f, 68/255f, 43/255f);

        public Sprite emptySprite;
        public Sprite revealSprite;
        public Image background;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    if (this.data.x.v >= 0 && this.data.y.v >= 0)
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
                            // piece
                            {
                                if (piece != null)
                                {
                                    if (this.data.bomb.v == 0)
                                    {
                                        if (this.data.piece.v == -1)
                                        {
                                            // not set
                                            piece.SetActive(false);
                                        }
                                        else
                                        {
                                            // already set
                                            piece.SetActive(true);
                                            // tvPiece
                                            if (tvPiece != null)
                                            {
                                                tvPiece.text = (this.data.piece.v == 0) ? "" : "" + this.data.piece.v;
                                                // color
                                                switch (this.data.piece.v)
                                                {
                                                    case 1:
                                                        tvPiece.color = color1;
                                                        break;
                                                    case 2:
                                                        tvPiece.color = color2;
                                                        break;
                                                    case 3:
                                                        tvPiece.color = color3;
                                                        break;
                                                    case 4:
                                                        tvPiece.color = color4;
                                                        break;
                                                    case 5:
                                                        tvPiece.color = color5;
                                                        break;
                                                    default:
                                                        // Debug.LogError("unknown piece: " + this.data.piece.v);
                                                        tvPiece.color = color1;
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("tvPiece null: " + this);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // have bomb
                                        piece.SetActive(false);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("piece null: " + this);
                                }
                            }
                            // bomb
                            {
                                if (imgBomb != null)
                                {
                                    if (this.data.bomb.v != 0)
                                    {
                                        // check is booom
                                        bool isBooom = false;
                                        bool canWatchBomb = false;
                                        {
                                            BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData>();
                                            if (boardUIData != null)
                                            {
                                                isBooom = boardUIData.booom.v;
                                                canWatchBomb = boardUIData.allowWatchBomb.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("boardUIData null: " + this);
                                            }
                                        }
                                        // Process
                                        if (isBooom)
                                        {
                                            imgBomb.gameObject.SetActive(true);
                                            imgBomb.color = Color.white;
                                        }
                                        else
                                        {
                                            if (canWatchBomb)
                                            {
                                                imgBomb.gameObject.SetActive(true);
                                                imgBomb.color = alphaColor;
                                            }
                                            else
                                            {
                                                imgBomb.gameObject.SetActive(false);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        imgBomb.gameObject.SetActive(false);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("bomb null: " + this);
                                }
                            }
                            // flag
                            {
                                if (flag != null)
                                {
                                    // TODO Cu an het da
                                    flag.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("flag null: " + this);
                                }
                            }
                            // LocalPosition
                            {
                                BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData>();
                                if (boardUIData != null)
                                {
                                    this.transform.localPosition = Common.converPosToLocalPosition(this.data.x.v, this.data.y.v, boardUIData);
                                }
                                else
                                {
                                    Debug.LogError("boardUIData null: " + this);
                                }
                            }
                            // Scale: co le ko can
                            /*{
								int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
								this.transform.localScale = (playerView == 0 ? new Vector3 (1f, 1f, 1f) : new Vector3 (1f, -1f, 1f));
							}*/
                        }
                        else
                        {
                            Debug.LogError("not load full");
                            dirty = true;
                        }
                    }
                    else
                    {
                        // contentContainer
                    }
                    // background
                    {
                        if (background != null && imgBomb != null && piece != null)
                        {
                            if (!imgBomb.gameObject.activeSelf && !piece.gameObject.activeSelf)
                            {
                                background.color = Color.white;
                                background.sprite = emptySprite;
                            }
                            else
                            {
                                if (piece.gameObject.activeSelf)
                                {
                                    background.color = Color.white;
                                    background.sprite = revealSprite;
                                }
                                else
                                {
                                    if (imgBomb.color == Color.white)
                                    {
                                        background.color = bombColor;
                                        background.sprite = null;
                                    }
                                    else
                                    {
                                        background.color = Color.white;
                                        background.sprite = emptySprite;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("background null");
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

        private BoardUI.UIData boardUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.boardUIData);
                }
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.boardUIData);
                }
                this.setDataNull(uiData);
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
                    case UIData.Property.x:
                        dirty = true;
                        break;
                    case UIData.Property.y:
                        dirty = true;
                        break;
                    case UIData.Property.piece:
                        dirty = true;
                        break;
                    case UIData.Property.bomb:
                        dirty = true;
                        break;
                    case UIData.Property.flag:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Parent
            if (wrapProperty.p is BoardUI.UIData)
            {
                switch ((BoardUI.UIData.Property)wrapProperty.n)
                {
                    case BoardUI.UIData.Property.mineSweeper:
                        break;
                    case BoardUI.UIData.Property.pieces:
                        break;
                    case BoardUI.UIData.Property.booom:
                        dirty = true;
                        break;
                    case BoardUI.UIData.Property.allowWatchBomb:
                        dirty = true;
                        break;
                    case BoardUI.UIData.Property.maxWidth:
                        dirty = true;
                        break;
                    case BoardUI.UIData.Property.maxHeight:
                        dirty = true;
                        break;
                    case BoardUI.UIData.Property.x:
                        dirty = true;
                        break;
                    case BoardUI.UIData.Property.y:
                        dirty = true;
                        break;
                    case BoardUI.UIData.Property.width:
                        dirty = true;
                        break;
                    case BoardUI.UIData.Property.height:
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
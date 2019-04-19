using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BoardIndexUI : UIBehavior<BoardIndexUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<GameType.Type> gameType;

        #region Type

        public enum Type
        {
            InBoard,
            X,
            Y
        }

        public VP<Type> type;

        #endregion

        public VP<int> index;

        public VP<int> playerView;

        #region Constructor

        public enum Property
        {
            gameType,
            type,
            index,
            playerView
        }

        public UIData() : base()
        {
            this.gameType = new VP<GameType.Type>(this, (byte)Property.gameType, GameType.Type.CHESS);
            this.type = new VP<Type>(this, (byte)Property.type, Type.InBoard);
            this.index = new VP<int>(this, (byte)Property.index, 0);
            this.playerView = new VP<int>(this, (byte)Property.playerView, 0);
        }

        #endregion

    }

    #endregion

    public const float DefaultScale = 100;

    #region Refresh

    public Text tvContent;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                if (tvContent != null)
                {
                    // find
                    Color color = Color.black;
                    Vector3 localPosition = Vector3.zero;
                    string text = "" + this.data.index.v;
                    int fontSize = 25;
                    float uiSize = 25;
                    {
                        switch (this.data.gameType.v)
                        {
                            case GameType.Type.CHESS:
                            case GameType.Type.Shatranj:
                            case GameType.Type.Makruk:
                            case GameType.Type.Seirawan:
                            case GameType.Type.FairyChess:
                                {
                                    switch (this.data.type.v)
                                    {
                                        case UIData.Type.InBoard:
                                            {
                                                int x = this.data.index.v % 8;
                                                int y = this.data.index.v / 8;
                                                // text
                                                {
                                                    if(this.data.index.v>=0 && this.data.index.v < 64)
                                                    {
                                                        text = Chess.Common.squareToString((Chess.Common.Square)this.data.index.v);
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("index error: " + this.data.index.v);
                                                    }
                                                }
                                                // localPosition
                                                {
                                                    // find pos
                                                    Vector3 pos = Vector3.zero;
                                                    {
                                                        pos = Chess.Common.convertXYToLocalPosition(x, y);
                                                    }
                                                    // process
                                                    if (this.data.playerView.v == 0)
                                                    {
                                                        localPosition = pos * DefaultScale + new Vector3(-30, 30, 0);
                                                    }
                                                    else
                                                    {
                                                        localPosition = pos * DefaultScale + new Vector3(-30, -30, 0);
                                                    }
                                                }
                                                // color
                                                color = Color.black;
                                            }
                                            break;
                                        case UIData.Type.X:
                                            {
                                                // text
                                                {
                                                    text = "" + (char)('a' + (int)(this.data.index.v % 8));
                                                }
                                                // localPosition
                                                {
                                                    // find pos
                                                    Vector3 pos = Vector3.zero;
                                                    {
                                                        if (this.data.index.v < 8)
                                                        {
                                                            pos = Chess.Common.convertXYToLocalPosition(this.data.index.v, 0);
                                                        }
                                                        else
                                                        {
                                                            pos = Chess.Common.convertXYToLocalPosition(this.data.index.v - 8, 7);
                                                        }
                                                    }
                                                    // process
                                                    {
                                                        // find distance
                                                        float distance = 75;
                                                        {
                                                            if (this.data.gameType.v == GameType.Type.Shatranj || this.data.gameType.v == GameType.Type.Makruk)
                                                            {
                                                                if (Setting.get().style.v == Setting.Style.Normal)
                                                                {
                                                                    distance = 125;
                                                                }
                                                            }
                                                        }
                                                        // process
                                                        if (this.data.index.v < 8)
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(0, -distance, 0);
                                                        }
                                                        else
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(0, distance, 0);
                                                        }
                                                    }
                                                }
                                                // color
                                                color = Color.black;
                                                // fontSize
                                                fontSize = 36;
                                            }
                                            break;
                                        case UIData.Type.Y:
                                            {
                                                // text
                                                {
                                                    text = "" + ((this.data.index.v % 8) + 1);
                                                }
                                                // localPosition
                                                {
                                                    // find pos
                                                    Vector3 pos = Vector3.zero;
                                                    {
                                                        if (this.data.index.v < 8)
                                                        {
                                                            pos = Chess.Common.convertXYToLocalPosition(0, this.data.index.v);
                                                        }
                                                        else
                                                        {
                                                            pos = Chess.Common.convertXYToLocalPosition(7, this.data.index.v - 8);
                                                        }
                                                    }
                                                    // process
                                                    {
                                                        // find distance
                                                        float distance = 75;
                                                        {
                                                            if (this.data.gameType.v == GameType.Type.Shatranj || this.data.gameType.v == GameType.Type.Makruk)
                                                            {
                                                                if (Setting.get().style.v == Setting.Style.Normal)
                                                                {
                                                                    distance = 125;
                                                                }
                                                            }
                                                        }
                                                        // process
                                                        if (this.data.index.v < 8)
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(-distance, 0, 0);
                                                        }
                                                        else
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(distance, 0, 0);
                                                        }
                                                    }
                                                }
                                                // color
                                                color = Color.black;
                                                // fontSize
                                                fontSize = 36;
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + this.data.type.v);
                                            break;
                                    }
                                }
                                break;
                            case GameType.Type.Weiqi:
                                break;
                            case GameType.Type.SHOGI:
                                break;
                            case GameType.Type.Reversi:
                                break;
                            case GameType.Type.Xiangqi:
                                break;
                            case GameType.Type.CO_TUONG_UP:
                                break;
                            case GameType.Type.Janggi:
                                break;
                            case GameType.Type.Banqi:
                                break;
                            case GameType.Type.Gomoku:
                                break;
                            case GameType.Type.InternationalDraught:
                                break;
                            case GameType.Type.EnglishDraught:
                                break;
                            case GameType.Type.RussianDraught:
                                break;
                            case GameType.Type.ChineseCheckers:
                                break;
                            case GameType.Type.MineSweeper:
                                break;
                            case GameType.Type.Hex:
                                break;
                            case GameType.Type.Solitaire:
                                break;
                            case GameType.Type.Sudoku:
                                break;
                            case GameType.Type.Khet:
                                break;
                            case GameType.Type.NineMenMorris:
                                break;
                            default:
                                Debug.LogError("unknown gameType: " + this.data.gameType.v);
                                break;
                        }
                    }
                    // process
                    {
                        tvContent.text = text;
                        tvContent.color = color;
                        tvContent.transform.localPosition = localPosition;
                    }
                    // playerView
                    {
                        if (this.data.playerView.v == 0)
                        {
                            tvContent.transform.localScale = new Vector3(1, 1, 1);
                        }
                        else
                        {
                            tvContent.transform.localScale = new Vector3(1, -1, 1);
                        }
                    }
                    // textSize
                    tvContent.fontSize = fontSize;
                    // uiSize
                    tvContent.rectTransform.sizeDelta = new Vector2(uiSize, uiSize);
                }
                else
                {
                    Debug.LogError("tvContent null");
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

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            // Setting
            Setting.get().addCallBack(this);
            dirty = true;
            return;
        }
        // Setting
        if(data is Setting)
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
            // Setting
            Setting.get().removeCallBack(this);
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if(data is Setting)
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
        if(wrapProperty.p is UIData)
        {
            switch ((UIData.Property)wrapProperty.n)
            {
                case UIData.Property.gameType:
                    dirty = true;
                    break;
                case UIData.Property.type:
                    dirty = true;
                    break;
                case UIData.Property.index:
                    dirty = true;
                    break;
                case UIData.Property.playerView:
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
                    dirty = true;
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
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
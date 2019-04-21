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
                            case GameType.Type.SHOGI:
                                {
                                    // text
                                    {
                                        switch (this.data.type.v)
                                        {
                                            case UIData.Type.InBoard:
                                                {
                                                    int x = this.data.index.v % 9;
                                                    int y = this.data.index.v / 9;
                                                    text = ((x % 9) + 1) + "" + ((y % 9) + 1);
                                                }
                                                break;
                                            case UIData.Type.X:
                                                text = "" + ((8 - this.data.index.v % 9) + 1);
                                                break;
                                            case UIData.Type.Y:
                                                text = "" + ((8 - this.data.index.v % 9) + 1);
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + this.data.type.v);
                                                break;
                                        }
                                    }
                                    // localPosition
                                    {
                                        switch (this.data.type.v)
                                        {
                                            case UIData.Type.InBoard:
                                                {
                                                    // find pos
                                                    Vector3 pos = Vector3.zero;
                                                    {
                                                        pos = Shogi.Common.convertSquareToLocalPosition((Shogi.Common.Square)this.data.index.v);
                                                    }
                                                    // process
                                                    {
                                                        // find distance
                                                        float distance = 30;
                                                        // process
                                                        if (this.data.playerView.v == 0)
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(-distance, distance, 0);
                                                        }
                                                        else
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(-distance, -distance, 0);
                                                        }
                                                    }
                                                }
                                                break;
                                            case UIData.Type.X:
                                                {
                                                    float distance = 90;
                                                    if (this.data.index.v < 9)
                                                    {
                                                        Vector3 pos = new Vector3(this.data.index.v % 9 - 4.0f, -4.0f);
                                                        localPosition = pos * DefaultScale + new Vector3(0, -distance, 0);
                                                    }
                                                    else
                                                    {
                                                        Vector3 pos = new Vector3(this.data.index.v % 9 - 4.0f, +4.0f);
                                                        localPosition = pos * DefaultScale + new Vector3(0, distance, 0);
                                                    }
                                                }
                                                break;
                                            case UIData.Type.Y:
                                                {
                                                    float distance = 90;
                                                    if (this.data.index.v < 9)
                                                    {
                                                        Vector3 pos = new Vector3(-4.0f, this.data.index.v % 9 - 4.0f);
                                                        localPosition = pos * DefaultScale + new Vector3(-distance, 0, 0);
                                                    }
                                                    else
                                                    {
                                                        Vector3 pos = new Vector3(+4.0f, this.data.index.v % 9 - 4.0f);
                                                        localPosition = pos * DefaultScale + new Vector3(distance, 0, 0);
                                                    }
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + this.data.type.v);
                                                break;
                                        }
                                    }
                                    // color
                                    color = Color.black;
                                    // fontSize
                                    {
                                        switch (this.data.type.v)
                                        {
                                            case UIData.Type.InBoard:
                                                fontSize = 25;
                                                break;
                                            case UIData.Type.X:
                                            case UIData.Type.Y:
                                                fontSize = 45;
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + this.data.type.v);
                                                break;
                                        }
                                    }
                                }
                                break;
                            case GameType.Type.Reversi:
                                {
                                    // text
                                    {
                                        switch (this.data.type.v)
                                        {
                                            case UIData.Type.InBoard:
                                                {
                                                    int x = this.data.index.v % 8;
                                                    int y = this.data.index.v / 8;
                                                    text = (char)('a' + x) + "" + (y + 1);
                                                }
                                                break;
                                            case UIData.Type.X:
                                                text = "" + (char)('a' + (int)(this.data.index.v % 8));
                                                break;
                                            case UIData.Type.Y:
                                                text = "" + ((7 - this.data.index.v % 8) + 1);
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + this.data.type.v);
                                                break;
                                        }
                                    }
                                    // localPosition
                                    {
                                        switch (this.data.type.v)
                                        {
                                            case UIData.Type.InBoard:
                                                {
                                                    // find pos
                                                    Vector3 pos = Vector3.zero;
                                                    {
                                                        pos = Reversi.Common.convertSquareToLocalPosition(this.data.index.v);
                                                    }
                                                    // process
                                                    {
                                                        // find distance
                                                        float distance = 30;
                                                        // process
                                                        if (this.data.playerView.v == 0)
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(-distance, distance, 0);
                                                        }
                                                        else
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(-distance, -distance, 0);
                                                        }
                                                    }
                                                }
                                                break;
                                            case UIData.Type.X:
                                                {
                                                    float distance = 75;
                                                    if (this.data.index.v < 8)
                                                    {
                                                        Vector3 pos = new Vector3(this.data.index.v % 8 - 3.5f, -3.5f);
                                                        localPosition = pos * DefaultScale + new Vector3(0, -distance, 0);
                                                    }
                                                    else
                                                    {
                                                        Vector3 pos = new Vector3(this.data.index.v % 8 - 3.5f, +3.5f);
                                                        localPosition = pos * DefaultScale + new Vector3(0, distance, 0);
                                                    }
                                                }
                                                break;
                                            case UIData.Type.Y:
                                                {
                                                    float distance = 75;
                                                    if (this.data.index.v < 8)
                                                    {
                                                        Vector3 pos = new Vector3(-3.5f, this.data.index.v % 8 - 3.5f);
                                                        localPosition = pos * DefaultScale + new Vector3(-distance, 0, 0);
                                                    }
                                                    else
                                                    {
                                                        Vector3 pos = new Vector3(+3.5f, this.data.index.v % 8 - 3.5f);
                                                        localPosition = pos * DefaultScale + new Vector3(distance, 0, 0);
                                                    }
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + this.data.type.v);
                                                break;
                                        }
                                    }
                                    // color
                                    color = Color.black;
                                    // fontSize
                                    {
                                        switch (this.data.type.v)
                                        {
                                            case UIData.Type.InBoard:
                                                fontSize = 25;
                                                break;
                                            case UIData.Type.X:
                                            case UIData.Type.Y:
                                                fontSize = 36;
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + this.data.type.v);
                                                break;
                                        }
                                    }
                                }
                                break;
                            case GameType.Type.Xiangqi:
                            case GameType.Type.CO_TUONG_UP:
                            case GameType.Type.Janggi:
                                {
                                    switch (this.data.type.v)
                                    {
                                        case UIData.Type.InBoard:
                                            {
                                                int x = this.data.index.v % 9;
                                                int y = this.data.index.v / 9;
                                                // Debug.LogError("xiangqi boardIndex: " + x + ", " + y + ", " + this.data.index.v);
                                                // text
                                                {
                                                    if (this.data.index.v >= 0 && this.data.index.v < 90)
                                                    {
                                                        text = (char)('a' + (int)(x)) + "" + y;
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
                                                        pos = Xiangqi.Common.convertXYToLocalPosition(x, y);
                                                    }
                                                    // process
                                                    {
                                                        float distance = 20;
                                                        if (this.data.playerView.v == 0)
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(-distance, -distance, 0);
                                                        }
                                                        else
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(-distance, distance, 0);
                                                        }
                                                    }
                                                }
                                                // color
                                                color = Color.black;
                                                // fontSize
                                                fontSize = 30;
                                            }
                                            break;
                                        case UIData.Type.X:
                                            {
                                                // text
                                                {
                                                    text = "" + (char)('a' + (int)(this.data.index.v % 9));
                                                }
                                                // localPosition
                                                {
                                                    // find pos
                                                    Vector3 pos = Vector3.zero;
                                                    {
                                                        if (this.data.index.v < 9)
                                                        {
                                                            pos = Xiangqi.Common.convertXYToLocalPosition(this.data.index.v, 0);
                                                        }
                                                        else
                                                        {
                                                            pos = Xiangqi.Common.convertXYToLocalPosition(this.data.index.v - 9, 9);
                                                        }
                                                    }
                                                    // process
                                                    {
                                                        // find distance
                                                        float distance = 84;
                                                        // process
                                                        if (this.data.index.v < 9)
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
                                                fontSize = 50;
                                            }
                                            break;
                                        case UIData.Type.Y:
                                            {
                                                // text
                                                {
                                                    text = "" + (this.data.index.v % 10);
                                                }
                                                // localPosition
                                                {
                                                    // find pos
                                                    Vector3 pos = Vector3.zero;
                                                    {
                                                        if (this.data.index.v < 10)
                                                        {
                                                            pos = Xiangqi.Common.convertXYToLocalPosition(0, this.data.index.v);
                                                        }
                                                        else
                                                        {
                                                            pos = Xiangqi.Common.convertXYToLocalPosition(8, this.data.index.v - 10);
                                                        }
                                                    }
                                                    // process
                                                    {
                                                        // find distance
                                                        float distance = 84;
                                                        // process
                                                        if (this.data.index.v < 10)
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
                                                fontSize = 50;
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + this.data.type.v);
                                            break;
                                    }
                                }
                                break;
                            case GameType.Type.Banqi:
                                break;
                            case GameType.Type.Weiqi:
                            case GameType.Type.Gomoku:
                                {
                                    int boardSize = 19;
                                    {
                                        // find 
                                        {
                                            if (this.data.gameType.v == GameType.Type.Gomoku)
                                            {
                                                Gomoku.BoardUI.UIData gomokuBoardUIData = this.data.findDataInParent<Gomoku.BoardUI.UIData>();
                                                if (gomokuBoardUIData != null)
                                                {
                                                    boardSize = gomokuBoardUIData.boardSize.v;
                                                }
                                                else
                                                {
                                                    Debug.LogError("gomokuBoardUIData null");
                                                }
                                            }
                                            else if (this.data.gameType.v == GameType.Type.Weiqi)
                                            {
                                                Weiqi.BoardUI.UIData weiqiBoardUIData = this.data.findDataInParent<Weiqi.BoardUI.UIData>();
                                                if (weiqiBoardUIData != null)
                                                {
                                                    boardSize = weiqiBoardUIData.boardSize.v - 2;
                                                }
                                                else
                                                {
                                                    Debug.LogError("weiqiBoardUIData null");
                                                }
                                            }
                                        }
                                        // correct
                                        if (boardSize <= 0)
                                        {
                                            Debug.LogError("boardSize error: " + boardSize);
                                            boardSize = 1;
                                        }
                                    }
                                    // text
                                    {
                                        switch (this.data.type.v)
                                        {
                                            case UIData.Type.X:
                                                {
                                                    int index = this.data.index.v % boardSize;
                                                    {
                                                        if (index > 7)
                                                        {
                                                            index++;
                                                        }
                                                    }
                                                    text = "" + (char)('A' + (int)index);
                                                }
                                                break;
                                            case UIData.Type.Y:
                                                text = "" + (this.data.index.v % boardSize + 1);
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + this.data.type.v);
                                                break;
                                        }
                                    }
                                    // localPosition
                                    {
                                        // find pos
                                        Vector3 pos = Vector3.zero;
                                        {
                                            // find square
                                            int square = 0;
                                            {
                                                switch (this.data.type.v)
                                                {
                                                    case UIData.Type.X:
                                                        {
                                                            if (this.data.index.v < boardSize)
                                                            {
                                                                square = this.data.index.v%boardSize + boardSize * 0;
                                                            }
                                                            else
                                                            {
                                                                square = this.data.index.v % boardSize + boardSize * (boardSize - 1);
                                                            }
                                                        }
                                                        break;
                                                    case UIData.Type.Y:
                                                        {
                                                            if (this.data.index.v < boardSize)
                                                            {
                                                                square = 0 + boardSize * (this.data.index.v % boardSize);
                                                            }
                                                            else
                                                            {
                                                                square = (boardSize - 1) + boardSize * (this.data.index.v % boardSize);
                                                            }
                                                        }
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown type: " + this.data.type.v);
                                                        break;
                                                }
                                            }
                                            // process
                                            pos = Gomoku.Common.convertSquareToLocalPosition(boardSize, square);
                                        }
                                        // process
                                        {
                                            // find distance
                                            float distance = 100;
                                            // process
                                            {
                                                switch (this.data.type.v)
                                                {
                                                    case UIData.Type.X:
                                                        {
                                                            if (this.data.index.v < boardSize)
                                                            {
                                                                localPosition = pos * DefaultScale + new Vector3(0, -distance, 0);
                                                            }
                                                            else
                                                            {
                                                                localPosition = pos * DefaultScale + new Vector3(0, distance, 0);
                                                            }
                                                        }
                                                        break;
                                                    case UIData.Type.Y:
                                                        {
                                                            if (this.data.index.v < boardSize)
                                                            {
                                                                localPosition = pos * DefaultScale + new Vector3(-distance, 0, 0);
                                                            }
                                                            else
                                                            {
                                                                localPosition = pos * DefaultScale + new Vector3(distance, 0, 0);
                                                            }
                                                        }
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown type: " + this.data.type.v);
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                    // color
                                    color = Color.black;
                                    // fontSize
                                    fontSize = 50;
                                }
                                break;
                            case GameType.Type.InternationalDraught:
                                {
                                    switch (this.data.type.v)
                                    {
                                        case UIData.Type.InBoard:
                                            {
                                                // text
                                                {
                                                    text = InternationalDraught.Common.square_to_string(this.data.index.v);
                                                }
                                                // localPosition
                                                {
                                                    // find pos
                                                    Vector3 pos = Vector3.zero;
                                                    {
                                                        pos = InternationalDraught.Common.convertSquareToLocalPosition(this.data.index.v);
                                                    }
                                                    // process
                                                    {
                                                        // find distance
                                                        float distance = 30;
                                                        // process
                                                        if (this.data.playerView.v == 0)
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(-distance, distance, 0);
                                                        }
                                                        else
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(-distance, -distance, 0);
                                                        }
                                                    }
                                                }
                                                // color
                                                color = Color.white;
                                                // fontSize
                                                fontSize = 30;
                                            }
                                            break;
                                        case UIData.Type.X:
                                        case UIData.Type.Y:
                                            {
                                                // text
                                                {
                                                    text = InternationalDraught.Common.square_to_string(this.data.index.v);
                                                }
                                                // localPosition
                                                {
                                                    // find pos
                                                    Vector3 pos = Vector3.zero;
                                                    {
                                                        pos = InternationalDraught.Common.convertSquareToLocalPosition(this.data.index.v);
                                                    }
                                                    // process
                                                    {
                                                        // find distance
                                                        float distance = 75;
                                                        // process
                                                        int std = InternationalDraught.Common.square_to_std(this.data.index.v);
                                                        switch (this.data.type.v)
                                                        {
                                                            case UIData.Type.X:
                                                                {
                                                                    if (std <= 5)
                                                                    {
                                                                        localPosition = pos * DefaultScale + new Vector3(0, distance, 0);
                                                                    }
                                                                    else
                                                                    {
                                                                        localPosition = pos * DefaultScale + new Vector3(0, -distance, 0);
                                                                    }
                                                                }
                                                                break;
                                                            case UIData.Type.Y:
                                                                {
                                                                    if (std % 2 == 0)
                                                                    {
                                                                        localPosition = pos * DefaultScale + new Vector3(-distance, 0, 0);
                                                                    }
                                                                    else
                                                                    {
                                                                        localPosition = pos * DefaultScale + new Vector3(distance, 0, 0);
                                                                    }
                                                                }
                                                                break;
                                                            default:
                                                                Debug.LogError("unknown type: " + this.data.type.v);
                                                                break;
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
                            case GameType.Type.EnglishDraught:
                                {
                                    switch (this.data.type.v)
                                    {
                                        case UIData.Type.InBoard:
                                            {
                                                // text
                                                {
                                                    int x = 7 - this.data.index.v % 8;
                                                    int y = this.data.index.v / 8;
                                                    text = "" + (EnglishDraught.Common.getIndexFromXY(x, y) + 1);
                                                }
                                                // localPosition
                                                {
                                                    // find pos
                                                    Vector3 pos = Vector3.zero;
                                                    {
                                                        pos = EnglishDraught.Common.convertSquareToLocalPosition(this.data.index.v);
                                                    }
                                                    // process
                                                    {
                                                        // find distance
                                                        float distance = 30;
                                                        // process
                                                        if (this.data.playerView.v == 0)
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(-distance, distance, 0);
                                                        }
                                                        else
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(-distance, -distance, 0);
                                                        }
                                                    }
                                                }
                                                // color
                                                color = Color.white;
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
                            case GameType.Type.RussianDraught:
                                {
                                    switch (this.data.type.v)
                                    {
                                        case UIData.Type.InBoard:
                                            {
                                                // text
                                                {
                                                    int x = this.data.index.v % 8;
                                                    int y = 7 - this.data.index.v / 8;
                                                    if (this.data.index.v >= 0 && this.data.index.v < 64)
                                                    {
                                                        text = Chess.Common.squareToString((Chess.Common.Square)(x + 8 * y));
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
                                                        pos = EnglishDraught.Common.convertSquareToLocalPosition(this.data.index.v);
                                                    }
                                                    // process
                                                    {
                                                        // find distance
                                                        float distance = 30;
                                                        // process
                                                        if (this.data.playerView.v == 0)
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(-distance, distance, 0);
                                                        }
                                                        else
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(-distance, -distance, 0);
                                                        }
                                                    }
                                                }
                                                // color
                                                color = Color.white;
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
                            case GameType.Type.ChineseCheckers:
                                break;
                            case GameType.Type.MineSweeper:
                                break;
                            case GameType.Type.Hex:
                                {
                                    // find boardSize
                                    int boardSize = 10;
                                    {
                                        // find
                                        HEX.BoardUI.UIData hexBoardUIData = this.data.findDataInParent<HEX.BoardUI.UIData>();
                                        if (hexBoardUIData != null)
                                        {
                                            boardSize = hexBoardUIData.boardSize.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("hexBoardUIData null");
                                        }
                                        // correct
                                        if (boardSize <= 0)
                                        {
                                            Debug.LogError("boardSize error");
                                            boardSize = 1;
                                        }
                                    }
                                    // text
                                    {
                                        switch (this.data.type.v)
                                        {
                                            case UIData.Type.X:
                                                text = "" + (char)('A' + (int)(this.data.index.v % boardSize));
                                                break;
                                            case UIData.Type.Y:
                                                text = "" + (this.data.index.v % boardSize + 1);
                                                break;
                                        }
                                    }
                                    // localPosition
                                    {
                                        // find pos
                                        Vector3 pos = Vector3.zero;
                                        {
                                            switch (this.data.type.v)
                                            {
                                                case UIData.Type.X:
                                                    {
                                                        if (this.data.index.v < boardSize)
                                                        {
                                                            ushort square = (ushort)(this.data.index.v % boardSize + 0 * boardSize);
                                                            pos = HEX.Common.GetLocalPosition(square, this.data);
                                                        }
                                                        else
                                                        {
                                                            ushort square = (ushort)(this.data.index.v % boardSize + (boardSize - 1) * boardSize);
                                                            pos = HEX.Common.GetLocalPosition(square, this.data);
                                                        }
                                                    }
                                                    break;
                                                case UIData.Type.Y:
                                                    {
                                                        if (this.data.index.v < boardSize)
                                                        {
                                                            ushort square = (ushort)(0 + (this.data.index.v % boardSize) * boardSize);
                                                            pos = HEX.Common.GetLocalPosition(square, this.data);
                                                        }
                                                        else
                                                        {
                                                            ushort square = (ushort)((boardSize - 1) + (this.data.index.v % boardSize) * boardSize);
                                                            pos = HEX.Common.GetLocalPosition(square, this.data);
                                                        }
                                                    }
                                                    break;
                                                default:
                                                    Debug.LogError("unknown type: " + this.data.type.v);
                                                    break;
                                            }
                                        }
                                        // process
                                        {
                                            // find distance
                                            float distance = 100;
                                            // process
                                            switch (this.data.type.v)
                                            {
                                                case UIData.Type.X:
                                                    {
                                                        if (this.data.index.v < boardSize)
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(0, distance, 0);
                                                        }
                                                        else
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(0, -distance, 0);
                                                        }
                                                    }
                                                    break;
                                                case UIData.Type.Y:
                                                    {
                                                        if (this.data.index.v < boardSize)
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(-distance, 0, 0);
                                                        }
                                                        else
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(distance, 0, 0);
                                                        }
                                                    }
                                                    break;
                                                default:
                                                    Debug.LogError("unknown type: " + this.data.type.v);
                                                    break;
                                            }
                                        }
                                    }
                                    // color
                                    color = Color.black;
                                    // fontSize
                                    fontSize = 50;
                                }
                                break;
                            case GameType.Type.Solitaire:
                                break;
                            case GameType.Type.Sudoku:
                                break;
                            case GameType.Type.Khet:
                                break;
                            case GameType.Type.NineMenMorris:
                                {
                                    // text
                                    {
                                        switch (this.data.type.v)
                                        {
                                            case UIData.Type.InBoard:
                                                text = "" + (this.data.index.v + 1);
                                                break;
                                            case UIData.Type.X:
                                                text = "" + (char)('a' + (int)(this.data.index.v % 7));
                                                break;
                                            case UIData.Type.Y:
                                                text = "" + (this.data.index.v % 7 + 1);
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + this.data.type.v);
                                                break;
                                        }
                                    }
                                    // localPosition
                                    {
                                        switch (this.data.type.v)
                                        {
                                            case UIData.Type.InBoard:
                                                {
                                                    // find pos
                                                    Vector3 pos = Vector3.zero;
                                                    {
                                                        pos = NineMenMorris.Common.convertPositionToLocal(this.data.index.v);
                                                    }
                                                    // process
                                                    {
                                                        // find distance
                                                        float distance = 30;
                                                        // process
                                                        if (this.data.playerView.v == 0)
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(-distance, distance, 0);
                                                        }
                                                        else
                                                        {
                                                            localPosition = pos * DefaultScale + new Vector3(-distance, -distance, 0);
                                                        }
                                                    }
                                                }
                                                break;
                                            case UIData.Type.X:
                                                {
                                                    float distance = 75;
                                                    if (this.data.index.v < 7)
                                                    {
                                                        Vector3 pos = new Vector3(this.data.index.v % 7 - 3.0f, -3.0f);
                                                        localPosition = pos * DefaultScale + new Vector3(0, -distance, 0);
                                                    }
                                                    else
                                                    {
                                                        Vector3 pos = new Vector3(this.data.index.v % 7 - 3.0f, +3.0f);
                                                        localPosition = pos * DefaultScale + new Vector3(0, distance, 0);
                                                    }
                                                }
                                                break;
                                            case UIData.Type.Y:
                                                {
                                                    float distance = 75;
                                                    if (this.data.index.v < 7)
                                                    {
                                                        Vector3 pos = new Vector3(-3.0f, this.data.index.v % 7 - 3.0f);
                                                        localPosition = pos * DefaultScale + new Vector3(-distance, 0, 0);
                                                    }
                                                    else
                                                    {
                                                        Vector3 pos = new Vector3(+3.0f, this.data.index.v % 7 - 3.0f);
                                                        localPosition = pos * DefaultScale + new Vector3(distance, 0, 0);
                                                    }
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + this.data.type.v);
                                                break;
                                        }
                                    }
                                    // color
                                    color = Color.black;
                                    // fontSize
                                    {
                                        switch (this.data.type.v)
                                        {
                                            case UIData.Type.InBoard:
                                                fontSize = 25;
                                                break;
                                            case UIData.Type.X:
                                            case UIData.Type.Y:
                                                fontSize = 36;
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + this.data.type.v);
                                                break;
                                        }
                                    }
                                }
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

    private Gomoku.BoardUI.UIData gomokuBoardUIData = null;
    private Weiqi.BoardUI.UIData weiqiBoardUIData = null;
    private HEX.BoardUI.UIData hexBoardUIData = null;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Parent
            {
                DataUtils.addParentCallBack(uiData, this, ref this.gomokuBoardUIData);
                DataUtils.addParentCallBack(uiData, this, ref this.weiqiBoardUIData);
                DataUtils.addParentCallBack(uiData, this, ref this.hexBoardUIData);
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
        {
            if (data is Gomoku.BoardUI.UIData)
            {
                dirty = true;
                return;
            }
            if(data is Weiqi.BoardUI.UIData)
            {
                dirty = true;
                return;
            }
            if(data is HEX.BoardUI.UIData)
            {
                dirty = true;
                return;
            }
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
            // Parent
            {
                DataUtils.removeParentCallBack(uiData, this, ref this.gomokuBoardUIData);
                DataUtils.removeParentCallBack(uiData, this, ref this.weiqiBoardUIData);
                DataUtils.removeParentCallBack(uiData, this, ref this.hexBoardUIData);
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
        {
            if (data is Gomoku.BoardUI.UIData)
            {
                return;
            }
            if(data is Weiqi.BoardUI.UIData)
            {
                return;
            }
            if(data is HEX.BoardUI.UIData)
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
        // Parent
        {
            if (wrapProperty.p is Gomoku.BoardUI.UIData)
            {
                switch ((Gomoku.BoardUI.UIData.Property)wrapProperty.n)
                {
                    case Gomoku.BoardUI.UIData.Property.gomoku:
                        break;
                    case Gomoku.BoardUI.UIData.Property.boardIndexs:
                        break;
                    case Gomoku.BoardUI.UIData.Property.boardSize:
                        dirty = true;
                        break;
                    case Gomoku.BoardUI.UIData.Property.background:
                        break;
                    case Gomoku.BoardUI.UIData.Property.pieces:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
            }
            if(wrapProperty.p is Weiqi.BoardUI.UIData)
            {
                switch ((Weiqi.BoardUI.UIData.Property)wrapProperty.n)
                {
                    case Weiqi.BoardUI.UIData.Property.weiqi:
                        break;
                    case Weiqi.BoardUI.UIData.Property.background:
                        break;
                    case Weiqi.BoardUI.UIData.Property.mode:
                        break;
                    case Weiqi.BoardUI.UIData.Property.boardSize:
                        dirty = true;
                        break;
                    case Weiqi.BoardUI.UIData.Property.pieces:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            if(wrapProperty.p is HEX.BoardUI.UIData)
            {
                switch ((HEX.BoardUI.UIData.Property)wrapProperty.n)
                {
                    case HEX.BoardUI.UIData.Property.hex:
                        break;
                    case HEX.BoardUI.UIData.Property.boardIndexs:
                        break;
                    case HEX.BoardUI.UIData.Property.boardSize:
                        dirty = true;
                        break;
                    case HEX.BoardUI.UIData.Property.pieces:
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
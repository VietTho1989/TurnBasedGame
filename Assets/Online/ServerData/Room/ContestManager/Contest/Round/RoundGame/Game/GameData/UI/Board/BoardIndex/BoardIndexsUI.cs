using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BoardIndexsUI : UIBehavior<BoardIndexsUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<GameType.Type> gameType;

        public LP<BoardIndexUI.UIData> indexs;

        #region Constructor

        public enum Property
        {
            gameType,
            indexs
        }

        public UIData() : base()
        {
            this.gameType = new VP<GameType.Type>(this, (byte)Property.gameType, GameType.Type.CHESS);
            this.indexs = new LP<BoardIndexUI.UIData>(this, (byte)Property.indexs);
        }

        #endregion

    }

    private class Index
    {

        public GameType.Type gameType;

        public BoardIndexUI.UIData.Type type;

        public int index;

        public int playerView;

    }

    #endregion

    #region Refresh

    public override void refresh()
    {
        if (this.data != null)
        {
            // find
            List<Index> indexs = new List<Index>();
            {
                // indexs
                if(Setting.get().boardIndex.v!= Setting.BoardIndex.None)
                {
                    switch (this.data.gameType.v)
                    {
                        case GameType.Type.CHESS:
                        case GameType.Type.Shatranj:
                        case GameType.Type.Makruk:
                        case GameType.Type.Seirawan:
                        case GameType.Type.FairyChess:
                            {
                                switch (Setting.get().boardIndex.v)
                                {
                                    case Setting.BoardIndex.InBoard:
                                        {
                                            for (int i = 0; i < 64; i++)
                                            {
                                                Index index = new Index();
                                                {
                                                    index.type = BoardIndexUI.UIData.Type.InBoard;
                                                    index.index = i;
                                                }
                                                indexs.Add(index);
                                            }
                                        }
                                        break;
                                    case Setting.BoardIndex.OutBoard:
                                        {
                                            for (int i = 0; i < 16; i++)
                                            {
                                                // x
                                                {
                                                    Index index = new Index();
                                                    {
                                                        index.type = BoardIndexUI.UIData.Type.X;
                                                        index.index = i;
                                                    }
                                                    indexs.Add(index);
                                                }
                                                // y
                                                {
                                                    Index index = new Index();
                                                    {
                                                        index.type = BoardIndexUI.UIData.Type.Y;
                                                        index.index = i;
                                                    }
                                                    indexs.Add(index);
                                                }
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + Setting.get().boardIndex.v);
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
                        case GameType.Type.CO_TUONG_UP:
                        case GameType.Type.Janggi:
                            {
                                switch (Setting.get().boardIndex.v)
                                {
                                    case Setting.BoardIndex.InBoard:
                                        {
                                            for (int i = 0; i < 90; i++)
                                            {
                                                Index index = new Index();
                                                {
                                                    index.type = BoardIndexUI.UIData.Type.InBoard;
                                                    index.index = i;
                                                }
                                                indexs.Add(index);
                                            }
                                        }
                                        break;
                                    case Setting.BoardIndex.OutBoard:
                                        {
                                            for (int i = 0; i < 16; i++)
                                            {
                                                // x
                                                {
                                                    Index index = new Index();
                                                    {
                                                        index.type = BoardIndexUI.UIData.Type.X;
                                                        index.index = i;
                                                    }
                                                    indexs.Add(index);
                                                }
                                                // y
                                                {
                                                    Index index = new Index();
                                                    {
                                                        index.type = BoardIndexUI.UIData.Type.Y;
                                                        index.index = i;
                                                    }
                                                    indexs.Add(index);
                                                }
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + Setting.get().boardIndex.v);
                                        break;
                                }
                            }
                            break;
                        case GameType.Type.Banqi:
                            break;
                        case GameType.Type.Gomoku:
                            break;
                        case GameType.Type.InternationalDraught:
                            break;
                        case GameType.Type.EnglishDraught:
                            {
                                switch (Setting.get().boardIndex.v)
                                {
                                    case Setting.BoardIndex.InBoard:
                                        {
                                            for (int y = 0; y < 8; y++)
                                            {
                                                for (int x = 0; x < 8; x++)
                                                {
                                                    if((x + y) % 2 == 1)
                                                    {
                                                        Index index = new Index();
                                                        {
                                                            index.type = BoardIndexUI.UIData.Type.InBoard;
                                                            index.index = x + 8 * y;
                                                        }
                                                        indexs.Add(index);
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case Setting.BoardIndex.OutBoard:
                                        {
                                            // x
                                            for (int i = 0; i < 16; i++)
                                            {
                                                Index index = new Index();
                                                {
                                                    index.type = BoardIndexUI.UIData.Type.X;
                                                    index.index = i;
                                                }
                                                indexs.Add(index);
                                            }
                                            // y
                                            for (int i = 0; i < 16; i++)
                                            {
                                                Index index = new Index();
                                                {
                                                    index.type = BoardIndexUI.UIData.Type.Y;
                                                    index.index = i;
                                                }
                                                indexs.Add(index);
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + Setting.get().boardIndex.v);
                                        break;
                                }
                            }
                            break;
                        case GameType.Type.RussianDraught:
                            {
                                switch (Setting.get().boardIndex.v)
                                {
                                    case Setting.BoardIndex.InBoard:
                                        {
                                            for (int y = 0; y < 8; y++)
                                            {
                                                for (int x = 0; x < 8; x++)
                                                {
                                                    if ((x + y) % 2 == 1)
                                                    {
                                                        Index index = new Index();
                                                        {
                                                            index.type = BoardIndexUI.UIData.Type.InBoard;
                                                            index.index = x + 8 * y;
                                                        }
                                                        indexs.Add(index);
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case Setting.BoardIndex.OutBoard:
                                        {
                                            // x
                                            for (int i = 0; i < 16; i++)
                                            {
                                                Index index = new Index();
                                                {
                                                    index.type = BoardIndexUI.UIData.Type.X;
                                                    index.index = i;
                                                }
                                                indexs.Add(index);
                                            }
                                            // y
                                            for (int i = 0; i < 16; i++)
                                            {
                                                Index index = new Index();
                                                {
                                                    index.type = BoardIndexUI.UIData.Type.Y;
                                                    index.index = i;
                                                }
                                                indexs.Add(index);
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + Setting.get().boardIndex.v);
                                        break;
                                }
                            }
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
                // gameType
                foreach(Index index in indexs)
                {
                    index.gameType = this.data.gameType.v;
                }
                // playerView
                {
                    // find
                    int playerView = 0;
                    {
                        GameDataBoardUI.UIData gameDataBoardUIData = this.data.findDataInParent<GameDataBoardUI.UIData>();
                        if (gameDataBoardUIData != null)
                        {
                            Perspective perspective = gameDataBoardUIData.perspective.v;
                            if (perspective != null)
                            {
                                playerView = perspective.playerView.v;
                            }
                            else
                            {
                                Debug.LogError("perspective null");
                            }
                        }
                        else
                        {
                            Debug.LogError("gameDataBoardUIData null");
                        }
                    }
                    // process
                    foreach(Index index in indexs)
                    {
                        index.playerView = playerView;
                    }
                }
            }
            // process
            {
                // get old
                List<BoardIndexUI.UIData> oldIndexs = new List<BoardIndexUI.UIData>();
                {
                    oldIndexs.AddRange(this.data.indexs.vs);
                }
                // update
                {
                    foreach(Index index in indexs)
                    {
                        // make UI
                        BoardIndexUI.UIData indexUIData = null;
                        bool needAdd = false;
                        {
                            // find old
                            if (oldIndexs.Count > 0)
                            {
                                indexUIData = oldIndexs[0];
                            }
                            // make new
                            if (indexUIData == null)
                            {
                                indexUIData = new BoardIndexUI.UIData();
                                {
                                    indexUIData.uid = this.data.indexs.makeId();
                                }
                                needAdd = true;
                            }
                            else
                            {
                                oldIndexs.Remove(indexUIData);
                            }
                        }
                        // update
                        {
                            indexUIData.gameType.v = index.gameType;
                            indexUIData.type.v = index.type;
                            indexUIData.index.v = index.index;
                            indexUIData.playerView.v = index.playerView;
                        }
                        // add
                        if (needAdd)
                        {
                            this.data.indexs.add(indexUIData);
                        }
                    }
                }
                // remove old
                foreach(BoardIndexUI.UIData oldIndex in oldIndexs)
                {
                    this.data.indexs.remove(oldIndex);
                }
            }
            // scale
            {
                this.transform.localScale = new Vector3(1, 1, 1);
                if (contentContainer != null)
                {
                    contentContainer.localScale = new Vector3(1 / BoardIndexUI.DefaultScale, 1 / BoardIndexUI.DefaultScale, 1);
                }
                else
                {
                    Debug.LogError("contentContainer null");
                }
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public BoardIndexUI boardIndexPrefab;
    public RectTransform contentContainer;

    private GameDataBoardCheckPerspectiveChange<UIData> gameDataBoardCheckPerspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // checkChange
            {
                gameDataBoardCheckPerspectiveChange.addCallBack(this);
                gameDataBoardCheckPerspectiveChange.setData(uiData);
            }
            // Child
            {
                uiData.indexs.allAddCallBack(this);
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
        // checkChange
        if (data is GameDataBoardCheckPerspectiveChange<UIData>)
        {
            dirty = true;
            return;
        }
        // Child
        if(data is BoardIndexUI.UIData)
        {
            BoardIndexUI.UIData boardIndexUIData = data as BoardIndexUI.UIData;
            // UI
            {
                UIUtils.Instantiate(boardIndexUIData, boardIndexPrefab, contentContainer);
            }
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
            // checkChange
            {
                gameDataBoardCheckPerspectiveChange.removeCallBack(this);
                gameDataBoardCheckPerspectiveChange.setData(null);
            }
            // Child
            {
                uiData.indexs.allRemoveCallBack(this);
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
        // Child
        if (data is BoardIndexUI.UIData)
        {
            BoardIndexUI.UIData boardIndexUIData = data as BoardIndexUI.UIData;
            // UI
            {
                boardIndexUIData.removeCallBackAndDestroy(typeof(BoardIndexUI));
            }
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
                case UIData.Property.gameType:
                    dirty = true;
                    break;
                case UIData.Property.indexs:
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
        // checkChange
        if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>)
        {
            dirty = true;
            return;
        }
        // Child
        if (wrapProperty.p is BoardIndexUI.UIData)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameTypeInformationUI : UIHaveTransformDataBehavior<GameTypeInformationUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<GameType>> gameType;

        #region sub

        public abstract class Sub : Data
        {

            public abstract GameType.Type getType();

            public abstract bool processEvent(Event e);

        }

        public VP<Sub> sub;

        #endregion

        #region Constructor

        public enum Property
        {
            gameType,
            sub
        }

        public UIData() : base()
        {
            this.gameType = new VP<ReferenceData<GameType>>(this, (byte)Property.gameType, new ReferenceData<GameType>(null));
            this.sub = new VP<Sub>(this, (byte)Property.sub, null);
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // sub
                if (!isProcess)
                {
                    Sub sub = this.sub.v;
                    if (sub != null)
                    {
                        isProcess = sub.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("sub null");
                    }
                }
            }
            return isProcess;
        }

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
                GameType gameType = this.data.gameType.v.data;
                if (gameType != null)
                {
                    // sub
                    {
                        switch (gameType.getType())
                        {
                            case GameType.Type.CHESS:
                                {
                                    Chess.Chess chess = gameType as Chess.Chess;
                                    // make UI
                                    Chess.ChessInformationUI.UIData chessInformationUIData = this.data.sub.newOrOld<Chess.ChessInformationUI.UIData>();
                                    {
                                        chessInformationUIData.chess.v = new ReferenceData<Chess.Chess>(chess);
                                    }
                                    this.data.sub.v = chessInformationUIData;
                                }
                                break;
                            case GameType.Type.FairyChess:
                                {
                                    FairyChess.FairyChess fairyChess = gameType as FairyChess.FairyChess;
                                    // make UI
                                    FairyChess.FairyChessInformationUI.UIData fairyChessInformationUIData = this.data.sub.newOrOld<FairyChess.FairyChessInformationUI.UIData>();
                                    {
                                        fairyChessInformationUIData.fairyChess.v = new ReferenceData<FairyChess.FairyChess>(fairyChess);
                                    }
                                    this.data.sub.v = fairyChessInformationUIData;
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + gameType.getType());
                                break;
                        }
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // sub
                        {
                            float height = UIRectTransform.SetPosY(this.data.sub.v, deltaY);
                            deltaY += height;
                        }
                        // set
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                }
                else
                {
                    Debug.LogError("gameType null");
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

    public Chess.ChessInformationUI chessInformationPrefab;
    public FairyChess.FairyChessInformationUI fairyChessInformationPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.sub.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if(data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case GameType.Type.CHESS:
                            {
                                Chess.ChessInformationUI.UIData chessInformationUIData = sub as Chess.ChessInformationUI.UIData;
                                UIUtils.Instantiate(chessInformationUIData, chessInformationPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.FairyChess:
                            {
                                FairyChess.FairyChessInformationUI.UIData fairyChessInformationUIData = sub as FairyChess.FairyChessInformationUI.UIData;
                                UIUtils.Instantiate(fairyChessInformationUIData, fairyChessInformationPrefab, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType());
                            break;
                    }
                }
                // Child
                {
                    TransformData.AddCallBack(sub, this);
                }
                dirty = true;
                return;
            }
            // Child
            if(data is TransformData)
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
            // Child
            {
                uiData.sub.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // Child
                {
                    TransformData.RemoveCallBack(sub, this);
                }
                // UI
                {
                    switch (sub.getType())
                    {
                        case GameType.Type.CHESS:
                            {
                                Chess.ChessInformationUI.UIData chessInformationUIData = sub as Chess.ChessInformationUI.UIData;
                                chessInformationUIData.removeCallBackAndDestroy(typeof(Chess.ChessInformationUI));
                            }
                            break;
                        case GameType.Type.FairyChess:
                            {
                                FairyChess.FairyChessInformationUI.UIData fairyChessInformationUIData = sub as FairyChess.FairyChessInformationUI.UIData;
                                fairyChessInformationUIData.removeCallBackAndDestroy(typeof(FairyChess.FairyChessInformationUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType());
                            break;
                    }
                }
                return;
            }
            // Child
            if (data is TransformData)
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
                case UIData.Property.gameType:
                    dirty = true;
                    break;
                case UIData.Property.sub:
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
        // Child
        {
            if (wrapProperty.p is UIData.Sub)
            {
                return;
            }
            // Child
            if (wrapProperty.p is TransformData)
            {
                switch ((TransformData.Property)wrapProperty.n)
                {
                    case TransformData.Property.anchoredPosition:
                        break;
                    case TransformData.Property.anchorMin:
                        break;
                    case TransformData.Property.anchorMax:
                        break;
                    case TransformData.Property.pivot:
                        break;
                    case TransformData.Property.offsetMin:
                        break;
                    case TransformData.Property.offsetMax:
                        break;
                    case TransformData.Property.sizeDelta:
                        break;
                    case TransformData.Property.rotation:
                        break;
                    case TransformData.Property.scale:
                        break;
                    case TransformData.Property.size:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
    }

    #endregion

}
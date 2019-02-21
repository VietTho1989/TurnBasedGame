using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBottomUI : UIBehavior<GameBottomUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<Game>> game;

        public VP<BtnUndoRedoUI.UIData> btnUndoRedo;

        #region Constructor

        public enum Property
        {
            game,
            btnUndoRedo
        }

        public UIData() : base()
        {
            this.game = new VP<ReferenceData<Game>>(this, (byte)Property.game, new ReferenceData<Game>(null));
            this.btnUndoRedo = new VP<BtnUndoRedoUI.UIData>(this, (byte)Property.btnUndoRedo, new BtnUndoRedoUI.UIData());
        }

        #endregion

    }

    #endregion

    #region txt

    static GameBottomUI()
    {
        // rect
        {
            // btnUndoRedo
            {
                // anchoredPosition: (0.0, 0.0); anchorMin: (0.0, 0.5); anchorMax: (0.0, 0.5); pivot: (0.0, 0.5);
                // offsetMin: (0.0, -30.0); offsetMax: (80.0, 30.0); sizeDelta: (80.0, 60.0);
                btnUndoRedoRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                btnUndoRedoRect.anchorMin = new Vector2(0.0f, 0.5f);
                btnUndoRedoRect.anchorMax = new Vector2(0.0f, 0.5f);
                btnUndoRedoRect.pivot = new Vector2(0.0f, 0.5f);
                btnUndoRedoRect.offsetMin = new Vector2(0.0f, -30.0f);
                btnUndoRedoRect.offsetMax = new Vector2(80.0f, 30.0f);
                btnUndoRedoRect.sizeDelta = new Vector2(80.0f, 60.0f);
            }
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
                Game game = this.data.game.v.data;
                if (game != null)
                {
                    // btnUndoRedo
                    {
                        BtnUndoRedoUI.UIData btnUndoRedo = this.data.btnUndoRedo.v;
                        if (btnUndoRedo != null)
                        {
                            btnUndoRedo.undoRedoRequest.v = new ReferenceData<UndoRedoRequest>(game.undoRedoRequest.v);
                        }
                        else
                        {
                            Debug.LogError("btnUndoRedo null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("game null");
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

    public BtnUndoRedoUI btnUndoRedoPrefab;
    private static readonly UIRectTransform btnUndoRedoRect = new UIRectTransform();

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.game.allAddCallBack(this);
                uiData.btnUndoRedo.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if(data is Game)
            {
                dirty = true;
                return;
            }
            if (data is BtnUndoRedoUI.UIData)
            {
                BtnUndoRedoUI.UIData btnUndoRedoUIData = data as BtnUndoRedoUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnUndoRedoUIData, btnUndoRedoPrefab, this.transform, btnUndoRedoRect);
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
            // Child
            {
                uiData.game.allRemoveCallBack(this);
                uiData.btnUndoRedo.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if(data is Game)
            {
                return;
            }
            if (data is BtnUndoRedoUI.UIData)
            {
                BtnUndoRedoUI.UIData btnUndoRedoUIData = data as BtnUndoRedoUI.UIData;
                // UI
                {
                    btnUndoRedoUIData.removeCallBackAndDestroy(typeof(BtnUndoRedoUI));
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if(WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is UIData)
        {
            switch ((UIData.Property)wrapProperty.n)
            {
                case UIData.Property.game:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnUndoRedo:
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
            if(wrapProperty.p is Game)
            {
                switch ((Game.Property)wrapProperty.n)
                {
                    case Game.Property.gamePlayers:
                        break;
                    case Game.Property.requestDraw:
                        break;
                    case Game.Property.state:
                        break;
                    case Game.Property.gameData:
                        break;
                    case Game.Property.history:
                        break;
                    case Game.Property.gameAction:
                        break;
                    case Game.Property.undoRedoRequest:
                        dirty = true;
                        break;
                    case Game.Property.chatRoom:
                        break;
                    case Game.Property.animationData:
                        break;
                    default:
                        Debug.LogError("game null");
                        break;
                }
                return;
            }
            if (wrapProperty.p is BtnUndoRedoUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
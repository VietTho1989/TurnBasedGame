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

        public VP<BtnRequestDrawUI.UIData> btnRequestDraw;

        #region Constructor

        public enum Property
        {
            game,
            btnUndoRedo,
            btnRequestDraw
        }

        public UIData() : base()
        {
            this.game = new VP<ReferenceData<Game>>(this, (byte)Property.game, new ReferenceData<Game>(null));
            this.btnUndoRedo = new VP<BtnUndoRedoUI.UIData>(this, (byte)Property.btnUndoRedo, new BtnUndoRedoUI.UIData());
            this.btnRequestDraw = new VP<BtnRequestDrawUI.UIData>(this, (byte)Property.btnRequestDraw, new BtnRequestDrawUI.UIData());
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
            // btnRequestDraw
            {
                // anchoredPosition: (80.0, 0.0); anchorMin: (0.0, 0.0); anchorMax: (0.0, 1.0); pivot: (0.0, 0.5);
                // offsetMin: (80.0, 0.0); offsetMax: (160.0, 0.0); sizeDelta: (80.0, 0.0);
                btnRequestDrawRect.anchoredPosition = new Vector3(80.0f, 0.0f, 0.0f);
                btnRequestDrawRect.anchorMin = new Vector2(0.0f, 0.0f);
                btnRequestDrawRect.anchorMax = new Vector2(0.0f, 1.0f);
                btnRequestDrawRect.pivot = new Vector2(0.0f, 0.5f);
                btnRequestDrawRect.offsetMin = new Vector2(80.0f, 0.0f);
                btnRequestDrawRect.offsetMax = new Vector2(160.0f, 0.0f);
                btnRequestDrawRect.sizeDelta = new Vector2(80.0f, 0.0f);
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
                    // btnRequestDraw
                    {
                        BtnRequestDrawUI.UIData btnRequestDraw = this.data.btnRequestDraw.v;
                        if (btnRequestDraw != null)
                        {
                            btnRequestDraw.requestDraw.v = new ReferenceData<RequestDraw>(game.requestDraw.v);
                        }
                        else
                        {
                            Debug.LogError("btnRequestDraw null");
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

    public BtnRequestDrawUI btnRequestDrawPrefab;
    private static readonly UIRectTransform btnRequestDrawRect = new UIRectTransform();

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.game.allAddCallBack(this);
                uiData.btnUndoRedo.allAddCallBack(this);
                uiData.btnRequestDraw.allAddCallBack(this);
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
            if(data is BtnRequestDrawUI.UIData)
            {
                BtnRequestDrawUI.UIData btnRequestDrawUIData = data as BtnRequestDrawUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnRequestDrawUIData, btnRequestDrawPrefab, this.transform, btnRequestDrawRect);
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
                uiData.btnRequestDraw.allRemoveCallBack(this);
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
            if(data is BtnRequestDrawUI.UIData)
            {
                BtnRequestDrawUI.UIData btnRequestDrawUIData = data as BtnRequestDrawUI.UIData;
                // UI
                {
                    btnRequestDrawUIData.removeCallBackAndDestroy(typeof(BtnRequestDrawUI));
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
                case UIData.Property.btnRequestDraw:
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
                        dirty = true;
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
            if(wrapProperty.p is BtnRequestDrawUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}
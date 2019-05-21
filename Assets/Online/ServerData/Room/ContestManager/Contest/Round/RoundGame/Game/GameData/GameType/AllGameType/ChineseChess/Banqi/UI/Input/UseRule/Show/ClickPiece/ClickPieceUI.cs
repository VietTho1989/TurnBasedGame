using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Banqi.UseRule
{
    public class ClickPieceUI : UIBehavior<ClickPieceUI.UIData>, IPointerDownHandler
    {

        #region UIData

        public class UIData : ShowUI.UIData.Sub
        {

            public VP<int> keyX;

            public VP<int> keyY;

            #region Constructor

            public enum Property
            {
                keyX,
                keyY
            }

            public UIData() : base()
            {
                this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
                this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
            }

            #endregion

            public override Type getType()
            {
                return Type.ClickPiece;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    if (InputEvent.isEnter(e))
                    {
                        // enter
                        ClickPieceUI clickPieceUI = this.findCallBack<ClickPieceUI>();
                        if (clickPieceUI != null)
                        {
                            clickPieceUI.onEnterKey();
                        }
                        else
                        {
                            Debug.LogError("clickPieceUI null: " + this);
                        }
                        isProcess = true;
                    }
                    else if (InputEvent.isArrow(e))
                    {
                        if (this.keyX.v >= 0 && this.keyX.v < 8
                            && this.keyY.v >= 0 && this.keyY.v < 4)
                        {
                            // find new key position
                            int newKeyX = this.keyX.v;
                            int newKeyY = this.keyY.v;
                            {
                                switch (e.keyCode)
                                {
                                    case KeyCode.LeftArrow:
                                        newKeyX--;
                                        break;
                                    case KeyCode.RightArrow:
                                        newKeyX++;
                                        break;
                                    case KeyCode.UpArrow:
                                        newKeyY++;
                                        break;
                                    case KeyCode.DownArrow:
                                        newKeyY--;
                                        break;
                                    default:
                                        Debug.LogError("unknown keyCode: " + e.keyCode);
                                        break;
                                }
                            }
                            // set
                            if (newKeyX >= 0 && newKeyX < 8
                                && newKeyY >= 0 && newKeyY < 4)
                            {
                                this.keyX.v = newKeyX;
                                this.keyY.v = newKeyY;
                            }
                        }
                        else
                        {
                            // bring to lastMove
                            int lastKeyX = 4;
                            int lastKeyY = 2;
                            {
                                // find gameMove
                                GameMove gameMove = null;
                                {
                                    // Find gameData
                                    GameData gameData = null;
                                    {
                                        GameDataUI.UIData gameDataUIData = this.findDataInParent<GameDataUI.UIData>();
                                        if (gameDataUIData != null)
                                        {
                                            gameData = gameDataUIData.gameData.v.data;
                                        }
                                        else
                                        {
                                            Debug.LogError("gameDataUIData null: ");
                                        }
                                    }
                                    // Process
                                    if (gameData != null)
                                    {
                                        LastMove lastMove = gameData.lastMove.v;
                                        if (lastMove != null)
                                        {
                                            gameMove = lastMove.gameMove.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("lastMove null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        // Debug.LogError ("gameData null: " + data);
                                    }
                                }
                                // process
                                if (gameMove != null)
                                {
                                    switch (gameMove.getType())
                                    {
                                        case GameMove.Type.BanqiMove:
                                            {
                                                BanqiMove banqiMove = gameMove as BanqiMove;
                                                lastKeyX = banqiMove.destX.v - 1;
                                                lastKeyY = 3 - (banqiMove.destY.v - 1);
                                            }
                                            break;
                                        case GameMove.Type.None:
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + gameMove.getType() + "; " + this);
                                            break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameMove null: " + this);
                                }
                            }
                            // set
                            this.keyX.v = lastKeyX;
                            this.keyY.v = lastKeyY;
                        }
                        isProcess = true;
                    }
                }
                return isProcess;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Banqi ? 1 : 0;
        }

        #region Refresh

        public GameObject keySelect;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // keySelect
                    {
                        if (keySelect != null)
                        {
                            if (this.data.keyX.v >= 0 && this.data.keyX.v < 8
                                && this.data.keyY.v >= 0 && this.data.keyY.v < 4)
                            {
                                keySelect.SetActive(true);
                                keySelect.transform.localPosition = Common.convertPosToLocalPosition(8 * this.data.keyY.v + this.data.keyX.v);
                            }
                            else
                            {
                                keySelect.SetActive(false);
                            }
                        }
                        else
                        {
                            Debug.LogError("keySelect null: " + this);
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
            return false;
        }

        #endregion

        #region implement callBacks

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
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
                // Child
                {

                }
                this.setDataNull(uiData);
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
                    case UIData.Property.keyX:
                        dirty = true;
                        break;
                    case UIData.Property.keyY:
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

        #region IPointerDownHandler

        private void clickPiece(int x, int y)
        {
            if (this.data != null)
            {
                Banqi banqi = null;
                // Check isActive
                bool isActive = false;
                {
                    UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData>();
                    if (useRuleInputUIData != null)
                    {
                        banqi = useRuleInputUIData.banqi.v.data;
                        if (banqi != null)
                        {
                            if (global::Game.IsPlaying(banqi))
                            {
                                isActive = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("banqi null: " + this);
                            return;
                        }
                    }
                    else
                    {
                        Debug.LogError("useRuleInputUIData null: " + this);
                    }
                }
                if (isActive)
                {
                    if (x >= 0 && x < 8 && y >= 0 && y < 4)
                    {
                        // find pc
                        Token.Ecolor color = Token.Ecolor.None;
                        Token.Type type = Token.Type.SOLDIER;
                        bool isFaceUp = true;
                        {
                            banqi.getPiece(8 * y + x, out color, out type, out isFaceUp);
                        }
                        if (color != Token.Ecolor.None)
                        {
                            // check is correct piece
                            bool isCorrectPiece = false;
                            {
                                if (!isFaceUp || color == banqi.color.v)
                                {
                                    isCorrectPiece = true;
                                }
                            }
                            if (isCorrectPiece)
                            {
                                // chuyen sang clickDest
                                ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData>();
                                if (show != null)
                                {
                                    ClickDestUI.UIData clickDest = new ClickDestUI.UIData();
                                    {
                                        clickDest.uid = show.sub.makeId();
                                        clickDest.x.v = x;
                                        clickDest.y.v = y;
                                    }
                                    show.sub.v = clickDest;
                                }
                                else
                                {
                                    Debug.LogError("show null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("not click correct piece: ");
                            }
                        }
                        else
                        {
                            Debug.LogError("not click in any piece");
                        }
                    }
                    else
                    {
                        Debug.LogError("click outside board");
                    }
                }
                else
                {
                    Debug.LogError("not active: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void onEnterKey()
        {
            if (this.data != null)
            {
                this.clickPiece(this.data.keyX.v, this.data.keyY.v);
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.LogError("OnPointerDown: " + eventData);
            Vector3 localPosition = transform.InverseTransformPoint(eventData.position);
            int x = 0;
            int y = 0;
            {
                Common.convertLocalPostionToPos(localPosition, out x, out y);
            }
            Debug.LogError("localPosition: " + localPosition + ", " + x + ", " + y);
            this.clickPiece(x, y);
        }

        #endregion

    }
}
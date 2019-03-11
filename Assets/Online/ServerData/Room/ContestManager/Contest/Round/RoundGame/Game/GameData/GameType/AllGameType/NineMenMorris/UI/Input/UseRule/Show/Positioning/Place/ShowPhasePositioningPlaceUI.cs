using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris.UseRule
{
    public class ShowPhasePositioningPlaceUI : UIBehavior<ShowPhasePositioningPlaceUI.UIData>, IPointerDownHandler
    {

        #region UIData

        public class UIData : ShowPhasePositioningUI.UIData.Sub
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
                return Type.Place;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    if (InputEvent.isEnter(e))
                    {
                        // enter
                        ShowPhasePositioningPlaceUI placeUI = this.findCallBack<ShowPhasePositioningPlaceUI>();
                        if (placeUI != null)
                        {
                            placeUI.onEnterKey();
                        }
                        else
                        {
                            Debug.LogError("placeUI null: " + this);
                        }
                        isProcess = true;
                    }
                    else if (InputEvent.isArrow(e))
                    {
                        if (this.keyX.v >= 0 && this.keyX.v <= 6
                            && this.keyY.v >= 0 && this.keyY.v <= 6)
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
                            if (newKeyX >= 0 && newKeyX <= 6
                                && newKeyY >= 0 && newKeyY <= 6)
                            {
                                this.keyX.v = newKeyX;
                                this.keyY.v = newKeyY;
                            }
                        }
                        else
                        {
                            // bring to lastMove
                            int lastKeyX = 3;
                            int lastKeyY = 3;
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
                                        case GameMove.Type.NineMenMorrisMove:
                                            {
                                                NineMenMorrisMove nineMenMorrisMove = gameMove as NineMenMorrisMove;
                                                Common.parsePositionToXY(nineMenMorrisMove.moved.v, out lastKeyX, out lastKeyY);
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
                            if (this.data.keyX.v >= 0 && this.data.keyX.v <= 6
                                && this.data.keyY.v >= 0 && this.data.keyY.v <= 6)
                            {
                                keySelect.SetActive(true);
                                keySelect.transform.localPosition = new Vector2(this.data.keyX.v - 3, this.data.keyY.v - 3);
                            }
                            else
                            {
                                keySelect.SetActive(false);
                            }
                        }
                        else
                        {
                            Debug.LogError("keySelect null");
                        }
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
                NineMenMorris nineMenMorris = null;
                // Check isActive
                bool isActive = false;
                {
                    UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData>();
                    if (useRuleInputUIData != null)
                    {
                        nineMenMorris = useRuleInputUIData.nineMenMorris.v.data;
                        if (nineMenMorris != null)
                        {
                            if (Game.IsPlaying(nineMenMorris))
                            {
                                isActive = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("nineMenMorris null: " + this);
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
                    if (x >= 0 && x <= 6 && y >= 0 && y <= 6)
                    {
                        int position = Common.ConvertXYToPosition(x, y);
                        if (position >= 0 && position < Common.BOARD_SPOT)
                        {
                            // find legal moves
                            List<NineMenMorrisMove> legalMoves = new List<NineMenMorrisMove>();
                            {
                                ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData>();
                                if (showUIData != null)
                                {
                                    foreach (NineMenMorrisMove nineMenMorrisMove in showUIData.legalMoves.vs)
                                    {
                                        if (nineMenMorrisMove.action.v == Common.NMMAction.Place)
                                        {
                                            if (nineMenMorrisMove.moved.v == position)
                                            {
                                                legalMoves.Add(nineMenMorrisMove);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("showUIData null");
                                }
                            }
                            // process
                            if (legalMoves.Count == 0)
                            {
                                Debug.LogError("why don't have any legal moves");
                            }
                            else
                            {
                                bool isOnlyPlace = false;
                                {
                                    if (legalMoves.Count == 1)
                                    {
                                        if (!(legalMoves[0].removed.v >= 0 && legalMoves[0].removed.v < Common.BOARD_SPOT))
                                        {
                                            isOnlyPlace = true;
                                        }
                                    }
                                }
                                // place
                                if (isOnlyPlace)
                                {
                                    ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                                    if (clientInput != null)
                                    {
                                        clientInput.makeSend(legalMoves[0]);
                                    }
                                    else
                                    {
                                        Debug.LogError("clientInput null: " + this);
                                    }
                                }
                                else
                                {
                                    // chuyen sang remove
                                    ShowPhasePositioningUI.UIData positioningUIData = this.data.findDataInParent<ShowPhasePositioningUI.UIData>();
                                    if (positioningUIData != null)
                                    {
                                        ShowPhasePositioningRemoveUI.UIData removeUIData = new ShowPhasePositioningRemoveUI.UIData();
                                        {
                                            removeUIData.uid = positioningUIData.sub.makeId();
                                            removeUIData.position.v = position;
                                        }
                                        positioningUIData.sub.v = removeUIData;
                                    }
                                    else
                                    {
                                        Debug.LogError("positioningUIData null");
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("outside board: " + position);
                        }
                    }
                    else
                    {
                        Debug.LogError("click outside board: " + this);
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

        public void OnPointerDown(PointerEventData eventData)
        {
            // Debug.LogError ("OnPointerDown: " + eventData);
            // get x, y
            int x = -1;
            int y = -1;
            {
                Vector3 localPosition = transform.InverseTransformPoint(eventData.position);
                Common.convertLocalPositionToXY(localPosition, out x, out y);
                // Debug.LogError ("localPosition: " + localPosition + ", " + x + ", " + y);
            }
            this.clickPiece(x, y);
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

        #endregion

    }
}
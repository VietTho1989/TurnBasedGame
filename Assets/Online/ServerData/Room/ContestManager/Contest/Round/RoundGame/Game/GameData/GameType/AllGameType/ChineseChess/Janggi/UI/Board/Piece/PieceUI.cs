using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Janggi
{
    public class PieceUI : UIBehavior<PieceUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<uint> piece;

            public VP<int> x;

            public VP<int> y;

            public VP<bool> blindFold;

            #region Constructor

            public enum Property
            {
                piece,
                x,
                y,
                blindFold
            }

            public UIData() : base()
            {
                this.piece = new VP<uint>(this, (byte)Property.piece, 0);
                this.x = new VP<int>(this, (byte)Property.x, 0);
                this.y = new VP<int>(this, (byte)Property.y, 0);
                this.blindFold = new VP<bool>(this, (byte)Property.blindFold, false);
            }

            #endregion

        }

        #endregion

        #region Refresh

        public Image image;

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
                        // image
                        {
                            if (image != null)
                            {
                                if (!this.data.blindFold.v)
                                {
                                    image.enabled = true;
                                    Sprite sprite = JanggiSpriteContainer.get().getSprite(this.data.piece.v, Setting.get().style.v);
                                    {
                                        // animation?
                                    }
                                    image.sprite = sprite;
                                }
                                else
                                {
                                    image.enabled = false;
                                }
                            }
                            else
                            {
                                Debug.LogError("image null");
                            }
                        }
                        // position
                        {
                            Vector2 localPos = Common.convertXYToLocalPosition(this.data.x.v, this.data.y.v);
                            {
                                if (moveAnimation != null)
                                {
                                    switch (moveAnimation.getType())
                                    {
                                        case GameMove.Type.JanggiMove:
                                            {
                                                JanggiMoveAnimation janggiMoveAnimation = moveAnimation as JanggiMoveAnimation;
                                                if (duration > 0)
                                                {
                                                    if (this.data.x.v == janggiMoveAnimation.fromX.v && this.data.y.v == janggiMoveAnimation.fromY.v)
                                                    {
                                                        this.transform.SetAsLastSibling();
                                                        Vector2 fromPos = Common.convertXYToLocalPosition(janggiMoveAnimation.fromX.v, janggiMoveAnimation.fromY.v);
                                                        Vector2 destPos = Common.convertXYToLocalPosition(janggiMoveAnimation.toX.v, janggiMoveAnimation.toY.v);
                                                        localPos = Vector2.Lerp(fromPos, destPos, MoveAnimation.getAccelerateDecelerateInterpolation(time / duration));
                                                    }
                                                }
                                                else
                                                {
                                                    Debug.LogError("why duration < 0");
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown moveAnimation: " + moveAnimation);
                                            break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("moveAnimation null");
                                }
                            }
                            this.transform.localPosition = localPos;
                        }
                        // Scale
                        {
                            int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                            float scale = 1;
                            {
                                float PawnScale = 0.65f;
                                float AdvisorScale = 0.65f;
                                float ElephantScale = 0.8f;
                                float HorseScale = 0.8f;
                                float CannonScale = 0.8f;
                                float ChariotScale = 0.8f;
                                float GeneralScale = 1.0f;
                                switch ((StoneHelper.Stones)this.data.piece.v)
                                {
                                    case StoneHelper.Stones.Empty:
                                        break;
                                    case StoneHelper.Stones.GreenPawn1:
                                    case StoneHelper.Stones.GreenPawn2:
                                    case StoneHelper.Stones.GreenPawn3:
                                    case StoneHelper.Stones.GreenPawn4:
                                    case StoneHelper.Stones.GreenPawn5:
                                        scale = PawnScale;
                                        break;
                                    case StoneHelper.Stones.GreenElephant1:
                                    case StoneHelper.Stones.GreenElephant2:
                                        scale = ElephantScale;
                                        break;
                                    case StoneHelper.Stones.GreenHorse1:
                                    case StoneHelper.Stones.GreenHorse2:
                                        scale = HorseScale;
                                        break;
                                    case StoneHelper.Stones.GreenCannon1:
                                    case StoneHelper.Stones.GreenCannon2:
                                        scale = CannonScale;
                                        break;
                                    case StoneHelper.Stones.GreenChariot1:
                                    case StoneHelper.Stones.GreenChariot2:
                                        scale = ChariotScale;
                                        break;
                                    case StoneHelper.Stones.GreenAdvisor1:
                                    case StoneHelper.Stones.GreenAdvisor2:
                                        scale = AdvisorScale;
                                        break;
                                    case StoneHelper.Stones.GreenGeneral:
                                        scale = GeneralScale;
                                        break;

                                    case StoneHelper.Stones.RedPawn1:
                                    case StoneHelper.Stones.RedPawn2:
                                    case StoneHelper.Stones.RedPawn3:
                                    case StoneHelper.Stones.RedPawn4:
                                    case StoneHelper.Stones.RedPawn5:
                                        scale = PawnScale;
                                        break;
                                    case StoneHelper.Stones.RedElephant1:
                                    case StoneHelper.Stones.RedElephant2:
                                        scale = ElephantScale;
                                        break;
                                    case StoneHelper.Stones.RedHorse1:
                                    case StoneHelper.Stones.RedHorse2:
                                        scale = HorseScale;
                                        break;
                                    case StoneHelper.Stones.RedCannon1:
                                    case StoneHelper.Stones.RedCannon2:
                                        scale = CannonScale;
                                        break;
                                    case StoneHelper.Stones.RedChariot1:
                                    case StoneHelper.Stones.RedChariot2:
                                        scale = ChariotScale;
                                        break;
                                    case StoneHelper.Stones.RedAdvisor1:
                                    case StoneHelper.Stones.RedAdvisor2:
                                        scale = AdvisorScale;
                                        break;
                                    case StoneHelper.Stones.RedGeneral:
                                        scale = GeneralScale;
                                        break;

                                    case StoneHelper.Stones.Pawn:
                                        scale = PawnScale;
                                        break;
                                    case StoneHelper.Stones.GreenPawn:
                                        scale = PawnScale;
                                        break;
                                    case StoneHelper.Stones.RedPawn:
                                        scale = PawnScale;
                                        break;
                                    case StoneHelper.Stones.Elephant:
                                        scale = ElephantScale;
                                        break;
                                    case StoneHelper.Stones.Horse:
                                        scale = HorseScale;
                                        break;
                                    case StoneHelper.Stones.Cannon:
                                        scale = CannonScale;
                                        break;
                                    case StoneHelper.Stones.GreenCannon:
                                        scale = CannonScale;
                                        break;
                                    case StoneHelper.Stones.RedCannon:
                                        scale = CannonScale;
                                        break;
                                    case StoneHelper.Stones.Chariot:
                                        scale = ChariotScale;
                                        break;
                                    case StoneHelper.Stones.GreenChariot:
                                        scale = ChariotScale;
                                        break;
                                    case StoneHelper.Stones.RedChariot:
                                        scale = ChariotScale;
                                        break;
                                    case StoneHelper.Stones.Advisor:
                                        scale = AdvisorScale;
                                        break;
                                    case StoneHelper.Stones.General:
                                        scale = GeneralScale;
                                        break;
                                    case StoneHelper.Stones.Green:
                                        scale = PawnScale;
                                        break;
                                    case StoneHelper.Stones.Red:
                                        scale = PawnScale;
                                        break;
                                    default:
                                        Debug.LogError("unknown piece: " + this.data.piece.v);
                                        scale = 1;
                                        break;
                                }
                            }
                            this.transform.localScale = (playerView == 0 ? new Vector3(scale, scale, scale) : new Vector3(scale, -scale, scale));
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
                    // Debug.LogError ("data null");
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // CheckChange
                {
                    // perspective
                    {
                        perspectiveChange.addCallBack(this);
                        perspectiveChange.setData(uiData);
                    }
                }
                dirty = true;
                return;
            }
            // Setting
            if (data is Setting)
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
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().removeCallBack(this);
                // CheckChange
                {
                    // perspective
                    {
                        perspectiveChange.removeCallBack(this);
                        perspectiveChange.setData(null);
                    }
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
                    case UIData.Property.piece:
                        dirty = true;
                        break;
                    case UIData.Property.x:
                        dirty = true;
                        break;
                    case UIData.Property.y:
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
            // Setting
            if (wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
                        break;
                    case Setting.Property.style:
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
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
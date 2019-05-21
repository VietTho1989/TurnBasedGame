using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Shogi.NoneRule;

namespace Shogi
{
    public class NoneRuleInputUI : UIBehavior<NoneRuleInputUI.UIData>
    {

        #region UIData

        public class UIData : InputUI.UIData.Sub
        {

            public VP<ReferenceData<Shogi>> shogi;

            #region Sub

            public abstract class Sub : Data
            {

                public enum Type
                {
                    ClickNone,
                    ClickPos,
                    SetPiece,
                    ClickMove,
                    SetHand,
                    CreateByFen
                }

                public abstract Type getType();

                public abstract bool processEvent(Event e);

            }

            public VP<Sub> sub;

            #endregion

            #region Constructor

            public enum Property
            {
                shogi,
                sub
            }

            public UIData() : base()
            {
                this.shogi = new VP<ReferenceData<Shogi>>(this, (byte)Property.shogi, new ReferenceData<Shogi>(null));
                this.sub = new VP<Sub>(this, (byte)Property.sub, new ClickNoneUI.UIData());
            }

            #endregion

            public override Type getType()
            {
                return Type.NoneRule;
            }

            public override bool processEvent(Event e)
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
                            Debug.LogError("sub null: " + this);
                        }
                    }
                }
                return isProcess;
            }

            public void reset()
            {
                // sub
                {
                    ClickNoneUI.UIData noneUIData = this.sub.newOrOld<ClickNoneUI.UIData>();
                    {

                    }
                    this.sub.v = noneUIData;
                }
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.SHOGI ? 1 : 0;
        }

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {

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

        public ClickNoneUI nonePrefab;
        public ClickPosUI posPrefab;
        public SetPieceUI setPiecePrefab;
        public ClickMoveUI clickMovePrefab;
        public SetHandUI setHandPrefab;
        public CreateByFenUI createByFenPrefab;
        public Transform subContainer;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.shogi.allAddCallBack(this);
                    uiData.sub.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is Shogi)
                {
                    // reset
                    {
                        if (this.data != null)
                        {
                            this.data.reset();
                        }
                        else
                        {
                            Debug.LogError("data null: " + this);
                        }
                    }
                    dirty = true;
                    return;
                }
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case UIData.Sub.Type.ClickNone:
                                {
                                    ClickNoneUI.UIData clickNoneUIData = sub as ClickNoneUI.UIData;
                                    UIUtils.Instantiate(clickNoneUIData, nonePrefab, subContainer);
                                }
                                break;
                            case UIData.Sub.Type.ClickPos:
                                {
                                    ClickPosUI.UIData clickPosUIData = sub as ClickPosUI.UIData;
                                    UIUtils.Instantiate(clickPosUIData, posPrefab, subContainer);
                                }
                                break;
                            case UIData.Sub.Type.SetPiece:
                                {
                                    SetPieceUI.UIData setPieceUIData = sub as SetPieceUI.UIData;
                                    UIUtils.Instantiate(setPieceUIData, setPiecePrefab, subContainer);
                                }
                                break;
                            case UIData.Sub.Type.ClickMove:
                                {
                                    ClickMoveUI.UIData clickMoveUIData = sub as ClickMoveUI.UIData;
                                    UIUtils.Instantiate(clickMoveUIData, clickMovePrefab, subContainer);
                                }
                                break;
                            case UIData.Sub.Type.SetHand:
                                {
                                    SetHandUI.UIData setHandUIData = sub as SetHandUI.UIData;
                                    UIUtils.Instantiate(setHandUIData, setHandPrefab, subContainer);
                                }
                                break;
                            case UIData.Sub.Type.CreateByFen:
                                {
                                    CreateByFenUI.UIData createByFenUIData = sub as CreateByFenUI.UIData;
                                    UIUtils.Instantiate(createByFenUIData, createByFenPrefab, subContainer);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                break;
                        }
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
                    uiData.shogi.allRemoveCallBack(this);
                    uiData.sub.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            {
                if (data is Shogi)
                {
                    return;
                }
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case UIData.Sub.Type.ClickNone:
                                {
                                    ClickNoneUI.UIData clickNoneUIData = sub as ClickNoneUI.UIData;
                                    clickNoneUIData.removeCallBackAndDestroy(typeof(ClickNoneUI));
                                }
                                break;
                            case UIData.Sub.Type.ClickPos:
                                {
                                    ClickPosUI.UIData clickPosUIData = sub as ClickPosUI.UIData;
                                    clickPosUIData.removeCallBackAndDestroy(typeof(ClickPosUI));
                                }
                                break;
                            case UIData.Sub.Type.SetPiece:
                                {
                                    SetPieceUI.UIData setPieceUIData = sub as SetPieceUI.UIData;
                                    setPieceUIData.removeCallBackAndDestroy(typeof(SetPieceUI));
                                }
                                break;
                            case UIData.Sub.Type.ClickMove:
                                {
                                    ClickMoveUI.UIData clickMoveUIData = sub as ClickMoveUI.UIData;
                                    clickMoveUIData.removeCallBackAndDestroy(typeof(ClickMoveUI));
                                }
                                break;
                            case UIData.Sub.Type.SetHand:
                                {
                                    SetHandUI.UIData setHandUIData = sub as SetHandUI.UIData;
                                    setHandUIData.removeCallBackAndDestroy(typeof(SetHandUI));
                                }
                                break;
                            case UIData.Sub.Type.CreateByFen:
                                {
                                    CreateByFenUI.UIData createByFenUIData = sub as CreateByFenUI.UIData;
                                    createByFenUIData.removeCallBackAndDestroy(typeof(CreateByFenUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                break;
                        }
                    }
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
                    case UIData.Property.shogi:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
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
                if (wrapProperty.p is Shogi)
                {
                    return;
                }
                if (wrapProperty.p is UIData.Sub)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
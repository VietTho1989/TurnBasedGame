using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Khet.UseRule
{
    public class ShowUI : UIBehavior<ShowUI.UIData>
    {

        #region UIData

        public class UIData : UseRuleInputUI.UIData.State
        {

            public LP<KhetMove> legalMoves;

            #region Sub

            public abstract class Sub : Data
            {

                public enum Type
                {
                    ClickPiece,
                    ClickDest
                }

                public abstract Type getType();

                public abstract bool processEvent(Event e);

            }

            public VP<Sub> sub;

            #endregion

            #region Constructor

            public enum Property
            {
                legalMoves,
                sub
            }

            public UIData() : base()
            {
                this.legalMoves = new LP<KhetMove>(this, (byte)Property.legalMoves);
                this.sub = new VP<Sub>(this, (byte)Property.sub, new ClickPieceUI.UIData());
            }

            #endregion

            public override Type getType()
            {
                return Type.Show;
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
                            Debug.LogError("sub null");
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Khet ? 1 : 0;
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

        public ClickPieceUI clickPiecePrefab;
        public ClickDestUI clickDestPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
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
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case UIData.Sub.Type.ClickPiece:
                            {
                                ClickPieceUI.UIData clickPieceUIData = sub as ClickPieceUI.UIData;
                                UIUtils.Instantiate(clickPieceUIData, clickPiecePrefab, this.transform);
                            }
                            break;
                        case UIData.Sub.Type.ClickDest:
                            {
                                ClickDestUI.UIData clickDestUIData = sub as ClickDestUI.UIData;
                                UIUtils.Instantiate(clickDestUIData, clickDestPrefab, this.transform);
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
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case UIData.Sub.Type.ClickPiece:
                            {
                                ClickPieceUI.UIData clickPieceUIData = sub as ClickPieceUI.UIData;
                                clickPieceUIData.removeCallBackAndDestroy(typeof(ClickPieceUI));
                            }
                            break;
                        case UIData.Sub.Type.ClickDest:
                            {
                                ClickDestUI.UIData clickDestUIData = sub as ClickDestUI.UIData;
                                clickDestUIData.removeCallBackAndDestroy(typeof(ClickDestUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                            break;
                    }
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
                    case UIData.Property.legalMoves:
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
            if (wrapProperty.p is UIData.Sub)
            {
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
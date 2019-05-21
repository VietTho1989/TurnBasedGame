using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
    public class NoneRuleInputUI : UIBehavior<NoneRuleInputUI.UIData>
    {

        #region UIData

        public class UIData : InputUI.UIData.Sub
        {

            public VP<ReferenceData<Solitaire>> solitaire;

            #region Constructor

            public enum Property
            {
                solitaire
            }

            public UIData() : base()
            {
                this.solitaire = new VP<ReferenceData<Solitaire>>(this, (byte)Property.solitaire, new ReferenceData<Solitaire>(null));
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

                }
                return isProcess;
            }

            public override void onClickCard(Card card)
            {
                // TODO Can hoan thien
            }

            public override void onClickPile(Pile pile)
            {
                // TODO Can hoan thien
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Solitaire ? 1 : 0;
        }

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Solitaire solitaire = this.data.solitaire.v.data;
                    if (solitaire != null)
                    {

                    }
                    else
                    {
                        Debug.LogError("solitaire null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public override void onAddCallBack<T>(T data)
        {
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if (WrapProperty.checkError(wrapProperty))
            {
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
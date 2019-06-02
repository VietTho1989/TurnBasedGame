using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Rubiks
{
    public class BoardUI : UIBehavior<BoardUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<Rubiks>> rubiks;

            #region Constructor

            public enum Property
            {
                rubiks
            }

            public UIData() : base()
            {
                this.rubiks = new VP<ReferenceData<Rubiks>>(this, (byte)Property.rubiks, new ReferenceData<Rubiks>(null));
            }

            #endregion

        }

        #endregion

        #region Refresh

        public Text tvRubiks;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Rubiks rubiks = this.data.rubiks.v.data;
                    if (rubiks != null)
                    {
                        if (tvRubiks != null)
                        {
                            tvRubiks.text = rubiks.lastMoveIndex.v + " " + Rubiks.convertToCube(rubiks).printCube();
                        }
                        else
                        {
                            Debug.LogError("tvRubiks null");
                        }
                    }
                    else
                    {
                        Debug.LogError("rubiks null");
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

        public override void onAddCallBack<T>(T data)
        {
            if(data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.rubiks.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if(data is Rubiks)
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
                    uiData.rubiks.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            if (data is Rubiks)
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
                    case UIData.Property.rubiks:
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
            if (wrapProperty.p is Rubiks)
            {
                switch ((Rubiks.Property)wrapProperty.n)
                {
                    case Rubiks.Property.faces:
                        dirty = true;
                        break;
                    case Rubiks.Property.dimension:
                        dirty = true;
                        break;
                    case Rubiks.Property.lastMoveId:
                        break;
                    case Rubiks.Property.lastMoveIndex:
                        break;
                    case Rubiks.Property.canFinish:
                        break;
                    default:
                        break;
                }
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}
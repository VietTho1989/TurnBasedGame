using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Rubiks
{
    /**
     * solve problem in different thread
     * */
    public class RubiksUpdate : UpdateBehavior<Rubiks>
    {

        #region UpdateData

        public class UpdateData : Data
        {

            #region State

            public enum State
            {
                None,
                Solve,
                Finish
            }

            public VP<State> state;

            #endregion

            #region Constructor

            public enum Property
            {
                state
            }

            public UpdateData() : base()
            {
                this.state = new VP<State>(this, (byte)Property.state, State.None);
            }

            #endregion

        }

        #endregion

        #region Update

        public override void update()
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
            return false;
        }

        private UpdateData updateData = new UpdateData();

        void Awake()
        {
            updateData.addCallBack(this);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            updateData.removeCallBack(this);
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
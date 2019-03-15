using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
    public class SwapRequestStateAccept : SwapRequest.State
    {

        public VP<float> time;

        public VP<float> duration;

        #region Constructor

        public enum Property
        {
            time,
            duration
        }

        public SwapRequestStateAccept() : base()
        {
            this.time = new VP<float>(this, (byte)Property.time, 0);
            this.duration = new VP<float>(this, (byte)Property.duration, 1);
        }

        #endregion

        public override Type getType()
        {
            return Type.Accept;
        }

    }
}
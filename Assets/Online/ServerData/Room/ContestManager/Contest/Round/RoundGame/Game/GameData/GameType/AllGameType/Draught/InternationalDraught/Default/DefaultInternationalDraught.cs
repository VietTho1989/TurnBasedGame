using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught
{
    public class DefaultInternationalDraught : DefaultGameType
    {

        #region variant

        public VP<int> variant;

        public void requestChangeVariant(uint userId, int newVariant)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeVariant(userId, newVariant);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is DefaultInternationalDraughtIdentity)
                        {
                            DefaultInternationalDraughtIdentity defaultInternationalDraughtIdentity = dataIdentity as DefaultInternationalDraughtIdentity;
                            defaultInternationalDraughtIdentity.requestChangeVariant(userId, newVariant);
                        }
                        else
                        {
                            Debug.LogError("Why isn't correct identity");
                        }
                    }
                    else
                    {
                        Debug.LogError("cannot find dataIdentity");
                    }
                }
            }
            else
            {
                Debug.LogError("You cannot request: " + this);
            }
        }

        public void changeVariant(uint userId, int newVariant)
        {
            if (GameManager.Match.ContestManagerStateLobby.IsCanChange(this, userId))
            {
                this.variant.v = newVariant;
            }
            else
            {
                Debug.LogError("cannot change config: " + this);
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            variant
        }

        public DefaultInternationalDraught() : base()
        {
            this.variant = new VP<int>(this, (byte)Property.variant, (int)Common.Variant_Type.Killer);
        }

        #endregion

        public override GameType.Type getType()
        {
            return GameType.Type.InternationalDraught;
        }

        public override GameType makeDefaultGameType()
        {
            InternationalDraught startInternationalDraught = null;
            {
                int variantType = this.variant.v;
                startInternationalDraught = Core.unityMakeDefaultPosition(variantType, InternationalDraught.StartFen);
                // startInternationalDraught = Core.unityMakeDefaultPosition(variantType, "B:W26,31,32,34-36,38,40-45,47,50:B2-4,6,8,9,11-17,19,20,24,25,30");
            }
            return startInternationalDraught;
        }

    }
}
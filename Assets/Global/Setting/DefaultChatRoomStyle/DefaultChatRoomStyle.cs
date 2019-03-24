using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class DefaultChatRoomStyle : Data
{

    public enum Type
    {
        Last,
        Always
    }

    public abstract Type getType();

    #region visibility

    public abstract ContestManagerBtnChatUI.UIData.Visibility getVisibility();

    public abstract void setLastVisibility(ContestManagerBtnChatUI.UIData.Visibility visibility);

    #endregion

    #region style

    public abstract ContestManagerBtnChatUI.UIData.Style getStyle();

    public abstract void setLastStyle(ContestManagerBtnChatUI.UIData.Style style);

    #endregion

    #region UIData

    public abstract class UIData : Data
    {

        public abstract Type getType();

    }

    #endregion

}
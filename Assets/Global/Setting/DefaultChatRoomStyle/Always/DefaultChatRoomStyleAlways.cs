using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefaultChatRoomStyleAlways : DefaultChatRoomStyle
{

    public VP<ContestManagerBtnChatUI.UIData.Visibility> visibility;

    public VP<ContestManagerBtnChatUI.UIData.Style> style;

    #region Constructor

    public enum Property
    {
        visibility,
        style
    }

    public DefaultChatRoomStyleAlways() : base()
    {
        this.visibility = new VP<ContestManagerBtnChatUI.UIData.Visibility>(this, (byte)Property.visibility, ContestManagerBtnChatUI.UIData.Visibility.Hide);
        this.style = new VP<ContestManagerBtnChatUI.UIData.Style>(this, (byte)Property.style, ContestManagerBtnChatUI.UIData.Style.Overlay);
    }

    #endregion

    public override Type getType()
    {
        return Type.Always;
    }

    #region visibility

    public override ContestManagerBtnChatUI.UIData.Visibility getVisibility()
    {
        return this.visibility.v;
    }

    public override void setLastVisibility(ContestManagerBtnChatUI.UIData.Visibility visibility)
    {

    }

    #endregion

    #region style

    public override ContestManagerBtnChatUI.UIData.Style getStyle()
    {
        return this.style.v;
    }

    public override void setLastStyle(ContestManagerBtnChatUI.UIData.Style style)
    {

    }

    #endregion

}
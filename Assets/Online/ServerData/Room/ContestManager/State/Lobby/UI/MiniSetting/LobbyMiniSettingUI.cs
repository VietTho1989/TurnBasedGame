using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class LobbyMiniSettingUI : UIHaveTransformDataBehavior<LobbyMiniSettingUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<ContestManagerStateLobby>> contestManagerStateLobby;

            public VP<GameFactoryUI.UIData> gameFactory;

            #region Constructor

            public enum Property
            {
                contestManagerStateLobby,
                gameFactory
            }

            public UIData() : base()
            {
                this.contestManagerStateLobby = new VP<ReferenceData<ContestManagerStateLobby>>(this, (byte)Property.contestManagerStateLobby, new ReferenceData<ContestManagerStateLobby>(null));
                // gameFactory
                {
                    this.gameFactory = new VP<GameFactoryUI.UIData>(this, (byte)Property.gameFactory, new GameFactoryUI.UIData());
                    this.gameFactory.v.useRule.v = null;
                    this.gameFactory.v.timeControl.v = null;
                }
            }

            #endregion

        }

        #endregion

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    ContestManagerStateLobby contestManagerStateLobby = this.data.contestManagerStateLobby.v.data;
                    if (contestManagerStateLobby != null)
                    {
                        // gameFactory
                        {
                            GameFactoryUI.UIData gameFactoryUIData = this.data.gameFactory.v;
                            if (gameFactoryUIData != null)
                            {
                                // origin
                                {
                                    GameFactory origin = null;
                                    {
                                        // TODO Can hoan thien
                                    }
                                    gameFactoryUIData.editGameFactory.v.origin.v = new ReferenceData<GameFactory>(origin);
                                }
                                // canEdit?
                                {
                                    bool canEdit = false;
                                    {
                                        uint profileId = Server.getProfileUserId(contestManagerStateLobby);
                                        if (contestManagerStateLobby.isCanChange(profileId))
                                        {
                                            canEdit = true;
                                        }
                                    }
                                    gameFactoryUIData.editGameFactory.v.canEdit.v = canEdit;
                                }
                            }
                            else
                            {
                                // Debug.LogError("contentFactoryUIData null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("contestManagerStateLobby null");
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
            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
        }

        #endregion

    }
}
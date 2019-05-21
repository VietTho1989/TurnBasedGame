using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class LobbyPlayer : Data
    {

        public VP<int> playerIndex;

        public VP<GamePlayer.Inform> inform;

        #region ready

        public VP<bool> isReady;

        public bool isNeedSetReady()
        {
            bool ret = false;
            {
                // isHuman?
                if (this.inform.v is Human)
                {
                    Human human = this.inform.v as Human;
                    // is not admin?
                    RoomUser roomUser = Room.findUser(human.playerId.v, this);
                    if (roomUser != null)
                    {
                        if (roomUser.role.v == RoomUser.Role.NORMAL)
                        {
                            ret = true;
                        }
                    }
                    else
                    {
                        Debug.LogError("roomUser null: " + this);
                    }
                }
            }
            return ret;
        }

        public bool isCanSetReady(uint userId, bool newReady)
        {
            bool ret = false;
            {
                if (this.isReady.v != newReady)
                {
                    // check is human
                    if (this.inform.v is Human)
                    {
                        Human human = this.inform.v as Human;
                        // check correct userId
                        if (human.playerId.v == userId)
                        {
                            // check is not admin
                            RoomUser roomUser = Room.findUser(userId, this);
                            if (roomUser != null)
                            {
                                if (roomUser.role.v == RoomUser.Role.NORMAL)
                                {
                                    // check contestManagerStateLobbyState correct
                                    ContestManagerStateLobby contestManagerStateLobby = this.findDataInParent<ContestManagerStateLobby>();
                                    if (contestManagerStateLobby != null)
                                    {
                                        if (contestManagerStateLobby.state.v.getType() == ContestManagerStateLobby.State.Type.Normal)
                                        {
                                            ret = true;
                                        }
                                        else
                                        {
                                            Debug.LogError("already start: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("contestManagerStateLobby null: " + this);
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("roomUser null: " + this);
                            }
                        }
                    }
                }
            }
            return ret;
        }

        public void requestSetReady(uint userId, bool newReady)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.setReady(userId, newReady);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is LobbyPlayerIdentity)
                        {
                            LobbyPlayerIdentity lobbyPlayerIdentity = dataIdentity as LobbyPlayerIdentity;
                            lobbyPlayerIdentity.requestSetReady(userId, newReady);
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
                Debug.LogError("You cannot request");
            }
        }

        public void setReady(uint userId, bool newReady)
        {
            if (isCanSetReady(userId, newReady))
            {
                this.isReady.v = newReady;
            }
            else
            {
                Debug.LogError("cannot set ready: " + userId + "; " + newReady);
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            playerIndex,
            inform,
            isReady
        }

        public LobbyPlayer() : base()
        {
            this.playerIndex = new VP<int>(this, (byte)Property.playerIndex, 0);
            this.inform = new VP<GamePlayer.Inform>(this, (byte)Property.inform, new EmptyInform());
            this.isReady = new VP<bool>(this, (byte)Property.isReady, false);
        }

        #endregion

        #region admin change human

        public void requestAdminChangeHuman(uint userId, uint humanId)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.adminChangeHuman(userId, humanId);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is LobbyPlayerIdentity)
                        {
                            LobbyPlayerIdentity lobbyPlayerIdentity = dataIdentity as LobbyPlayerIdentity;
                            lobbyPlayerIdentity.requestAdminChangeHuman(userId, humanId);
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
                Debug.LogError("You cannot request");
            }
        }

        public void adminChangeHuman(uint userId, uint humanId)
        {
            // Check can change
            bool canChange = true;
            {
                // is admin
                if (canChange)
                {
                    // Find
                    bool isAdmin = false;
                    {
                        RoomUser admin = Room.findAdmin(this);
                        if (admin != null)
                        {
                            if (admin.isInsideRoom())
                            {
                                Human human = admin.inform.v as Human;
                                if (human.playerId.v == userId)
                                {
                                    isAdmin = true;
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("admin null: " + this);
                        }
                    }
                    // Process
                    if (!isAdmin)
                    {
                        canChange = false;
                    }
                }
                // is inside room
                if (canChange)
                {
                    // Find
                    bool isInsideRoom = false;
                    {
                        RoomUser roomUser = Room.findUser(humanId, this);
                        if (roomUser != null)
                        {
                            if (roomUser.isInsideRoom())
                            {
                                isInsideRoom = true;
                            }
                            else
                            {
                                Debug.LogError("roomUser not inside room anymore: " + roomUser + "; " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("roomUser null: " + this);
                        }
                    }
                    // Process
                    if (!isInsideRoom)
                    {
                        canChange = false;
                    }
                }
                // correct state
                if (canChange)
                {
                    // Find
                    bool isCorrectState = false;
                    {
                        ContestManagerStateLobby contestManagerStateLobby = this.findDataInParent<ContestManagerStateLobby>();
                        if (contestManagerStateLobby != null)
                        {
                            if (contestManagerStateLobby.state.v is Lobby.StateNormal)
                            {
                                isCorrectState = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("contestManagerStateLobby null: " + this);
                        }
                    }
                    // Process
                    if (!isCorrectState)
                    {
                        Debug.LogError("not correct state: " + this);
                        canChange = false;
                    }
                }
                // already set
                if (canChange)
                {
                    // Find
                    bool alreadySet = false;
                    {
                        if (this.inform.v is Human)
                        {
                            Human human = this.inform.v as Human;
                            if (human.playerId.v == humanId)
                            {
                                alreadySet = true;
                            }
                        }
                    }
                    // Process
                    if (alreadySet)
                    {
                        canChange = false;
                    }
                }
            }
            // Change
            if (canChange)
            {
                // Find Human
                Human human = null;
                {
                    // Find old
                    if (this.inform.v is Human)
                    {
                        human = this.inform.v as Human;
                    }
                    // Make new
                    if (human == null)
                    {
                        human = new Human();
                        {
                            human.uid = this.inform.makeId();
                        }
                        this.inform.v = human;
                    }
                }
                // Update
                {
                    human.playerId.v = humanId;
                }
                this.isReady.v = false;
            }
        }

        #endregion

        #region admin change empty

        public void requestAdminChangeEmpty(uint userId)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.adminChangeEmpty(userId);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is LobbyPlayerIdentity)
                        {
                            LobbyPlayerIdentity lobbyPlayerIdentity = dataIdentity as LobbyPlayerIdentity;
                            lobbyPlayerIdentity.requestAdminChangeEmpty(userId);
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
                Debug.LogError("You cannot request");
            }
        }

        public void adminChangeEmpty(uint userId)
        {
            // Find
            bool canChange = true;
            {
                // is admin
                if (canChange)
                {
                    // Find
                    bool isAdmin = false;
                    {
                        RoomUser admin = Room.findAdmin(this);
                        if (admin != null)
                        {
                            if (admin.isInsideRoom())
                            {
                                Human human = admin.inform.v as Human;
                                if (human.playerId.v == userId)
                                {
                                    isAdmin = true;
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("admin null: " + this);
                        }
                    }
                    // Process
                    if (!isAdmin)
                    {
                        canChange = false;
                    }
                }
                // correct state
                if (canChange)
                {
                    // Find
                    bool isCorrectState = false;
                    {
                        ContestManagerStateLobby contestManagerStateLobby = this.findDataInParent<ContestManagerStateLobby>();
                        if (contestManagerStateLobby != null)
                        {
                            if (contestManagerStateLobby.state.v is Lobby.StateNormal)
                            {
                                isCorrectState = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("contestManagerStateLobby null: " + this);
                        }
                    }
                    // Process
                    if (!isCorrectState)
                    {
                        Debug.LogError("not correct state: " + this);
                        canChange = false;
                    }
                }
                // already set
                if (canChange)
                {
                    // Find
                    bool alreadySet = false;
                    {
                        if (this.inform.v is EmptyInform)
                        {
                            alreadySet = true;
                        }
                    }
                    // Process
                    if (alreadySet)
                    {
                        canChange = false;
                    }
                }
            }
            // Process
            if (canChange)
            {
                if (!(this.inform.v is EmptyInform))
                {
                    EmptyInform emptyInform = new EmptyInform();
                    {
                        emptyInform.uid = this.inform.makeId();
                    }
                    this.inform.v = emptyInform;
                }
                this.isReady.v = false;
            }
            else
            {
                Debug.LogError("cannot change: " + userId + "; " + this);
            }
        }

        #endregion

        #region admin change computer

        public void requestAdminChangeComputer(uint userId, Computer computer)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.adminChangeComputer(userId, computer);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is LobbyPlayerIdentity)
                        {
                            LobbyPlayerIdentity lobbyPlayerIdentity = dataIdentity as LobbyPlayerIdentity;
                            lobbyPlayerIdentity.requestAdminChangeComputer(userId, computer);
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
                Debug.LogError("You cannot request");
            }
        }

        public void adminChangeComputer(uint userId, Computer computer)
        {
            // Find
            bool canChange = true;
            {
                // is admin
                if (canChange)
                {
                    // Find
                    bool isAdmin = false;
                    {
                        RoomUser admin = Room.findAdmin(this);
                        if (admin != null)
                        {
                            if (admin.isInsideRoom())
                            {
                                Human human = admin.inform.v as Human;
                                if (human.playerId.v == userId)
                                {
                                    isAdmin = true;
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("admin null: " + this);
                        }
                    }
                    // Process
                    if (!isAdmin)
                    {
                        canChange = false;
                    }
                }
                // correct state
                if (canChange)
                {
                    // Find
                    bool isCorrectState = false;
                    {
                        ContestManagerStateLobby contestManagerStateLobby = this.findDataInParent<ContestManagerStateLobby>();
                        if (contestManagerStateLobby != null)
                        {
                            if (contestManagerStateLobby.state.v is Lobby.StateNormal)
                            {
                                isCorrectState = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("contestManagerStateLobby null: " + this);
                        }
                    }
                    // Process
                    if (!isCorrectState)
                    {
                        Debug.LogError("not correct state: " + this);
                        canChange = false;
                    }
                }
            }
            // Process
            if (canChange)
            {
                {
                    Computer newComputer = DataUtils.cloneData(computer) as Computer;
                    {
                        newComputer.uid = this.inform.makeId();
                    }
                    this.inform.v = newComputer;
                }
                this.isReady.v = false;
            }
            else
            {
                Debug.LogError("cannot change: " + userId + "; " + this);
            }
        }

        #endregion

        #region normal set

        public bool isNormalCanSet(uint userId)
        {
            bool canSet = true;
            {
                // check inform is empty
                if (canSet)
                {
                    if (this.inform.v.getType() != GamePlayer.Inform.Type.None)
                    {
                        canSet = false;
                    }
                }
                // check user inside room
                if (canSet)
                {
                    // Find
                    bool isInsideRoom = false;
                    {
                        RoomUser roomUser = Room.findUser(userId, this);
                        if (roomUser != null)
                        {
                            if (roomUser.isInsideRoom())
                            {
                                isInsideRoom = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("roomUser null: " + this);
                        }
                    }
                    // Process
                    if (!isInsideRoom)
                    {
                        canSet = false;
                    }
                    else
                    {
                        Debug.LogError("not inside room: " + this);
                    }
                }
                // correct state
                if (canSet)
                {
                    // Find
                    bool isCorrectState = false;
                    {
                        ContestManagerStateLobby contestManagerStateLobby = this.findDataInParent<ContestManagerStateLobby>();
                        if (contestManagerStateLobby != null)
                        {
                            if (contestManagerStateLobby.state.v is Lobby.StateNormal)
                            {
                                isCorrectState = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("contestManagerStateLobby null: " + this);
                        }
                    }
                    // Process
                    if (!isCorrectState)
                    {
                        Debug.LogError("not correct state: " + this);
                        canSet = false;
                    }
                }
            }
            return canSet;
        }

        public void requestNormaSet(uint userId)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.normalSet(userId);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is LobbyPlayerIdentity)
                        {
                            LobbyPlayerIdentity lobbyPlayerIdentity = dataIdentity as LobbyPlayerIdentity;
                            lobbyPlayerIdentity.requestNormalSet(userId);
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
                Debug.LogError("You cannot request");
            }
        }

        public void normalSet(uint userId)
        {
            if (isNormalCanSet(userId))
            {
                Human human = new Human();
                {
                    human.uid = this.inform.makeId();
                    human.playerId.v = userId;
                }
                this.inform.v = human;
            }
            else
            {
                Debug.LogError("normal cannot set: " + userId + "; " + this);
            }
        }

        #endregion

        #region normal empty

        public bool isNormalCanEmpty(uint userId)
        {
            bool canEmpty = true;
            {
                // check inform is empty
                if (canEmpty)
                {
                    canEmpty = false;
                    if (this.inform.v.getType() == GamePlayer.Inform.Type.Human)
                    {
                        Human human = this.inform.v as Human;
                        if (human.playerId.v == userId)
                        {
                            canEmpty = true;
                        }
                    }
                }
                // check user inside room
                if (canEmpty)
                {
                    // Find
                    bool isInsideRoom = false;
                    {
                        RoomUser roomUser = Room.findUser(userId, this);
                        if (roomUser != null)
                        {
                            if (roomUser.isInsideRoom())
                            {
                                isInsideRoom = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("roomUser null: " + this);
                        }
                    }
                    // Process
                    if (!isInsideRoom)
                    {
                        canEmpty = false;
                    }
                    else
                    {
                        Debug.LogError("not inside room: " + this);
                    }
                }
                // correct state
                if (canEmpty)
                {
                    // Find
                    bool isCorrectState = false;
                    {
                        ContestManagerStateLobby contestManagerStateLobby = this.findDataInParent<ContestManagerStateLobby>();
                        if (contestManagerStateLobby != null)
                        {
                            if (contestManagerStateLobby.state.v is Lobby.StateNormal)
                            {
                                isCorrectState = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("contestManagerStateLobby null: " + this);
                        }
                    }
                    // Process
                    if (!isCorrectState)
                    {
                        Debug.LogError("not correct state: " + this);
                        canEmpty = false;
                    }
                }
            }
            return canEmpty;
        }

        public void requestNormaEmpty(uint userId)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.normalEmpty(userId);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is LobbyPlayerIdentity)
                        {
                            LobbyPlayerIdentity lobbyPlayerIdentity = dataIdentity as LobbyPlayerIdentity;
                            lobbyPlayerIdentity.requestNormalEmpty(userId);
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
                Debug.LogError("You cannot request");
            }
        }

        public void normalEmpty(uint userId)
        {
            if (isNormalCanEmpty(userId))
            {
                EmptyInform emptyInform = new EmptyInform();
                {
                    emptyInform.uid = this.inform.makeId();
                }
                this.inform.v = emptyInform;
            }
            else
            {
                Debug.LogError("normal cannot set: " + userId + "; " + this);
            }
        }

        #endregion

    }
}
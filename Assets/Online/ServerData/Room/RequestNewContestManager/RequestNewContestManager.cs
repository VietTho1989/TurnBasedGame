using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class RequestNewContestManager : Data
    {

        #region State

        public abstract class State : Data
        {

            public enum Type
            {
                None,
                Ask,
                Accept
            }

            public abstract Type getType();

        }

        public VP<State> state;

        #endregion

        #region Constructor

        public enum Property
        {
            state
        }

        public RequestNewContestManager() : base()
        {
            this.state = new VP<State>(this, (byte)Property.state, new RequestNewContestManagerStateNone());
        }

        #endregion

        public static HashSet<uint> WhoCanAsk(Data data)
        {
            HashSet<uint> ret = new HashSet<uint>();
            {
                if (data != null)
                {
                    RequestNewContestManager requestNewContestManager = data.findDataInParent<RequestNewContestManager>();
                    if (requestNewContestManager != null)
                    {
                        // Add admin
                        {
                            RoomUser admin = Room.findAdmin(requestNewContestManager);
                            if (admin != null)
                            {
                                Human human = admin.inform.v;
                                if (human != null)
                                {
                                    ret.Add(human.playerId.v);
                                }
                                else
                                {
                                    Debug.LogError("human null: " + data);
                                }
                            }
                            else
                            {
                                Debug.LogError("admin null: " + data);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("requestNewContestManager null: " + data);
                    }
                }
                else
                {
                    Debug.LogError("data null");
                }
            }
            return ret;
        }

        public static bool IsCanMakeNewContestManagerWithoutRequestState(Data data)
        {
            if (data != null)
            {
                Room room = data.findDataInParent<Room>();
                if (room != null)
                {
                    // Find
                    bool allContestManagerEnd = true;
                    {
                        foreach (ContestManager contestManager in room.contestManagers.vs)
                        {
                            // check contestManager end
                            bool isEnd = false;
                            {
                                if (contestManager.state.v is ContestManagerStatePlay)
                                {
                                    ContestManagerStatePlay contestManagerStatePlay = contestManager.state.v as ContestManagerStatePlay;
                                    if (contestManagerStatePlay.state.v is ContestManagerStatePlayEnd)
                                    {
                                        isEnd = true;
                                    }
                                }
                            }
                            // Process
                            if (!isEnd)
                            {
                                allContestManagerEnd = false;
                                break;
                            }
                        }
                    }
                    // Process
                    if (allContestManagerEnd)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    Debug.LogError("room null: " + data);
                    return false;
                }
            }
            else
            {
                Debug.LogError("data null: " + data);
                return false;
            }
        }

    }
}
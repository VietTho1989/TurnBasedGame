using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RequestChange
{

    #region UIData

    public abstract class UIData<T> : Data
    {

        public abstract RequestChangeUpdate<T>.UpdateData getUpdate();

        public abstract void setShowDifferent(bool showDifferent);

        public abstract void setCompare(T compare);

    }

    #endregion

    public static void RefreshUI<T, K>(UIData<T> requestChange, EditData<K> editData, Server.State.Type serverState, bool needReset, Func<K, T> getValue) where K : Data
    {
        if (editData != null)
        {
            if (getValue != null)
            {
                if (requestChange != null)
                {
                    K show = editData.show.v.data;
                    K compare = editData.compare.v.data;
                    if (show != null)
                    {
                        // update
                        RequestChangeUpdate<T>.UpdateData updateData = requestChange.getUpdate();
                        if (updateData != null)
                        {
                            updateData.origin.v = getValue(show);
                            updateData.canRequestChange.v = editData.canEdit.v;
                            updateData.serverState.v = serverState;
                        }
                        else
                        {
                            Debug.LogError("updateData null");
                        }
                        // compare
                        {
                            if (compare != null)
                            {
                                requestChange.setShowDifferent(true);
                                requestChange.setCompare(getValue(compare));
                            }
                            else
                            {
                                requestChange.setShowDifferent(false);
                            }
                        }
                        // reset
                        if (needReset)
                        {
                            updateData.current.v = getValue(show);
                            updateData.changeState.v = Data.ChangeState.None;
                        }
                    }
                    else
                    {
                        Debug.LogError("show null");
                    }
                }
                else
                {
                    Debug.LogError("requestChange null");
                }
            }
            else
            {
                Debug.LogError("getValue null");
            }
        }
        else
        {
            Debug.LogError("editData null");
        }
    }

}
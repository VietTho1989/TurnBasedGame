using UnityEngine;
using UnityEngine.UI;
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

    public static Server.State.Type GetServerState<K>(EditData<K> editData) where K : Data
    {
        Server.State.Type serverState = Server.State.Type.Connect;
        {
            if (editData != null)
            {
                K show = editData.show.v.data;
                if (show != null)
                {
                    Server server = show.findDataInParent<Server>();
                    if (server != null)
                    {
                        if (server.state.v != null)
                        {
                            serverState = server.state.v.getType();
                        }
                        else
                        {
                            Debug.LogError("server state null");
                        }
                    }
                    else
                    {
                        // Debug.LogError("server null");
                    }
                }
                else
                {
                    // Debug.LogError("show null");
                }
            }
            else
            {
                // Debug.LogError("editData null");
            }
        }
        return serverState;
    }

    public static void ShowDifferentTitle<K>(Text lbTitle, EditData<K> editData) where K : Data
    {
        if (lbTitle != null)
        {
            bool isDifferent = false;
            {
                if (editData != null)
                {
                    K show = editData.show.v.data;
                    if (show != null)
                    {
                        if (editData.compareOtherType.v.data != null)
                        {
                            if (editData.compareOtherType.v.data.GetType() != show.GetType())
                            {
                                isDifferent = true;
                            }
                        }
                    }
                    else
                    {
                        // Debug.LogError("show null");
                    }
                }
                else
                {
                    // Debug.LogError("editData null");
                }
            }
            lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
        }
        else
        {
            Debug.LogError("lbTitle null");
        }
    }

    #region refreshUI

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
                        // Debug.LogError("show null");
                    }
                }
                else
                {
                    // Debug.LogError("requestChange null");
                }
            }
            else
            {
                // Debug.LogError("getValue null");
            }
        }
        else
        {
            // Debug.LogError("editData null");
        }
    }

    public static void RefreshUIWithCanEdit<T, K>(UIData<T> requestChange, EditData<K> editData, Server.State.Type serverState, bool needReset, Func<K, T> getValue, bool canEdit) where K : Data
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
                            updateData.canRequestChange.v = canEdit;
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

    public static void RefreshUINotDifferent<T, K>(UIData<T> requestChange, EditData<K> editData, Server.State.Type serverState, bool needReset, Func<K, T> getValue, T resetValue) where K : Data
    {
        if (editData != null)
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
                        updateData.origin.v = (getValue != null ? getValue(show) : resetValue);
                        updateData.canRequestChange.v = editData.canEdit.v;
                        updateData.serverState.v = serverState;
                    }
                    else
                    {
                        Debug.LogError("updateData null");
                    }
                    // compare
                    {
                        requestChange.setShowDifferent(false);
                    }
                    // reset
                    if (needReset)
                    {
                        updateData.current.v = resetValue;
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
            Debug.LogError("editData null");
        }
    }

    #endregion

}
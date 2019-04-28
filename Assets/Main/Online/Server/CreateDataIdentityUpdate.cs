using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class CreateDataIdentityUpdate : UpdateBehavior<Server>
{
    public Dictionary<System.Type, DataIdentity> prefabDict = new Dictionary<System.Type, DataIdentity>();

    public override void onBeforeSetData(Server newData)
    {
        base.onBeforeSetData(newData);
        if (newData != null)
        {
            prefabDict.Clear();
            ServerManager serverManager = ServerManager.instance;
            if (serverManager != null)
            {
                foreach (GameObject prefab in serverManager.spawnPrefabs)
                {
                    if (prefab != null)
                    {
                        DataIdentity dataIdentity = prefab.GetComponent<DataIdentity>();
                        if (dataIdentity != null)
                        {
                            System.Type dataType = dataIdentity.getNetData().getDataType();
                            if (!prefabDict.ContainsKey(dataType))
                            {
                                prefabDict.Add(dataType, dataIdentity);
                            }
                            else
                            {
                                Debug.LogError("why already contain type: " + dataType + "; " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("dataIdentity null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("prefab null: " + this);
                    }
                }
            }
            else
            {
                Debug.LogError("serverManager null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    private DataIdentity getPrefabForDataFromDict(Data data)
    {
        DataIdentity dataIdentity = null;
        if (data != null)
        {
            if (!prefabDict.TryGetValue(data.GetType(), out dataIdentity))
            {
                // Debug.LogError ("Cannot find prefab: " + data + "; " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
        return dataIdentity;
    }

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
                Debug.LogError("data null: " + this);
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
        // Check can make dataIdentity
        bool canMake = true;
        {
            if (data.p != null)
            {
                if (data.p.ni == 0)
                {
                    // Debug.LogError ("Don't need keep dataIdentity");
                    canMake = false;
                }
            }
        }
        // Make
        if (canMake)
        {
            createDataIdentity(data);
            data.addCallBackAllChildren(this);
        }
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        removeDataIdentity(data);
        data.removeCallBackAllChildren(this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (Generic.IsAddCallBackInterface<T>())
        {
            ValueChangeUtils.replaceCallBack(this, syncs);
        }
    }

    #endregion

    #region getPrefab

    public DataIdentity getPrefabForData(Data data)
    {
        DataIdentity dataIdentity = getPrefabForDataFromDict(data);
        if (dataIdentity != null)
        {
            // Debug.Log ("find dataIdentity from dict: " + data + "; " + dataIdentity + "; " + this);
            return dataIdentity;
        }
        else
        {
            // Debug.Log ("Cannot find dataIdentity from dict: " + data + "; " + this);
            return null;
        }
    }

    private void createDataIdentity(Data data)
    {
        // Debug.Log ("createDataIdentity: " + data);
        DataIdentity dataPrefab = getPrefabForData(data);
        if (dataPrefab != null)
        {
            DataIdentity netObject = GameObject.Instantiate<DataIdentity>(dataPrefab);
            {
                netObject.setNewServerData(data);
                netObject.enabled = true;
            }
            // Spawn
            NetworkServer.Spawn(netObject.gameObject);
        }
        else
        {
            // Debug.Log ("dataPrefab null");
        }
    }

    public void removeDataIdentity(Data data)
    {
        // Search dataIdentity in callBack
        DataIdentity dataIdentity = null;
        for (int i = 0; i < data.callBacks.Count; i++)
        {
            ValueChangeCallBack callBack = data.callBacks[i];
            if (callBack is DataIdentity)
            {
                data.removeCallBack(callBack);
                dataIdentity = callBack as DataIdentity;
                break;
            }
        }
        if (dataIdentity != null)
        {
            // Debug.Log ("Destroy dataIdentity: " + data);
            NetworkServer.Destroy(dataIdentity.gameObject);
        }
        else
        {
            // Debug.Log ("Why cannot find dataIdentity to remove: " + data);
        }
    }

    #endregion

}
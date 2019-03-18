using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/** TODO Sau nay can co layerIndex cho cac thanh phan*/
public abstract class UIBehavior<K> : GameBehavior<K>, TrashMan.DespawnInterface, DirtyInterface, HaveTransformInterface where K : Data
{

    private bool Dirty = true;

    public bool dirty
    {
        get
        {
            return Dirty;
        }
        set
        {
            // Debug.LogError ("setDirty: " + value + "; " + this);
            Dirty = value;
            if (this)
            {
                if (this.isShouldDisableUpdate())
                {
                    this.enabled = Dirty;
                }
            }
        }
    }

    public void makeDirty()
    {
        dirty = true;
    }

    public abstract bool isShouldDisableUpdate();

    public virtual void Awake()
    {
        dirty = true;
        // this.transformData.update(this.transform);
        refresh();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        dirty = true;
    }

    public abstract void refresh();

    public virtual void FixedUpdate()
    {

        // var watch = System.Diagnostics.Stopwatch.StartNew();
        refresh();
        // watch.Stop();
        // var elapsedMs = watch.ElapsedMilliseconds;
        // Debug.Log ("UIBehaviorUpdate: " + elapsedMs + "; " + this);
    }

    public virtual void LateUpdate()
    {
        refresh();
    }

    public virtual void OnGUI()
    {
        // updateTransformData();
        refresh();
    }

    public virtual void OnPreCull()
    {
        refresh();
    }

    public override void onAfterSetData()
    {
        base.onAfterSetData();
        this.refresh();
    }

    #region Destroy

    public bool alreadyDestroy = false;

    public override void OnDestroy()
    {
        base.OnDestroy();
        alreadyDestroy = true;
    }

    #endregion

    #region TrashMan interface

    public int trashInstanceId = 0;

    public int getInstanceId()
    {
        return trashInstanceId;
    }

    public void setInstanceId(int newInstanceId)
    {
        // Debug.Log ("setInstanceId: " + newInstanceId + "; " + this);
        this.trashInstanceId = newInstanceId;
    }

    public GameObject getGameObject()
    {
        if (!alreadyDestroy)
        {
            return this.gameObject;
        }
        else
        {
            return null;
        }
    }

    #endregion

    #region haveTransformInterface

    public Transform getTransform()
    {
        return this.transform;
    }

    public Data getData()
    {
        return this.data;
    }

    public void setDirty(bool dirty)
    {
        this.dirty = dirty;
    }

    #endregion

}
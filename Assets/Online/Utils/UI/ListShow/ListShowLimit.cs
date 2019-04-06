using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListShowLimit : ListShow
{

    public VP<uint> index;

    public VP<uint> count;

    #region Constructor

    public enum Property
    {
        index,
        count
    }

    public ListShowLimit() : base()
    {
        this.index = new VP<uint>(this, (byte)Property.index, 0);
        this.count = new VP<uint>(this, (byte)Property.count, 1000);
    }

    #endregion

    public override Type getType()
    {
        return Type.Limit;
    }

    public override List<T> getList<T>(List<T> list)
    {
        List<T> ret = new List<T>();
        {
            if (this.index.v < list.Count)
            {
                if (this.count.v > 0)
                {
                    int insertCount = (int)Mathf.Min(list.Count - this.index.v, this.count.v);
                    list.GetRange((int)this.index.v, insertCount);
                }
                else
                {
                    Debug.LogError("why count 0: " + this);
                }
            }
            else
            {
                Debug.LogError("index error: " + list.Count + "; " + this);
            }
        }
        return ret;
    }

}
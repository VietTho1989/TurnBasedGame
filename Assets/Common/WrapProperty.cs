using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public abstract class WrapProperty
{

    [SerializeField]
    public Data p = null;
    [SerializeField]
    public byte n = 0;// "-1";

    public WrapProperty(Data parent, byte name)
    {
        this.p = parent;
        this.n = name;
        parent.pts.Add(this);
    }

    public enum Type
    {
        List,
        Value
    }
    public abstract Type getType();

    public abstract object getValue();

    public abstract object getValue(int index);

    public abstract int getValueCount();

    public abstract System.Type getValueType();

    #region process value

    public abstract void clear();

    public abstract void addValue(object value, bool needOrder = false);

    public abstract void insertValue(object value, int index);

    public abstract void removeValue(object value);

    public abstract void removeAt(int index);

    public abstract void processAddValue(string strValue);

    public abstract void processAddValue(string strValue, int index);

    public abstract void processRemoveValue(string strValue, int index);

    public abstract void copyWrapProperty(WrapProperty otherWrapProperty);

    #endregion

    #region uid

    /** Id count*/
    public uint i = 0;

    public uint makeId()
    {
        i++;
        return i;
    }

    #endregion

    public abstract void allAddCallBack(ValueChangeCallBack callBack);

    public abstract void allRemoveCallBack(ValueChangeCallBack callBack);

    #region History Undo/Redo

    public abstract void processUndo(WrapChange wrapChange);

    public abstract void processRedo(WrapChange wrapChange);

    #endregion

    #region Need create dataIdentity

    /** Need create identity or not*/
    public byte ni = 1;

    /** Need history*/
    public byte nh = 1;

    #endregion

    public static bool checkError(WrapProperty wrapProperty)
    {
        if (wrapProperty.p == null)
        {
            Debug.LogError("wrapProperty null");
            return true;
        }
        return false;
    }

    #region Compare

    public static bool isDifferent(WrapProperty wrapProperty1, WrapProperty wrapProperty2)
    {
        if (!object.Equals(wrapProperty1, wrapProperty2))
        {
            if (wrapProperty1.getType() == wrapProperty2.getType())
            {
                if (wrapProperty1.getValueCount() == wrapProperty2.getValueCount())
                {
                    bool ret = false;
                    for (int i = 0; i < wrapProperty1.getValueCount(); i++)
                    {
                        object value1 = wrapProperty1.getValue(i);
                        object value2 = wrapProperty2.getValue(i);
                        // equals
                        if (object.Equals(value1, value2))
                        {
                            // Debug.Log ("equal value, continue");
                        }
                        else
                        {
                            // if data?
                            if (value1 != null && value2 != null)
                            {
                                if (value1.GetType() != value2.GetType())
                                {
                                    ret = true;
                                    break;
                                }
                                else
                                {
                                    if (value1 is Data && value2 is Data)
                                    {
                                        Data data1 = value1 as Data;
                                        Data data2 = value2 as Data;
                                        if (DataUtils.IsDifferent(data1, data2))
                                        {
                                            ret = true;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        ret = true;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("why value null when compare");
                            }
                        }
                    }
                    return ret;
                }
                else
                {
                    Debug.LogError("different value count: " + wrapProperty1 + "; " + wrapProperty2);
                    return true;
                }
            }
            else
            {
                Debug.LogError("not the same type: " + wrapProperty1 + "; " + wrapProperty2);
                return true;
            }
        }
        else
        {
            Debug.LogError("the same property: " + wrapProperty1 + "; " + wrapProperty2);
            return false;
        }
    }

    #endregion

    #region makeBinary

    public abstract void makeBinary(BinaryWriter writer);

    public abstract void parse(BinaryReader binaryReader);

    #endregion

    #region makeSqliteBinary

    public abstract void makeSqliteBinary(BinaryWriter writer);

    public abstract void parseSqlite(BinaryReader reader);

    #endregion

}
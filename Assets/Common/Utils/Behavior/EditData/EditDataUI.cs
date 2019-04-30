using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EditDataUI
{

    #region UIData

    public interface UIData<T> where T : Data
    {

        EditData<T> getEditData();

    }

    #endregion

    public static void RefreshChildUI<T, K>(UIData<K> parent, UIData<T> child, Func<K, T> getValue) where T : Data where K: Data
    {
        if (parent != null)
        {
            EditData<K> editParent = parent.getEditData();
            if (editParent != null)
            {
                if (child != null)
                {
                    EditData<T> editChild = child.getEditData();
                    if (editChild != null)
                    {
                        // origin
                        {
                            T originChild = null;
                            {
                                K originParent = editParent.origin.v.data;
                                if (originParent != null)
                                {
                                    originChild = getValue(originParent);
                                }
                                else
                                {
                                    // Debug.LogError("originParent null");
                                }
                            }
                            editChild.origin.v = new ReferenceData<T>(originChild);
                        }
                        // show
                        {
                            T showChild = null;
                            {
                                K showParent = editParent.show.v.data;
                                if (showParent != null)
                                {
                                    showChild = getValue(showParent);
                                }
                                else
                                {
                                    // Debug.LogError("showParent null");
                                }
                            }
                            editChild.show.v = new ReferenceData<T>(showChild);
                        }
                        // compare
                        {
                            T compareChild = null;
                            {
                                K compareParent = editParent.compare.v.data;
                                if (compareParent != null)
                                {
                                    compareChild = getValue(compareParent);
                                }
                                else
                                {
                                    // Debug.LogError("compareParent null: " + this);
                                }
                            }
                            editChild.compare.v = new ReferenceData<T>(compareChild);
                        }
                        // compare other type
                        {
                            T compareOtherTypeChild = null;
                            {
                                K compareOtherTypeParent = (K)editParent.compareOtherType.v.data;
                                if (compareOtherTypeParent != null)
                                {
                                    compareOtherTypeChild = getValue(compareOtherTypeParent);
                                }
                            }
                            editChild.compareOtherType.v = new ReferenceData<Data>(compareOtherTypeChild);
                        }
                        // canEdit
                        editChild.canEdit.v = editParent.canEdit.v;
                        // editType
                        editChild.editType.v = editParent.editType.v;
                    }
                    else
                    {
                        Debug.LogError("editChild null");
                    }
                }
                else
                {
                    Debug.LogError("child null");
                }
            }
            else
            {
                Debug.LogError("editParent null");
            }
        }
        else
        {
            Debug.LogError("parent null");
        }
    }

    // public static void RefreshChildSubUI<T, K>

}
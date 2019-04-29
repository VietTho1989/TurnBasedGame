using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface ValueChangeCallBack
{

#pragma warning disable CS0618

    void onAddCallBack<T> (T data) where T:Data;

	void onRemoveCallBack<T> (T data, bool isHide) where T:Data;

	void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs);

}
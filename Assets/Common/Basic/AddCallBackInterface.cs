using UnityEngine;
using System.Collections;

public interface AddCallBackInterface 
{
	void addCallBack (ValueChangeCallBack callBack);

	void removeCallBack (ValueChangeCallBack callBack, bool isHide = false);

}	
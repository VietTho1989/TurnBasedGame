using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HaveDatabaseServerFailUI : UIBehavior<HaveDatabaseServerFailUI.UIData>
{

	#region UIData

	public class UIData : HaveDatabaseServerUI.UIData.Sub
	{

		#region Constructor

		public enum Property
		{

		}

		public UIData() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Fail;
		}

		public override bool processEvent (Event e)
		{
			bool isProcess = false;
			{
				Debug.LogError ("TODO Can hoan thien");
			}
			return isProcess;
		}

		public static void changeToFail(Data data)
		{
			if (data != null) {
				HaveDatabaseServerUI.UIData haveDatabaseServerUIData = data.findDataInParent<HaveDatabaseServerUI.UIData> ();
				if (haveDatabaseServerUIData != null) {
					HaveDatabaseServerFailUI.UIData failUIData = haveDatabaseServerUIData.sub.newOrOld<HaveDatabaseServerFailUI.UIData> ();
					{

					}
					haveDatabaseServerUIData.sub.v = failUIData;
				} else {
					Debug.LogError ("haveDatabaseServerUIData null: " + data);
				}
			} else {
				Debug.LogError ("data null: " + data);
			}
		}

	}

	#endregion

	#region Refresh

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {

			} else {
				Debug.LogError ("data null: " + this);
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HaveDatabaseServerLoadUI : UIBehavior<HaveDatabaseServerLoadUI.UIData>
{

	#region UIData

	public class UIData : HaveDatabaseServerUI.UIData.Sub
	{

		#region State

		public abstract class State : Data
		{

			public enum Type
			{
				File,
				Data
			}

			public abstract Type getType ();

		}

		public VP<State> state;

		#endregion

		#region Constructor

		public enum Property
		{
			state
		}

		public UIData() : base()
		{
			this.state = new VP<State>(this, (byte)Property.state, new HaveDatabaseServerLoadFileUI.UIData());
		}

		#endregion

		public override Type getType ()
		{
			return Type.Load;
		}

		public override bool processEvent (Event e)
		{
			bool isProcess = false;
			{
				// TODO Can hoan thien
			}
			return isProcess;
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

	public HaveDatabaseServerLoadFileUI filePrefab;
	public HaveDatabaseServerLoadDataUI dataPrefab;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.state.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is UIData.State) {
			UIData.State state = data as UIData.State;
			// UI
			{
				switch (state.getType ()) {
				case UIData.State.Type.File:
					{
						HaveDatabaseServerLoadFileUI.UIData fileUIData = state as HaveDatabaseServerLoadFileUI.UIData;
						UIUtils.Instantiate (fileUIData, filePrefab, this.transform, UIConstants.FullParent);
					}
					break;
				case UIData.State.Type.Data:
					{
						HaveDatabaseServerLoadDataUI.UIData dataUIData = state as HaveDatabaseServerLoadDataUI.UIData;
						UIUtils.Instantiate (dataUIData, dataPrefab, this.transform, UIConstants.FullParent);
					}
					break;
				default:
					Debug.LogError ("unknown type: " + state.getType () + "; " + this);
					break;
				}
			}
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.state.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		if (data is UIData.State) {
			UIData.State state = data as UIData.State;
			// UI
			{
				switch (state.getType ()) {
				case UIData.State.Type.File:
					{
						HaveDatabaseServerLoadFileUI.UIData fileUIData = state as HaveDatabaseServerLoadFileUI.UIData;
						fileUIData.removeCallBackAndDestroy (typeof(HaveDatabaseServerLoadFileUI));
					}
					break;
				case UIData.State.Type.Data:
					{
						HaveDatabaseServerLoadDataUI.UIData dataUIData = state as HaveDatabaseServerLoadDataUI.UIData;
						dataUIData.removeCallBackAndDestroy (typeof(HaveDatabaseServerLoadDataUI));
					}
					break;
				default:
					Debug.LogError ("unknown type: " + state.getType () + "; " + this);
					break;
				}
			}
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is UIData) {
			switch ((UIData.Property)wrapProperty.n) {
			case UIData.Property.state:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		if (wrapProperty.p is UIData.State) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
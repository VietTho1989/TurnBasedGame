using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameTopicUI : UIBehavior<GameTopicUI.UIData>
{

	#region UIData

	public class UIData : TopicUI
	{

		public VP<ReferenceData<GameTopic>> gameTopic;

		#region Constructor

		public enum Property
		{
			gameTopic
		}

		public UIData() : base()
		{
			this.gameTopic = new VP<ReferenceData<GameTopic>>(this, (byte)Property.gameTopic, new ReferenceData<GameTopic>(null));
		}

		#endregion

		public override Topic.Type getType ()
		{
			return Topic.Type.Game;
		}

	}

	#endregion

	#region Refresh

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				GameTopic gameTopic = this.data.gameTopic.v.data;
				if (gameTopic != null) {

				} else {
					// Debug.LogError ("gameTopic null: " + this);
				}
			} else {
				// Debug.LogError ("data null: " + this);
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
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.gameTopic.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is GameTopic) {
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
				uiData.gameTopic.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		if (data is GameTopic) {
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
			case UIData.Property.gameTopic:
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
		if (wrapProperty.p is GameTopic) {
			switch ((GameTopic.Property)wrapProperty.n) {
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
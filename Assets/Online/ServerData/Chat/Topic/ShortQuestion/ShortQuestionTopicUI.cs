using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShortQuestionTopicUI : UIBehavior<ShortQuestionTopicUI.UIData>
{

	#region UIData

	public class UIData : TopicUI
	{

		public VP<ReferenceData<ShortQuestionTopic>> shortQuestionTopic;

		#region Constructor

		public enum Property
		{
			shortQuestionTopic
		}

		public UIData() : base()
		{
			this.shortQuestionTopic = new VP<ReferenceData<ShortQuestionTopic>>(this, (byte)Property.shortQuestionTopic, new ReferenceData<ShortQuestionTopic>(null));
		}

		#endregion

		public override Topic.Type getType ()
		{
			return Topic.Type.ShortQuestion;
		}

		public void reset()
		{

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
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.shortQuestionTopic.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is ShortQuestionTopic) {
			// Reset
			{
				if (this.data != null) {
					this.data.reset ();
				} else {
					Debug.LogError ("data null: " + this);
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
				uiData.shortQuestionTopic.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		if (data is ShortQuestionTopic) {
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
			case UIData.Property.shortQuestionTopic:
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
		if (wrapProperty.p is ShortQuestionTopic) {
			switch ((ShortQuestionTopic.Property)wrapProperty.n) {
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
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WaitAIInputSolvedUI : UIBehavior<WaitAIInputSolvedUI.UIData>
{

	#region UIData

	public class UIData : WaitAIInputUI.UIData.Sub
	{

		public VP<ReferenceData<WaitAIInputSolved>> waitAIInputSolved;

		#region Constructor

		public enum Property
		{
			waitAIInputSolved
		}

		public UIData() : base()
		{
			this.waitAIInputSolved = new VP<ReferenceData<WaitAIInputSolved>>(this, (byte)Property.waitAIInputSolved, new ReferenceData<WaitAIInputSolved>(null));
		}

		#endregion

		public override WaitAIInput.Sub.Type getType ()
		{
			return WaitAIInput.Sub.Type.Solved;
		}

	}

	#endregion

	#region Update

	#region txt

	public Text tvMessage;
	public static readonly TxtLanguage txtMessage = new TxtLanguage();

	static WaitAIInputSolvedUI()
	{
		txtMessage.add (Language.Type.vi, "Đợi đầu vào AI: Lấy nước đi đã giải");
	}

	#endregion

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// txt
				{
					if (tvMessage != null) {
						tvMessage.text = txtMessage.get ("Wait AI Input: get solved move");
					} else {
						Debug.LogError ("tvMessage null: " + this);
					}
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
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.waitAIInputSolved.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Setting
		if (data is Setting) {
			dirty = true;
			return;
		}
		// Child
		if (data is WaitAIInputSolved) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().removeCallBack(this);
			// Child
			{
				uiData.waitAIInputSolved.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Setting
		if (data is Setting) {
			return;
		}
		// Child
		if (data is WaitAIInputSolved) {
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
			case UIData.Property.waitAIInputSolved:
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
		// Setting
		if (wrapProperty.p is Setting) {
			switch ((Setting.Property)wrapProperty.n) {
			case Setting.Property.language:
				dirty = true;
				break;
			case Setting.Property.showLastMove:
				break;
			case Setting.Property.viewUrlImage:
				break;
			case Setting.Property.animationSetting:
				break;
			case Setting.Property.maxThinkCount:
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		if (wrapProperty.p is WaitAIInputSolved) {
			switch ((WaitAIInputSolved.Property)wrapProperty.n) {
			case WaitAIInputSolved.Property.state:
				dirty = true;
				break;
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
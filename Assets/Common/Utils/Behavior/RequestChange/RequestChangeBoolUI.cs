using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RequestChangeBoolUI : UIBehavior<RequestChangeBoolUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<RequestChangeBoolUpdate.UpdateData> updateData;

		#region compare

		public VP<bool> showDifferent;

		public VP<bool> compare;

		#endregion

		#region Constructor

		public enum Property
		{
			updateData,
			// comare
			showDifferent,
			compare
		}

		public UIData() : base()
		{
			this.updateData = new VP<RequestChangeBoolUpdate.UpdateData>(this, (byte)Property.updateData, new RequestChangeBoolUpdate.UpdateData());
			// compare
			{
				this.showDifferent = new VP<bool>(this, (byte)Property.showDifferent, false);
				this.compare = new VP<bool>(this, (byte)Property.compare, true);
			}
		}

		#endregion

	}

	#endregion

	#region Refresh

	public void onClickBtnChange()
	{
		// Debug.LogError ("onClickBtnChange: " + this);
		if (this.data != null) {
			this.data.updateData.v.current.v = !this.data.updateData.v.current.v;
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	public Button btnValue;

    public Sprite blackCheckMark;
    public Sprite redCheckMark;
    public Sprite redDot;
    public Image checkMark;

	public Text tvState;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// interactable
				if (this.data.updateData.v.canRequestChange.v) {
					// make interactable
					if (btnValue != null) {
						btnValue.interactable = true;
					} else {
						Debug.LogError ("btnValue null: " + this);
					}
				} else {
					// disable interactable
					if (btnValue != null) {
						btnValue.interactable = false;
					} else {
						Debug.LogError ("btnValue null: " + this);
					}
				}
				// set value
				{
					// tvState
					if (tvState != null) {
						switch (this.data.updateData.v.changeState.v) {
						case Data.ChangeState.None:
							tvState.text = "None";
							break;
						case Data.ChangeState.Request:
							tvState.text = "Request";
							break;
						case Data.ChangeState.Requesting:
							tvState.text = "Requesting";
							break;
						default:
							Debug.LogError ("unknown state: " + this.data.updateData.v.changeState.v + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("tvState null: " + this);
					}
				}
				// checkMark
				{
					if (checkMark != null) {
						// check different
						bool isDifferent = false;
						{
							if (this.data.showDifferent.v) {
								RequestChangeBoolUpdate.UpdateData updateData = this.data.updateData.v;
								if (updateData != null) {
									if (updateData.current.v != this.data.compare.v) {
										isDifferent = true;
									}
								} else {
									Debug.LogError ("updateData null: " + this);
								}
							}
						}
						// Process
						if (isDifferent) {
                            checkMark.color = Color.white;
                            checkMark.sprite = this.data.updateData.v.current.v ? redCheckMark : redDot;
						} else {
                            if (this.data.updateData.v.current.v)
                            {
                                checkMark.color = Color.white;
                                checkMark.sprite = blackCheckMark;
                            }
                            else
                            {
                                checkMark.color = Global.TransparentColor;
                            }
						}
					} else {
						Debug.LogError ("checkMark null: " + this);
					}
				}
			} else {
				// Debug.Log ("data null: " + this);
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
				uiData.updateData.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is RequestChangeBoolUpdate.UpdateData) {
				RequestChangeBoolUpdate.UpdateData updateData = data as RequestChangeBoolUpdate.UpdateData;
				// Update
				{
					UpdateUtils.makeUpdate<RequestChangeBoolUpdate, RequestChangeBoolUpdate.UpdateData> (updateData, this.transform);
				}
				dirty = true;
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.updateData.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is RequestChangeBoolUpdate.UpdateData) {
				RequestChangeBoolUpdate.UpdateData updateData = data as RequestChangeBoolUpdate.UpdateData;
				// Update
				{
					updateData.removeCallBackAndDestroy (typeof(RequestChangeBoolUpdate));
				}
				return;
			}
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
			case UIData.Property.updateData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.showDifferent:
				dirty = true;
				break;
			case UIData.Property.compare:
				dirty = true;
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			if (wrapProperty.p is RequestChangeBoolUpdate.UpdateData) {
				switch ((RequestChangeBoolUpdate.UpdateData.Property)wrapProperty.n) {
				case RequestChangeBoolUpdate.UpdateData.Property.origin:
					break;
				case RequestChangeBoolUpdate.UpdateData.Property.current:
					dirty = true;
					break;
				case RequestChangeBoolUpdate.UpdateData.Property.canRequestChange:
					dirty = true;
					break;
				case RequestChangeBoolUpdate.UpdateData.Property.changeState:
					dirty = true;
					break;
				case RequestChangeBoolUpdate.UpdateData.Property.serverState:
					break;
				case RequestChangeBoolUpdate.UpdateData.Property.request:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
		}
		Debug.LogError ("Don't process:  " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
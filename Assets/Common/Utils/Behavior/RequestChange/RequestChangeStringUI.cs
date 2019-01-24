using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RequestChangeStringUI : UIBehavior<RequestChangeStringUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<RequestChangeStringUpdate.UpdateData> updateData;

		#region compare

		public VP<bool> showDifferent;

		public VP<string> compare;

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
			this.updateData = new VP<RequestChangeStringUpdate.UpdateData>(this, (byte)Property.updateData, new RequestChangeStringUpdate.UpdateData());
			// compare
			{
				this.showDifferent = new VP<bool>(this, (byte)Property.showDifferent, false);
				this.compare = new VP<string>(this, (byte)Property.compare, "");
			}
		}

		#endregion

	}

	#endregion

	#region Refresh

	public InputField edtValue;
	public Text txtValue;

	public override void Awake ()
	{
		base.Awake ();
		if (edtValue != null) {
			edtValue.onEndEdit.AddListener (delegate {
				if(edtValue.gameObject.activeInHierarchy){
					if (this.data != null) {
						string newValue = edtValue.text;
						this.data.updateData.v.current.v = newValue;
					} else {
						Debug.LogError ("data null: " + this);
					}
				} else {
					Debug.LogError("edtValue not active: " + this);
				}
			});
		} else {
			Debug.LogError ("edtValue null: " + this);
		}
	}

	public ContentSizeFitter contentSizeFilter;

	public Text tvState;

	public GameObject differentIndicator;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// Update UI
				{
					// Process
					if (this.data.updateData.v.canRequestChange.v) {
						// txtValue
						if (txtValue != null) {
							txtValue.gameObject.SetActive (false);
						} else {
							Debug.LogError ("txtValue null: " + this);
						}
						// edtValue
						if (edtValue != null) {
							edtValue.gameObject.SetActive (true);
							edtValue.interactable = true;
						} else {
							Debug.LogError ("edtValue null: " + this);
						}
						// tvState
						if (tvState != null) {
							tvState.gameObject.SetActive (true);
						} else {
							Debug.LogError ("tvState null: " + this);
						}
					} else {
						// txtValue
						if (txtValue != null) {
							txtValue.gameObject.SetActive (true);
						} else {
							Debug.LogError ("txtValue null: " + this);
						}
						// disable interactable
						if (edtValue != null) {
							edtValue.gameObject.SetActive (false);
							edtValue.interactable = false;
						} else {
							Debug.LogError ("edtValue null: " + this);
						}
						// tvState
						if (tvState != null) {
							tvState.gameObject.SetActive (false);
						} else {
							Debug.LogError ("tvState null: " + this);
						}
					}
					// set value
					{
						// edtValue
						if (edtValue != null) {
							edtValue.text = this.data.updateData.v.current.v;
						} else {
							Debug.LogError ("edtValue null: " + this);
						}
						// txtValue
						if (txtValue != null) {
							txtValue.text = this.data.updateData.v.current.v;
						} else {
							Debug.LogError ("txtValue null: " + this);
						}
						// tvState
						if (tvState != null) {
							if (this.data.updateData.v.request.v != null) {
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
								tvState.text = "None";
							}
						} else {
							Debug.LogError ("tvState null: " + this);
						}
					}
				}
				// different
				{
					if (differentIndicator != null) {
						// check different
						bool isDifferent = false;
						{
							if (this.data.showDifferent.v) {
								RequestChangeStringUpdate.UpdateData updateData = this.data.updateData.v;
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
							differentIndicator.SetActive (true);
						} else {
							differentIndicator.SetActive (false);
						}
					} else {
						Debug.LogError ("differentIndicator null: " + this);
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
			// Child
			{
				uiData.updateData.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is RequestChangeStringUpdate.UpdateData) {
				RequestChangeStringUpdate.UpdateData updateData = data as RequestChangeStringUpdate.UpdateData;
				// Update
				{
					UpdateUtils.makeUpdate<RequestChangeStringUpdate, RequestChangeStringUpdate.UpdateData> (updateData, this.transform);
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
			if (data is RequestChangeStringUpdate.UpdateData) {
				RequestChangeStringUpdate.UpdateData updateData = data as RequestChangeStringUpdate.UpdateData;
				// Update
				{
					updateData.removeCallBackAndDestroy (typeof(RequestChangeStringUpdate));
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
			if (wrapProperty.p is RequestChangeStringUpdate.UpdateData) {
				switch ((RequestChangeStringUpdate.UpdateData.Property)wrapProperty.n) {
				case RequestChangeStringUpdate.UpdateData.Property.origin:
					break;
				case RequestChangeStringUpdate.UpdateData.Property.current:
					dirty = true;
					break;
				case RequestChangeStringUpdate.UpdateData.Property.canRequestChange:
					dirty = true;
					break;
				case RequestChangeStringUpdate.UpdateData.Property.changeState:
					dirty = true;
					break;
				case RequestChangeStringUpdate.UpdateData.Property.serverState:
					break;
				case RequestChangeStringUpdate.UpdateData.Property.request:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RequestChangeLongUI : UIBehavior<RequestChangeLongUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<RequestChangeLongUpdate.UpdateData> updateData;

		public VP<IntLimit> limit;

		#region compare

		public VP<bool> showDifferent;

		public VP<long> compare;

		#endregion

		#region Constructor

		public enum Property
		{
			updateData,
			limit,
			// comare
			showDifferent,
			compare
		}

		public UIData() : base()
		{
			this.updateData = new VP<RequestChangeLongUpdate.UpdateData>(this, (byte)Property.updateData, new RequestChangeLongUpdate.UpdateData());
			this.limit = new VP<IntLimit>(this, (byte)Property.limit, new IntLimit.No());
			// compare
			{
				this.showDifferent = new VP<bool>(this, (byte)Property.showDifferent, false);
				this.compare = new VP<long>(this, (byte)Property.compare, 0);
			}
		}

		#endregion

	}

	#endregion

	#region Refresh

	public InputField edtValue;
	public Slider sliderValue;

	public override void Awake ()
	{
		base.Awake ();
		if (edtValue != null) {
			edtValue.onEndEdit.AddListener (delegate {
				if(edtValue.gameObject.activeInHierarchy){
					if (this.data != null) {
						long newValue = this.data.updateData.v.current.v;
						if (System.Int64.TryParse (edtValue.text, out newValue)) {
							this.data.updateData.v.current.v = newValue;
						}
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
		if (sliderValue != null) {
			sliderValue.onValueChanged.AddListener (delegate {
				// Debug.LogError ("sliderValue: onValueChanged: " + sliderValue.value);
				if(sliderValue.gameObject.activeInHierarchy){
					if (this.data != null) {
						this.data.updateData.v.current.v = (long)sliderValue.value;
					} else {
						Debug.LogError ("data null: " + this);
					}
				} else {
					// Debug.LogError("slider not active: "+this);
				}
			});
		} else {
			Debug.LogError ("sliderValue null: " + this);
		}
	}

	public Text tvState;

	public GameObject differentIndicator;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// slider
				{
					if (sliderValue != null) {
						IntLimit intLimit = this.data.limit.v;
						if (intLimit != null) {
							switch (intLimit.getType ()) {
							case IntLimit.Type.No:
								{
									sliderValue.gameObject.SetActive (false);
								}
								break;
							case IntLimit.Type.Have:
								{
									IntLimit.Have have = intLimit as IntLimit.Have;
									if (have.min.v < have.max.v) {
										sliderValue.gameObject.SetActive (true);
										sliderValue.minValue = have.min.v;
										sliderValue.maxValue = have.max.v;
									} else {
										Debug.LogError ("why min >= max: " + have.min.v + "; " + have.max.v);
										sliderValue.gameObject.SetActive (false);
									}
								}
								break;
							default:
								Debug.LogError ("unknown type: " + intLimit.getType () + "; " + this);
								break;
							}
						} else {
							Debug.LogError ("limit null: " + this);
						}
					} else {
						Debug.LogError ("sliderValue null: " + this);
					}
				}
				// Update UI
				{
					// Process
					if (this.data.updateData.v.canRequestChange.v) {
						// make interactable
						if (edtValue != null) {
							edtValue.interactable = true;
						} else {
							Debug.LogError ("edtValue null: " + this);
						}
						if (sliderValue != null) {
							sliderValue.interactable = true;
						} else {
							Debug.LogError ("sliderValue null: " + this);
						}
					} else {
						// disable interactable
						if (edtValue != null) {
							edtValue.interactable = false;
						} else {
							Debug.LogError ("edtValue null: " + this);
						}
						if (sliderValue != null) {
							sliderValue.interactable = false;
						} else {
							Debug.LogError ("sliderValue null: " + this);
						}
					}
					// set value
					{
						// edtValue
						if (edtValue != null) {
							edtValue.text = "" + this.data.updateData.v.current.v;
						} else {
							Debug.LogError ("edtValue null: " + this);
						}
						// sliderValue
						if (sliderValue != null) {
							sliderValue.value = this.data.updateData.v.current.v;
						} else {
							Debug.LogError ("sliderValue null: " + this);
						}
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
				}
				// different
				{
					if (differentIndicator != null) {
						// check different
						bool isDifferent = false;
						{
							if (this.data.showDifferent.v) {
								RequestChangeLongUpdate.UpdateData updateData = this.data.updateData.v;
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
				uiData.limit.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is RequestChangeLongUpdate.UpdateData) {
				RequestChangeLongUpdate.UpdateData updateData = data as RequestChangeLongUpdate.UpdateData;
				// Update
				{
					UpdateUtils.makeUpdate<RequestChangeLongUpdate, RequestChangeLongUpdate.UpdateData> (updateData, this.transform);
				}
				dirty = true;
				return;
			}
			if (data is IntLimit) {
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
				uiData.limit.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is RequestChangeLongUpdate.UpdateData) {
				RequestChangeLongUpdate.UpdateData updateData = data as RequestChangeLongUpdate.UpdateData;
				// Update
				{
					updateData.removeCallBackAndDestroy (typeof(RequestChangeLongUpdate));
				}
				return;
			}
			if (data is IntLimit) {
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
			case UIData.Property.limit:
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
			if (wrapProperty.p is RequestChangeLongUpdate.UpdateData) {
				switch ((RequestChangeLongUpdate.UpdateData.Property)wrapProperty.n) {
				case RequestChangeLongUpdate.UpdateData.Property.origin:
					break;
				case RequestChangeLongUpdate.UpdateData.Property.current:
					dirty = true;
					break;
				case RequestChangeLongUpdate.UpdateData.Property.canRequestChange:
					dirty = true;
					break;
				case RequestChangeLongUpdate.UpdateData.Property.changeState:
					dirty = true;
					break;
				case RequestChangeLongUpdate.UpdateData.Property.serverState:
					break;
				case RequestChangeLongUpdate.UpdateData.Property.request:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is IntLimit) {
				if (wrapProperty.p is IntLimit.Have) {
					switch ((IntLimit.Have.Property)wrapProperty.n) {
					case IntLimit.Have.Property.min:
						dirty = true;
						break;
					case IntLimit.Have.Property.max:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
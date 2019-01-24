using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Compare co le nen them vao compare with other type
 * */
public class EditData<K> : Data, ValueChangeCallBack where K : Data
{

	public VP<ReferenceData<K>> origin;

	public VP<ReferenceData<K>> show;

	public VP<ReferenceData<K>> compare;

	public VP<ReferenceData<Data>> compareOtherType;

	public VP<bool> canEdit;

	public VP<EditType> editType;

	#region Constructor

	public enum Property
	{
		origin,
		show,
		compare,
		compareOtherType,
		canEdit,
		editType
	}

	public EditData() : base()
	{
		this.origin = new VP<ReferenceData<K>> (this, (byte)Property.origin, new ReferenceData<K> (null));
		this.show = new VP<ReferenceData<K>> (this, (byte)Property.show, new ReferenceData<K> (null));
		this.compare = new VP<ReferenceData<K>> (this, (byte)Property.compare, new ReferenceData<K> (null));
		this.compareOtherType = new VP<ReferenceData<Data>> (this, (byte)Property.compareOtherType, new ReferenceData<Data> (null));
		this.canEdit = new VP<bool> (this, (byte)Property.canEdit, false);
		this.editType = new VP<EditType> (this, (byte)Property.editType, EditType.Immediate);
		// add callBacks
		this.addCallBack(this);
	}

	#endregion

	private bool dirty = true;
	/** co cai haveOriginChange the nay thi do phai reset khi doi origin*/
	private bool haveOriginChange = true;

	/**
	 * Copy nhung cai co the edit
	 * */
	public List<byte> allowNames = null;

	public void update()
	{
		if (dirty) {
			dirty = false;
			if (this.origin.v.data != null) {
				if (this.editType.v == EditType.Immediate) {
					this.show.v = new ReferenceData<K> (this.origin.v.data);
				} else {
					// need create complete new
					if (this.show.v.data == null || this.show.v.data == this.origin.v.data || this.show.v.data.GetType () != this.origin.v.data.GetType ()) {
						this.show.v = new ReferenceData<K> ((K)DataUtils.cloneData (this.origin.v.data));
					} else {
						// update when origin change
						if (haveOriginChange) {
							DataUtils.copyData (this.show.v.data, this.origin.v.data, allowNames);
						}
					}
				}
			} else {
				this.show.v = new ReferenceData<K> (null);
			}
			haveOriginChange = false;
		}
	}

	#region implement callBacks

	public void onAddCallBack<T> (T data) where T:Data
	{
		if (data is EditData<K>) {
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public void onRemoveCallBack<T> (T data, bool isHide) where T:Data
	{
		if (data is EditData<K>) {
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is EditData<K>) {
			switch ((EditData<K>.Property)wrapProperty.n) {
			case Property.origin:
				{
					haveOriginChange = true;
					dirty = true;
				}
				break;
			case Property.show:
				dirty = true;
				break;
			case Property.compare:
				break;
			case Property.compareOtherType:
				break;
			case Property.canEdit:
				break;
			case Property.editType:
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
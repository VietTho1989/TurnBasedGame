using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BanUI : UIBehavior<BanUI.UIData>, HaveTransformData
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<Ban>> ban;

		#region Sub

		public abstract class Sub : Data
		{
			public abstract Ban.Type getType();
		}

		public VP<Sub> sub;

		#endregion

		#region Constructor

		public enum Property
		{
			ban,
			sub
		}

		public UIData() : base()
		{
			this.ban = new VP<ReferenceData<Ban>>(this, (byte)Property.ban, new ReferenceData<Ban>(null));
			this.sub = new VP<Sub>(this, (byte)Property.sub, null);
		}

		#endregion

	}

    #endregion

    #region TransformData

    public TransformData transformData = new TransformData();

    private void updateTransformData()
    {
        this.transformData.update(this.transform);
    }

    public TransformData getTransformData()
    {
        return this.transformData;
    }

    #endregion

    #region Refresh

    public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Ban ban = this.data.ban.v.data;
				if (ban != null) {
					switch (ban.getType ()) {
					case Ban.Type.Normal:
						{
							BanNormal banNormal = ban as BanNormal;
							// UIData
							BanNormalUI.UIData banNormalUIData = this.data.sub.newOrOld<BanNormalUI.UIData>();
							{
								banNormalUIData.banNormal.v = new ReferenceData<BanNormal> (banNormal);
							}
							this.data.sub.v = banNormalUIData;
						}
						break;
					case Ban.Type.Ban:
						{
							BanBan banBan = ban as BanBan;
							// UIData
							BanBanUI.UIData banBanUIData = this.data.sub.newOrOld<BanBanUI.UIData>();
							{
								banBanUIData.banBan.v = new ReferenceData<BanBan> (banBan);
							}
							this.data.sub.v = banBanUIData;
						}
						break;
					default:
						Debug.LogError ("unknown type: " + ban.getType () + "; " + this);
						break;
					}
				} else {
					Debug.LogError ("ban null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}
        updateTransformData();
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public BanNormalUI banNormalPrefab;
	public BanBanUI banBanPrefab;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.ban.allAddCallBack (this);
				uiData.sub.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is Ban) {
				dirty = true;
				return;
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case Ban.Type.Normal:
						{
							BanNormalUI.UIData banNormalUIData = sub as BanNormalUI.UIData;
							UIUtils.Instantiate (banNormalUIData, banNormalPrefab, this.transform);
						}
						break;
					case Ban.Type.Ban:
						{
							BanBanUI.UIData banBanUIData = sub as BanBanUI.UIData;
							UIUtils.Instantiate (banBanUIData, banBanPrefab, this.transform);
						}
						break;
					default:
						Debug.LogError ("Unknown type: " + sub.getType () + "; " + this);
						break;
					}
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
				uiData.ban.allRemoveCallBack (this);
				uiData.sub.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is Ban) {
				return;
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case Ban.Type.Normal:
						{
							BanNormalUI.UIData banNormalUIData = sub as BanNormalUI.UIData;
							banNormalUIData.removeCallBackAndDestroy (typeof(BanNormalUI));
						}
						break;
					case Ban.Type.Ban:
						{
							BanBanUI.UIData banBanUIData = sub as BanBanUI.UIData;
							banBanUIData.removeCallBackAndDestroy (typeof(BanBanUI));
						}
						break;
					default:
						Debug.LogError ("Unknown type: " + sub.getType () + "; " + this);
						break;
					}
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
			case UIData.Property.ban:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.sub:
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
		{
			if (wrapProperty.p is Ban) {
				return;
			}
			if (wrapProperty.p is UIData.Sub) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
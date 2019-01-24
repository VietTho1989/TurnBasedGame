using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PerspectiveUI : UIBehavior<PerspectiveUI.UIData>
{

	#region UIData

	public class UIData : Data
	{
		public VP<ReferenceData<Perspective>> perspective;

		#region Sub

		public abstract class Sub : Data
		{
			public abstract Perspective.Sub.Type getType();
		}

		public VP<Sub> sub;

		#endregion

		#region Constructor

		public enum Property
		{
			perspective,
			sub
		}

		public UIData() : base()
		{
			this.perspective = new VP<ReferenceData<Perspective>>(this, (byte)Property.perspective, new ReferenceData<Perspective>(null));
			this.sub = new VP<Sub>(this, (byte)Property.sub, null);
		}

		#endregion

	}

	#endregion

	#region Refresh

	#region txt

	public static readonly TxtLanguage txtPlayerView = new TxtLanguage();

	static PerspectiveUI()
	{
		txtPlayerView.add (Language.Type.vi, "Góc Nhìn Người Chơi");
	}

	#endregion

	public Text tvPlayerIndex;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Perspective perspective = this.data.perspective.v.data;
				if (perspective != null) {
					// tvPlayerIndex
					{
						if (tvPlayerIndex != null) {
							tvPlayerIndex.text = txtPlayerView.get ("Player View") + ": " + perspective.playerView.v;
						} else {
							Debug.LogError ("tvPlayerIndex null: " + this);
						}
					}
					// Sub
					if (perspective.sub.v != null) {
						switch (perspective.sub.v.getType ()) {
						case Perspective.Sub.Type.Auto:
							{
								PerspectiveAuto auto = perspective.sub.v as PerspectiveAuto;
								// UIData
								PerspectiveAutoUI.UIData subUIData = this.data.sub.newOrOld<PerspectiveAutoUI.UIData>();
								{
									subUIData.auto.v = new ReferenceData<PerspectiveAuto> (auto);
								}
								this.data.sub.v = subUIData;
							}
							break;
						case Perspective.Sub.Type.Force:
							{
								PerspectiveForce force = perspective.sub.v as PerspectiveForce;
								// UIData
								PerspectiveForceUI.UIData subUIData = this.data.sub.newOrOld<PerspectiveForceUI.UIData>();
								{
									subUIData.force.v = new ReferenceData<PerspectiveForce> (force);
								}
								this.data.sub.v = subUIData;
							}
							break;
						default:
							Debug.LogError ("unknown sub: " + perspective.sub.v.getType () + "; " + this);
							break;
						}
					} else {
						// Debug.LogError ("sub null: " + this);
						this.data.sub.v = null;
					}
				} else {
					Debug.LogError ("perpective null: " + this);
				}
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

	public PerspectiveAutoUI autoPrefab;
	public PerspectiveForceUI forcePrefab;
	public Transform subTransform;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.perspective.allAddCallBack (this);
				uiData.sub.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Setting
		if (data is Setting) {
			dirty = true;
			return;
		}
		// Chid
		{
			// perspective
			{
				if (data is Perspective) {
					Perspective perspective = data as Perspective;
					// Child
					{
						perspective.sub.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is Perspective.Sub) {
					dirty = true;
					return;
				}
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case Perspective.Sub.Type.Auto:
						{
							PerspectiveAutoUI.UIData autoUIData = sub as PerspectiveAutoUI.UIData;
							UIUtils.Instantiate (autoUIData, autoPrefab, subTransform);
						}
						break;
					case Perspective.Sub.Type.Force:
						{
							PerspectiveForceUI.UIData forceUIData = sub as PerspectiveForceUI.UIData;
							UIUtils.Instantiate (forceUIData, forcePrefab, subTransform);
						}
						break;
					default:
						Debug.LogError ("unknown sub: " + sub + "; " + this);
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
			// Setting
			Setting.get().removeCallBack(this);
			// Child
			{
				uiData.perspective.allRemoveCallBack (this);
				uiData.sub.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Setting
		if (data is Setting) {
			return;
		}
		// Child
		{
			// Perspective
			{
				if (data is Perspective) {
					Perspective perspective = data as Perspective;
					// Child
					{
						perspective.sub.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is Perspective.Sub) {
					return;
				}
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case Perspective.Sub.Type.Auto:
						{
							PerspectiveAutoUI.UIData autoUIData = sub as PerspectiveAutoUI.UIData;
							autoUIData.removeCallBackAndDestroy (typeof(PerspectiveAutoUI));
						}
						break;
					case Perspective.Sub.Type.Force:
						{
							PerspectiveForceUI.UIData forceUIData = sub as PerspectiveForceUI.UIData;
							forceUIData.removeCallBackAndDestroy (typeof(PerspectiveForceUI));
						}
						break;
					default:
						Debug.LogError ("unknown sub: " + sub + "; " + this);
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
			case UIData.Property.perspective:
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
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
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
		{
			// Perspective
			{
				if (wrapProperty.p is Perspective) {
					switch ((Perspective.Property)wrapProperty.n) {
					case Perspective.Property.playerView:
						dirty = true;
						break;
					case Perspective.Property.sub:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					default:
						Debug.LogError ("unknownw wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is Perspective.Sub) {
					return;
				}
			}
			if(wrapProperty.p is UIData.Sub){
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerStateUI : UIBehavior<GamePlayerStateUI.UIData>
{

	#region UIData

	public class UIData : Data
	{
		public VP<ReferenceData<GamePlayer.State>> state;

		#region Sub

		public abstract class Sub : Data
		{
			
			public abstract GamePlayer.State.Type getType ();

		}

		public VP<Sub> sub;

		#endregion

		#region Constructor

		public enum Property
		{
			state,
			sub
		}

		public UIData() : base()
		{
			this.state = new VP<ReferenceData<GamePlayer.State>>(this, (byte)Property.state, new ReferenceData<GamePlayer.State>(null));
			this.sub = new VP<Sub>(this, (byte)Property.sub, null);
		}

		#endregion
	}

	#endregion

	#region Refresh

	public GamePlayerStateNormalUI normalPrefab;
	public GamePlayerStateSurrenderUI surrenderPrefab;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				GamePlayer.State state = this.data.state.v.data;
				if (state != null) {
					switch (state.getType ()) {
					case GamePlayer.State.Type.Normal:
						{
							GamePlayerStateNormal gamePlayerStateNormal = state as GamePlayerStateNormal;
							// UIData
							GamePlayerStateNormalUI.UIData normalUIData = this.data.sub.newOrOld<GamePlayerStateNormalUI.UIData>();
							{
								normalUIData.normal.v = new ReferenceData<GamePlayerStateNormal> (gamePlayerStateNormal);
							}
							this.data.sub.v = normalUIData;
						}
						break;
					case GamePlayer.State.Type.Surrender:
						{
							GamePlayerStateSurrender gamePlayerStateSurrender = state as GamePlayerStateSurrender;
							// UIData
							GamePlayerStateSurrenderUI.UIData surrenderUIData = this.data.sub.newOrOld<GamePlayerStateSurrenderUI.UIData>();
							{
								surrenderUIData.surrender.v = new ReferenceData<GamePlayerStateSurrender> (gamePlayerStateSurrender);
							}
							this.data.sub.v = surrenderUIData;
						}
						break;
					default:
						Debug.LogError ("unknown type: " + state.getType ());
						break;
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			} else {
				Debug.LogError ("data null");
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
				uiData.sub.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case GamePlayer.State.Type.Normal:
						{
							GamePlayerStateNormalUI.UIData normalUIData = sub as GamePlayerStateNormalUI.UIData;
							UIUtils.Instantiate (normalUIData, normalPrefab, this.transform);
						}
						break;
					case GamePlayer.State.Type.Surrender:
						{
							GamePlayerStateSurrenderUI.UIData surrenderUIData = sub as GamePlayerStateSurrenderUI.UIData;
							UIUtils.Instantiate (surrenderUIData, surrenderPrefab, this.transform);
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
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
				uiData.sub.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case GamePlayer.State.Type.Normal:
						{
							GamePlayerStateNormalUI.UIData normalUIData = sub as GamePlayerStateNormalUI.UIData;
							normalUIData.removeCallBackAndDestroy (typeof(GamePlayerStateNormalUI));
						}
						break;
					case GamePlayer.State.Type.Surrender:
						{
							GamePlayerStateSurrenderUI.UIData surrenderUIData = sub as GamePlayerStateSurrenderUI.UIData;
							surrenderUIData.removeCallBackAndDestroy (typeof(GamePlayerStateSurrenderUI));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
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
			case UIData.Property.state:
				dirty = true;
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
		// Child
		if (wrapProperty.p is UIData.Sub) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
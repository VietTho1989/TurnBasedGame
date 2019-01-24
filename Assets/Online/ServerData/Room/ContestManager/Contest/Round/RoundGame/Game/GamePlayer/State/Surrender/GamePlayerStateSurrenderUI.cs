using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerStateSurrenderUI : UIBehavior<GamePlayerStateSurrenderUI.UIData>
{

	#region UIData

	public class UIData : GamePlayerStateUI.UIData.Sub
	{
		
		public VP<ReferenceData<GamePlayerStateSurrender>> surrender;

		#region Sub

		public abstract class Sub : Data
		{

			public abstract GamePlayerStateSurrender.State.Type getType();

		}

		public VP<Sub> sub;

		#endregion

		#region Constructor

		public enum Property
		{
			surrender,
			sub
		}

		public UIData() : base()
		{
			this.surrender = new VP<ReferenceData<GamePlayerStateSurrender>>(this, (byte)Property.surrender, new ReferenceData<GamePlayerStateSurrender>(null));
			this.sub = new VP<Sub>(this, (byte)Property.sub, null);
		}

		#endregion

		public override GamePlayer.State.Type getType ()
		{
			return GamePlayer.State.Type.Surrender;
		}

	}

	#endregion

	#region Refresh

	#region txt

	public Text lbTitle;
	public static readonly TxtLanguage txtTitle = new TxtLanguage();

	static GamePlayerStateSurrenderUI()
	{
		txtTitle.add (Language.Type.vi, "Đầu Hàng");
	}

	#endregion

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				GamePlayerStateSurrender surrender = this.data.surrender.v.data;
				if (surrender != null) {
					GamePlayerStateSurrender.State state = surrender.state.v;
					if (state != null) {
						switch (state.getType ()) {
						case GamePlayerStateSurrender.State.Type.None:
							{
								GamePlayerStateSurrenderNone none = state as GamePlayerStateSurrenderNone;
								// UI
								{
									GamePlayerStateSurrenderNoneUI.UIData noneUIData = this.data.sub.newOrOld<GamePlayerStateSurrenderNoneUI.UIData> ();
									{
										noneUIData.none.v = new ReferenceData<GamePlayerStateSurrenderNone> (none);
									}
									this.data.sub.v = noneUIData;
								}
							}
							break;
						case GamePlayerStateSurrender.State.Type.Ask:
							{
								GamePlayerStateSurrenderAsk ask = state as GamePlayerStateSurrenderAsk;
								// UI
								{
									GamePlayerStateSurrenderAskUI.UIData askUIData = this.data.sub.newOrOld<GamePlayerStateSurrenderAskUI.UIData> ();
									{
										askUIData.ask.v = new ReferenceData<GamePlayerStateSurrenderAsk> (ask);
									}
									this.data.sub.v = askUIData;
								}
							}
							break;
						default:
							Debug.LogError ("unknown type: " + state.getType () + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("state null: " + this);
					}
				} else {
					Debug.LogError ("surrender null");
				}
				// txt
				{
					if (lbTitle != null) {
						lbTitle.text = txtTitle.get ("Surrender");
					} else {
						Debug.LogError ("lbTitle null: " + this);
					}
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

	public GamePlayerStateSurrenderNoneUI nonePrefab;
	public GamePlayerStateSurrenderAskUI askPrefab;
	public Transform subContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.surrender.allAddCallBack (this);
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
		// Child
		{
			if (data is GamePlayerStateSurrender) {
				dirty = true;
				return;
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case GamePlayerStateSurrender.State.Type.None:
						{
							GamePlayerStateSurrenderNoneUI.UIData noneUIData = sub as GamePlayerStateSurrenderNoneUI.UIData;
							UIUtils.Instantiate (noneUIData, nonePrefab, subContainer);
						}
						break;
					case GamePlayerStateSurrender.State.Type.Ask:
						{
							GamePlayerStateSurrenderAskUI.UIData askUIData = sub as GamePlayerStateSurrenderAskUI.UIData;
							UIUtils.Instantiate (askUIData, askPrefab, subContainer);
						}
						break;
					default:
						Debug.LogError ("unknown sub: " + sub.getType () + "; " + this);
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
			Setting.get ().removeCallBack (this);
			// Child
			{
				uiData.surrender.allRemoveCallBack (this);
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
			if (data is GamePlayerStateSurrender) {
				return;
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case GamePlayerStateSurrender.State.Type.None:
						{
							GamePlayerStateSurrenderNoneUI.UIData noneUIData = sub as GamePlayerStateSurrenderNoneUI.UIData;
							noneUIData.removeCallBackAndDestroy (typeof(GamePlayerStateSurrenderNoneUI));
						}
						break;
					case GamePlayerStateSurrender.State.Type.Ask:
						{
							GamePlayerStateSurrenderAskUI.UIData askUIData = sub as GamePlayerStateSurrenderAskUI.UIData;
							askUIData.removeCallBackAndDestroy (typeof(GamePlayerStateSurrenderAskUI));
						}
						break;
					default:
						Debug.LogError ("unknown sub: " + sub.getType () + "; " + this);
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
			case UIData.Property.surrender:
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
			if (wrapProperty.p is GamePlayerStateSurrender) {
				switch ((GamePlayerStateSurrender.Property)wrapProperty.n) {
				case GamePlayerStateSurrender.Property.state:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
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
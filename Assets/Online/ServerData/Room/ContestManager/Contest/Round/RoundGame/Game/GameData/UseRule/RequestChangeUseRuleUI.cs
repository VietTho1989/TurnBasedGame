using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeUseRuleUI : UIBehavior<RequestChangeUseRuleUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<RequestChangeUseRule>> requestChangeUseRule;

		#region Sub

		public abstract class Sub : Data
		{

			public abstract RequestChangeUseRule.State.Type getType ();

		}

		public VP<Sub> sub;

		#endregion

		#region Constructor

		public enum Property
		{
			requestChangeUseRule,
			sub
		}

		public UIData() : base()
		{
			this.requestChangeUseRule = new VP<ReferenceData<RequestChangeUseRule>>(this, (byte)Property.requestChangeUseRule, new ReferenceData<RequestChangeUseRule>(null));
			this.sub = new VP<Sub>(this, (byte)Property.sub, null);
		}

		#endregion

		public bool processEvent(Event e)
		{
			bool isProcess = false;
			{

			}
			return isProcess;
		}

	}

	#endregion

	#region Refresh

	#region txt

	public Text lbTitle;
	public static readonly TxtLanguage txtTitle = new TxtLanguage();

	public Text tvUseRule;
	public static readonly TxtLanguage txtUseRule = new TxtLanguage();

	static RequestChangeUseRuleUI()
	{
		txtTitle.add (Language.Type.vi, "Dùng Luật");
		txtUseRule.add (Language.Type.vi, "dùng luật");
	}

	#endregion

	public Toggle tgUseRule;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				RequestChangeUseRule requestChangeUseRule = this.data.requestChangeUseRule.v.data;
				if (requestChangeUseRule != null) {
					// tgUseRule
					{
						if (tgUseRule != null) {
							bool useRule = true;
							{
								GameData gameData = requestChangeUseRule.findDataInParent<GameData> ();
								if (gameData != null) {
									useRule = gameData.useRule.v;
								} else {
									Debug.LogError ("gameData null: " + this);
								}
							}
							tgUseRule.isOn = useRule;
						} else {
							Debug.LogError ("tgUseRule null: " + this);
						}
					}
					// sub
					{
						RequestChangeUseRule.State state = requestChangeUseRule.state.v;
						if (state != null) {
							switch (state.getType ()) {
							case RequestChangeUseRule.State.Type.None:
								{
									RequestChangeUseRuleStateNone none = state as RequestChangeUseRuleStateNone;
									// UIData
									{
										RequestChangeUseRuleStateNoneUI.UIData noneUIData = this.data.sub.newOrOld<RequestChangeUseRuleStateNoneUI.UIData> ();
										{
											noneUIData.requestChangeUseRuleStateNone.v = new ReferenceData<RequestChangeUseRuleStateNone> (none);
										}
										this.data.sub.v = noneUIData;
									}
								}
								break;
							case RequestChangeUseRule.State.Type.Ask:
								{
									RequestChangeUseRuleStateAsk ask = state as RequestChangeUseRuleStateAsk;
									// UIData
									{
										RequestChangeUseRuleStateAskUI.UIData askUIData = this.data.sub.newOrOld<RequestChangeUseRuleStateAskUI.UIData> ();
										{
											askUIData.requestChangeUseRuleStateAsk.v = new ReferenceData<RequestChangeUseRuleStateAsk> (ask);
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
					}
				} else {
					Debug.LogError ("requestChangeUseRule null: " + this);
				}
				// txt
				{
					if (lbTitle != null) {
						lbTitle.text = txtTitle.get ("Use Rule");
					} else {
						Debug.LogError ("lbTitle null: " + this);
					}
					if (tvUseRule != null) {
						tvUseRule.text = txtUseRule.get ("use rule");
					} else {
						Debug.LogError ("tvUseRule null: " + this);
					}
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

	public RequestChangeUseRuleStateNoneUI nonePrefab;
	public RequestChangeUseRuleStateAskUI askPrefab;
	public Transform subContainer;

	private GameData gameData = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.requestChangeUseRule.allAddCallBack (this);
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
			// requestChangeUseRule
			{
				if (data is RequestChangeUseRule) {
					RequestChangeUseRule requestChangeUseRule = data as RequestChangeUseRule;
					// Parent
					{
						DataUtils.addParentCallBack (requestChangeUseRule, this, ref this.gameData);
					}
					dirty = true;
					return;
				}
				// Parent
				if (data is GameData) {
					dirty = true;
					return;
				}
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case RequestChangeUseRule.State.Type.None:
						{
							RequestChangeUseRuleStateNoneUI.UIData noneUIData = sub as RequestChangeUseRuleStateNoneUI.UIData;
							UIUtils.Instantiate (noneUIData, nonePrefab, subContainer);
						}
						break;
					case RequestChangeUseRule.State.Type.Ask:
						{
							RequestChangeUseRuleStateAskUI.UIData askUIData = sub as RequestChangeUseRuleStateAskUI.UIData;
							UIUtils.Instantiate (askUIData, askPrefab, subContainer);
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
			// Setting
			Setting.get().removeCallBack(this);
			// Child
			{
				uiData.requestChangeUseRule.allRemoveCallBack (this);
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
			// requestChangeUseRule
			{
				if (data is RequestChangeUseRule) {
					RequestChangeUseRule requestChangeUseRule = data as RequestChangeUseRule;
					// Parent
					{
						DataUtils.removeParentCallBack (requestChangeUseRule, this, ref this.gameData);
					}
					return;
				}
				// Parent
				if (data is GameData) {
					return;
				}
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case RequestChangeUseRule.State.Type.None:
						{
							RequestChangeUseRuleStateNoneUI.UIData noneUIData = sub as RequestChangeUseRuleStateNoneUI.UIData;
							noneUIData.removeCallBackAndDestroy (typeof(RequestChangeUseRuleStateNoneUI));
						}
						break;
					case RequestChangeUseRule.State.Type.Ask:
						{
							RequestChangeUseRuleStateAskUI.UIData askUIData = sub as RequestChangeUseRuleStateAskUI.UIData;
							askUIData.removeCallBackAndDestroy (typeof(RequestChangeUseRuleStateAskUI));
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
			case UIData.Property.requestChangeUseRule:
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
			// requestChangeUseRule
			{
				if (wrapProperty.p is RequestChangeUseRule) {
					switch ((RequestChangeUseRule.Property)wrapProperty.n) {
					case RequestChangeUseRule.Property.state:
						dirty = true;
						break;
					case RequestChangeUseRule.Property.whoCanAsks:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Parent
				if (wrapProperty.p is GameData) {
					switch ((GameData.Property)wrapProperty.n) {
					case GameData.Property.gameType:
						break;
					case GameData.Property.useRule:
						dirty = true;
						break;
					case GameData.Property.requestChangeUseRule:
						break;
					case GameData.Property.turn:
						break;
					case GameData.Property.timeControl:
						break;
					case GameData.Property.lastMove:
						break;
					case GameData.Property.state:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			if (wrapProperty.p is UIData.Sub) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
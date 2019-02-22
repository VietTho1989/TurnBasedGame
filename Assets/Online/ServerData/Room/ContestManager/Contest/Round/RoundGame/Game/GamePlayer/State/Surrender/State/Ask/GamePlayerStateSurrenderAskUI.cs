using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Foundation.Tasks;
using AdvancedCoroutines;

public class GamePlayerStateSurrenderAskUI : UIBehavior<GamePlayerStateSurrenderAskUI.UIData>
{

	#region UIData

	public class UIData : GamePlayerStateSurrenderUI.UIData.Sub
	{

		public VP<ReferenceData<GamePlayerStateSurrenderAsk>> ask;

		#region state

		public enum State
		{
			None,
			RequestAccept,
			WaitAccept,
			RequestRefuse,
			WaitRefuse
		}

		public VP<State> state;

		#endregion

		#region Constructor

		public enum Property
		{
			ask,
			state
		}

		public UIData() : base()
		{
			this.ask = new VP<ReferenceData<GamePlayerStateSurrenderAsk>>(this, (byte)Property.ask, new ReferenceData<GamePlayerStateSurrenderAsk>(null));
			this.state = new VP<State>(this, (byte)Property.state, State.None);
		}

		#endregion

		public override GamePlayerStateSurrender.State.Type getType ()
		{
			return GamePlayerStateSurrender.State.Type.Ask;
		}

		public void reset()
		{
			this.state.v = State.None;
		}

	}

	#endregion

	#region Refresh

	#region txt

	public static readonly TxtLanguage txtAccept = new TxtLanguage();
	public static readonly TxtLanguage txtCancelAccept = new TxtLanguage ();
	public static readonly TxtLanguage txtAccepting = new TxtLanguage ();

	public static readonly TxtLanguage txtRefuse = new TxtLanguage();
	public static readonly TxtLanguage txtCancelRefuse = new TxtLanguage();
	public static readonly TxtLanguage txtRefusing = new TxtLanguage();

	static GamePlayerStateSurrenderAskUI()
	{
		txtAccept.add (Language.Type.vi, "Chấp Nhận");
		txtCancelAccept.add (Language.Type.vi, "Huỷ chấp nhận?");
		txtAccepting.add (Language.Type.vi, "Đang chấp nhận...");

		txtRefuse.add (Language.Type.vi, "Từ Chối");
		txtCancelRefuse.add (Language.Type.vi, "Huỷ từ chối?");
		txtRefusing.add (Language.Type.vi, "Đang từ chối...");
	}

	#endregion

	private bool needReset = true;

	public Button btnAccept;
	public Text tvAccept;

	public Button btnRefuse;
	public Text tvRefuse;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				GamePlayerStateSurrenderAsk ask = this.data.ask.v.data;
				if (ask != null) {
					// reset
					{
						if (needReset) {
							this.data.state.v = UIData.State.None;
							needReset = false;
						}
					}
					uint profileId = Server.getProfileUserId (ask);
					// Task
					{
						switch (this.data.state.v) {
						case UIData.State.None:
							{
								destroyRoutine (wait);
							}
							break;
						case UIData.State.RequestAccept:
							{
								destroyRoutine (wait);
								if (ask.isCanAccept (profileId)) {
									if (Server.IsServerOnline (ask)) {
										ask.requestAccept (profileId);
										this.data.state.v = UIData.State.WaitAccept;
									} else {
										Debug.LogError ("server not online: " + this);
									}
								} else {
									this.data.state.v = UIData.State.None;
								}
							}
							break;
						case UIData.State.WaitAccept:
							{
								if (ask.isCanAccept (profileId)) {
									if (Server.IsServerOnline (ask)) {
										startRoutine (ref this.wait, TaskWait ());
									} else {
										destroyRoutine (wait);
										this.data.state.v = UIData.State.None;
									}
								} else {
									destroyRoutine (wait);
									this.data.state.v = UIData.State.None;
								}
							}
							break;
						case UIData.State.RequestRefuse:
							{
								destroyRoutine (wait);
								if (ask.isCanRefuse (profileId)) {
									if (Server.IsServerOnline (ask)) {
										ask.requestRefuse (profileId);
										this.data.state.v = UIData.State.WaitRefuse;
									} else {
										Debug.LogError ("server not online: " + this);
									}
								} else {
									this.data.state.v = UIData.State.None;
								}
							}
							break;
						case UIData.State.WaitRefuse:
							{
								if (ask.isCanRefuse (profileId)) {
									if (Server.IsServerOnline (ask)) {
										startRoutine (ref this.wait, TaskWait ());
									} else {
										destroyRoutine (wait);
										this.data.state.v = UIData.State.None;
									}
								} else {
									destroyRoutine (wait);
									this.data.state.v = UIData.State.None;
								}
							}
							break;
						default:
							Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
							break;
						}
					}
					// UI
					{
						// accept
						{
							if (btnAccept != null && tvAccept != null) {
								if (ask.isCanAccept (profileId)) {
									btnAccept.gameObject.SetActive (true);
									switch (this.data.state.v) {
									case UIData.State.None:
										{
											btnAccept.interactable = true;
											tvAccept.text = txtAccept.get ("Accept");
										}
										break;
									case UIData.State.RequestAccept:
										{
											btnAccept.interactable = true;
											tvAccept.text = txtCancelAccept.get ("Cancel accept?");
										}
										break;
									case UIData.State.WaitAccept:
										{
											btnAccept.interactable = false;
											tvAccept.text = txtAccepting.get ("Accepting...");
										}
										break;
									case UIData.State.RequestRefuse:
										{
											btnAccept.interactable = false;
											tvAccept.text = txtAccept.get ("Accept");
										}
										break;
									case UIData.State.WaitRefuse:
										{
											btnAccept.interactable = false;
											tvAccept.text = txtAccept.get ("Accept");
										}
										break;
									default:
										Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
										break;
									}
								} else {
									btnAccept.gameObject.SetActive (false);
								}
							} else {
								Debug.LogError ("btnAccept, tvAccept null: " + this);
							}
						}
						// refuse
						{
							if (btnRefuse != null && tvRefuse != null) {
								if (ask.isCanRefuse (profileId)) {
									btnRefuse.gameObject.SetActive (true);
									switch (this.data.state.v) {
									case UIData.State.None:
										{
											btnRefuse.interactable = true;
											tvRefuse.text = txtRefuse.get ("Refuse");
										}
										break;
									case UIData.State.RequestAccept:
										{
											btnRefuse.interactable = false;
											tvRefuse.text = txtRefuse.get ("Refuse");
										}
										break;
									case UIData.State.WaitAccept:
										{
											btnRefuse.interactable = false;
											tvRefuse.text = txtRefuse.get ("Refuse");
										}
										break;
									case UIData.State.RequestRefuse:
										{
											btnRefuse.interactable = true;
											tvRefuse.text = txtCancelRefuse.get ("Cancel refuse?");
										}
										break;
									case UIData.State.WaitRefuse:
										{
											btnRefuse.interactable = false;
											tvRefuse.text = txtRefusing.get ("Refusing...");
										}
										break;
									default:
										Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
										break;
									}
								} else {
									btnAccept.gameObject.SetActive (false);
								}
							} else {
								Debug.LogError ("btnAccept, tvAccept null: " + this);
							}
						}
					}
				} else {
					Debug.LogError ("ask null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return false;
	}

	#endregion

	#region Task wait

	private Routine wait;

	public IEnumerator TaskWait()
	{
		if (this.data != null) {
			yield return new Wait (Global.WaitSendTime);
			this.data.state.v = UIData.State.None;
			Toast.showMessage ("request error");
			Debug.LogError ("request error: " + this);
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	public override List<Routine> getRoutineList ()
	{
		List<Routine> ret = new List<Routine> ();
		{
			ret.Add (wait);
		}
		return ret;
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
				uiData.ask.allAddCallBack (this);
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
			if (data is GamePlayerStateSurrenderAsk) {
				GamePlayerStateSurrenderAsk ask = data as GamePlayerStateSurrenderAsk;
				// Child
				{
					ask.whoCanAsks.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is Human) {
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
				uiData.ask.allRemoveCallBack (this);
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
			if (data is GamePlayerStateSurrenderAsk) {
				GamePlayerStateSurrenderAsk ask = data as GamePlayerStateSurrenderAsk;
				// Child
				{
					ask.whoCanAsks.allRemoveCallBack (this);
				}
				return;
			}
			// Child
			if (data is Human) {
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
			case UIData.Property.ask:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.state:
				dirty = true;
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
			if (wrapProperty.p is GamePlayerStateSurrenderAsk) {
				switch ((GamePlayerStateSurrenderAsk.Property)wrapProperty.n) {
				case GamePlayerStateSurrenderAsk.Property.whoCanAsks:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case GamePlayerStateSurrenderAsk.Property.accepts:
					{
						needReset = true;
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
			if (wrapProperty.p is Human) {
				Human.onUpdateSyncPlayerIdChange (wrapProperty, this);
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnAccept()
	{
		if (this.data != null) {
			switch (this.data.state.v) {
			case UIData.State.None:
				this.data.state.v = UIData.State.RequestAccept;
				break;
			case UIData.State.RequestAccept:
				this.data.state.v = UIData.State.None;
				break;
			case UIData.State.WaitAccept:
				break;
			case UIData.State.RequestRefuse:
				break;
			case UIData.State.WaitRefuse:
				break;
			default:
				Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
				break;
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	public void onClickBtnRefuse()
	{
		if (this.data != null) {
			switch (this.data.state.v) {
			case UIData.State.None:
				this.data.state.v = UIData.State.RequestRefuse;
				break;
			case UIData.State.RequestAccept:
				break;
			case UIData.State.WaitAccept:
				break;
			case UIData.State.RequestRefuse:
				this.data.state.v = UIData.State.None;
				break;
			case UIData.State.WaitRefuse:
				break;
			default:
				Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
				break;
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}
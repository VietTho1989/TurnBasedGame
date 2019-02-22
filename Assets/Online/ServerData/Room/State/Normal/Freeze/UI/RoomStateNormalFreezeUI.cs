using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Foundation.Tasks;
using AdvancedCoroutines;

public class RoomStateNormalFreezeUI : UIBehavior<RoomStateNormalFreezeUI.UIData>
{

	#region UIData

	public class UIData : RoomStateNormalUI.UIData.Sub
	{

		public VP<ReferenceData<RoomStateNormalFreeze>> freeze;

		#region state

		public enum State
		{
			None,
			Request,
			Wait
		}

		public VP<State> state;

		#endregion

		#region Constructor

		public enum Property
		{
			freeze,
			state
		}

		public UIData() : base()
		{
			this.freeze = new VP<ReferenceData<RoomStateNormalFreeze>>(this, (byte)Property.freeze, new ReferenceData<RoomStateNormalFreeze>(null));
			this.state = new VP<State>(this, (byte)Property.state, State.None);
		}

		#endregion

		public override RoomStateNormal.State.Type getType ()
		{
			return RoomStateNormal.State.Type.Freeze;
		}

		public void reset()
		{
			this.state.v = State.None;
		}

	}

	#endregion

	#region Refresh

	#region txt

	public static readonly TxtLanguage txtUnFreeze = new TxtLanguage ();
	public static readonly TxtLanguage txtCancelUnFreeze = new TxtLanguage ();
	public static readonly TxtLanguage txtUnFreezing = new TxtLanguage ();
	public static readonly TxtLanguage txtStateFreeze = new TxtLanguage ();

	static RoomStateNormalFreezeUI()
	{
		txtUnFreeze.add (Language.Type.vi, "Phá băng");
		txtCancelUnFreeze.add (Language.Type.vi, "Huỷ phá băng");
		txtUnFreezing.add (Language.Type.vi, "Đang phá băng");
		txtStateFreeze.add (Language.Type.vi, "Trạng thái đóng băng");
	}

	#endregion

	public Button btnFreeze;
	public Text tvFreeze;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				RoomStateNormalFreeze freeze = this.data.freeze.v.data;
				if (freeze != null) {
					uint profileId = Server.getProfileUserId (freeze);
					if (freeze.isCanUnFreeze (profileId)) {
						// Task
						{
							switch (this.data.state.v) {
							case UIData.State.None:
								{
									destroyRoutine (wait);
								}
								break;
							case UIData.State.Request:
								{
									destroyRoutine (wait);
									// request
									{
										if (Server.IsServerOnline (freeze)) {
											freeze.requestUnFreeze (profileId);
											this.data.state.v = UIData.State.Wait;
										} else {
											Debug.LogError ("server not online: " + this);
										}
									}
								}
								break;
							case UIData.State.Wait:
								{
									if (Server.IsServerOnline (freeze)) {
										startRoutine (ref this.wait, TaskWait ());
									} else {
										this.data.state.v = UIData.State.None;
										destroyRoutine (wait);
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
							if (btnFreeze != null && tvFreeze != null) {
								switch (this.data.state.v) {
								case UIData.State.None:
									{
										btnFreeze.interactable = true;
										tvFreeze.text = txtUnFreeze.get ("UnFreeze Room?");
									}
									break;
								case UIData.State.Request:
									{
										btnFreeze.interactable = true;
										tvFreeze.text = txtCancelUnFreeze.get ("Cancel UnFreeze Room?");
									}
									break;
								case UIData.State.Wait:
									{
										btnFreeze.interactable = false;
										tvFreeze.text = txtUnFreezing.get ("UnFreezing Room");
									}
									break;
								default:
									Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("btnFreeze, tvFreeze null: " + this);
							}
						}
					} else {
						// Task
						{
							this.data.state.v = UIData.State.None;
							destroyRoutine (wait);
						}
						// btnFreeze, tvFreeze
						{
							if (btnFreeze != null && tvFreeze != null) {
								btnFreeze.interactable = false;
								tvFreeze.text = txtStateFreeze.get ("Room State Freeze");
							} else {
								Debug.LogError ("btnFreeze, tvFreeze null: " + this);
							}
						}
					}
				} else {
					Debug.LogError ("freeze null: " + this);
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

	private Server server = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.freeze.allAddCallBack (this);
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
			if (data is RoomStateNormalFreeze) {
				RoomStateNormalFreeze freeze = data as RoomStateNormalFreeze;
				// reset
				{
					if (this.data != null) {
						this.data.reset ();
					} else {
						Debug.LogError ("data null: " + this);
					}
				}
				// Parent
				{
					DataUtils.addParentCallBack (freeze, this, ref this.server);
				}
				dirty = true;
				return;
			}
			// Parent
			if (data is Server) {
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
				uiData.freeze.allRemoveCallBack (this);
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
			if (data is RoomStateNormalFreeze) {
				RoomStateNormalFreeze freeze = data as RoomStateNormalFreeze;
				// Parent
				{
					DataUtils.removeParentCallBack (freeze, this, ref this.server);
				}
				return;
			}
			// Parent
			if (data is Server) {
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
			case UIData.Property.freeze:
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
			if (wrapProperty.p is RoomStateNormalFreeze) {
				switch ((RoomStateNormalFreeze.Property)wrapProperty.n) {
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			if (wrapProperty.p is Server) {
				Server.State.OnUpdateSyncStateChange (wrapProperty, this);
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnFreeze()
	{
		if (this.data != null) {
			switch (this.data.state.v) {
			case UIData.State.None:
				this.data.state.v = UIData.State.Request;
				break;
			case UIData.State.Request:
				this.data.state.v = UIData.State.None;
				break;
			case UIData.State.Wait:
				Debug.LogError ("you are requesting: " + this);
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
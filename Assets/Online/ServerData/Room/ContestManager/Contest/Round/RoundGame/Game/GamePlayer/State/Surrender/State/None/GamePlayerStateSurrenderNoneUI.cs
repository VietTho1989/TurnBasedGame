using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

public class GamePlayerStateSurrenderNoneUI : UIBehavior<GamePlayerStateSurrenderNoneUI.UIData>
{

	#region UIData

	public class UIData : GamePlayerStateSurrenderUI.UIData.Sub
	{

		public VP<ReferenceData<GamePlayerStateSurrenderNone>> none;

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
			none,
			state
		}

		public UIData()
		{
			this.none = new VP<ReferenceData<GamePlayerStateSurrenderNone>>(this, (byte)Property.none, new ReferenceData<GamePlayerStateSurrenderNone>(null));
			this.state = new VP<State>(this, (byte)Property.state, State.None);
		}

		#endregion

		public override GamePlayerStateSurrender.State.Type getType ()
		{
			return GamePlayerStateSurrender.State.Type.None;
		}

		public void reset()
		{
			this.state.v = State.None;
		}

	}

	#endregion

	#region Refresh

	#region txt

	public static readonly TxtLanguage txtRequest = new TxtLanguage ();
	public static readonly TxtLanguage txtCancelRequest = new TxtLanguage ();
	public static readonly TxtLanguage txtRequesting = new TxtLanguage ();
	public static readonly TxtLanguage txtCannotRequest = new TxtLanguage ();

	static GamePlayerStateSurrenderNoneUI()
	{
		txtRequest.add (Language.Type.vi, "Yêu Cầu Huỷ Bỏ");
		txtCancelRequest.add (Language.Type.vi, "Huỷ yêu cầu huỷ?");
		txtRequesting.add (Language.Type.vi, "Đang yêu cầu huỷ");
		txtCannotRequest.add (Language.Type.vi, "Không thể yêu cầu huỷ");
	}

	#endregion

	public Button btnRequest;
	public Text tvRequest;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				GamePlayerStateSurrenderNone none = this.data.none.v.data;
				if (none != null) {
					uint profileId = Server.getProfileUserId (none);
					if (none.isCanRequestCancel (profileId)) {
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
									if (Server.IsServerOnline (none)) {
										none.requestMakeRequestCancel (profileId);
										this.data.state.v = UIData.State.Wait;
									} else {
										Debug.LogError ("server not online: " + this);
									}
								}
								break;
							case UIData.State.Wait:
								{
									if (Server.IsServerOnline (none)) {
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
							if (btnRequest != null && tvRequest != null) {
								btnRequest.gameObject.SetActive (true);
								switch (this.data.state.v) {
								case UIData.State.None:
									{
										btnRequest.interactable = true;
										tvRequest.text = txtRequest.get ("Request Cancel");
									}
									break;
								case UIData.State.Request:
									{
										btnRequest.interactable = true;
										tvRequest.text = txtCancelRequest.get ("Cancel Request Cancel?");
									}
									break;
								case UIData.State.Wait:
									{
										btnRequest.interactable = false;
										tvRequest.text = txtRequesting.get ("Requesting cancel...");
									}
									break;
								default:
									Debug.LogError ("unknowns state: " + this.data.state.v + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("btnRequest, tvRequest null: " + this);
							}
						}
					} else {
						// Task
						{
							this.data.state.v = UIData.State.None;
							destroyRoutine (wait);
						}
						// UI
						{
							if (btnRequest != null && tvRequest != null) {
								btnRequest.gameObject.SetActive (false);
								tvRequest.text = txtCannotRequest.get ("Cannot request cancel");
							} else {
								Debug.LogError ("btnRequest, tvRequest null: " + this);
							}
						}
					}
				} else {
					Debug.LogError ("none null: " + this);
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

	public RoomCheckChangeAdminChange<GamePlayerStateSurrenderNone> roomCheckAdminChange = new RoomCheckChangeAdminChange<GamePlayerStateSurrenderNone>();
	public GameCheckPlayerChange<GamePlayerStateSurrenderNone> gameCheckPlayerChange = new GameCheckPlayerChange<GamePlayerStateSurrenderNone>();

	private Server server = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.none.allAddCallBack (this);
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
			if (data is GamePlayerStateSurrenderNone) {
				GamePlayerStateSurrenderNone none = data as GamePlayerStateSurrenderNone;
				// reset
				{
					if (this.data != null) {
						this.data.reset ();
					} else {
						Debug.LogError ("data null: " + this);
					}
				}
				// CheckChange
				{
					// admin
					{
						roomCheckAdminChange.addCallBack (this);
						roomCheckAdminChange.setData (none);
					}
					// player
					{
						gameCheckPlayerChange.addCallBack (this);
						gameCheckPlayerChange.setData (none);
					}
				}
				// Parent
				{
					DataUtils.addParentCallBack (none, this, ref this.server);
				}
				dirty = true;
				return;
			}
			// CheckChange
			{
				if (data is RoomCheckChangeAdminChange<GamePlayerStateSurrenderNone>) {
					dirty = true;
					return;
				}
				if (data is GameCheckPlayerChange<GamePlayerStateSurrenderNone>) {
					dirty = true;
					return;
				}
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
				uiData.none.allRemoveCallBack (this);
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
			if (data is GamePlayerStateSurrenderNone) {
				GamePlayerStateSurrenderNone none = data as GamePlayerStateSurrenderNone;
				// CheckChange
				{
					// admin
					{
						roomCheckAdminChange.removeCallBack (this);
						roomCheckAdminChange.setData (null);
					}
					// player
					{
						gameCheckPlayerChange.removeCallBack (this);
						gameCheckPlayerChange.setData (null);
					}
				}
				// Parent
				{
					DataUtils.removeParentCallBack (none, this, ref this.server);
				}
				return;
			}
			// CheckChange
			{
				if (data is RoomCheckChangeAdminChange<GamePlayerStateSurrenderNone>) {
					return;
				}
				if (data is GameCheckPlayerChange<GamePlayerStateSurrenderNone>) {
					return;
				}
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
			case UIData.Property.none:
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
			if (wrapProperty.p is GamePlayerStateSurrenderNone) {
				switch ((GamePlayerStateSurrenderNone.Property)wrapProperty.n) {
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			{
				if (wrapProperty.p is RoomCheckChangeAdminChange<GamePlayerStateSurrenderNone>) {
					dirty = true;
					return;
				}
				if (wrapProperty.p is GameCheckPlayerChange<GamePlayerStateSurrenderNone>) {
					dirty = true;
					return;
				}
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

	public void onClickBtnRequest()
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
				Debug.LogError ("You are requesting: " + this);
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
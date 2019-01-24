using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

public class RoomStateNormalNormalUI : UIBehavior<RoomStateNormalNormalUI.UIData>
{

	#region UIData

	public class UIData : RoomStateNormalUI.UIData.Sub
	{

		public VP<ReferenceData<RoomStateNormalNormal>> normal;

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
			normal,
			state
		}

		public UIData() : base()
		{
			this.normal = new VP<ReferenceData<RoomStateNormalNormal>>(this, (byte)Property.normal, new ReferenceData<RoomStateNormalNormal>(null));
			this.state = new VP<State>(this, (byte)Property.state, State.None);
		}

		#endregion

		public override RoomStateNormal.State.Type getType ()
		{
			return RoomStateNormal.State.Type.Normal;
		}

		public void reset()
		{
			this.state.v = State.None;
		}

	}

	#endregion

	#region Refresh

	#region txt

	public static readonly TxtLanguage txtFreezeRoom = new TxtLanguage ();
	public static readonly TxtLanguage txtCancelFreezeRoom = new TxtLanguage ();
	public static readonly TxtLanguage txtFreezingRoom = new TxtLanguage ();
	public static readonly TxtLanguage txtRoomStateNormal = new TxtLanguage();

	static RoomStateNormalNormalUI()
	{
		txtFreezeRoom.add (Language.Type.vi, "Đóng băng phòng");
		txtCancelFreezeRoom.add (Language.Type.vi, "Huỷ đóng băng phòng");
		txtFreezingRoom.add (Language.Type.vi, "Đang đóng băng phòng");
		txtRoomStateNormal.add (Language.Type.vi, "Phòng trạng thái bình thường");
	}

	#endregion

	public Button btnNormal;
	public Text tvNormal;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				RoomStateNormalNormal normal = this.data.normal.v.data;
				if (normal != null) {
					uint profileId = Server.getProfileUserId (normal);
					if (normal.isCanFreeze (profileId)) {
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
										if (Server.IsServerOnline (normal)) {
											normal.requestFreeze (profileId);
											this.data.state.v = UIData.State.Wait;
										} else {
											Debug.LogError ("server not online: " + this);
										}
									}
								}
								break;
							case UIData.State.Wait:
								{
									if (Server.IsServerOnline (normal)) {
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
							if (btnNormal != null && tvNormal != null) {
								switch (this.data.state.v) {
								case UIData.State.None:
									{
										btnNormal.enabled = true;
										tvNormal.text = txtFreezeRoom.get ("Freeze Room?");
									}
									break;
								case UIData.State.Request:
									{
										btnNormal.enabled = true;
										tvNormal.text = txtCancelFreezeRoom.get ("Cancel Freeze Room?");
									}
									break;
								case UIData.State.Wait:
									{
										btnNormal.enabled = false;
										tvNormal.text = txtFreezingRoom.get ("Freezing Room");
									}
									break;
								default:
									Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("btnNormal, tvNormal null: " + this);
							}
						}
					} else {
						// Task
						{
							this.data.state.v = UIData.State.None;
							destroyRoutine (wait);
						}
						// btnNormal, tvNormal
						{
							if (btnNormal != null && tvNormal != null) {
								btnNormal.enabled = false;
								tvNormal.text = txtRoomStateNormal.get ("Room State Normal");
							} else {
								Debug.LogError ("btnNormal, tvNormal null: " + this);
							}
						}
					}
				} else {
					Debug.LogError ("normal null: " + this);
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
				uiData.normal.allAddCallBack (this);
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
			if (data is RoomStateNormalNormal) {
				RoomStateNormalNormal normal = data as RoomStateNormalNormal;
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
					DataUtils.addParentCallBack (normal, this, ref this.server);
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
				uiData.normal.allRemoveCallBack (this);
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
			if (data is RoomStateNormalNormal) {
				RoomStateNormalNormal normal = data as RoomStateNormalNormal;
				// Parent
				{
					DataUtils.removeParentCallBack (normal, this, ref this.server);
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
			case UIData.Property.normal:
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
			if (wrapProperty.p is RoomStateNormalNormal) {
				switch ((RoomStateNormalNormal.Property)wrapProperty.n) {
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

	public void onClickBtnNormal()
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
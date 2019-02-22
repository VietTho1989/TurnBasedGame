using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

namespace GameManager.Match
{
	public class RequestNewRoundAskBtnAcceptUI : UIBehavior<RequestNewRoundAskBtnAcceptUI.UIData>
	{

		#region UIData

		public class UIData : RequestNewRoundStateAskUI.UIData.Btn
		{

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
				state
			}

			public UIData() : base()
			{
				this.state = new VP<State>(this, (byte)Property.state, State.None);
			}

			#endregion

			public override Type getType ()
			{
				return Type.Accept;
			}

			public void reset()
			{
				this.state.v = State.None;
			}

		}

		#endregion

		#region Refresh

		public Button btnAccept;
		public Text tvAccept;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
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
									RequestNewRoundStateAskUI.UIData requestNewRoundStateAskUIData = this.data.findDataInParent<RequestNewRoundStateAskUI.UIData> ();
									if (requestNewRoundStateAskUIData != null) {
										RequestNewRoundStateAsk requestNewRoundStateAsk = requestNewRoundStateAskUIData.requestNewRoundStateAsk.v.data;
										if (requestNewRoundStateAsk != null) {
											if (Server.IsServerOnline (requestNewRoundStateAsk)) {
												requestNewRoundStateAsk.requestAccept (Server.getProfileUserId (requestNewRoundStateAsk));
												this.data.state.v = UIData.State.Wait;
											} else {
												Debug.LogError ("server not online: " + this);
											}
										} else {
											Debug.LogError ("requestNewRoundStateAsk null: " + this);
										}
									} else {
										Debug.LogError ("requestNewRoundStateAskUIData null: " + this);
									}
								}
							}
							break;
						case UIData.State.Wait:
							{
								RequestNewRoundStateAskUI.UIData requestNewRoundStateAskUIData = this.data.findDataInParent<RequestNewRoundStateAskUI.UIData> ();
								if (requestNewRoundStateAskUIData != null) {
									RequestNewRoundStateAsk requestNewRoundStateAsk = requestNewRoundStateAskUIData.requestNewRoundStateAsk.v.data;
									if (requestNewRoundStateAsk != null) {
										if (Server.IsServerOnline (requestNewRoundStateAsk)) {
											startRoutine (ref this.wait, TaskWait ());
										} else {
											Debug.LogError ("server not online: " + this);
											destroyRoutine (wait);
										}
									} else {
										Debug.LogError ("requestNewRoundStateAsk null: " + this);
									}
								} else {
									Debug.LogError ("requestNewRoundStateAskUIData null: " + this);
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
						if (btnAccept != null && tvAccept != null) {
							switch (this.data.state.v) {
							case UIData.State.None:
								{
									btnAccept.interactable = true;
									tvAccept.text = "Accept";
								}
								break;
							case UIData.State.Request:
								{
									btnAccept.interactable = true;
									tvAccept.text = "Cancel Accept?";
								}
								break;
							case UIData.State.Wait:
								{
									btnAccept.interactable = false;
									tvAccept.text = "Accepting...";
								}
								break;
							default:
								Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
								break;
							}
						} else {
							Debug.LogError ("btnAccept, tvAccept null: " + this);
						}
					}
				} else {
					// Debug.LogError ("data null: " + this);
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
				if (this.data != null) {
					this.data.state.v = UIData.State.None;
				} else {
					Debug.LogError ("data null: " + this);
				}
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

		private RequestNewRoundStateAskUI.UIData requestNewRoundStateAskUIData = null;
		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.requestNewRoundStateAskUIData);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is RequestNewRoundStateAskUI.UIData) {
					RequestNewRoundStateAskUI.UIData requestNewRoundStateAskUIData = data as RequestNewRoundStateAskUI.UIData;
					// Child
					{
						requestNewRoundStateAskUIData.requestNewRoundStateAsk.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is RequestNewRoundStateAsk) {
						RequestNewRoundStateAsk requestNewRoundStateAsk = data as RequestNewRoundStateAsk;
						// Reset
						{
							if (this.data != null) {
								this.data.reset ();
							} else {
								Debug.LogError ("data null: " + this);
							}
						}
						// Parent
						{
							DataUtils.addParentCallBack (requestNewRoundStateAsk, this, ref this.server);
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
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.requestNewRoundStateAskUIData);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			{
				if (data is RequestNewRoundStateAskUI.UIData) {
					RequestNewRoundStateAskUI.UIData requestNewRoundStateAskUIData = data as RequestNewRoundStateAskUI.UIData;
					// Child
					{
						requestNewRoundStateAskUIData.requestNewRoundStateAsk.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is RequestNewRoundStateAsk) {
						RequestNewRoundStateAsk requestNewRoundStateAsk = data as RequestNewRoundStateAsk;
						// Parent
						{
							DataUtils.removeParentCallBack (requestNewRoundStateAsk, this, ref this.server);
						}
						return;
					}
					// Parent
					if (data is Server) {
						return;
					}
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
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			{
				if (wrapProperty.p is RequestNewRoundStateAskUI.UIData) {
					switch ((RequestNewRoundStateAskUI.UIData.Property)wrapProperty.n) {
					case RequestNewRoundStateAskUI.UIData.Property.requestNewRoundStateAsk:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case RequestNewRoundStateAskUI.UIData.Property.btn:
						break;
					case RequestNewRoundStateAskUI.UIData.Property.visibility:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				{
					if (wrapProperty.p is RequestNewRoundStateAsk) {
						return;
					}
					// Parent
					if (wrapProperty.p is Server) {
						Server.State.OnUpdateSyncStateChange (wrapProperty, this);
						return;
					}
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
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Foundation.Tasks;
using AdvancedCoroutines;

namespace GameState
{
	public class PlayNormalUI : UIBehavior<PlayNormalUI.UIData>
	{

		#region UIData

		public class UIData : PlayUI.UIData.Sub
		{

			public VP<ReferenceData<PlayNormal>> playNormal;

			#region State

			public enum State
			{
				Normal,
				Request,
				Wait
			}

			public VP<State> state;

			#endregion

			#region Constructor

			public enum Property
			{
				playNormal,
				state
			}

			public UIData() : base()
			{
				this.playNormal = new VP<ReferenceData<PlayNormal>>(this, (byte)Property.playNormal, new ReferenceData<PlayNormal>(null));
				this.state = new VP<State>(this, (byte)Property.state, State.Normal);
			}

			#endregion

			public override Play.Sub.Type getType ()
			{
				return Play.Sub.Type.Normal;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public static readonly TxtLanguage txtPause = new TxtLanguage();
		public static readonly TxtLanguage txtCancelPause = new TxtLanguage ();
		public static readonly TxtLanguage txtPausing = new TxtLanguage();
		public static readonly TxtLanguage txtCannotPause = new TxtLanguage();

		static PlayNormalUI()
		{
			txtPause.add (Language.Type.vi, "Tạm Dừng");
			txtCancelPause.add (Language.Type.vi, "Huỷ tạm dừng?");
			txtPausing.add (Language.Type.vi, "Đang tạm dừng...");
			txtCannotPause.add (Language.Type.vi, "Không thể tạm dừng");
		}

		#endregion

		public Button btnPause;
		public Text tvPause;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					PlayNormal playNormal = this.data.playNormal.v.data;
					if (playNormal != null) {
						if (Play.IsCanChange (playNormal, Server.getProfileUserId (playNormal))) {
							// Task
							{
								switch (this.data.state.v) {
								case UIData.State.Normal:
									{
										destroyRoutine (wait);
									}
									break;
								case UIData.State.Request:
									{
										destroyRoutine (wait);
										if (Server.IsServerOnline (playNormal)) {
											playNormal.requestPause (Server.getProfileUserId (playNormal));
											this.data.state.v = UIData.State.Wait;
										} else {
											Debug.LogError ("server offline: " + this);
										}
									}
									break;
								case UIData.State.Wait:
									{
										if (Server.IsServerOnline (playNormal)) {
											if (Routine.IsNull (wait)) {
												wait = CoroutineManager.StartCoroutine (TaskWait (), this.gameObject);
											} else {
												Debug.LogError ("Why routine != null: " + this);
											}
										} else {
											this.data.state.v = UIData.State.Normal;
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
								if (btnPause != null && tvPause != null) {
									switch (this.data.state.v) {
									case UIData.State.Normal:
										{
											btnPause.interactable = true;
											tvPause.text = txtPause.get ("Pause");
										}
										break;
									case UIData.State.Request:
										{
											btnPause.interactable = true;
											tvPause.text = txtCancelPause.get ("Cancel pause?");
										}
										break;
									case UIData.State.Wait:
										{
											btnPause.interactable = false;
											tvPause.text = txtPausing.get ("Pausing...");
										}
										break;
									default:
										Debug.LogError ("Unknown state: " + this.data.state.v + "; " + this);
										break;
									}
								} else {
									Debug.LogError ("btnPause, tvPause null: " + this);
								}
							}
						} else {
							// Task
							{
								this.data.state.v = UIData.State.Normal;
								destroyRoutine (wait);
							}
							// UI
							{
								if (btnPause != null && tvPause != null) {
									btnPause.interactable = false;
									tvPause.text = txtCannotPause.get ("Cannot pause");
								} else {
									Debug.LogError ("btnPause, tvPause null: " + this);
								}
							}
						}
					} else {
						// Debug.LogError ("playNormal null: " + this);
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region Task wait

		private Routine wait;

		public IEnumerator TaskWait()
		{
			if (this.data != null) {
				yield return new Wait (Global.WaitSendTime);
				if (this.data != null) {
					this.data.state.v = UIData.State.Normal;
				} else {
					Debug.LogError ("data null: " + this);
				}
				Debug.LogError ("error, why cannot request: " + this);
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

		private GameCheckPlayerChange<PlayNormal> gamePlayerCheckChange = new GameCheckPlayerChange<PlayNormal> ();
		private RoomCheckChangeAdminChange<PlayNormal> roomCheckAdminChange = new RoomCheckChangeAdminChange<PlayNormal> ();
		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.playNormal.allAddCallBack (this);
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
				if (data is PlayNormal) {
					PlayNormal playNormal = data as PlayNormal;
					// Reset
					{
						if (this.data != null) {
							this.data.state.v = UIData.State.Normal;
						} else {
							Debug.LogError ("data null: " + this);
						}
					}
					// CheckChange
					{
						// gamePlayer
						{
							gamePlayerCheckChange.addCallBack (this);
							gamePlayerCheckChange.setData (playNormal);
						}
						// roomAdmin
						{
							roomCheckAdminChange.addCallBack (this);
							roomCheckAdminChange.setData (playNormal);
						}
					}
					// Parent
					{
						DataUtils.addParentCallBack (playNormal, this, ref this.server);
					}
					dirty = true;
					return;
				}
				// CheckChange
				{
					if (data is GameCheckPlayerChange<PlayNormal>) {
						dirty = true;
						return;
					}
					if (data is RoomCheckChangeAdminChange<PlayNormal>) {
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
					uiData.playNormal.allRemoveCallBack (this);
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
				if (data is PlayNormal) {
					PlayNormal playNormal = data as PlayNormal;
					// CheckChange
					{
						// gamePlayer
						{
							gamePlayerCheckChange.removeCallBack (this);
							gamePlayerCheckChange.setData (null);
						}
						// roomAdmin
						{
							roomCheckAdminChange.removeCallBack (this);
							roomCheckAdminChange.setData (null);
						}
					}
					// Parent
					{
						DataUtils.removeParentCallBack (playNormal, this, ref this.server);
					}
					return;
				}
				// CheckChange
				{
					if (data is GameCheckPlayerChange<PlayNormal>) {
						return;
					}
					if (data is RoomCheckChangeAdminChange<PlayNormal>) {
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
				case UIData.Property.playNormal:
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
				if (wrapProperty.p is PlayNormal) {
					switch ((PlayNormal.Property)wrapProperty.n) {
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// CheckChange
				{
					if (wrapProperty.p is GameCheckPlayerChange<PlayNormal>) {
						dirty = true;
						return;
					}
					if (wrapProperty.p is RoomCheckChangeAdminChange<PlayNormal>) {
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

		public void onClickBtnPause()
		{
			if (this.data != null) {
				if (this.data.state.v == UIData.State.Normal) {
					this.data.state.v = UIData.State.Request;
				} else if (this.data.state.v == UIData.State.Request) {
					this.data.state.v = UIData.State.Normal;
				} else {
					Debug.LogError ("you are requesting: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}
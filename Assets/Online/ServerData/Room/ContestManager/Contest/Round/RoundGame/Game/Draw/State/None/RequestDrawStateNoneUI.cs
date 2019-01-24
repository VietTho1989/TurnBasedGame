using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RequestDrawStateNoneUI : UIBehavior<RequestDrawStateNoneUI.UIData>
{

	#region UIData

	public class UIData : RequestDrawUI.UIData.Sub
	{
		
		public VP<ReferenceData<RequestDrawStateNone>> requestDrawStateNone;

		public override RequestDraw.State.Type getType ()
		{
			return RequestDraw.State.Type.None;
		}

		#region UIData

		public enum Property
		{
			requestDrawStateNone
		}

		public UIData() : base()
		{
			this.requestDrawStateNone = new VP<ReferenceData<RequestDrawStateNone>>(this, (byte)Property.requestDrawStateNone, new ReferenceData<RequestDrawStateNone>(null));
		}

		#endregion

	}

	#endregion

	#region Refresh

	#region txt

	public Text lbTitle;
	public static readonly TxtLanguage txtTitle = new TxtLanguage ();

	public Text tvRequest;
	public static readonly TxtLanguage txtRequest = new TxtLanguage();

	static RequestDrawStateNoneUI()
	{
		txtTitle.add (Language.Type.vi, "Yêu Cầu Hoà: Trạng Thái Không");
		txtRequest.add (Language.Type.vi, "Yêu Cầu");
	}

	#endregion

	public Button btnRequestDraw;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				RequestDrawStateNone requestDrawStateNone = this.data.requestDrawStateNone.v.data;
				if (requestDrawStateNone != null) {
					// btnRequestDraw
					{
						if (btnRequestDraw != null) {
							uint userId = Server.getProfileUserId (requestDrawStateNone);
							if (requestDrawStateNone.isCanRequestDraw (userId)) {
								btnRequestDraw.gameObject.SetActive (true);
							} else {
								btnRequestDraw.gameObject.SetActive (false);
							}
						} else {
							Debug.LogError ("btnRequestDraw null");
						}
					}
				} else {
					Debug.LogError ("requestDrawStateNone null");
				}
				// txt
				{
					if (lbTitle != null) {
						lbTitle.text = txtTitle.get ("Request Draw State None");
					} else {
						Debug.LogError ("lbTitle null: " + this);
					}
					if (tvRequest != null) {
						tvRequest.text = txtRequest.get ("Request");
					} else {
						Debug.LogError ("tvRequest null: " + this);
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

	private GameIsPlayingChange<RequestDrawStateNone> gameIsPlayingChange = new GameIsPlayingChange<RequestDrawStateNone>();
	private GameCheckPlayerChange<RequestDrawStateNone> gameCheckPlayerChange = new GameCheckPlayerChange<RequestDrawStateNone>();
	private RoomCheckChangeAdminChange<RequestDrawStateNone> roomCheckAdminChange = new RoomCheckChangeAdminChange<RequestDrawStateNone> ();

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.requestDrawStateNone.allAddCallBack (this);
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
			if (data is RequestDrawStateNone) {
				RequestDrawStateNone requestDrawStateNone = data as RequestDrawStateNone;
				// CheckChange
				{
					// isPlaying
					{
						gameIsPlayingChange.addCallBack (this);
						gameIsPlayingChange.setData (requestDrawStateNone);
					}
					// gamePlayer
					{
						gameCheckPlayerChange.addCallBack (this);
						gameCheckPlayerChange.setData (requestDrawStateNone);
					}
					// roomCheckAdminChange
					{
						roomCheckAdminChange.addCallBack (this);
						roomCheckAdminChange.setData (requestDrawStateNone);
					}
				}
				dirty = true;
				return;
			}
			// CheckChange
			{
				if (data is GameIsPlayingChange<RequestDrawStateNone>) {
					dirty = true;
					return;
				}
				if (data is GameCheckPlayerChange<RequestDrawStateNone>) {
					dirty = true;
					return;
				}
				if (data is RoomCheckChangeAdminChange<RequestDrawStateNone>) {
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
			// Setting
			Setting.get().removeCallBack(this);
			// Child
			{
				uiData.requestDrawStateNone.allRemoveCallBack (this);
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
			if (data is RequestDrawStateNone) {
				// RequestDrawStateNone requestDrawStateNone = data as RequestDrawStateNone;
				// CheckChange
				{
					// isPlaying
					{
						gameIsPlayingChange.removeCallBack (this);
						gameIsPlayingChange.setData (null);
					}
					// gamePlayer
					{
						gameCheckPlayerChange.removeCallBack (this);
						gameCheckPlayerChange.setData (null);
					}
					// roomCheckAdminChange
					{
						roomCheckAdminChange.removeCallBack (this);
						roomCheckAdminChange.setData (null);
					}
				}
				return;
			}
			// CheckChange
			{
				if (data is GameIsPlayingChange<RequestDrawStateNone>) {
					return;
				}
				if (data is GameCheckPlayerChange<RequestDrawStateNone>) {
					return;
				}
				if (data is RoomCheckChangeAdminChange<RequestDrawStateNone>) {
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
			case UIData.Property.requestDrawStateNone:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
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
			if (wrapProperty.p is RequestDrawStateNone) {
				switch ((RequestDrawStateNone.Property)wrapProperty.n) {
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			{
				if (wrapProperty.p is GameIsPlayingChange<RequestDrawStateNone>) {
					dirty = true;
					return;
				}
				if (wrapProperty.p is GameCheckPlayerChange<RequestDrawStateNone>) {
					dirty = true;
					return;
				}
				if (wrapProperty.p is RoomCheckChangeAdminChange<RequestDrawStateNone>) {
					dirty = true;
					return;
				}
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnRequestDraw()
	{
		if (this.data != null) {
			if (!GameUI.UIData.IsReplay (this.data)) {
				RequestDrawStateNone requestDrawStateNone = this.data.requestDrawStateNone.v.data;
				if (requestDrawStateNone != null) {
					uint userId = Server.getProfileUserId (requestDrawStateNone);
					if (requestDrawStateNone.isCanRequestDraw (userId)) {
						requestDrawStateNone.requestMakeRequestDraw (userId);
					} else {
						Debug.LogError ("Cannot request draw: " + userId);
					}
				} else {
					Debug.LogError ("requestDrawStateNone null");
				}
			} else {
				Debug.LogError ("this is replay, cannot request: " + this);
			}
		} else {
			Debug.LogError ("data null");
		}
	}
}
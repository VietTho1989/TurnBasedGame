using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AccountDeviceUI : UIBehavior<AccountDeviceUI.UIData>
{

	#region UIData

	public class UIData : AccountUI.UIData.Sub
	{

		public VP<EditData<AccountDevice>> editAccountDevice;

		public VP<RequestChangeStringUI.UIData> imei;

		public VP<RequestChangeStringUI.UIData> deviceName;

		public VP<RequestChangeEnumUI.UIData> deviceType;

		#region customName

		public VP<RequestChangeStringUI.UIData> customName;

		public void makeRequestChangeCustomName (RequestChangeUpdate<string>.UpdateData update, string newCustomName)
		{
			// Find
			AccountDevice accountDevice = null;
			{
				EditData<AccountDevice> editAccountDevice = this.editAccountDevice.v;
				if (editAccountDevice != null) {
					accountDevice = editAccountDevice.show.v.data;
				} else {
					Debug.LogError ("editAccountDevice null: " + this);
				}
			}
			// Process
			if (accountDevice != null) {
				accountDevice.requestChangeCustomName (accountDevice.getRequestAccountUserId (), newCustomName);
			} else {
				Debug.LogError ("accountDevice null: " + this);
			}
		}

		#endregion

		#region avatarUrl

		public VP<RequestChangeStringUI.UIData> avatarUrl;

		public void makeRequestChangeAvatarUrl (RequestChangeUpdate<string>.UpdateData update, string newAvatarUrl)
		{
			// Find
			AccountDevice accountDevice = null;
			{
				EditData<AccountDevice> editAccountDevice = this.editAccountDevice.v;
				if (editAccountDevice != null) {
					accountDevice = editAccountDevice.show.v.data;
				} else {
					Debug.LogError ("editAccountDevice null: " + this);
				}
			}
			// Process
			if (accountDevice != null) {
				accountDevice.requestChangeAvatarUrl (accountDevice.getRequestAccountUserId (), newAvatarUrl);
			} else {
				Debug.LogError ("accountDevice null: " + this);
			}
		}

		public void makeAvatarUrl()
		{
			if (this.avatarUrl.v == null) {
				RequestChangeStringUI.UIData newAvatarUrl = new RequestChangeStringUI.UIData ();
				{
					newAvatarUrl.uid = this.avatarUrl.makeId ();
					// event
					newAvatarUrl.updateData.v.request.v = makeRequestChangeAvatarUrl;
				}
				this.avatarUrl.v = newAvatarUrl;
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			editAccountDevice,
			imei,
			deviceName,
			deviceType,
			customName,
			avatarUrl
		}

		public UIData() : base()
		{
			this.editAccountDevice = new VP<EditData<AccountDevice>>(this, (byte)Property.editAccountDevice, new EditData<AccountDevice>());
			// imei
			{
				this.imei = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.imei, new RequestChangeStringUI.UIData());
				this.imei.v.updateData.v.canRequestChange.v = false;
			}
			// deviceName
			{
				this.deviceName = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.deviceName, new RequestChangeStringUI.UIData());
				this.deviceName.v.updateData.v.canRequestChange.v = false;
			}
			// deviceType
			{
				this.deviceType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.deviceType, new RequestChangeEnumUI.UIData());
				// options
				{
					foreach (DeviceType type in System.Enum.GetValues(typeof(DeviceType))) {
						this.deviceType.v.options.add(type.ToString());
					}
				}
			}
			// customName
			{
				this.customName = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.customName, new RequestChangeStringUI.UIData());
				// event
				this.customName.v.updateData.v.request.v = makeRequestChangeCustomName;
			}
			// avatarUrl
			{
				this.avatarUrl = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.avatarUrl, new RequestChangeStringUI.UIData());
				// event
				this.avatarUrl.v.updateData.v.request.v = makeRequestChangeAvatarUrl;
			}
		}

		#endregion

		public override Account.Type getType ()
		{
			return Account.Type.DEVICE;
		}

	}

	#endregion

	#region Refresh

	#region txt

	public Text lbTitle;
	public static readonly TxtLanguage txtTitle = new TxtLanguage();

	public Text lbImei;
	public static readonly TxtLanguage txtImei = new TxtLanguage ();

	public Text lbDeviceName;
	public static readonly TxtLanguage txtDeviceName = new TxtLanguage();

	public Text lbDeviceType;
	public static readonly TxtLanguage txtDeviceType = new TxtLanguage();

	public Text lbCustomName;
	public static readonly TxtLanguage txtCustomName = new TxtLanguage();

	public Text lbAvatarUrl;
	public static readonly TxtLanguage txtAvatarUrl = new TxtLanguage();

	static AccountDeviceUI()
	{
		txtTitle.add (Language.Type.vi, "Tài khoản thiết bị");
		txtImei.add (Language.Type.vi, "Imei");
		txtDeviceName.add (Language.Type.vi, "Tên thiết bị");
		txtDeviceType.add (Language.Type.vi, "Tên loại thiết bị");
		txtCustomName.add (Language.Type.vi, "Tên");
		txtAvatarUrl.add (Language.Type.vi, "Đường dẫn avatar");
	}

	#endregion

	private bool needReset = true;
	public GameObject differentIndicator;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				EditData<AccountDevice> editAccountDevice = this.data.editAccountDevice.v;
				if (editAccountDevice != null) {
					editAccountDevice.update ();
					// get show
					AccountDevice show = editAccountDevice.show.v.data;
					AccountDevice compare = editAccountDevice.compare.v.data;
					if (show != null) {
						// differentIndicator
						if (differentIndicator != null) {
							bool isDifferent = false;
							{
								if (editAccountDevice.compareOtherType.v.data != null) {
									if (editAccountDevice.compareOtherType.v.data.GetType () != show.GetType ()) {
										isDifferent = true;
									}
								}
							}
							differentIndicator.SetActive (isDifferent);
						} else {
							Debug.LogError ("differentIndicator null: " + this);
						}
						// request
						{
							// get server state
							Server.State.Type serverState = Server.State.Type.Connect;
							{
								Server server = show.findDataInParent<Server> ();
								if (server != null) {
									if (server.state.v != null) {
										serverState = server.state.v.getType ();
									} else {
										Debug.LogError ("server state null: " + this);
									}
								} else {
									Debug.LogError ("server null: " + this);
								}
							}
							// set origin
							{
								// imei
								{
									RequestChangeStringUI.UIData imei = this.data.imei.v;
									if (imei != null) {
										// update
										RequestChangeUpdate<string>.UpdateData updateData = imei.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.imei.v;
											updateData.canRequestChange.v = false;// editAccountDevice.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												imei.showDifferent.v = true;
												imei.compare.v = compare.imei.v;
											} else {
												imei.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("imei null: " + this);
									}
									// Container
									if (imeiContainer != null) {
										imeiContainer.parent.gameObject.SetActive (imei != null);
									} else {
										Debug.LogError ("imeiContainer null: " + this);
									}
								}
								// deviceName
								{
									RequestChangeStringUI.UIData deviceName = this.data.deviceName.v;
									if (deviceName != null) {
										// update
										RequestChangeUpdate<string>.UpdateData updateData = deviceName.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.deviceName.v;
											updateData.canRequestChange.v = false;// editAccountDevice.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												deviceName.showDifferent.v = true;
												deviceName.compare.v = compare.deviceName.v;
											} else {
												deviceName.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("deviceName null: " + this);
									}
									// Container
									if (deviceNameContainer != null) {
										deviceNameContainer.parent.gameObject.SetActive (deviceName != null);
									} else {
										Debug.LogError ("deviceNameContainer null: " + this);
									}
								}
								// deviceType
								{
									RequestChangeEnumUI.UIData deviceType = this.data.deviceType.v;
									if (deviceType != null) {
										// update
										RequestChangeUpdate<int>.UpdateData updateData = deviceType.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.deviceType.v;
											updateData.canRequestChange.v = false;// editAccountDevice.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												deviceType.showDifferent.v = true;
												deviceType.compare.v = compare.deviceType.v;
											} else {
												deviceType.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("deviceType null: " + this);
									}
									// Container
									if (deviceTypeContainer != null) {
										deviceTypeContainer.parent.gameObject.SetActive (deviceType != null);
									} else {
										Debug.LogError ("deviceTypeContainer null: " + this);
									}
								}
								// customName
								{
									RequestChangeStringUI.UIData customName = this.data.customName.v;
									if (customName != null) {
										// update
										RequestChangeUpdate<string>.UpdateData updateData = customName.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.customName.v;
											updateData.canRequestChange.v = editAccountDevice.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												customName.showDifferent.v = true;
												customName.compare.v = compare.customName.v;
											} else {
												customName.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("customName null: " + this);
									}
									// Container
									if (customNameContainer != null) {
										customNameContainer.parent.gameObject.SetActive (customName != null);
									} else {
										Debug.LogError ("customNameContainer null: " + this);
									}
								}
								// avatarUrl
								{
									RequestChangeStringUI.UIData avatarUrl = this.data.avatarUrl.v;
									if (avatarUrl != null) {
										// update
										RequestChangeUpdate<string>.UpdateData updateData = avatarUrl.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.avatarUrl.v;
											updateData.canRequestChange.v = editAccountDevice.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												avatarUrl.showDifferent.v = true;
												avatarUrl.compare.v = compare.avatarUrl.v;
											} else {
												avatarUrl.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("avatarUrl null: " + this);
									}
									// Container
									if (avatarUrlContainer != null) {
										avatarUrlContainer.parent.gameObject.SetActive (avatarUrl != null);
									} else {
										Debug.LogError ("avatarUrlContainer null: " + this);
									}
								}
							}
							// reset?
							if (needReset) {
								needReset = false;
								// imei
								{
									RequestChangeStringUI.UIData imei = this.data.imei.v;
									if (imei != null) {
										// update
										RequestChangeUpdate<string>.UpdateData updateData = imei.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.imei.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("imei null: " + this);
									}
								}
								// deviceName
								{
									RequestChangeStringUI.UIData deviceName = this.data.deviceName.v;
									if (deviceName != null) {
										// update
										RequestChangeUpdate<string>.UpdateData updateData = deviceName.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.deviceName.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("deviceName null: " + this);
									}
								}
								// deviceType
								{
									RequestChangeEnumUI.UIData deviceType = this.data.deviceType.v;
									if (deviceType != null) {
										// update
										RequestChangeUpdate<int>.UpdateData updateData = deviceType.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.deviceType.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("deviceType null: " + this);
									}
								}
								// customName
								{
									RequestChangeStringUI.UIData customName = this.data.customName.v;
									if (customName != null) {
										// update
										RequestChangeUpdate<string>.UpdateData updateData = customName.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.customName.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("customName null: " + this);
									}
								}
								// avatarUrl
								{
									RequestChangeStringUI.UIData avatarUrl = this.data.avatarUrl.v;
									if (avatarUrl != null) {
										// update
										RequestChangeUpdate<string>.UpdateData updateData = avatarUrl.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.avatarUrl.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.Log ("avatarUrl null: " + this);
									}
								}
							}
						}
					} else {
						Debug.LogError ("show null: " + this);
					}
				} else {
					Debug.LogError ("editAccountDevice null: " + this);
				}
				// txt
				{
					if (lbTitle != null) {
						lbTitle.text = txtTitle.get ("Account Device");
					} else {
						Debug.LogError ("lbTitle null: " + this);
					}
					if (lbImei != null) {
						lbImei.text = txtImei.get ("Imei");
					} else {
						Debug.LogError ("lbImei null: " + this);
					}
					if (lbDeviceName != null) {
						lbDeviceName.text = txtDeviceName.get ("Device Name");
					} else {
						Debug.LogError ("lbDeviceName null: " + this);
					}
					if (lbDeviceType != null) {
						lbDeviceType.text = txtDeviceType.get ("Device Type");
					} else {
						Debug.LogError ("lbDeviceType null: " + this);
					}
					if (lbCustomName != null) {
						lbCustomName.text = txtCustomName.get ("Custom Name");
					} else {
						Debug.LogError ("lbCustomName null: " + this);
					}
					if (lbAvatarUrl != null) {
						lbAvatarUrl.text = txtAvatarUrl.get ("Avatar Url");
					} else {
						Debug.LogError ("lbAvatarUrl null: " + this);
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

	public RequestChangeStringUI requestStringPrefab;
	public RequestChangeEnumUI requestEnumPrefab;

	public Transform imeiContainer;
	public Transform deviceNameContainer;
	public Transform deviceTypeContainer;
	public Transform customNameContainer;
	public Transform avatarUrlContainer;

	private Server server = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.editAccountDevice.allAddCallBack (this);
				uiData.imei.allAddCallBack (this);
				uiData.deviceName.allAddCallBack (this);
				uiData.deviceType.allAddCallBack (this);
				uiData.customName.allAddCallBack (this);
				uiData.avatarUrl.allAddCallBack (this);
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
			// editAccountDevice
			{
				if (data is EditData<AccountDevice>) {
					EditData<AccountDevice> editAccountDevice = data as EditData<AccountDevice>;
					// Child
					{
						editAccountDevice.show.allAddCallBack (this);
						editAccountDevice.compare.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is AccountDevice) {
						AccountDevice accountDevice = data as AccountDevice;
						// Parent
						{
							DataUtils.addParentCallBack (accountDevice, this, ref this.server);
						}
						needReset = true;
						dirty = true;
						return;
					}
					// Parent
					{
						if (data is Server) {
							dirty = true;
							return;
						}
					}
				}
			}
			if (data is RequestChangeStringUI.UIData) {
				RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
				// UI
				{
					WrapProperty wrapProperty = requestChange.p;
					if (wrapProperty != null) {
						switch ((UIData.Property)wrapProperty.n) {
						case UIData.Property.imei:
							UIUtils.Instantiate (requestChange, requestStringPrefab, imeiContainer);
							break;
						case UIData.Property.deviceName:
							UIUtils.Instantiate (requestChange, requestStringPrefab, deviceNameContainer);
							break;
						case UIData.Property.customName:
							UIUtils.Instantiate (requestChange, requestStringPrefab, customNameContainer);
							break;
						case UIData.Property.avatarUrl:
							UIUtils.Instantiate (requestChange, requestStringPrefab, avatarUrlContainer);
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("wrapProperty null: " + this);
					}
				}
				dirty = true;
				return;
			}
			if (data is RequestChangeEnumUI.UIData) {
				RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
				// UI
				{
					WrapProperty wrapProperty = requestChange.p;
					if (wrapProperty != null) {
						switch ((UIData.Property)wrapProperty.n) {
						case UIData.Property.deviceType:
							UIUtils.Instantiate (requestChange, requestEnumPrefab, deviceTypeContainer);
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("wrapProperty null: " + this);
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
				uiData.editAccountDevice.allRemoveCallBack (this);
				uiData.imei.allRemoveCallBack (this);
				uiData.deviceName.allRemoveCallBack (this);
				uiData.deviceType.allRemoveCallBack (this);
				uiData.customName.allRemoveCallBack (this);
				uiData.avatarUrl.allRemoveCallBack (this);
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
			// editAccountDevice
			{
				if (data is EditData<AccountDevice>) {
					EditData<AccountDevice> editAccountDevice = data as EditData<AccountDevice>;
					// Child
					{
						editAccountDevice.show.allRemoveCallBack (this);
						editAccountDevice.compare.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is AccountDevice) {
						AccountDevice accountDevice = data as AccountDevice;
						// Parent
						{
							DataUtils.removeParentCallBack (accountDevice, this, ref this.server);
						}
						return;
					}
					// Parent
					{
						if (data is Server) {
							return;
						}
					}
				}
			}
			if (data is RequestChangeStringUI.UIData) {
				RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
				// UI
				{
					requestChange.removeCallBackAndDestroy (typeof(RequestChangeStringUI));
				}
				return;
			}
			if (data is RequestChangeEnumUI.UIData) {
				RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
				// UI
				{
					requestChange.removeCallBackAndDestroy (typeof(RequestChangeEnumUI));
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
			case UIData.Property.editAccountDevice:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.imei:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.deviceName:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.deviceType:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.customName:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.avatarUrl:
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
			// editAccountDevice
			{
				if (wrapProperty.p is EditData<AccountDevice>) {
					switch ((EditData<AccountDevice>.Property)wrapProperty.n) {
					case EditData<AccountDevice>.Property.origin:
						dirty = true;
						break;
					case EditData<AccountDevice>.Property.show:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case EditData<AccountDevice>.Property.compare:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case EditData<AccountDevice>.Property.compareOtherType:
						dirty = true;
						break;
					case EditData<AccountDevice>.Property.canEdit:
						dirty = true;
						break;
					case EditData<AccountDevice>.Property.editType:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				{
					if (wrapProperty.p is AccountDevice) {
						switch ((AccountDevice.Property)wrapProperty.n) {
						case AccountDevice.Property.imei:
							dirty = true;
							break;
						case AccountDevice.Property.deviceName:
							dirty = true;
							break;
						case AccountDevice.Property.deviceType:
							dirty = true;
							break;
						case AccountDevice.Property.customName:
							dirty = true;
							break;
						case AccountDevice.Property.avatarUrl:
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
						if (wrapProperty.p is Server) {
							Server.State.OnUpdateSyncStateChange (wrapProperty, this);
							return;
						}
					}
				}
			}
			if (wrapProperty.p is RequestChangeStringUI.UIData) {
				return;
			}
			if (wrapProperty.p is RequestChangeEnumUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
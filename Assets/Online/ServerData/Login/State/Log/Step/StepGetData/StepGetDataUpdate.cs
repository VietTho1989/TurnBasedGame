using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class StepGetDataUpdate : UpdateBehavior<StepGetData>
	{

		#region update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Login login = this.data.findDataInParent<Login> ();
					if (login != null) {
						Account account = login.account.v;
						if (account != null) {
							switch(account.getType()){
							case Account.Type.DEVICE:
								{
									// need new?
									bool needNew = true;
									{
										if (this.data.sub.v != null) {
											if (this.data.sub.v is StepGetDataDevice) {
												needNew = false;
											}
										}
									}
									// Process
									if (needNew) {
										StepGetDataDevice stepGetDataDevice = new StepGetDataDevice ();
										{
											stepGetDataDevice.uid = this.data.sub.makeId ();
										}
										this.data.sub.v = stepGetDataDevice;
									}
								}
								break;
							case Account.Type.EMAIL:
								{
									// need new?
									bool needNew = true;
									{
										if (this.data.sub.v != null) {
											if (this.data.sub.v is StepGetDataEmail) {
												needNew = false;
											}
										}
									}
									// Process
									if (needNew) {
										StepGetDataEmail stepGetDataEmail = new StepGetDataEmail ();
										{
											stepGetDataEmail.uid = this.data.sub.makeId ();
										}
										this.data.sub.v = stepGetDataEmail;
									}
								}
								break;
							case Account.Type.FACEBOOK:
								{
									// need new?
									bool needNew = true;
									{
										if (this.data.sub.v != null) {
											if (this.data.sub.v is StepGetDataFacebook) {
												needNew = false;
											}
										}
									}
									// Process
									if (needNew) {
										StepGetDataFacebook stepGetDataFacebook = new StepGetDataFacebook ();
										{
											stepGetDataFacebook.uid = this.data.sub.makeId ();
										}
										this.data.sub.v = stepGetDataFacebook;
									}
								}
								break;
							default:
								Debug.LogError ("unknown type: " + account.getType () + "; " + this);
								break;
							}
						} else {
							Debug.LogError ("accountMessage null: " + this);
						}
					} else {
						Debug.LogError ("login null: " + this);
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

		private Login login = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is StepGetData) {
				StepGetData stepGetData = data as StepGetData;
				// Parent
				{
					DataUtils.addParentCallBack (stepGetData, this, ref this.login);
				}
				// Child
				{
					stepGetData.sub.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is Login) {
					dirty = true;
					return;
				}
			}
			// Child
			{
				if (data is StepGetData.Sub) {
					StepGetData.Sub sub = data as StepGetData.Sub;
					// Update
					{
						switch (sub.getType ()) {
						case Account.Type.DEVICE:
							{
								StepGetDataDevice stepGetDataDevice = sub as StepGetDataDevice;
								UpdateUtils.makeUpdate<StepGetDataDeviceUpdate, StepGetDataDevice> (stepGetDataDevice, this.transform);
							}
							break;
						case Account.Type.EMAIL:
							{
								StepGetDataEmail stepGetDataEmail = sub as StepGetDataEmail;
								UpdateUtils.makeUpdate<StepGetDataEmailUpdate, StepGetDataEmail> (stepGetDataEmail, this.transform);
							}
							break;
						case Account.Type.FACEBOOK:
							{
								StepGetDataFacebook stepGetDataFacebook = sub as StepGetDataFacebook;
								UpdateUtils.makeUpdate<StepGetDataFacebookUpdate, StepGetDataFacebook> (stepGetDataFacebook, this.transform);
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
			if (data is StepGetData) {
				StepGetData stepGetData = data as StepGetData;
				// Parent
				{
					DataUtils.removeParentCallBack (stepGetData, this, ref this.login);
				}
				// Child
				{
					stepGetData.sub.allRemoveCallBack (this);
				}
				this.setDataNull (stepGetData);
				return;
			}
			// Parent
			{
				if (data is Login) {
					return;
				}
			}
			// Child
			{
				if (data is StepGetData.Sub) {
					StepGetData.Sub sub = data as StepGetData.Sub;
					// Update
					{
						switch (sub.getType ()) {
						case Account.Type.DEVICE:
							{
								StepGetDataDevice stepGetDataDevice = sub as StepGetDataDevice;
								stepGetDataDevice.removeCallBackAndDestroy (typeof(StepGetDataDeviceUpdate));
							}
							break;
						case Account.Type.EMAIL:
							{
								StepGetDataEmail stepGetDataEmail = sub as StepGetDataEmail;
								stepGetDataEmail.removeCallBackAndDestroy (typeof(StepGetDataEmailUpdate));
							}
							break;
						case Account.Type.FACEBOOK:
							{
								StepGetDataFacebook stepGetDataFacebook = sub as StepGetDataFacebook;
								stepGetDataFacebook.removeCallBackAndDestroy (typeof(StepGetDataFacebookUpdate));
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
			if(WrapProperty.checkError(wrapProperty)){
				return;
			}
			if (wrapProperty.p is StepGetData) {
				switch ((StepGetData.Property)wrapProperty.n) {
				case StepGetData.Property.sub:
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
			// Parent
			{
				if (wrapProperty.p is Login) {
					switch ((Login.Property)wrapProperty.n) {
					case Login.Property.state:
						break;
					case Login.Property.account:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			// Child
			{
				if (wrapProperty.p is StepGetData.Sub) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
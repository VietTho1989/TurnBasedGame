using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LoginState;

public class ClientResumeConnectServerUpdate : UpdateBehavior<Login>
{

	#region update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Login.State state = this.data.state.v;
				if (state != null) {
					switch (state.getType ()) {
					case Login.State.Type.None:
						{
							// Find profileAccount
							Account profileAccount = null;
							{
								User profileUser = Server.GetProfileUser (this.data);
								if (profileUser != null) {
									Human human = profileUser.human.v;
									if (human != null) {
										profileAccount = human.account.v;
									} else {
										Debug.LogError ("human null: " + this);
									}
								} else {
									Debug.LogError ("profileUser null: " + this);
								}
							}
							// Process
							if (profileAccount != null) {
								// Copy account
								{
									// Check needNew
									bool needNew = true;
									{
										if (this.data.account.v != null) {
											if (this.data.account.v.getType () == profileAccount.getType ()) {
												needNew = false;
											}
										}
									}
									// Process
									if (needNew) {
										Account cloneProfileAccount = (Account)DataUtils.cloneData (profileAccount);
										{
											cloneProfileAccount.uid = this.data.account.makeId ();
										}
										this.data.account.v = cloneProfileAccount;
									} else {
										DataUtils.copyData (this.data.account.v, profileAccount);
									}
								}
								// New State
								Log log = new Log ();
								{
									log.uid = this.data.state.makeId ();
								}
								this.data.state.v = log;
							} else {
								Debug.LogError ("profileAccount null: " + this);
							}
						}
						break;
					case Login.State.Type.Log:
						break;
					default:
						Debug.LogError ("unknown type: " + state.getType () + "; " + this);
						break;
					}
				} else {
					Debug.LogError ("state null: " + this);
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

	public override void onAddCallBack<T> (T data)
	{
		if (data is Login) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is Login) {
			Login login = data as Login;
			// Child
			{

			}
			this.setDataNull (login);
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is Login) {
			switch ((Login.Property)wrapProperty.n) {
			case Login.Property.state:
				dirty = true;
				break;
			case Login.Property.account:
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
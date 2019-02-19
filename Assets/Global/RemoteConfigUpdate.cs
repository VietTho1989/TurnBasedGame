using UnityEngine;
using System.Collections;

public class RemoteConfigUpdate : UpdateBehavior<RemoteConfig>
{
	private static bool log = false;

	void Awake()
	{
		this.setData (RemoteConfig.get ());
	}

	public override void OnDestroy ()
	{
		base.OnDestroy ();
		this.setData (null);
	}

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				switch (this.data.state.v) {
				case RemoteConfig.State.NotLoad:
					{
						StartCoroutine (WaitToLoad ());
						StopCoroutine (LoadRemoteConfig ());
						StopCoroutine (WaitToReload ());
					}
					break;
				case RemoteConfig.State.Load:
					{
						StopCoroutine (WaitToLoad ());
						StopCoroutine (LoadRemoteConfig ());
						StopCoroutine (WaitToReload ());
						this.data.state.v = RemoteConfig.State.Loading;
						StartCoroutine (LoadRemoteConfig ());
					}
					break;
				case RemoteConfig.State.Loading:
					{
						StopCoroutine (WaitToLoad ());
						StopCoroutine (WaitToReload ());
					}
					break;
				case RemoteConfig.State.Finish:
					{
						StopCoroutine (WaitToLoad ());
						StopCoroutine (LoadRemoteConfig ());
						StartCoroutine (WaitToReload ());
					}
					break;
				default:
					if (log)
						Debug.LogError ("unknown remoteConfig state: " + this.data.state.v + "; " + this);
					break;
				}
			} else {
				if (log)
					Debug.LogError ("remoteConfig null: " + this);
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return false;
	}

	#region wait to Load

	bool first = true;

	/**
	 * Wait to load remote config
	 * */
	IEnumerator WaitToLoad()
	{
		if (first) {
			first = false;
		} else {
			yield return new WaitForSeconds (60);
		}
		this.data.state.v = RemoteConfig.State.Load;
	}

	#endregion

	IEnumerator LoadRemoteConfig()
	{
		string url = "http://mdcgate.com/config/get_friend_locator_config.php?";
#pragma warning disable CS0618 // Type or member is obsolete
        WWW www = new WWW(url);
#pragma warning restore CS0618 // Type or member is obsolete
        yield return www;
		string strRemoteConfig = www.text;
		if (log)
			Debug.LogError ("remoteConfig: " + strRemoteConfig + "; " + this);
		// Parse
		{
			// TODO Can hoan thien
		}
		this.data.state.v = RemoteConfig.State.Finish;
	}

	IEnumerator WaitToReload()
	{
		yield return new WaitForSeconds (60 * 60);
		this.data.state.v = RemoteConfig.State.Load;
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is RemoteConfig) {
			dirty = true;
			return;
		}
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is RemoteConfig) {
			RemoteConfig removeConfig = data as RemoteConfig;
			// set data null
			this.setDataNull (removeConfig);
			return;
		}
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, System.Collections.Generic.List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is RemoteConfig) {
			switch ((RemoteConfig.Property)wrapProperty.n) {
			case RemoteConfig.Property.state:
				dirty = true;
				break;
			case RemoteConfig.Property.time:
				break;
			case RemoteConfig.Property.serverAddress:
				break;
			case RemoteConfig.Property.serverPort:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
	}

	#endregion
}


using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class HaveDatabaseServerUI : UIBehavior<HaveDatabaseServerUI.UIData>
{

	#region UIData

	public class UIData : SqliteServerUI.UIData.Sub
	{

		#region Sub

		public abstract class Sub : Data
		{

			public enum Type
			{
				None,
				Load,
				Update,
				Fail
			}

			public abstract Type getType();

			public abstract bool processEvent(Event e);

		}

		public VP<Sub> sub;

		#endregion

		#region Constructor

		public enum Property
		{
			sub
		}

		public UIData() : base()
		{
			this.sub = new VP<Sub>(this, (byte)Property.sub, new HaveDatabaseServerNoneUI.UIData());
		}

		#endregion

		public override Type getType ()
		{
			return Type.HaveDatabase;
		}

		public override bool processEvent (Event e)
		{
			bool isProcess = false;
			{
				// sub
				if (!isProcess) {
					Sub sub = this.sub.v;
					if (sub != null) {
						isProcess = sub.processEvent (e);
					} else {
						Debug.LogError ("sub null: " + this);
					}
				}
			}
			return isProcess;
		}

	}

    #endregion

    #region Refresh

    public GameObject portContainer;
	public InputField edtPort;

    public GameObject maxClientUserCountContainer;
    public InputField edtMaxClientUserCount;

    private bool firstInit = false;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
                // firstInit
                if (firstInit)
                {
                    firstInit = false;
                    if (edtMaxClientUserCount != null)
                    {
                        Server.Type serverType = Server.Type.Offline;
                        {
                            SqliteServerUI.UIData sqliteServerUIData = this.data.findDataInParent<SqliteServerUI.UIData>();
                            if (sqliteServerUIData != null)
                            {
                                serverType = sqliteServerUIData.serverType;
                            }
                            else
                            {
                                Debug.LogError("sqliteServerUIData null: " + this);
                            }
                        }
                        switch (serverType)
                        {
                            case Server.Type.Server:
                                edtMaxClientUserCount.text = "" + LLAPITransport.DefaultServerMaxConnections;
                                break;
                            case Server.Type.Client:
                            case Server.Type.Host:
                            case Server.Type.Offline:
                                edtMaxClientUserCount.text = "" + LLAPITransport.DefaultMaxConnections;
                                break;
                            default:
                                Debug.LogError("unknown serverType: " + serverType);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("edtMaxClientUserCount null");
                    }
                }
                // port
                if (edtPort != null && portContainer!=null) {
					// get serverType
					Server.Type serverType = Server.Type.Offline;
					{
						SqliteServerUI.UIData sqliteServerUIData = this.data.findDataInParent<SqliteServerUI.UIData> ();
						if (sqliteServerUIData != null) {
							serverType = sqliteServerUIData.serverType;
						} else {
							Debug.LogError ("sqliteServerUIData null: " + this);
						}
					}
					// set
					switch (serverType) {
					case Server.Type.Host:
						{
							// setActive
							{
								switch (this.data.sub.v.getType ()) {
								case UIData.Sub.Type.None:
									portContainer.SetActive (true);
									break;
								case UIData.Sub.Type.Load:
								case UIData.Sub.Type.Fail:
								case UIData.Sub.Type.Update:
									portContainer.SetActive (false);
									break;
								default:
									Debug.LogError ("unknown type: " + this.data.sub.v.getType ());
									break;
								}
							}
							// enable
							{
								if (this.data.sub.v.getType () == UIData.Sub.Type.None) {
									edtPort.enabled = true;
								} else {
									edtPort.enabled = false;
								}
							}
						}
						break;
					case Server.Type.Offline:
					case Server.Type.Server:
					case Server.Type.Client:
						{
						    portContainer.SetActive (false);
						}
						break;
					default:
						Debug.LogError ("unknown server type: " + serverType + "; " + this);
						break;
					}
				} else {
					Debug.LogError ("edtPort null: " + this);
				}
                // maxClientUserCount
                if (edtMaxClientUserCount != null && maxClientUserCountContainer != null)
                {
                    // get serverType
                    Server.Type serverType = Server.Type.Offline;
                    {
                        SqliteServerUI.UIData sqliteServerUIData = this.data.findDataInParent<SqliteServerUI.UIData>();
                        if (sqliteServerUIData != null)
                        {
                            serverType = sqliteServerUIData.serverType;
                        }
                        else
                        {
                            Debug.LogError("sqliteServerUIData null: " + this);
                        }
                    }
                    // set
                    switch (serverType)
                    {
                        case Server.Type.Server:
                        case Server.Type.Host:
                            {
                                // setActive
                                {
                                    switch (this.data.sub.v.getType())
                                    {
                                        case UIData.Sub.Type.None:
                                            maxClientUserCountContainer.SetActive(true);
                                            break;
                                        case UIData.Sub.Type.Load:
                                        case UIData.Sub.Type.Fail:
                                        case UIData.Sub.Type.Update:
                                            maxClientUserCountContainer.SetActive(false);
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + this.data.sub.v.getType());
                                            break;
                                    }
                                }
                                // enable
                                {
                                    if (this.data.sub.v.getType() == UIData.Sub.Type.None)
                                    {
                                        edtMaxClientUserCount.enabled = true;
                                    }
                                    else
                                    {
                                        edtMaxClientUserCount.enabled = false;
                                    }
                                }
                            }
                            break;
                        case Server.Type.Offline:
                        case Server.Type.Client:
                            {
                                maxClientUserCountContainer.SetActive(false);
                            }
                            break;
                        default:
                            Debug.LogError("unknown server type: " + serverType + "; " + this);
                            break;
                    }
                }
                else
                {
                    Debug.LogError("edtMaxClientUserCount null: " + this);
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

	public HaveDatabaseServerNoneUI nonePrefab;
	public HaveDatabaseServerLoadUI loadPrefab;
	public HaveDatabaseServerUpdateUI updatePrefab;
	public HaveDatabaseServerFailUI failPrefab;
	public Transform subContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.sub.allAddCallBack (this);
			}
            firstInit = true;
			dirty = true;
			return;
		}
		// Child
		if (data is UIData.Sub) {
			UIData.Sub sub = data as UIData.Sub;
			// UI
			{
				switch (sub.getType ()) {
				case UIData.Sub.Type.None:
					{
						HaveDatabaseServerNoneUI.UIData noneUIData = sub as HaveDatabaseServerNoneUI.UIData;
						UIUtils.Instantiate (noneUIData, nonePrefab, subContainer);
					}
					break;
				case UIData.Sub.Type.Load:
					{
						HaveDatabaseServerLoadUI.UIData loadUIData = sub as HaveDatabaseServerLoadUI.UIData;
						UIUtils.Instantiate (loadUIData, loadPrefab, subContainer);
					}
					break;
				case UIData.Sub.Type.Update:
					{
						HaveDatabaseServerUpdateUI.UIData updateUIData = sub as HaveDatabaseServerUpdateUI.UIData;
						UIUtils.Instantiate (updateUIData, updatePrefab, subContainer);
					}
					break;
				case UIData.Sub.Type.Fail:
					{
						HaveDatabaseServerFailUI.UIData failUIData = sub as HaveDatabaseServerFailUI.UIData;
						UIUtils.Instantiate (failUIData, failPrefab, subContainer);
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
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.sub.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		if (data is UIData.Sub) {
			UIData.Sub sub = data as UIData.Sub;
			// UI
			{
				switch (sub.getType ()) {
				case UIData.Sub.Type.None:
					{
						HaveDatabaseServerNoneUI.UIData noneUIData = sub as HaveDatabaseServerNoneUI.UIData;
						noneUIData.removeCallBackAndDestroy (typeof(HaveDatabaseServerNoneUI));
					}
					break;
				case UIData.Sub.Type.Load:
					{
						HaveDatabaseServerLoadUI.UIData loadUIData = sub as HaveDatabaseServerLoadUI.UIData;
						loadUIData.removeCallBackAndDestroy (typeof(HaveDatabaseServerLoadUI));
					}
					break;
				case UIData.Sub.Type.Update:
					{
						HaveDatabaseServerUpdateUI.UIData updateUIData = sub as HaveDatabaseServerUpdateUI.UIData;
						updateUIData.removeCallBackAndDestroy (typeof(HaveDatabaseServerUpdateUI));
					}
					break;
				case UIData.Sub.Type.Fail:
					{
						HaveDatabaseServerFailUI.UIData failUIData = sub as HaveDatabaseServerFailUI.UIData;
						failUIData.removeCallBackAndDestroy (typeof(HaveDatabaseServerFailUI));
					}
					break;
				default:
					Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
					break;
				}
			}
			return;
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
			case UIData.Property.sub:
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
		// Child
		if (wrapProperty.p is UIData.Sub) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}
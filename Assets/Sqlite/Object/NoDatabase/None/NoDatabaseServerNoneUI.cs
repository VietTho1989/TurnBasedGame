using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class NoDatabaseServerNoneUI : UIBehavior<NoDatabaseServerNoneUI.UIData>
{

	#region UIData

	public class UIData : NoDatabaseServerUI.UIData.Sub
	{

		#region Constructor

		public enum Property
		{

		}

		public UIData() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.None;
		}

		public override bool processEvent (Event e)
		{
			bool isProcess = false;
			{

			}
			return isProcess;
		}

	}

	#endregion

	#region Refresh

	#region txt

	public Text tvStart;
	public static readonly TxtLanguage txtStart = new TxtLanguage();

	public Text tvPlaceHolder;
	public static readonly TxtLanguage txtPlaceHolder = new TxtLanguage();

	static NoDatabaseServerNoneUI()
	{
		txtStart.add (Language.Type.vi, "Bắt Đầu");
		txtPlaceHolder.add (Language.Type.vi, "Điền số cổng...");
	}

    #endregion

    public GameObject portContainer;
	public InputField edtPort;

    public GameObject maxClientUserCountContainer;
    public InputField edtMaxClientUserCount;

    private bool firstInit = true;

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
                // edtPort, edtMaxClientUserCount
                {
					if (portContainer != null) {
						bool show = false;
						{
							SqliteServerUI.UIData sqliteServerUIData = this.data.findDataInParent<SqliteServerUI.UIData> ();
							if (sqliteServerUIData != null) {
								if (sqliteServerUIData.serverType == Server.Type.Host) {
									show = true;
								}
							} else {
								Debug.LogError ("sqliteServerUIData null: " + this);
							}
						}
						portContainer.SetActive (show);
					} else {
						Debug.LogError ("portContainer null: " + this);
					}
                    if (maxClientUserCountContainer != null)
                    {
                        bool show = false;
                        {
                            SqliteServerUI.UIData sqliteServerUIData = this.data.findDataInParent<SqliteServerUI.UIData>();
                            if (sqliteServerUIData != null)
                            {
                                if (sqliteServerUIData.serverType == Server.Type.Host || sqliteServerUIData.serverType == Server.Type.Server)
                                {
                                    show = true;
                                }
                            }
                            else
                            {
                                Debug.LogError("sqliteServerUIData null: " + this);
                            }
                        }
                        maxClientUserCountContainer.SetActive(show);
                    }
                    else
                    {
                        Debug.LogError("maxClientUserCountContainer null: " + this);
                    }
                }
				// txt
				{
					if (tvStart != null) {
						tvStart.text = txtStart.get ("Start");
					} else {
						Debug.LogError ("tvStart null: " + this);
					}
					if (tvPlaceHolder != null) {
						tvPlaceHolder.text = txtPlaceHolder.get ("Enter port...");
					} else {
						Debug.LogError ("tvPlaceHolder null: " + this);
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

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			// Setting
			{
				Setting.get ().addCallBack (this);
			}
            firstInit = true;
			dirty = true;
			return;
		}
		// Setting
		if (data is Setting) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get ().removeCallBack (this);
			// Child
			{

			}
			this.setDataNull (uiData);
			return;
		}
		// Setting
		if (data is Setting) {
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
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnStart()
	{
		if (this.data != null) {
			NoDatabaseServerUI.UIData noDatabaseServerUIData = this.data.findDataInParent<NoDatabaseServerUI.UIData> ();
			if (noDatabaseServerUIData != null) {
				NoDatabaseServerPlayUI.UIData playUIData = new NoDatabaseServerPlayUI.UIData ();
				{
					playUIData.uid = noDatabaseServerUIData.sub.makeId ();
					// serverManager
					{
						ServerManager.UIData severManagerUIData = new ServerManager.UIData ();
						{
							Server server = new Server ();
							{
								// serverType
								Server.Type serverType = Server.Type.Offline;
								{
									SqliteServerUI.UIData sqliteServerUIData = this.data.findDataInParent<SqliteServerUI.UIData> ();
									if (sqliteServerUIData != null) {
										serverType = sqliteServerUIData.serverType;
									} else {
										Debug.LogError ("sqliteServerUIData null: " + this);
									}
								}
								// port
								int port = 7777;
								{
									if (edtPort != null) {
										string strPort = edtPort.text;
										if (int.TryParse (strPort, out port)) {

										} else {
											Debug.LogError ("strPort error: " + strPort);
										}
									} else {
										Debug.LogError ("edtPort null: " + this);
									}
								}
								// init
								server.init(serverType, port);
                                // maxClientUserCount
                                {
                                    int maxClientUserCount = LLAPITransport.DefaultMaxConnections;
                                    {
                                        if (edtMaxClientUserCount != null)
                                        {
                                            string strMaxClientUserCount = edtMaxClientUserCount.text;
                                            if (int.TryParse(strMaxClientUserCount, out maxClientUserCount))
                                            {

                                            }
                                            else
                                            {
                                                Debug.LogError("strPort error: " + strMaxClientUserCount);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("edtMaxClientUserCount null: " + this);
                                        }
                                    }
                                    server.maxClientUserCount = maxClientUserCount;
                                }
                            }
							severManagerUIData.server.v = new ReferenceData<Server> (server);
						}
						playUIData.serverManager.v = severManagerUIData;
					}
				}
				noDatabaseServerUIData.sub.v = playUIData;
			} else {
				Debug.LogError ("noDatabaseServerUIData null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}
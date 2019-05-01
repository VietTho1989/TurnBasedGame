using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DiscoveredServerUI : UIBehavior<DiscoveredServer>
{

    #region Refresh

    private static readonly TxtLanguage txtSameVersion = new TxtLanguage("Same version");
    private static readonly TxtLanguage txtDifferentVersion = new TxtLanguage("Different version");
    private static readonly TxtLanguage txtIpAddress = new TxtLanguage("Ip address");
    private static readonly TxtLanguage txtPlayers = new TxtLanguage("Players");

    static DiscoveredServerUI()
    {
        txtSameVersion.add(Language.Type.vi, "Cùng Phiên Bản");
        txtDifferentVersion.add(Language.Type.vi, "Khác Phiên Bản");
        txtIpAddress.add(Language.Type.vi, "Địa chỉ IP");
        txtPlayers.add(Language.Type.vi, "Người Chơi");
    }

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // tvVersion
                if (tvVersion != null)
                {
                    int version = this.data.version.v;
                    if (Global.VersionCode == version)
                    {
                        tvVersion.text = txtSameVersion.get() + ": " + version;
                    }
                    else
                    {
                        tvVersion.text = txtDifferentVersion.get() + ": " + version;
                    }
                }
                else
                {
                    Debug.LogError("tvVersion null: " + this);
                }
                // tvIp
                if (tvIp != null)
                {
                    tvIp.text = txtIpAddress.get() + ": " + this.data.ipAddress.v;
                }
                else
                {
                    Debug.LogError("tvIp null: " + this);
                }
                // tvPlayers
                if (tvPlayers != null)
                {
                    tvPlayers.text = txtPlayers.get() + ": " + this.data.player.v;
                }
                else
                {
                    Debug.LogError("tvPlayers  null");
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public Text tvVersion;
    public Text tvIp;
    public Text tvPlayers;

    public override void onAddCallBack<T>(T data)
    {
        if (data is DiscoveredServer)
        {
            // Setting
            {
                Setting.get().addCallBack(this);
            }
            dirty = true;
            return;
        }
        // Setting
        if (data is Setting)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is DiscoveredServer)
        {
            DiscoveredServer discoveredServer = data as DiscoveredServer;
            // Setting
            {
                Setting.get().removeCallBack(this);
            }
            // Child
            {

            }
            this.setDataNull(discoveredServer);
            return;
        }
        // Child
        if (data is Setting)
        {
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is DiscoveredServer)
        {
            switch ((DiscoveredServer.Property)wrapProperty.n)
            {
                case DiscoveredServer.Property.ipAddress:
                    dirty = true;
                    break;
                case DiscoveredServer.Property.timestamp:
                    break;
                case DiscoveredServer.Property.version:
                    dirty = true;
                    break;
                case DiscoveredServer.Property.player:
                    dirty = true;
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Setting
        if (wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
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
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnJoin()
    {
        if (this.data != null)
        {
            LanClientMenuUI.UIData lanClientMenu = this.data.findDataInParent<LanClientMenuUI.UIData>();
            if (lanClientMenu != null)
            {
                lanClientMenu.onClickJoin(this.data);
            }
            else
            {
                Debug.LogError("lanClientMenu null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}
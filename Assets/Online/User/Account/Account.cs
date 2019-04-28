using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public abstract class Account : Data
{

    // public const string DefaultAvatarUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQhypFirbu-jMrBQGb-lEZmFNGlV0glfDwtJWEdRF8g79lYmKUC";
    public const string DefaultAvatarUrl = "";

    #region type

    public enum Type
    {
        NONE,
        Admin,
        DEVICE,
        EMAIL,
        FACEBOOK
    }

    private static readonly Dictionary<Type, TxtLanguage> txtTypeDict = new Dictionary<Type, TxtLanguage>();

    static Account()
    {
        // txt
        {

        }
    }

    #endregion

    #region Login Account Type

    public static Type[] LoginTypes = 
    {
        Type.DEVICE,
        Type.EMAIL,
        Type.FACEBOOK
    };

    public static int getLoginTypesIndex(Type accountType)
    {
        int index = -1;
        {
            for (int i = 0; i < LoginTypes.Length; i++)
            {
                if (LoginTypes[i] == accountType)
                {
                    index = i;
                }
            }
        }
        return index;
    }

    public static Type getLoginType(int index)
    {
        if (index >= 0 && index < LoginTypes.Length)
        {
            return LoginTypes[index];
        }
        else
        {
            return Type.DEVICE;
        }
    }

    #endregion

    public abstract Type getType();

    public abstract void requestUpdate(uint userId, Account account);

    public abstract AccountMessage makeAccountMessage();

    public abstract bool isEqual(AccountMessage accountMessage);

    public abstract bool checkCorrectAccount(AccountMessage accountMessage);

    public abstract void updateAccount(AccountMessage accountMessage);

    public abstract string getName();

    public abstract string getAvatarUrl();

    public static void OnUpdateSyncAccount(WrapProperty wrapProperty, DirtyInterface dirtyInterface)
    {
        Account account = wrapProperty.p as Account;
        switch (account.getType())
        {
            case Account.Type.NONE:
                {
                    switch ((AccountNone.Property)wrapProperty.n)
                    {
                        default:
                            Debug.LogError("Don't process: " + wrapProperty);
                            break;
                    }
                }
                break;
            case Account.Type.Admin:
                {
                    switch ((AccountAdmin.Property)wrapProperty.n)
                    {
                        case AccountAdmin.Property.customName:
                            dirtyInterface.makeDirty();
                            break;
                        case AccountAdmin.Property.avatarUrl:
                            dirtyInterface.makeDirty();
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty);
                            break;
                    }
                }
                break;
            case Account.Type.DEVICE:
                {
                    switch ((AccountDevice.Property)wrapProperty.n)
                    {
                        case AccountDevice.Property.imei:
                            dirtyInterface.makeDirty();
                            break;
                        case AccountDevice.Property.deviceName:
                            dirtyInterface.makeDirty();
                            break;
                        case AccountDevice.Property.customName:
                            dirtyInterface.makeDirty();
                            break;
                        case AccountDevice.Property.avatarUrl:
                            dirtyInterface.makeDirty();
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty);
                            break;
                    }
                }
                break;
            case Account.Type.EMAIL:
                {
                    switch ((AccountEmail.Property)wrapProperty.n)
                    {
                        case AccountEmail.Property.email:
                            dirtyInterface.makeDirty();
                            break;
                        case AccountEmail.Property.password:
                            break;
                        case AccountEmail.Property.customName:
                            dirtyInterface.makeDirty();
                            break;
                        case AccountEmail.Property.avatarUrl:
                            dirtyInterface.makeDirty();
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty);
                            break;
                    }
                }
                break;
            case Account.Type.FACEBOOK:
                {
                    switch ((AccountFacebook.Property)wrapProperty.n)
                    {
                        case AccountFacebook.Property.userId:
                            dirtyInterface.makeDirty();
                            break;
                        case AccountFacebook.Property.firstName:
                            dirtyInterface.makeDirty();
                            break;
                        case AccountFacebook.Property.lastName:
                            dirtyInterface.makeDirty();
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty);
                            break;
                    }
                }
                break;
            default:
                Debug.LogError("unknown type: " + account.getType());
                break;
        }
    }

    public static uint[] getIdentites()
    {
        // find
        uint[] ids;
        {
            NetworkIdentity[] networkIdentites = GameObject.FindObjectsOfType<NetworkIdentity>();
            ids = new uint[networkIdentites.Length];
            for (int i = 0; i < networkIdentites.Length; i++)
            {
                NetworkIdentity networkIdentity = networkIdentites[i];
                ids[i] = networkIdentity.netId.Value;
            }
        }
        // return
        return ids;
    }

    public bool isCanChange(uint userId)
    {
        Human human = this.findDataInParent<Human>();
        if (human != null)
        {
            if (human.playerId.v == userId)
            {
                return true;
            }
            else
            {
                Debug.LogError("not correct humanId");
                return false;
            }
        }
        else
        {
            Debug.LogError("human null: " + this);
            // login
            return true;
        }
    }

    public bool isCanChangeEmail(uint userId)
    {
        Human human = this.findDataInParent<Human>();
        if (human != null)
        {
            return false;
        }
        else
        {
            Debug.LogError("human null: " + this);
            // login
            return true;
        }
    }

    public bool isCanChangePassword(uint userId)
    {
        Human human = this.findDataInParent<Human>();
        if (human != null)
        {
            return false;
        }
        else
        {
            Debug.LogError("human null: " + this);
            // login
            return true;
        }
    }

    public uint getRequestAccountUserId()
    {
        Server server = this.findDataInParent<Server>();
        if (server != null)
        {
            return server.profileId.v;
        }
        else
        {
            // Debug.LogError ("server null: " + this);
            Human human = this.findDataInParent<Human>();
            if (human != null)
            {
                return human.playerId.v;
            }
            else
            {
                Debug.LogError("human null: " + this);
                return 0;
            }
        }
    }

}
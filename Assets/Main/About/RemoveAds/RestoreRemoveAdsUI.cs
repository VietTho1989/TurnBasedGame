using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using Ads;

public class RestoreRemoveAdsUI : MonoBehaviour
{

    public void OnPurchaseComplete(Product item)
    {
        Debug.LogError("OnPurchaseComplete: " + item.definition.id);
        if (item.definition.id == "1")
        {
            Debug.LogError("remove ads");
            Global.get().removeAds.v = true;
            AdsManager.get().removeAds();
        }
    }

    public void OnPurchaseFailed(Product item, PurchaseFailureReason r)
    {
        Debug.LogError("OnPurchaseFailed: " + item + ", " + r);
        Toast.showMessage("Remove ads fail");
    }

}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using Ads;

public class RestoreRemoveAdsUI : MonoBehaviour, IStoreListener
{

    public const string ProductRemoveAds = "removeAds";

    /*void Start()
    {
        StandardPurchasingModule module = StandardPurchasingModule.Instance();
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);
        builder.AddProduct("1", ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder);
    }*/

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.LogError("OnInitialized: " + controller + "; " + extensions);
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.LogError("OnInitializeFailed: " + error);
    }

    public void OnPurchaseComplete(Product item)
    {
        Debug.LogError("OnPurchaseComplete: " + item.definition.id);
        if (item.definition.id == ProductRemoveAds)
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

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        if (e.purchasedProduct.definition.id == ProductRemoveAds)
        {
            Debug.LogError("remove ads");
            Global.get().removeAds.v = true;
            AdsManager.get().removeAds();
        }
        return PurchaseProcessingResult.Complete;
    }

}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using Ads;

public class RestoreRemoveAdsUI : MonoBehaviour, IStoreListener
{

    public const string ProductRemoveAds = "full_remove_ads";

    /*void Awake()
    {
        Debug.LogError("RestoreRemoveAdsUI: Awake");
        StandardPurchasingModule module = StandardPurchasingModule.Instance();
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);
        builder.AddProduct(ProductRemoveAds, ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder);
    }*/

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.LogError("OnInitialized: " + controller + "; " + extensions);
        foreach (var item in controller.products.all)
        {
            if (item.availableToPurchase)
            {
                Debug.Log(string.Join(" - ",
                    new[]
                    {
                    item.metadata.localizedTitle,
                    item.metadata.localizedDescription,
                    item.metadata.isoCurrencyCode,
                    item.metadata.localizedPrice.ToString(),
                    item.metadata.localizedPriceString,
                    item.transactionID,
                    item.receipt
                    }));

                // Set all these products to be visible in the user's App Store according to Apple's Promotional IAP feature
                // https://developer.apple.com/library/content/documentation/NetworkingInternet/Conceptual/StoreKitGuide/PromotingIn-AppPurchases/PromotingIn-AppPurchases.html
                // m_AppleExtensions.SetStorePromotionVisibility(item, AppleStorePromotionVisibility.Show);

                // this is the usage of SubscriptionManager class
                if (item.receipt != null)
                {
                    if (item.definition.type == ProductType.Subscription)
                    {
                        string intro_json = "";
                        SubscriptionManager p = new SubscriptionManager(item, intro_json);
                        SubscriptionInfo info = p.getSubscriptionInfo();
                        Debug.Log("product id is: " + info.getProductId());
                        Debug.Log("purchase date is: " + info.getPurchaseDate());
                        Debug.Log("subscription next billing date is: " + info.getExpireDate());
                        Debug.Log("is subscribed? " + info.isSubscribed().ToString());
                        Debug.Log("is expired? " + info.isExpired().ToString());
                        Debug.Log("is cancelled? " + info.isCancelled());
                        Debug.Log("product is in free trial peroid? " + info.isFreeTrial());
                        Debug.Log("product is auto renewing? " + info.isAutoRenewing());
                        Debug.Log("subscription remaining valid time until next billing date is: " + info.getRemainingTime());
                        Debug.Log("is this product in introductory price period? " + info.isIntroductoryPricePeriod());
                        Debug.Log("the product introductory localized price is: " + info.getIntroductoryPrice());
                        Debug.Log("the product introductory price period is: " + info.getIntroductoryPricePeriod());
                        Debug.Log("the number of product introductory price period cycles is: " + info.getIntroductoryPricePeriodCycles());
                        if (info.isSubscribed() == Result.True)
                        {
                            Debug.LogError("subScribed true");
                            Global.get().removeAds.v = true;
                        }
                        else
                        {
                            Debug.LogError("subScribed not true");
                        }
                    }
                    else
                    {
                        Debug.Log("the product is not a subscription product");
                    }
                }
                else
                {
                    Debug.Log("the product should have a valid receipt");
                }
            }
        }
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
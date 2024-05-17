using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedADS : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
   // [SerializeField] Button _showAdButton;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    string _adUnitId = null; // This will remain null for unsupported platforms

    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        // Disable the button until the ad is ready to show:
       // _showAdButton.interactable = false;
    }

    // Call this public method when you want to get an ad ready to show.
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
  
        Advertisement.Load(_adUnitId, this);
    }
    public void ShowAd()
    {
        // Disable the button:
        //   _showAdButton.interactable = false;
        // Then show the ad:
        Advertisement.Show(_adUnitId, this);
     
        LoadAd();
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    /*  public void OnUnityAdsAdLoaded(string adUnitId)
      {
          Debug.Log("Ad Loaded: " + adUnitId);

          if (adUnitId.Equals(_adUnitId))
          {
              // Configure the button to call the ShowAd() method when clicked:
             // _showAdButton.onClick.AddListener(ShowAd);
              // Enable the button for users to click:
            //  _showAdButton.interactable = true;
          }
      }*/

    // Implement a method to execute when the user clicks the button:


    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
     
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
 
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        GameManager.Instance.tWICEthescORE();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
      
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId == _adUnitId&&showCompletionState.Equals(UnityAdsCompletionState.COMPLETED))
        {
            Debug.Log("ADS Fully Watched");
         //   GameManager.Instance.tWICEthescORE();
        }
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("ADS loaded");
    }
}

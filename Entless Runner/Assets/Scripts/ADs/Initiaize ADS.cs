using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class InitiaizeADS : MonoBehaviour,IUnityAdsInitializationListener
{
    [SerializeField] private string androidgameId;
    [SerializeField] private string iosId;
    [SerializeField] private bool isTesting;

    private string gameid;
    void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
#if UNITY_IOS
            gameid = iosId;
#elif UNITY_ANDROID
        gameid = androidgameId;
#elif UNITY_EDITOR
            gameid = androidgameId; //Only for testing the functionality in the Editor
#endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameid, isTesting, this);
        }
    }

    public void OnInitializationComplete()
    {
        Debug.Log("ADS Initilizing complited");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("ADS Initilizing failed");
    }
}

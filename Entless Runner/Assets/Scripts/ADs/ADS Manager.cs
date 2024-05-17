using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ADSManager : MonoBehaviour
{
    public InitiaizeADS initializeADS; // Ensure this is spelled correctly
    public InterstitialADS interstitialADS;
    public BannerADS bannerADS;
    public RewardedADS rewardedADS;

    public static ADSManager instance;

    private void Awake()
    {
        if (instance != null && instance != this) // Corrected the singleton pattern check
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Uncommented to persist the object across scenes
    }

    private void Start() // Loading ads in Start to ensure all objects are initialized
    {
        bannerADS.LoadBanner();
        interstitialADS.LoadAd();
        rewardedADS.LoadAd();
        StartCoroutine(DisplayBannerAds());
    }

    IEnumerator DisplayBannerAds()
    {
        yield return new WaitForSeconds(1);
        instance.bannerADS.ShowBannerAd(); // 'instance' already refers to this class
    }
}
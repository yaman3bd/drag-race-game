using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;
public enum AdType
{
    None,
    INTERSTITIAL,
    REWARDED,
}
public class AdsManager : MonoBehaviour, IUnityAdsListener, IUnityAdsInitializationListener
{
    public static AdsManager Instance;
    public delegate void UnityAdsAdLoaded(AdType adType);
    public event UnityAdsAdLoaded OnAdLoaded;

    public delegate void UnityAdsShowComplete(AdType adType);
    public event UnityAdsShowComplete OnAdShowComplete;
    public Action OnAdsInitializationComplete;
    private const string ANDROID_GAME_ID = "4324611";
    private const string IOS_GAME_ID = "4324610";
    [SerializeField] bool _enablePerPlacementMode = true;

    private const string INTERSTITIAL_ANDROID_UNIT_ID = "Interstitial_Android";
    private const string REWARDED_ANDROID_UNIT_ID = "Rewarded_Android";


    private void Awake()
    {
        Instance = this;
        InitializeAds();
    }
    public void InitializeAds()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(ANDROID_GAME_ID, true, _enablePerPlacementMode, this);
    }

    public void LoadAd(AdType adType)
    {
        switch (adType)
        {
            case AdType.None:
                break;
            case AdType.INTERSTITIAL:
                Advertisement.Load(INTERSTITIAL_ANDROID_UNIT_ID);
                break;
            case AdType.REWARDED:
                Advertisement.Load(REWARDED_ANDROID_UNIT_ID);
                break;
            default:
                break;
        }
    }
    public void ShowAd(AdType adType)
    {
        switch (adType)
        {
            case AdType.None:
                break;
            case AdType.INTERSTITIAL:
                Advertisement.Show(INTERSTITIAL_ANDROID_UNIT_ID);
                break;
            case AdType.REWARDED:
                Advertisement.Show(REWARDED_ANDROID_UNIT_ID);
                break;
            default:
                break;
        }
    }

    public bool IsAdReay(AdType adType)
    {
        switch (adType)
        {
            case AdType.None:
                break;
            case AdType.INTERSTITIAL:
                return Advertisement.IsReady(INTERSTITIAL_ANDROID_UNIT_ID);

            case AdType.REWARDED:
                return Advertisement.IsReady(REWARDED_ANDROID_UNIT_ID);

        }
        return false;

    }


    public void OnUnityAdsReady(string placementId)
    {

        if (OnAdLoaded != null)
        {
            if (INTERSTITIAL_ANDROID_UNIT_ID.Equals(placementId))
            {
                OnAdLoaded(AdType.INTERSTITIAL);
            }
            else if (REWARDED_ANDROID_UNIT_ID.Equals(placementId))
            {
                OnAdLoaded(AdType.REWARDED);

            }
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("OnUnityAdsDidError");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("OnUnityAdsDidStart");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (OnAdShowComplete != null)
        {
            if (INTERSTITIAL_ANDROID_UNIT_ID.Equals(placementId))
            {
                OnAdShowComplete(AdType.INTERSTITIAL);
            }
            else if (REWARDED_ANDROID_UNIT_ID.Equals(placementId) && showResult.Equals(ShowResult.Finished))
            {
                OnAdShowComplete(AdType.REWARDED);
            }
        }
    }

    public void OnInitializationComplete()
    {
        if (OnAdsInitializationComplete != null)
        {
            OnAdsInitializationComplete();
        }
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
    }
}

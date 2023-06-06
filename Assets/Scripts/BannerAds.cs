﻿using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class BannerAds : MonoBehaviour
{
    private BannerView banner;

    public void Start()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-7490973564927547~8346204820";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-7490973564927547~8346204820";
#else
            string appId = "unexpected_platform";
#endif
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        this.RequestBanner();
        
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
        string AdUnitID = "ca-app-pub-7490973564927547/3681143450"; //테스트 아이디
#else
        string AdUnitID = "unDefind";
#endif

        banner = new BannerView(AdUnitID, AdSize.SmartBanner, AdPosition.Bottom);

        // Called when an ad request has successfully loaded.
        banner.OnAdLoaded += HandleOnAdLoaded_banner;
        // Called when an ad request failed to load.
        banner.OnAdFailedToLoad += HandleOnAdFailedToLoad_banner;
        // Called when an ad is clicked.
        banner.OnAdOpening += HandleOnAdOpened_banner;
        // Called when the user returned from the app after an ad click.
        banner.OnAdClosed += HandleOnAdClosed_banner;
        // Called when the ad click caused the user to leave the application.
        banner.OnAdLeavingApplication += HandleOnAdLeavingApplication_banner;

        AdRequest request = new AdRequest.Builder().Build();

        banner.LoadAd(request);

       
    }

    public void ShowBanner()
    {
        banner.Show();
    }

    public void HideBanner()
    {
        banner.Hide();
    }

    public void HandleOnAdLoaded_banner(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received_banner");
    }

    public void HandleOnAdFailedToLoad_banner(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd_banner event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened_banner(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received_banner");
    }

    public void HandleOnAdClosed_banner(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received_banner");
    }

    public void HandleOnAdLeavingApplication_banner(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received_banner");
    }

}

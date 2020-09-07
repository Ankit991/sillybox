using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class Ads : MonoBehaviour
{
    public static Ads instace;
    private string Store_id = "3805517";
    private string Banner_ad = "banner";
    public bool testMode = true;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instace != null)
        {
            Destroy(gameObject);
        }else
        {
            instace = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        Advertisement.Initialize(Store_id, testMode);
        StartCoroutine(ShowBannerWhenInitialized());
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }
    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(Banner_ad);
    }
    public void ShowInterstitialAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }
}

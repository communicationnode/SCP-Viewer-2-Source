using YandexMobileAds;
using YandexMobileAds.Base;
using UnityEngine;

public sealed class AdsTurnInMenu : MonoBehaviour {

    // FIELDS
    public static AdsTurnInMenu instance;
    private InterstitialAdLoader interstitialAdLoader;
    private Interstitial interstitial;
    public bool demo = true;
    public string blockID;
    [SerializeField] private GameObject loadBar;


    // UNITY FUNCTIONAL
    private void Start() {
        Debug.Log($"AFTER_SCENE_MENU_ADS = {PlayerPrefs.GetInt(PlayerPrefsKeys.AFTER_SCENE_MENU_ADS)}");
        instance = this;

        interstitialAdLoader = new InterstitialAdLoader();
        interstitialAdLoader.OnAdLoaded += (obj, args) => {
            if (interstitial != null) {
                interstitial.Destroy();
            }
            interstitial = args.Interstitial;
            interstitial.OnAdFailedToShow += (obj, evArg) => { Debug.Log($"({blockID}) Failed to load: {evArg.Message}"); loadBar.SetActive(false); };
            interstitial.Show();
            loadBar.SetActive(false);
        };

        interstitialAdLoader.OnAdFailedToLoad += (obj, evArg) => { Debug.Log($"({blockID}) Failed to shown: {evArg.Message}"); loadBar.SetActive(false); };

        if (PlayerPrefs.GetInt(PlayerPrefsKeys.AFTER_SCENE_MENU_ADS) >= 2) {
            PlayerPrefs.SetInt(PlayerPrefsKeys.AFTER_SCENE_MENU_ADS, 0);
            LoadAd();
            loadBar.SetActive(true);
        }
    }

    // FUNCTIONAL
    public void LoadAd() {
        if (InternetStatusRequestor.isConnected) {
            interstitialAdLoader.LoadAd(new AdRequestConfiguration.Builder(demo is true ? AdDemos.DEMO_INTERSTITIAL_ID : blockID).Build());
        }
        else {
            Debug.Log($"({blockID}) NET-not-connected. Ads will not show. Ads is not builded");
        }
    }
}

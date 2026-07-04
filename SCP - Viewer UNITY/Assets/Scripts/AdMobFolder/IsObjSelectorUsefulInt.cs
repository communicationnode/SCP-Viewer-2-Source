using YandexMobileAds;
using YandexMobileAds.Base;
using UnityEngine;

public sealed class IsObjSelectorUsefulInt : MonoBehaviour {

    // FIELDS
    public int countOfClicksToShowAds;
    public string blockID;
    public bool demo = true;
    public GameObject loadBar;
    private InterstitialAdLoader interstitialAdLoader;
    private Interstitial interstitial;
    [SerializeField] private int maxClickToShowVideo = 4;


    // UNITY FUNCTIONAL
    private void Start() {
        InitializeAd();
    }


    // FUNCTIONAL
    private void InitializeAd() {
        interstitialAdLoader = new InterstitialAdLoader();
        interstitialAdLoader.OnAdLoaded += (obj, args) => {
            if (interstitial != null) {
                interstitial.Destroy();
            }
            Debug.Log($"({blockID}) NET-connected. Ads will show. Ads builded");
            interstitial = args.Interstitial;
            interstitial.OnAdFailedToShow += (obj, evArg) => {
                Debug.Log($"({blockID}) Failed to load: {evArg.Message}");
                loadBar.SetActive(false);
            };
            interstitial.Show();
            PlayerPrefs.SetInt(PlayerPrefsKeys.OBJECTS_LIST_ADS, 0);
            loadBar.SetActive(false);
        };
        interstitialAdLoader.OnAdFailedToLoad += (obj, evArg) => { Debug.Log($"({blockID}) Failed to shown: {evArg.Message}"); loadBar.SetActive(false); };
    }
    public void InterTurnAdd() {
        PlayerPrefs.SetInt(PlayerPrefsKeys.OBJECTS_LIST_ADS, PlayerPrefs.GetInt(PlayerPrefsKeys.OBJECTS_LIST_ADS) + 1);

        /*load ad after count of clicks will equal or greater then max count value*/
        if (PlayerPrefs.GetInt(PlayerPrefsKeys.OBJECTS_LIST_ADS) >= maxClickToShowVideo) {
            PlayerPrefs.SetInt(PlayerPrefsKeys.OBJECTS_LIST_ADS, 0);

            interstitialAdLoader.LoadAd(new AdRequestConfiguration.Builder(demo is true ? AdDemos.DEMO_INTERSTITIAL_ID : blockID).Build());
            loadBar.SetActive(true);
        }
    }
}

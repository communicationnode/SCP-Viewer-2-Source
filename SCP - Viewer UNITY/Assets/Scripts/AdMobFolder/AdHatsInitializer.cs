using YandexMobileAds;
using YandexMobileAds.Base;
using UnityEngine;
public sealed class AdHatsInitializer : MonoBehaviour
{
    /*
     * values
     */
    private RewardedAdLoader            rewardedAdLoader;
    private RewardedAd                  rewarded;
    public  static AdHatsInitializer    instance;
    public  bool                        demo                = true;
    public  string                      blockID;

    public  bool                        debug               = false;
    public  byte                        availableBuyTickets = 0;

    [SerializeField] private GameObject loadBar;


    /*
     * methods
     */
    private void Start()
    {
        instance = this;

        rewardedAdLoader = new RewardedAdLoader();
        rewardedAdLoader.OnAdLoaded += (obj, args) => {
            if (rewarded != null) {
                rewarded.Destroy();
            }
            rewarded = args.RewardedAd;
            rewarded.OnRewarded += (obj,rew) => { availableBuyTickets = 3; };
            rewarded.OnAdFailedToShow += (obj, args) => { Debug.Log($"({blockID}) Failed to load: {args.Message}"); loadBar.SetActive(false); };
            rewarded.Show();
            loadBar.SetActive(false);
        };
        rewardedAdLoader.OnAdFailedToLoad += (obj, args) => { Debug.Log($"({blockID}) Failed to load: {args.Message}"); loadBar.SetActive(false); };
    }

    public  void LoadAd()
    {
        if (!debug)
        {
            rewardedAdLoader.LoadAd(new AdRequestConfiguration.Builder(demo is true ? AdDemos.DEMO_REWARDED_ID : blockID).Build());
            loadBar.SetActive(true);
        }
        else
        {
            availableBuyTickets = 3;
        }
    }
}

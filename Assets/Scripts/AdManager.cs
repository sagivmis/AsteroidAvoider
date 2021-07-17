using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    #if UNITY_ANDROID
    private string gameId = "4216189";
    #elif UNITY_IOS
    private string gameId = "4216188";
    #endif
    [SerializeField] private bool testMode;
    public static AdManager Instance;
    private GameOverHandler gameOverHandler;
    public  void showAd(GameOverHandler gameOverHandler){
        this.gameOverHandler = gameOverHandler;
        Advertisement.Show("rewardedVideo");
     }
    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError($"Unity ads error: {message}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch(showResult){
            case ShowResult.Finished:
                gameOverHandler.continueGame();
                break;
            case ShowResult.Skipped:
            // ad was skipped
                break;
            case ShowResult.Failed:
            Debug.LogWarning("Ad Failed");
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad Started");
        }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Unity Ads Ready");
    }

    private void Awake() {
        if(Instance != null && Instance !=this){
            Destroy(gameObject);
        }
        else{
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId,  testMode);
        }
    }
}

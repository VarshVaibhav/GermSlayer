using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityVideoAd : MonoBehaviour, IUnityAdsListener
{
    string placement = "Rewarded_Android";

    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize("4074357", true);
    }

    public void ShowRewardedVideo()
    {
        if (Advertisement.IsReady(placement))
        {
            Advertisement.Show(placement);
        }
        else
        {
            GameManager.Instance.messageAdFailed();
        }
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {
            GameManager.Instance.RewardPanel.SetActive(true);
            GameManager.Instance.deathPanel.SetActive(false);
        }
        else if(showResult == ShowResult.Failed)
        {
            if (Application.internetReachability != NetworkReachability.NotReachable)
            {
                GameManager.Instance.messageAdFailed();
            }
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
    }
}

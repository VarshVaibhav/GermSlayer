using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour
{
    void Start()
    {
        Advertisement.Initialize("4074357", true);
    }

    public void DisplayAd()
    {
        Advertisement.Show();
    }

}

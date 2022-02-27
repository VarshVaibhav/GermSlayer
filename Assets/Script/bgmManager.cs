using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bgmManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundfOffIcon;
    private bool muted = false;

    private GameObject man;
    void Start()
    {
        man = GameObject.Find("Background Music");
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted",0);
            Load();
        }
        else
        {
            Load();
        }
        UpdatedButtonIcon();
        man.GetComponent<AudioSource>().enabled = !muted;
    }
    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            man.GetComponent<AudioSource>().enabled = false;
        }
        else
        {
            muted = false;
            man.GetComponent<AudioSource>().enabled = true;
        }
        Save();
        UpdatedButtonIcon();
    }
    private void UpdatedButtonIcon()
    {
        if(muted == false)
        {
            soundOnIcon.enabled = true;
            soundfOffIcon.enabled = false;
        }
        else
        {
            soundOnIcon.enabled = false;
            soundfOffIcon.enabled = true;
        }
    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}

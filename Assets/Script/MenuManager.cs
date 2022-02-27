using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject onButton;
    public GameObject offButton;

    public GameObject ClassicPanel;
    public GameObject ArcadePanel;
    public GameObject menuPanel;
    public GameObject settingPanel;
    public GameObject settingButtonPanel;
    public GameObject quitPanel;
    public GameObject creditPanel;
    public GameObject nameGS;

    public Animator classicAnim;
    public Animator arcadeAnim;
    public Animator openAnim;
    public Animator openSetting;
    public Animator quitAnim;

    private void Start()
    {
        onButton.SetActive(true);
        offButton.SetActive(false);

        classicAnim.enabled = false;
        arcadeAnim.enabled = false;
        ClassicPanel.SetActive(false);
        ArcadePanel.SetActive(false);
        settingPanel.SetActive(false);
        quitPanel.SetActive(false);
        menuPanel.SetActive(true);
        creditPanel.SetActive(false);
        nameGS.SetActive(true);
    }
    public void ClassicActive()
    {
        classicAnim.enabled = true;
        ClassicPanel.SetActive(true);
        menuPanel.SetActive(false);
        settingButtonPanel.SetActive(false);
    }
    public void ClassicDeactive()
    {
        openAnim.enabled = true;
        ClassicPanel.SetActive(false);
        menuPanel.SetActive(true);
        settingButtonPanel.SetActive(true);
    }
    public void ArcadeActivate()
    {
        arcadeAnim.enabled = true;
        ArcadePanel.SetActive(true);
        menuPanel.SetActive(false);
        settingButtonPanel.SetActive(false);
    }
    public void ArcadeDeactivate()
    {
        openAnim.enabled = true;
        ArcadePanel.SetActive(false);
        menuPanel.SetActive(true);
        settingButtonPanel.SetActive(true);
    }
    public void SettingActivate()
    {
        settingPanel.SetActive(true);
        onButton.SetActive(false);
        offButton.SetActive(true);
    }
    public void settingDeactivate()
    {
        settingPanel.SetActive(false);
        onButton.SetActive(true);
        offButton.SetActive(false);
    }
    public void quitActivate()
    {
        quitAnim.enabled = true;
        quitPanel.SetActive(true);
        menuPanel.SetActive(false);
        settingButtonPanel.SetActive(false);
    }
    public void quitDeactivate()
    {
        openAnim.enabled = true;
        quitPanel.SetActive(false);
        menuPanel.SetActive(true);
        settingButtonPanel.SetActive(true);
    }
    public void creditActivate()
    {
        nameGS.SetActive(false);
        creditPanel.SetActive(true);
        menuPanel.SetActive(false);
        settingButtonPanel.SetActive(false);
    }
    public void creditDeactivate()
    {
        nameGS.SetActive(true);
        creditPanel.SetActive(false);
        menuPanel.SetActive(true);
        settingButtonPanel.SetActive(true);
    }
    public void quitYes()
    {
        Application.Quit();
    }
    public void ClassicGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void ArcadeGame()
    {
        SceneManager.LoadScene("Level2");
    }
}

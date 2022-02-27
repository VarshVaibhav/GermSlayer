using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    public GameObject slash;

    void Start()
    {
        StartCoroutine("StartDelay");
    }

    IEnumerator StartDelay()
    {
        GameManager.Instance.isPaused = true;
        GameManager.Instance.pauseButton.SetActive(false);
        float pauseTime = Time.realtimeSinceStartup + 2.3f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        slash.gameObject.SetActive(false);
        GameManager.Instance.isPaused = false;
        GameManager.Instance.pauseButton.SetActive(true);
    }
}

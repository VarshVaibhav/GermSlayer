using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TrailSelection : MonoBehaviour
{
    public static TrailSelection Instance { set; get; }
    public Transform trail1;
    public Transform trail2;
    public Transform trail3;
    public Transform trail4;

    public GameObject Trail1;
    public GameObject Trail2;
    public GameObject Trail3;
    public GameObject Trail4;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Time.timeScale == 0)
            return;

        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = -1;
            trail1.position = pos;
            trail2.position = pos;
            trail3.position = pos;
            trail4.position = pos;
        }
    }
    public void Trail1AD()
    {
        Trail1.SetActive(!Trail1.activeSelf);
        Trail2.SetActive(false);
        Trail3.SetActive(false);
        Trail4.SetActive(false);
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    public void Trail2AD()
    {
        Trail2.SetActive(!Trail2.activeSelf);
        Trail1.SetActive(false);
        Trail3.SetActive(false);
        Trail4.SetActive(false);
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    public void Trail3AD()
    {
        Trail3.SetActive(!Trail3.activeSelf);
        Trail2.SetActive(false);
        Trail1.SetActive(false);
        Trail4.SetActive(false);
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    public void Trail4AD()
    {
        Trail4.SetActive(!Trail4.activeSelf);
        Trail2.SetActive(false);
        Trail3.SetActive(false);
        Trail1.SetActive(false);
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
}

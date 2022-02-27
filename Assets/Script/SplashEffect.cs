using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashEffect : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 2f);
    }
}

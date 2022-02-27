using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullEffect : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 2.1f);
    }
}

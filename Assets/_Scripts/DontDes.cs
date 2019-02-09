using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDes : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType<DontDes>().Length > 1)
        {
            Destroy(gameObject);
        }
    }
}

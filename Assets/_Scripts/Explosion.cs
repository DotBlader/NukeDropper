﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DesTroy());
    }
    public IEnumerator DesTroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
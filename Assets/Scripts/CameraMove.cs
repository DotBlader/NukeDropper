﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float posMax;
    public float posMin;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > posMin)
        {
            transform.Translate(0, -speed, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < posMax)
        {
            transform.Translate(0, speed, 0);
        }
    }
}

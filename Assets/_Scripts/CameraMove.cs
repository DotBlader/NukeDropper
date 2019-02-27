using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float posMax;
    public float posMin;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y > posMin)
        {
            transform.Translate(0, -speed, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y < posMax)
        {
            transform.Translate(0, speed, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float posMax; //max positionen för scrollandet
    public float posMin; //minimum positionen
    public float speed; //farten den scrollar med
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y > posMin) //om man klickar på knappen och positionen är rätt
        {
            transform.Translate(0, -speed, 0); //scrollar genom att flytta på sig
        }
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y < posMax)
        {
            transform.Translate(0, speed, 0);
        }
    }
}

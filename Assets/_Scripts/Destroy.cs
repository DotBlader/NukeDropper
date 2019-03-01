using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float timer; //en timer
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; //timern räknar ned
        if (timer <= 0) //om timern är mindre än eller lika med 0
        {
            Destroy(gameObject); //förstör objektet
        }
    }
}

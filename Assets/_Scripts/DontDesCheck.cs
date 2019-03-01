using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDesCheck : MonoBehaviour
{
    public GameObject musically; //music objektet
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<Musically>() != null) //om objektet finns
            return; //returna ingenting
        else //om objektet inte finns
            Instantiate(musically, transform.position, transform.rotation); //spawna in objektet
    }
}

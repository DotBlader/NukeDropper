using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDesCheck : MonoBehaviour
{
    public GameObject dontDes;
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<DontDes>() != null)
            return;
        else
            Instantiate(dontDes, transform.position, transform.rotation);
    }
}

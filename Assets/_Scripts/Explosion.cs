using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DesTroy()); //startar timern 
    }
    public IEnumerator DesTroy() //ienumerator för timer att förstöra objektet
    {
        yield return new WaitForSeconds(2); //väntar 2 sekunder
        Destroy(gameObject); //förstör objektet
    }
}

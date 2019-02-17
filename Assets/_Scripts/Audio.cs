using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public GameObject bing;
    public GameObject bing2;
    public GameObject bong;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceKleeker>().coochieKleek += Bing;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Bing()
    {
        int i = Random.Range(1, 4);
        if (i == 1)
            Instantiate(bing, transform.position, transform.rotation);
        else if (i == 2)
            Instantiate(bing2, transform.position, transform.rotation);
        else if (i == 3)
            Instantiate(bong, transform.position, transform.rotation);
    }
    
}

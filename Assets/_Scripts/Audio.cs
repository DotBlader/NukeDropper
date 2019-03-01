using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public GameObject bing; //objekt som skall spawnas
    public GameObject bing2;
    public GameObject bong;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceKleeker>().NukeDrop += Bing; //kopplar funktionen till klick eventen
    }
    public void Bing() //funktion för att spawna ljudobjekt
    {
        int i = Random.Range(1, 4); //sätter inten till en slumpnässig siffra 
        if (i == 1) //om den är 1
            Instantiate(bing, transform.position, transform.rotation); //spawnar det specifika objektet
        else if (i == 2)
            Instantiate(bing2, transform.position, transform.rotation);
        else if (i == 3)
            Instantiate(bong, transform.position, transform.rotation);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchieveScene : MonoBehaviour
{
    public Image image; //bilden i scenen
    public string namn; //namnet på playerprefs som är gjord för den achievementen
    private void Awake()
    {
        image = GetComponent<Image>(); //get:ar bild komponenten
        
    }
    // Start is called before the first frame update
    void Start()
    {
        image.color = new Color32(84, 84, 84, 228); //sätter bildens färg till grå
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt(namn) == 0) //om inten är lika med 0
        {
            image.color = new Color32(84, 84, 84, 228); //bilden är grå
        }
        else if (PlayerPrefs.GetInt(namn) == 1) //om den är 1, alltså att man har fått acheivementen
        {
            image.color = new Color32(0, 160, 255, 228); //sätter färgen till blå
        }
    }
    public void Reset() //funktion för att reset:a alla sparade data
    {
        PlayerPrefs.SetInt("Score", 0); //score blir 0

        PlayerPrefs.SetInt("million", 0); //alla achievements reset:ar
        PlayerPrefs.SetInt("billion", 0);
        PlayerPrefs.SetInt("sevenBillion", 0);
        PlayerPrefs.SetInt("tenBillion", 0);
        PlayerPrefs.SetInt("upgrade1", 0);
        PlayerPrefs.SetInt("upgrade2", 0);
        PlayerPrefs.SetInt("upgrade3", 0);
        PlayerPrefs.SetInt("upgrade4", 0);
        PlayerPrefs.SetInt("americaGreat", 0);

        PlayerPrefs.SetInt("Nukes", 1); //alla uppgraderingar reset:as
        PlayerPrefs.SetInt("WallLevel", 0);
        PlayerPrefs.SetInt("HotelAmount", 0);
        PlayerPrefs.SetInt("Workers", 0);
    }
}

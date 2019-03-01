using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public Vector3 startScale; //vector3 för scale:en den skall ändras till
    public TextMeshProUGUI textScore; //texten för poängen/ pengarna man får
    public Upgrades upgrades; //accessar scriptet

    private float fadeTime; //float för tiden för fade:ningen
    public float riseSpeed = 0.5f; //farten den ökar med
    public float timeSec = 0.5f; //tiden ienumeratorn har för att vänta innan den börjar fade:a
    private bool fade = false; //bool för om den ska fade:a
    // Start is called before the first frame update
    void Start()
    {
        fadeTime = 1f; //sätter tiden till 1
        transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform); //sätter objektets parent till canvas
        startScale = new Vector3(4, 4, 1); //sätter värdena på startScale
        transform.localScale = new Vector3(0, 0); //sätter pbjektets scale till 0
        upgrades = GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>(); //accessar scriptet
        textScore = GetComponent<TextMeshProUGUI>(); //hittar textkomponenten

        StartCoroutine(FadeTimer(timeSec)); //startar timern för fade:ningen
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "+" + upgrades.nukes.ToString(); //sätter texten till + och mängden poäng/ pengar man får
        transform.localScale = Vector3.MoveTowards(transform.localScale, startScale, 0.5f); //scale:ar objektet
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(960, 1040, 0), riseSpeed); //rör objektets position
        if (fadeTime <= 0) //om fade timern är 0
        {
            DestroyObject(); //förstör objektet
        }
        if (fade) //om objektet skall fade:as
        {
            fadeTime -= Time.deltaTime * 10; //räknar ned gånger 10
            textScore.color = new Color(1.0f, 1.0f, 1.0f, fadeTime);  //ändrar färgen så att fade:ningen får alpha värdet att minska tills det är osynligt
        }
    }
    IEnumerator FadeTimer(float time) //ienumerator för fade:ningens timer
    {
        yield return new WaitForSeconds(time); //väntar ett antal sekunder
        fade = true; //visar att fade skall starta
    }
    void DestroyObject() //funktion för att förstöra objektet
    {
        Destroy(gameObject); //förstör det
    }
}

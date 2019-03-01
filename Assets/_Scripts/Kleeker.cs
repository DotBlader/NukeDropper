using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Kleeker : MonoBehaviour
{
    public Vector3 target; //target scale
    public Vector3 target2; //andra target för annan storlek
    private Vector3 startScale; //objektets original scale
    public GameObject scoreText; //objektet för poängen/ pengarna man får
    public TextMeshProUGUI poangText; //själva texten för ens totala pengar
    public Upgrades upgradesScript; //accessar scriptet

    public event Action Achieve1; //events för achievements
    public event Action Achieve2;
    public event Action Achieve3;
    public event Action Achieve4;

    public float t; // float jag inte vet vad den gör
    public int score; //int för ens totala poäng/ pengar
    private bool size; //bool för om storleken skall ändras
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceKleeker>().NukeDrop += ScoreIncrease; //kopplar funktionerna till eventsen
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceKleeker>().NukeRelease += Release;
        startScale = transform.localScale; //sätter startScale till ens start scale
        upgradesScript = GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>(); //accessar objektet med scriptet på
        score = PlayerPrefs.GetInt("Score"); //sätter ens score till det score man har sparat
    }
    void Update()
    {
        PlayerPrefs.SetInt("Score", score); //sätter playerprefs inten till ens score så att det automatiskt sparas
        if (score > 0) //om man har mer än 0 score / pengar
            poangText.text = "$" + score.ToString() + " 000 000"; //sätter texten till hur det skall se ut
        else //om man inte har mer än 0 score/ pengar
            poangText.text = "$0"; //skriver att man ej har några pengar
        transform.localScale = startScale; //
        if (size) //om storleken skall ändras
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, target, t); //ändrar storleken genom att ändra med vector3.movetowards
        }
        else if (size != true) //om storleken inte skall ändras
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, target2, t); //ändrar storleken till det den var innan
        }
        if (score >= 1 && PlayerPrefs.GetInt("million") == 0) { Achieve1?.Invoke(); } //invoke:ar alla events vid rätt mängd score/ pengar 
        if (score >= 1000 && PlayerPrefs.GetInt("billion") == 0) { Achieve2?.Invoke(); }//om man inte redan har fått dem genom playerprefs
        if (score >= 7000 && PlayerPrefs.GetInt("sevenBillion") == 0) { Achieve3?.Invoke(); }
        if (score >= 50000 && PlayerPrefs.GetInt("tenBillion") == 0) { Achieve4?.Invoke(); }
    }
    void ScoreIncrease() //funktion för att öka score
    {
        size = true; //sätter att storleken skall ändras
        score = score + (1 * upgradesScript.nukes); //ökar score med mängden beroende av hur mycket man har uppgraderat More Nukes
        Instantiate(scoreText, new Vector3(960, 540, 0), transform.rotation); //spawnar in pluss score popup:en
    }
    void Release() //funktion för när man släppersin knapp
    {
        size = false; //visar att storleken skall ändras tillbaka
    }
}

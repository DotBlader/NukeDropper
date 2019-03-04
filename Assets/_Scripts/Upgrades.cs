using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Upgrades : MonoBehaviour
{
    public Kleeker kleeker; //accessar scriptet
    public event Action Upgrade1; //alla events för upgrade achievementsen
    public event Action Upgrade2;
    public event Action Upgrade3;
    public event Action Upgrade4;

    public SpaceKleeker spaceKleeker; //access script

    [Header("More Nukes Upgrade")]
    public int nukes = 1; //inten förens uppgraderings nivå
    public int[] nukeCost; //array med kostnaderna för uppgraderingen

    public TextMeshProUGUI nukeAmount;  //texterna för uppgraderingns utseende
    public TextMeshProUGUI nukeText;
    public TextMeshProUGUI nukeCostText;

    [Header("Build a Wall Upgrade")]
    public int wallLevel; //int för nivån på uppgraderingen
    public int[] wallCost; //array med kostnaderna för uppgr
    public float immigrantTimer; //timer för immigranterna som stjäl ifrån en
    public int immigrants; //basen för hur mycket som stjäls av de illegala immigranterna
    public int immigrantMulti; //multipliceras för att förändras hur mycket som stjäls

    public GameObject sprite1; // objekt för sprites
    public GameObject sprite2;
    public GameObject sprite3;
    public TextMeshProUGUI wallText; //uppgraderingens texter
    public TextMeshProUGUI wallCostText;

    [Header("Build a Hotel Upgrade")]
    public int hotelAmount; //int för nivån på uppgraderingen
    public int[] hotelCost; //array med kostnaderna för uppgraderingen
    public int hotelTaxStandard; //basen för pengarna hotellen ger en
    public int[] hotelTaxMulti; //array med antal som ändrar hur mycket hotellen ger en
    public float taxTimer; //timern för skattebetalningarna från hotellen

    public TextMeshProUGUI hotelAmountText; //uppgraderingens texter
    public TextMeshProUGUI hotelText;
    public TextMeshProUGUI hotelCostText;

    [Header("Hire Workers Upgrade")]
    public int workerAmount; //int för nivån på uppgraderingen
    public int[] workerCost; //array med kostnaderna för uppgraderingen
    public int[] timerAmount; //array med timerns max tider 
    public float timerDivider; //float som står för vad timerns max tid är
    public bool click = false; //bool för om uppgraderingen skall klicka
    private bool firstClick; //bool för första gången den klickar när scenen börjar
    private bool startClick;  //bool för det första klicket

    public TextMeshProUGUI workAmountText; //uppgraderingens texter
    public TextMeshProUGUI workText;
    public TextMeshProUGUI workCostText;

    [Header("PlayerPrefs Ints")]
    public int upgrade1Int; //ints som står för olika playerprefs
    public int upgrade2Int;
    public int upgrade3Int;
    public int upgrade4Int;
    
    void Start()
    {
        kleeker = GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>(); //hittar scripts
        spaceKleeker = GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceKleeker>();
        immigrantTimer = 4f; //sätter värdena för floats
        taxTimer = 8f;
        nukes = PlayerPrefs.GetInt("Nukes"); //sätter värdena på intsen till värdet som är sparat i playerprefs
        wallLevel = PlayerPrefs.GetInt("WallLevel");
        hotelAmount = PlayerPrefs.GetInt("HotelAmount");
        workerAmount = PlayerPrefs.GetInt("Workers");
        WorkClick(); //kör funktionen

        upgrade1Int = PlayerPrefs.GetInt("upgrade1"); //sätter intsen till det som är sparat med playerprefs
        upgrade2Int = PlayerPrefs.GetInt("upgrade2");
        upgrade3Int = PlayerPrefs.GetInt("upgrade3");
        upgrade4Int = PlayerPrefs.GetInt("upgrade4");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Nukes", nukes); //sätter playerprefs intsen till vad de ska vara för att spara ens uppgraderingars nivå
        PlayerPrefs.SetInt("WallLevel", wallLevel);
        PlayerPrefs.SetInt("HotelAmount", hotelAmount);
        PlayerPrefs.SetInt("Workers", workerAmount);

        nukeAmount.text = "x" + nukes.ToString(); //sätter alla texterna till gånger och det antalet man köpt
        
        hotelAmountText.text = "x" + (hotelAmount + 1).ToString();

        workAmountText.text = "x" + (workerAmount + 1).ToString();

        immigrantTimer -= Time.deltaTime; //timers räknar ned

        taxTimer -= Time.deltaTime;

        if (workerAmount > 0)  //om man har mer än 0 workers
            timerDivider = 10 / (timerAmount[workerAmount] - 1); //timerDivider blir hur stor del av 10 som timern ska räkna ned från
        else { timerDivider = 10; } //annars är timerDivider 10

        if (startClick != true) //om den inte har klickat en gång
        {
            WorkClick(); //kör funktionen
            startClick = true; //visar att den har klickat en gång
        }

        if (nukes < 10) //om man har mindre än 10 nukes
            nukeCostText.text = "Cost : $" + nukeCost[nukes].ToString(); //skriver texten på det sättet
        else 
        {
            if (upgrade1Int == 0) //om playerprefs inten är 0
                Upgrade1?.Invoke(); //invoke:ar eventen för upgradering 1
            nukeCostText.text = "Maxed"; //skriver att man har man har maxat uppgraderingen
            nukeText.text = "Maxed";
        }

        if (wallLevel == 0) //om ens mur har den nivån
        {
            immigrantMulti = 10; //sätter inten till 10
        }
        else if (wallLevel == 1) //om den är 1
        {
            sprite1.SetActive(true); sprite2.SetActive(false); sprite3.SetActive(false); //aktiverar och stänger av sprite:sen
            immigrantMulti = 5; //inten är lika med 5
        }
        else if (wallLevel == 2) //2
        {
            sprite1.SetActive(false); sprite2.SetActive(true); sprite3.SetActive(false); //aktiverar och stänger av sprite objekt
            immigrantMulti = 0;
        }
        else if (wallLevel == 3) //3
        {
            if (upgrade2Int == 0) //om playerprefs inten är 0, alltså om man ej har fått den innan
                Upgrade2?.Invoke(); //invoke:ar eventen
            sprite1.SetActive(false); sprite2.SetActive(false); sprite3.SetActive(true); //aktiverar och stänger av
            immigrantMulti = -100; //gör så att man inte förlorar pengar utan istället tjänar pengar
            wallText.text = "Maxed"; //skriver att den är maxad
            wallCostText.text = "Maxed";
        }
        if (wallLevel < 3) //sålänge muren inte är maxad
            wallCostText.text = "Cost : $" + wallCost[wallLevel].ToString(); //skriver kostnaden sådär
        
        if (immigrantTimer <= 0) //när timern har räknat ned
        {
            ImmigrantSteal(); //kör steal funktionen
            immigrantTimer = 4f; //resettar timern
        }

        if (hotelAmount == 9) //om ens hotel nivå är 9
        {
            if (upgrade3Int == 0) //om man inte fått achievementen enligt ens playerprefs
                Upgrade3?.Invoke(); //invoke:ar eventen
            hotelText.text = "Maxed"; //skriver att den är maxad
            hotelCostText.text = "Maxed";
        }
        if (hotelAmount < 9) //om man inte har maxat uppgraderingen
        {
            hotelCostText.text = "Cost : $" + hotelCost[hotelAmount].ToString(); //skriver sådär
        }
        if (taxTimer <= 0) //om timern räknat ned
        {
            HotelTax(); //kör funktionen
            taxTimer = 8f; //resettar timern
        }
        if (workerAmount < 9) // om den ej är maxad
        {
            workCostText.text = "Cost : $" + workerCost[workerAmount].ToString(); //skriver sådär
        }
        else if (workerAmount == 9) //om uppgraderingen är maxad
        {
            if (upgrade4Int == 0) //om man ej redan har fått achievementen
                Upgrade4?.Invoke(); //invoke:ar eventen
            workCostText.text = "Maxed"; //skriver att den är maxad
            workText.text = "Maxed";
        }
        
    }
    public void MoreNukes() //funktioner för när man köper uppgraderingar
    {
        if (nukes < 10 && kleeker.score >= nukeCost[nukes]) //om man inte har fullt uppgraderat den och man har råd att köpa den
        {
            kleeker.score -= nukeCost[nukes]; //tar bort pengarna från en
            nukes += 1; //ökar ens uppgradering
        }
    }
    public void BuildWall() //samma för alla sådana funktioner
    {
        if (wallLevel < 3 && kleeker.score >= wallCost[wallLevel])
        {
            kleeker.score -= wallCost[wallLevel];
            wallLevel += 1;
        }
    }
    public void ImmigrantSteal() //funktion för när illegala immigranter stjäl pengar ifrån en
    {
        if (kleeker.score >= (immigrants * immigrantMulti)) //om man har tillräckligt med pengar
        {
            kleeker.score -= immigrants * immigrantMulti; //tar bort så mycket pengar immigrantmulti förändrar
        }
    }
    public void BuildHotel()
    {
        if (hotelAmount < 9 && kleeker.score >= hotelCost[hotelAmount])
        {
            kleeker.score -= hotelCost[hotelAmount];
            hotelAmount += 1;
        }
    }
    public void HotelTax() //funktion för när man får betalt av sina hotel
    {
        kleeker.score += hotelTaxStandard * hotelTaxMulti[hotelAmount]; //ökar ens pengar med mängden beroende på hur många hotel man har
    }
    public void HireWork() //funktion för när man köper workers
    {
        if (workerAmount < 9 && kleeker.score >= workerCost[workerAmount]) //om uppgraderingen ej är maxad och man har råd att köpa den
        {
            kleeker.score -= workerCost[workerAmount]; //tar bort mängden pengar
            workerAmount += 1; //ökar uppgraderingens nivå
            if (firstClick != true) //om den ej har klickat sedan scenen startade
            {
                WorkClick(); //kör klick funktionen
                firstClick = true; //visar att den har klickat redan i sedan scenen böörjade
            }
        }
    }
    public void WorkClick() //funktion för när den klickar
    {
        if (click == false && workerAmount > 0) //
            StartCoroutine(spaceKleeker.BetweenClicks()); //startar timern som är tiden mellan klick
    }
    
}

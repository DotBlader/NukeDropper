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
            timerDivider = 10 / (timerAmount[workerAmount] - 1);
        else { timerDivider = 10; }

        if (startClick != true)
        {
            WorkClick();
            startClick = true;
        }

        if (nukes < 10)
            nukeCostText.text = "Cost : $" + nukeCost[nukes].ToString();
        else
        {
            if (upgrade1Int == 0)
                Upgrade1?.Invoke();
            nukeCostText.text = "Maxed";
            nukeText.text = "Maxed";
        }

        if (wallLevel == 0)
        {
            immigrantMulti = 10;
        }
        else if (wallLevel == 1)
        {
            sprite1.SetActive(true); sprite2.SetActive(false); sprite3.SetActive(false);
            immigrantMulti = 5;
        }
        else if (wallLevel == 2)
        {
            sprite1.SetActive(false); sprite2.SetActive(true); sprite3.SetActive(false);
            immigrantMulti = 0;
        }
        else if (wallLevel == 3)
        {
            if (upgrade2Int == 0)
                Upgrade2?.Invoke();
            sprite1.SetActive(false); sprite2.SetActive(false); sprite3.SetActive(true);
            immigrantMulti = -100;
            wallText.text = "Maxed";
            wallCostText.text = "Maxed";
        }
        if (wallLevel < 3)
            wallCostText.text = "Cost : $" + wallCost[wallLevel].ToString();
        
        if (immigrantTimer <= 0)
        {
            ImmigrantSteal();
            immigrantTimer = 4f;
        }

        if (hotelAmount == 9)
        {
            if (upgrade3Int == 0)
                Upgrade3?.Invoke();
            hotelText.text = "Maxed";
            hotelCostText.text = "Maxed";
        }
        if (hotelAmount < 9)
        {
            hotelCostText.text = "Cost : $" + hotelCost[hotelAmount].ToString();
        }
        if (taxTimer <= 0)
        {
            HotelTax();
            taxTimer = 8f;
        }
        if (workerAmount < 9)
        {
            workCostText.text = "Cost : $" + workerCost[workerAmount].ToString();
        }
        else if (workerAmount == 9)
        {
            if (upgrade4Int == 0)
                Upgrade4?.Invoke();
            workCostText.text = "Maxed";
            workText.text = "Maxed";
        }
        
    }
    public void MoreNukes()
    {
        if (nukes < 10 && kleeker.score >= nukeCost[nukes])
        {
            kleeker.score -= nukeCost[nukes];
            nukes += 1;
        }
    }
    public void BuildWall()
    {
        if (wallLevel < 3 && kleeker.score >= wallCost[wallLevel])
        {
            kleeker.score -= wallCost[wallLevel];
            wallLevel += 1;
        }
    }
    public void ImmigrantSteal()
    {
        if (kleeker.score >= (immigrants * immigrantMulti))
        {
            kleeker.score -= immigrants * immigrantMulti;
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
    public void HotelTax()
    {
        kleeker.score += hotelTaxStandard * hotelTaxMulti[hotelAmount];
    }
    public void HireWork()
    {
        if (workerAmount < 9 && kleeker.score >= workerCost[workerAmount])
        {
            kleeker.score -= workerCost[workerAmount];
            workerAmount += 1;
            if (firstClick != true)
            {
                WorkClick();
                firstClick = true;
            }
        }
    }
    public void WorkClick()
    {
        if (click == false && workerAmount > 0) 
            StartCoroutine(spaceKleeker.BetweenClicks());
    }
    
}

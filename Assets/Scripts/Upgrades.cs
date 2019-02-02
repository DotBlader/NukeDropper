using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Upgrades : MonoBehaviour
{
    public Kleeker kleeker;
    public event Action upgrade1;
    public event Action upgrade2;
    public event Action upgrade3;

    [Header("More Nukes Upgrade")]
    public int nukes = 1;
    public int[] nukeCost;

    public TextMeshProUGUI nukeAmount;
    public TextMeshProUGUI nukeText;
    public TextMeshProUGUI nukeCostText;

    [Header("Build a Wall Upgrade")]
    public int wallLevel;
    public int[] wallCost;
    public float immigrantTimer;
    public int immigrants;
    public int immigrantMulti;

    public GameObject sprite1;
    public GameObject sprite2;
    public GameObject sprite3;
    public TextMeshProUGUI wallText;
    public TextMeshProUGUI wallCostText;

    [Header("Build a Hotel Upgrade")]
    public int hotelAmount;
    public int[] hotelCost;
    public int hotelTaxStandard;
    public int[] hotelTaxMulti;
    public float taxTimer;

    public TextMeshProUGUI hotelAmountText;
    public TextMeshProUGUI hotelText;
    public TextMeshProUGUI hotelCostText;

    // Start is called before the first frame update
    void Start()
    {
        kleeker = GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>();
        immigrantTimer = 4f;
        taxTimer = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        nukeAmount.text = "x" + nukes.ToString();
        
        hotelAmountText.text = "x" + (hotelAmount + 1).ToString();

        immigrantTimer -= Time.deltaTime;

        taxTimer -= Time.deltaTime;

        if (nukes < 10)
            nukeCostText.text = "Cost : $" + nukeCost[nukes].ToString();
        else
        {
            upgrade1?.Invoke();
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
            upgrade2?.Invoke();
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
            upgrade3?.Invoke();
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
}

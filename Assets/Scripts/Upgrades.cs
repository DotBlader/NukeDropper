using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public int nukes = 1;
    public int[] nukeCost;

    public TextMeshProUGUI nukeAmount;
    public TextMeshProUGUI nukeText;
    public TextMeshProUGUI nukeCostText;

    public Kleeker kleeker;
    // Start is called before the first frame update
    void Start()
    {
        kleeker = GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>();
    }

    // Update is called once per frame
    void Update()
    {
        nukeAmount.text = "x" + nukes.ToString();

        if (nukes < 10)
            nukeCostText.text = "Cost : " + nukeCost[nukes].ToString();
        else
            nukeCostText.text = "Maxed";

        if (nukes == 10)
        {
            nukeText.text = "Maxed";
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
}

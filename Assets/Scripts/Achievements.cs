using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    public bool million;
    public bool billion;
    public bool sevenBillion;
    public bool tenBillion;
    public bool upgrade1;
    public bool upgrade2;
    public bool upgrade3;

    public GameObject smallLoan;
    public GameObject billionsBillions;
    public GameObject sevenBill;
    public GameObject reallyRich;
    public GameObject WW3;
    public GameObject WallUpgrade;
    public GameObject HotelUpgrade;

    public Vector2 startTrans;
    public Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().achieve1 += Achieve1;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().achieve2 += Achieve2;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().achieve3 += Achieve3;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().achieve4 += Achieve4;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Upgrades>().upgrade1 += Upgrade1;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Upgrades>().upgrade2 += Upgrade2;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Upgrades>().upgrade3 += Upgrade3;
    }
    private void Update()
    {
        
    }
    public void Achieve1()
    {
        million = true;
        smallLoan.transform.position = Vector2.MoveTowards(startTrans, target, 10f);
    }
    public void Achieve2()
    {
        billion = true;
        billionsBillions.transform.position = Vector2.MoveTowards(startTrans, target, 10f);
    }
    public void Achieve3()
    {
        sevenBillion = true;
        sevenBill.transform.position = Vector2.MoveTowards(startTrans, target, 10f);
    }
    public void Achieve4()
    {
        tenBillion = true;
        reallyRich.transform.position = Vector2.MoveTowards(startTrans, target, 10f);
    }
    public void Upgrade1()
    {
        upgrade1 = true;
        WW3.transform.position = Vector2.MoveTowards(startTrans, target, 10f);
    }
    public void Upgrade2()
    {
        upgrade2 = true;
        WallUpgrade.transform.position = Vector2.MoveTowards(startTrans, target, 10f);
    }
    public void Upgrade3()
    {
        upgrade3 = true;
        HotelUpgrade.transform.position = Vector2.MoveTowards(startTrans, target, 10f);
    }
}

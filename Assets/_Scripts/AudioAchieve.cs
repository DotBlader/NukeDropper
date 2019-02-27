using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAchieve : MonoBehaviour
{

    public AudioSource smallLoanAS;
    public AudioSource billionsAS;
    public AudioSource sevenBillAS;
    public AudioSource reallyRichAS;

    public AudioSource upgrade1AS;
    public AudioSource upgrade2AS;
    public AudioSource upgrade3AS;
    public AudioSource upgrade4AS;

    public Upgrades upgrades;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().Achieve1 += SmallLoan;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().Achieve2 += Billions;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().Achieve3 += SevenBill;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().Achieve4 += ReallyRich;
        upgrades.Upgrade1 += WorldWarThree;
        upgrades.Upgrade2 += BuildWall;
        upgrades.Upgrade3 += Hotels;
        upgrades.Upgrade4 += HireWorkers;
    }
    public void SmallLoan()
    {
        for (int i = 0; i < 1; i++)
        {
            smallLoanAS.PlayDelayed(0.5f);
        }
    }
    public void Billions()
    {
        for (int i = 0; i < 1; i++)
        {
            billionsAS.PlayDelayed(0.5f);
        }
    }
    public void SevenBill()
    {
        for (int i = 0; i < 1; i++)
        {
            sevenBillAS.PlayDelayed(0.5f);
        }
    }
    public void ReallyRich()
    {
        for (int i = 0; i < 1; i++)
        {
            reallyRichAS.PlayDelayed(0.5f);
        }
    }
    public void WorldWarThree()
    {
        for (int i = 0; i < 1; i++)
        {
            upgrade1AS.PlayDelayed(0.5f);
        }
    }
    public void BuildWall()
    {
        for (int i = 0; i < 1; i++)
        {
            upgrade2AS.PlayDelayed(0.5f);
        }
    }
    public void Hotels()
    {
        for (int i = 0; i < 1; i++)
        {
            upgrade3AS.PlayDelayed(0.5f);
        }
    }
    public void HireWorkers()
    {
        for (int i = 0; i < 1; i++)
        {
            upgrade4AS.PlayDelayed(0.5f);
        }
    }
}

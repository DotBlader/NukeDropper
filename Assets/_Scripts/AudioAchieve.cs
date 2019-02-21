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
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().achieve1 += SmallLoan;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().achieve2 += Billions;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().achieve3 += SevenBill;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().achieve4 += ReallyRich;
        GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>().upgrade1 += Upgrade1;
        GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>().upgrade2 += Upgrade2;
        GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>().upgrade3 += Upgrade3;
        GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>().upgrade4 += Upgrade4;
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void Upgrade1()
    {
        for (int i = 0; i < 1; i++)
        {
            upgrade1AS.PlayDelayed(0.5f);
        }
    }
    public void Upgrade2()
    {
        for (int i = 0; i < 1; i++)
        {
            upgrade2AS.PlayDelayed(0.5f);
        }
    }
    public void Upgrade3()
    {
        for (int i = 0; i < 1; i++)
        {
            upgrade3AS.PlayDelayed(0.5f);
        }
    }
    public void Upgrade4()
    {
        for (int i = 0; i < 1; i++)
        {
            upgrade4AS.PlayDelayed(0.5f);
        }
    }
}

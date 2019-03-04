using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAchieve : MonoBehaviour
{

    public AudioSource smallLoanAS; //alla AudioSources
    public AudioSource billionsAS;
    public AudioSource sevenBillAS;
    public AudioSource reallyRichAS;

    public AudioSource WWThreeAS;
    public AudioSource BuildWallAS;
    public AudioSource HotelsAS;
    public AudioSource WorkersAS;

    public AudioSource GreatAS;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().Achieve1 += SmallLoan; //kopplar alla funktioner till rätt event
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().Achieve2 += Billions;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().Achieve3 += SevenBill;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().Achieve4 += ReallyRich;
        GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>().Upgrade1 += WorldWarThree;
        GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>().Upgrade2 += BuildWall;
        GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>().Upgrade3 += Hotels;
        GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>().Upgrade4 += HireWorkers;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().AchieveFinal += AmericaGreat;
    }

    public void SmallLoan() //funktionerna för alla ljuduppspelningar
    {
        for (int i = 0; i < 1; i++) //ser till att det endast händer en gång
        {
            smallLoanAS.PlayDelayed(0.5f); //spelar upp ljudet med en delay på 0.5 sekunder
        }
    }
    public void Billions() //samma för alla
    {
        for (int i = 0; i < 1; i++) //ser till att det endast händer en gång
        {
            billionsAS.PlayDelayed(0.5f); //spelar upp ljudet med en delay på 0.5 sekunder
        }
    }
    public void SevenBill()
    {
        for (int i = 0; i < 1; i++) //ser till att det endast händer en gång
        {
            sevenBillAS.PlayDelayed(0.5f); //spelar upp ljudet med en delay på 0.5 sekunder
        }
    }
    public void ReallyRich()
    {
        for (int i = 0; i < 1; i++) //ser till att det endast händer en gång
        {
            reallyRichAS.PlayDelayed(0.5f); //spelar upp ljudet med en delay på 0.5 sekunder
        }
    }
    public void WorldWarThree()
    {
        for (int i = 0; i < 1; i++) //ser till att det endast händer en gång
        {
            WWThreeAS.PlayDelayed(0.5f); //spelar upp ljudet med en delay på 0.5 sekunder
        }
    }
    public void BuildWall()
    {
        for (int i = 0; i < 1; i++) //ser till att det endast händer en gång
        {
            BuildWallAS.PlayDelayed(0.5f); //spelar upp ljudet med en delay på 0.5 sekunder
        }
    }
    public void Hotels()
    {
        for (int i = 0; i < 1; i++) //ser till att det endast händer en gång
        {
            HotelsAS.PlayDelayed(0.5f); //spelar upp ljudet med en delay på 0.5 sekunder
        }
    }
    public void HireWorkers()
    {
        for (int i = 0; i < 1; i++) //ser till att det endast händer en gång
        {
            WorkersAS.PlayDelayed(0.5f); //spelar upp ljudet med en delay på 0.5 sekunder
        }
    }
    public void AmericaGreat()
    {
        for (int i = 0; i < 1; i++) //ser till att det endast händer en gång
        {
            GreatAS.PlayDelayed(0.5f); //spelar upp ljudet med en delay på 0.5 sekunder
        }
    }
}

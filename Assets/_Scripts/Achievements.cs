using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    [Header("Bools")]
    public bool million;
    public bool millionGet;

    public bool billion;
    public bool billionGet;

    public bool sevenBillion;
    public bool sevenGet;

    public bool tenBillion;
    public bool tenGet;

    public bool upgrade1;
    public bool upgrade1Get;

    public bool upgrade2;
    public bool upgrade2Get;

    public bool upgrade3;
    public bool upgrade3Get;

    public bool goBack;

    [Header("Animators")]
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public Animator anim4;
    public Animator anim5;
    public Animator anim6;
    public Animator anim7;

    [Header("GameObjects")]
    public GameObject smallLoan;
    public GameObject billionsBillions;
    public GameObject sevenBill;
    public GameObject reallyRich;
    public GameObject WW3;
    public GameObject WallUpgrade;
    public GameObject HotelUpgrade;

    public Vector3 startTrans;
    public Vector3 target;

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
        if (million == true && goBack == false && millionGet == false)
        {
            anim1.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer(2));
            
        }
        else if (million == true && goBack == true)
        {
            anim1.SetTrigger("Back");
            anim1.SetBool("Start 0", false);
            millionGet = true;
            goBack = false;
        }
        if (billion == true && goBack == false && billionGet == false)
        {
            anim2.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer2(2));

        }
        else if (billion == true && goBack == true)
        {
            anim2.SetTrigger("Back");
            anim2.SetBool("Start 0", false);
            billionGet = true;
            goBack = false;
        }
        if (sevenBillion == true && goBack == false && sevenGet == false)
        {
            anim3.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer3(2));

        }
        else if (sevenBillion == true && goBack == true)
        {
            anim3.SetTrigger("Back");
            anim3.SetBool("Start 0", false);
            sevenGet = true;
            goBack = false;
        }
        if (tenBillion == true && goBack == false && tenGet == false)
        {
            anim4.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer4(2));

        }
        else if (tenBillion == true && goBack == true)
        {
            anim4.SetTrigger("Back");
            anim4.SetBool("Start 0", false);
            tenGet = true;
            goBack = false;
        }
        if (upgrade1 == true && goBack == false && upgrade1Get == false)
        {
            anim5.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer5(2));

        }
        else if (upgrade1 == true && goBack == true)
        {
            anim5.SetTrigger("Back");
            anim5.SetBool("Start 0", false);
            upgrade1Get = true;
            goBack = false;
        }
        if (upgrade2 == true && goBack == false && upgrade2Get == false)
        {
            anim6.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer6(2));

        }
        else if (upgrade2 == true && goBack == true)
        {
            anim6.SetTrigger("Back");
            anim6.SetBool("Start 0", false);
            upgrade2Get = true;
            goBack = false;
        }
        if (upgrade3 == true && goBack == false && upgrade3Get == false)
        {
            anim7.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer7(2));

        }
        else if (upgrade3 == true && goBack == true)
        {
            anim7.SetTrigger("Back");
            anim7.SetBool("Start 0", false);
            upgrade3Get = true;
            goBack = false;
        }

    }
    public void Achieve1()
    {
        million = true;
    }
    public void Achieve2()
    {
        billion = true;
    }
    public void Achieve3()
    {
        sevenBillion = true;
    }
    public void Achieve4()
    {
        tenBillion = true;
    }
    public void Upgrade1()
    {
        upgrade1 = true;
    }
    public void Upgrade2()
    {
        upgrade2 = true;
    }
    public void Upgrade3()
    {
        upgrade3 = true;
    }
    public IEnumerator AchieveTimer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        goBack = true;
    }
    public IEnumerator AchieveTimer2(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        goBack = true;
    }
    public IEnumerator AchieveTimer3(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        goBack = true;
    }
    public IEnumerator AchieveTimer4(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        goBack = true;
    }
    public IEnumerator AchieveTimer5(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        goBack = true;
    }
    public IEnumerator AchieveTimer6(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        goBack = true;
    }
    public IEnumerator AchieveTimer7(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        goBack = true;
    }
}

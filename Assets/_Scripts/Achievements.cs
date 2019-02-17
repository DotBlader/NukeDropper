using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    public bool goBack2;
    public bool goBack3;
    public bool goBack4;
    public bool goBack5;
    public bool goBack6;
    public bool goBack7;

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
        GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>().upgrade1 += Upgrade1;
        GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>().upgrade2 += Upgrade2;
        GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>().upgrade3 += Upgrade3;

        if (PlayerPrefs.GetInt("million") == 1) { millionGet = true; }
        if (PlayerPrefs.GetInt("billion") == 1) { billionGet = true; }
        if (PlayerPrefs.GetInt("sevenBillion") == 1) { sevenGet = true; }
        if (PlayerPrefs.GetInt("tenBillion") == 1) { tenGet = true; }
        if (PlayerPrefs.GetInt("upgrade1") == 1) { upgrade1Get = true; }
        if (PlayerPrefs.GetInt("upgrade2") == 1) { upgrade2Get = true; }
        if (PlayerPrefs.GetInt("upgrade3") == 1) { upgrade3Get = true; }
    }
    private void Update()
    {
        if (million == true && goBack == false && millionGet == false)
        {
            anim1.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer(2));
            PlayerPrefs.SetInt("million", 1);
        }
        else if (million == true && goBack == true)
        {
            anim1.SetTrigger("Back");
            anim1.SetBool("Start 0", false);
            millionGet = true;
            goBack = false;
        }
        if (billion == true && goBack2 == false && billionGet == false)
        {
            anim2.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer2(2));
            PlayerPrefs.SetInt("billion", 1);
        }
        else if (billion == true && goBack2 == true)
        {
            anim2.SetTrigger("Back");
            anim2.SetBool("Start 0", false);
            billionGet = true;
            goBack2 = false;
        }
        if (sevenBillion == true && goBack3 == false && sevenGet == false)
        {
            anim3.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer3(2));
            PlayerPrefs.SetInt("sevenBillion", 1);
        }
        else if (sevenBillion == true && goBack3 == true)
        {
            anim3.SetTrigger("Back");
            anim3.SetBool("Start 0", false);
            sevenGet = true;
            goBack3 = false;
        }
        if (tenBillion == true && goBack4 == false && tenGet == false)
        {
            anim4.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer4(2));
            PlayerPrefs.SetInt("tenBillion", 1);
        }
        else if (tenBillion == true && goBack4 == true)
        {
            anim4.SetTrigger("Back");
            anim4.SetBool("Start 0", false);
            tenGet = true;
            goBack4 = false;
        }
        if (upgrade1 == true && goBack5 == false && upgrade1Get == false)
        {
            anim5.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer5(2));
            PlayerPrefs.SetInt("upgrade1", 1);
        }
        else if (upgrade1 == true && goBack5 == true)
        {
            anim5.SetTrigger("Back");
            anim5.SetBool("Start 0", false);
            upgrade1Get = true;
            goBack5 = false;
        }
        if (upgrade2 == true && goBack6 == false && upgrade2Get == false)
        {
            anim6.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer6(2));
            PlayerPrefs.SetInt("upgrade2", 1);
        }
        else if (upgrade2 == true && goBack6 == true)
        {
            anim6.SetTrigger("Back");
            anim6.SetBool("Start 0", false);
            upgrade2Get = true;
            goBack6 = false;
        }
        if (upgrade3 == true && goBack7 == false && upgrade3Get == false)
        {
            anim7.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer7(2));
            PlayerPrefs.SetInt("upgrade3", 1);
        }
        else if (upgrade3 == true && goBack7 == true)
        {
            anim7.SetTrigger("Back");
            anim7.SetBool("Start 0", false);
            upgrade3Get = true;
            goBack7 = false;
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
        for (int i = 0; i < 1; i++)
        {
            goBack = true;
        }
    }
    public IEnumerator AchieveTimer2(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        for (int i = 0; i < 1; i++)
        {
            goBack2 = true;
        }
    }
    public IEnumerator AchieveTimer3(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        for (int i = 0; i < 1; i++)
        {
            goBack3 = true;
        }
    }
    public IEnumerator AchieveTimer4(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        for (int i = 0; i < 1; i++)
        {
            goBack4 = true;
        }
    }
    public IEnumerator AchieveTimer5(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        for (int i = 0; i < 1; i++)
        {
            goBack5 = true;
        }
    }
    public IEnumerator AchieveTimer6(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        for (int i = 0; i < 1; i++)
        {
            goBack6 = true;
        }
    }
    public IEnumerator AchieveTimer7(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        for (int i = 0; i < 1; i++)
        {
            goBack7 = true;
        }
    }
}

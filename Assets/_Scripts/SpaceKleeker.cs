using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpaceKleeker : MonoBehaviour
{
    public bool click; //bool för om den skall klicka
    public bool release; //bool för release

    public Upgrades upgrades; //accessar script
    public event Action NukeDrop; //events för klick och release
    public event Action NukeRelease;

    public GameObject explosion; //explosion objektet
    public Transform canvas; //canvas:ens transform

    void Start()
    {
        upgrades = GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>(); //accessar script
    }
    void Update()
    {
        if (upgrades.click == true) //om man skall klicka
        {
            if (click == true) //om man här också skall klicka
            {
                NukeDrop?.Invoke(); //invoke:ar klick eventen
                StartCoroutine(DuringClick()); //startar ienumeratorn
                click = false; //visar att man här inte skall klicka
            }
        }
        else
        {
            if (release == true) //om man skall släppa
            {
                NukeRelease?.Invoke(); //invoke:ar släpp eventen
                release = false; //visar att man ej ska släppa
            }
        }
    }
    private void OnMouseDown() //när man klickar
    {
        NukeDrop?.Invoke(); //invoke:ar klick eventen
        Instantiate(explosion, Input.mousePosition, transform.rotation, canvas); //spawnar explosionen
    }
    private void OnMouseUpAsButton() //när man släpper musknappen
    {
        NukeRelease?.Invoke(); //invoke.ar eventen 
    }
    public IEnumerator BetweenClicks() //ienumerator för tiden mellan klicks med worker upgraderingen
    {
        if (upgrades != null) //om upgrades finns
            yield return new WaitForSeconds(upgrades.timerDivider); //väntar antal sek
        if (upgrades != null) //om den finns
            upgrades.click = true; //sätter att den skall klicka
        click = true; //sätter att den skall klicka

    }
    public IEnumerator DuringClick() //ienumerator för under klicken
    {
        yield return new WaitForSeconds(0.00000001f); //väntar frunktansvärt lite tid
        upgrades.click = false; //sätter att den ej ska klicka
        release = true; //sätter att den skall släppa
        upgrades.WorkClick(); //kör funktionen från upgrades scriptet
    }
}

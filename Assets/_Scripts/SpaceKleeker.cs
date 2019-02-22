using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpaceKleeker : MonoBehaviour
{
    public bool click;
    public bool release;

    public Upgrades upgrades;
    public event Action coochieKleek;
    public event Action coochieReleez;

    public GameObject explosion;
    public Transform canvas;

    void Start()
    {
        upgrades = GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>();
    }
    void Update()
    {
        if (upgrades.click == true)
        {
            if (click == true)
            {
                coochieKleek?.Invoke();
                StartCoroutine(DuringClick());
                click = false;
            }
        }
        else
        {
            if (release == true)
            {
                coochieReleez?.Invoke();
                release = false;
            }
        }
    }
    private void OnMouseDown()
    {
        coochieKleek?.Invoke();
        Instantiate(explosion, Input.mousePosition, transform.rotation, canvas);
    }
    private void OnMouseUpAsButton()
    {
        coochieReleez?.Invoke();
    }
    public IEnumerator BetweenClicks()
    {
        if (upgrades != null)
            yield return new WaitForSeconds(upgrades.timerDivider);
        upgrades.click = true;
        click = true;

    }
    public IEnumerator DuringClick()
    {
        yield return new WaitForSeconds(0.000001f);
        upgrades.click = false;
        release = true;
        upgrades.WorkClick();
    }
}

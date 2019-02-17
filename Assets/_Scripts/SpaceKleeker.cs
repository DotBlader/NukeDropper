using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpaceKleeker : MonoBehaviour
{
    public Upgrades upgrades;
    public event Action coochieKleek;
    public event Action coochieReleez;
    
    void Start()
    {
        upgrades = GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>();
    }
    // Update is called once per frame
    void Update()
    {
        if (upgrades.workTimer <= 0 && upgrades.click == true)
        {
            coochieKleek?.Invoke();
        }
        
        else if (upgrades.workTimer <= (10 / upgrades.timerAmount[upgrades.workerAmount]) && upgrades.workTimer > (10 / (upgrades.timerAmount[upgrades.workerAmount] - 0.01f)) && upgrades.click == false)
        {
            coochieReleez?.Invoke();
        }
            
    }
    private void OnMouseDown()
    {
        coochieKleek?.Invoke();
    }
    private void OnMouseUpAsButton()
    {
        coochieReleez?.Invoke();
    }

}

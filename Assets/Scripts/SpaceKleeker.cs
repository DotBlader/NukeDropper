using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpaceKleeker : MonoBehaviour
{
    public event Action coochieKleek;
    public event Action coochieReleez;
    // Update is called once per frame
    void Update()
    {
        
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

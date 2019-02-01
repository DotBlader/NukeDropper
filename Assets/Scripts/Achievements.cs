using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    public bool million = false;
    public bool billion = false;
    public bool sevenBillion = false;
    public bool tenBillion = false;


    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().achieve1 += Achieve1;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().achieve2 += Achieve2;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().achieve3 += Achieve3;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().achieve4 += Achieve4;
    }
    private void Update()
    {
        
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
}

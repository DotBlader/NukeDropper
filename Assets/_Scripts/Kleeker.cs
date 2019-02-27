﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Kleeker : MonoBehaviour
{
    public Vector3 target;
    public Vector3 target2;
    private Vector3 trans;
    public GameObject scoreText;
    public TextMeshProUGUI poangText;
    public Upgrades upgradesScript;

    public event Action Achieve1;
    public event Action Achieve2;
    public event Action Achieve3;
    public event Action Achieve4;

    public float t;
    public int score;
    private bool size;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceKleeker>().NukeDrop += ScoreIncrease;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceKleeker>().NukeRelease += Release;
        trans = transform.localScale;
        upgradesScript = GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>();
        score = PlayerPrefs.GetInt("Score");
    }
    void Update()
    {
        PlayerPrefs.SetInt("Score", score);
        if (score > 0)
            poangText.text = "$" + score.ToString() + " 000 000";
        else
            poangText.text = "$0";
        transform.localScale = trans;
        if (size)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, target, t);
        }
        else if (size != true)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, target2, t);
        }
        if (score >= 1 && PlayerPrefs.GetInt("million") == 0) { Achieve1?.Invoke(); }
        if (score >= 1000 && PlayerPrefs.GetInt("billion") == 0) { Achieve2?.Invoke(); }
        if (score >= 7000 && PlayerPrefs.GetInt("sevenBillion") == 0) { Achieve3?.Invoke(); }
        if (score >= 50000 && PlayerPrefs.GetInt("tenBillion") == 0) { Achieve4?.Invoke(); }
    }
    void ScoreIncrease()
    {
        size = true;
        score = score + (1 * upgradesScript.nukes);
        Instantiate(scoreText, new Vector3(960, 540, 0), transform.rotation);
    }
    void Release()
    {
        size = false;
    }
    
    
    
}

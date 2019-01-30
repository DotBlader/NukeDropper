using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Kleeker : MonoBehaviour
{
    public Vector3 target;
    public Vector3 target2;
    private Vector3 trans;
    public GameObject scoreText;
    public TextMeshProUGUI poangText;
    public Upgrades upgradesScript;

    public float t;
    public int score;
    private bool size;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceKleeker>().coochieKleek += ScoreIncrease;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpaceKleeker>().coochieReleez += Release;
        trans = transform.localScale;
        upgradesScript = GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>();
    }
    void Update()
    {
        poangText.text = "Nukes dropped : " + score.ToString();
        transform.localScale = trans;
        if (size)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, target, t);
        }
        else if (size != true)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, target2, t);
        }
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

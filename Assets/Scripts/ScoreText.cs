using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public Vector3 trans;
    public TextMeshProUGUI textScore;
    public Upgrades upgrades;

    private float fadeTime;
    public float riseSpeed = 0.5f;
    public float timeSec = 0.5f;
    private bool fade = false;
    // Start is called before the first frame update
    void Start()
    {
        fadeTime = 1f;
        transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        trans = new Vector3(4, 4, 1);
        transform.localScale = new Vector3(0, 0);
        upgrades = GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>();
        textScore = GetComponent<TextMeshProUGUI>();

        StartCoroutine(Timer(timeSec));
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "+" + upgrades.nukes.ToString(); 
        transform.localScale = Vector3.MoveTowards(transform.localScale, trans, 0.5f);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(960, 1040, 0), riseSpeed);
        if (fadeTime <= 0)
        {
            DestroyObject();
        }
        if (fade)
        {
            fadeTime -= Time.deltaTime * 10;
            this.GetComponent<TextMeshProUGUI>().color = new Color(1.0f, 1.0f, 1.0f, fadeTime); 
        }
    }
    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        FadeText();
    }
    void FadeText()
    {
        fade = true;
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}

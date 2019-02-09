using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchieveScene : MonoBehaviour
{
    public Image image;
    public string namn;
    private void Awake()
    {
        image = GetComponent<Image>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        image.color = new Color32(84, 84, 84, 228);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt(namn) == 0)
        {
            image.color = new Color32(84, 84, 84, 228);
        }
        else if (PlayerPrefs.GetInt(namn) == 1)
        {
            image.color = new Color32(0, 160, 255, 228);
        }
    }
    public void Reset()
    {
        PlayerPrefs.SetInt("Score", 0);

        PlayerPrefs.SetInt("million", 0);
        PlayerPrefs.SetInt("billion", 0);
        PlayerPrefs.SetInt("sevenBillion", 0);
        PlayerPrefs.SetInt("tenBillion", 0);
        PlayerPrefs.SetInt("upgrade1", 0);
        PlayerPrefs.SetInt("upgrade2", 0);
        PlayerPrefs.SetInt("upgrade3", 0);
    }
}

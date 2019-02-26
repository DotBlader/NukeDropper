using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musically : MonoBehaviour
{
    public int musicNum;
    public bool pauseMenuOn;

    public AudioClip[] musicClips;
    public AudioSource audioSource;
    public GameObject[] musicUI;
    public GameObject pauseMenu;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType<Musically>().Length > 1)
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
    }
    private void Start()
    {
        audioSource.clip = musicClips[musicNum];
        audioSource.Play();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuOn == false)
        {
            pauseMenu.SetActive(true);
            pauseMenuOn = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuOn == true)
        {
            pauseMenu.SetActive(false);
            pauseMenuOn = false;
            Time.timeScale = 1;
        }
        foreach (GameObject objects in musicUI)
        {
            if (objects == musicUI[musicNum])
            {
                continue;
            }
            objects.SetActive(false);
        }
        foreach (GameObject objects in musicUI)
        {
            if (objects != musicUI[musicNum])
            {
                continue;
            }
            objects.SetActive(true);
        }

    }
    public void ChangeSong()
    {
        audioSource.Stop();
        if (musicNum < (musicClips.Length - 1))
        {
            musicNum += 1;
            audioSource.clip = musicClips[musicNum];
        }
        else
        {
            musicNum = 0;
            audioSource.clip = musicClips[musicNum];
        }
        audioSource.Play();
    }
}

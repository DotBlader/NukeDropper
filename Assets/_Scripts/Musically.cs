using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musically : MonoBehaviour
{
    public int musicNum; //numret för vilket klipp som skall spelas
    public bool pauseMenuOn; //bool för om menyn skallö vara på

    public AudioClip[] musicClips; //array med music klipp
    public AudioSource audioSource; //audiosource för musiken att spelas från
    public GameObject[] musicUI; //array med objekt för bilderna i UI:n
    public GameObject pauseMenu; //pausmenyn
    private void Awake()
    {
        DontDestroyOnLoad(gameObject); //gör så att objektet inte4 förstörs när man byter scen, så att musiken inte ba plötsligt stoppar och startas igen
        if (FindObjectsOfType<Musically>().Length > 1) //om antalet objekt i scenen är mer än ett
        {
            Destroy(gameObject); //förstör objektet
        }
        audioSource = GetComponent<AudioSource>(); //sätter audioscourcen
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu"); //hittar pausmenyn
    }
    private void Start()
    {
        pauseMenuOn = false; //sätter att paumenyn ej skall vara på
        pauseMenu.SetActive(false); //stänger av paumenyn
        audioSource.clip = musicClips[musicNum]; //sätter musikklippet till det som det skall vara enligt musicNum
        audioSource.Play(); //börjar spela musiken
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuOn == false) // om man klickar på esc och spelet är på
        {
            if (pauseMenu != null) //om paumenyn finns
                pauseMenu.SetActive(true); //sätter på pausmenyn
            pauseMenuOn = true; //visar att paumenyn är på
            Time.timeScale = 0; //pausar tiden för hela spelet
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuOn == true) // om man klickar på esc när spelet är pausat
        {
            if (pauseMenu != null) //om pausmenyn finns
                pauseMenu.SetActive(false); //stänger av pausmenyn
            pauseMenuOn = false; //visar att pausmenyn är av
            Time.timeScale = 1;
        }
        foreach (GameObject objects in musicUI) //för varje objekt som finns i arrayen med objekt
        {
            if (objects == musicUI[musicNum]) //om objektet är det som enligt musicNum är det klipp som just nu ska spelas
            {
                continue; //skippar det objektet
            }
            objects.SetActive(false); //stänger av alla andra objekt
        }
        foreach (GameObject objects in musicUI) //för varje objekt i arrayen med objekt
        {
            if (objects != musicUI[musicNum]) //om objektet inte är det vars klipp spelas
            {
                continue; //skippa dem
            }
            objects.SetActive(true); //sätter på objektet
        }
        if (musicNum == 1 || musicNum == 2) //om musik numret är 1 eller 2
        {
            audioSource.volume = 1; //ändrar ljudets volym
        }
        else
        {
            audioSource.volume = 0.058f; //ändrar volymen
        }
    }
    public void ChangeSong() //funktionen som ändrar låt
    {
        audioSource.Stop(); //stoppar först musiken
        if (musicNum < (musicClips.Length - 1)) //om musicNum är mindre än längden av arrayen minus ett
        {
            musicNum += 1; //lägger till ett på musicNum
            audioSource.clip = musicClips[musicNum]; //sätter musik klippet till det som skall vara från arrayen
        }
        else //annars, om musicNum alltså är mer än eller lika med längden av arrayen minus ett
        {
            musicNum = 0; //sätter numret till 0
            audioSource.clip = musicClips[musicNum]; //sätter klippet
        }
        audioSource.Play(); //börjar spela musiken igen
    }
}

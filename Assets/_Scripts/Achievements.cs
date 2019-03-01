using System.Collections;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    [Header("Bools")]
    public bool million; // två bools för varje achievement, en för att man har fått den och en för att visa att man ska få den
    public bool millionGet;

    public bool billion;
    public bool billionGet;

    public bool sevenBillion;
    public bool sevenGet;

    public bool tenBillion;
    public bool tenGet;

    public bool wwThree;
    public bool wwThreeGet;

    public bool buildWall;
    public bool buildWallGet;

    public bool hotels;
    public bool hotelsGet;

    public bool workers;
    public bool workersGet;

    public bool goBack; //bools för att visa att tillbaka animationen skall starta
    public bool goBack2;
    public bool goBack3;
    public bool goBack4;
    public bool goBack5;
    public bool goBack6;
    public bool goBack7;
    public bool goBack8;

    [Header("Animators")] //alla animators för scen objekten
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public Animator anim4;
    public Animator anim5;
    public Animator anim6;
    public Animator anim7;
    public Animator anim8;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().Achieve1 += Achieve1; //kopplar alla funktioner till eventen från andra scripts
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().Achieve2 += Achieve2;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().Achieve3 += Achieve3;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Kleeker>().Achieve4 += Achieve4;
        GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>().Upgrade1 += Upgrade1;
        GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>().Upgrade2 += Upgrade2;
        GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>().Upgrade3 += Upgrade3;
        GameObject.FindGameObjectWithTag("Upgrades").GetComponent<Upgrades>().Upgrade4 += Upgrade4;

        if (PlayerPrefs.GetInt("million") == 1) { millionGet = true; } //sätter att man fått achievement om playerprefs säger att man har det
        if (PlayerPrefs.GetInt("billion") == 1) { billionGet = true; }
        if (PlayerPrefs.GetInt("sevenBillion") == 1) { sevenGet = true; }
        if (PlayerPrefs.GetInt("tenBillion") == 1) { tenGet = true; }
        if (PlayerPrefs.GetInt("upgrade1") == 1) { wwThreeGet = true; }
        if (PlayerPrefs.GetInt("upgrade2") == 1) { buildWallGet = true; }
        if (PlayerPrefs.GetInt("upgrade3") == 1) { hotelsGet = true; }
        if (PlayerPrefs.GetInt("upgrade4") == 1) { workersGet = true; }
    }
    private void Update()
    {
        if (million == true && goBack == false && millionGet == false) //om man inte redan har fått achievementet, objektet inte skall tillbaka och man ska få den
        {
            anim1.SetBool("Start 0", true); //startar animationen
            StartCoroutine(AchieveTimer(2)); //startar timern
            PlayerPrefs.SetInt("million", 1); //sätter att man har fått achievementet
        }
        else if (million == true && goBack == true) //om man ska få achievementet och objektet skall gå tillbaka
        {
            anim1.SetTrigger("Back"); //startar tillbaka animationen
            anim1.SetBool("Start 0", false); //avslutar start animationen
            millionGet = true; //sätter att man har fått den
            goBack = false; //visar att man inte längre skall gå tillbaka
        }
        if (billion == true && goBack2 == false && billionGet == false) //samma sak för alla achievements
        {
            anim2.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer2(2));
            PlayerPrefs.SetInt("billion", 1);
        }
        else if (billion == true && goBack2 == true)
        {
            anim2.SetTrigger("Back");
            anim2.SetBool("Start 0", false);
            billionGet = true;
            goBack2 = false;
        }
        if (sevenBillion == true && goBack3 == false && sevenGet == false)
        {
            anim3.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer3(2));
            PlayerPrefs.SetInt("sevenBillion", 1);
        }
        else if (sevenBillion == true && goBack3 == true)
        {
            anim3.SetTrigger("Back");
            anim3.SetBool("Start 0", false);
            sevenGet = true;
            goBack3 = false;
        }
        if (tenBillion == true && goBack4 == false && tenGet == false)
        {
            anim4.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer4(2));
            PlayerPrefs.SetInt("tenBillion", 1);
        }
        else if (tenBillion == true && goBack4 == true)
        {
            anim4.SetTrigger("Back");
            anim4.SetBool("Start 0", false);
            tenGet = true;
            goBack4 = false;
        }
        if (wwThree == true && goBack5 == false && wwThreeGet == false)
        {
            anim5.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer5(2));
            PlayerPrefs.SetInt("upgrade1", 1);
        }
        else if (wwThree == true && goBack5 == true)
        {
            anim5.SetTrigger("Back");
            anim5.SetBool("Start 0", false);
            wwThreeGet = true;
            goBack5 = false;
        }
        if (buildWall == true && goBack6 == false && buildWallGet == false)
        {
            anim6.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer6(2));
            PlayerPrefs.SetInt("upgrade2", 1);
        }
        else if (buildWall == true && goBack6 == true)
        {
            anim6.SetTrigger("Back");
            anim6.SetBool("Start 0", false);
            buildWallGet = true;
            goBack6 = false;
        }
        if (hotels == true && goBack7 == false && hotelsGet == false)
        {
            anim7.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer7(2));
            PlayerPrefs.SetInt("upgrade3", 1);
        }
        else if (hotels == true && goBack7 == true)
        {
            anim7.SetTrigger("Back");
            anim7.SetBool("Start 0", false);
            hotelsGet = true;
            goBack7 = false;
        }
        if (workers == true && goBack8 == false && workersGet == false)
        {
            anim8.SetBool("Start 0", true);
            StartCoroutine(AchieveTimer8(2));
            PlayerPrefs.SetInt("upgrade4", 1);
        }
        else if (workers == true && goBack8 == true)
        {
            anim8.SetTrigger("Back");
            anim8.SetBool("Start 0", false);
            workersGet = true;
            goBack8 = false;
        }

    }
    public void Achieve1() //funktioner för att visa att man skall få achievementena
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
    public void Upgrade1()
    {
        wwThree = true;
    }
    public void Upgrade2()
    {
        buildWall = true;
    }
    public void Upgrade3()
    {
        hotels = true;
    }
    public void Upgrade4()
    {
        workers = true;
    }
    public IEnumerator AchieveTimer(float seconds) //timers för popup rutorna
    {
        yield return new WaitForSeconds(seconds); //väntar antalet sekunder som krävs av funktionen
        for (int i = 0; i < 1; i++) //ser till att det bara händer så många gånger jag vill (1 gång)
        {
            goBack = true; //visar att den skall gå tillbaka
        }
    }
    public IEnumerator AchieveTimer2(float seconds) //samma sak för alla
    {
        yield return new WaitForSeconds(seconds);
        for (int i = 0; i < 1; i++)
        {
            goBack2 = true;
        }
    }
    public IEnumerator AchieveTimer3(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        for (int i = 0; i < 1; i++)
        {
            goBack3 = true;
        }
    }
    public IEnumerator AchieveTimer4(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        for (int i = 0; i < 1; i++)
        {
            goBack4 = true;
        }
    }
    public IEnumerator AchieveTimer5(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        for (int i = 0; i < 1; i++)
        {
            goBack5 = true;
        }
    }
    public IEnumerator AchieveTimer6(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        for (int i = 0; i < 1; i++)
        {
            goBack6 = true;
        }
    }
    public IEnumerator AchieveTimer7(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        for (int i = 0; i < 1; i++)
        {
            goBack7 = true;
        }
    }
    public IEnumerator AchieveTimer8(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        for (int i = 0; i < 1; i++)
        {
            goBack8 = true;
        }
    }
}

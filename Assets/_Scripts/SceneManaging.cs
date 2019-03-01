using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneManaging : MonoBehaviour
{
    public GameObject explosion; //objektet för den animerade explosionen
    public Transform canvas; //canvasens transform
    public void SceneChanger(string name) //funktion för att byta scen, kräver en string som är namnet på scenen man skall byta till
    {
        Instantiate(explosion, Input.mousePosition, transform.rotation, canvas); //spawnar in explosionen med canvas som parent vid mus positionen
        StartCoroutine(WaitForSceneChange(name)); //startar timern för scenbytet med namnet på scenen
    }
    public IEnumerator WaitForSceneChange(string name) //ienumerator för att byta scen som kräver namn på scenen man skall byta till
    {
        yield return new WaitForSeconds(1.5f); //väntar 1.5 sekunder
        SceneManager.LoadScene(name); //byter scen till den man skrivit in
    }
    public void QuitGame() //funktion för att stänga av spelet
    {
#if UNITY_EDITOR //om editorn är igång
        UnityEditor.EditorApplication.isPlaying = false; //slutar spela i editorn
#else
        Application.Quit(); //stänger annars av spelet
#endif
    }
}

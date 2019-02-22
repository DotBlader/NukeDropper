using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneManaging : MonoBehaviour
{
    public GameObject explosion;
    public Transform canvas;
    public void SceneChanger(string name)
    {
        Instantiate(explosion, Input.mousePosition, transform.rotation, canvas);
        StartCoroutine(WaitForSceneChange(name));
    }
    public IEnumerator WaitForSceneChange(string name)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(name);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

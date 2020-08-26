using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public string Level;
    public Animator fade;
    public int fadeTime;

    public void NextLevel()
    {
        StartCoroutine(LoadLevel(Level));
    }

    IEnumerator LoadLevel(string LevelName)
    {
        fade.SetTrigger("Start");
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(LevelName);
    }
}

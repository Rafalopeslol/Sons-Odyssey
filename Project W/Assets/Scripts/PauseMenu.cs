using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject Kid;
    public GameObject Dog;
    public GameObject Menu;
    public string level;
    public string NextLevel;
    public Player KidScript;
    public Dog DogScript;
    public void pause()
    {
        Kid.SetActive(false);
        Dog.SetActive(false);
        Time.timeScale = 0;
        Menu.SetActive(true);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        Menu.SetActive(false);
        Time.timeScale = 1;
        if(KidScript.selected == true)
        {
            Kid.SetActive(true);  
        }
        if (DogScript.selected == true)
        {
            Dog.SetActive(true);
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }

    public void LevelCompleted()
    {
        SceneManager.LoadScene(NextLevel);
    }
}

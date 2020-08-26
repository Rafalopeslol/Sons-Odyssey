using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash_Transicao : MonoBehaviour
{

    public void LogoJogo()
    {
        SceneManager.LoadScene("SplashJogo");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

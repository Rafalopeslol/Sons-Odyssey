using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public GameObject Object;
    public GameObject BridgeUp;
    public GameObject BridgeDown;
    public GameObject bar;
    public Ladder ladder;
    public string Type;

    private AudioSource Alavanca;

    void Awake()
    {
        Alavanca = GetComponent<AudioSource>();
    }

    public void activate()
    {
        if(Type == "Button")
        {
            Object.SetActive(true);
        }
        if(Type == "LeverBridge")
        {
            BridgeUp.SetActive(false);
            BridgeDown.SetActive(true);
            Alavanca.Play();
        }
        if(Type == "LeverLadder")
        {
            Alavanca.Play();
            ladder.BringDown();
        }
        if (Type == "LeverBar")
        {
            bar.SetActive(false);
            Alavanca.Play();
        }

    }
    
}

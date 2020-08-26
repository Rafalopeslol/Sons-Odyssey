using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{
    GameObject[] playerObject;
    public Transform[] players;
    Selected[] selectedComponents;
    public GameObject dog;
    public Player kid;
    public Transform player;
    public static Transform mainPlayer;

    private void Start()
    {
        playerObject = new GameObject[GameObject.FindGameObjectsWithTag("Player").Length];
        playerObject = GameObject.FindGameObjectsWithTag("Player");
        players = new Transform[playerObject.Length];
        selectedComponents = new Selected[playerObject.Length];
        for (int i = 0; i < playerObject.Length; i++)
        {
            players[i] = playerObject[i].transform;
            selectedComponents[i] = playerObject[i].GetComponent<Selected>();
            if (selectedComponents[i].selected)
            { 
                mainPlayer = selectedComponents[i].gameObject.transform;
            }
        }

    }

    public void ChangeCharacter(int index)
    {
       if (kid.withDog == true)
       {
            dog.SetActive(true);
            dog.transform.position = new Vector3 (player.position.x, player.position.y, player.position.z);
            kid.withDog = false;
       }
       if (kid.withDog == false)
       {

            for (int i = 0; i < selectedComponents.Length; i++)
            {
                if (i == index)
                {
                    selectedComponents[i].selected = true;
                    mainPlayer = selectedComponents[i].gameObject.transform;
                }
                else
                {
                    selectedComponents[i].selected = false;
                }
            }
        }
    }
}

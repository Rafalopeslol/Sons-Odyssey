using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncompleteLever : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject baseLever;
    public GameObject stickLever;
    public Player player;
    public Dog dog;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            player = FindObjectOfType<Player>();
            dog = FindObjectOfType<Dog>();
            if(dog.Leverpart >= 1 || player.Leverpart >= 1)
            {
                baseLever.SetActive(true);
                stickLever.SetActive(true);
                gameObject.SetActive(false);
                Debug.Log("Funcionou");
            }
        }
    }
}

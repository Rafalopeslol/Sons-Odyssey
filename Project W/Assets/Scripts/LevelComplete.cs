using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public LevelLoader load;
    public GameObject kid;
    public GameObject dog;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (Vector3.Distance(kid.transform.position, transform.position) <= 5 && Vector3.Distance(dog.transform.position, transform.position) <= 5)
            {
                load.NextLevel();
            }
            
        }
    }
}

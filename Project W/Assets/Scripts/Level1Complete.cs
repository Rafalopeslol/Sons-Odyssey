using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Complete : MonoBehaviour
{
    public LevelLoader load;
    public GameObject kid;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            load.NextLevel();        
        }
    }
}

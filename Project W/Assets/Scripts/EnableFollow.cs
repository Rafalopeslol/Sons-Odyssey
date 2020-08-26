using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFollow : MonoBehaviour
{
    public Follow dog;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Doguinho")
        {
            dog.canFollow = true;
        }
    }
}

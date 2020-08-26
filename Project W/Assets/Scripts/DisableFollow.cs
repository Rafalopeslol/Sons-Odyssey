using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFollow : MonoBehaviour
{
    public Follow dog;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Doguinho")
        {
            dog.canFollow = false;
        }
    }
}

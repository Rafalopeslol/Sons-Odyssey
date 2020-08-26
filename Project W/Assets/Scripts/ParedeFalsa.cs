using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeFalsa : MonoBehaviour
{

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            anim.SetBool("Mostrar", true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            anim.SetBool("Mostrar", false);
        }
    }
}

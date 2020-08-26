using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float speedDown;
    public float speedUp;
    public bool moveUp = false;
    public bool moveDown = false;

    void Update()
    {
       if(transform.position.y >= -0.1 && moveDown == true)
       {
            transform.Translate(Vector3.down * speedDown * Time.deltaTime);
       }

       else if(transform.position.y <= 5)
       {
            moveDown = false;
            transform.Translate(Vector3.up * speedUp * Time.deltaTime);
       }

       
    }

    public void BringDown()
    {
        moveDown = true;
    }
}

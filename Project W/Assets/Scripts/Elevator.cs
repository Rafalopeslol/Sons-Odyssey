using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speed;
    public bool moveUp = false;
    public bool moveDown = false;
    private void Update()
    {
        if (transform.position.y <= -4f && moveUp)
        {
                 
               transform.Translate(Vector3.up * speed * Time.deltaTime);

        }
        else if (transform.position.y >= -6.88f && moveDown)
        {

               transform.Translate(Vector3.down * speed * Time.deltaTime);
           
        }
    }
    public void MoveUp()
    {
        moveDown = false;
        moveUp = true;
    }
    public void MoveDown()
    {
        moveUp = false;
        moveDown = true;
       
    }
}

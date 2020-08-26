using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectPlate : MonoBehaviour
{
    public float speedDown;
    public float speedUp;
    public float minY, maxY;
    public bool moveUp = false;
    public bool moveDown = false;

    void Update()
    {
        if (transform.position.y <= maxY && moveUp == true)
        {
            transform.Translate(Vector3.up * speedUp * Time.deltaTime);
        }

        else if (transform.position.y >= minY && moveDown == true)
        {
            transform.Translate(Vector3.down * speedDown * Time.deltaTime);
        }
    }

    public void BringUp()
    {
        moveUp = true;
    }
}

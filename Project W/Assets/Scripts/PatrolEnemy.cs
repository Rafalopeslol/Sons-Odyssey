using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public float speed;
    public float minX, maxX;
    public bool moveRight = false;
    public bool moveLeft = false;

    public GameObject visionLeft;

    public GameObject visionRight;

    void Start()
    {

        moveLeft = true;
    }

    void Update()
    {
        
        if (moveLeft == true)
        {
            transform.localScale = new Vector3(1f, 1, 1);
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            visionRight.SetActive(false);
            visionLeft.SetActive(true);
        }

        else if (moveLeft == false)
        {
            transform.localScale = new Vector3(-1f, 1, 1);
            moveLeft = false;
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            visionLeft.SetActive(false);
            visionRight.SetActive(true);
        }
    }

    public void MoveLeft()
    {
        moveLeft = true; 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public float directionX;
    public float directionY;

    public float speedX = 5f;
    public float jumpForce = 300f;
    public bool facingRight, jumping, selected;
    float speed;
    public Player kid;
    public Interactable objects;
    public GameObject Buttons;
    public int Leverpart;
    Rigidbody2D rb;
    Selected sel;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sel = gameObject.GetComponent<Selected>();
        facingRight = true;
        anim.Play("Idle");

    }

    // Update is called once per frame
    void Update()
    {
        if (selected != sel.selected)
        {
            Buttons.SetActive(false);
           
    
        }
        if (selected = sel.selected)
        {
            
            Buttons.SetActive(true);
            Move(speed);
            Flip();
            
           

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                speed = -speedX;

            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                if (speed < 0)
                {
                    speed = 0;
                }


            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                speed = speedX;

            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                if (speed > 0)
                {
                    speed = 0;

                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && jumping == false)
            {
                rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
                jumping = true;
            }
        }
        anim.SetFloat("MoveX", directionX);
        anim.SetFloat("MoveY", directionY);

        anim.SetBool("Jumping", jumping);

    }
    public void CarryMe()
    {
        kid.withDog = true;
        this.gameObject.SetActive(false);
    }

    private void Move(float playerSpeed)
    {
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }

    public void Flip()
    {
        if (speed > 0 && !facingRight || speed < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            jumping = false;

        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Interactable")
        {
            objects = col.gameObject.GetComponent<Interactable>();
        }
        if (col.gameObject.tag == "Collectable")
        {
            Leverpart++;
            Destroy(col.gameObject);
        }
    }
    public void Interact()
    {
        if (objects != null)
        {
            objects.activate();
        }
    }

    public void WalkLeft()
    {
        speed = -speedX;
        directionX = -1;
        anim.SetBool("Walking", true);
    }

    public void WalkRight()
    {
        speed = speedX;
        directionX = 1;
        anim.SetBool("Walking", true);
    }
    public void Stop()
    {
        speed = 0;
        anim.SetBool("Walking", false);
    }
    public void Jump()
    {
        if (jumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            jumping = true;
        }
    }
 
}

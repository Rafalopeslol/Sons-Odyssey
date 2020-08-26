using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speedX = 5f;
    public float InputVertical;
    public float climbVelocity;
    public float climbSpeed;
    public float directionX;
    public float directionY;
    public float jumpCD;
    public float jumpForce = 300f;
    public bool facingRight, jumping, selected, walkingRight, withDog, canChange, canClimb, Climbing, Escondido;
    public Dog dog;
    public Interactable objects;
    public GameObject Tutorial1;
    public GameObject Tutorial2;
    public GameObject Buttons;
    float speed;
    public int Leverpart;
    Rigidbody2D rb;
    public Animator anim;
    Selected sel;

    private AudioSource JumpFX;

    void Awake()
    {
        JumpFX = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sel = gameObject.GetComponent<Selected>();
        facingRight = true;
        jumpCD = 300;
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
                walkingRight = false;
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
                walkingRight = true;
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
        jumpCD++;
        

    }
    public void StopClimbing()
    {
        Climbing = false;
    }
    private void Move(float playerSpeed)
    {
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }

    private void Flip()
    {
        if(speed > 0 && !facingRight || speed < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            jumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Interactable")
        {
            objects = other.gameObject.GetComponent<Interactable>();
        }
        
        if (other.gameObject.tag == "Collectable")
        {
            Leverpart++;
            Destroy(other.gameObject);
        }

        /*if (other.gameObject.tag == "Dog")
        {
            canChange = true;
        }*/

        if (other.gameObject.tag == "Ladder")
        {
            canClimb = true;
        }
        if (other.gameObject.name == "Tutorial1")
        {
            Tutorial1.SetActive(true);
        }
        if (other.gameObject.name == "Tutorial2")
        {
            Tutorial2.SetActive(true);
        }
        if (other.gameObject.tag == "Escondivel")
        {
            Escondido = true;
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            canClimb = true;
        }
        if (other.gameObject.tag == "Escondivel")
        {
            Escondido = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        //jumping = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        objects = null;
        canChange = false;
        canClimb = false;
        Escondido = false;
        rb.gravityScale = 1;
        Tutorial1.SetActive(false);
        Tutorial2.SetActive(false);
        
    }

    public void WalkLeft()
    {
        speed = -speedX;
        directionX = -1;
        walkingRight = false;
        anim.SetBool("Walking", true);
    }

    public void WalkRight()
    {
        speed = speedX;
        directionX = 1;
        walkingRight = true;
        anim.SetBool("Walking", true);
        
    }
    public void Stop()
    {
        speed = 0;
        directionX = 0;
        anim.SetBool("Walking", false);
    }

    public void Interact()
    {
        if (objects != null)
        {
            objects.activate();          
        }
        if (canChange == true)
        {      
            dog.CarryMe();
        }
    }
 
    public void Jump()
    {
        if (jumping == false && canClimb == false && jumpCD >= 30f)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));

            JumpFX.Play();

            jumping = true;
            jumpCD = 0;
        }

        if (canClimb == true)
        {
                rb.velocity = new Vector2(0, speedX);
                jumping = true;
        }

    }
}  

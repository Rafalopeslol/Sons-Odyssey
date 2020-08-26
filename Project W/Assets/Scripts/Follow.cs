using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Follow : MonoBehaviour
{
    public GameObject target;
    public Player kid;
    public bool canFollow;
    public Dog dog;
    public  float moveSpeed;
    public Rigidbody2D body;

    public Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
        canFollow = true;
    }

    public void Update()
    {
        Chase();
    }

    public void Chase()
    {
        if (dog.selected == false && canFollow == true)
        {
            if(kid.walkingRight == true)
            {
                this.gameObject.transform.position = Vector2.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z),
               new Vector3(target.transform.position.x + 1f, transform.position.y, target.transform.position.z),
               moveSpeed * Time.deltaTime);
                anim.SetBool("Walking", true);
            }

            if (kid.walkingRight == false)
            {
                this.gameObject.transform.position = Vector2.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z),
                new Vector3(target.transform.position.x - 1f, transform.position.y, target.transform.position.z),
                moveSpeed * Time.deltaTime);
                anim.SetBool("Walking", true);
            }
            else
            {
                anim.SetBool("Walking", false);
            }

            if (target.transform.position.y >= transform.position.y + 2f && dog.jumping == false)
            {
                body.AddForce(new Vector2(body.velocity.x, dog.jumpForce));
                dog.jumping = true;
                
            }
        }      
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            dog.jumping = false;

        }
    }
 
}

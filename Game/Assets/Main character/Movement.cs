using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


    }

    void FixedUpdate()
    {

        if(movement.x > 0){
            gameObject.transform.localScale = new Vector3(1,1,1);
            animator.SetFloat("Direction", 3);
        }

        else if(movement.x < 0){
            gameObject.transform.localScale = new Vector3(-1,1,1);
            animator.SetFloat("Direction", 4);
        }
        else if(movement.y > 0)
            animator.SetFloat("Direction", 1);
        else if(movement.y < 0)
            animator.SetFloat("Direction", 2);


        if(movement.y != 0 && movement.x != 0){
            rb.MovePosition(rb.position + movement * speed/2 * Time.fixedDeltaTime);
        }
        else{
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }
}

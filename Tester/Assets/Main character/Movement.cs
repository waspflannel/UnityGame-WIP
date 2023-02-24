using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 1;

    public Rigidbody2D rb;
    public Animator animator;

    public float dashDistance;

    public PlayerInfo PI;

    private PlayerControls controls;
    Vector2 movementVector;

    void Awake()
    {
        controls = new PlayerControls();
        controls.GamePlay.Enable();

    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        move();
    }

    public void move()
    {
        movementVector = controls.GamePlay.MovementInput.ReadValue<Vector2>().normalized;

        rb.AddForce(movementVector * speed, ForceMode2D.Impulse);

        animator.SetFloat("Horizontal", movementVector.x);
        animator.SetFloat("Vertical", movementVector.y);
        animator.SetFloat("Speed", movementVector.sqrMagnitude);

        if(movementVector.x > 0)
        {
            gameObject.transform.localScale = new Vector3(1,1,1);
            animator.SetFloat("Direction", 3);
        }

        else if(movementVector.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-1,1,1);
            animator.SetFloat("Direction", 4);
        }

        else if(movementVector.y > 0)
        {
            animator.SetFloat("Direction", 1);
        }

        else if(movementVector.y < 0)
        {
            animator.SetFloat("Direction", 2);
        }
    }

    public void dashMove(){
            rb.AddForce(movementVector * speed * dashDistance, ForceMode2D.Impulse);
            rb.AddForce(movementVector * speed * dashDistance, ForceMode2D.Impulse);
    }

}
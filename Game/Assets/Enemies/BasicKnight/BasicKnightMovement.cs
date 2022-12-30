using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicKnightMovement : MonoBehaviour
{
    public float speed = 2f;
    Rigidbody2D rb;
    Transform target = null;
    Vector2 moveDirection;

    private bool agro = false;
    [SerializeField] float initialAggroRange;
    public float currentAggroRange { get; set; }
        
    // Start is called before the first frame update
    void Awake()
    {
        currentAggroRange = initialAggroRange;
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(InRange() && !agro)
            agro = true;
            
        if(agro){
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }
    }

    private void FixedUpdate(){
        if(target != null){
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
        }
    }


    public bool InRange(){
        return Vector2.Distance(transform.position, GameObject.Find("Player").transform.position) < currentAggroRange;
    }

}

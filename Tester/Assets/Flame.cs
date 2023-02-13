using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector3 currVelocity;
    public Flame aFlame;

    // Start is called before the first frame update
    void Awake()
    {
        currVelocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 currentVelocity = new Vector3((float)(currVelocity.x), (float)(currVelocity.y), 0);
        //Vector3 currentVelocity = new Vector3((float)(Math.Cos(time/10)), (float)(Math.Sin(time/10)), 0);
        currentVelocity.Normalize();
        rb.velocity = currentVelocity * speed;
    }

   public void Create(Vector3 position, Vector3 givenVelocity)
    {
        Flame thisFlame = Instantiate(aFlame, position,  new Quaternion(0, 0, 0, 0));
        thisFlame.currVelocity = givenVelocity;
    }
}

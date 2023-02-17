using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector3 currVelocity;
    public Flame aFlame;
    public int damage;
    public int range;
    private int rotation = 0;
    private int change;

    void FixedUpdate()
    {
        rotationUpdate();
        rangeCheck();
        Vector3 currentVelocity = new Vector3((float)(currVelocity.x), (float)(currVelocity.y), 0);
        currentVelocity = Quaternion.Euler(0, 0, (float)rotation) * currentVelocity;
        currentVelocity.Normalize();
        rb.velocity = currentVelocity * speed;
    }

    public void Create(Vector3 position, Vector3 givenVelocity, int rotate)
    {
        Flame thisFlame = Instantiate(aFlame, position,  new Quaternion(0, 0, 0, 0));
        thisFlame.currVelocity = givenVelocity;
        thisFlame.change = rotate;
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.tag != "NotCollide")
        {
            Destroy(gameObject);
        }

        PlayerInfo player = hit.GetComponent<PlayerInfo>();
        if(player != null)
        {
            player.takeDamage(damage);
        }
    }

    void rangeCheck()
    {
        range--;
        if(range <= 0)
        {
            Destroy(gameObject);
        }
    }

    void rotationUpdate()
    {
        if(rotation <= - 90 || rotation >= 90)
        {
            change *= -1;
        }
        rotation += change;
    }
}

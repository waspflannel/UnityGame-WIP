using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameExplode : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector3 currVelocity;
    public FlameExplode explodeFlame;
    public Flame flame;
    public int damage;
    public int range;
    private int change;

    void FixedUpdate()
    {
        rb.velocity = currVelocity * speed;
        rangeCheck();
    }

    public void Create(Vector3 position, Vector3 givenVelocity)
    {
        FlameExplode thisFlame = Instantiate(explodeFlame, position,  new Quaternion(0, 0, 0, 0));
        thisFlame.currVelocity = givenVelocity;
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.tag != "NotCollide")
        {
            shootFlames();
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

    public void shootFlames(){
        List<Vector3> velocities = new List<Vector3>{new Vector3(0, -1, 0),
                                                     new Vector3((float)Math.Sqrt(2), (float)-Math.Sqrt(2), 0),
                                                     new Vector3(1, 0, 0),
                                                     new Vector3((float)Math.Sqrt(2),(float)Math.Sqrt(2), 0),
                                                     new Vector3(0, 1, 0),
                                                     new Vector3((float)-Math.Sqrt(2),(float)Math.Sqrt(2), 0),
                                                     new Vector3(-1, 0, 0),
                                                     new Vector3((float)-Math.Sqrt(2),(float)-Math.Sqrt(2), 0)};


        for(int i = 0; i<velocities.Count; i++)
        {
            flame.Create(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), velocities[i], 0);
        }
        Destroy(gameObject);
    }
}

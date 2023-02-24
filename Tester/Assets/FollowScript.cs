using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public FollowScript aBullet;
    public int damage;
    public int range;
    private Transform target;
    Vector3 targetVector;

    void FixedUpdate()
    {
        rangeCheck();
        targetVector = (target.position - gameObject.transform.position).normalized;
        gameObject.transform.Translate(targetVector * speed);
    }

    public void Create(Vector3 position, Transform target)
    {
        FollowScript thisBullet = Instantiate(aBullet, position,  new Quaternion(0, 0, 0, 0));
        thisBullet.target = target;
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

}

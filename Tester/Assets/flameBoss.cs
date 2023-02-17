using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class flameBoss : MonoBehaviour
{
    public Transform firePointCenter;
    float root2 = (float)(1.1*Math.Sqrt(2)/2);
    public Flame flame;
    public FollowScript follow;
    public Animator animator;
    public int attackCD;
    private bool inRange = false;
    public float aggroRange;
    private int currentAttackCD = 0;
    private List<Action> attacks = new List<Action>();
    private int attackChoice;

    
    // Start is called before the first frame update
    void Start()
    {
        attacks.Add(flameAttack);
        attacks.Add(followAttack);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!inRange && Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position) <= aggroRange)
        {
            inRange = true;
        }
        if(inRange)
        {
            attack();
        }
    }

    void attack()
    {
        currentAttackCD--;

        if(currentAttackCD <= 0)
        {
            attackChoice = UnityEngine.Random.Range(0, attacks.Count);
            attacks[attackChoice]();
            currentAttackCD = UnityEngine.Random.Range(attackCD-50, attackCD+50);
        }
    }

    public void flameAttack()
    {
            animator.SetFloat("Attack1", 1);
    }

    public void shootFlame(){
        List<Vector3> velocities = new List<Vector3>{new Vector3(0, -1, 0),
                                                     new Vector3((float)Math.Sqrt(2), (float)-Math.Sqrt(2), 0),
                                                     new Vector3(1, 0, 0),
                                                     new Vector3((float)Math.Sqrt(2),(float)Math.Sqrt(2), 0),
                                                     new Vector3(0, 1, 0),
                                                     new Vector3((float)-Math.Sqrt(2),(float)Math.Sqrt(2), 0),
                                                     new Vector3(-1, 0, 0),
                                                     new Vector3((float)-Math.Sqrt(2),(float)-Math.Sqrt(2), 0)};

        List<Vector3> positions = new List<Vector3>{new Vector3(0,(float)-1.1,0),
                                                    new Vector3(root2,-root2,0),
                                                    new Vector3((float)1.1,0,0),
                                                    new Vector3(root2,root2,0),
                                                    new Vector3(0,(float)1.1,0),
                                                    new Vector3(-root2,root2,0),
                                                    new Vector3((float)-1.1,0,0),
                                                    new Vector3(-root2,-root2,0)};

        int rotate = UnityEngine.Random.Range(-10, 10);
        for(int i = 0; i<positions.Count; i++)
        {
            flame.Create(new Vector3(positions[i].x + firePointCenter.position.x, positions[i].y + firePointCenter.position.y, 0), velocities[i], rotate);
        }
        animator.SetFloat("Attack1", 0);
    }

    public void followAttack()
    {
        follow.Create(new Vector3(firePointCenter.position.x,firePointCenter.position.y, 0), GameObject.Find("Player").transform);
    }
}


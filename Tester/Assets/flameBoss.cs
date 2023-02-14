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
    public Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void flameAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            animator.SetFloat("Attack1", 1);
        }
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
}


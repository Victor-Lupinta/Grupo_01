using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AguilaEnemy : MonoBehaviour
{

    public Transform[] points;
    public float moveSpeed;
    private int currentPoint;


    public SpriteRenderer theSR;

    public float distanceToAttackplayer, chaseSpeed;

    private Vector3 attackTarget;


    public float waitAfterAttack;
    private float attackCounter;

    
    void Start() 
    
   {
        for(int i = 0; i < points.Length; i++)
        {
            points[i].parent = null;
        }
     
    }

    
    // update is called once per frame 
    void Update()
    {
        if(attackCounter > 0)
        {
            attackCounter -= Time.deltaTime;
        }
        else
        {
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) > distanceToAttackplayer)
            {
                attackTarget = Vector3.zero;

                transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, points[currentPoint].position) < .05)
                {

                    currentPoint++;

                    if (currentPoint >= points.Length)
                    {
                        currentPoint = 0;
                    }

                }

                if (transform.position.x < points[currentPoint].position.x)
                {
                    theSR.flipX = true;

                }
                else if (transform.position.x > points[currentPoint].position.x)
                {
                    theSR.flipX = false;


                }

            }
            else
            {
                //atacando al jugador 
                if (attackTarget == Vector3.zero)
                {
                    attackTarget = PlayerController.instance.transform.position;
                }

                transform.position = Vector3.MoveTowards(transform.position, attackTarget, chaseSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, attackTarget) <= .1f)
                {
                    attackCounter = waitAfterAttack;
                    attackTarget = Vector3.zero;
                }


            }

        }

        

        
        
    }

}








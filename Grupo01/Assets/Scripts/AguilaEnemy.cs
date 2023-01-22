using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AguilaEnemy : MonoBehaviour
{

    public Transform[] Points;
    public float moveSpeead;
    private int currentPoint;


    public SpriteRenderer theSR;

    public float DistanceToAttackplayer, chaseSpeed;

    private Vector3 Attacktarget;

    private bool HasAttacked;
    public float waitAfterAttack;
     float attackCounter;

    
    void Start() 
    
   {
        for(int i = 0; i < Points.Length; i++)
        {
            Points[i].parent = null;
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
            if(Vector3.Distance(transform.position, PlayerController.instance.transform.position) > DistanceToAttackplayer)
        {
            transform.position = Vector3.MoveTowards(transform.position,Points[currentPoint].position, moveSpeead * Time.deltaTime);

            if (Vector3.Distance(transform.position,Points[currentPoint].position) < .05)
            {
                
                currentPoint++;

                if(currentPoint >= Points.Length)
                {
                currentPoint =0;
                }
            
            }

            if(transform.position.x < Points[currentPoint].position.x)
            {
                theSR.flipX = true;
             
            } 
            else if(transform.position.x > Points[currentPoint].position.x)
            {
                theSR.flipX = false;
            
            
            }
     
        }else
        {
            //atacando al jugador 
            if(Attacktarget == Vector3.zero)
            {
                Attacktarget = PlayerController.instance.transform.position;
            }

            transform.position = Vector3.MoveTowards(transform.position, Attacktarget, chaseSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, Attacktarget) <= .1f)
            {
                HasAttacked = true;
                attackCounter = waitAfterAttack;
                Attacktarget = Vector3.zero;
            }


        }

        }

        

        
        
    }

}







